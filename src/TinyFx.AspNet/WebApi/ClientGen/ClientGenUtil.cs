using Fonlow.CodeDom.Web;
using Fonlow.CodeDom.Web.Cs;
using Fonlow.CodeDom.Web.Ts;
using Fonlow.Web.Meta;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;
using TinyFx.AspNet.WebApi.ClientGen.Fonlow;
using TinyFx.AspNet.WebApi.HelpPage;

namespace TinyFx.AspNet.WebApi.ClientGen
{
    /// <summary>
    /// WebApi代码生成辅助类
    /// </summary>
    public static class ClientGenUtil
    {
        #region Fonlow
        public static string GenFonlowClientCode(FonlowGenSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");
            settings.InitSettings();
            WebApiServerPath = settings.WebApiServerPath;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve1;
            Collection<ApiDescription> descs;
            WebApiDescription[] apiDescriptions;
            try
            {
                descs = HelpPageUtil.GetApiDescriptions(settings.GetAssemblyFiles(), settings.GetXmlDocuments(), settings.RouteTemplate, settings.RouteDefaults, settings.RouteConstraints);
                apiDescriptions = descs.Select(d => MetaTransform.GetWebApiDescription(d)).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("获取WebApi描述出错。message:" + ex.Message);
            }
            var codeSettings = settings.GetCodeGenSettings(descs);
            try
            {
                string ret = null;
                switch (settings.ClientGenMode)
                {
                    case FonlowGenMode.CSharp:
                        var genCSharp = new ControllersClientApiGen(codeSettings);
                        genCSharp.ForBothAsyncAndSync = settings.GenerateBothAsyncAndSync;
                        genCSharp.CreateCodeDom(apiDescriptions);
                        ret = genCSharp.GenCode();
                        break;
                    case FonlowGenMode.JQuery:
                        var jqueryOutput = new JSOutput(codeSettings, null, false);
                        var genJQuery = new ControllersTsClientApiGen(jqueryOutput);
                        genJQuery.CreateCodeDom(apiDescriptions);
                        ret = genJQuery.GenCode();
                        break;
                    case FonlowGenMode.Angular:
                        var ng2Output = new JSOutput(codeSettings, null, true);
                        var tsGen = new ControllersTsNG2ClientApiGen(ng2Output);
                        tsGen.CreateCodeDom(apiDescriptions);
                        ret = tsGen.GenCode();
                        break;
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("获生成WebApi Typescript Client代码时出错。message:" + ex.Message);
            }
        }
        private static string WebApiServerPath = null;
        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve1(object sender, ResolveEventArgs args)
        {
            if (string.IsNullOrEmpty(WebApiServerPath)) return null;
            string[] tokens = args.Name.Split(",".ToCharArray());
            var file = Path.Combine(new string[] { WebApiServerPath, tokens[0] + ".dll" });
            return (File.Exists(file)) ? Assembly.LoadFile(file) : null;
        }
        #endregion
    }
}
