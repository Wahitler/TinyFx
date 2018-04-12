using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Windows.Win32;

namespace TinyFx.Windows.Components
{
    public static class SNTPUtil
    {
        /// <summary>
        /// 获取SNTP时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSNTPNow()
        {
            DateTime ret = SNTPClient.Now;
            if (ret == DateTime.MinValue) throw new Exception("SNTP服务器异常");
            return ret;
        }
        /// <summary>
        /// 使用指定的时间更改当前操作系统时间（需要管理员权限）
        /// </summary>
        /// <param name="newDate">指定的时间</param>
        public static void SetLocalTime(DateTime newDate)
        {
            SYSTEMTIME date = SYSTEMTIME.FromDateTime(newDate);
            if (!Win32API.SetLocalTime(ref date))
                throw new Win32Exception();
        }

        /// <summary>
        /// 同步SNTP时间到本机系统
        /// </summary>
        public static void SyncSNTPTime()
        {
            SetLocalTime(GetSNTPNow());
        }
    }
}
