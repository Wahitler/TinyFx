using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace TinyFx
{
    /// <summary>
    /// 枚举辅助类
    /// </summary>
    public static class EnumUtil
    {
        #region EnumInfo
        
        /// <summary>
        /// 枚举描述缓存
        /// </summary>
        private static readonly ConcurrentDictionary<string, EnumInfo> _descsCache = new ConcurrentDictionary<string, EnumInfo>();

        /// <summary>
        /// 获取枚举类型的描述信息
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static EnumInfo GetInfo(Type enumType)
        {
            EnumInfo ret = null;
            if (!_descsCache.TryGetValue(enumType.FullName, out ret))
            {
                ret = new EnumInfo(enumType);
                _descsCache.AddOrUpdate(enumType.FullName, ret, (key, value) => ret);
            }
            return ret;
        }
        
        /// <summary>
        /// 获取枚举类型的描述信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static EnumInfo GetInfo<T>() => GetInfo(typeof(T));
        
        /// <summary>
        /// 获取枚举项描述信息
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EnumItemInfo GetItemInfo(Type enumType, object value) => GetInfo(enumType).GetItem(value);
        
        /// <summary>
        /// 获取枚举项描述信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EnumItemInfo GetItemInfo<T>(object value) => GetItemInfo(typeof(T), value);

        /// <summary>
        /// 获取枚举的Description
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetDescription(Type enumType) => GetInfo(enumType).Description;
        
        /// <summary>
        /// 获取枚举的Description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetDescription<T>() => GetInfo<T>().Description;
        
        /// <summary>
        /// 获取枚举项的Description
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetItemDescription(Type enumType, object value) => GetItemInfo(enumType, value).Description;
        
        /// <summary>
        /// 获取枚举项的Description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetItemDescription<T>(object value) => GetItemInfo<T>(value).Description;

        #endregion // EnumInfo

        /// <summary>
        /// 判断flags枚举类型variable是否包含value
        /// </summary>
        /// <param name="variable">要验证的Enum值</param>
        /// <param name="value">判断value是否包含在variable中</param>
        /// <returns></returns>
        public static bool HasFlag(Enum variable, Enum value)
        {
            var valueNum = Convert.ToUInt64(value);
            return (Convert.ToUInt64(variable) & valueNum) == valueNum; 
        }
    }
}
