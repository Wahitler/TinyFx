using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using log4net.Util;
using TinyFx.Configuration;
using TinyFx.Net;
using System.Net;

namespace TinyFx.Log4net
{
    /// <summary>
    /// 自定义log4net的properties
    /// 配置文件中可通过log4net.Layout.PatternLayout的%property{key}格式获取
    /// </summary>
    public class TinyLogProperties
    {
        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="exp"></param>
        public static void AddTinyLogProperties(PropertiesDictionary properties, Exception exp)
        {
            AddProjectId(properties);
            AddHostIp(properties);
            AddHostName(properties);
            AddExpUserData(properties, exp);
        }
        /// <summary>
        /// 添加常量参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddConstProperty(string key, string value)
        {
            _propertiesCache.TryAdd(key, value);
        }
        private static ConcurrentDictionary<string, object> _propertiesCache = new ConcurrentDictionary<string, object>();
        /// <summary>
        /// 项目标识
        /// </summary>
        public const string ProjectId = "ProjectId";
        private static void AddProjectId(PropertiesDictionary properties)
        {
            if (properties.Contains(ProjectId)) return;
            var value = _propertiesCache.GetOrAdd(ProjectId, (key) => {
                var config = TinyFxConfigManager.GetConfig<ProjectConfig>();
                return config?.Id;
            });
            properties[ProjectId] = value;
        }
        
        /// <summary>
        /// IP地址，可以是服务器地址，也可以是来源地址
        /// </summary>
        public const string HostIp = "HostIp";
        private static void AddHostIp(PropertiesDictionary properties)
        {
            if (properties.Contains(HostIp)) return;
            var value = _propertiesCache.GetOrAdd(HostIp, (key)=> {
                return NetUtil.GetInterIp();
            });
            properties[HostIp] = value;
        }

        /// <summary>
        /// 主机名称
        /// </summary>
        public const string HostName = "HostName";
        private static void AddHostName(PropertiesDictionary properties)
        {
            if (properties.Contains(HostName)) return;
            var value = _propertiesCache.GetOrAdd(HostName, (key)=> {
                return Dns.GetHostName();
            });
            properties[HostName] = value;
        }

        /// <summary>
        /// 异常用户数据
        /// </summary>
        public const string ExpUserData = "ExpUserData";
        private static void AddExpUserData(PropertiesDictionary properties, Exception exp)
        {
            if (exp == null || exp.Data == null || exp.Data.Values.Count == 0 || properties.Contains(ExpUserData)) return;
            string msg = string.Empty;
            foreach (var item in exp.Data.Values)
                msg += Convert.ToString(item) + Environment.NewLine;
            properties[ExpUserData] = msg;
        }
    }
}
