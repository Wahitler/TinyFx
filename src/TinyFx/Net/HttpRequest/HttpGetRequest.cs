using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Net
{
    /// <summary>
    /// HTTP GET 请求类
    /// </summary>
    public class HttpGetRequest : HttpRequestBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="encoding">字符集</param>
        /// <param name="cookies">Cookies</param>
        public HttpGetRequest(string url, Encoding encoding = null, CookieCollection cookies = null) 
            : base(url, encoding, cookies)
        {
            Method = "GET";
        }

        /// <summary>
        /// 获得Response对象
        /// </summary>
        /// <returns></returns>
        public override HttpWebResponse GetResponse()
            => CreateRequest().GetResponse() as HttpWebResponse;
    }
}
