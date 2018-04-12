using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using StackExchange.Redis;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// Redis List双向链表结构（左右两边操作）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RedisListBase<T>:RedisObjectBase<T>
    {
        protected override string GetRedisKey() => $"list:{RedisKey}";

        public T GetByIndex(long index, CommandFlags flags = CommandFlags.None)
        {
            var value = Database.ListGetByIndex(GetRedisKey(), index, flags);
            return value.HasValue ? Serializer.Deserialize<T>(value) : default(T);
        }
        public T LeftPop(CommandFlags commandFlags = CommandFlags.None)
        {
            var value = Database.ListLeftPop(GetRedisKey(), commandFlags);
            return value.HasValue ? Serializer.Deserialize<T>(value) : default(T);
        }
        public long LeftPush(T value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => Database.ListLeftPush(GetRedisKey(), Serializer.Serialize(value), when, flags);
        public long LeftPush(IEnumerable<T> values, CommandFlags flags = CommandFlags.None)
            => Database.ListLeftPush(GetRedisKey(), values.Select(x=>(RedisValue)Serializer.Serialize(x)).ToArray(), flags);
        public long GetLength(CommandFlags flags = CommandFlags.None)
            => Database.ListLength(GetRedisKey(), flags);
        /// <summary>
        /// 移除list中缓存项。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count">count大于0 从头删除count个元素; count=0 删除全部; count小于0 从后删除count个元素</param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public long Remove(T value, long count = 0, CommandFlags flags = CommandFlags.None)
            => Database.ListRemove(GetRedisKey(), Serializer.Serialize(value), count, flags);
        public T RightPop(CommandFlags flags = CommandFlags.None)
        {
            var value = Database.ListRightPop(GetRedisKey(), flags);
            return value.HasValue ? Serializer.Deserialize<T>(value) : default(T);
        }
        public long RightPush(T value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => Database.ListRightPush(GetRedisKey(), Serializer.Serialize(value), when, flags);
        public long RightPush(IEnumerable<T> values, CommandFlags flags = CommandFlags.None)
            => Database.ListRightPush(GetRedisKey(), values.Select(x => (RedisValue)Serializer.Serialize(x)).ToArray(), flags);
        public void SetByIndex(long index, T value, CommandFlags flags = CommandFlags.None)
            => Database.ListSetByIndex(GetRedisKey(), index, Serializer.Serialize(value), flags);
        public void Trim(long start, long stop, CommandFlags flags = CommandFlags.None)
            => Database.ListTrim(GetRedisKey(), start, stop, flags);

    }
}
