using StackExchange.Redis;
using StackExchange.Redis.KeyspaceIsolation;
using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Extensions.StackExchangeRedis.Serializers;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using TinyFx.Extensions.StackExchangeRedis.ServerIteration;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// 访问操作Redis的Client
    /// string类型使用此对象，其他对象
    /// </summary>
    public class RedisClient
    {
        #region Constructors & Fields
        /// <summary>
        /// IConnectionMultiplexer
        /// </summary>
        public IConnectionMultiplexer Multiplexer => Database.Multiplexer;

        /// <summary>
        /// IDatabase
        /// </summary>
        public IDatabase Database { get; private set; }
        
        /// <summary>
        /// 系列化器
        /// </summary>
        public ISerializer Serializer { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="database"></param>
        /// <param name="serializer"></param>
        public RedisClient(IDatabase database, ISerializer serializer)
        {
            Database = database;
            Serializer = serializer;
        }
        #endregion

        #region SearchKeys
        /// <summary>
        /// 从Redis数据库中搜索密钥keys，生产环境小心使用，可能会破坏性能
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="strategy"></param>
        /// <example>
        ///		如果要返回以“myCacheKey”开头的所有键使用“myCacheKey *”
        ///		如果要返回包含“myCacheKey”的所有键使用“* myCacheKey *”
        ///		如果要返回以“myCacheKey”结尾的所有键使用“* myCacheKey”
        /// </example>
        /// <returns>从Redis数据库检索的key集合</returns>
        public IEnumerable<string> SearchKeys(string pattern, ServerEnumerationStrategy strategy)
        {
            var keys = new HashSet<RedisKey>();

            var multiplexer = Database.Multiplexer;
            var servers = ServerIteratorFactory.GetServers(multiplexer, strategy).ToArray();
            if (!servers.Any())
            {
                throw new Exception("No server found to serve the KEYS command.");
            }

            foreach (var server in servers)
            {
                var dbKeys = server.Keys(Database.Database, pattern);
                foreach (var dbKey in dbKeys)
                {
                    if (!keys.Contains(dbKey))
                    {
                        keys.Add(dbKey);
                    }
                }
            }

            return keys.Select(x => (string)x);
        }

        /// <summary>
        /// 从Redis数据库中搜索密钥keys，生产环境小心使用，可能会破坏性能
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="strategy"></param>
        /// <example>
        ///		如果要返回以“myCacheKey”开头的所有键使用“myCacheKey *”
        ///		如果要返回包含“myCacheKey”的所有键使用“* myCacheKey *”
        ///		如果要返回以“myCacheKey”结尾的所有键使用“* myCacheKey”
        /// </example>
        /// <returns>从Redis数据库检索的key集合</returns>
        public Task<IEnumerable<string>> SearchKeysAsync(string pattern, ServerEnumerationStrategy strategy)
            => Task.Factory.StartNew(() => SearchKeys(pattern, strategy));
        #endregion

        #region FlashDb/Save
        /// <summary>
        /// 刷新数据库Database
        /// </summary>
        public void FlushDb()
        {
            var endPoints = Multiplexer.GetEndPoints();
            foreach (var endpoint in endPoints)
            {
                Multiplexer.GetServer(endpoint).FlushDatabase(Database.Database);
            }
        }

        /// <summary>
        /// 刷新数据库Database
        /// </summary>
        public async Task FlushDbAsync()
        {
            var endPoints = Multiplexer.GetEndPoints();
            foreach (var endpoint in endPoints)
            {
                await Multiplexer.GetServer(endpoint).FlushDatabaseAsync(Database.Database);
            }
        }

        /// <summary>
        /// 后台保存Database
        /// </summary>
        /// <param name="saveType"></param>
        public void Save(SaveType saveType)
        {
            var endPoints = Multiplexer.GetEndPoints();
            foreach (var endpoint in endPoints)
            {
                Multiplexer.GetServer(endpoint).Save(saveType);
            }
        }

        /// <summary>
        /// 后台保存Database
        /// </summary>
        /// <param name="saveType"></param>
        public async void SaveAsync(SaveType saveType)
        {
            var endPoints = Multiplexer.GetEndPoints();
            foreach (var endpoint in endPoints)
            {
                await Multiplexer.GetServer(endpoint).SaveAsync(saveType);
            }
        }
        #endregion

        #region GetInfo
        /// <summary>
        /// 获取Redis信息。更多查看 http://redis.io/commands/INFO
        /// </summary>
        public Dictionary<string, string> GetInfo()
        {
            var info = Database.ScriptEvaluate("return redis.call('INFO')").ToString();
            return ParseInfo(info);
        }

        /// <summary>
        /// 获取Redis信息。更多查看 http://redis.io/commands/INFO
        /// </summary>
        public async Task<Dictionary<string, string>> GetInfoAsync()
        {
            var info = (await Database.ScriptEvaluateAsync("return redis.call('INFO')")).ToString();
            return ParseInfo(info);
        }
        private Dictionary<string, string> ParseInfo(string info)
        {
            var lines = info.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var data = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) || line[0] == '#')
                {
                    // 2.6+ can have empty lines, and comment lines
                    continue;
                }

                var idx = line.IndexOf(':');
                if (idx > 0) // double check this line looks about right
                {
                    var key = line.Substring(0, idx);
                    var infoValue = line.Substring(idx + 1).Trim();

                    data.Add(key, infoValue);
                }
            }

            return data;
        }
        #endregion

        #region Publish/Subscribe
        /// <summary>
        /// 发布消息到Channel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public long Publish<T>(RedisChannel channel, T message, CommandFlags flags = CommandFlags.None)
        {
            var sub = Multiplexer.GetSubscriber();
            return sub.Publish(channel, Serializer.Serialize(message), flags);
        }

        /// <summary>
        /// 发布消息到Channel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public async Task<long> PublishAsync<T>(RedisChannel channel, T message, CommandFlags flags = CommandFlags.None)
        {
            var sub = Multiplexer.GetSubscriber();
            return await sub.PublishAsync(channel, await Serializer.SerializeAsync(message), flags);
        }

        /// <summary>
        /// 注册回调处理程序handler来处理发布到通道channel的消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="handler"></param>
        /// <param name="flags"></param>
        public void Subscribe<T>(RedisChannel channel, Action<T> handler, CommandFlags flags = CommandFlags.None)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            var sub = Multiplexer.GetSubscriber();
            sub.Subscribe(channel, (redisChannel, value) => handler(Serializer.Deserialize<T>(value)), flags);
        }

        /// <summary>
        /// 注册回调处理程序handler来处理发布到通道channel的消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="handler"></param>
        /// <param name="flags"></param>
        public async Task SubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler,
            CommandFlags flags = CommandFlags.None)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            var sub = Multiplexer.GetSubscriber();
            await
                sub.SubscribeAsync(channel, async (redisChannel, value) => await handler(Serializer.Deserialize<T>(value)), flags);
        }

        /// <summary>
        /// 注销已注册在Channel中的消息处理Handler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="handler"></param>
        /// <param name="flags"></param>
        public void Unsubscribe<T>(RedisChannel channel, Action<T> handler, CommandFlags flags = CommandFlags.None)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            var sub = Multiplexer.GetSubscriber();
            sub.Unsubscribe(channel, (redisChannel, value) => handler(Serializer.Deserialize<T>(value)), flags);
        }

        /// <summary>
        /// 注销已注册在Channel中的消息处理Handler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="handler"></param>
        /// <param name="flags"></param>
        public async Task UnsubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler,
            CommandFlags flags = CommandFlags.None)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            var sub = Multiplexer.GetSubscriber();
            await sub.UnsubscribeAsync(channel, (redisChannel, value) => handler(Serializer.Deserialize<T>(value)), flags);
        }

        /// <summary>
        /// 注销所有已注册在通道上的所有消息处理程序
        /// </summary>
        /// <param name="flags"></param>
        public void UnsubscribeAll(CommandFlags flags = CommandFlags.None)
        {
            var sub = Multiplexer.GetSubscriber();
            sub.UnsubscribeAll(flags);
        }

        /// <summary>
        /// 注销所有已注册在通道上的所有消息处理程序
        /// </summary>
        /// <param name="flags"></param>
        public async Task UnsubscribeAllAsync(CommandFlags flags = CommandFlags.None)
        {
            var sub = Multiplexer.GetSubscriber();
            await sub.UnsubscribeAllAsync(flags);
        }
        #endregion

        #region Exists/Expire
        /// <summary>
        /// 验证缓存Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
            => Database.KeyExists(key);

        /// <summary>
        /// 验证缓存Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(string key)
            => Database.KeyExistsAsync(key);
        /// <summary>
        /// 设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool SetExpire(string key, TimeSpan expiry)
            => Database.KeyExpire(key, expiry);
        
        /// <summary>
        /// 设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool SetExpire(string key, DateTime expiry)
            => Database.KeyExpire(key, expiry);
        #endregion

        #region Set
        /// <summary>
        /// 添加缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>添加成功返回true</returns>
        public bool Set<T>(string key, T value)
        {
            var entryBytes = Serializer.Serialize(value);
            return Database.StringSet(key, entryBytes);
        }

        /// <summary>
        /// 添加缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>添加成功返回true</returns>
        public async Task<bool> SetAsync<T>(string key, T value)
        {
            var entryBytes = await Serializer.SerializeAsync(value);
            return await Database.StringSetAsync(key, entryBytes);
        }

        /// <summary>
        /// 添加缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresAt">指定过期时间</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, DateTimeOffset expiresAt)
        {
            var entryBytes = Serializer.Serialize(value);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);

            return Database.StringSet(key, entryBytes, expiration);
        }

        /// <summary>
        /// 添加缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresAt">到期时间</param>
        /// <returns></returns>
        public async Task<bool> SetAsync<T>(string key, T value, DateTimeOffset expiresAt)
        {
            var entryBytes = await Serializer.SerializeAsync(value);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);

            return await Database.StringSetAsync(key, entryBytes, expiration);
        }

        /// <summary>
        /// 添加缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn">缓存持续时间</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            var entryBytes = Serializer.Serialize(value);
            return Database.StringSet(key, entryBytes, expiresIn);
        }

        /// <summary>
        /// 添加缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn">缓存持续时间</param>
        /// <returns></returns>
        public async Task<bool> SetAsync<T>(string key, T value, TimeSpan expiresIn)
        {
            var entryBytes = await Serializer.SerializeAsync(value);
            return await Database.StringSetAsync(key, entryBytes, expiresIn);
        }
        /// <summary>
        /// 添加多个缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool SetAll<T>(IList<(string key, T item)> items)
        {
            var values = items
                .Select(item => new KeyValuePair<RedisKey, RedisValue>(item.Item1, Serializer.Serialize(item.Item2)))
                .ToArray();

            return Database.StringSet(values);
        }

        /// <summary>
        /// 添加多个缓存项，如果存在则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<bool> SetAllAsync<T>(IList<(string key, T item)> items)
        {
            var values = items
                .Select(item => new KeyValuePair<RedisKey, RedisValue>(item.Item1, Serializer.Serialize(item.Item2)))
                .ToArray();

            return await Database.StringSetAsync(values);
        }
        #endregion

        #region Get
        /// <summary>
        /// 获取指定key的缓存项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns>如果不存在则为空，否则为T</returns>
        public T Get<T>(string key)
        {
            var valueBytes = Database.StringGet(key);

            if (!valueBytes.HasValue)
            {
                return default(T);
            }

            return Serializer.Deserialize<T>(valueBytes);
        }

        /// <summary>
        /// 获取指定key的缓存项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns>如果不存在则为空，否则为T</returns>
        public async Task<T> GetAsync<T>(string key)
        {
            var valueBytes = await Database.StringGetAsync(key);

            if (!valueBytes.HasValue)
            {
                return default(T);
            }

            return await Serializer.DeserializeAsync<T>(valueBytes);
        }
        /// <summary>
        /// 获取指定kyes的缓存集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns>如果缓存key不存在返回null</returns>
        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            var redisKeys = keys.Select(x => (RedisKey)x).ToArray();
            var result = Database.StringGet(redisKeys);

            var dict = new Dictionary<string, T>(StringComparer.Ordinal);
            for (var index = 0; index < redisKeys.Length; index++)
            {
                var value = result[index];
                dict.Add(redisKeys[index], value == RedisValue.Null ? default(T) : Serializer.Deserialize<T>(value));
            }

            return dict;
        }

        /// <summary>
        /// 获取指定kyes的缓存集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns>如果缓存key不存在返回null</returns>
        public async Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys)
        {
            var redisKeys = keys.Select(x => (RedisKey)x).ToArray();
            var result = await Database.StringGetAsync(redisKeys);
            var dict = new Dictionary<string, T>(StringComparer.Ordinal);
            for (var index = 0; index < redisKeys.Length; index++)
            {
                var value = result[index];
                dict.Add(redisKeys[index], value == RedisValue.Null ? default(T) : Serializer.Deserialize<T>(value));
            }
            return dict;
        }
        #endregion

        #region Remove
        /// <summary>
        /// 移除指定key缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns>如果成功移除返回true，反之false</returns>
        public bool Remove(string key)
            => Database.KeyDelete(key);

        /// <summary>
        /// 移除指定key缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns>如果成功移除返回true，反之false</returns>
        public Task<bool> RemoveAsync(string key)
            => Database.KeyDeleteAsync(key);
        /// <summary>
        /// 删除所有指定keys
        /// </summary>
        /// <param name="keys"></param>
        public void RemoveAll(IEnumerable<string> keys)
        {
            var redisKeys = keys.Select(x => (RedisKey)x).ToArray();
            Database.KeyDelete(redisKeys);
        }

        /// <summary>
        /// 删除所有指定keys
        /// </summary>
        /// <param name="keys"></param>
        public Task RemoveAllAsync(IEnumerable<string> keys)
        {
            var redisKeys = keys.Select(x => (RedisKey)x).ToArray();
            return Database.KeyDeleteAsync(redisKeys);
        }
        #endregion

        #region Increment/Decrement
        /// <summary>
        /// 增量数字+value，如不存在key则创建,返回增加后值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Increment(string key, long value = 1)
            => Database.StringIncrement(key, value);

        /// <summary>
        /// 增量数字+value，如不存在key则创建,返回增加后值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Increment(string key, double value = 1)
            => Database.StringIncrement(key, value);
        
        /// <summary>
        /// 减量数字-value,如不存在key则创建，返回减量后值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Decrement(string key, long value = 1)
            => Database.StringDecrement(key, value);
        /// <summary>
        /// 减量数字-value,如不存在key则创建，返回减量后值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Decrement(string key, double value = 1)
            => Database.StringDecrement(key, value);
        #endregion
    }
}
