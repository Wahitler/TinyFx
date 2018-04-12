using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TinyFx.Web;
using TinyFx;
using System.Net;
using TinyFx.AspNet.WebApi.Results;
using TinyFx.Configuration.AspNet;
using TinyFx.Configuration;

namespace TinyFx.AspNet.WebApi.Authentication
{
    /// <summary>
    /// Jwt 验证 DelegatingHandler
    /// GlobalConfiguration.Configuration.MessageHandlers.Add(new JwtAuthHandler());
    /// </summary>
    public class JwtAuthHandler: DelegatingHandler
    {
        private static bool? _responseOk;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Init();
            HttpResponseMessage errorResponse = null;
            ApiErrResult result = null;
            try
            {
                var authValue = request.Headers.Authorization;
                if (authValue == null)//没有jwt验证header，跳过
                    return base.SendAsync(request, cancellationToken);
                if (authValue.Scheme != "Bearer")
                    throw new Exception($"验证方式不是JWT，Scheme: {authValue.Scheme}");
                string token = authValue.Parameter;
                if (string.IsNullOrEmpty(token))
                    throw new Exception($"无效的jwt token：token不能为空。");
                var secret = JwtConfig.SecretKey;
                Thread.CurrentPrincipal = ValidateToken(token, secret, true);
                if (HttpContext.Current != null)
                    HttpContext.Current.User = Thread.CurrentPrincipal;
            }
            catch (JwtExpireException ex)
            {
                result = new ApiErrResult()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Code = ApiErrorCode.JwtAuthErrorExpire,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                result = new ApiErrResult()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Code = ApiErrorCode.JwtAuthError,
                    Message = ex.Message,
                };
            }
            if (result != null)
                errorResponse = request.CreateResponse(_responseOk.Value ? HttpStatusCode.OK : HttpStatusCode.Unauthorized, result);

            return errorResponse != null
                ? Task.FromResult(errorResponse)
                : base.SendAsync(request, cancellationToken);
        }

        private static ClaimsPrincipal ValidateToken(string token, string secret, bool checkExpiration)
        {
            var payload = JwtUtil.DecodeToken<JwtPayload>(token, secret);
            if (payload == null)
                throw new Exception("无效的jwt token：token格式错误。");
            if (checkExpiration)
            {
                if (payload.exp != 0)
                {
                    var expire = JwtUtil.ParseTokenExpiry(payload.exp);
                    if (expire < DateTime.UtcNow)
                        throw new JwtExpireException("无效的jwt token：token过期。", DateTime.UtcNow, expire);
                }
                if (payload.ver != null)
                {
                    // 可以与数据库比对
                }
            }
            payload.role = payload.role ?? string.Empty;
            var identity = new ClaimsIdentity("Federation", ClaimTypes.Name, ClaimTypes.Role);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, payload.name, ClaimValueTypes.String),
                new Claim(ClaimTypes.Role, payload.role, ClaimValueTypes.String),
                new Claim(ClaimTypes.Version, payload.ver.ToString(), ClaimValueTypes.String)
            };
            identity.AddClaims(claims);
            return new ClaimsPrincipal(identity);
        }

        private static void Init()
        {
            if (!_responseOk.HasValue)
            {
                var config = TinyFxConfigManager.GetConfig<AspNetConfig>();
                if (config.WebApiConfig != null && config.WebApiConfig.JwtAuthElement != null)
                    _responseOk = config.WebApiConfig.JwtAuthElement.ResponseOKStatusCode;
                else
                    _responseOk = false;
            }
        }
    }
}