using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace TinyFx.AspNet.VirtualPath
{
    /// <summary>
    /// 嵌入资源虚拟文件
    /// </summary>
    public class EmbeddedVirtualFile : VirtualFile
    {
        private readonly EmbeddedResource _embedded;
        private readonly EmbeddedCacheControl _cacheControl;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="embedded"></param>
        /// <param name="cacheControl"></param>
        public EmbeddedVirtualFile(string virtualPath, EmbeddedResource embedded, EmbeddedCacheControl cacheControl)
            : base(virtualPath)
        {
            this._embedded = embedded;
            this._cacheControl = cacheControl;
        }
        
        /// <summary>
        /// 打开资源文件
        /// </summary>
        /// <returns></returns>
        public override Stream Open()
        {
            if (_cacheControl != null)
            {
                HttpContext.Current.Response.Cache.SetCacheability(_cacheControl.Cacheability);
                HttpContext.Current.Response.Cache.AppendCacheExtension("max-age=" + _cacheControl.MaxAge);
            }
            return new MemoryStream(_embedded.Data);
        }
    }
}
