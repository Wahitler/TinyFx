using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TinyFx.AspNet.WebApi.Authentication
{
    /// <summary>
    /// Jwt Token中存放的payload信息
    /// </summary>
    [JsonObject]
    public class JwtPayload
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string name { get; set; }
        /// <summary>
        /// 用户组
        /// </summary>
        public string role { get; set; }
        /// <summary>
        /// Token有效期
        /// </summary>
        public long exp { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string ver { get; set; }
    }
}