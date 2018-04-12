using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using StackExchange.Redis;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Extensions.StackExchangeRedis.Serializers;
using TinyFx.Configuration;
using StackExchange.Redis.KeyspaceIsolation;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// Redis工厂方法类，获取 RedisClient 和 IDatabase
    ///     RedisClient: 操作Redis客户端，包含Redis操作，string类型操作，缓存对象序列化器
    ///     IDatabase: 操作Redis缓存项的类 
    /// </summary>
    public static class RedisFactory
    {
        // key: connectionString
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> _multiplexers = new ConcurrentDictionary<string, ConnectionMultiplexer>();
        // key: typename
        private static readonly ConcurrentDictionary<string, ISerializer> _serializers = new ConcurrentDictionary<string, ISerializer>();
        /// <summary>
        /// 获得IDatabase
        /// </summary>
        /// <param name="connectionStringName">配置文件redis中的ConnectionStringName</param>
        /// <returns></returns>
        public static IDatabase GetDatabase(string connectionStringName = null)
        {
            var config = GetConfig(connectionStringName);
            return GetDatabase(config.ConnectionString, config.Database, config.KeyPrefix);
        }
        
        /// <summary>
        /// 获得IDatabase
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="database"></param>
        /// <param name="keyPrefix"></param>
        /// <returns></returns>
        public static IDatabase GetDatabase(string connectionString, int database, string keyPrefix = null)
        {
            var ret = GetMultiplexer(connectionString).GetDatabase(database);
            /*
            if (string.IsNullOrEmpty(keyPrefix))
            {
                var projConfig = TinyFxConfigManager.GetConfig<ProjectConfig>();
                if (projConfig != null && !string.IsNullOrEmpty(projConfig.Id))
                {
                    keyPrefix = projConfig.Id;
                }
            }
            */
            if (!string.IsNullOrEmpty(keyPrefix))
                ret = ret.WithKeyPrefix(keyPrefix+":");
            return ret;
        }

        /// <summary>
        /// 获得RedisClient
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static RedisClient GetClient(string connectionStringName = null)
        {
            var config = GetConfig(connectionStringName);
            var serializer = GetSerializer(config.serializer);
            var database = GetDatabase(config.ConnectionString, config.Database, config.KeyPrefix);
            return new RedisClient(database, serializer);
        }

        /// <summary>
        /// 获得RedisClient
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="serializer"></param>
        /// <param name="database"></param>
        /// <param name="keyPrefix"></param>
        /// <returns></returns>
        public static RedisClient GetClient(string connectionString, ISerializer serializer, int database, string keyPrefix = null)
        {
            serializer = serializer ?? new NewtonsoftSerializer();
            var db = GetDatabase(connectionString, database, keyPrefix);
            return new RedisClient(db, serializer);
        }

        #region Utils
        private static (string ConnectionString, int Database, string KeyPrefix, string serializer) GetConfig(string connectionStringName = null)
        {
            var config = TinyFxConfigManager.GetConfig<RedisConfig>();
            if (config == null)
                throw new Exception("tinyfx.config文件中redis配置不存在。");
            if (string.IsNullOrEmpty(connectionStringName))
                connectionStringName = config.DefaultConnectionString;
            if (string.IsNullOrEmpty(connectionStringName))
                throw new ArgumentNullException("connectionStringName");
            if (!config.ConnectionStrings.TryGetValue(connectionStringName, out RedisConnectionStringElement element))
                throw new Exception($"redis配置connectionStrings中不存在指定的connectionStringName:{connectionStringName}");
            if (string.IsNullOrEmpty(element.ConnectionString))
                throw new Exception($"redis配置connectionStrings中connectionStringName={connectionStringName}的connectionString不能为空。");
            return (element.ConnectionString, element.Database, element.KeyPrefix, element.Serializer);
        }
        private static ISerializer GetSerializer(string typeName)
        {
            return _serializers.GetOrAdd(typeName, (name) => {
                return string.IsNullOrEmpty(name) ? new NewtonsoftSerializer()
                    : (ISerializer)Activator.CreateInstance(Type.GetType(name));
            });
        }
        private static ConnectionMultiplexer GetMultiplexer(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");
            return _multiplexers.GetOrAdd(connectionString, (key)=> {
                return ConnectionMultiplexer.Connect(connectionString);
            });
        }
        #endregion
    }
}
