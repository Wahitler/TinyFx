using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using TinyFx.Configuration;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// Redis集合对象基类：hash, list, set, sortedset
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RedisObjectBase<T>
    {
        private RedisClient _redisClient = null;
        /// <summary>
        /// 操作Redis的Client
        /// </summary>
        public RedisClient RedisClient
        {
            get {
                if (_redisClient == null)
                    _redisClient = RedisFactory.GetClient(ConnectionStringName);
                return _redisClient;
            }
        }        
        /// <summary>
        /// 操作缓存数据的Database
        /// </summary>
        public IDatabase Database => RedisClient.Database;
        /// <summary>
        /// 缓存对象序列化器
        /// </summary>
        public ISerializer Serializer => RedisClient.Serializer;

        private string _connectionStringName = null;

        /// <summary>
        /// 配置文件中定义的Redis连接字符串名称
        /// </summary>
        public virtual string ConnectionStringName
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionStringName))
                    _connectionStringName = TinyFxConfigManager.GetConfig<RedisConfig>().DefaultConnectionString;
                if (string.IsNullOrEmpty(_connectionStringName))
                    throw new Exception("未设置Redis的ConnectionStringName或未给出默认值");
                return _connectionStringName;
            }
        }
        private string _redisKey = null;
        /// <summary>
        /// 当前Redis缓存key，默认使用当前类名
        /// </summary>
        protected virtual string RedisKey
        {
            get
            {
                if (_redisKey == null)
                    _redisKey = this.GetType().Name;
                    //_redisKey = this.GetType().FullName;
                return _redisKey;
            }
        }
        /// <summary>
        /// 集合中缓存项是否有过期属性
        /// </summary>
        protected bool HasRedisValueExpired { get; } = typeof(IRedisValueExpired).IsAssignableFrom(typeof(T));

        /// <summary>
        /// 判断缓存项是否过期
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool IsRedisValueExpired(T value)
        {
            // 缓存项不过期
            if (!HasRedisValueExpired) return false;
            var item = (IRedisValueExpired)value;
            // ExpiredDate > MinValue && ExpiredDate < DateTime.Now
            return (item.RedisExpiredDate > DateTime.MinValue) && (item.RedisExpiredDate.CompareTo(DateTime.Now) < 1);
        }

        /// <summary>
        /// 获取最终当前redis缓存key
        /// </summary>
        /// <returns></returns>
        protected abstract string GetRedisKey();
        /// <summary>
        /// 设置当前缓存集合的相对过期时间(非缓存项)
        /// </summary>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool SetExpire(TimeSpan expiry)
            => RedisClient.SetExpire(GetRedisKey(), expiry);

        /// <summary>
        /// 设置当前缓存集合的绝对过期时间(非缓存项)
        /// </summary>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool SetExpire(DateTime expiry)
            => RedisClient.SetExpire(GetRedisKey(), expiry);
    }
}
