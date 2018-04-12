using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 异常堆栈信息类
    /// </summary>
    [Serializable]
    public class ExceptionStackEntry
    {
        /// <summary>
        /// 获取引发异常的应用程序集名称
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 获取引发异常的类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 获取引发异常的方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 获取引发异常的文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 获取引发异常的行号
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// 获取是否由Framwork引发的异常
        /// </summary>
        public bool IsGlobalAssembly { get; set; }
    }
}
