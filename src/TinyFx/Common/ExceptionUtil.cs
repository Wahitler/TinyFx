using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Diagnostics;
using TinyFx.Collections;

namespace TinyFx
{
    /// <summary>
    /// 异常辅助类
    /// </summary>
    public static class ExceptionUtil
    {
        #region UserData
        /// <summary>
        /// 异常添加用户自定义数据，key默认使用exp.Data的当前索引+1
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="data">用户数据</param>
        public static void AddUserData(this Exception ex, object data) 
            => ex.Data.Add(ex.Data.Count, data);

        /// <summary>
        /// 异常添加用户自定义数据，key默认使用exp.Data的当前索引+1
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="sort">用户数据类型</param>
        /// <param name="content">用户数据内容</param>
        /// <param name="args">string.Format(content, args)</param>
        public static void AddUserData(this Exception ex, string sort, string content, params object[] args)
        {
            content = (args != null&& args.Length > 0) ? string.Format(content, args) : content;
            AddUserData(ex, $"{sort} : {content}");
        }

        /// <summary>
        /// 序列化异常用户数据Exception.Data
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string SerializeUserData(Exception ex)
        {
            var data = new SerializableDictionary<object, object>();
            data.Add(ex.Data);
            return SerializerUtil.SerializeXml(data);
        }

        /// <summary>
        /// 反序列化异常用户数据
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static SerializableDictionary<object, object> DeserializeUserData(string xml)
            => SerializerUtil.DeserializeXml<SerializableDictionary<object, object>>(xml);
        #endregion // UserData

        #region ExceptionStackEntry
        /// <summary>
        /// 分析Exception.StackTrace获得类型化信息
        /// </summary>
        /// <param name="stackTrace"></param>
        /// <returns></returns>
        public static IEnumerable<ExceptionStackEntry> GetStackEntries(string stackTrace)
        {
            string[] lines = stackTrace.Split(new string[] { " 在 ", " at " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string currLine = line.Trim();
                if (string.IsNullOrEmpty(currLine)) continue;
                string[] entries = currLine.Split(new string[] { " 位置 ", ":行号 ", " in ", ":line " }, StringSplitOptions.RemoveEmptyEntries);
                if (entries.Length != 3) continue;

                yield return new ExceptionStackEntry()
                {
                    MethodName = entries[0].Trim(),
                    FileName = entries[1].Trim(),
                    LineNumber = int.Parse(entries[2].Trim())
                };
            }
        }

        /// <summary>
        /// 获取异常的堆栈信息集合
        /// </summary>
        /// <param name="ex">抛出的异常</param>
        /// <returns></returns>
        public static IEnumerable<ExceptionStackEntry> GetStackEntries(Exception ex)
        {
            foreach (StackFrame frame in new StackTrace(ex, true).GetFrames())
            {
                yield return GetStackEntry(frame);
            }
        }

        /// <summary>
        /// 获取异常的堆栈信息
        /// </summary>
        /// <param name="frame">堆栈中的一个函数调用</param>
        /// <returns></returns>
        internal static ExceptionStackEntry GetStackEntry(StackFrame frame)
        {
            System.Reflection.MethodBase method = frame.GetMethod();
            ExceptionStackEntry ret = new ExceptionStackEntry
            {
                AssemblyName = method.Module.Name,
                ClassName = (method.ReflectedType != null) ? method.ReflectedType.FullName : null,
                MethodName = method.ToString(),
                FileName = frame.GetFileName(),
                LineNumber = frame.GetFileLineNumber(),
                IsGlobalAssembly = method.Module.Assembly.GlobalAssemblyCache
            };
            return ret;
        }

        #endregion

        /// <summary>
        /// 获得第一个抛出的异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns></returns>
        public static Exception GetFirstException(Exception ex)
        {
            Exception ret = ex;
            while (ret.InnerException != null)
            {
                ret = ret.InnerException;
            }
            return ret;
        }
    }
}
