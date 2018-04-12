using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Net
{
    /// <summary>
    /// ContentType类型
    /// </summary>
    public static class HttpPostContentType
    {
        /// <summary>
        /// 表单数据处理为键值对
        /// </summary>
        public const string FormUrlencoded = "application/x-www-form-urlencoded";
        
        /// <summary>
        /// 表单数据处理为一条消息。以标签为单元，用分隔符分开。既可以上传键值队，也可以上传文件
        /// </summary>
        public const string FormData = "multipart/form-data";

        /// <summary>
        /// 上传二进制数据。一次只能上传一个文件
        /// </summary>
        public const string Binary = "application/octet-stream";

        /// <summary>
        /// TEXT
        /// </summary>
        public const string Text = "text/plain";

        /// <summary>
        /// JSON
        /// </summary>
        public const string JSON = "application/json";

        /// <summary>
        /// Javascript
        /// </summary>
        public const string Javascript = "application/javascript";

        /// <summary>
        /// XML
        /// </summary>
        public const string Xml = "text/xml";

        /// <summary>
        /// HTML
        /// </summary>
        public const string HTML = "text/html";
    }
}
