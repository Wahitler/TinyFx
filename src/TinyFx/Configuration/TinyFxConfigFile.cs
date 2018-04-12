using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Reflection;
using TinyFx;

namespace TinyFx.Configuration
{
    /// <summary>
    /// 配置文件映射管理类
    /// 在app.config或web.config中定义
    /// 
    /// </summary>
    public static class TinyFxConfigFile
    {
        /// <summary>
        /// appConfigFileMaps配置节中配的tinyfx.config文件名，提供默认值
        /// </summary>
        public static string TinyfxConfig { get; set; }
        /// <summary>
        /// appConfigFileMaps配置节中配的log4net.config文件名，提供默认值
        /// </summary>
        public static string Log4netConfig { get; set; }

        private static Dictionary<string, (string tinyfx, string log4net)> _mapsCache = new Dictionary<string, (string tinyfx, string log4net)>();

        static TinyFxConfigFile()
        {
            var element = System.Configuration.ConfigurationManager.GetSection("tinyConfigFile") as XmlElement;
            if (element == null) return;
            LoadMapsCache(element);
            FindConfigFile();
        }
        #region Utils
        private static void LoadMapsCache(XmlElement element)
        {
            _mapsCache.Clear();
            foreach (XmlElement node in element.ChildNodes)
            {
                // ips
                var ips = node.Attributes["ip"]?.Value.ToLower().Split(new char[] { ';', ',', '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (ips == null) continue;
                // tinyfx
                var tinyfx = node.Attributes["tinyfx"]?.Value;
                if (string.IsNullOrEmpty(tinyfx))
                    tinyfx = "tinyfx.config";
                var tinyfxFile = TinyFxUtil.GetAbsolutePath(tinyfx);
                // log4net
                var log4net = node.Attributes["log4net"]?.Value;
                if (string.IsNullOrEmpty(log4net))
                    log4net = "log4net.config";
                var log4netFile = TinyFxUtil.GetAbsolutePath(log4net);
                // 
                foreach (var ip in ips)
                {
                    var ipStr = ip.Trim();
                    if (ipStr.EndsWith("0.0"))
                        ipStr = ipStr.Substring(0, ipStr.Length-3);
                    _mapsCache.Add(ipStr, (tinyfxFile, log4netFile));
                }
            }
        }
        private static void FindConfigFile()
        {
            var ips = GetLocalIps();
            foreach (var ip in ips)
            {
                if (_mapsCache.ContainsKey(ip))
                {
                    TinyfxConfig = _mapsCache[ip].tinyfx;
                    Log4netConfig = _mapsCache[ip].log4net;
                    return;
                }
                var prefix = ip.Substring(0, StringUtil.IndexOf(ip, '.', 1) + 1);
                if (_mapsCache.ContainsKey(prefix))
                {
                    TinyfxConfig = _mapsCache[prefix].tinyfx;
                    Log4netConfig = _mapsCache[prefix].log4net;
                    return;
                }
            }
            if (_mapsCache.ContainsKey("(default)"))
            {
                TinyfxConfig = _mapsCache["(default)"].tinyfx;
                Log4netConfig = _mapsCache["(default)"].log4net;
                return;
            }
            TinyfxConfig = TinyFxUtil.GetAbsolutePath("tinyfx.config");
            Log4netConfig = TinyFxUtil.GetAbsolutePath("log4net.config");
        }
        private static List<string> GetLocalIps()
        {
            List<string> ret = new List<string>();
            var ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in ipEntry.AddressList)
            {
                ret.Add(ip.ToString());
            }
            return ret;
        }
        #endregion
    }
}
