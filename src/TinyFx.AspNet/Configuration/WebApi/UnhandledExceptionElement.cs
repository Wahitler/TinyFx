using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Configuration.AspNet.WebApi
{
    /// <summary>
    /// 异常处理配置信息，统一返回TinyErrResult结构
    /// </summary>
    public class UnhandledExceptionElement
    {
        /// <summary>
        /// 是否使用异常处理程序
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否返回 HttpStatusCode.OK
        /// true: 返回 HttpStatusCode.OK
        /// false: 返回 HttpStatusCode.BadRequest 或者 HttpStatusCode.InternalServerError
        /// </summary>
        public bool ResponseOKStatusCode { get; set; }
        /// <summary>
        /// 是否返回客户端异常详细信息到客户端
        /// </summary>
        public bool ResponseExceptionDetail { get; set; }

        /// <summary>
        /// 用于日志的log4net loggerName
        /// </summary>
        public string Logger { get; set; }
    }
}
