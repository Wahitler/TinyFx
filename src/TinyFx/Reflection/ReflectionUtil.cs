using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web;
using System.Runtime.InteropServices;
using System.IO;
using TinyFx.IO;
using System.Collections;

namespace TinyFx.Reflection
{
    /// <summary>
    /// 反射辅助方法类
    /// </summary>
    public static class ReflectionUtil
    {
        #region AssemblyInfo.cs
        /// <summary>
        /// 获取AssemblyInfo.cs中定义的Product
        /// </summary>
        /// <param name="asm"></param>
        /// <returns></returns>
        public static AssemblyProductAttribute GetAssemblyProduct(Assembly asm)
            => asm.GetCustomAttribute<AssemblyProductAttribute>();

        /// <summary>
        /// 获取AssemblyInfo.cs中定义的版本信息
        /// </summary>
        /// <param name="asm"></param>
        /// <returns></returns>
        public static Version GetAssemblyVersion(Assembly asm)
            => asm.GetName().Version;

        /// <summary>
        /// 获取指定Assembly的GUID
        /// </summary>
        /// <param name="asm"></param>
        /// <returns></returns>
        public static string GetAssemblyGuidString(Assembly asm)
        {
            string ret = null;
            GuidAttribute[] attrs = (GuidAttribute[])asm.GetCustomAttributes(typeof(GuidAttribute), false);
            if (attrs != null && attrs.Length > 0)
                ret = attrs[0].Value;
            return ret;
        }
        #endregion

        // 基元类型
        private static readonly HashSet<string> _primitiveTypeCache = new HashSet<string>() { { "System.Boolean" }, { "System.Byte" }, { "System.SByte" },  { "System.Int16" }, { "System.UInt16" }, { "System.Int32" }, { "System.UInt32" }, { "System.Int64" }, { "System.UInt64" }, { "System.IntPtr" }, { "System.UIntPtr" }, { "System.Char" }, { "System.Double" }, { "System.Single" } };
        // 简单类型
        private static readonly HashSet<string> _simpleTypeCache = new HashSet<string>() { { "System.TimeSpan" }, { "System.DateTime" }, { "System.Guid"}, { "System.Decimal" }, { "System.String" }, { "System.Byte[]"} };

        /// <summary>
        /// 类型是否是基元类型
        /// https://msdn.microsoft.com/en-us/library/system.type.isprimitive.aspx
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsPrimitiveType(Type type)
            => _primitiveTypeCache.Contains(type.FullName);

        /// <summary>
        /// 简单类型：基元类型 + TimeSpan + DateTime + Guid + Decimal + String + Byte[] + 任何可从字符串转入的对象（暂未加入判断）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSimpleType(Type type)
            => _primitiveTypeCache.Contains(type.FullName) || _simpleTypeCache.Contains(type.FullName);

        // .Net简单类型 => JS类型 映射缓存
        private static readonly Dictionary<string, string> _jsTypeMapCache = new Dictionary<string, string>() {
            { "System.Sbyte", "Number" },
            { "System.Byte", "Number"},
            { "System.Int16", "Number"},
            { "System.UInt16", "Number"},
            { "System.Int32", "Number"},
            { "System.UInt32", "Number"},
            { "System.Int64", "Number"},
            { "System.UInt64", "Number"},
            { "System.Single", "Number"},
            { "System.Double", "Number"},
            { "System.Decimal", "Number"},
            { "System.Boolean", "Boolean"},
            { "System.Char", "String"},
            { "System.String", "String"},
            { "System.DateTime", "String"},
            { "System.TimeSpan", "String"},
            { "System.Enum", "String"},
            { "System.Guid", "String"},
            { "System.Object", "Object"}
        };

        /// <summary>
        /// 获得.NET类型映射的JS类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string MapToJsType(Type type)
        {
            string ret = null;
            string key = type.FullName;
            if (_jsTypeMapCache.ContainsKey(key))
                return _jsTypeMapCache[key];
            if (typeof(ICollection).IsAssignableFrom(type) || typeof(IEnumerable<>).IsAssignableFrom(type))
                return "Array";
            return ret;
        }

        #region 反射获取/设置对象属性值
        /// <summary>
        /// 通过反射获取对象属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(this object obj, string propertyName)
            => obj.GetType().GetProperty(propertyName).GetValue(obj);

        /// <summary>
        /// 通过反射获取对象属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this object obj, string propertyName)
            => TinyFxUtil.ConvertTo<T>(GetPropertyValue(obj, propertyName));

        /// <summary>
        /// 通过反射设置对象属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(this object obj, string propertyName, object value)
            => obj.GetType().GetProperty(propertyName).SetValue(obj, value);
        #endregion

        /// <summary>
        /// 根据类型名称创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(string typeName)
            => (T)Activator.CreateInstance(Type.GetType(typeName));

        /// <summary>
        /// 获取字符串类型的嵌入资源
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetManifestResourceString(Assembly assembly, string name, Encoding encoding = null)
        {
            var stream = assembly.GetManifestResourceStream(name);
            using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8))
                return reader.ReadToEnd();
        }
    }
}
