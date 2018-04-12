using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    /// <summary>
    /// DBO列表中选中项的类型
    /// </summary>
    public enum DBOListType
    {
        /// <summary>
        /// 数据库
        /// </summary>
        Database,
        /// <summary>
        /// 表目录
        /// </summary>
        Tables,
        /// <summary>
        ///  表
        /// </summary>
        Table,
        /// <summary>
        /// 视图目录
        /// </summary>
        Views,
        /// <summary>
        /// 视图
        /// </summary>
        View,
        /// <summary>
        /// 存储过程目录
        /// </summary>
        Procs,
        /// <summary>
        /// 存储过程
        /// </summary>
        Proc
    }
}
