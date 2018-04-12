using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.AspNet.WebApi
{
    /// <summary>
    /// 系统定义的错误码
    /// </summary>
    public class ApiErrorCode
    {
        /// <summary>
        /// JWT 验证失败
        /// </summary>
        public const string JwtAuthError = "JwtAuthError";
        public const string JwtAuthErrorExpire = "JwtAuthErrorExpire";
        /// <summary>
        /// 不支持Session
        /// </summary>
        public const string NotSupportSession = "NotSupportSession";
        /// <summary>
        /// 未处理异常
        /// </summary>
        public const string UnhandledException = "UnhandledException";
        /// <summary>
        /// TinyOkResult返回时Code代码
        /// </summary>
        public const string OK = "0";
        /// <summary>
        /// TinyErrResult 返回Code代码，客户端一般性处理
        /// </summary>
        public const string Error = "err";
        /// <summary>
        /// Code错误码，通知客户端仅显示错误信息即可
        /// </summary>
        public const string ShowErrorMessage = "showErrMsg";
    }
}
