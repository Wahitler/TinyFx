using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.AspNet.WebApi
{
    public static class WebApiUtil
    {
        /// <summary>
        /// 抛出一个业务逻辑异常，并返回客户端错误码和其他信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="exp"></param>
        public static void ThrowApiError(string code= ApiErrorCode.Error, string message = null, Exception exp = null)
            => throw new ApiErrorException(code, message, exp);
        /// <summary>
        /// 业务逻辑错误，终止并返回客户端。通知客户端仅显示message消息即可
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exp"></param>
        public static void ThrowApiErrorMessage(string message, Exception exp = null)
        {
            if (string.IsNullOrEmpty(message))
                throw new Exception("ThrowApiErrMessage时返回给客户端的消息message不能为空。");
            ThrowApiError(ApiErrorCode.ShowErrorMessage, message, exp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="request"></param>
        public static void RepairHttpException(this Exception ex, HttpRequestMessage request)
        {
            // Request Url
            ex.AddUserData("Request Url", request.RequestUri.ToString());
            // Method
            ex.AddUserData("Method", request.Method.Method);
            // Headers
            foreach (var header in request.Headers)
                ex.AddUserData("Headers", "[key]: {0} [value]: {1}", header.Key, header.Value);
            // Properties
            if (request.Properties["MS_HttpRouteData"] is System.Web.Http.Routing.IHttpRouteData prop && prop != null)
            {
                var value = $"[RouteTemplate]: {prop.Route.RouteTemplate} [RouteData]: {string.Join("|", prop.Values.Values)}";
                ex.AddUserData("MS_HttpRouteData", value);
            }
            //System.Web.Http.WebHost.Routing.HostedHttpRouteData
            //foreach (var property in request.Properties)
            //    ex.AddUserData("Properties", "[key]:{0} [value]:{1}", property.Key, property.Value);
            // Content
            ex.AddUserData("Content", request.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            // Web-hosting. Needs reference to System.Web.dll
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                dynamic ctx = request.Properties["MS_HttpContext"];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }

            // Self-hosting. Needs reference to System.ServiceModel.dll. 
            if (request.Properties.ContainsKey("System.ServiceModel.Channels.RemoteEndpointMessageProperty"))
            {
                dynamic remoteEndpoint = request.Properties["System.ServiceModel.Channels.RemoteEndpointMessageProperty"];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            // Self-hosting using Owin. Needs reference to Microsoft.Owin.dll. 
            if (request.Properties.ContainsKey("MS_OwinContext"))
            {
                dynamic owinContext = request.Properties["MS_OwinContext"];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取当前请求的MultipartFormData信息，包含FormData和FileData
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static MultipartFormDataInfo GetMultipartFormDataInfo(HttpRequestMessage request)
        {
            var ret = new MultipartFormDataInfo();
            var provider = new MultipartFormDataMemoryStreamProvider();
            request.Content.ReadAsMultipartAsync(provider);
            foreach (var key in provider.FormData.AllKeys)
            {
                ret.FormData.Add(key, provider.FormData[key]);
            }
            foreach (var file in provider.FileData)
            {
                var item = new UploadFileInfo()
                {
                    ClientFileName = file.Headers.ContentDisposition.FileName,
                    ServerFileName = file.LocalFileName,
                    Stream = ((MultipartFileDataStream)file).Stream,
                };
                ret.FileData.Add(item);
            }
            return ret;
        }
    }
}
