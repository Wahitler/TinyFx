using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using TinyFx.Web;
using TinyFx.Configuration;
using TinyFx.Configuration.AspNet;
using TinyFx.Log4net;
using TinyFx.AspNet.WebApi.Results;

namespace TinyFx.AspNet.WebApi.Filters
{
    /// <summary>
    /// 全局异常处理
    ///   1) GlobalConfiguration.Configuration.Filters.Add(new ApiExceptionFilterAttribute());
    ///   2) ApiController上添加Attribute
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static bool _inited = false;
        private static ITinyLog _logger = null;
        private static bool _repOK;
        private static bool _repExpDetail;
        /// <summary>
        /// 处理全局异常
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Init();
            var request = actionExecutedContext.Request;
            var exception = actionExecutedContext.Exception;
            ApiErrResult result = null;
            // 业务逻辑异常或已捕获异常
            if (exception is ApiErrorException exp)
            {
                result = exp.Result;
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            else// 未处理异常
            {
                result = new ApiErrResult(ApiErrorCode.UnhandledException, "服务器未处理异常", exception);
                result.StatusCode = HttpStatusCode.InternalServerError;
                LogError(exception, request);
            }

            if (!_repExpDetail)
                result.ClearException();
            HttpStatusCode status = _repOK ? HttpStatusCode.OK : result.StatusCode;
            actionExecutedContext.Response = request.CreateResponse(status, result);
            base.OnException(actionExecutedContext);
        }
        private void LogError(Exception exp, HttpRequestMessage request)
        {
            if (exp == null || request == null || _logger == null) return;
            exp.RepairHttpException(request);
            _logger.Error("WebApi请求未处理异常", exp);
        }
        private void Init()
        {
            if (!_inited)
            {
                var config = TinyFxConfigManager.GetConfig<AspNetConfig>().WebApiConfig.UnhandledExceptionElement;
                _repOK = config.ResponseOKStatusCode;
                _repExpDetail = config.ResponseExceptionDetail;
                _logger = LogUtil.GetLogger(config.Logger);
                _inited = true;
            }
        }
    }
}
