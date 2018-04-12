using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 字符范围枚举，可使用StringUtil类获取相应的字符集合
    /// </summary>
    [Flags]
    public enum CharsScope
    {
        /// <summary>
        /// 数字
        /// </summary>
        Numbers = 1,

        /// <summary>
        /// 小写字母
        /// </summary>
        LowerLetters = 2,

        /// <summary>
        /// 大写字母
        /// </summary>
        UpperLetters = 4,

        /// <summary>
        /// 字母
        /// </summary>
        Letters = LowerLetters | UpperLetters,

        /// <summary>
        /// 数字和小写字母
        /// </summary>
        NumbersAndLowerLetters = Numbers | LowerLetters,

        /// <summary>
        /// 数字和大写字母
        /// </summary>
        NumbersAndUpperLetters = Numbers | UpperLetters,

        /// <summary>
        /// 数字字母
        /// </summary>
        NumbersAndLetters = Numbers | Letters,

        /// <summary>
        /// 常用汉字
        /// </summary>
        UsualChinese = 8,

        /// <summary>
        /// 数字，字母和汉字
        /// </summary>
        All = Numbers | Letters | UsualChinese
    }
}
