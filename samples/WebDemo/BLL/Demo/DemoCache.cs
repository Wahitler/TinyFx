using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Extensions.StackExchangeRedis;
using TinyFx.Runtime.Caching;

namespace WebDemo.BLL.Demo
{
    /// <summary>
    /// Redis 缓存类
    /// </summary>
    public class DemoCache : RedisHashBase<string>
    {
        public override string GetRedisValueFromSource(string field)
        {
            return $"{field}_Value";
        }
    }

    /// <summary>
    /// 内存缓存类
    /// </summary>
    public class Demo2Cache : MemoryCacheHashBase<string>
    {
        protected override CacheValue<string> GetCacheValue(string key)
        {
            CacheValue<string> ret = $"{key}_Value";
            return ret;
        }
    }
}
