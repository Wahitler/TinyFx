using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Net;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.UI;
using System.Net.Http;
using TinyFx;

namespace TinyFx.AspNet.WebForm
{
    /// <summary>
    /// WebForm辅助类
    /// </summary>
    public static class WebFormUtil
    {
        public static void ResponseExcel(byte[] data, string fileName = null)
        {
            var response = HttpContext.Current.Response;
            fileName = fileName ?? "download.xlsx";
            response.BinaryWrite(data);
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", $"attachment;  filename={fileName ?? "download.xlsx"}");
        }

        #region 输出图片
        /// <summary>
        /// 输出图片
        /// </summary>
        /// <param name="data">图片数据</param>
        /// <param name="context">上下文</param>
        public static void ResponseImage(byte[] data, HttpContext context = null)
        {
            HttpResponse response = (context == null) ? HttpContext.Current.Response : context.Response;
            response.ClearContent();
            response.ContentType = "image/Jpeg";
            response.BinaryWrite(data);
            response.Flush();
            //response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// 输出图片
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="context">上下文</param>
        public static void ResponseImage(System.Drawing.Image img, HttpContext context = null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                ResponseImage(ms.ToArray(), context);
            }
        }

        /// <summary>
        /// 输出图片
        /// </summary>
        /// <param name="filename">包含WEB相对路径或绝对路径的文件名</param>
        /// <param name="context">上下文</param>
        public static void ResponseImage(string filename, HttpContext context = null)
        {
            context = context ?? HttpContext.Current;
            filename = context.Server.MapPath(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                ResponseImage(data, context);
            }
        }

        /// <summary>
        /// 输出文件未找到
        /// </summary>
        /// <param name="context">HTTP请求信息</param>
        public static void ResponseFileNotFound(HttpContext context = null)
        {
            context = context ?? HttpContext.Current;
            context.Response.StatusCode = 404;
            //context.Response.End();
            context.ApplicationInstance.CompleteRequest();
        }
        #endregion

