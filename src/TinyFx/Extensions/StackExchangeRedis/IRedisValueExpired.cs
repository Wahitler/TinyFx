using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// Redis集合结构中缓存项过期接口
    /// </summary>
    public interface IRedisValueExpired
    {
        /// <summary>
        /// 缓存过期时间
        /// </summary>
        DateTime RedisExpiredDate { get; set; }
    }
}
