using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;

namespace TinyFx
{
    /// <summary>
    /// 提供TinyFx辅助方法
    /// </summary>
    public static partial class TinyFxUtil
    {
        private static object _lock = new object();

        #region Random
        /// <summary>
        /// 获得随机数生成器
        /// 以Guid的哈希值最为种子值，避免大并发随机数重复的问题
        /// </summary>
        /// <returns></returns>
        public static Random GetRandom() 
            => new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// 返回一个定义范围的随机数
        /// </summary>
        /// <param name="minValue">最小值(包含下限)</param>
        /// <param name="maxValue">最大值(不包含上限)</param>
        /// <returns></returns>
        public static int GetRandomNext(int minValue, int maxValue) 
            => GetRandom().Next(minValue, maxValue);

        /// <summary>
        /// 返回一个小于指定最大值的非负随机数
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandomNext(int maxValue) 
            => GetRandom().Next(maxValue);

        /// <summary>
        /// 返回非负随机数
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNext() 
            => GetRandom().Next();
        #endregion

        #region Other
        /// <summary>
        /// 判断是否为可空类型
        /// </summary>
        /// <param name="type">类型信息</param>
        /// <returns></returns>
        public static bool IsNullableType(this Type type)
        {
            if (type == null)
                throw new ArgumentException("Type类型不能为NULL。");
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
            //return type.FullName.StartsWith("System.Nullable`");
        }

        /// <summary>
        /// 多次尝试执行代理方法，如果仍然失败，则抛出异常
        /// </summary>
        /// <param name="method">需执行的方法</param>
        /// <param name="tryCount">重试次数</param>
        /// <param name="interval">重试间隔ms</param>
        /// <param name="args">执行方法需要的参数</param>
        /// <returns></returns>
        public static object TryDo(this Delegate method, int tryCount, int interval, params object[] args)
            => TryDo(method, null, tryCount, interval, args);

        /// <summary>
        /// 多次尝试执行代理方法，如果仍然失败，则抛出异常
        /// </summary>
        /// <param name="method">需执行的方法</param>
        /// <param name="calcback">出现异常时回调方法</param>
        /// <param name="tryCount">尝试次数</param>
        /// <param name="interval">尝试执行间隔，毫秒</param>
        /// <param name="args">方法执行参数</param>
        /// <returns></returns>
        public static object TryDo(this Delegate method, Action<int> calcback, int tryCount, int interval, params object[] args)
        {
            object ret = null;
            for (int i = 0; i < tryCount; i++)
            {
                try
                {
                    ret = method.DynamicInvoke(args);
                    break;
                }
                catch (Exception ex)
                {
                    calcback?.Invoke(i);
                    if (i == tryCount - 1)
                    {
                        ex.AddUserData($"调用方法{method.Method.Name}并重试{tryCount}次仍错误。");
                        throw;
                    }
                    Thread.Sleep(interval);
                }
            }
            return ret;
        }

        /// <summary>
        /// 计算分页的页数
        /// </summary>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public static long GetPageCount(long totalRecord, long pageSize)
            => (totalRecord % pageSize == 0) ? totalRecord / pageSize : totalRecord / pageSize + 1;
        #endregion

        /// <summary>
        /// 获取绝对路径。支持web相对路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetAbsolutePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path参数不能为空。");
            string ret = path;
            // 绝对路径
            if (Path.IsPathRooted(path))
                return path;
            if (path.StartsWith("~/"))
                return Path.Combine(AppContext.BaseDirectory, path.TrimStart("~/").Replace('/', '\\'));
            if (path.StartsWith("/"))
                return Path.Combine(AppContext.BaseDirectory, path.Replace('/', '\\'));
            return Path.Combine(AppContext.BaseDirectory, path.Replace('/', '\\'));
            //return Path.Combine(Environment.CurrentDirectory, path);
        }

        /// <summary>
        /// 获取应用程序Assembly所在目录,Web获取bin，其他获取执行程序当前目录
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyDirectory(bool isWebApp = false)
        {
            //string ret = Environment.CurrentDirectory;
            string ret = AppContext.BaseDirectory;
            if (isWebApp)
                ret = Path.Combine(ret, "bin");
#if NET_4

            if (!string.IsNullOrEmpty(HttpRuntime.BinDirectory))
                ret = HttpRuntime.BinDirectory;
#endif
            return ret;
        }

        /// <summary>
        /// 获取应用程序目录，web获取根目录，应用程序获取入口目录
        /// </summary>
        /// <returns></returns>
        public static string GetAppDirectory()
        {
            return AppContext.BaseDirectory;
        }

        /// <summary>
        /// 是否是Windows系统
        /// </summary>
        /// <returns></returns>
        public static bool IsWindowsOS
            => Environment.OSVersion.Platform == PlatformID.Win32NT || Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.Win32S;

    }
}
