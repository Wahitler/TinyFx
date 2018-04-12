using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using TinyFx.AspNet.VirtualPath;
using TinyFx.AspNet.WebApi.Authentication;
using TinyFx.AspNet.WebApi.Filters;
using TinyFx.AspNet.WebApi.Handlers;
using TinyFx.Configuration;
using TinyFx.Configuration.AspNet;

[assembly: PreApplicationStartMethod(typeof(TinyFx.AspNet.AspNetUtil), "PreStart")]
namespace TinyFx.AspNet
{
    /// <summary>
    /// AspNet辅助类
    /// </summary>
    public static class AspNetUtil
    {
        #region InitWebConfig
        private static bool _preStarted = false;
        private static bool _initConfiged = false;
        /// <summary>
        /// 根据配置文件tinyfx.config对当前应用程序进行配置
        /// </summary>
        public static void PreStart()
        {
            if (_preStarted) return;
            var config = TinyFxConfigManager.GetConfig<AspNetConfig>();
            if (config != null && config.PreStartConfig)
                InitWebConfig(true);
            _preStarted = true;
        }

        /// <summary>
        /// 初始化Tinyfx.config应用程序配置
        /// </summary>
        public static void InitWebConfig(bool registerVirtualPaths = false)
        {
            if (_initConfiged) return;
            var config = TinyFxConfigManager.GetConfig<AspNetConfig>();
            // 注册配置文件中的虚拟路径资源
            if (registerVirtualPaths)
                RegisterVirtualPaths();
            // 注册 WebForm 用户控件资源
            if (config.WebFormConfig != null && config.WebFormConfig.UseControls)
                EmbeddedContext.Register(typeof(AspNetUtil).Assembly, "TinyFx.AspNet.WebForm.Controls");
            #region WebApi
            var section = config.WebApiConfig;
            if (section != null)
            {
                var configuration = GlobalConfiguration.Configuration;
                // Debug Log
                if (section.DebugElement != null && (section.DebugElement.LogRequest || section.DebugElement.LogResponse))
                    configuration.MessageHandlers.Add(new LoggingRequestHandler(section.DebugElement.LogRequest, section.DebugElement.LogResponse, section.DebugElement.Logger));
                // Cors
                if (section.CorsElement != null && section.CorsElement.Enabled)
                    configuration.EnableCors(new EnableCorsAttribute(section.CorsElement.Origins, section.CorsElement.Headers, section.CorsElement.Methods));
                // Version
                if (section.VersionElement != null && section.VersionElement.VersionMode != Web.VersionControlMode.None)
                    configuration.Services.Replace(typeof(IHttpControllerSelector), new TinyFxControllerSelector(GlobalConfiguration.Configuration, section.VersionElement.VersionMode));
                // JWT Auth
                if (section.JwtAuthElement != null && section.JwtAuthElement.Enabled)
                    configuration.MessageHandlers.Add(new JwtAuthHandler());
                // ResultFilter
                if (section.ResultFilterElement != null && section.ResultFilterElement.Enabled)
                    configuration.Filters.Add(new ApiResultFilterAttribute());
                // UnhandleException
                if (section.UnhandledExceptionElement != null && section.UnhandledExceptionElement.Enabled)
                    configuration.Filters.Add(new ApiExceptionFilterAttribute());
                // Json Serialize
                if (section.JsonSerializerElement != null && section.JsonSerializerElement.Enabled)
                {
                    configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
                    var jsonSettings = configuration.Formatters.JsonFormatter.SerializerSettings;
                    jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    jsonSettings.DefaultValueHandling = section.JsonSerializerElement.DefaultValueHandling;
                    jsonSettings.NullValueHandling = section.JsonSerializerElement.NullValueHandling;
                    jsonSettings.DateFormatHandling = section.JsonSerializerElement.DateFormatHandling;
                    jsonSettings.DateFormatString = section.JsonSerializerElement.DateFormatString;
                    //jsonSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    //jsonSettings.Culture = new CultureInfo("zh-CN");
                    if (section.JsonSerializerElement.CamelCasePropertyNames)
                        jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    //jsonSettings.ContractResolver = new DefaultContractResolver();
                }
            }
            #endregion
            _initConfiged = true;
        }
        
        /// <summary>
        /// 注册虚拟路径,需要在应用程序启动前注册，如：global的静态构造函数
        /// </summary>
        public static void RegisterVirtualPaths()
        {
            var config = TinyFxConfigManager.GetConfig<AspNetConfig>();
            // 注册配置文件中的虚拟路径资源
            if (config.VirtualPaths != null && config.VirtualPaths.Count > 0)
            {
                EmbeddedContext.RegisterVirtualPaths();
                //web.config ==> <modules runAllManagedModulesForAllRequests="true"/>
                // 处理静态资源 
                HttpApplication.RegisterModule(typeof(EmbeddedModule));
                // 处理动态资源
                HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedVirtualPathProvider());
                //RouteTable.Routes.Add(new Route("WebAdmin.Resource/{id}", new EmbeddedResourceHttpHandler()));
                //DynamicModuleUtility.RegisterModule(typeof(EmbeddedModule));
            }
        }
        #endregion
    }
}
