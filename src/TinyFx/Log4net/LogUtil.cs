using System;
using System.Collections.Generic;
using System.Text;
using log4net.Config;
using log4net;
using TinyFx.Configuration;

namespace TinyFx.Log4net
{
    /// <summary>
    /// 使用配置中的默认logger name来保存日志
    /// 在root配置节中定义的默认配置
    /// </summary>
    public static class LogUtil
    {
        private static string _defaultLogger = null;
        /// <summary>
        /// 获取默认Logger
        /// </summary>
        /// <returns></returns>
        public static ITinyLog GetDefaultLogger()
        {
            if (_defaultLogger == null)
            {
                var config = TinyFxConfigManager.GetConfig<ProjectConfig>();
                _defaultLogger = (config != null && !string.IsNullOrEmpty(config.Logger)) ? config.Logger : string.Empty;
            }
            return !string.IsNullOrEmpty(_defaultLogger) ? TinyLogManager.GetLogger(_defaultLogger) : null;
        }

        /// <summary>
        /// 获取指定名称的logger
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITinyLog GetLogger(string name)
            => string.IsNullOrEmpty(name) ? GetDefaultLogger() : TinyLogManager.GetLogger(name);

        /// <summary>
        /// 记录Debug日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Debug(object message)
            => GetDefaultLogger()?.Debug(message);

        /// <summary>
        /// 记录Debug日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Debug(object message, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Debug(message, properties);

        /// <summary>
        /// 记录Debug日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        public static void Debug(object message, Exception exception)
            => GetDefaultLogger()?.Debug(message, exception);

        /// <summary>
        /// 记录Debug日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Debug(object message, Exception exception, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Debug(message, exception, properties);

        /// <summary>
        /// 记录Error日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Error(object message)
            => GetDefaultLogger()?.Error(message);

        /// <summary>
        /// 记录Error日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Error(object message, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Error(message, properties);

        /// <summary>
        /// 记录Error日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        public static void Error(object message, Exception exception)
            => GetDefaultLogger()?.Error(message, exception);

        /// <summary>
        /// 记录Error日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Error(object message, Exception exception, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Error(message, exception, properties);

        /// <summary>
        /// 记录Fatal日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Fatal(object message)
            => GetDefaultLogger()?.Fatal(message);

        /// <summary>
        /// 记录Fatal日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Fatal(object message, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Fatal(message, properties);

        /// <summary>
        /// 记录Fatal日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        public static void Fatal(object message, Exception exception)
            => GetDefaultLogger()?.Fatal(message, exception);

        /// <summary>
        /// 记录Fatal日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Fatal(object message, Exception exception, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Fatal(message, exception, properties);

        /// <summary>
        /// 记录Info日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Info(object message)
            => GetDefaultLogger()?.Info(message);

        /// <summary>
        /// 记录Info日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Info(object message, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Info(message, properties);

        /// <summary>
        /// 记录Info日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        public static void Info(object message, Exception exception)
            => GetDefaultLogger()?.Info(message, exception);

        /// <summary>
        /// 记录Info日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Info(object message, Exception exception, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Info(message, exception, properties);

        /// <summary>
        /// 记录Warn日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Warn(object message)
            => GetDefaultLogger()?.Warn(message);

        /// <summary>
        /// 记录Warn日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Warn(object message, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Warn(message, properties);

        /// <summary>
        /// 记录Warn日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        public static void Warn(object message, Exception exception)
            => GetDefaultLogger()?.Warn(message, exception);

        /// <summary>
        /// 记录Warn日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public static void Warn(object message, Exception exception, params (string key, object value)[] properties)
            => GetDefaultLogger()?.Warn(message, exception, properties);
    }
}
