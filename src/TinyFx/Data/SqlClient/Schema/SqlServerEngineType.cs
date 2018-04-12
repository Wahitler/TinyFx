using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// SQL Server 数据库引擎类型
    /// </summary>
    public enum SqlServerEngineType
    {
        #region 字符串
        /// <summary>
        /// 固定长度的非 Unicode 字符串。最多 8,000 个字符
        /// </summary>
        Char,
        /// <summary>
        /// 可变长度的非 Unicode 字符串。最多 8,000 个字符。
        /// varchar(max) => 最多2GB字节
        /// </summary>
        VarChar,
        /// <summary>
        /// 请改用varchar(max)
        /// </summary>
        Text,
        /// <summary>
        /// 固定长度的 Unicode 字符串。最多4000个字符
        /// </summary>
        NChar,
        /// <summary>
        /// 可变长度的 Unicode 字符串。最多4000个字符
        /// nvarchar(Max) => 最多2GB字节
        /// </summary>
        NVarchar,
        /// <summary>
        /// 请改用nvarchar(max)
        /// </summary>
        NText,
        #endregion

        #region 数字
        /// <summary>
        /// 1、0 或 NULL 的 integer 数据类型
        /// </summary>
        Bit,
        /// <summary>
        /// 1字节整数。 0 到 255
        /// </summary>
        TinyInt,
        /// <summary>
        /// 2字节整数。-2^15 (-32,768) 到 2^15-1 (32,767)
        /// </summary>
        SmallInt,
        /// <summary>
        /// 4字节整数。-2^31 (-2,147,483,648) 到 2^31-1 (2,147,483,647)
        /// </summary>
        Int,
        /// <summary>
        /// 8字节整数。-2^63 (-9,223,372,036,854,775,808) 到 2^63-1 (9,223,372,036,854,775,807)
        /// </summary>
        Bigint,

        /// <summary>
        /// decimal(p[,s])固定精度(p)和小数位(s)的数值。范围为 - 10^38 +1 到 10^38 - 1
        /// 精度(p)小于等于   存储字节
        ///     9               5字节
        ///     19              9字节
        ///     28              13字节
        ///     38              17字节
        /// </summary>
        Decimal,
        /// <summary>
        /// 等同decimal
        /// </summary>
        Numeric,
        /// <summary>
        /// 货币数据类型4字节。-214,748.3648 到 214,748.3647
        /// </summary>
        SmallMoney,
        /// <summary>
        /// 货币数据类型8字节。-922,337,203,685,477.5808 到 922337203685,477.5807
        /// </summary>
        Money,

        /// <summary>
        /// 等同float(24)，4字节。-3.40E + 38 至 -1.18E - 38、0 以及 1.18E - 38 至 3.40E + 38
        /// </summary>
        Real,
        /// <summary>
        /// float(n)浮点数值,n默认53。-1.79E + 308 至 -2.23E - 308、0 以及 2.23E - 308 至 1.79E + 308
        /// n值        精度      存储大小
        /// 1-24        7位       4字节
        /// 25-53       15位      8字节
        /// </summary>
        Float,
        #endregion

        #region 二进制
        /// <summary>
        /// 固定长度的二进制数据。最多 8,000 字节
        /// </summary>
        Binary,
        /// <summary>
        /// 可变长度的二进制数据。最多 8,000 字节
        /// varbinary(Max) => 最多 2GB 字节
        /// </summary>
        VarBinary,
        /// <summary>
        /// 请改用varbinary(max)
        /// </summary>
        Image,
        #endregion

        #region 日期
        /// <summary>
        /// 仅存储时间。精度为 100 纳秒
        /// </summary>
        Time,
        /// <summary>
        /// 短日期时间，精度1分钟，4字节存储。
        /// 范围：1900-01-01 至 2079-06-06
        /// </summary>
        SmallDateTime,
        /// <summary>
        /// 仅存储日期。0001-01-01 到 9999-12-31
        /// </summary>
        Date,
        /// <summary>
        /// 日期时间，8字节。
        /// 1753-01-01 到 9999-12-31，精度为 3.33 毫秒
        /// 建议使用DateTime2
        /// </summary>
        DateTime,
        /// <summary>
        /// datetime2 [(秒的小数部分精度)]。日期时间。
        /// 日期范围：0001-01-01 到 9999-12-31
        /// 时间范围：00:00:00 到 23:59:59.9999999
        /// </summary>
        DateTime2,
        /// <summary>
        /// 与 datetime2 相同，外加时区偏移。8-10 bytes
        /// 字符串文字格式：YYYY MM DD hh: mm: [.nnnnnnn] [{+ |-} hh: mm]
        /// </summary>
        DateTimeOffset,
        #endregion

        /// <summary>
        /// 16 字节 GUID。36 个字符
        /// </summary>
        UniqueIdentifier,
        /// <summary>
        /// 时间戳
        /// </summary>
        RowVersion,
        /// <summary>
        /// 放弃使用，请改用rowversion
        /// </summary>
        Timestamp,

        /// <summary>
        /// 支持的各种数据类型的值,最大8,000 字节
        /// </summary>
        SQL_Variant,
        /// <summary>
        /// 存储 XML 格式化数据。最多 2GB
        /// </summary>
        Xml,

        FILESTREAM,
    }
}
