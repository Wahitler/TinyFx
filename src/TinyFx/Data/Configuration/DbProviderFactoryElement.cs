using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Configuration.Data
{
    /// <summary>
    /// 数据库提供程序配置节
    /// </summary>
    public class DbProviderFactoryElement
    {
        /// <summary>
        /// 数据提供程序名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据提供标识
        /// </summary>
        public string Invariant { get; set; }
        /// <summary>
        /// DbProviderFactory类型
        /// </summary>
        public string  Type { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
