﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyFx.Configuration;
using TinyFx.Log4net;

namespace TinyFx.Data.Instrumentation
{
    /// <summary>
    /// 数据操作执行事件监测类
    /// 除了TransactionUndisposedEvent外其他事件不处理
    /// </summary>
    public class DefaultDataInstProvider : IDataInstProvider
    {
        private DefaultDataInstProvider() { }
        /// <summary>
        /// 单例模式
        /// </summary>
        public static readonly DefaultDataInstProvider Instance = new DefaultDataInstProvider();
        /// <summary>
        /// 执行ConnectionOpened事件
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public virtual void FireConnectionOpenedEvent(string connectionString)
        { }

        /// <summary>
        /// 执行CommandExecuted事件
        /// </summary>
        /// <param name="command">Command对象</param>
        /// <param name="startTime">执行起始时间</param>
        /// <param name="endTime">执行结束时间</param>
        public virtual void FireCommandExecutedEvent(CommandWrapper command, DateTime startTime, DateTime endTime)
        { }

        /// <summary>
        /// 执行ConnectionFailed事件
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="exception">执行失败时抛出的异常</param>
        public virtual void FireConnectionFailedEvent(string connectionString, Exception exception)
        {
            LogUtil.Error("无法连接数据库。ConnectionString:" + connectionString, exception);
        }

        /// <summary>
        /// 执行CommandFailed事件
        /// </summary>
        /// <param name="command">执行的Command对象</param>
        /// <param name="exception">执行失败时抛出的异常</param>
        public virtual void FireCommandFailedEvent(CommandWrapper command, Exception exception)
        {
            //LogUtil.Error("Command对象执行错误。CommandText: "+command.CommandText, exception);
            LogUtil.Error("Command对象执行错误。CommandText: " + command.CommandText, exception);
        }

        /// <summary>
        /// 执行TransactionUndisposed事件,处理事务没有Commit或Rollback的情况
        /// </summary>
        /// <param name="exception">执行失败时抛出的异常</param>
        public virtual void FireTransactionUndisposedEvent(Exception exception)
        {
            LogUtil.Error("TransactionManager事务未关闭。", exception);
        }
    }
}
