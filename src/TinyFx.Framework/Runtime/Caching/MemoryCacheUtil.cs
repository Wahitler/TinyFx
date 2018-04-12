using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Runtime.Caching
{
    /// <summary>
    /// MemoryCache辅助类
    /// </summary>
    public static class MemoryCacheUtil
    {
        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Add<T>(string key, T value)
            => MemoryCache.Default.Add(key, (CacheValue<T>)value, null);

        /// <summary>
        /// 添加缓存项，指定时间未访问则移除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpiration"></param>
        public static void AddSliding<T>(string key, T value, TimeSpan slidingExpiration)
            => MemoryCache.Default.Add(key, (CacheValue<T>)value, new CacheItemPolicy() { SlidingExpiration = slidingExpiration });

        /// <summary>
        /// 添加缓存项，到指定时间则移除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        public static void AddAbsolute<T>(string key, T value, DateTimeOffset absoluteExpiration)
            => MemoryCache.Default.Add(key, (CacheValue<T>)value, absoluteExpiration);

        /// <summary>
        /// 添加或更新缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(string key, T value)
            => MemoryCache.Default.Set(key, (CacheValue<T>)value, null);
        public static void Set<T>(string key, CacheValue<T> value)
            => MemoryCache.Default.Set(key, value, null);

        /// <summary>
        /// 添加或更新缓存项，指定时间未访问则移除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpiration"></param>
        public static void SetSliding<T>(string key, T value, TimeSpan slidingExpiration)
            => MemoryCache.Default.Set(key, (CacheValue<T>)value, new CacheItemPolicy() { SlidingExpiration = slidingExpiration });

        /// <summary>
        /// 添加或更新缓存项，到指定时间则移除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        public static void SetAbsolute<T>(string key, T value, DateTimeOffset absoluteExpiration)
            => MemoryCache.Default.Set(key, (CacheValue<T>)value, absoluteExpiration);

        /// <summary>
        /// 移除缓存项
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
            => MemoryCache.Default.Remove(key);

        /// <summary>
        /// 根据key获取缓存项，如不存在调用GetCacheValue获取返回并缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static CacheValue<T> Get<T>(string key)
        {
            if (MemoryCache.Default.Contains(key))
                return (CacheValue<T>)MemoryCache.Default.Get(key);
            var ret = new CacheValue<T>();
            Set(key, ret);
            return ret;
        }
        /// <summary>
        /// 根据key获取缓存项，如果不存在则抛出MemoryCacheNotFound异常。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetOrException<T>(string key)
        {
            var ret = Get<T>(key);
            if (!ret.HasValue)
                throw new MemoryCacheNotFound($"MemoryCache key: {key} 不存在");
            return ret.Value;
        }
        /// <summary>
        /// 根据key获取缓存项，如果不存在使用默认值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetOrDefault<T>(string key, T defaultValue)
        {
            var ret = Get<T>(key);
            return (!ret.HasValue) ? defaultValue : ret.Value;
        }
    }
}
