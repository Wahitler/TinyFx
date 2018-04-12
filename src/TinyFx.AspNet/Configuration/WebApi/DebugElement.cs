using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Configuration.AspNet.WebApi
{
    /// <summary>
    /// Debug配置节
    /// </summary>
    public class DebugElement
    {
        /// <summary>
        /// 是否记录Reqeust
        /// </summary>
        public bool LogRequest { get; set; }
        
        /// <summary>
        /// 是否记录Response
        /// </summary>
        public bool LogResponse { get; set; }

        /// <summary>
        /// 用于日志的log4net loggerName
        /// </summary>
        public string Logger { get; set; }
    }
}
