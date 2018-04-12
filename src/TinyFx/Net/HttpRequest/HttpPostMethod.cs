using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Net
{
    /// <summary>
    /// http提交模式
    /// </summary>
    public enum HttpPostMethod
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknow,

        /// <summary>
        /// 表单数据处理为一条消息。以标签为单元，用分隔符分开。既可以上传键值队，也可以上传文件
        /// </summary>
        FormData,

        /// <summary>
        /// 表单数据处理为键值对
        /// </summary>
        FormUrlencoded,

        /// <summary>
        /// 上传二进制数据。一次只能上传一个文件
        /// </summary>
        Binary,

        #region raw
        /// <summary>
        /// TEXT
        /// </summary>
        Text,
        /// <summary>
        /// Json
        /// </summary>
        JSON,
        /// <summary>
        /// Javascript
        /// </summary>
        Javascript,
        /// <summary>
        /// xml
        /// </summary>
        Xml,
        /// <summary>
        /// html
        /// </summary>
        HTML
        #endregion
    }

}
