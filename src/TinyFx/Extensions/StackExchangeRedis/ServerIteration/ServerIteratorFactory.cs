using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyFx.Extensions.StackExchangeRedis.ServerIteration
{
    /// <summary>
    /// 服务器迭代器Factory
    /// </summary>
    public class ServerIteratorFactory
    {
        public static IEnumerable<IServer> GetServers(ConnectionMultiplexer multiplexer, ServerEnumerationStrategy serverEnumerationStrategy)
        {
            switch (serverEnumerationStrategy.Mode)
            {
                case ModeOptions.All:
                    var serversAll = new ServerEnumerable(multiplexer,
                        serverEnumerationStrategy.TargetRole,
                        serverEnumerationStrategy.UnreachableServerAction);
                    return serversAll;

                case ModeOptions.Single:
                    var serversSingle = new ServerEnumerable(multiplexer,
                        serverEnumerationStrategy.TargetRole,
                        serverEnumerationStrategy.UnreachableServerAction);
                    return serversSingle.Take(1);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
