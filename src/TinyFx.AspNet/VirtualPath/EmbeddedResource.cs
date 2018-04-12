using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace TinyFx.AspNet.VirtualPath
{
    /// <summary>
    /// 嵌入资源信息
    /// </summary>
    public class EmbeddedResource
    {
        /// <summary>
        /// 映射的虚拟路径
        /// </summary>
        public string VirtualPath { get; set; }
        /// <summary>
        /// 资源所在应用程序集
        /// </summary>
        public Assembly Assembly { get; set; }
        /// <summary>
        /// 资源路径
        /// </summary>
        public string ResourceName { get; set; }
        /// <summary>
        /// 嵌入资源的数据
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// 是否是静态文件资源，如.js,.bmp等
        /// </summary>
        public bool IsStaticFile { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public EmbeddedResource() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <param name="virtualPath"></param>
        /// <param name="isStaticFile"></param>
        public EmbeddedResource(Assembly assembly, string resourceName, string virtualPath, bool isStaticFile)
        {
            VirtualPath = virtualPath;
            Assembly = assembly;
            ResourceName = resourceName;
            IsStaticFile = isStaticFile;
        }

        /// <summary>
        /// 获得CacheDependency
        /// </summary>
        /// <param name="utcStart"></param>
        /// <returns></returns>
        public CacheDependency GetCacheDependency(DateTime utcStart)
            => new CacheDependency(Assembly.Location);
    }
}
