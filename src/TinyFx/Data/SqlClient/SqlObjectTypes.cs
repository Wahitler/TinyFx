using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// SQL Server数据库对象类型
    /// </summary>
    public enum SqlObjectType
    {
        /// <summary>
        /// AF = 聚合函数 (CLR)
        /// </summary>
        AggregateFunction,
        /// <summary>
        /// C = CHECK 约束
        /// </summary>
        CheckConstraint,
        /// <summary>
        /// D = DEFAULT（约束或独立）
        /// </summary>
        DefaultConstraint,
        /// <summary>
        /// F = FOREIGN KEY 约束
        /// </summary>
        ForeignKeyConstraint,
        /// <summary>
        /// FN = SQL 标量函数
        /// </summary>
        SqlScalarFunction,
        /// <summary>
        /// FS = 程序集 (CLR) 标量函数
        /// </summary>
        ClrScalarFunctionFS,
        /// <summary>
        /// FT = 程序集 (CLR) 表值函数
        /// </summary>
        ClrTableValuedFunction,
        /// <summary>
        /// IF = SQL 内联表值函数
        /// </summary>
        SqlInlineTableValuedFunction,
        /// <summary>
        /// IT = 内部表
        /// </summary>
        InternalTable,
        /// <summary>
        /// P = SQL 存储过程
        /// </summary>
        SqlStoredProcedure,
        /// <summary>
        /// PC = 程序集 (CLR) 存储过程
        /// </summary>
        ClrStoredProcedure,
        /// <summary>
        /// PG = 计划指南
        /// </summary>
        PlanGuide,
        /// <summary>
        /// PK = PRIMARY KEY 约束
        /// </summary>
        PrimaryKeyConstraint,
        /// <summary>
        /// R = 规则（旧式，独立）
        /// </summary>
        Rule,
        /// <summary>
        /// RF = 复制筛选过程
        /// </summary>
        ReplicationFilterProcedure,
        /// <summary>
        /// S = 系统基表
        /// </summary>
        SystemTable,
        /// <summary>
        /// SN = 同义词
        /// </summary>
        Synonym,
        /// <summary>
        /// SQ = 服务队列
        /// </summary>
        ServiceQueue,
        /// <summary>
        /// TA = 程序集 (CLR) DML 触发器
        /// </summary>
        ClrTrigger,
        /// <summary>
        /// TF = SQL 表值函数
        /// </summary>
        SqlTableValuedFunction,
        /// <summary>
        /// TR = SQL DML 触发器
        /// </summary>
        SqlTrigger,
        /// <summary>
        /// TT = 表类型
        /// </summary>
        TableType,
        /// <summary>
        /// U = 表（用户定义类型）
        /// </summary>
        UserTable,
        /// <summary>
        /// UQ = UNIQUE 约束
        /// </summary>
        UniqueConstraint,
        /// <summary>
        /// V = 视图
        /// </summary>
        View,
        /// <summary>
        /// X = 扩展存储过程
        /// </summary>
        ExtendedStoredProcedure
    }
}
