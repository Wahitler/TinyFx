using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// Redis Zset集合（排序的不重复集合）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RedisSortedSetBase<T>: RedisObjectBase<T>
    {
        protected override string GetRedisKey() => $"zset:{RedisKey}";
    }
}
