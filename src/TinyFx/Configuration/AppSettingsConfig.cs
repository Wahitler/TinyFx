using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TinyFx.Configuration
{
    /// <summary>
    /// AppSettings配置节
    /// </summary>
    public class AppSettingsConfig : TinyFxConfiguration
    {
        public override string GetConfigName() => "appSettings";
        public Dictionary<string, string> AppSettings = new Dictionary<string, string>();

        public override void Parse(XmlElement element)
        {
            var nodes = element.SelectNodes("/tinyFx/appSettings/*");
            if (nodes != null)
            {
                AppSettings.Clear();
                foreach (XmlElement node in nodes)
                {
                    var key = GetAttributeValue(node, "key");
                    var value = GetAttributeValue(node, "value");
                    if (AppSettings.ContainsKey(key))
                        throw new Exception($"tinyfx.config中appSettings配置节出现重复key: {key}");
                    AppSettings.Add(key, value);
                }
            }
        }

        /// <summary>
        /// 获取AppSettings中的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
            => AppSettings.ContainsKey(key) ? AppSettings[key].To<T>() : throw new Exception($"AppSettings不存在此key: {key}");
        
        /// <summary>
        /// 获取AppSettings中的值,不存在使用默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetOrDefault<T>(string key, T defaultValue)
            => AppSettings.ContainsKey(key) ? AppSettings[key].To<T>() : defaultValue;
    }
}
