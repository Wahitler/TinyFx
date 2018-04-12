using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Net
{
    /// <summary>
    /// HTTP Web请求基类
    /// </summary>
    public abstract class HttpRequestBase
    {
        #region Properties
        /// <summary>
        /// 基础URL
        /// </summary>
        public string BaseUrl { get; set; }
        
        /// <summary>
        /// 是否HTTPS访问
        /// </summary>
        public bool UseHttps { get; protected set; }
        
        /// <summary>
        /// 证书所在路径
        /// </summary>
        public string CertificatePath { get; set; }
        
        /// <summary>
        /// 请求GET/POST
        /// </summary>
        public string Method { get; protected set; }
        
        /// <summary>
        /// 字符集
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        
        /// <summary>
        /// Cookies
        /// </summary>
        public CookieCollection Cookies { get; set; }

        ///// <summary>
        ///// 指定后面返回的文档是什么MIME类型,POST时设置 
        ///// 格式：[type]/[subtype];parameter 如：text/html;charset=utf-8
        ///// </summary>
        //public string ContentType { get; set; }

        /// <summary>
        /// 上一个引用URL
        /// </summary>
        public string RefererUrl { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
        
        /// <summary>
        /// 请求超时
        /// </summary>
        public int Timeout { get; set; } = 100000;
        
        /// <summary>
        /// 是否与 Internet 资源建立持续型连接
        /// </summary>
        public bool KeepAlive { get; set; } = false;
        
        /// <summary>
        /// Request's URL参数
        /// </summary>
        public List<(string name, string value)> UrlParams = new List<(string name, string value)>();
        
        /// <summary>
        /// Request's Headers
        /// </summary>
        public List<(HttpRequestHeader header, string value)> Headers = new List<(HttpRequestHeader header, string value)>();
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="encoding">字符集</param>
        /// <param name="cookies">Cookies</param>
        public HttpRequestBase(string url, Encoding encoding = null, CookieCollection cookies = null)
        {
            BaseUrl = url.Trim();
            UseHttps = url.StartsWith("https", StringComparison.OrdinalIgnoreCase);
            Encoding = encoding ?? Encoding.UTF8;
            Cookies = cookies;
        }

        #region URL
        /// <summary>
        /// 添加URL参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddUrlParam(string name, string value)
            => UrlParams.Add((name, value));

        /// <summary>
        /// 添加URL参数
        /// </summary>
        /// <param name="value"></param>
        public void AddUrlParam(string value)
            => AddUrlParam(null, value);

        /// <summary>
        /// 获取完整URL
        /// </summary>
        /// <returns></returns>
        protected string GetUrl()
        {
            string ret = BaseUrl;
            if (UrlParams != null && UrlParams.Count > 0)
            {
                if (!ret.EndsWith("?")) ret += "?";
                var paras = UrlParams.Select((item) => {
                    return string.IsNullOrEmpty(item.name) ? item.value : $"{item.name}={item.value}";
                });
                ret += string.Join<string>("&", paras);
            }
            return ret;
        }
        #endregion

        #region Headers
        /// <summary>
        /// 添加Request's Header
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        public void AddHeader(HttpRequestHeader header, string value)
            => Headers.Add((header, value));

        /// <summary>
        /// 修改Request添加Headers
        /// </summary>
        /// <param name="request"></param>
        protected void AppendHeaders(HttpWebRequest request)
        {
            foreach (var header in Headers)
                request.Headers.Add(header.header, header.value);
        }
        #endregion

        #region Methods
        /// <summary>
        /// 创建Request
        /// </summary>
        /// <returns></returns>
        protected HttpWebRequest CreateRequest()
        {
            var ret = WebRequest.Create(GetUrl()) as HttpWebRequest;
            ret.Method = Method;
            var contentType = GetContentType();
            if (!string.IsNullOrEmpty(contentType))
                ret.ContentType = contentType;
            AppendHeaders(ret);
            ret.UserAgent = UserAgent;
            ret.Timeout = Timeout;
            ret.KeepAlive = KeepAlive; //??
            if (!string.IsNullOrEmpty(RefererUrl))
                ret.Referer = RefererUrl;
            if (Cookies != null)
            {
                ret.CookieContainer = new CookieContainer();
                ret.CookieContainer.Add(Cookies);
            }
            if (UseHttps)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(VerifyServerCertificate);
                // ret.Proxy = null; //??
                if (!string.IsNullOrEmpty(CertificatePath))
                {
                    if (!File.Exists(CertificatePath))
                        throw new FileNotFoundException("https请求时证书文件未找到:" + CertificatePath);
                    X509Certificate cert = X509Certificate.CreateFromCertFile(CertificatePath);
                    ret.ClientCertificates.Add(cert);
                }
            }
            return ret;
        }

        protected virtual string GetContentType()
            =>  null;

        /// <summary>
        /// 获取Response
        /// </summary>
        /// <returns></returns>
        public abstract HttpWebResponse GetResponse();
        
        /// <summary>
        /// 获取Response内容的String表示
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string GetString(HttpWebResponse response)
        {
            Stream stream = GetDecompressStream(response);
            using (StreamReader reader = new StreamReader(stream, Encoding))
                return reader.ReadToEnd();
        }

        /// <summary>
        /// 获取返回的String类型表示
        /// </summary>
        /// <returns></returns>
        public string GetResponseString()
            => GetString(GetResponse());

        /// <summary>
        /// 获取解压缩的流
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected Stream GetDecompressStream(HttpWebResponse response)
        {
            Stream stream = null;
            var contentEncoding = response.ContentEncoding.ToLower();
            if (contentEncoding.Contains("gzip"))
                stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
            else if (contentEncoding.Contains("deflate"))
                stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
            else
                stream = response.GetResponseStream();
            return stream;
        }
        
        #endregion

        #region Utils
        private static bool VerifyServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }
        #endregion
    }
}
