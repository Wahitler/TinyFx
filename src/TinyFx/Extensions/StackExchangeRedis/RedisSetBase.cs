using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// Redis Set集合（不重复集合）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RedisSetBase<T>: RedisObjectBase<T>
    {
        protected override string GetRedisKey() => $"set:{RedisKey}";
    }
}
