using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Xml;
using TinyFx.AspNet.WebApi.HelpPage.Microsoft.ModelDescriptions;
using TinyFx.AspNet.WebApi.HelpPage.Microsoft.Models;
using TinyFx.AspNet.WebApi.HelpPage.Microsoft;

namespace TinyFx.AspNet.WebApi.HelpPage
{
    public class ApiDescriptionHelper
    {
        /// <summary>
        /// HttpServer 实例的配置
        /// </summary>
        public HttpConfiguration Configuration { get; private set; }

        #region Constructors
        /// <summary>
        /// 构造函数，使用当前HttpServer获取Description信息
        /// </summary>
        /// <param name="documentPaths"></param>
        public ApiDescriptionHelper(List<string> documentPaths)
            : this(GlobalConfiguration.Configuration, documentPaths)
        { }
        /// <summary>
        /// 构造函数，使用指定HttpServer配置信息获取Description信息
        /// </summary>
        /// <param name="config"></param>
        /// <param name="documentPaths"></param>
        public ApiDescriptionHelper(HttpConfiguration config, List<string> documentPaths)
        {
            Configuration = HelpPageUtil.GetConfiguration(config, documentPaths);
        }
        /// <summary>
        /// 构造函数，使用自定义HttpServer配置信息获取Description信息
        /// </summary>
        /// <param name="assemblyFiles"></param>
        /// <param name="documentPaths"></param>
        /// <param name="routeTemplate"></param>
        /// <param name="defaults"></param>
        /// <param name="constraints"></param>
        public ApiDescriptionHelper(List<string> assemblyFiles, List<string> documentPaths, string routeTemplate, object defaults = null, object constraints = null)
        {
            Configuration = HelpPageUtil.GetConfiguration(assemblyFiles, documentPaths, routeTemplate, defaults, constraints);
        }
        #endregion

        public Collection<ApiDescription> ApiDescriptions 
            => Configuration.Services.GetApiExplorer().ApiDescriptions;

        public HelpPageApiModel GetHelpPageApiModel(string apiId) 
            => Configuration.GetHelpPageApiModel(apiId);

        public ModelDescription GetModelDescription(string modelName)
            => HelpPageUtil.GetModelDescription(Configuration, modelName);
    }

}
