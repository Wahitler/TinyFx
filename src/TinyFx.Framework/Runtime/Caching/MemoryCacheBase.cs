using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace TinyFx.Runtime.Caching
{
    /// <summary>
    /// 内存缓存基类
    /// </summary>
    public abstract class MemoryCacheBase
    {
        /// <summary>
        /// 全局MemoryCache
        /// </summary>
        protected static readonly MemoryCache _cache = MemoryCache.Default;
        private string _collectionId = null;
        /// <summary>
        /// 用于生成MemoryCache的缓存Key，必须保证全局唯一。
        /// </summary>
        protected virtual string CollectionId
        {
            get
            {
                if (_collectionId == null)
                    _collectionId = this.GetType().Name;
                return _collectionId;
            }
        }
        /// <summary>
        /// 获得CacheKey
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual string GetCacheKey(string key = null) => $"{CollectionId}@{key}";
        /// <summary>
        /// 指定缓存项的一组逐出和过期详细信息
        /// </summary>
        public CacheItemPolicy Policy { get; set; } = new CacheItemPolicy();
        /// <summary>
        /// 设置缓存策略，此对象中的缓存项如果在给定时段内未被访问，将被逐出。
        /// </summary>
        /// <param name="minutesExpiration"></param>
        public void SetSliding(int minutesExpiration = 30) => Policy.SlidingExpiration = new TimeSpan(0, minutesExpiration, 0);
        /// <summary>
        /// 设置缓存策略，此对象中的缓存项将在指定的持续时间后被逐出。
        /// </summary>
        /// <param name="expiration"></param>
        public void SetAbsolute(DateTimeOffset expiration) => Policy.AbsoluteExpiration = expiration;
    }
}