        #region 文件下载
        private static void ResponseFileBase(HttpContext context, Stream stream, string filename, long speed = 0)
        {
            context = context ?? HttpContext.Current;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            using (BinaryReader reader = new BinaryReader(stream))
            {
                long total = stream.Length;
                long start = 0;
                int pack = 10240;//10K 每包大小
                int sleep = 0;
                if (speed > 0)
                    sleep = (int)Math.Floor((double)1000 * pack / speed) + 1; //pack/speed 每个包发送速度/秒 总的意思:发包频率

                string range = request.Headers["Range"];
                if (!string.IsNullOrEmpty(range))
                {
                    response.StatusCode = 206;
                    start = Convert.ToInt64(range.Split(new char[] { '=', '-' })[1]);
                }
                long remain = total - start;
                response.AddHeader("Content-Length", remain.ToString());
                if (start != 0)
                {
                    //Content-Range: bytes [文件块的开始字节]-[文件的剩余大小]/[文件的总大小]
                    response.AddHeader("Content-Range", string.Format("bytes {0}-{1}/{2}", start, remain, total));
                }
                response.AddHeader("Accept-Ranges", "bytes");
                response.ContentType = "application/octet-stream";
                response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8));
                response.AddHeader("Connection", "Keep-Alive");
                stream.Position = start;
                int maxCount = (int)Math.Floor((double)(total - start) / pack) + 1;
                for (int i = 0; i < maxCount; i++)
                {
                    if (response.IsClientConnected)
                    {
                        response.BinaryWrite(reader.ReadBytes(pack));
                        response.Flush();
                        if (speed > 0) Thread.Sleep(sleep);
                    }
                    else break;
                }
            }
        }

        /// <summary>
        /// 提供下载，支持断点续传
        /// </summary>
        /// <param name="stream">下载的数据流</param>
        /// <param name="filename">文件名</param>
        /// <param name="speed">每秒允许下载的字节数，0或负数为不限制</param>
        /// <param name="context">上下文</param>
        public static void ResponseFile(Stream stream, string filename, long speed = 0, HttpContext context = null)
            => ResponseFileBase(context, stream, filename, speed);

        /// <summary>
        /// 提供文件下载，支持断点续传
        /// </summary>
        /// <param name="data">下载的数据</param>
        /// <param name="filename">下载的文件名</param>
        /// <param name="speed">每秒允许下载的字节数，0或小数为不限制</param>
        /// <param name="context">上下文</param>
        public static void ResponseFile(byte[] data, string filename, long speed = 0, HttpContext context = null)
            => ResponseFileBase(context, new MemoryStream(data), filename, speed);

        /// <summary>
        /// 提供文件下载，支持断点续传
        /// </summary>
        /// <param name="downloadFile">提供下载的包含WEB相对路径或绝对路径的文件名</param>
        /// <param name="filename">下载的文件名</param>
        /// <param name="speed">每秒允许下载的字节数，0或小数为不限制</param>
        /// <param name="context">上下文</param>
        public static void ResponseFile(string downloadFile, string filename = null, long speed = 0, HttpContext context = null)
        {
            downloadFile = context.Server.MapPath(downloadFile);
            if (string.IsNullOrEmpty(filename))
                filename = Path.GetFileName(downloadFile);
            ResponseFileBase(context, new FileStream(downloadFile, FileMode.Open, FileAccess.Read), filename, speed);
        }

        #endregion

        /// <summary>
        /// 获得客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetUserHostAddress()
        {
            /*
             * 1）无代理
             *      REMOTE_ADDR=用户IP，HTTP_VIA=null，HTTP_X_FORWARDED_FOR=null
             * 2）透明代理
             *      REMOTE_ADDR=最后代理IP，HTTP_VIA=代理IP，HTTP_X_FORWARDED_FOR=用户IP+多个代理IP
             * 3）匿名代理
             *      REMOTE_ADDR=最后代理IP，HTTP_VIA=代理IP，HTTP_X_FORWARDED_FOR=代理IP+多个代理IP
             * 4）欺骗性代理
             *      REMOTE_ADDR=代理IP，HTTP_VIA=代理IP，HTTP_X_FORWARDED_FOR=随机IP+多个代理IP
             * 5）高级匿名代理
             *      REMOTE_ADDR=代理IP，HTTP_VIA=null，HTTP_X_FORWARDED_FOR=null+多个代理IP
             */


            var ret = string.Empty;
            var request = HttpContext.Current.Request;
            if (request.ServerVariables["HTTP_VIA"] == null)
            {
                ret = request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                ret = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ret))
                {
                    var ips = ret.Split(',');
                    if (ips != null && ips.Length > 0)
                        ret = ips[0];
                }
            }
            if (string.IsNullOrEmpty(ret) || !StringUtil.IsIpAddress(ret))
                ret = "127.0.0.1";
            return ret;
        }

        /// <summary>
        /// 将Request的集合信息(Params, Form, QueryString)映射为实体对象。
        /// 请使用RequestMapperAttribute定义映射字段。如果未使用RequestMapperAttribute进行定义，则保证属性名与key保持一致。
        /// </summary>
        /// <typeparam name="T">映射类型</typeparam>
        /// <param name="items">集合对象</param>
        /// <param name="mapper">映射方法</param>
        /// <returns></returns>
        public static T MapTo<T>(this NameValueCollection items, Func<NameValueCollection, T> mapper = null)
        {
            mapper = mapper ?? RequestMapper.Map<T>;
            return mapper(items);
        }

        /// <summary>
        /// 配置Web异常，添加HTTP请求的相关信息
        /// </summary>
        /// <param name="ex">需要添加信息的异常</param>
        /// <param name="context">当前上下文，如为空则取HttpContext.Current</param>
        public static void RepairHttpException(this Exception ex, HttpContext context = null)
        {
            context = context ?? HttpContext.Current;
            if (ex == null || context == null || context.Request == null) return;
            // Request Url
            if (context.Request.Url != null)
                ex.AddUserData("Request Url", context.Request.Url.ToString());
            // UrlReferrer
            if (context.Request.UrlReferrer != null)
                ex.AddUserData("UrlReferrer", context.Request.UrlReferrer.ToString());
            // QueryString
            if (context.Request.QueryString != null)
            {
                foreach (string key in context.Request.QueryString.AllKeys)
                {
                    ex.AddUserData("QueryString", $"[key] {key} [value] {context.Request.QueryString[key]}");
                }
            }

            // Form
            if (context.Request.Form != null)
            {
                foreach (string key in context.Request.Form.AllKeys)
                {
                    //if (key == "__VIEWSTATE" || key == "__EVENTVALIDATION") continue;
                    ex.AddUserData("Form", $"[key] {key} [value] {context.Request.Form[key]}");
                }
            }
            // Headers
            if (context.Request.Headers != null)
            {
                foreach (string key in context.Request.Headers.Keys)
                {
                    ex.AddUserData("Headers", $"[key] {key} [value] {context.Request.Headers[key]}");
                }
            }
            // Cookie
            if (context.Request.Cookies != null)
            {
                foreach (string key in context.Request.Cookies.AllKeys)
                {
                    //if (key == "ASP.NET_SessionId") continue;
                    string cookieValue = null;
                    HttpCookie cookie = context.Request.Cookies[key];
                    if (cookie.Values != null && cookie.Values.Count > 1)
                    {
                        foreach (string item in cookie.Values.AllKeys)
                        {
                            cookieValue += $"{item};{cookie.Values[item]} ";
                        }
                    }
                    else
                        cookieValue = cookie.Value;
                    ex.AddUserData("Cookies", $"[key] {key} [value] {cookieValue}");
                }
            }
        }

        #region Path
        /*
        请求路径：http://xxx.com/aaa/logs/1.txt
        站点根目录 c:\www\
        应用程序根目录的虚拟路径 ~/aaa/1.txt  AppRelativePath 
        相对路径 ./    RelativePath
        绝对路径 /app/aaa/1.txt     AbsolutePath
        物理路径 c:\www\app\aaa\1.txt   PhysicalPath
        request.ApplicationPath  /app
        */

        /// <summary>
        /// 物理路径转换为绝对路径
        /// c:\www\app\aaa\1.txt => /app/aaa/1.txt
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string PhysicalToAbsolutePath(string path)
        {
            var request = HttpContext.Current.Request;
            var appDir = request.PhysicalApplicationPath; // 应用程序池目录c:\www\app\ 
            var appPath = path.Replace(appDir, "").Replace('\\','/'); // aaa/1.txt
            return $"{HttpRuntime.AppDomainAppVirtualPath}/{appPath}";
        }

        /// <summary>
        /// 物理路径转换为应用程序根目录的虚拟路径。
        /// c:\www\app\aaa\1.txt => ~/aaa/1.txt
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string PhysicalToAppRelativePath(string path)
        {
            var appDir = HttpContext.Current.Request.PhysicalApplicationPath; // 应用程序池目录c:\www\app\ 
            return $"~/{path.Replace(appDir, "").Replace('\\', '/')}";
        }

        /// <summary>
        /// 将 URL 转换成一个请求的客户端上可用路径（绝对路径）；ResolveUrl("~/bbb") => "/aaa/bbb"
        ///     1) 当URL以斜线开始（/或\）,不处理。
        ///     2）当URL是一个绝对URL，不处理
        ///     3）当URL以~/开始，它会被AppVirtualPath取代
        ///     4）其他任何情况，追加URL到AppVirtualPath
        ///     5）每当它修改URL，还修复斜杠。删除双斜线，用/替换\
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public static string ResolveUrl(string relativeUrl)
        {
            if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

            if (relativeUrl.Length == 0 || relativeUrl[0] == '/' ||
                relativeUrl[0] == '\\') return relativeUrl;

            int idxOfScheme =
              relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
            if (idxOfScheme != -1)
            {
                int idxOfQM = relativeUrl.IndexOf('?');
                if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
            }

            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append(HttpRuntime.AppDomainAppVirtualPath);
            if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/') sbUrl.Append('/');

            // found question mark already? query string, do not touch!
            bool foundQM = false;
            bool foundSlash; // the latest char was a slash?
            if (relativeUrl.Length > 1
                && relativeUrl[0] == '~'
                && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
            {
                relativeUrl = relativeUrl.Substring(2);
                foundSlash = true;
            }
            else foundSlash = false;
            foreach (char c in relativeUrl)
            {
                if (!foundQM)
                {
                    if (c == '?') foundQM = true;
                    else
                    {
                        if (c == '/' || c == '\\')
                        {
                            if (foundSlash) continue;
                            else
                            {
                                sbUrl.Append('/');
                                foundSlash = true;
                                continue;
                            }
                        }
                        else if (foundSlash) foundSlash = false;
                    }
                }
                sbUrl.Append(c);
            }

            return sbUrl.ToString();
        }
        #endregion
    }
}
