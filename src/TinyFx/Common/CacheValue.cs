using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 缓存值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheValue<T>
    {
        /// <summary>
        /// 是否存在缓存值
        /// </summary>
        public bool HasValue { get; set; }
        private T _value = default(T);
        /// <summary>
        /// 缓存值
        /// </summary>
        public T Value
        {
            get { return _value; }
            set { HasValue = true; _value = value; }
        }

        /// <summary>
        /// 转换器
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator CacheValue<T>(T value)
        {
            CacheValue<T> ret = new CacheValue<T>();
            ret.Value = value;
            return ret;
        }
    }
}
