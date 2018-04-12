using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using TinyFx;

namespace TinyFx.Web
{
    /// <summary>
    /// Web辅助类
    /// </summary>
    public static class WebUtil
    {
        /// <summary>
        /// 判断文件类型是否为WEB格式图片(注：JPG,GIF,BMP,PNG)
        /// </summary>
        /// <param name="contentType">HTTP MIME 类型</param>
        /// <returns></returns>
        public static bool IsWebImage(string contentType)
            => contentType == "image/pjpeg" || contentType == "image/jpeg" || contentType == "image/gif" 
            || contentType == "image/bmp" || contentType == "image/png" || contentType == "image/x-png";
    }
}
