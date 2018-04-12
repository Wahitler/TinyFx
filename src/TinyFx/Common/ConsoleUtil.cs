using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 控制台输出辅助类
    /// </summary>
    public static class ConsoleUtil
    {
        /// <summary>
        /// 输出到控制台，可设置前景色和背景色
        /// </summary>
        /// <param name="value"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        public static void Write(string value, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            if (foregroundColor != ConsoleColor.White)
                Console.ForegroundColor = foregroundColor;
            if (backgroundColor != ConsoleColor.Black)
                Console.BackgroundColor = backgroundColor;
            Console.Write(value);
            Console.ResetColor();
        }
        /// <summary>
        /// 输出到控制台，可设置前景色和背景色
        /// </summary>
        /// <param name="value"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        public static void WriteLine(string value, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Write(value + Environment.NewLine, foregroundColor, backgroundColor);
        }
    }
}
