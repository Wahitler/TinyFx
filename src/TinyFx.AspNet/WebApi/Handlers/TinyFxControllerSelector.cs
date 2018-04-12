using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using TinyFx.Web;

namespace TinyFx.AspNet.WebApi.Handlers
{
    /// <summary>
    /// 自定义Controller选择器
    /// 支持版本，需要继承旧版本的Controller，新版本类名规则 : 旧版本Controller路由名 + V + 新版本号 + Controller, 如：DemoController ==> DemoV2Controller
    /// 前端调用时添加header：api-version : 2, 或url加 api/v1/demo/get1
    /// config.Services.Replace(typeof(IHttpControllerSelector), new TinyFxControllerSelector(config, VersionControlMode.UrlParameter));
    /// </summary>
    public class TinyFxControllerSelector : DefaultHttpControllerSelector
    {
        private const string ControllerKey = "controller";
        /// <summary>
        /// 版本控制模式
        /// </summary>
        public VersionControlMode VersionControlMode { get; set; } = VersionControlMode.None;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="mode"></param>
        public TinyFxControllerSelector(HttpConfiguration configuration, VersionControlMode mode = VersionControlMode.None)
            : base(configuration)
        {
            VersionControlMode = mode;
        }
        /// <summary>
        /// 选择控制器
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override string GetControllerName(HttpRequestMessage request)
        {
            IHttpRouteData routeData = request.GetRouteData();
            if (routeData == null)
                return null;

            string controllerName = null;
            object ctrlName = null;
            routeData.Values.TryGetValue(ControllerKey, out ctrlName);
            controllerName = Convert.ToString(ctrlName);
            if (VersionControlMode != VersionControlMode.None)
                controllerName = GetVersionControllerName(request, controllerName);
            return controllerName;
        }

        #region VersionSelector
        private string GetVersionControllerName(HttpRequestMessage request, string controllerName)
        {
            IHttpRouteData routeData = request.GetRouteData();
            string version = null;
            switch (VersionControlMode)
            {
                case VersionControlMode.UrlParameter:
                    version = GetVersionFromUrl(routeData);
                    break;
                case VersionControlMode.RequestHeader:
                    version = GetVersionFromHTTPHeader(request);
                    break;
                case VersionControlMode.ContentType:
                    version = GetVersionFromContentType(request);
                    break;
                default:
                    version = GetVersionFromUrl(routeData);
                    break;
            }
            if (!string.IsNullOrEmpty(version) && version != "1")
            {
                // controllerNameV2
                controllerName = string.Concat(controllerName, "V", version);
            }
            return controllerName;
        }
        private string GetVersionFromContentType(HttpRequestMessage request)
        {
            if (request.Headers.Contains("api-version"))
            {
                var versionHeader = request.Headers.GetValues("api-version").FirstOrDefault();
                if (versionHeader != null)
                {
                    return versionHeader;
                }
            }
            return string.Empty;
        }
        private string GetVersionFromUrl(IHttpRouteData routeData)
        {
            if (routeData.Values.ContainsKey("version"))
            {
                return routeData.Values["version"].ToString().TrimStart('v', 'V');
            }
            return string.Empty;
        }
        private string GetVersionFromHTTPHeader(HttpRequestMessage request)
        {
            if (request.Headers.Contains("api-version"))
            {
                var versionHeader = request.Headers.GetValues("api-version").FirstOrDefault();
                if (versionHeader != null)
                {
                    return versionHeader;
                }
            }
            return string.Empty;
        }
        #endregion
    }

}
