using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.StackExchangeRedis.ServerIteration
{
    public class ServerEnumerable : IEnumerable<IServer>
    {
        private readonly ConnectionMultiplexer multiplexer;
        private readonly TargetRoleOptions targetRole;
        private readonly UnreachableServerActionOptions unreachableServerAction;

        public ServerEnumerable(ConnectionMultiplexer multiplexer, TargetRoleOptions targetRole, UnreachableServerActionOptions unreachableServerAction)
        {
            this.multiplexer = multiplexer;
            this.targetRole = targetRole;
            this.unreachableServerAction = unreachableServerAction;
        }

        public IEnumerator<IServer> GetEnumerator()
        {
            foreach (var endPoint in multiplexer.GetEndPoints())
            {
                var server = multiplexer.GetServer(endPoint);
                if (targetRole == TargetRoleOptions.PreferSlave)
                {
                    if (!server.IsSlave)
                        continue;
                }
                if (unreachableServerAction == UnreachableServerActionOptions.IgnoreIfOtherAvailable)
                {
                    if (!server.IsConnected || !server.Features.Scan)
                        continue;
                }

                yield return server;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
