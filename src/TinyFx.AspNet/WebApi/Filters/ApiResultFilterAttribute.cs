using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Net.Http;
using TinyFx.AspNet.WebApi.Results;

namespace TinyFx.AspNet.WebApi.Filters
{
    /// <summary>
    /// 统一返回ApiOkResult结构
    /// </summary>
    public class ApiResultFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            var response = actionExecutedContext.ActionContext.Response;
            if (response == null || actionExecutedContext.Exception != null)
                return; // 异常时不处理
            // 仅处理不成功返回包装返回结构
            if ((int)response.StatusCode >= 400)
            {
                object data = null;
                if (response.Content != null)
                {
                    if (response.Content is StringContent)
                        data = response.Content.ReadAsStringAsync().Result;
                    else
                        data = response.Content.ReadAsAsync<object>().Result;
                }
                var result = new ApiErrResult()
                {
                    StatusCode = response.StatusCode,
                    Code = ApiErrorCode.Error,
                    Data = data
                };
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(response.StatusCode, result);
            }

            /*
            object result = null;
            var statusCode = response.StatusCode;
            object data = null;
            if (response.Content != null)
            {
                if (response.Content is StringContent)
                    data = response.Content.ReadAsStringAsync().Result;
                else
                    data = response.Content.ReadAsAsync<object>().Result;
            }
            if (response.IsSuccessStatusCode)
            {
                result = new ApiOkResult()
                {
                    StatusCode = statusCode,
                    Data = data
                };
            }
            else
            {
                // 错误统一返回结构并屏蔽异常返回HttpStatusCode.OK
                result = new ApiErrResult() {
                    StatusCode = statusCode,
                    Code = ApiErrorCode.Error,
                    Data = data
                };
                statusCode = System.Net.HttpStatusCode.OK; // StatusCode >= 400 修改成返回错误结构
            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(statusCode, result);
            */
        }
    }
}
