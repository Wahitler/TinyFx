using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.StackExchangeRedis
{
    /// <summary>
    /// 缓存项未找到
    /// </summary>
    public class RedisNotFound : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public RedisNotFound(string message) : base(message) { }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        public RedisNotFound(string hashId, string key) : base(string.Format("未找到缓存项，hashId: {0} key: {1}", hashId, key)) { }

    }
}
