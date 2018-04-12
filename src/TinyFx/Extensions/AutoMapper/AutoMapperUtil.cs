using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TinyFx.Configuration;

namespace TinyFx.Extensions.AutoMapper
{
    /// <summary>
    /// AutoMapper配置类
    /// 需要在Application_Start中配置AutoMapperUtil.Register(Assembly.GetAssembly(typeof(OSC.Models.IAssembly)));
    /// 其中Assembly为所有继承IMapFrom和IMapTo的程序集
    /// </summary>
    public static class AutoMapperUtil
    {
        /// <summary>
        /// 使用配置文件中的配置注册AutoMapper
        /// </summary>
        public static void Register()
        {
            var section = TinyFxConfigManager.GetConfig<AutoMapperConfig>();
            if (section == null || !section.Enabled || section.Assemblies.Count ==0)
                return;
            List<Assembly> asms = new List<Assembly>();
            foreach (var item in section.Assemblies)
            {
                string binDir = TinyFxUtil.GetAssemblyDirectory();
                var asm = item.Contains(',') 
                    ? Assembly.Load(item) 
                    : Assembly.LoadFrom(Path.Combine(binDir, item));

                asms.Add(asm);
            }
            Register(asms);
        }

        /// <summary>
        /// 注册AutoMapper，需要在应用程序启动时注册
        /// </summary>
        /// <param name="asm"></param>
        public static void Register(Assembly asm)
        {
            Register(new List<Assembly>() { asm });
        }
        /// <summary>
        /// 注册AutoMapper，需要在应用程序启动时注册
        /// </summary>
        public static void Register(List<Assembly> asms)
        {
            List<Type> types = new List<Type>();
            foreach (var asm in asms)
                types.AddRange(asm.GetExportedTypes());
            var config = GetMapperConfig(types);
            Mapper.Initialize(config);
            Mapper.AssertConfigurationIsValid();
        }
        /// <summary>
        /// 获取映射配置
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static Action<IMapperConfigurationExpression> GetMapperConfig(List<Type> types)
        {
            Action<IMapperConfigurationExpression> config = cfg =>
            {
                foreach (var type in types)
                {
                    if (!type.IsClass) continue;
                    foreach (var currInterface in type.GetInterfaces())
                    {
                        RegisterInterface(currInterface, type, cfg);
                    }
                }
            };
            return config;
        }
        private static void RegisterInterface(Type currInterface, Type type, IMapperConfigurationExpression cfg)
        {
            if (currInterface.Name.StartsWith("IMapTo`"))
            {
                RegisterMapTo(currInterface, type, cfg);
            }
            if (currInterface.Name.StartsWith("IMapFrom`"))
            {
                RegisterMapFrom(currInterface, type, cfg);
            }
        }
        private static void RegisterMapTo(Type currInterface, Type type, IMapperConfigurationExpression cfg)
        {
            foreach (var destType in currInterface.GetGenericArguments())
            {
                Action<object, object> afterFunc;
                afterFunc = (src, dest) =>
                {
                    var method = type.GetMethod("MapTo", new Type[] { destType });
                    method.Invoke(src, new object[] { dest });
                };
                cfg.CreateMap(type, destType, MemberList.None).AfterMap(afterFunc);
            }
        }
        private static void RegisterMapFrom(Type currInterface, Type type, IMapperConfigurationExpression cfg)
        {
            foreach (var srcType in currInterface.GetGenericArguments())
            {
                Action<object, object> afterFunc;
                afterFunc = (src, dest) =>
                {
                    var method = type.GetMethod("MapFrom", new Type[] { srcType });
                    method.Invoke(dest, new object[] { src });
                };
                cfg.CreateMap(srcType, type, MemberList.None).AfterMap(afterFunc);
            }
        }
    }
}
