using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Configuration.AspNet
{
    /// <summary>
    /// 虚拟路径配置节
    /// 请求路径映射: ~/TinyFxResource/VirtualPath/demo.png
    /// </summary>
    public class VirtualPathElement
    {
        /// <summary>
        /// 虚拟的请求URL前缀。如：~/TinyFxResource/
        /// </summary>
        public string RequestPath { get; set; }
        /// <summary>
        /// 映射的嵌入资源路径前缀。如：TinyFx.AspNet.WebForm
        /// </summary>
        public string ResourcePath { get; set; }
        /// <summary>
        /// 程序集名称的长格式
        /// </summary>
        public string Assembly { get; set; }
    }
}
