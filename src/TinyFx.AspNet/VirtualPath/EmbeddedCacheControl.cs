using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TinyFx.AspNet.VirtualPath
{
    /// <summary>
    /// 缓存控制类
    /// </summary>
    public class EmbeddedCacheControl
    {
        /// <summary>
        /// 缓存期
        /// </summary>
        public int MaxAge { get; set; }
        /// <summary>
        /// Cache-Control HTTP标头枚举值
        /// </summary>
        public HttpCacheability Cacheability { get; set; }
    }
}
