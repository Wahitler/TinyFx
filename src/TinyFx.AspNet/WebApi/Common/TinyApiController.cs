using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Tracing;
using System.Web.SessionState;
using TinyFx.AspNet.WebApi.Filters;
using TinyFx.Configuration;

namespace TinyFx.AspNet.WebApi
{    
    /// <summary>
    /// Web API基类
    /// </summary>
    [Authorize]
    [CompressContent(CompressContentMode.Gzip)]
    public abstract class TinyApiController: ApiController
    {
        #region Environment
        /// <summary>
        /// Trace
        /// </summary>
        protected ITraceWriter TraceWriter => Configuration.Services.GetTraceWriter(); 

        /// <summary>
        /// 当前Session
        /// </summary>
        protected HttpSessionState Session
        {
            get
            {
                if (HttpContext.Current.Session == null)
                    throw new ApiErrorException(ApiErrorCode.NotSupportSession);
                return HttpContext.Current.Session;
            }
        }

        /// <summary>
        /// 当前程序运行环境
        /// </summary>
        protected RunningEnvironment RunningEnvironment
        {
            get
            {
                RunningEnvironment? value = TinyFxConfigManager.ProjectConfig?.Running;
                return value.HasValue ? value.Value : RunningEnvironment.Unknown;
            }
        }

        /// <summary>
        /// 当前用户唯一标识
        /// </summary>
        protected string UserId => Thread.CurrentPrincipal.Identity?.Name;

        /// <summary>
        /// 当前用户角色
        /// </summary>
        protected string Role
        {
            get
            {
                string role = null;
                var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
                if (identity != null)
                    role = identity.FindFirst(identity.RoleClaimType)?.Value;
                return role;
            }
        }
        #endregion

        /// <summary>
        /// 业务逻辑错误，终止并返回客户端
        /// 此方法将抛出异常并在统一异常处理中封装并返回客户端
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="exp"></param>
        public void ThrowApiError(string code= ApiErrorCode.Error, string message = null, Exception exp = null)
            => WebApiUtil.ThrowApiError(code, message, exp);
        /// <summary>
        /// 业务逻辑错误，终止并返回客户端。通知客户端仅显示message消息即可
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exp"></param>
        public void ThrowApiErrorMessage(string message, Exception exp = null)
            => WebApiUtil.ThrowApiErrorMessage(message, exp);
    }
}
