using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Linq;
using System.Collections;

namespace TinyFx.Web
{
    /// <summary>
    /// UriBuilder继承扩展类
    /// </summary>
    public class UriBuilderEx : UriBuilder
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uri"></param>
        public UriBuilderEx(string uri) : base(uri) { }

        /// <summary>
        /// URL中的QueryString键值对
        /// </summary>
        public NameValueCollection QueryString => HttpUtility.ParseQueryString(Query);

        /// <summary>
        /// 添加QueryString值，如果指定Encoding则使用HttpUtility.UrlEncode编码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        public void AppendQueryString(string name, string value, Encoding encoding = null)
        {
            if (!string.IsNullOrEmpty(value) && encoding != null)
                value = HttpUtility.UrlEncode(value, encoding);
            var queries = HttpUtility.ParseQueryString(Query);
            queries[name] = value;
            string query = "?";
            foreach (string key in queries.Keys)
                query += $"{key}={queries[key]}&";
            Query = query.TrimEnd('&');
        }

        /// <summary>
        /// 获取QueryString值，如果指定Encoding则使用HttpUtility.UrlDecode解码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string GetQueryStringValue(string name, Encoding encoding = null)
        {
            var value = HttpUtility.ParseQueryString(Query)?.Get(name);
            if (!string.IsNullOrEmpty(value) && encoding != null)
                value = HttpUtility.UrlDecode(value, encoding);
            return value;
        }

    }
}
