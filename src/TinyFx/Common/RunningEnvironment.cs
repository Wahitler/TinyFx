using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx
{
    /// <summary>
    /// 程序运行环境
    /// </summary>
    public enum RunningEnvironment
    {
        /// <summary>
        /// 未知环境
        /// </summary>
        Unknown,
        /// <summary>
        /// 研发环境
        /// </summary>
        Development,
        /// <summary>
        /// 测试环境
        /// </summary>
        Test,
        /// <summary>
        /// 仿真环境
        /// </summary>
        Simulation,
        /// <summary>
        /// 线上环境
        /// </summary>
        Online
    }
}
