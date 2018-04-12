using Fonlow.CodeDom.Web;
using Fonlow.Poco2Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Reflection;

namespace TinyFx.AspNet.WebApi.ClientGen.Fonlow
{
    [Serializable]
    public class FonlowGenSettings
    {
        public FonlowGenMode ClientGenMode { get; set; }
        /// <summary>
        /// WebApi的bin所在目录
        /// </summary>
        public string AssemblyFolder { get; set; }
        /// <summary>
        /// 应用程序集名称，在AssemblyFolder下寻找。包含WebApi服务和Models，如：DemoWebApi.dll，DemoWebApi.Models.dll
        /// 文档路径通过此名称找：DemoWebApi.xml
        /// </summary>
        public List<string> AssemblyNames { get; set; } = new List<string>();
        public List<string> XmlDocuments { get; set; } = new List<string>();
        /// <summary>
        /// 排除控制器名称，不包含Controller后缀，如：DemoWebApi.Controllers.Account
        /// </summary>
        public List<string> ExcludedControllerNames { get; set; } = new List<string>();
        /// <summary>
        /// WebApi路径模板。如：{version}/{controller}/{action}
        /// </summary>
        public string RouteTemplate { get; set; }
        /// <summary>
        /// 默认Route数据
        /// </summary>
        public object RouteDefaults { get; set; }
        /// <summary>
        /// 路由模板扩展值
        /// </summary>
        public object RouteConstraints { get; set; }

        /// <summary>
        /// 生成POCO类的方法
        /// </summary>
        public CherryPickingMethods CherryPickingMethods { get; set; } = CherryPickingMethods.DataContract;
        /// <summary>
        /// 对于.NET客户端，为每个Web API函数生成异步和同步函数
        /// </summary>
        public bool GenerateBothAsyncAndSync { get; set; } = true;
        /// <summary>
        /// 生成的TS是否使用Camel命名法
        /// </summary>
        public bool CamelCase { get; set; } = true;
        /// <summary>
        /// NG2的HTTP的POST中使用的HTTP内容类型。 因此可以使用text/plain来避免在CORS中进行预检
        /// </summary>
        public string ContentType { get; set; }
        private const string WebApiServerFolder = "WebApiServerFolder";
        public string WebApiServerPath { get; set; }
        public void InitSettings()
        {
            var currentPath = Directory.GetCurrentDirectory();
            WebApiServerPath = Path.Combine(currentPath, WebApiServerFolder);
            if (!Directory.Exists(WebApiServerPath))
                Directory.CreateDirectory(WebApiServerPath);
            
            foreach (var file in Directory.GetFiles(AssemblyFolder))
            {
                File.Copy(file, $"{WebApiServerPath}\\{Path.GetFileName(file)}", true);
            }
            foreach (var name in AssemblyNames)
            {
                //var asm = Path.Combine(WebApiServerPath, name);
                var asm =  $"{WebApiServerFolder}\\{name}";
                _assemblyFiles.Add(asm);
                var xml = Path.Combine(WebApiServerPath, $"{Path.GetFileNameWithoutExtension(asm)}.xml");
                _xmlDocuments.Add(xml);
            }
        }
        private List<string> _assemblyFiles = new List<string>();
        private List<string> _xmlDocuments = new List<string>();
        public List<string> GetAssemblyFiles() => _assemblyFiles;
        /// <summary>
        /// 获取注释文件，确保全路径
        /// </summary>
        /// <returns></returns>
        public List<string> GetXmlDocuments() => _xmlDocuments;
        public CodeGenSettings GetCodeGenSettings(Collection<ApiDescription> apiDescs)
        {
            var ret = new CodeGenSettings();
            var assemblyNames = AssemblyNames.Select(name => Path.GetFileNameWithoutExtension(name));
            if (ExcludedControllerNames == null || ExcludedControllerNames.Count == 0)
            {
                foreach (var api in apiDescs)
                {
                    var desc = api.ActionDescriptor.ControllerDescriptor;
                    if (desc.ControllerType.Name == "BaseApiController") continue;
                    if (!ExcludedControllerNames.Contains(desc.ControllerName))
                        ExcludedControllerNames.Add(desc.ControllerName);
                }
            }
            ret.ApiSelections = new CodeGenConfig()
            {
                CherryPickingMethods = (int)CherryPickingMethods,
                DataModelAssemblyNames = assemblyNames.ToArray(),
                ExcludedControllerNames = ExcludedControllerNames.ToArray()
            };
            ret.ClientApiOutputs = new CodeGenOutputs()
            {
                CamelCase = CamelCase,
                ContentType = ContentType,
                GenerateBothAsyncAndSync = GenerateBothAsyncAndSync,
            };
            return ret;
        }
    }
}
