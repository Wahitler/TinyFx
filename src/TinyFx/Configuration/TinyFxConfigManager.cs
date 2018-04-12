using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;

namespace TinyFx.Configuration
{
    /// <summary>
    /// TinyFx配置管理类
    /// </summary>
    public static class TinyFxConfigManager
    {
        private static bool _configured = false; // 用户是否调用Configure()进行自定义配置
        private static string _configFile = null; // 配置文件名
        //private static FileSystemWatcher _watcher;
        private const string SECTION_NAME = "tinyFx"; // Section名称

        private static XmlElement _element = null; // 获取的配置节xml信息
        // key: 继承TinyConfiguration的配置类名称 value: 配置文件中的配置信息
        private static ConcurrentDictionary<string, TinyFxConfiguration> _configCache = new ConcurrentDictionary<string, TinyFxConfiguration>();
        static TinyFxConfigManager()
        {
            //_watcher = new FileSystemWatcher();
            //_watcher.EnableRaisingEvents = false;
            //_watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.FileName;
            //_watcher.Changed += _watcher_Changed;
            //_watcher.Created += _watcher_Changed;
            //_watcher.Deleted += _watcher_Changed;
            //_watcher.Renamed += _watcher_Changed;

            if (!string.IsNullOrEmpty(TinyFxConfigFile.TinyfxConfig) && File.Exists(TinyFxConfigFile.TinyfxConfig))
            {
                InitFileConfigure(TinyFxConfigFile.TinyfxConfig, false);
            }
            else
            {
                _element = System.Configuration.ConfigurationManager.GetSection(SECTION_NAME) as XmlElement;
                var configFile = (_element != null)
                    ? (_element as System.Configuration.Internal.IConfigErrorInfo)?.Filename
                    : TinyFxUtil.GetAbsolutePath("tinyfx.config");
                if (!string.IsNullOrEmpty(configFile) && File.Exists(configFile))
                {
                    InitFileConfigure(configFile, false);
                }
            }
            if (!string.IsNullOrEmpty(TinyFxConfigFile.Log4netConfig) && File.Exists(TinyFxConfigFile.Log4netConfig))
            {
                var repository = log4net.LogManager.GetRepository(Assembly.GetExecutingAssembly());
                log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, new FileInfo(TinyFxConfigFile.Log4netConfig));
            }
        }

        //private static void _watcher_Changed(object sender, FileSystemEventArgs e)
        //{
        //    _watcher.EnableRaisingEvents = false;
        //    _element = ReadXmlElement(_configFile);
        //    _configCache.Clear();
        //    _watcher.EnableRaisingEvents = true;
        //}

        /// <summary>
        /// 自定义配置文件
        /// </summary>
        /// <param name="configFile"></param>
        public static void Configure(string configFile)
             => InitFileConfigure(configFile, true);

        private static void InitFileConfigure(string configFile, bool configured = false)
        {
            FileInfo file = new FileInfo(configFile);
            if (!file.Exists)
                throw new FileNotFoundException($"指定的配置文件不存在: {configFile}");
            _configured = configured;
            //_watcher.EnableRaisingEvents = false;
            _configFile = configFile;
            _element = ReadXmlElement(_configFile);
            _configCache.Clear();
            //_watcher.Path = file.DirectoryName;
            //_watcher.Filter = file.Name;
            //_watcher.EnableRaisingEvents = true;
        }
        private static XmlElement ReadXmlElement(string configFile)
        {
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            var doc = new XmlDocument();
            doc.Load(configFile);
            return doc.DocumentElement;
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetConfig<T>()
            where T : TinyFxConfiguration
        {
            var type = typeof(T);
            var typeName = type.FullName;
            if (_configCache.TryGetValue(typeName, out TinyFxConfiguration value))
                return (T)value;
            // 不存在，重新获取
            if (!type.IsSubclassOf(typeof(TinyFxConfiguration)))
                throw new Exception($"配置类型{typeName}必须继承TinyConfiguration");
            var obj = Activator.CreateInstance(type) as TinyFxConfiguration;

            var configElement = GetConfigElement(_element, obj.GetConfigName());
            if (configElement != null)
                obj.Parse(configElement);
            _configCache.TryAdd(typeName, obj);
            return (T)obj;
        }

        /// <summary>
        /// 指定配置文件获取配置信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configFile"></param>
        /// <returns></returns>
        public static T GetConfig<T>(string configFile)
            where T : TinyFxConfiguration
        {
            if (!File.Exists(configFile))
                throw new Exception($"配置文件{configFile}不存在。");
            var ret = Activator.CreateInstance(typeof(T)) as TinyFxConfiguration;
            var element = ReadXmlElement(configFile);
            var configElement = GetConfigElement(element, ret.GetConfigName());
            if (configElement != null)
                ret.Parse(configElement);
            return (T)ret;
        }
        private static XmlElement GetConfigElement(XmlElement element, string elementName)
        {
            if (element == null) return null;
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            return element.SelectSingleNode($"/{SECTION_NAME}/{elementName}") as XmlElement;
        }

        /// <summary>
        /// 获取应用程序配置信息
        /// </summary>
        public static ProjectConfig ProjectConfig => GetConfig<ProjectConfig>();

        #region AppSettings
        /// <summary>
        /// 获取tinyfx.config中AppSettings
        /// </summary>
        public static Dictionary<string, string> AppSettings => GetConfig<AppSettingsConfig>().AppSettings;
        /// <summary>
        /// 获取tinyfx.config中AppSettings节配置的AppSetting
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            var settings = GetConfig<AppSettingsConfig>();
            return settings.AppSettings.ContainsKey(key) ? settings.AppSettings[key] : null;
        }
        /// <summary>
        /// 获取tinyfx.config中AppSettings节配置的AppSetting
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetAppSetting<T>(string key)
            => TinyFxUtil.ConvertTo<T>(GetAppSetting(key));
        #endregion
    }
}
