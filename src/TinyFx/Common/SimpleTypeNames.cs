using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 简单类型名称集合
    /// 基元类型 + TimeSpan + DateTime + Guid + Decimal + String + 任何可从字符串转入的对象（暂未加入判断）
    /// </summary>
    public class SimpleTypeNames
    {
        #region Primitive Types
        /// <summary>
        /// Byte
        /// </summary>
        public const string Byte = "System.Byte";
        /// <summary>
        /// Sbyte
        /// </summary>
        public const string SByte = "System.SByte";
        /// <summary>
        /// Int16
        /// </summary>
        public const string Int16 = "System.Int16";
        /// <summary>
        /// UInt16
        /// </summary>
        public const string UInt16 = "System.UInt16";
        /// <summary>
        /// Int32
        /// </summary>
        public const string Int32 = "System.Int32";
        /// <summary>
        /// UInt32
        /// </summary>
        public const string UInt32 = "System.UInt32";
        /// <summary>
        /// Int64
        /// </summary>
        public const string Int64 = "System.Int64";
        /// <summary>
        /// UInt64
        /// </summary>
        public const string UInt64 = "System.UInt64";
        /// <summary>
        /// Single
        /// </summary>
        public const string Single = "System.Single";
        /// <summary>
        /// Double
        /// </summary>
        public const string Double = "System.Double";
        /// <summary>
        /// Boolean
        /// </summary>
        public const string Boolean = "System.Boolean";
        /// <summary>
        /// Char
        /// </summary>
        public const string Char = "System.Char";
        /// <summary>
        /// IntPtr
        /// </summary>
        public const string IntPtr = "System.IntPtr";
        /// <summary>
        /// UIntPtr
        /// </summary>
        public const string UIntPtr = "System.UIntPtr";
        #endregion

        /// <summary>
        /// Decimal
        /// </summary>
        public const string Decimal = "System.Decimal";
        /// <summary>
        /// TimeSpan
        /// </summary>
        public const string TimeSpan = "System.TimeSpan";
        /// <summary>
        /// DataTime
        /// </summary>
        public const string DateTime = "System.DateTime";
        /// <summary>
        /// DateTimeOffset
        /// </summary>
        public const string DateTimeOffset = "System.DateTimeOffset";
        /// <summary>
        /// Guid
        /// </summary>
        public const string Guid = "System.Guid";
        /// <summary>
        /// String
        /// </summary>
        public const string String = "System.String";
        /// <summary>
        /// byte[]
        /// </summary>
        public const string Bytes = "System.Byte[]";
    }
}
