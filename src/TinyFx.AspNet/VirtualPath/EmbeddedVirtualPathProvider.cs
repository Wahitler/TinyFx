using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace TinyFx.AspNet.VirtualPath
{
    /// <summary>
    /// 嵌入资源虚拟路径提供程序（动态资源如.aspx）
    /// </summary>
    public class EmbeddedVirtualPathProvider : VirtualPathProvider
    {
        // 是否是虚拟文件系统路径
        private bool IsPathVirtual(string virtualPath)
        {
            var vper = EmbeddedContext.GetVirtualPathEmbeddedResource(HttpContext.Current);
            return vper != null;
        }
        /// <summary>
        /// 虚拟文件是否存在
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public override bool FileExists(string virtualPath)
        {
            return IsPathVirtual(virtualPath) || base.FileExists(virtualPath);
        }
        /// <summary>
        /// 获取虚拟文件
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            var vper = EmbeddedContext.GetVirtualPathEmbeddedResource(HttpContext.Current);
            return (vper == null) ? base.GetFile(virtualPath)
                : new EmbeddedVirtualFile(virtualPath, vper, GetCacheControl(vper));
        }
        private EmbeddedCacheControl GetCacheControl(EmbeddedResource resource)
        {
            return null;
        }
        /// <summary>
        /// 获取CacheDependency
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="virtualPathDependencies"></param>
        /// <param name="utcStart"></param>
        /// <returns></returns>
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            var vper = EmbeddedContext.GetVirtualPathEmbeddedResource(HttpContext.Current);
            return (vper == null) ? base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart)
                : vper.GetCacheDependency(utcStart);
        }
    }

}
