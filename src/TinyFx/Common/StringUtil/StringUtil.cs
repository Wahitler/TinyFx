﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TinyFx
{
    /// <summary>
    /// 字符串操作静态辅助类
    /// </summary>
    public static partial class StringUtil
    {
        private static readonly object _lock = new object();

        /// <summary>
        /// 获取不包含'-'的GUID字符串
        /// </summary>
        /// <param name="removeSymbol">是否替换间隔符号-</param>
        /// <returns></returns>
        public static string GetGuidString(bool removeSymbol = true)
        {
            var ret = Guid.NewGuid().ToString();
            return removeSymbol ? ret.Replace("-", "") : ret;
        }

        /// <summary>
        /// 编辑距离（Levenshtein Distance），计算字符串相似度
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="target">目标字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static int LevenshteinDistance(string source, string target, bool ignoreCase = true)
        {
            int n = source.Length;
            int m = target.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0) return m;
            if (m == 0) return n;

            if (ignoreCase)
            {
                source = source.ToLower();
                target = target.ToLower();
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++) { }

            for (int j = 0; j <= m; d[0, j] = j++) { }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        /// <summary>
        /// 使用camel命名法
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CamelCase(string name) 
            => char.ToLower(name[0]) + name.Substring(1);

        /// <summary>
        /// 使用Pascal命名法
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string PascalCase(string name) 
            => char.ToUpper(name[0]) + name.Substring(1);

        /// <summary>
        /// 将字符串按NewLine进行Split
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string[] SplitNewLine(this string src)
            => src.Trim().Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
        
        // C#保留字
        private static Regex CSharpReserved = new Regex("^(ABSTRACT|AS|BASE|BOOL|BREAK|BYTE|CASE|CATCH|CHAR|CHECKED|CLASS|CONST|CONTINUE|DECIMAL|DEFAULT|DELEGATE|DO|DOUBLE|ELSE|ENUM|EVENT|EXPLICIT|EXTERN|FALSE|FINALLY|FIXED|FLOAT|FOR|FOREACH|GET|GOTO|IF|IMPLICIT|IN|INT|INTERFACE|INTERNAL|IS|LOCK|LONG|NAMESPACE|NEW|NULL|OBJECT|OPERATOR|OUT|OVERRIDE|PARAMS|PARTIAL|PRIVATE|PROTECTED|PUBLIC|READONLY|REF|RETURN|SBYTE|SEALED|SET|SHORT|SIZEOF|STACKALLOC|STATIC|STRING|STRUCT|SWITCH|THIS|THROW|TRUE|TRY|TYPEOF|UINT|ULONG|UNCHECKED|UNSAFE|USHORT|USING|VALUE|VIRTUAL|VOID|VOLATILE|WHERE|WHILE|YIELD)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// 是否是.NET保留字
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsCSharpReserved(this string src) 
            => CSharpReserved.IsMatch(src);

        /// <summary>
        /// 获取连续TAB输入字符串
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Tab(int n) 
            => (n == 0) ? string.Empty : new string('\t', n);

        /// <summary>
        /// 获取字符串第一行，没有返回string.Empty
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string GetFirstLine(string src)
        {
            var strs = SplitNewLine(src);
            return (strs != null && strs.Length > 0) ? strs[0] : string.Empty;
        }

        /// <summary>
        /// 查找字符串中指定字符匹配索引（跳过指定次数）
        /// 如：IndexOf("192.12.0.0", '.', 1); 返回6
        /// </summary>
        /// <param name="str"></param>
        /// <param name="value"></param>
        /// <param name="skipNum"></param>
        /// <returns></returns>
        public static int IndexOf(string str, char value, int skipNum)
        {
            int currSkip = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == value)
                {
                    if (currSkip == skipNum)
                        return i;
                    currSkip++;
                }
            }
            return -1;
        }
    }
}
