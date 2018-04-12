using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TinyFx.Configuration;
using TinyFx.Configuration.AspNet;
using TinyFx.IO;

namespace TinyFx.AspNet.VirtualPath
{
    /// <summary>
    /// 嵌入资源上下文，包含静态资源和动态资源
    /// </summary>
    public static class EmbeddedContext
    {
        private static HashSet<string> _handleExts = new HashSet<string>() { ".aspx", ".ashx", ".asmx" };
        // key : requestUrl (~/TinyFxResource/VirtualPath/demo.png)
        private static Dictionary<string, EmbeddedResource> _resources = new Dictionary<string, EmbeddedResource>();
        /// <summary>
        /// 
        /// </summary>
        public const string VIRTUAL_PATH_CONTEXT_KEY = "VIRTUAL_PATH_CONTEXT_KEY";

        #region Register
        /// <summary>
        /// 通过配置文件tinyfx.config加载映射
        /// </summary>
        public static void RegisterVirtualPaths()
        {
            var config = TinyFxConfigManager.GetConfig<AspNetConfig>();
            if (config == null || config.VirtualPaths == null)
                return;
            foreach (VirtualPathElement element in config.VirtualPaths)
            {
                Register(element.Assembly, element.ResourcePath, element.RequestPath);
            }
        }
        public static void Register(string assembly, string resourcePath, string requestPath = null)
        {
            // Assembly : TinyFx.Framework.dll
            // ResourceName : TinyFx.AspNet.WebForm.VirtualPath.demo.png
            // URL : ~/TinyFxResource/VirtualPath/demo.png
            // ==> RequestPath : ~/TinyFxResource/
            // ==> ResourcePath : TinyFx.AspNet.WebForm
            Assembly asm = assembly.Contains(',') ? Assembly.Load(assembly)
                : Assembly.LoadFrom(Path.Combine(HttpRuntime.BinDirectory + assembly));
            Register(asm, resourcePath, requestPath);
        }
        public static void Register(Assembly assembly, string resourcePath, string requestPath = null)
        {
            var resourceNames = assembly.GetManifestResourceNames();

            // 通过resourcePath前缀作为过滤
            foreach (var resourceName in resourceNames.Where(name => name.StartsWith(resourcePath)))
            {
                // resourceName: TinyFx.AspNet.WebForm.VirtualPath.demo.png
                var idx = resourceName.Substring(0, resourceName.LastIndexOf('.')).LastIndexOf('.');
                var path = resourceName.Substring(0, idx);// TinyFx.AspNet.WebForm.VirtualPath
                var file = resourceName.Substring(idx + 1); // demo.png
                // ~/TinyFxResource + / + VirtualPath + / + demo.png
                string url = null;
                if (string.IsNullOrEmpty(requestPath))
                {
                    url = $"~/{path.Replace('.', '/')}/{file}";
                }
                else
                {
                    var sub = path.TrimStart(resourcePath).TrimStart('.').Replace('.', '/').Trim();
                    sub = string.IsNullOrEmpty(sub) ? "/" : $"/{sub}/";
                    url = $"{requestPath.TrimEnd('/')}{sub}{file}";
                }
                url = url.ToLower();
                //var url = string.IsNullOrEmpty(requestPath) ? $"~/{path.Replace('.', '/')}/{file}"
                //    : $"{requestPath.TrimEnd('/')}/{path.TrimStart(resourcePath).TrimStart('.').Replace('.', '/')}/{file}";
                var value = new EmbeddedResource()
                {
                    VirtualPath = url,
                    Assembly = assembly,
                    ResourceName = resourceName,
                    Data = IOUtil.ReadStreamToBytes(assembly.GetManifestResourceStream(resourceName), true),
                    IsStaticFile = !_handleExts.Contains(Path.GetExtension(resourceName).ToLower())
                };
                Register(url, value);
            }
        }
        public static void Register(string url, EmbeddedResource resource)
        {
            if (_resources.ContainsKey(url))
                throw new Exception($"虚拟映射路径已存在：{url}");
            _resources.Add(url, resource);
        }
        #endregion // Register

        /// <summary>
        /// 获取虚拟路径对应的嵌入资源对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static EmbeddedResource GetVirtualPathEmbeddedResource(HttpContext context)
        {
            try
            {
                if (!HasVirtualPath || context == null || context.Request == null)
                    return null;
            }
            catch
            {
                return null;
            }
            if (context.Items[VIRTUAL_PATH_CONTEXT_KEY] is EmbeddedResource ret)
                return ret;

            var path = context.Request.AppRelativeCurrentExecutionFilePath.ToLower(); // ~/TinyFxResource/VirtualPath/demo.png
            return _resources.ContainsKey(path) ? _resources[path] : null;
        }

        /// <summary>
        /// 是否有虚拟路径
        /// </summary>
        public static bool HasVirtualPath =>  _resources.Count > 0;
    }
}
