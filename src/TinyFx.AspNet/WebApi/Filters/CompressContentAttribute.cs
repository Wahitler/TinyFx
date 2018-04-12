using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TinyFx.AspNet.WebApi.Filters
{
    /// <summary>
    /// 自动识别客户端是否支持压缩，如果支持则返回压缩后的数据 GZip
    /// </summary>
    public class CompressContentAttribute : ActionFilterAttribute
    {
        private CompressContentMode _mode;
        public CompressContentAttribute(CompressContentMode mode = CompressContentMode.None)
        {
            _mode = CompressContentMode.None;
        }
        /// <summary>
        /// Action执行时重写压缩
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            switch (_mode)
            {
                case CompressContentMode.None:
                    return;
                case CompressContentMode.Gzip:
                    CompressGzip(filterContext);
                    break;
                case CompressContentMode.Deflate:
                    CompressDeflate(filterContext);
                    break;
                case CompressContentMode.Auto:
                    CompressAuto(filterContext);
                    break;
            }
        }
        private void CompressGzip(HttpActionContext filterContext)
        {
            HttpResponse Response = HttpContext.Current.Response;
            Response.Filter = new GZipStream(Response.Filter, CompressionMode.Compress);
            Response.AppendHeader("Content-Encoding", "gzip");
        }
        private void CompressDeflate(HttpActionContext filterContext)
        {
            HttpResponse Response = HttpContext.Current.Response;
            Response.Filter = new DeflateStream(Response.Filter, CompressionMode.Compress);
            Response.AppendHeader("Content-Encoding", "deflate");
        }
        private void CompressAuto(HttpActionContext filterContext)
        {
            string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(AcceptEncoding))
            {
                if (AcceptEncoding.Contains("gzip"))
                    CompressGzip(filterContext);
                else if (AcceptEncoding.Contains("deflate"))
                    CompressDeflate(filterContext);
            }
            // 允许代理服务器缓存
            HttpContext.Current.Response.AppendHeader("Vary", "Content-Encoding");
        }
    }
    /// <summary>
    /// 压缩模式
    /// </summary>
    public enum CompressContentMode
    {
        None,
        Auto,
        Gzip,
        Deflate
    }
}
