﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 枚举类型的值的描述信息
    /// </summary>
    public class EnumItemInfo
    {
        /// <summary>
        /// 枚举int值
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 枚举描述，通过DescriptionAttribute定义的描述
        /// </summary>
        public string Description { get; set; }
    }
}
