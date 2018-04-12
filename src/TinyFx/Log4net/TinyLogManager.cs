using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TinyFx.Log4net
{
    /// <summary>
    /// 创建Log的静态管理器
    /// </summary>
    public static class TinyLogManager
    {
        private static readonly WrapperMap _wrapperMap = new WrapperMap(new WrapperCreationHandler(WrapperCreationHandler));

        #region Methods

        /// <summary>
        /// 如果存在返回ILog否则null
        /// </summary>
        /// <param name="name">log4net.config中配置的Logger Name</param>
        /// <returns></returns>
        public static ITinyLog Exists(string name)
            => Exists(Assembly.GetCallingAssembly(), name);

        /// <summary>
        /// 如果存在返回ILog否则null
        /// </summary>
        /// <param name="repository">logger所在repository</param>
        /// <param name="name">log4net.config中配置的Logger Name</param>
        /// <returns></returns>
        public static ITinyLog Exists(string repository, string name)
            => WrapLogger(LoggerManager.Exists(repository, name));

        /// <summary>
        /// 如果存在返回ILog否则null
        /// </summary>
        /// <param name="assembly">查找domain中的assembly</param>
        /// <param name="name">log4net.config中配置的Logger Name</param>
        /// <returns></returns>
        public static ITinyLog Exists(Assembly assembly, string name)
            => WrapLogger(LoggerManager.Exists(assembly, name));

        /// <summary>
        /// 返回默认repository中的所有loggers
        /// </summary>
        /// <returns></returns>
        public static ITinyLog[] GetCurrentLoggers()
            => GetCurrentLoggers(Assembly.GetCallingAssembly());

        /// <summary>
        /// 返回repository中的所有loggers
        /// </summary>
        /// <returns></returns>
        public static ITinyLog[] GetCurrentLoggers(string repository)
            => WrapLoggers(LoggerManager.GetCurrentLoggers(repository));

        /// <summary>
        /// 返回assembly中的所有loggers
        /// </summary>
        /// <returns></returns>
        public static ITinyLog[] GetCurrentLoggers(Assembly assembly)
            => WrapLoggers(LoggerManager.GetCurrentLoggers(assembly));

        /// <summary>
        /// 获取指定Logger Name的logger【log4net.config中配置】
        /// </summary>
        /// <param name="name">log4net.config中配置的Logger Name</param>
        /// <returns></returns>
        public static ITinyLog GetLogger(string name)
            => GetLogger(Assembly.GetCallingAssembly(), name);

        /// <summary>
        /// 获取repository中指定Logger Name的logger
        /// </summary>
        /// <param name="repository">logger所在repository</param>
        /// <param name="name">log4net.config中配置的Logger Name</param>
        /// <returns></returns>
        public static ITinyLog GetLogger(string repository, string name)
            => WrapLogger(LoggerManager.GetLogger(repository, name));

        /// <summary>
        /// 获取assembly中指定Logger Name的logger
        /// </summary>
        /// <param name="assembly">logger所在assembly</param>
        /// <param name="name">log4net.config中配置的Logger Name</param>
        /// <returns></returns>
        public static ITinyLog GetLogger(Assembly assembly, string name)
            => WrapLogger(LoggerManager.GetLogger(assembly, name));

        /// <summary>
        /// 获取name为type.FullName的logger
        /// </summary>
        /// <param name="type">将作为logger名称的Type</param>
        /// <returns></returns>
        public static ITinyLog GetLogger(Type type)
            => GetLogger(Assembly.GetCallingAssembly(), type.FullName);

        /// <summary>
        /// 获取name为type.FullName的logger
        /// </summary>
        /// <param name="repository">type所在repository</param>
        /// <param name="type">将作为logger名称的Type</param>
        /// <returns></returns>
        public static ITinyLog GetLogger(string repository, Type type)
            => WrapLogger(LoggerManager.GetLogger(repository, type));

        /// <summary>
        /// 获取name为type.FullName的logger
        /// </summary>
        /// <param name="assembly">type所在assembly</param>
        /// <param name="type">将作为logger名称的Type</param>
        /// <returns></returns>
        public static ITinyLog GetLogger(Assembly assembly, Type type)
            => WrapLogger(LoggerManager.GetLogger(assembly, type));

        #endregion

        #region Utils
        private static ITinyLog WrapLogger(ILogger logger)
            => (ITinyLog)_wrapperMap.GetWrapper(logger);

        private static ITinyLog[] WrapLoggers(ILogger[] loggers)
        {
            ITinyLog[] results = new ITinyLog[loggers.Length];
            for (int i = 0; i < loggers.Length; i++)
            {
                results[i] = WrapLogger(loggers[i]);
            }
            return results;
        }

        private static ILoggerWrapper WrapperCreationHandler(ILogger logger)
            => new TinyLogImpl(logger);
        #endregion
    }

}
