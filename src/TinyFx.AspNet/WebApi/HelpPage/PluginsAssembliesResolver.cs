using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace TinyFx.AspNet.WebApi.HelpPage
{
    /// <summary>
    /// 插入应用程序集解析器
    /// </summary>
    public class PluginsAssembliesResolver : DefaultAssembliesResolver
    {
        private List<string> _assemblyFiles;
        public PluginsAssembliesResolver(List<string> assemblyFiles)
        {
            _assemblyFiles = assemblyFiles;
        }

        public override ICollection<Assembly> GetAssemblies()
        {
            List<Assembly> ret = new List<Assembly>(base.GetAssemblies());
            foreach (var file in _assemblyFiles)
            {
                var dll = file.EndsWith(".dll") ? file : $"{file}.dll";
                var asm = Assembly.LoadFrom(dll);
                ret.Add(asm);
            }
            return ret;
        }
    }

}
