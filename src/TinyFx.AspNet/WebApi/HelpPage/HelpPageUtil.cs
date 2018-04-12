using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Xml;
using TinyFx.AspNet.WebApi.HelpPage.Microsoft;
using TinyFx.AspNet.WebApi.HelpPage.Microsoft.ModelDescriptions;
using TinyFx.AspNet.WebApi.HelpPage.Microsoft.Models;

namespace TinyFx.AspNet.WebApi.HelpPage
{
    /// <summary>
    /// 获取WebApi描述信息的辅助类
    /// </summary>
    public static class HelpPageUtil
    {
        /// <summary>
        /// 获得HttpConfiguration
        /// </summary>
        /// <param name="assemblyFiles"></param>
        /// <param name="documentPaths"></param>
        /// <param name="routeTemplate"></param>
        /// <param name="defaults"></param>
        /// <param name="constraints"></param>
        /// <returns></returns>
        public static HttpConfiguration GetConfiguration(List<string> assemblyFiles, List<string> documentPaths, string routeTemplate = "{version}/{controller}/{action}", object defaults = null, object constraints = null)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("Default"
                , routeTemplate
                , defaults
                , constraints);
            config.Services.Replace(typeof(IAssembliesResolver), new PluginsAssembliesResolver(assemblyFiles));
            var stream = GetDocsToStream(documentPaths);
            config.SetDocumentationProvider(new XmlDocumentationProvider(stream));
            return config;
        }
        public static HttpConfiguration GetConfiguration(HttpConfiguration config, List<string> documentPaths)
        {
            var stream = GetDocsToStream(documentPaths);
            config.SetDocumentationProvider(new XmlDocumentationProvider(stream));
            return config;
        }
        /// <summary>
        /// 获取WebAPI描述信息
        /// </summary>
        /// <param name="assemblyFiles">应用程序名称</param>
        /// <param name="documentPaths">XML描述文档</param>
        /// <param name="routeTemplate"></param>
        /// <param name="defaults"></param>
        /// <param name="constraints"></param>
        /// <returns></returns>
        public static Collection<ApiDescription> GetApiDescriptions(List<string> assemblyFiles, List<string> documentPaths, string routeTemplate = "{version}/{controller}/{action}", object defaults = null, object constraints = null)
        {
            routeTemplate = routeTemplate ?? "{version}/{controller}/{action}";
            var config = GetConfiguration(assemblyFiles, documentPaths, routeTemplate, defaults, constraints);
            return GetApiDescriptions(config);
        }

        /// <summary>
        /// 获取WebAPI描述信息
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Collection<ApiDescription> GetApiDescriptions(HttpConfiguration config)
            => config.Services.GetApiExplorer().ApiDescriptions;

        private static Stream GetDocsToStream(List<string> documentPaths)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version='1.0'?>");
            sb.AppendLine("<doc>");
            sb.AppendLine("<members>");
            foreach (var docFile in documentPaths)
            {
                var xml = new XmlDocument();
                xml.Load(docFile);
                var nodes = xml.SelectNodes("/doc/members/member");
                foreach (XmlNode item in nodes)
                    sb.AppendLine(item.OuterXml);
            }
            sb.AppendLine("</members>");
            sb.AppendLine("</doc>");
            return new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        /// <summary>
        /// 获取API描述信息
        /// </summary>
        /// <param name="config"></param>
        /// <param name="apiId"></param>
        /// <returns></returns>
        public static HelpPageApiModel GetHelpPageApiModel(HttpConfiguration config, string apiId)
            => config.GetHelpPageApiModel(apiId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public static ModelDescription GetModelDescription(HttpConfiguration config, string modelName)
        {
            ModelDescription ret = null;
            ModelDescriptionGenerator modelDescriptionGenerator = config.GetModelDescriptionGenerator();
            if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out ModelDescription modelDescription))
            {
                ret = modelDescription;
            }
            return ret;
        }
    }
}
