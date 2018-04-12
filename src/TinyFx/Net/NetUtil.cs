using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TinyFx.Net
{
    /// <summary>
    /// 网络通用类
    /// </summary>
    public static class NetUtil
    {
        #region IP 操作
        /// <summary>
        /// 转换long类型的IP值为字符串类型的IP地址
        /// </summary>
        /// <param name="ip">long类型的IP值</param>
        /// <returns></returns>
        public static string GetIpString(long ip)
            => new IPAddress(ip).ToString();

        /// <summary>
        /// 转换字符串类型的IP地址为long类型的值
        /// </summary>
        /// <param name="ip">IP地址，如：127.0.0.1</param>
        /// <returns></returns>
        public static long GetIpLong(string ip)
        {
            long ret = 0;
            byte[] data = IPAddress.Parse(ip).GetAddressBytes();
            for (int i = 0; i < data.Length; i++)
            {
                ret += data[i] * (long)Math.Pow(256, i);
            }
            return ret;
        }

        /// <summary>
        /// 获取IP地址类型
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        public static IpAddressMode GetIpMode(string ip)
            => IpAddressParser.GetIpMode(ip);

        /// <summary>
        /// 获取本机内网IP集合
        /// </summary>
        /// <returns></returns>
        public static List<string> GetInterIps()
        {
            List<string> ret = new List<string>();
            var ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in ipEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ret.Add(ip.ToString());
            }
            return ret;
        }

        /// <summary>
        /// 获取IPv4地址
        /// </summary>
        /// <returns></returns>
        public static string GetInterIp()
        {
            var ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in ipEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return null;
        }
        #endregion
    }

}
