using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 字符串操作静态辅助类
    /// </summary>
    public static partial class StringUtil
    {
        #region 字符串和16进制字符串表示互转
        /// <summary>
        /// 将字符串转换成为16进制字符串
        /// </summary>
        /// <param name="str">要转换成16进制表示的字符串</param>
        /// <param name="encode">字符编码</param>
        /// <returns></returns>
        public static string StrToHex(this string str, Encoding encode = null)
        {
            byte[] bytes = (encode ?? Encoding.UTF8).GetBytes(str);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
        
        /// <summary>
        /// 字节数组转换成为16进制字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string BytesToHex(byte[] input)
            => BitConverter.ToString(input).Replace("-", "");

        /// <summary>
        /// 将16进制字符串转换成为字节数组，如果要将byte[]转换成hex字符串，可使用BitConverter.ToString()实现。
        /// </summary>
        /// <param name="hex">要转换成字节数组的16进制字符串</param>
        /// <returns></returns>
        public static byte[] HexToBytes(this string hex)
        {
            if (hex.Length == 0)
                return new byte[] { 0 };
            if (hex.Length % 2 == 1)
                hex = "0" + hex;
            byte[] ret = new byte[hex.Length / 2];
            for (int i = 0; i < ret.Length; i++)
                ret[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            return ret;
        }

        /// <summary>
        /// 将16进制字符串转换成为字符编码对应的字符串
        /// </summary>
        /// <param name="hex">16进制表示的字符串</param>
        /// <param name="encode">字符编码</param>
        /// <returns></returns>
        public static string HexToStr(this string hex, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;
            return encode.GetString(HexToBytes(hex));
        }
        #endregion

        #region 10进制和其他进制转换
        /// <summary>
        /// 将十进制整数转换为指定进位制的字符串表示，如进位制位是2，8，10，16等，最好使用Convert.ToString(value, toBase)方法
        /// </summary>
        /// <param name="num">十进制整数</param>
        /// <param name="radix">进位制，如：36,62</param>
        /// <returns></returns>
        public static string RadixToString(ulong num, uint radix)
        {
            if (num == 0) return "0";
            string ret = string.Empty;
            while (num > 0)
            {
                ret = NumeralRadixChars[num % radix] + ret;
                num = num / radix;
            }
            return ret;
        }

        /// <summary>
        /// 将十进制整数转换为指定进位制的字符串表示，如进位制位是2，8，10，16等
        /// </summary>
        /// <param name="num">十进制数</param>
        /// <param name="radix">进位制，如：36,62</param>
        /// <returns></returns>
        public static string RadixToString(long num, int radix)
        {
            var ret = RadixToString((ulong)Math.Abs(num), (uint)radix);
            return (num < 0) ? '-' + ret : ret;
        }

        /// <summary>
        /// 将指定进位制的字符串表示转换为十进制整数，如进位制位是2，8，10，16等，最好使用Convert.ToXXX(string, fromBase)方法
        /// </summary>
        /// <param name="value">指定进位制的字符串表示</param>
        /// <param name="radix">进位制，如：36,62</param>
        /// <returns></returns>
        public static ulong StringToRadix(this string value, uint radix)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            ulong ret = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char chr = value[i];
                ret += (uint)NumeralRadixCache[chr] * (ulong)Math.Pow(radix, value.Length - i - 1);
            }
            return ret;
        }

        /// <summary>
        /// 将指定进位制的字符串表示转换为十进制整数，如进位制位是2，8，10，16等
        /// </summary>
        /// <param name="value">指定进位制的字符串表示</param>
        /// <param name="radix">进位制，如：36,62</param>
        /// <returns></returns>
        public static long StringToRadix(this string value, int radix)
        {
            bool negative = (value[0] == '-');
            string valueString = negative ? value.Substring(1) : value;
            var ret = StringToRadix(valueString, (uint)radix);
            return negative ? ((long)ret * -1) : (long)ret;
        }

        /// <summary>
        /// 进位制间相互转换（支持2,8,10,16进制）
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="fromBase">源进制， 只能是2，8，10，16</param>
        /// <param name="toBase">目标进制， 只能是2，8，10，16</param>
        /// <returns></returns>
        public static string ConvertNumberBase(string source, int fromBase, int toBase)
            => RadixToString(StringToRadix(source, (uint)fromBase), (uint)toBase);
        #endregion

#if NET_4
        /// <summary>
        /// 繁体转换为简体中文
        /// </summary>
        /// <param name="input">繁体中文</param>
        /// <returns></returns>
        public static string ToSimplifiedChinese(string input)
        {
            return Strings.StrConv(input, VbStrConv.SimplifiedChinese);
        }

        /// <summary>
        /// 简体转换为繁体中文
        /// </summary>
        /// <param name="input">简体中文</param>
        /// <returns></returns>
        public static string ToTraditionalChinese(string input)
        {
            return Strings.StrConv(input, VbStrConv.TraditionalChinese);
        }

        /// <summary>
        ///  将字符串中的宽（双字节）字符转换为窄（单字节）字符。应用于亚洲区域设置。
        /// </summary>
        /// <param name="input">字符串输入</param>
        /// <returns></returns>
        public static string ToNarrow(string input)
        {
            return Strings.StrConv(input, VbStrConv.Narrow);
        }

        /// <summary>
        /// 将字符串中的窄（单字节）字符转换为宽（双字节）字符。应用于亚洲区域设置。
        /// </summary>
        /// <param name="input">字符串输入</param>
        /// <returns></returns>
        public static string ToWide(string input)
        {
            return Strings.StrConv(input, VbStrConv.Wide);
        }
#endif

        #region Base64转换
        /// <summary>
        /// 将字符串转换成Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase64String(string str, Encoding encoding = null)
            => Convert.ToBase64String((encoding ?? Encoding.UTF8).GetBytes(str));
        /// <summary>
        /// 将Base64编码的字符串还原
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase64String(string str, Encoding encoding = null)
            => (encoding ?? Encoding.UTF8).GetString(Convert.FromBase64String(str));
#endregion
    }
}
