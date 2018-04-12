using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Runtime.Caching
{
    /// <summary>
    /// 未找到缓存项异常
    /// </summary>
    public class MemoryCacheNotFound:Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public MemoryCacheNotFound(string message) : base(message) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="key"></param>
        public MemoryCacheNotFound(string collectionId, string key) : base($"未找到缓存项：cacheType:{collectionId} key:{key}") { }
    }
}
