using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.BLL.Demo
{
    /// <summary>
    /// 与具体业务无关的公共方法类
    /// </summary>
    public static class DemoUtil
    {
        public static string GetCacheValue(string key)
        {
            return new DemoCache().Get(key);
        }
    }
}
