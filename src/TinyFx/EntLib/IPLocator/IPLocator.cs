using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using TinyFx.Configuration;
using TinyFx.IO;

namespace TinyFx.EntLib
{
    /// <summary>
    /// IPv4 地址归属地查询类。 
    /// http://www.ipip.net/ 下载最新
    /// </summary>
    public static class IPLocator
    {
        private const string DATA_FILE_NAME = "17monipdb.dat";
        private static byte[] dataBuffer, indexBuffer;
        private static uint[] index = new uint[256];
        private static int offset;
        static IPLocator()
        {
            string file = null;
            var config = TinyFxConfigManager.GetConfig<IPLocatorConfig>();
            if (config != null && !string.IsNullOrEmpty(config.ResourcePath))
            {
                file = IOUtil.GetAbsolutePath(config.ResourcePath);
                if (IOUtil.IsDir(file))
                    file = Path.Combine(file, DATA_FILE_NAME);
            }
            else
            {
                file = Path.Combine(TinyFxUtil.GetAssemblyDirectory(), DATA_FILE_NAME);
                if (!File.Exists(file))
                {
                    file = Path.Combine(TinyFxUtil.GetAppDirectory(), DATA_FILE_NAME);
                }
            }
            if (!File.Exists(file))
                throw new Exception("IPv4 地址归属地数据文件17monipdb.dat没有找到，请在tinyfx.config中配置。");

            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                dataBuffer = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(dataBuffer, 0, (int)stream.Length);
            }

            var indexLength = BytesToLong(dataBuffer[0], dataBuffer[1], dataBuffer[2], dataBuffer[3]);
            indexBuffer = new byte[indexLength];
            Array.Copy(dataBuffer, 4, indexBuffer, 0, indexLength);
            offset = (int)indexLength;

            for (int loop = 0; loop < 256; loop++)
            {
                index[loop] = BytesToLong(indexBuffer[loop * 4 + 3], indexBuffer[loop * 4 + 2], indexBuffer[loop * 4 + 1], indexBuffer[loop * 4]);
            }
        }

        /// <summary>
        /// 根据IP地址获取区域信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ChinaAreaInfo FindAreaInfo(string ip)
        {
            ChinaAreaInfo ret = null;
            var infos = Find(ip);
            if (infos.Length > 1 && !string.IsNullOrEmpty(infos[1]))
            {
                var areas = ChinaAreaUtil.GetByName(infos[1]);
                if (areas.Count > 0) ret = areas[0];
            }
            return ret;
        }

        /// <summary>
        /// 查询ip地址归属库获得信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string[] Find(string ip)
        {
            var ips = ip.Split('.');
            int ip_prefix_value = int.Parse(ips[0]);
            long ip2long_value = BytesToLong(byte.Parse(ips[0]), byte.Parse(ips[1]), byte.Parse(ips[2]), byte.Parse(ips[3]));
            uint start = index[ip_prefix_value];
            int max_comp_len = offset - 1028;
            long index_offset = -1;
            int index_length = -1;
            byte b = 0;
            for (start = start * 8 + 1024; start < max_comp_len; start += 8)
            {
                if (BytesToLong(indexBuffer[start + 0], indexBuffer[start + 1], indexBuffer[start + 2], indexBuffer[start + 3]) >= ip2long_value)
                {
                    index_offset = BytesToLong(b, indexBuffer[start + 6], indexBuffer[start + 5], indexBuffer[start + 4]);
                    index_length = 0xFF & indexBuffer[start + 7];
                    break;
                }
            }
            var areaBytes = new byte[index_length];
            Array.Copy(dataBuffer, offset + (int)index_offset - 1024, areaBytes, 0, index_length);
            return Encoding.UTF8.GetString(areaBytes).Split('\t');
        }
        private static uint BytesToLong(byte a, byte b, byte c, byte d)
            => ((uint)a << 24) | ((uint)b << 16) | ((uint)c << 8) | (uint)d;
    }
}
