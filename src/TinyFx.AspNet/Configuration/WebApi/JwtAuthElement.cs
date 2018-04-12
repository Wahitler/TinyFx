using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Configuration.AspNet.WebApi
{
    /// <summary>
    /// Jwt配置
    /// </summary>
    public class JwtAuthElement
    {
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Jwt Key
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// Jwt TokenExpiry
        /// </summary>
        public string TokenExpiry { get; set; }
        /// <summary>
        /// 是否返回 HttpStatusCode.OK
        /// true: 返回 HttpStatusCode.OK
        /// false: 返回 HttpStatusCode.Unauthorized
        /// </summary>
        public bool ResponseOKStatusCode { get; set; }
    }
}
