using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using TinyFx.Data.Schema;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// SQL Server 数据库引擎类型与.NET类型的映射辅助类
    /// engineTypeString(+engineTypeFull) => TEngineType => TDbType
    ///                                 => DotNetType => NetTypeString
    /// </summary>
    public class SqlServerTypeMapper : IDbTypeMapper<SqlServerEngineType, SqlDbType>
    {
        //参考 https://msdn.microsoft.com/zh-cn/library/cc716729(v=vs.110).aspx
        #region IDbTypeMapper
        /// <summary>
        /// 根据 MySQL 数据库引擎原生类型推断MySqlEngineType
        /// </summary>
        /// <param name="engineTypeString">数据库字段类型字符串表示，如 tinyint</param>
        /// <param name="engineTypeFull">数据库字段字符串全描述，如 tinyint(1)</param>
        /// <returns></returns>
        public SqlServerEngineType MapEngineType(string engineTypeString, string engineTypeFull = null)
        {
            switch (engineTypeString.ToLower())
            {
                case "image": return SqlServerEngineType.Image;
                case "text": return SqlServerEngineType.Text;
                case "uniqueidentifier": return SqlServerEngineType.UniqueIdentifier;
                case "date": return SqlServerEngineType.Date;
                case "time": return SqlServerEngineType.Time;
                case "datetime2": return SqlServerEngineType.DateTime2;
                case "datetimeoffset": return SqlServerEngineType.DateTimeOffset;
                case "tinyint": return SqlServerEngineType.TinyInt;
                case "smallint": return SqlServerEngineType.SmallInt;
                case "int": return SqlServerEngineType.Int;
                case "smalldatetime": return SqlServerEngineType.SmallDateTime;
                case "real": return SqlServerEngineType.Real;
                case "money": return SqlServerEngineType.Money;
                case "datetime": return SqlServerEngineType.DateTime;
                case "float": return SqlServerEngineType.Float;
                case "sql_variant": return SqlServerEngineType.SQL_Variant;
                case "ntext": return SqlServerEngineType.NText;
                case "bit": return SqlServerEngineType.Bit;
                case "decimal": return SqlServerEngineType.Decimal;
                case "numeric": return SqlServerEngineType.Numeric;
                case "smallmoney": return SqlServerEngineType.SmallMoney;
                case "bigint": return SqlServerEngineType.Bigint;
                case "varbinary": return SqlServerEngineType.VarBinary;
                case "varchar": return SqlServerEngineType.VarChar;
                case "binary": return SqlServerEngineType.Binary;
                case "char": return SqlServerEngineType.Char;
                case "timestamp": return SqlServerEngineType.Timestamp;
                case "nvarchar": return SqlServerEngineType.NVarchar;
                case "nchar": return SqlServerEngineType.NChar;
                case "xml": return SqlServerEngineType.Xml;
            }
            throw new Exception($"未知的SQL Server数据类型: {engineTypeString}");
        }

        /// <summary>
        /// 根据 MySQL 数据库引擎类型推断MySqlDbType
        /// </summary>
        /// <param name="engineType"></param>
        /// <returns></returns>
        public SqlDbType MapDbType(SqlServerEngineType engineType)
        {
            switch (engineType)
            {
                case SqlServerEngineType.Bigint: return SqlDbType.BigInt;
                case SqlServerEngineType.Binary: return SqlDbType.VarBinary;
                case SqlServerEngineType.Bit: return SqlDbType.Bit;
                case SqlServerEngineType.Char: return SqlDbType.Char;
                case SqlServerEngineType.Date: return SqlDbType.Date;
                case SqlServerEngineType.DateTime: return SqlDbType.DateTime;
                case SqlServerEngineType.DateTime2: return SqlDbType.DateTime2;
                case SqlServerEngineType.DateTimeOffset: return SqlDbType.DateTimeOffset;
                case SqlServerEngineType.Decimal: return SqlDbType.Decimal;
                case SqlServerEngineType.FILESTREAM: return SqlDbType.VarBinary;
                case SqlServerEngineType.Float: return SqlDbType.Float;
                case SqlServerEngineType.Image: return SqlDbType.Binary;
                case SqlServerEngineType.Int: return SqlDbType.Int;
                case SqlServerEngineType.Money: return SqlDbType.Money;
                case SqlServerEngineType.NChar: return SqlDbType.NChar;
                case SqlServerEngineType.NText: return SqlDbType.NText;
                case SqlServerEngineType.Numeric: return SqlDbType.Decimal;
                case SqlServerEngineType.NVarchar: return SqlDbType.NVarChar;
                case SqlServerEngineType.Real: return SqlDbType.Real;
                case SqlServerEngineType.RowVersion: return SqlDbType.Timestamp;
                case SqlServerEngineType.SmallDateTime: return SqlDbType.DateTime;
                case SqlServerEngineType.SmallInt: return SqlDbType.SmallInt;
                case SqlServerEngineType.SmallMoney: return SqlDbType.SmallMoney;
                case SqlServerEngineType.SQL_Variant: return SqlDbType.Variant;
                case SqlServerEngineType.Text: return SqlDbType.Text;
                case SqlServerEngineType.Time: return SqlDbType.Time;
                case SqlServerEngineType.Timestamp: return SqlDbType.Timestamp;
                case SqlServerEngineType.TinyInt: return SqlDbType.TinyInt;
                case SqlServerEngineType.UniqueIdentifier: return SqlDbType.UniqueIdentifier;
                case SqlServerEngineType.VarBinary: return SqlDbType.VarBinary;
                case SqlServerEngineType.VarChar: return SqlDbType.VarChar;
                case SqlServerEngineType.Xml: return SqlDbType.Xml;
            }
            throw new Exception($"未知的SqlServerEngineType：{engineType}");
        }

        /// <summary>
        /// 根据 MySQL 数据库引擎原生类型推断MySqlDbType
        /// </summary>
        /// <param name="engineTypeString"></param>
        /// <param name="engineTypeFull"></param>
        /// <returns></returns>
        public SqlDbType MapDbType(string engineTypeString, string engineTypeFull = null)
            => MapDbType(MapEngineType(engineTypeString, engineTypeFull));

        /// <summary>
        /// 根据 DbType 类型推断MySqlDbType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlDbType MapDbType(DbType type)
        {
            switch (type)
            {
                case DbType.Boolean: return SqlDbType.Bit;
                case DbType.Byte: return SqlDbType.TinyInt;
                case DbType.Binary: return SqlDbType.VarBinary;//8000bytes限制
                case DbType.DateTime: return SqlDbType.DateTime;
                case DbType.DateTimeOffset: return SqlDbType.DateTimeOffset;//2008
                case DbType.Decimal: return SqlDbType.Decimal;
                case DbType.Double: return SqlDbType.Float;
                case DbType.Single: return SqlDbType.Real;
                case DbType.Guid: return SqlDbType.UniqueIdentifier;
                case DbType.Int16: return SqlDbType.SmallInt;
                case DbType.Int32: return SqlDbType.Int;
                case DbType.Int64: return SqlDbType.BigInt;
                case DbType.Object: return SqlDbType.Variant;
                case DbType.String: return SqlDbType.NVarChar;//4000字符
                case DbType.Time: return SqlDbType.Time;//2008
                case DbType.AnsiString: return SqlDbType.VarChar;
                case DbType.AnsiStringFixedLength: return SqlDbType.Char;
                case DbType.Currency: return SqlDbType.Money;
                case DbType.Date: return SqlDbType.Date;//2008
                case DbType.StringFixedLength: return SqlDbType.NChar;
            }
            throw new ArgumentException("不支持从此DbType类型推断成对应的SqlDbType类型。" + type.ToString(), "type");
        }

        public DbType MapSysDbType(SqlDbType type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据 MySQL 数据库引擎类型推断ORM映射的.NET类型，依据可存下，尽量少类型，不考虑无符号类型
        /// </summary>
        /// <param name="engineType"></param>
        /// <returns></returns>
        public Type MapDotNetType(SqlServerEngineType engineType)
        {
            switch (engineType)
            {
                case SqlServerEngineType.Bigint: return typeof(long);
                case SqlServerEngineType.Binary: return typeof(byte[]);
                case SqlServerEngineType.Bit: return typeof(bool);
                case SqlServerEngineType.Char: return typeof(string);
                case SqlServerEngineType.Date: return typeof(DateTime);
                case SqlServerEngineType.DateTime: return typeof(DateTime);
                case SqlServerEngineType.DateTime2: return typeof(DateTime);
                case SqlServerEngineType.DateTimeOffset: return typeof(DateTimeOffset);
                case SqlServerEngineType.Decimal: return typeof(decimal);
                case SqlServerEngineType.FILESTREAM: return typeof(byte[]);
                case SqlServerEngineType.Float: return typeof(double);
                case SqlServerEngineType.Image: return typeof(byte[]);
                case SqlServerEngineType.Int: return typeof(int);
                case SqlServerEngineType.Money: return typeof(decimal);
                case SqlServerEngineType.NChar: return typeof(string);
                case SqlServerEngineType.NText: return typeof(string);
                case SqlServerEngineType.Numeric: return typeof(decimal);
                case SqlServerEngineType.NVarchar: return typeof(string);
                case SqlServerEngineType.Real: return typeof(float);
                case SqlServerEngineType.RowVersion: return typeof(byte[]);
                case SqlServerEngineType.SmallDateTime: return typeof(DateTime);
                case SqlServerEngineType.SmallInt: return typeof(short);
                case SqlServerEngineType.SmallMoney: return typeof(decimal);
                case SqlServerEngineType.SQL_Variant: return typeof(object);
                case SqlServerEngineType.Text: return typeof(string);
                case SqlServerEngineType.Time: return typeof(TimeSpan);
                case SqlServerEngineType.Timestamp: return typeof(byte[]);
                case SqlServerEngineType.TinyInt: return typeof(byte);
                case SqlServerEngineType.UniqueIdentifier: return typeof(Guid);
                case SqlServerEngineType.VarBinary: return typeof(byte[]);
                case SqlServerEngineType.VarChar: return typeof(string);
                case SqlServerEngineType.Xml: return typeof(string); // ? xml
            }
            throw new Exception("未知的SQL Server 数据库引擎类型。");
        }

        public Type MapDotNetType(SqlDbType dbType)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Others
        /// <summary>
        /// SqlServerEngineType => DbType
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isUnicode"></param>
        /// <returns></returns>
        public DbType MapDbType(SqlServerEngineType type, bool isUnicode = true)
        {
            switch (type)
            {
                case SqlServerEngineType.Bigint: return DbType.Int64;
                case SqlServerEngineType.Binary: return DbType.Binary;
                case SqlServerEngineType.Bit: return DbType.Boolean;
                case SqlServerEngineType.Char: if (isUnicode) return DbType.String; else return DbType.AnsiStringFixedLength;
                case SqlServerEngineType.Date: return DbType.Date;
                case SqlServerEngineType.DateTime: return DbType.DateTime;
                case SqlServerEngineType.DateTime2: return DbType.DateTime2;
                case SqlServerEngineType.DateTimeOffset: return DbType.DateTimeOffset;
                case SqlServerEngineType.Decimal: return DbType.Decimal;
                case SqlServerEngineType.FILESTREAM: return DbType.Binary;
                case SqlServerEngineType.Float: return DbType.Double;
                case SqlServerEngineType.Image: return DbType.Binary;
                case SqlServerEngineType.Int: return DbType.Int32;
                case SqlServerEngineType.Money: return DbType.Decimal;
                case SqlServerEngineType.NChar: return DbType.StringFixedLength;
                case SqlServerEngineType.NText: return DbType.String;
                case SqlServerEngineType.Numeric: return DbType.Decimal;
                case SqlServerEngineType.NVarchar: return DbType.String;
                case SqlServerEngineType.Real: return DbType.Single;
                case SqlServerEngineType.RowVersion: return DbType.Binary;
                case SqlServerEngineType.SmallDateTime: return DbType.DateTime;
                case SqlServerEngineType.SmallInt: return DbType.Int16;
                case SqlServerEngineType.SmallMoney: return DbType.Decimal;
                case SqlServerEngineType.SQL_Variant: return DbType.Object;
                case SqlServerEngineType.Text: return DbType.String;
                case SqlServerEngineType.Time: return DbType.Time;
                case SqlServerEngineType.Timestamp: return DbType.Binary;
                case SqlServerEngineType.TinyInt: return DbType.Byte;
                case SqlServerEngineType.UniqueIdentifier: return DbType.Guid;
                case SqlServerEngineType.VarBinary: return DbType.Binary;
                case SqlServerEngineType.VarChar: if (isUnicode) return DbType.String; else return DbType.AnsiString;
                case SqlServerEngineType.Xml: return DbType.Xml;
            }
            throw new Exception("未知的SQL Server 数据库引擎类型。");
        }

        /// <summary>
        /// 根据引擎类型调用Reader对应方法获取值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="reader"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public object ConvertDbValue(SqlServerEngineType type, SqlDataReader reader, int i)
        {
            switch (type)
            {
                case SqlServerEngineType.Bigint: return reader.GetInt64(i);
                case SqlServerEngineType.Binary: return (byte[])reader[i]; // reader.GetBytes(i);
                case SqlServerEngineType.Bit: return reader.GetBoolean(i);
                case SqlServerEngineType.Char: return reader.GetString(i);
                case SqlServerEngineType.Date: return reader.GetDateTime(i);
                case SqlServerEngineType.DateTime: return reader.GetDateTime(i);
                case SqlServerEngineType.DateTime2: return reader.GetDateTime(i);
                case SqlServerEngineType.DateTimeOffset: return reader.GetDateTimeOffset(i);
                case SqlServerEngineType.Decimal: return reader.GetDecimal(i);
                case SqlServerEngineType.FILESTREAM: return (byte[])reader[i]; // reader.GetBytes(i);
                case SqlServerEngineType.Float: return reader.GetDouble(i);
                case SqlServerEngineType.Image: return (byte[])reader[i]; // reader.GetBytes(i);
                case SqlServerEngineType.Int: return reader.GetInt32(i);
                case SqlServerEngineType.Money: return reader.GetDecimal(i);
                case SqlServerEngineType.NChar: return reader.GetString(i);
                case SqlServerEngineType.NText: return reader.GetString(i);
                case SqlServerEngineType.Numeric: return reader.GetDecimal(i);
                case SqlServerEngineType.NVarchar: return reader.GetString(i);
                case SqlServerEngineType.Real: return reader.GetFloat(i);
                case SqlServerEngineType.RowVersion: return (byte[])reader[i]; // reader.GetBytes(i);
                case SqlServerEngineType.SmallDateTime: return reader.GetDateTime(i);
                case SqlServerEngineType.SmallInt: return reader.GetInt16(i);
                case SqlServerEngineType.SmallMoney: return reader.GetDecimal(i);
                case SqlServerEngineType.SQL_Variant: return reader.GetValue(i);
                case SqlServerEngineType.Text: return reader.GetString(i);
                case SqlServerEngineType.Time: return reader.GetDateTime(i);
                case SqlServerEngineType.Timestamp: return (byte[])reader[i]; // reader.GetBytes(i);
                case SqlServerEngineType.TinyInt: return reader.GetByte(i);
                case SqlServerEngineType.UniqueIdentifier: return reader.GetGuid(i);
                case SqlServerEngineType.VarBinary: return (byte[])reader[i]; // reader.GetBytes(i);
                case SqlServerEngineType.VarChar: return reader.GetString(i);
                case SqlServerEngineType.Xml: // 无对应方法，转换成String类型。
                    SqlXml xml = reader.GetSqlXml(i);
                    if (xml.IsNull) return null; else return xml.Value;
            }
            throw new Exception("未知的SQL Server 数据库引擎类型。");
        }

        /// <summary>
        /// 根据.NET Framework 类型推断Parameter对象的DbType类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DbType MapSysDbType(Type type)
        {
            switch (type.Name)
            {
                case "Boolean": return DbType.Boolean;
                case "Byte": return DbType.Byte;
                case "Byte[]": return DbType.Binary;
                // case "Char": return DbType.String; //没有定义
                case "DateTime": return DbType.DateTime;
                case "DateTimeOffset": return DbType.DateTimeOffset;
                case "Decimal": return DbType.Decimal;
                case "Double": return DbType.Double;
                case "Single": return DbType.Single;
                case "Guid": return DbType.Guid;
                case "Int16": return DbType.Int16;
                case "Int32": return DbType.Int32;
                case "Int64": return DbType.Int64;
                case "Object": return DbType.Object;
                case "String": return DbType.String;
                case "TimeSpan": return DbType.Time;
                case "UInt16": return DbType.UInt16;
                case "UInt32": return DbType.UInt32;
                case "UInt64": return DbType.UInt64;
            }
            throw new ArgumentException("不支持从此.NET Framework 类型推断成对应的DbType类型。" + type.Name, "type");
        }

        public SqlDbType MapDbType(Type type)
        {
            switch (type.Name)
            {
                case "Boolean": return SqlDbType.Bit;
                case "Byte": return SqlDbType.TinyInt;
                case "Byte[]": return SqlDbType.VarBinary; // 对于大于8000 bytes的数组需显示设置SqlDbType
                case "DateTime": return SqlDbType.DateTime;
                case "DateTimeOffset": return SqlDbType.DateTimeOffset; //SQL Server 2008之前不支持推断
                case "Decimal": return SqlDbType.Decimal;
                case "Double": return SqlDbType.Float;
                case "Single": return SqlDbType.Real;
                case "Guid": return SqlDbType.UniqueIdentifier;
                case "Int16": return SqlDbType.SmallInt;
                case "Int32": return SqlDbType.Int;
                case "Int64": return SqlDbType.BigInt;
                case "Object": return SqlDbType.Variant;
                case "String": return SqlDbType.Variant; // 大于4000个字符将导致转换失败需显示设置SqlDbType
                case "TimeSpan": return SqlDbType.Time; //SQL Server 2008之前不支持推断
            }
            throw new ArgumentException("不支持从此.NET Framework 类型推断成对应的SqlDbType类型。" + type.Name, "type");
        }
        #endregion
    }
}
