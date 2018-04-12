using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.StackExchangeRedis.ServerIteration
{
    /// <summary>
    /// 执行服务器端命令时使用的策略
    /// </summary>
    public class ServerEnumerationStrategy
    {
        /// <summary>
        /// 选择单个还是全部服务器
        /// </summary>
        public ModeOptions Mode { get; set; }

        /// <summary>
        /// 服务器选择策略：选择任一个还是优先Slave
        /// </summary>
        public TargetRoleOptions TargetRole { get; set; }
        
        /// <summary>
        /// 无法访问的服务器操作选项: throw异常或忽略
        /// </summary>
        public UnreachableServerActionOptions UnreachableServerAction { get; set; }
    }

    /// <summary>
    /// 选择单个还是全部服务器
    /// </summary>
    public enum ModeOptions
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = 0,
        /// <summary>
        /// 仅选择一个
        /// </summary>
        Single
    }

    /// <summary>
    /// 服务器选择策略：选择任一个还是优先Slave
    /// </summary>
    public enum TargetRoleOptions
    {
        Any = 0,
        /// <summary>
        /// 优先选择slave服务器
        /// </summary>
        PreferSlave
    }

    /// <summary>
    /// 无法访问的服务器操作选项: throw异常或忽略
    /// </summary>
    public enum UnreachableServerActionOptions
    {
        /// <summary>
        /// 抛出异常
        /// </summary>
        Throw = 0,
        /// <summary>
        /// 忽略无效
        /// </summary>
        IgnoreIfOtherAvailable
    }
}
