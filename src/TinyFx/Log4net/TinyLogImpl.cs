using log4net.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TinyFx.Log4net
{
    /// <summary>
    /// TinyFx的Log类
    /// 记录日志时properties参数说明：
    ///     配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取
    ///     例如：Debug("日志记录信息", ("ID", 1), ("NAME", "johny"));
    /// </summary>
    public class TinyLogImpl : LogImpl, ITinyLog
    {
        /// <summary>
        /// 该方法的声明类型是该调用的日志记录系统中的堆栈边界
        /// </summary>
        public Type CallerType { get; set; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        public TinyLogImpl(ILogger logger)
            : base(logger) { }

        /// <summary>
        /// 记录Debug级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Debug(object message, params (string key, object value)[] properties)
            => Debug(message, null, properties);

        /// <summary>
        /// 记录Debug级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Debug(object message, Exception exception, params (string key, object value)[] properties)
        {
            if (IsDebugEnabled) DoLog(Level.Debug, message, exception, properties);
        }

        /// <summary>
        /// 记录Error级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Error(object message, params (string key, object value)[] properties)
            => Error(message, null, properties);

        /// <summary>
        /// 记录Error级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Error(object message, Exception exception, params (string key, object value)[] properties)
        {
            if (IsErrorEnabled) DoLog(Level.Error, message, exception, properties);
        }

        /// <summary>
        /// 记录Fatal级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Fatal(object message, params (string key, object value)[] properties)
            => Fatal(message, null, properties);

        /// <summary>
        /// 记录Fatal级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Fatal(object message, Exception exception, params (string key, object value)[] properties)
        {
            if (IsFatalEnabled) DoLog(Level.Fatal, message, exception, properties);
        }

        /// <summary>
        /// 记录Info级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Info(object message, params (string key, object value)[] properties)
            => Info(message, null, properties);

        /// <summary>
        /// 记录Info级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Info(object message, Exception exception, params (string key, object value)[] properties)
        {
            if (IsInfoEnabled) DoLog(Level.Info, message, exception, properties);
        }

        /// <summary>
        /// 记录Warn级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Warn(object message, params (string key, object value)[] properties)
            => Warn(message, null, properties);

        /// <summary>
        /// 记录Warn级别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        /// <param name="properties">属性信息集合【配置中可通过log4net.Layout.PatternLayout的%property{key}格式获取】</param>
        public void Warn(object message, Exception exception, params (string key, object value)[] properties)
        {
            if (IsWarnEnabled) DoLog(Level.Warn, message, exception, properties);
        }

        private void DoLog(Level level, object message, Exception ex, params (string key, object value)[] properties)
        {
            try
            {
                CallerType = CallerType ?? MethodBase.GetCurrentMethod().DeclaringType;
                LoggingEvent loggingEvent = new LoggingEvent(CallerType, Logger.Repository, Logger.Name, level, message, ex);
                if (properties != null && properties.Length > 0)
                {
                    foreach (var (key, value) in properties)
                    {
                        loggingEvent.Properties[key] = value;
                    }
                }
#if NET_4
            var frames = loggingEvent.LocationInformation.StackFrames;
            if (frames.Length > 0)
            {
                var location = frames[frames.Length - 1];
                loggingEvent.Properties["Location"] = $"{location.ClassName}.{location.Method.Name}(:{location.LineNumber})";
            }
#endif
                // 添加自定义Log Properties
                TinyLogProperties.AddTinyLogProperties(loggingEvent.Properties, ex);
                Logger.Log(loggingEvent);
            }
            catch { }
        }
    }
}
