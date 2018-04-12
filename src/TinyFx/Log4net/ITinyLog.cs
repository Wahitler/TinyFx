using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Log4net
{
    /// <summary>
    /// log4net封装ILog
    /// </summary>
    public interface ITinyLog : ILog
    {
        /// <summary>
        /// 该方法的声明类型是该调用的日志记录系统中的堆栈边界
        /// </summary>
        Type CallerType { get; set; }

        /// <summary>
        /// 记录Debug级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Debug(object message, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Debug级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Debug(object message, Exception exception, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Error级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Error(object message, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Error级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Error(object message, Exception exception, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Fatal级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Fatal(object message, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Fatal级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Fatal(object message, Exception exception, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Info级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Info(object message, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Info级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Info(object message, Exception exception, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Warn级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Warn(object message, params (string key, object value)[] properties);

        /// <summary>
        /// 记录Warn级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        void Warn(object message, Exception exception, params (string key, object value)[] properties);
    }
}
