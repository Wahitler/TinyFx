using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Runtime.Caching
{
    /// <summary>
    /// 存储Hash结构的MemoryCache缓存基类，将多个对象以hash结构存储在MemoryCache中
    /// </summary>
    /// <typeparam name="T">缓存项类型</typeparam>
    public abstract class MemoryCacheHashBase<T> : MemoryCacheBase
    {
        /// <summary>
        /// 根据key获取缓存value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected abstract CacheValue<T> GetCacheValue(string key);
        /// <summary>
        /// 缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key) => _cache.Contains(GetCacheKey(key));
        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <param name="key">缓存主键</param>
        /// <param name="item">缓存项</param>
        public void Set(string key, T item) =>  _cache.Set(GetCacheKey(key), (CacheValue<T>)item, Policy);
        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public void Set(string key, CacheValue<T> item) => _cache.Set(GetCacheKey(key), item, Policy);
        /// <summary>
        /// 移除缓存项，如果存在返回true
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key) => _cache.Remove(GetCacheKey(key)) == null;
        /// <summary>
        /// 根据key获取缓存项，如不存在调用GetCacheValue获取返回并缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public CacheValue<T> Get(string key)
        {
            var cacheKey = GetCacheKey(key);
            if (_cache.Contains(cacheKey))
                return (CacheValue<T>)_cache.Get(cacheKey);
            var ret = GetCacheValue(key);
            Set(key, ret);
            return ret;
        }
        /// <summary>
        /// 根据key获取缓存项，如果不存在则抛出MemoryCacheNotFound异常。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetOrException(string key)
        {
            var ret = Get(key);
            if (!ret.HasValue)
                throw new MemoryCacheNotFound(CollectionId, key);
            return ret.Value;
        }
        /// <summary>
        /// 根据key获取缓存项，如果不存在使用默认值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetOrDefault(string key, T defaultValue)
        {
            var ret = Get(key);
            return (!ret.HasValue) ? defaultValue : ret.Value;
        }
    }
}
