using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TinyFx.IO;

namespace TinyFx.AspNet.VirtualPath
{
    /// <summary>
    /// 处理静态资源请求映射到DLL嵌入资源的IHttpModule
    /// 在请求静态资源文件（如.html/.js/.jpg等）时，如果在tinyfx.config中进行了配置，则该请求会映射到对应的DLL嵌入资源
    /// 例如请求路径:~/TinyFxResource/VirtualPath/demo.png 最终映射到DLL嵌入资源 TinyFx.AspNet.WebForm.VirtualPath.demo.png上
    /// 动态请求由EmbeddedVirtualPathProvider处理
    /// 注意：web.config中需要配置 runAllManagedModulesForAllRequests="true"
    /// </summary>
    public class EmbeddedModule : IHttpModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }
        private void Context_BeginRequest(object sender, EventArgs e)
        {
            if (!EmbeddedContext.HasVirtualPath)
                return; // 没有设置VirtualPath则返回
            var context = ((HttpApplication)sender).Context;
            if (context == null || context.Request == null)
                return;
            var vper = EmbeddedContext.GetVirtualPathEmbeddedResource(context);
            if (vper == null || !vper.IsStaticFile)
                return;// 非静态文件，由EmbeddedVirtualPathProvider处理
            context.Response.OutputStream.Write(vper.Data, 0, vper.Data.Length);
            context.Response.ContentType = MimeMapping.GetMimeMapping(context.Request.FilePath);
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.AppendCacheExtension("max-age=" + new TimeSpan(365, 0, 0, 0).TotalSeconds);
            context.ApplicationInstance.CompleteRequest(); //不要使用context.Response.End()
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() { }
    }
}
