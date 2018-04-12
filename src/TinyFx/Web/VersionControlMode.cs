using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Web
{
    /// <summary>
    /// 版本控制方式
    /// </summary>
    public enum VersionControlMode
    {
        /// <summary>
        /// 没有版本控制
        /// </summary>
        None,
        /// <summary>
        /// 请求的Headers中添加: api-version : 2
        /// </summary>
        RequestHeader,
        /// <summary>
        /// 请求URL中添加：~/api/v2/demo/get1?id=2
        /// </summary>
        UrlParameter,
        /// <summary>
        /// ContentType添加：Accept: application/vnd.haveibeenpwned+json; version=2.0
        /// </summary>
        ContentType
    }
}
