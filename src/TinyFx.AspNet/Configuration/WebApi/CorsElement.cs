using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Configuration.AspNet.WebApi
{
    /// <summary>
    /// 跨域配置
    /// </summary>
    public class CorsElement
    {
        /// <summary>
        /// 是否使用跨域
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 跨域域名， ,分割
        /// </summary>
        public string Origins { get; set; }
        /// <summary>
        /// 跨域Headers ,分割
        /// </summary>
        public string Headers { get; set; }
        /// <summary>
        /// 跨域Methods ,分割
        /// </summary>
        public string Methods { get; set; }
    }
}
