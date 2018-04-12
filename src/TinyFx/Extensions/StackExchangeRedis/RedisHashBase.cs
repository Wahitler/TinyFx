using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using StackExchange.Redis;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// Redis Hash表（key-value结构）
    ///     RedisKey => HashField => RedisValue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RedisHashBase<T> : RedisObjectBase<T>
    {
        /// <summary>
        /// RedisKey
        /// </summary>
        /// <returns></returns>
        protected override string GetRedisKey() => $"hash_{RedisKey}";

        /// <summary>
        /// 根据field从缓存源获取缓存项
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public abstract T GetRedisValueFromSource(string field);

        #region Set
        /// <summary>
        /// 设置hash结构中的field。如果key不存在创建，如果field存在则覆盖，不存在则添加
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="nx"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public bool Set(string field, T value, bool nx = false, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashSet(GetRedisKey(), field, Serializer.Serialize(value), nx ? When.NotExists : When.Always, commandFlags);

        /// <summary>
        /// 设置hash结构中的field。如果key不存在创建，如果field存在则覆盖，不存在则添加
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="nx"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<bool> SetAsync(string field, T value, bool nx = false, CommandFlags commandFlags = CommandFlags.None)
            => await Database.HashSetAsync(GetRedisKey(), field, Serializer.Serialize(field), nx ? When.NotExists : When.Always, commandFlags);

        /// <summary>
        /// 设置hash结构中的field。如果key不存在创建，如果field存在则覆盖，不存在则添加
        /// </summary>
        /// <param name="values"></param>
        /// <param name="commandFlags"></param>
        public void Set(Dictionary<string, T> values, CommandFlags commandFlags = CommandFlags.None)
        {
            var entries = values.Select(kv => new HashEntry(kv.Key, Serializer.Serialize(kv.Value)));
            Database.HashSet(GetRedisKey(), entries.ToArray(), commandFlags);
        }

        /// <summary>
        /// 设置hash结构中的field。如果key不存在创建，如果field存在则覆盖，不存在则添加
        /// </summary>
        /// <param name="values"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task SetAsync(Dictionary<string, T> values, CommandFlags commandFlags = CommandFlags.None)
        {
            var entries = values.Select(kv => new HashEntry(kv.Key, Serializer.Serialize(kv.Value)));
            await Database.HashSetAsync(GetRedisKey(), entries.ToArray(), commandFlags);
        }
        #endregion

        #region Get
        private (bool hasValue, T value) GetIfValid(string field, CommandFlags commandFlags = CommandFlags.None)
        {
            var redisValue = Database.HashGet(GetRedisKey(), field, commandFlags);
            if (redisValue.HasValue)
            {
                var value = Serializer.Deserialize<T>(redisValue);
                if (!IsRedisValueExpired(value))
                    return (true, value);
                else
                    Remove(field, commandFlags);
            }
            return (false, default(T));
        }
        /// <summary>
        /// 从Hash结构根据field获取缓存项，如果不存在则调用GetRedisValueFromSource()放入redis并返回
        /// </summary>
        /// <param name="field"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public T Get(string field, CommandFlags commandFlags = CommandFlags.None)
        {
            T ret = default(T);
            var redisValue = GetIfValid(field, commandFlags);
            if (!redisValue.hasValue)
            {
                // 没有值或已过期
                ret = GetRedisValueFromSource(field);
                Database.HashSet(GetRedisKey(), field, Serializer.Serialize(ret), When.Always, commandFlags);
            }
            else
                ret = redisValue.value;
            return ret;
        }
        /// <summary>
        /// 从Hash结构根据field获取缓存项，如果不存在则抛出异常RedisNotFound
        /// </summary>
        /// <param name="field"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public T GetOrException(string field, CommandFlags commandFlags = CommandFlags.None)
        {
            var redisValue = GetIfValid(field, commandFlags);
            if (!redisValue.hasValue)
                throw new RedisNotFound(GetRedisKey(), field);
            return redisValue.value;
        }

        /// <summary>
        /// 从Hash结构根据field获取缓存项，如果不存在，则返回默认值。
        /// </summary>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public T GetOrDefault(string field, T defaultValue, CommandFlags commandFlags = CommandFlags.None)
        {
            var redisValue = GetIfValid(field, commandFlags);
            return (redisValue.hasValue) ? redisValue.value : defaultValue;
        }

        /// <summary>
        /// 从Hash结构Get缓存项
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public Dictionary<string, T> Get(IEnumerable<string> fields, CommandFlags commandFlags = CommandFlags.None)
        {
            var result = new Dictionary<string, T>();
            var hashFields = fields.Select((field) => (RedisValue)field).ToArray();
            var values = Database.HashGet(GetRedisKey(), hashFields, commandFlags);
            for (int i = 0; i < hashFields.Length; i++)
            {
                var field = Convert.ToString(hashFields[i]);
                var redisValue = values[i];
                T value = default(T);
                if (redisValue.HasValue)
                {
                    value = Serializer.Deserialize<T>(redisValue);
                    if (!IsRedisValueExpired(value))
                    {
                        result.Add(field, value);
                        continue;
                    }
                }
                value = GetRedisValueFromSource(field);
                Database.HashSet(GetRedisKey(), field, Serializer.Serialize(value), When.Always, commandFlags);
                result.Add(field, value);
            }
            return result;
        }

        /// <summary>
        /// 从Hash结构Get缓存项
        /// </summary>
        /// <param name="field"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(string field, CommandFlags commandFlags = CommandFlags.None)
            => await Task.Factory.StartNew(()=> Get(field, commandFlags));

        /// <summary>
        /// 从Hash结构Get缓存项
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, T>> GetAsync(IEnumerable<string> fields, CommandFlags commandFlags = CommandFlags.None)
            => await Task.Factory.StartNew(()=> Get(fields, commandFlags));

        /// <summary>
        /// 从Hash结构Get缓存项
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public Dictionary<string, T> GetAll(CommandFlags commandFlags = CommandFlags.None)
        {
            var ret = new Dictionary<string, T>();
            var entries = Database.HashGetAll(GetRedisKey(), commandFlags);
            foreach (var entry in entries)
            {
                var value = Serializer.Deserialize<T>(entry.Value);
                if (!IsRedisValueExpired(value))
                    ret.Add(entry.Name.ToString(), value);
            }
            return ret;
        }

        /// <summary>
        /// 从Hash结构Get缓存项
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, T>> GetAllAsync(CommandFlags commandFlags = CommandFlags.None)
            => await Task.Factory.StartNew(()=> GetAll(commandFlags));
        #endregion

        #region Remove
        /// <summary>
        /// 从Hash结构移除key。时间复杂度：O(1)
        /// </summary>
        /// <param name="field"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public bool Remove(string field, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashDelete(GetRedisKey(), field, commandFlags);

        /// <summary>
        /// 从Hash结构移除keys。时间复杂度：O(1)
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public long Remove(IEnumerable<string> fields, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashDelete(GetRedisKey(), fields.Select(x => (RedisValue)x).ToArray(), commandFlags);

        /// <summary>
        /// 从Hash结构移除key。时间复杂度：O(1)
        /// </summary>
        /// <param name="field"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public Task<bool> RemoveAsync(string field, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashDeleteAsync(GetRedisKey(), field, commandFlags);

        /// <summary>
        /// 从Hash结构移除keys。时间复杂度：O(1)
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public Task<long> RemoveAsync(IEnumerable<string> fields, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashDeleteAsync(GetRedisKey(), fields.Select(x => (RedisValue)x).ToArray(), commandFlags);
        #endregion

        #region Exists/Keys/Values/Length/Scan
        /// <summary>
        /// Hash是否存在指定key
        /// </summary>
        /// <param name="field"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public bool Exists(string field, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashExists(GetRedisKey(), field, commandFlags);

        /// <summary>
        /// Hash是否存在指定key
        /// </summary>
        /// <param name="field"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(string field, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashExistsAsync(GetRedisKey(), field, commandFlags);

        /// <summary>
        /// 获取所有hash中的keys
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public IEnumerable<string> GetFields(CommandFlags commandFlags = CommandFlags.None)
            => Database.HashKeys(GetRedisKey(), commandFlags).Select(x => x.ToString());

        /// <summary>
        /// 获取所有hash中的keys
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetFieldsAsync(CommandFlags commandFlags = CommandFlags.None)
            => (await Database.HashKeysAsync(GetRedisKey(), commandFlags)).Select(x => x.ToString());

        /// <summary>
        /// 返回所有hash结构的fields
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public IEnumerable<T> GetValues(CommandFlags commandFlags = CommandFlags.None)
            => Database.HashValues(GetRedisKey(), commandFlags).Select(x => Serializer.Deserialize<T>(x));

        /// <summary>
        /// 返回所有hash结构的fields
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetValuesAsync(CommandFlags commandFlags = CommandFlags.None)
            => (await Database.HashValuesAsync(GetRedisKey(), commandFlags)).Select(x => Serializer.Deserialize<T>(x));

        /// <summary>
        /// 获取hash内缓存项数量
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public long GetLength(CommandFlags commandFlags = CommandFlags.None)
            => Database.HashLength(GetRedisKey(), commandFlags);
        
        /// <summary>
        /// 获取hash内缓存项数量
        /// </summary>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<long> GetLengthAsync(CommandFlags commandFlags = CommandFlags.None)
            => await Database.HashLengthAsync(GetRedisKey(), commandFlags);

        /// <summary>
        /// 在hash结构中查询fields。时间复杂度O(N).N为hash中的field数量
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="pageSize"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public Dictionary<string, T> Scan(string pattern, int pageSize = 10, CommandFlags commandFlags = CommandFlags.None)
        {
            return Database.HashScan(GetRedisKey(), pattern, pageSize, commandFlags).ToDictionary(
                x => x.Name.ToString(),
                x => Serializer.Deserialize<T>(x.Value),
                StringComparer.Ordinal);
        }

        /// <summary>
        /// 在hash结构中查询fields。时间复杂度O(N).N为hash中的field数量
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="pageSize"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, T>> ScanAsync(string pattern, int pageSize = 10, CommandFlags commandFlags = CommandFlags.None)
        {
            return (await Task.Run(() => Database.HashScan(GetRedisKey(), pattern, pageSize, commandFlags)))
                .ToDictionary(x => x.Name.ToString(), x => Serializer.Deserialize<T>(x.Value), StringComparer.Ordinal);
        }
        #endregion

        #region Increment
        /// <summary>
        /// Hash结构存储增量数字。如果field不存在则设置为0。支持long
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public long Increment(string field, long value, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashIncrement(GetRedisKey(), field, value, commandFlags);

        /// <summary>
        /// Hash结构存储增量数字。如果field不存在则设置为0。支持long
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public double Increment(string field, double value, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashIncrement(GetRedisKey(), field, value, commandFlags);

        /// <summary>
        /// 减量数字-value,如不存在key则创建，返回减量后值
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public long Decrement(string field, long value, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashDecrement(GetRedisKey(), field, value, commandFlags);

        /// <summary>
        /// 减量数字-value,如不存在key则创建，返回减量后值
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="commandFlags"></param>
        /// <returns></returns>
        public double Decrement(string field, double value, CommandFlags commandFlags = CommandFlags.None)
            => Database.HashDecrement(GetRedisKey(), field, value, commandFlags);

        #endregion
    }
}
