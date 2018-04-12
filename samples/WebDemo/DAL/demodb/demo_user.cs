/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0 by JiangHui 2016-06-20
 * 文档生成时间：2018-04-11 11: 25:09
 ******************************************************/
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using TinyFx;
using TinyFx.Data;
using TinyFx.Data.MySqlClient;
using MySql.Data.MySqlClient;

namespace WebDemo.DAL.demodb
{
	#region EO
	/// <summary>
	/// 用户表
	/// 【表 demo_user 的实体类】
	/// </summary>
	[Serializable]
	public class Demo_userEO : IRowMapper<Demo_userEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Demo_userEO()
		{
			this.FBit = 1;
			this.FTinyInt = 127;
			this.FTinyInt_Unsigned = 255;
			this.F_Boolean = true;
			this.FBool_TinyInt = false;
			this.FSmallInt = -32768;
			this.FSmallInt_Unsigned = 65535;
			this.FMediumInt = -8388608;
			this.FInt = -2147483648;
			this.FInt_Unsigned = 4294967295;
			this.FBigInt = -9223372036854775808;
			this.FFloat = 12.3457f;
			this.FDouble = 123456789.1234567d;
			this.FTimestamp = DateTime.Now;
			this.FDecimal = 123m;
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected long _originalUserID;
		/// <summary>
		/// 【数据库中的原始主键 UserID 值的副本，用于主键值更新】
		/// </summary>
		public long OriginalUserID
		{
			get { return _originalUserID; }
			set { HasOriginal = true; _originalUserID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "UserID", UserID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 用户编码（自增字段）
		/// 【主键 bigint(20)】
		/// </summary>
		public long UserID { get; set; }
		/// <summary>
		/// 类别编码
		/// 【外键 varchar(10)】
		/// </summary>
		public string ClassID { get; set; }
		/// <summary>
		/// 字段1
		///                      多行1
		///                      多行2
		/// 【字段 bit(1)】
		/// </summary>
		public int FBit { get; set; }
		/// <summary>
		/// 
		/// 【字段 bit(64)】
		/// </summary>
		public int? FBit_Max { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinyint(4)】
		/// </summary>
		public int FTinyInt { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinyint(3) unsigned】
		/// </summary>
		public int? FTinyInt_Unsigned { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool? FBool { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool F_Boolean { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool? FBool_TinyInt { get; set; }
		/// <summary>
		/// 
		/// 【字段 smallint(6)】
		/// </summary>
		public int FSmallInt { get; set; }
		/// <summary>
		/// 
		/// 【字段 smallint(5) unsigned】
		/// </summary>
		public int? FSmallInt_Unsigned { get; set; }
		/// <summary>
		/// 
		/// 【字段 mediumint(9)】
		/// </summary>
		public int FMediumInt { get; set; }
		/// <summary>
		/// 
		/// 【字段 mediumint(8) unsigned】
		/// </summary>
		public int? FMediumInt_Unsigned { get; set; }
		/// <summary>
		/// 
		/// 【字段 int(11)】
		/// </summary>
		public int FInt { get; set; }
		/// <summary>
		/// 
		/// 【字段 int(10) unsigned】
		/// </summary>
		public long? FInt_Unsigned { get; set; }
		/// <summary>
		/// 
		/// 【字段 int(11)】
		/// </summary>
		public int? F_Integer { get; set; }
		/// <summary>
		/// 
		/// 【字段 bigint(20)】
		/// </summary>
		public long FBigInt { get; set; }
		/// <summary>
		/// 
		/// 【字段 bigint(20) unsigned】
		/// </summary>
		public ulong? FBigInt_Unsigned { get; set; }
		/// <summary>
		/// 
		/// 【字段 float】
		/// </summary>
		public float FFloat { get; set; }
		/// <summary>
		/// 
		/// 【字段 float(7,4) unsigned】
		/// </summary>
		public float? FFloat_Max { get; set; }
		/// <summary>
		/// 
		/// 【字段 double】
		/// </summary>
		public double FDouble { get; set; }
		/// <summary>
		/// 
		/// 【字段 double(15,4) unsigned】
		/// </summary>
		public double? FDouble_Max { get; set; }
		/// <summary>
		/// 
		/// 【字段 double】
		/// </summary>
		public double? F_Real { get; set; }
		/// <summary>
		/// 
		/// 【字段 double unsigned】
		/// </summary>
		public double? F_Double_Precision { get; set; }
		/// <summary>
		/// 
		/// 【字段 year(4)】
		/// </summary>
		public int? FYear { get; set; }
		/// <summary>
		/// 
		/// 【字段 date】
		/// </summary>
		public DateTime? FDate { get; set; }
		/// <summary>
		/// 
		/// 【字段 time】
		/// </summary>
		public TimeSpan? FTime { get; set; }
		/// <summary>
		/// 
		/// 【字段 timestamp】
		/// </summary>
		public DateTime FTimestamp { get; set; }
		/// <summary>
		/// 
		/// 【字段 datetime】
		/// </summary>
		public DateTime? FDateTime { get; set; }
		/// <summary>
		/// 
		/// 【字段 char(4)】
		/// </summary>
		public string FChar { get; set; }
		/// <summary>
		/// 
		/// 【字段 varchar(255)】
		/// </summary>
		public string FVarChar { get; set; }
		/// <summary>
		/// 
		/// 【字段 binary(2)】
		/// </summary>
		public byte[] FBinary { get; set; }
		/// <summary>
		/// 
		/// 【字段 varbinary(2)】
		/// </summary>
		public byte[] FVarBinary { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinytext】
		/// </summary>
		public string FTinyText { get; set; }
		/// <summary>
		/// 
		/// 【字段 text】
		/// </summary>
		public string FText { get; set; }
		/// <summary>
		/// 
		/// 【字段 mediumtext】
		/// </summary>
		public string FMediumText { get; set; }
		/// <summary>
		/// 
		/// 【字段 longtext】
		/// </summary>
		public string FLongText { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinyblob】
		/// </summary>
		public byte[] FTinyBlob { get; set; }
		/// <summary>
		/// 
		/// 【字段 blob】
		/// </summary>
		public byte[] FBlob { get; set; }
		/// <summary>
		/// 
		/// 【字段 mediumblob】
		/// </summary>
		public byte[] FMediumBlob { get; set; }
		/// <summary>
		/// 
		/// 【字段 longblob】
		/// </summary>
		public byte[] FLongBlob { get; set; }
		/// <summary>
		/// 
		/// 【字段 enum('m','f')】
		/// </summary>
		public string FEnum { get; set; }
		/// <summary>
		/// 
		/// 【字段 set('one','two')】
		/// </summary>
		public string FSet { get; set; }
		/// <summary>
		/// 
		/// 【字段 decimal(10,0)】
		/// </summary>
		public decimal FDecimal { get; set; }
		/// <summary>
		/// 
		/// 【字段 decimal(65,30) unsigned】
		/// </summary>
		public decimal? FDecimal_Max { get; set; }
		/// <summary>
		/// 
		/// 【字段 decimal(10,0)】
		/// </summary>
		public decimal? F_Numeric { get; set; }
		/// <summary>
		/// 
		/// 【字段 decimal(10,0)】
		/// </summary>
		public decimal? F_Dec { get; set; }
		/// <summary>
		/// 
		/// 【字段 decimal(10,0)】
		/// </summary>
		public decimal? F_Fixed { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Demo_userEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Demo_userEO MapDataReader(IDataReader reader)
		{
		    Demo_userEO ret = new Demo_userEO();
			ret.UserID = reader.ToInt64("UserID");
			ret.OriginalUserID = ret.UserID;
			ret.ClassID = reader.ToString("ClassID");
			ret.FBit = reader.ToInt32("FBit");
			ret.FBit_Max = reader.ToInt32N("FBit_Max");
			ret.FTinyInt = reader.ToInt32("FTinyInt");
			ret.FTinyInt_Unsigned = reader.ToInt32N("FTinyInt_Unsigned");
			ret.FBool = reader.ToBooleanN("FBool");
			ret.F_Boolean = reader.ToBoolean("F_Boolean");
			ret.FBool_TinyInt = reader.ToBooleanN("FBool_TinyInt");
			ret.FSmallInt = reader.ToInt32("FSmallInt");
			ret.FSmallInt_Unsigned = reader.ToInt32N("FSmallInt_Unsigned");
			ret.FMediumInt = reader.ToInt32("FMediumInt");
			ret.FMediumInt_Unsigned = reader.ToInt32N("FMediumInt_Unsigned");
			ret.FInt = reader.ToInt32("FInt");
			ret.FInt_Unsigned = reader.ToInt64N("FInt_Unsigned");
			ret.F_Integer = reader.ToInt32N("F_Integer");
			ret.FBigInt = reader.ToInt64("FBigInt");
			ret.FBigInt_Unsigned = reader.ToUInt64N("FBigInt_Unsigned");
			ret.FFloat = reader.ToSingle("FFloat");
			ret.FFloat_Max = reader.ToSingleN("FFloat_Max");
			ret.FDouble = reader.ToDouble("FDouble");
			ret.FDouble_Max = reader.ToDoubleN("FDouble_Max");
			ret.F_Real = reader.ToDoubleN("F_Real");
			ret.F_Double_Precision = reader.ToDoubleN("F_Double_Precision");
			ret.FYear = reader.ToInt32N("FYear");
			ret.FDate = reader.ToDateTimeN("FDate");
			ret.FTime = reader.ToTimeSpanN("FTime");
			ret.FTimestamp = reader.ToDateTime("FTimestamp");
			ret.FDateTime = reader.ToDateTimeN("FDateTime");
			ret.FChar = reader.ToString("FChar");
			ret.FVarChar = reader.ToString("FVarChar");
			ret.FBinary = reader.ToBytes("FBinary");
			ret.FVarBinary = reader.ToBytes("FVarBinary");
			ret.FTinyText = reader.ToString("FTinyText");
			ret.FText = reader.ToString("FText");
			ret.FMediumText = reader.ToString("FMediumText");
			ret.FLongText = reader.ToString("FLongText");
			ret.FTinyBlob = reader.ToBytes("FTinyBlob");
			ret.FBlob = reader.ToBytes("FBlob");
			ret.FMediumBlob = reader.ToBytes("FMediumBlob");
			ret.FLongBlob = reader.ToBytes("FLongBlob");
			ret.FEnum = reader.ToString("FEnum");
			ret.FSet = reader.ToString("FSet");
			ret.FDecimal = reader.ToDecimal("FDecimal");
			ret.FDecimal_Max = reader.ToDecimalN("FDecimal_Max");
			ret.F_Numeric = reader.ToDecimalN("F_Numeric");
			ret.F_Dec = reader.ToDecimalN("F_Dec");
			ret.F_Fixed = reader.ToDecimalN("F_Fixed");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 用户表
	/// 【表 demo_user 的操作类】
	/// </summary>
	public class Demo_userMO : MySqlTableMO<Demo_userEO>
	{
	    public override string TableName => "`demo_user`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Demo_userMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Demo_userMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Demo_userMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Demo_userEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `demo_user` (`ClassID`, `FBit`, `FBit_Max`, `FTinyInt`, `FTinyInt_Unsigned`, `FBool`, `F_Boolean`, `FBool_TinyInt`, `FSmallInt`, `FSmallInt_Unsigned`, `FMediumInt`, `FMediumInt_Unsigned`, `FInt`, `FInt_Unsigned`, `F_Integer`, `FBigInt`, `FBigInt_Unsigned`, `FFloat`, `FFloat_Max`, `FDouble`, `FDouble_Max`, `F_Real`, `F_Double_Precision`, `FYear`, `FDate`, `FTime`, `FTimestamp`, `FDateTime`, `FChar`, `FVarChar`, `FBinary`, `FVarBinary`, `FTinyText`, `FText`, `FMediumText`, `FLongText`, `FTinyBlob`, `FBlob`, `FMediumBlob`, `FLongBlob`, `FEnum`, `FSet`, `FDecimal`, `FDecimal_Max`, `F_Numeric`, `F_Dec`, `F_Fixed`) VALUE (@ClassID, @FBit, @FBit_Max, @FTinyInt, @FTinyInt_Unsigned, @FBool, @F_Boolean, @FBool_TinyInt, @FSmallInt, @FSmallInt_Unsigned, @FMediumInt, @FMediumInt_Unsigned, @FInt, @FInt_Unsigned, @F_Integer, @FBigInt, @FBigInt_Unsigned, @FFloat, @FFloat_Max, @FDouble, @FDouble_Max, @F_Real, @F_Double_Precision, @FYear, @FDate, @FTime, @FTimestamp, @FDateTime, @FChar, @FVarChar, @FBinary, @FVarBinary, @FTinyText, @FText, @FMediumText, @FLongText, @FTinyBlob, @FBlob, @FMediumBlob, @FLongBlob, @FEnum, @FSet, @FDecimal, @FDecimal_Max, @F_Numeric, @F_Dec, @F_Fixed);SELECT LAST_INSERT_ID();";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ClassID", item.ClassID != null ? item.ClassID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@FBit", item.FBit, MySqlDbType.Bit),
				Database.CreateInParameter("@FBit_Max", item.FBit_Max.HasValue ? item.FBit_Max.Value : (object)DBNull.Value, MySqlDbType.Bit),
				Database.CreateInParameter("@FTinyInt", item.FTinyInt, MySqlDbType.Byte),
				Database.CreateInParameter("@FTinyInt_Unsigned", item.FTinyInt_Unsigned.HasValue ? item.FTinyInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UByte),
				Database.CreateInParameter("@FBool", item.FBool.HasValue ? item.FBool.Value : (object)DBNull.Value, MySqlDbType.Byte),
				Database.CreateInParameter("@F_Boolean", item.F_Boolean, MySqlDbType.Byte),
				Database.CreateInParameter("@FBool_TinyInt", item.FBool_TinyInt.HasValue ? item.FBool_TinyInt.Value : (object)DBNull.Value, MySqlDbType.Byte),
				Database.CreateInParameter("@FSmallInt", item.FSmallInt, MySqlDbType.Int16),
				Database.CreateInParameter("@FSmallInt_Unsigned", item.FSmallInt_Unsigned.HasValue ? item.FSmallInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt16),
				Database.CreateInParameter("@FMediumInt", item.FMediumInt, MySqlDbType.Int24),
				Database.CreateInParameter("@FMediumInt_Unsigned", item.FMediumInt_Unsigned.HasValue ? item.FMediumInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt24),
				Database.CreateInParameter("@FInt", item.FInt, MySqlDbType.Int32),
				Database.CreateInParameter("@FInt_Unsigned", item.FInt_Unsigned.HasValue ? item.FInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt32),
				Database.CreateInParameter("@F_Integer", item.F_Integer.HasValue ? item.F_Integer.Value : (object)DBNull.Value, MySqlDbType.Int32),
				Database.CreateInParameter("@FBigInt", item.FBigInt, MySqlDbType.Int64),
				Database.CreateInParameter("@FBigInt_Unsigned", item.FBigInt_Unsigned.HasValue ? item.FBigInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt64),
				Database.CreateInParameter("@FFloat", item.FFloat, MySqlDbType.Float),
				Database.CreateInParameter("@FFloat_Max", item.FFloat_Max.HasValue ? item.FFloat_Max.Value : (object)DBNull.Value, MySqlDbType.Float),
				Database.CreateInParameter("@FDouble", item.FDouble, MySqlDbType.Double),
				Database.CreateInParameter("@FDouble_Max", item.FDouble_Max.HasValue ? item.FDouble_Max.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@F_Real", item.F_Real.HasValue ? item.F_Real.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@F_Double_Precision", item.F_Double_Precision.HasValue ? item.F_Double_Precision.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@FYear", item.FYear.HasValue ? item.FYear.Value : (object)DBNull.Value, MySqlDbType.Year),
				Database.CreateInParameter("@FDate", item.FDate.HasValue ? item.FDate.Value : (object)DBNull.Value, MySqlDbType.Date),
				Database.CreateInParameter("@FTime", item.FTime.HasValue ? item.FTime.Value : (object)DBNull.Value, MySqlDbType.Time),
				Database.CreateInParameter("@FTimestamp", item.FTimestamp, MySqlDbType.Timestamp),
				Database.CreateInParameter("@FDateTime", item.FDateTime.HasValue ? item.FDateTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@FChar", item.FChar != null ? item.FChar : (object)DBNull.Value, MySqlDbType.String),
				Database.CreateInParameter("@FVarChar", item.FVarChar != null ? item.FVarChar : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@FBinary", item.FBinary != null ? item.FBinary : (object)DBNull.Value, MySqlDbType.Binary),
				Database.CreateInParameter("@FVarBinary", item.FVarBinary != null ? item.FVarBinary : (object)DBNull.Value, MySqlDbType.VarBinary),
				Database.CreateInParameter("@FTinyText", item.FTinyText != null ? item.FTinyText : (object)DBNull.Value, MySqlDbType.TinyText),
				Database.CreateInParameter("@FText", item.FText != null ? item.FText : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@FMediumText", item.FMediumText != null ? item.FMediumText : (object)DBNull.Value, MySqlDbType.MediumText),
				Database.CreateInParameter("@FLongText", item.FLongText != null ? item.FLongText : (object)DBNull.Value, MySqlDbType.LongText),
				Database.CreateInParameter("@FTinyBlob", item.FTinyBlob != null ? item.FTinyBlob : (object)DBNull.Value, MySqlDbType.TinyBlob),
				Database.CreateInParameter("@FBlob", item.FBlob != null ? item.FBlob : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@FMediumBlob", item.FMediumBlob != null ? item.FMediumBlob : (object)DBNull.Value, MySqlDbType.MediumBlob),
				Database.CreateInParameter("@FLongBlob", item.FLongBlob != null ? item.FLongBlob : (object)DBNull.Value, MySqlDbType.LongBlob),
				Database.CreateInParameter("@FEnum", item.FEnum != null ? item.FEnum : (object)DBNull.Value, MySqlDbType.Enum),
				Database.CreateInParameter("@FSet", item.FSet != null ? item.FSet : (object)DBNull.Value, MySqlDbType.Set),
				Database.CreateInParameter("@FDecimal", item.FDecimal, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@FDecimal_Max", item.FDecimal_Max.HasValue ? item.FDecimal_Max.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@F_Numeric", item.F_Numeric.HasValue ? item.F_Numeric.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@F_Dec", item.F_Dec.HasValue ? item.F_Dec.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@F_Fixed", item.F_Fixed.HasValue ? item.F_Fixed.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
			};
			item.UserID = Database.ExecSqlScalar<long>(sql, paras, tm); 
	        return 1;
		}
	    
	    #endregion // Add
	    
		#region  Remove
		
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long userID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `demo_user` WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Demo_userEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.UserID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByClassID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByClassID(string classID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (classID != null ? "`ClassID` = @ClassID" : "`ClassID` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (classID != null)
				paras_.Add(Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByClassID
	
		#region RemoveByFBit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBit(int fBit, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FBit` = @FBit";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FBit", fBit, MySqlDbType.Bit));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBit
	
		#region RemoveByFBit_Max
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBit_Max(int? fBit_Max, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fBit_Max.HasValue ? "`FBit_Max` = @FBit_Max" : "`FBit_Max` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fBit_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FBit_Max", fBit_Max.Value, MySqlDbType.Bit));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBit_Max
	
		#region RemoveByFTinyInt
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFTinyInt(int fTinyInt, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FTinyInt` = @FTinyInt";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FTinyInt", fTinyInt, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFTinyInt
	
		#region RemoveByFTinyInt_Unsigned
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFTinyInt_Unsigned(int? fTinyInt_Unsigned, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fTinyInt_Unsigned.HasValue ? "`FTinyInt_Unsigned` = @FTinyInt_Unsigned" : "`FTinyInt_Unsigned` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fTinyInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FTinyInt_Unsigned", fTinyInt_Unsigned.Value, MySqlDbType.UByte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFTinyInt_Unsigned
	
		#region RemoveByFBool
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBool(bool? fBool, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fBool.HasValue ? "`FBool` = @FBool" : "`FBool` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fBool.HasValue)
				paras_.Add(Database.CreateInParameter("@FBool", fBool.Value, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBool
	
		#region RemoveByF_Boolean
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByF_Boolean(bool f_Boolean, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `F_Boolean` = @F_Boolean";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@F_Boolean", f_Boolean, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByF_Boolean
	
		#region RemoveByFBool_TinyInt
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBool_TinyInt(bool? fBool_TinyInt, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fBool_TinyInt.HasValue ? "`FBool_TinyInt` = @FBool_TinyInt" : "`FBool_TinyInt` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fBool_TinyInt.HasValue)
				paras_.Add(Database.CreateInParameter("@FBool_TinyInt", fBool_TinyInt.Value, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBool_TinyInt
	
		#region RemoveByFSmallInt
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFSmallInt(int fSmallInt, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FSmallInt` = @FSmallInt";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FSmallInt", fSmallInt, MySqlDbType.Int16));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFSmallInt
	
		#region RemoveByFSmallInt_Unsigned
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFSmallInt_Unsigned(int? fSmallInt_Unsigned, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fSmallInt_Unsigned.HasValue ? "`FSmallInt_Unsigned` = @FSmallInt_Unsigned" : "`FSmallInt_Unsigned` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fSmallInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FSmallInt_Unsigned", fSmallInt_Unsigned.Value, MySqlDbType.UInt16));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFSmallInt_Unsigned
	
		#region RemoveByFMediumInt
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFMediumInt(int fMediumInt, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FMediumInt` = @FMediumInt";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FMediumInt", fMediumInt, MySqlDbType.Int24));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFMediumInt
	
		#region RemoveByFMediumInt_Unsigned
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFMediumInt_Unsigned(int? fMediumInt_Unsigned, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fMediumInt_Unsigned.HasValue ? "`FMediumInt_Unsigned` = @FMediumInt_Unsigned" : "`FMediumInt_Unsigned` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fMediumInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FMediumInt_Unsigned", fMediumInt_Unsigned.Value, MySqlDbType.UInt24));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFMediumInt_Unsigned
	
		#region RemoveByFInt
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFInt(int fInt, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FInt` = @FInt";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FInt", fInt, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFInt
	
		#region RemoveByFInt_Unsigned
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFInt_Unsigned(long? fInt_Unsigned, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fInt_Unsigned.HasValue ? "`FInt_Unsigned` = @FInt_Unsigned" : "`FInt_Unsigned` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FInt_Unsigned", fInt_Unsigned.Value, MySqlDbType.UInt32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFInt_Unsigned
	
		#region RemoveByF_Integer
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByF_Integer(int? f_Integer, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (f_Integer.HasValue ? "`F_Integer` = @F_Integer" : "`F_Integer` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (f_Integer.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Integer", f_Integer.Value, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByF_Integer
	
		#region RemoveByFBigInt
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBigInt(long fBigInt, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FBigInt` = @FBigInt";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FBigInt", fBigInt, MySqlDbType.Int64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBigInt
	
		#region RemoveByFBigInt_Unsigned
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBigInt_Unsigned(ulong? fBigInt_Unsigned, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fBigInt_Unsigned.HasValue ? "`FBigInt_Unsigned` = @FBigInt_Unsigned" : "`FBigInt_Unsigned` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fBigInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FBigInt_Unsigned", fBigInt_Unsigned.Value, MySqlDbType.UInt64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBigInt_Unsigned
	
		#region RemoveByFFloat
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFFloat(float fFloat, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FFloat` = @FFloat";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FFloat", fFloat, MySqlDbType.Float));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFFloat
	
		#region RemoveByFFloat_Max
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFFloat_Max(float? fFloat_Max, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fFloat_Max.HasValue ? "`FFloat_Max` = @FFloat_Max" : "`FFloat_Max` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fFloat_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FFloat_Max", fFloat_Max.Value, MySqlDbType.Float));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFFloat_Max
	
		#region RemoveByFDouble
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFDouble(double fDouble, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FDouble` = @FDouble";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FDouble", fDouble, MySqlDbType.Double));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFDouble
	
		#region RemoveByFDouble_Max
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFDouble_Max(double? fDouble_Max, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fDouble_Max.HasValue ? "`FDouble_Max` = @FDouble_Max" : "`FDouble_Max` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fDouble_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FDouble_Max", fDouble_Max.Value, MySqlDbType.Double));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFDouble_Max
	
		#region RemoveByF_Real
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByF_Real(double? f_Real, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (f_Real.HasValue ? "`F_Real` = @F_Real" : "`F_Real` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (f_Real.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Real", f_Real.Value, MySqlDbType.Double));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByF_Real
	
		#region RemoveByF_Double_Precision
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByF_Double_Precision(double? f_Double_Precision, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (f_Double_Precision.HasValue ? "`F_Double_Precision` = @F_Double_Precision" : "`F_Double_Precision` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (f_Double_Precision.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Double_Precision", f_Double_Precision.Value, MySqlDbType.Double));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByF_Double_Precision
	
		#region RemoveByFYear
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFYear(int? fYear, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fYear.HasValue ? "`FYear` = @FYear" : "`FYear` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fYear.HasValue)
				paras_.Add(Database.CreateInParameter("@FYear", fYear.Value, MySqlDbType.Year));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFYear
	
		#region RemoveByFDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFDate(DateTime? fDate, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fDate.HasValue ? "`FDate` = @FDate" : "`FDate` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fDate.HasValue)
				paras_.Add(Database.CreateInParameter("@FDate", fDate.Value, MySqlDbType.Date));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFDate
	
		#region RemoveByFTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFTime(TimeSpan? fTime, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fTime.HasValue ? "`FTime` = @FTime" : "`FTime` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fTime.HasValue)
				paras_.Add(Database.CreateInParameter("@FTime", fTime.Value, MySqlDbType.Time));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFTime
	
		#region RemoveByFTimestamp
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFTimestamp(DateTime fTimestamp, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FTimestamp` = @FTimestamp";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FTimestamp", fTimestamp, MySqlDbType.Timestamp));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFTimestamp
	
		#region RemoveByFDateTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFDateTime(DateTime? fDateTime, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fDateTime.HasValue ? "`FDateTime` = @FDateTime" : "`FDateTime` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fDateTime.HasValue)
				paras_.Add(Database.CreateInParameter("@FDateTime", fDateTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFDateTime
	
		#region RemoveByFChar
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFChar(string fChar, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fChar != null ? "`FChar` = @FChar" : "`FChar` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fChar != null)
				paras_.Add(Database.CreateInParameter("@FChar", fChar, MySqlDbType.String));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFChar
	
		#region RemoveByFVarChar
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFVarChar(string fVarChar, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fVarChar != null ? "`FVarChar` = @FVarChar" : "`FVarChar` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fVarChar != null)
				paras_.Add(Database.CreateInParameter("@FVarChar", fVarChar, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFVarChar
	
		#region RemoveByFBinary
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBinary(byte[] fBinary, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fBinary != null ? "`FBinary` = @FBinary" : "`FBinary` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fBinary != null)
				paras_.Add(Database.CreateInParameter("@FBinary", fBinary, MySqlDbType.Binary));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBinary
	
		#region RemoveByFVarBinary
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFVarBinary(byte[] fVarBinary, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fVarBinary != null ? "`FVarBinary` = @FVarBinary" : "`FVarBinary` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fVarBinary != null)
				paras_.Add(Database.CreateInParameter("@FVarBinary", fVarBinary, MySqlDbType.VarBinary));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFVarBinary
	
		#region RemoveByFTinyText
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFTinyText(string fTinyText, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fTinyText != null ? "`FTinyText` = @FTinyText" : "`FTinyText` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fTinyText != null)
				paras_.Add(Database.CreateInParameter("@FTinyText", fTinyText, MySqlDbType.TinyText));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFTinyText
	
		#region RemoveByFText
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFText(string fText, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fText != null ? "`FText` = @FText" : "`FText` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fText != null)
				paras_.Add(Database.CreateInParameter("@FText", fText, MySqlDbType.Text));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFText
	
		#region RemoveByFMediumText
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFMediumText(string fMediumText, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fMediumText != null ? "`FMediumText` = @FMediumText" : "`FMediumText` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fMediumText != null)
				paras_.Add(Database.CreateInParameter("@FMediumText", fMediumText, MySqlDbType.MediumText));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFMediumText
	
		#region RemoveByFLongText
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFLongText(string fLongText, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fLongText != null ? "`FLongText` = @FLongText" : "`FLongText` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fLongText != null)
				paras_.Add(Database.CreateInParameter("@FLongText", fLongText, MySqlDbType.LongText));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFLongText
	
		#region RemoveByFTinyBlob
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFTinyBlob(byte[] fTinyBlob, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fTinyBlob != null ? "`FTinyBlob` = @FTinyBlob" : "`FTinyBlob` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fTinyBlob != null)
				paras_.Add(Database.CreateInParameter("@FTinyBlob", fTinyBlob, MySqlDbType.TinyBlob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFTinyBlob
	
		#region RemoveByFBlob
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFBlob(byte[] fBlob, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fBlob != null ? "`FBlob` = @FBlob" : "`FBlob` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fBlob != null)
				paras_.Add(Database.CreateInParameter("@FBlob", fBlob, MySqlDbType.Blob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFBlob
	
		#region RemoveByFMediumBlob
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFMediumBlob(byte[] fMediumBlob, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fMediumBlob != null ? "`FMediumBlob` = @FMediumBlob" : "`FMediumBlob` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fMediumBlob != null)
				paras_.Add(Database.CreateInParameter("@FMediumBlob", fMediumBlob, MySqlDbType.MediumBlob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFMediumBlob
	
		#region RemoveByFLongBlob
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFLongBlob(byte[] fLongBlob, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fLongBlob != null ? "`FLongBlob` = @FLongBlob" : "`FLongBlob` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fLongBlob != null)
				paras_.Add(Database.CreateInParameter("@FLongBlob", fLongBlob, MySqlDbType.LongBlob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFLongBlob
	
		#region RemoveByFEnum
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFEnum(string fEnum, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fEnum != null ? "`FEnum` = @FEnum" : "`FEnum` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fEnum != null)
				paras_.Add(Database.CreateInParameter("@FEnum", fEnum, MySqlDbType.Enum));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFEnum
	
		#region RemoveByFSet
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFSet(string fSet, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fSet != null ? "`FSet` = @FSet" : "`FSet` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fSet != null)
				paras_.Add(Database.CreateInParameter("@FSet", fSet, MySqlDbType.Set));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFSet
	
		#region RemoveByFDecimal
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFDecimal(decimal fDecimal, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE `FDecimal` = @FDecimal";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FDecimal", fDecimal, MySqlDbType.NewDecimal));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFDecimal
	
		#region RemoveByFDecimal_Max
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFDecimal_Max(decimal? fDecimal_Max, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (fDecimal_Max.HasValue ? "`FDecimal_Max` = @FDecimal_Max" : "`FDecimal_Max` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (fDecimal_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FDecimal_Max", fDecimal_Max.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByFDecimal_Max
	
		#region RemoveByF_Numeric
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByF_Numeric(decimal? f_Numeric, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (f_Numeric.HasValue ? "`F_Numeric` = @F_Numeric" : "`F_Numeric` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (f_Numeric.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Numeric", f_Numeric.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByF_Numeric
	
		#region RemoveByF_Dec
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByF_Dec(decimal? f_Dec, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (f_Dec.HasValue ? "`F_Dec` = @F_Dec" : "`F_Dec` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (f_Dec.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Dec", f_Dec.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByF_Dec
	
		#region RemoveByF_Fixed
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByF_Fixed(decimal? f_Fixed, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user` WHERE " + (f_Fixed.HasValue ? "`F_Fixed` = @F_Fixed" : "`F_Fixed` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (f_Fixed.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Fixed", f_Fixed.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByF_Fixed
	
		#endregion // RemoveByXXX
	
		#region RemoveByFKOrUnique
	
		#endregion // RemoveByFKOrUnique
	
		#endregion //Remove
	
		#region Put
	
		#region PutItem
		/// <summary>
		/// 更新实体到数据库
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(Demo_userEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `demo_user` SET `ClassID` = @ClassID, `FBit` = @FBit, `FBit_Max` = @FBit_Max, `FTinyInt` = @FTinyInt, `FTinyInt_Unsigned` = @FTinyInt_Unsigned, `FBool` = @FBool, `F_Boolean` = @F_Boolean, `FBool_TinyInt` = @FBool_TinyInt, `FSmallInt` = @FSmallInt, `FSmallInt_Unsigned` = @FSmallInt_Unsigned, `FMediumInt` = @FMediumInt, `FMediumInt_Unsigned` = @FMediumInt_Unsigned, `FInt` = @FInt, `FInt_Unsigned` = @FInt_Unsigned, `F_Integer` = @F_Integer, `FBigInt` = @FBigInt, `FBigInt_Unsigned` = @FBigInt_Unsigned, `FFloat` = @FFloat, `FFloat_Max` = @FFloat_Max, `FDouble` = @FDouble, `FDouble_Max` = @FDouble_Max, `F_Real` = @F_Real, `F_Double_Precision` = @F_Double_Precision, `FYear` = @FYear, `FDate` = @FDate, `FTime` = @FTime, `FDateTime` = @FDateTime, `FChar` = @FChar, `FVarChar` = @FVarChar, `FBinary` = @FBinary, `FVarBinary` = @FVarBinary, `FTinyText` = @FTinyText, `FText` = @FText, `FMediumText` = @FMediumText, `FLongText` = @FLongText, `FTinyBlob` = @FTinyBlob, `FBlob` = @FBlob, `FMediumBlob` = @FMediumBlob, `FLongBlob` = @FLongBlob, `FEnum` = @FEnum, `FSet` = @FSet, `FDecimal` = @FDecimal, `FDecimal_Max` = @FDecimal_Max, `F_Numeric` = @F_Numeric, `F_Dec` = @F_Dec, `F_Fixed` = @F_Fixed WHERE `UserID` = @UserID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ClassID", item.ClassID != null ? item.ClassID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@FBit", item.FBit, MySqlDbType.Bit),
				Database.CreateInParameter("@FBit_Max", item.FBit_Max.HasValue ? item.FBit_Max.Value : (object)DBNull.Value, MySqlDbType.Bit),
				Database.CreateInParameter("@FTinyInt", item.FTinyInt, MySqlDbType.Byte),
				Database.CreateInParameter("@FTinyInt_Unsigned", item.FTinyInt_Unsigned.HasValue ? item.FTinyInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UByte),
				Database.CreateInParameter("@FBool", item.FBool.HasValue ? item.FBool.Value : (object)DBNull.Value, MySqlDbType.Byte),
				Database.CreateInParameter("@F_Boolean", item.F_Boolean, MySqlDbType.Byte),
				Database.CreateInParameter("@FBool_TinyInt", item.FBool_TinyInt.HasValue ? item.FBool_TinyInt.Value : (object)DBNull.Value, MySqlDbType.Byte),
				Database.CreateInParameter("@FSmallInt", item.FSmallInt, MySqlDbType.Int16),
				Database.CreateInParameter("@FSmallInt_Unsigned", item.FSmallInt_Unsigned.HasValue ? item.FSmallInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt16),
				Database.CreateInParameter("@FMediumInt", item.FMediumInt, MySqlDbType.Int24),
				Database.CreateInParameter("@FMediumInt_Unsigned", item.FMediumInt_Unsigned.HasValue ? item.FMediumInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt24),
				Database.CreateInParameter("@FInt", item.FInt, MySqlDbType.Int32),
				Database.CreateInParameter("@FInt_Unsigned", item.FInt_Unsigned.HasValue ? item.FInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt32),
				Database.CreateInParameter("@F_Integer", item.F_Integer.HasValue ? item.F_Integer.Value : (object)DBNull.Value, MySqlDbType.Int32),
				Database.CreateInParameter("@FBigInt", item.FBigInt, MySqlDbType.Int64),
				Database.CreateInParameter("@FBigInt_Unsigned", item.FBigInt_Unsigned.HasValue ? item.FBigInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt64),
				Database.CreateInParameter("@FFloat", item.FFloat, MySqlDbType.Float),
				Database.CreateInParameter("@FFloat_Max", item.FFloat_Max.HasValue ? item.FFloat_Max.Value : (object)DBNull.Value, MySqlDbType.Float),
				Database.CreateInParameter("@FDouble", item.FDouble, MySqlDbType.Double),
				Database.CreateInParameter("@FDouble_Max", item.FDouble_Max.HasValue ? item.FDouble_Max.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@F_Real", item.F_Real.HasValue ? item.F_Real.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@F_Double_Precision", item.F_Double_Precision.HasValue ? item.F_Double_Precision.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@FYear", item.FYear.HasValue ? item.FYear.Value : (object)DBNull.Value, MySqlDbType.Year),
				Database.CreateInParameter("@FDate", item.FDate.HasValue ? item.FDate.Value : (object)DBNull.Value, MySqlDbType.Date),
				Database.CreateInParameter("@FTime", item.FTime.HasValue ? item.FTime.Value : (object)DBNull.Value, MySqlDbType.Time),
				Database.CreateInParameter("@FDateTime", item.FDateTime.HasValue ? item.FDateTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@FChar", item.FChar != null ? item.FChar : (object)DBNull.Value, MySqlDbType.String),
				Database.CreateInParameter("@FVarChar", item.FVarChar != null ? item.FVarChar : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@FBinary", item.FBinary != null ? item.FBinary : (object)DBNull.Value, MySqlDbType.Binary),
				Database.CreateInParameter("@FVarBinary", item.FVarBinary != null ? item.FVarBinary : (object)DBNull.Value, MySqlDbType.VarBinary),
				Database.CreateInParameter("@FTinyText", item.FTinyText != null ? item.FTinyText : (object)DBNull.Value, MySqlDbType.TinyText),
				Database.CreateInParameter("@FText", item.FText != null ? item.FText : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@FMediumText", item.FMediumText != null ? item.FMediumText : (object)DBNull.Value, MySqlDbType.MediumText),
				Database.CreateInParameter("@FLongText", item.FLongText != null ? item.FLongText : (object)DBNull.Value, MySqlDbType.LongText),
				Database.CreateInParameter("@FTinyBlob", item.FTinyBlob != null ? item.FTinyBlob : (object)DBNull.Value, MySqlDbType.TinyBlob),
				Database.CreateInParameter("@FBlob", item.FBlob != null ? item.FBlob : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@FMediumBlob", item.FMediumBlob != null ? item.FMediumBlob : (object)DBNull.Value, MySqlDbType.MediumBlob),
				Database.CreateInParameter("@FLongBlob", item.FLongBlob != null ? item.FLongBlob : (object)DBNull.Value, MySqlDbType.LongBlob),
				Database.CreateInParameter("@FEnum", item.FEnum != null ? item.FEnum : (object)DBNull.Value, MySqlDbType.Enum),
				Database.CreateInParameter("@FSet", item.FSet != null ? item.FSet : (object)DBNull.Value, MySqlDbType.Set),
				Database.CreateInParameter("@FDecimal", item.FDecimal, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@FDecimal_Max", item.FDecimal_Max.HasValue ? item.FDecimal_Max.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@F_Numeric", item.F_Numeric.HasValue ? item.F_Numeric.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@F_Dec", item.F_Dec.HasValue ? item.F_Dec.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@F_Fixed", item.F_Fixed.HasValue ? item.F_Fixed.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserID_Original", item.HasOriginal ? item.OriginalUserID : item.UserID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Demo_userEO> items, TransactionManager tm = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm);
			}
			return ret;
		}
		#endregion // PutItem
	
		#region PutByPK
	
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long userID, string set_, params object[] values_)
		{
			return Put(set_, "`UserID` = @UserID", ConcatValues(values_, userID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long userID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`UserID` = @UserID", tm_, ConcatValues(values_, userID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long userID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
	        };
			return Put(set_, "`UserID` = @UserID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutClassID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "classID">类别编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutClassIDByPK(long userID, string classID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `ClassID` = @ClassID  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ClassID", classID != null ? classID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutClassID(string classID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `ClassID` = @ClassID";
			var parameter_ = Database.CreateInParameter("@ClassID", classID != null ? classID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutClassID
	
		#region PutFBit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBit">字段1</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBitByPK(long userID, int fBit, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBit` = @FBit  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBit", fBit, MySqlDbType.Bit),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBit(int fBit, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBit` = @FBit";
			var parameter_ = Database.CreateInParameter("@FBit", fBit, MySqlDbType.Bit);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBit
	
		#region PutFBit_Max
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBit_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBit_MaxByPK(long userID, int? fBit_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBit_Max` = @FBit_Max  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBit_Max", fBit_Max.HasValue ? fBit_Max.Value : (object)DBNull.Value, MySqlDbType.Bit),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBit_Max(int? fBit_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBit_Max` = @FBit_Max";
			var parameter_ = Database.CreateInParameter("@FBit_Max", fBit_Max.HasValue ? fBit_Max.Value : (object)DBNull.Value, MySqlDbType.Bit);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBit_Max
	
		#region PutFTinyInt
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fTinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyIntByPK(long userID, int fTinyInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyInt` = @FTinyInt  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FTinyInt", fTinyInt, MySqlDbType.Byte),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyInt(int fTinyInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyInt` = @FTinyInt";
			var parameter_ = Database.CreateInParameter("@FTinyInt", fTinyInt, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFTinyInt
	
		#region PutFTinyInt_Unsigned
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyInt_UnsignedByPK(long userID, int? fTinyInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyInt_Unsigned` = @FTinyInt_Unsigned  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FTinyInt_Unsigned", fTinyInt_Unsigned.HasValue ? fTinyInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UByte),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyInt_Unsigned(int? fTinyInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyInt_Unsigned` = @FTinyInt_Unsigned";
			var parameter_ = Database.CreateInParameter("@FTinyInt_Unsigned", fTinyInt_Unsigned.HasValue ? fTinyInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UByte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFTinyInt_Unsigned
	
		#region PutFBool
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBool"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBoolByPK(long userID, bool? fBool, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBool` = @FBool  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBool", fBool.HasValue ? fBool.Value : (object)DBNull.Value, MySqlDbType.Byte),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBool(bool? fBool, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBool` = @FBool";
			var parameter_ = Database.CreateInParameter("@FBool", fBool.HasValue ? fBool.Value : (object)DBNull.Value, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBool
	
		#region PutF_Boolean
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "f_Boolean"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_BooleanByPK(long userID, bool f_Boolean, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Boolean` = @F_Boolean  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@F_Boolean", f_Boolean, MySqlDbType.Byte),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Boolean(bool f_Boolean, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Boolean` = @F_Boolean";
			var parameter_ = Database.CreateInParameter("@F_Boolean", f_Boolean, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutF_Boolean
	
		#region PutFBool_TinyInt
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBool_TinyIntByPK(long userID, bool? fBool_TinyInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBool_TinyInt` = @FBool_TinyInt  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBool_TinyInt", fBool_TinyInt.HasValue ? fBool_TinyInt.Value : (object)DBNull.Value, MySqlDbType.Byte),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBool_TinyInt(bool? fBool_TinyInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBool_TinyInt` = @FBool_TinyInt";
			var parameter_ = Database.CreateInParameter("@FBool_TinyInt", fBool_TinyInt.HasValue ? fBool_TinyInt.Value : (object)DBNull.Value, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBool_TinyInt
	
		#region PutFSmallInt
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fSmallInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFSmallIntByPK(long userID, int fSmallInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FSmallInt` = @FSmallInt  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FSmallInt", fSmallInt, MySqlDbType.Int16),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFSmallInt(int fSmallInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FSmallInt` = @FSmallInt";
			var parameter_ = Database.CreateInParameter("@FSmallInt", fSmallInt, MySqlDbType.Int16);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFSmallInt
	
		#region PutFSmallInt_Unsigned
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFSmallInt_UnsignedByPK(long userID, int? fSmallInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FSmallInt_Unsigned` = @FSmallInt_Unsigned  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FSmallInt_Unsigned", fSmallInt_Unsigned.HasValue ? fSmallInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt16),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFSmallInt_Unsigned(int? fSmallInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FSmallInt_Unsigned` = @FSmallInt_Unsigned";
			var parameter_ = Database.CreateInParameter("@FSmallInt_Unsigned", fSmallInt_Unsigned.HasValue ? fSmallInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt16);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFSmallInt_Unsigned
	
		#region PutFMediumInt
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fMediumInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumIntByPK(long userID, int fMediumInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumInt` = @FMediumInt  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FMediumInt", fMediumInt, MySqlDbType.Int24),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumInt(int fMediumInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumInt` = @FMediumInt";
			var parameter_ = Database.CreateInParameter("@FMediumInt", fMediumInt, MySqlDbType.Int24);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFMediumInt
	
		#region PutFMediumInt_Unsigned
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumInt_UnsignedByPK(long userID, int? fMediumInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumInt_Unsigned` = @FMediumInt_Unsigned  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FMediumInt_Unsigned", fMediumInt_Unsigned.HasValue ? fMediumInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt24),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumInt_Unsigned(int? fMediumInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumInt_Unsigned` = @FMediumInt_Unsigned";
			var parameter_ = Database.CreateInParameter("@FMediumInt_Unsigned", fMediumInt_Unsigned.HasValue ? fMediumInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt24);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFMediumInt_Unsigned
	
		#region PutFInt
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFIntByPK(long userID, int fInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FInt` = @FInt  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FInt", fInt, MySqlDbType.Int32),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFInt(int fInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FInt` = @FInt";
			var parameter_ = Database.CreateInParameter("@FInt", fInt, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFInt
	
		#region PutFInt_Unsigned
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFInt_UnsignedByPK(long userID, long? fInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FInt_Unsigned` = @FInt_Unsigned  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FInt_Unsigned", fInt_Unsigned.HasValue ? fInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt32),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFInt_Unsigned(long? fInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FInt_Unsigned` = @FInt_Unsigned";
			var parameter_ = Database.CreateInParameter("@FInt_Unsigned", fInt_Unsigned.HasValue ? fInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFInt_Unsigned
	
		#region PutF_Integer
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "f_Integer"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_IntegerByPK(long userID, int? f_Integer, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Integer` = @F_Integer  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@F_Integer", f_Integer.HasValue ? f_Integer.Value : (object)DBNull.Value, MySqlDbType.Int32),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Integer(int? f_Integer, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Integer` = @F_Integer";
			var parameter_ = Database.CreateInParameter("@F_Integer", f_Integer.HasValue ? f_Integer.Value : (object)DBNull.Value, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutF_Integer
	
		#region PutFBigInt
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBigInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBigIntByPK(long userID, long fBigInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBigInt` = @FBigInt  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBigInt", fBigInt, MySqlDbType.Int64),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBigInt(long fBigInt, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBigInt` = @FBigInt";
			var parameter_ = Database.CreateInParameter("@FBigInt", fBigInt, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBigInt
	
		#region PutFBigInt_Unsigned
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBigInt_UnsignedByPK(long userID, ulong? fBigInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBigInt_Unsigned` = @FBigInt_Unsigned  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBigInt_Unsigned", fBigInt_Unsigned.HasValue ? fBigInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt64),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBigInt_Unsigned(ulong? fBigInt_Unsigned, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBigInt_Unsigned` = @FBigInt_Unsigned";
			var parameter_ = Database.CreateInParameter("@FBigInt_Unsigned", fBigInt_Unsigned.HasValue ? fBigInt_Unsigned.Value : (object)DBNull.Value, MySqlDbType.UInt64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBigInt_Unsigned
	
		#region PutFFloat
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fFloat"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFFloatByPK(long userID, float fFloat, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FFloat` = @FFloat  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FFloat", fFloat, MySqlDbType.Float),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFFloat(float fFloat, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FFloat` = @FFloat";
			var parameter_ = Database.CreateInParameter("@FFloat", fFloat, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFFloat
	
		#region PutFFloat_Max
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFFloat_MaxByPK(long userID, float? fFloat_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FFloat_Max` = @FFloat_Max  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FFloat_Max", fFloat_Max.HasValue ? fFloat_Max.Value : (object)DBNull.Value, MySqlDbType.Float),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFFloat_Max(float? fFloat_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FFloat_Max` = @FFloat_Max";
			var parameter_ = Database.CreateInParameter("@FFloat_Max", fFloat_Max.HasValue ? fFloat_Max.Value : (object)DBNull.Value, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFFloat_Max
	
		#region PutFDouble
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fDouble"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDoubleByPK(long userID, double fDouble, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDouble` = @FDouble  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FDouble", fDouble, MySqlDbType.Double),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDouble(double fDouble, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDouble` = @FDouble";
			var parameter_ = Database.CreateInParameter("@FDouble", fDouble, MySqlDbType.Double);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFDouble
	
		#region PutFDouble_Max
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDouble_MaxByPK(long userID, double? fDouble_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDouble_Max` = @FDouble_Max  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FDouble_Max", fDouble_Max.HasValue ? fDouble_Max.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDouble_Max(double? fDouble_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDouble_Max` = @FDouble_Max";
			var parameter_ = Database.CreateInParameter("@FDouble_Max", fDouble_Max.HasValue ? fDouble_Max.Value : (object)DBNull.Value, MySqlDbType.Double);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFDouble_Max
	
		#region PutF_Real
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "f_Real"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_RealByPK(long userID, double? f_Real, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Real` = @F_Real  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@F_Real", f_Real.HasValue ? f_Real.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Real(double? f_Real, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Real` = @F_Real";
			var parameter_ = Database.CreateInParameter("@F_Real", f_Real.HasValue ? f_Real.Value : (object)DBNull.Value, MySqlDbType.Double);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutF_Real
	
		#region PutF_Double_Precision
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Double_PrecisionByPK(long userID, double? f_Double_Precision, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Double_Precision` = @F_Double_Precision  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@F_Double_Precision", f_Double_Precision.HasValue ? f_Double_Precision.Value : (object)DBNull.Value, MySqlDbType.Double),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Double_Precision(double? f_Double_Precision, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Double_Precision` = @F_Double_Precision";
			var parameter_ = Database.CreateInParameter("@F_Double_Precision", f_Double_Precision.HasValue ? f_Double_Precision.Value : (object)DBNull.Value, MySqlDbType.Double);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutF_Double_Precision
	
		#region PutFYear
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fYear"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFYearByPK(long userID, int? fYear, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FYear` = @FYear  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FYear", fYear.HasValue ? fYear.Value : (object)DBNull.Value, MySqlDbType.Year),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFYear(int? fYear, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FYear` = @FYear";
			var parameter_ = Database.CreateInParameter("@FYear", fYear.HasValue ? fYear.Value : (object)DBNull.Value, MySqlDbType.Year);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFYear
	
		#region PutFDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fDate"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDateByPK(long userID, DateTime? fDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDate` = @FDate  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FDate", fDate.HasValue ? fDate.Value : (object)DBNull.Value, MySqlDbType.Date),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDate(DateTime? fDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDate` = @FDate";
			var parameter_ = Database.CreateInParameter("@FDate", fDate.HasValue ? fDate.Value : (object)DBNull.Value, MySqlDbType.Date);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFDate
	
		#region PutFTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fTime"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTimeByPK(long userID, TimeSpan? fTime, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTime` = @FTime  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FTime", fTime.HasValue ? fTime.Value : (object)DBNull.Value, MySqlDbType.Time),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTime(TimeSpan? fTime, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTime` = @FTime";
			var parameter_ = Database.CreateInParameter("@FTime", fTime.HasValue ? fTime.Value : (object)DBNull.Value, MySqlDbType.Time);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFTime
	
		#region PutFTimestamp
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fTimestamp"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTimestampByPK(long userID, DateTime fTimestamp, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTimestamp` = @FTimestamp  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FTimestamp", fTimestamp, MySqlDbType.Timestamp),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTimestamp(DateTime fTimestamp, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTimestamp` = @FTimestamp";
			var parameter_ = Database.CreateInParameter("@FTimestamp", fTimestamp, MySqlDbType.Timestamp);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFTimestamp
	
		#region PutFDateTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fDateTime"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDateTimeByPK(long userID, DateTime? fDateTime, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDateTime` = @FDateTime  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FDateTime", fDateTime.HasValue ? fDateTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDateTime(DateTime? fDateTime, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDateTime` = @FDateTime";
			var parameter_ = Database.CreateInParameter("@FDateTime", fDateTime.HasValue ? fDateTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFDateTime
	
		#region PutFChar
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fChar"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFCharByPK(long userID, string fChar, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FChar` = @FChar  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FChar", fChar != null ? fChar : (object)DBNull.Value, MySqlDbType.String),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFChar(string fChar, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FChar` = @FChar";
			var parameter_ = Database.CreateInParameter("@FChar", fChar != null ? fChar : (object)DBNull.Value, MySqlDbType.String);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFChar
	
		#region PutFVarChar
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fVarChar"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFVarCharByPK(long userID, string fVarChar, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FVarChar` = @FVarChar  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FVarChar", fVarChar != null ? fVarChar : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFVarChar(string fVarChar, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FVarChar` = @FVarChar";
			var parameter_ = Database.CreateInParameter("@FVarChar", fVarChar != null ? fVarChar : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFVarChar
	
		#region PutFBinary
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBinaryByPK(long userID, byte[] fBinary, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBinary` = @FBinary  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBinary", fBinary != null ? fBinary : (object)DBNull.Value, MySqlDbType.Binary),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBinary(byte[] fBinary, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBinary` = @FBinary";
			var parameter_ = Database.CreateInParameter("@FBinary", fBinary != null ? fBinary : (object)DBNull.Value, MySqlDbType.Binary);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBinary
	
		#region PutFVarBinary
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fVarBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFVarBinaryByPK(long userID, byte[] fVarBinary, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FVarBinary` = @FVarBinary  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FVarBinary", fVarBinary != null ? fVarBinary : (object)DBNull.Value, MySqlDbType.VarBinary),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFVarBinary(byte[] fVarBinary, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FVarBinary` = @FVarBinary";
			var parameter_ = Database.CreateInParameter("@FVarBinary", fVarBinary != null ? fVarBinary : (object)DBNull.Value, MySqlDbType.VarBinary);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFVarBinary
	
		#region PutFTinyText
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fTinyText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyTextByPK(long userID, string fTinyText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyText` = @FTinyText  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FTinyText", fTinyText != null ? fTinyText : (object)DBNull.Value, MySqlDbType.TinyText),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyText(string fTinyText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyText` = @FTinyText";
			var parameter_ = Database.CreateInParameter("@FTinyText", fTinyText != null ? fTinyText : (object)DBNull.Value, MySqlDbType.TinyText);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFTinyText
	
		#region PutFText
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTextByPK(long userID, string fText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FText` = @FText  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FText", fText != null ? fText : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFText(string fText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FText` = @FText";
			var parameter_ = Database.CreateInParameter("@FText", fText != null ? fText : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFText
	
		#region PutFMediumText
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fMediumText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumTextByPK(long userID, string fMediumText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumText` = @FMediumText  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FMediumText", fMediumText != null ? fMediumText : (object)DBNull.Value, MySqlDbType.MediumText),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumText(string fMediumText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumText` = @FMediumText";
			var parameter_ = Database.CreateInParameter("@FMediumText", fMediumText != null ? fMediumText : (object)DBNull.Value, MySqlDbType.MediumText);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFMediumText
	
		#region PutFLongText
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fLongText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFLongTextByPK(long userID, string fLongText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FLongText` = @FLongText  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FLongText", fLongText != null ? fLongText : (object)DBNull.Value, MySqlDbType.LongText),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFLongText(string fLongText, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FLongText` = @FLongText";
			var parameter_ = Database.CreateInParameter("@FLongText", fLongText != null ? fLongText : (object)DBNull.Value, MySqlDbType.LongText);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFLongText
	
		#region PutFTinyBlob
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyBlobByPK(long userID, byte[] fTinyBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyBlob` = @FTinyBlob  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FTinyBlob", fTinyBlob != null ? fTinyBlob : (object)DBNull.Value, MySqlDbType.TinyBlob),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFTinyBlob(byte[] fTinyBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FTinyBlob` = @FTinyBlob";
			var parameter_ = Database.CreateInParameter("@FTinyBlob", fTinyBlob != null ? fTinyBlob : (object)DBNull.Value, MySqlDbType.TinyBlob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFTinyBlob
	
		#region PutFBlob
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBlobByPK(long userID, byte[] fBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBlob` = @FBlob  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FBlob", fBlob != null ? fBlob : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFBlob(byte[] fBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FBlob` = @FBlob";
			var parameter_ = Database.CreateInParameter("@FBlob", fBlob != null ? fBlob : (object)DBNull.Value, MySqlDbType.Blob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFBlob
	
		#region PutFMediumBlob
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumBlobByPK(long userID, byte[] fMediumBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumBlob` = @FMediumBlob  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FMediumBlob", fMediumBlob != null ? fMediumBlob : (object)DBNull.Value, MySqlDbType.MediumBlob),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFMediumBlob(byte[] fMediumBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FMediumBlob` = @FMediumBlob";
			var parameter_ = Database.CreateInParameter("@FMediumBlob", fMediumBlob != null ? fMediumBlob : (object)DBNull.Value, MySqlDbType.MediumBlob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFMediumBlob
	
		#region PutFLongBlob
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fLongBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFLongBlobByPK(long userID, byte[] fLongBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FLongBlob` = @FLongBlob  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FLongBlob", fLongBlob != null ? fLongBlob : (object)DBNull.Value, MySqlDbType.LongBlob),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFLongBlob(byte[] fLongBlob, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FLongBlob` = @FLongBlob";
			var parameter_ = Database.CreateInParameter("@FLongBlob", fLongBlob != null ? fLongBlob : (object)DBNull.Value, MySqlDbType.LongBlob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFLongBlob
	
		#region PutFEnum
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fEnum"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFEnumByPK(long userID, string fEnum, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FEnum` = @FEnum  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FEnum", fEnum != null ? fEnum : (object)DBNull.Value, MySqlDbType.Enum),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFEnum(string fEnum, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FEnum` = @FEnum";
			var parameter_ = Database.CreateInParameter("@FEnum", fEnum != null ? fEnum : (object)DBNull.Value, MySqlDbType.Enum);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFEnum
	
		#region PutFSet
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fSet"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFSetByPK(long userID, string fSet, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FSet` = @FSet  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FSet", fSet != null ? fSet : (object)DBNull.Value, MySqlDbType.Set),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFSet(string fSet, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FSet` = @FSet";
			var parameter_ = Database.CreateInParameter("@FSet", fSet != null ? fSet : (object)DBNull.Value, MySqlDbType.Set);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFSet
	
		#region PutFDecimal
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fDecimal"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDecimalByPK(long userID, decimal fDecimal, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDecimal` = @FDecimal  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FDecimal", fDecimal, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDecimal(decimal fDecimal, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDecimal` = @FDecimal";
			var parameter_ = Database.CreateInParameter("@FDecimal", fDecimal, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFDecimal
	
		#region PutFDecimal_Max
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDecimal_MaxByPK(long userID, decimal? fDecimal_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDecimal_Max` = @FDecimal_Max  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FDecimal_Max", fDecimal_Max.HasValue ? fDecimal_Max.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFDecimal_Max(decimal? fDecimal_Max, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `FDecimal_Max` = @FDecimal_Max";
			var parameter_ = Database.CreateInParameter("@FDecimal_Max", fDecimal_Max.HasValue ? fDecimal_Max.Value : (object)DBNull.Value, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFDecimal_Max
	
		#region PutF_Numeric
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "f_Numeric"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_NumericByPK(long userID, decimal? f_Numeric, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Numeric` = @F_Numeric  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@F_Numeric", f_Numeric.HasValue ? f_Numeric.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Numeric(decimal? f_Numeric, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Numeric` = @F_Numeric";
			var parameter_ = Database.CreateInParameter("@F_Numeric", f_Numeric.HasValue ? f_Numeric.Value : (object)DBNull.Value, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutF_Numeric
	
		#region PutF_Dec
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "f_Dec"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_DecByPK(long userID, decimal? f_Dec, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Dec` = @F_Dec  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@F_Dec", f_Dec.HasValue ? f_Dec.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Dec(decimal? f_Dec, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Dec` = @F_Dec";
			var parameter_ = Database.CreateInParameter("@F_Dec", f_Dec.HasValue ? f_Dec.Value : (object)DBNull.Value, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutF_Dec
	
		#region PutF_Fixed
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "f_Fixed"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_FixedByPK(long userID, decimal? f_Fixed, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Fixed` = @F_Fixed  WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@F_Fixed", f_Fixed.HasValue ? f_Fixed.Value : (object)DBNull.Value, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutF_Fixed(decimal? f_Fixed, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user` SET `F_Fixed` = @F_Fixed";
			var parameter_ = Database.CreateInParameter("@F_Fixed", f_Fixed.HasValue ? f_Fixed.Value : (object)DBNull.Value, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutF_Fixed
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Demo_userEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.UserID) == null)
			{
				Add(item, tm);
			}
			else
			{
				Put(item, tm);
				ret = false;
			}
			return ret;
		}
		
		#endregion // Set
		
		#region Get
	
		#region GetByPK
		/// <summary>
		/// 按 PK（主键） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Demo_userEO GetByPK(long userID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
		#region GetByFK
	
		#endregion // GetByFK
	
		#region GetByXXX
	
		#region GetByClassID
		
		/// <summary>
		/// 按 ClassID（字段） 查询
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByClassID(string classID)
		{
			return GetByClassID(classID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ClassID（字段） 查询
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByClassID(string classID, TransactionManager tm_)
		{
			return GetByClassID(classID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ClassID（字段） 查询
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByClassID(string classID, int top_)
		{
			return GetByClassID(classID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ClassID（字段） 查询
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByClassID(string classID, int top_, TransactionManager tm_)
		{
			return GetByClassID(classID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ClassID（字段） 查询
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByClassID(string classID, string sort_)
		{
			return GetByClassID(classID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ClassID（字段） 查询
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByClassID(string classID, string sort_, TransactionManager tm_)
		{
			return GetByClassID(classID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ClassID（字段） 查询
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByClassID(string classID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(classID != null ? "`ClassID` = @ClassID" : "`ClassID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (classID != null)
				paras_.Add(Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByClassID
	
		#region GetByFBit
		
		/// <summary>
		/// 按 FBit（字段） 查询
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit(int fBit)
		{
			return GetByFBit(fBit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBit（字段） 查询
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit(int fBit, TransactionManager tm_)
		{
			return GetByFBit(fBit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBit（字段） 查询
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit(int fBit, int top_)
		{
			return GetByFBit(fBit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBit（字段） 查询
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit(int fBit, int top_, TransactionManager tm_)
		{
			return GetByFBit(fBit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBit（字段） 查询
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit(int fBit, string sort_)
		{
			return GetByFBit(fBit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBit（字段） 查询
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit(int fBit, string sort_, TransactionManager tm_)
		{
			return GetByFBit(fBit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBit（字段） 查询
		/// </summary>
		/// /// <param name = "fBit">字段1</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit(int fBit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FBit` = @FBit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FBit", fBit, MySqlDbType.Bit));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBit
	
		#region GetByFBit_Max
		
		/// <summary>
		/// 按 FBit_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit_Max(int? fBit_Max)
		{
			return GetByFBit_Max(fBit_Max, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBit_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit_Max(int? fBit_Max, TransactionManager tm_)
		{
			return GetByFBit_Max(fBit_Max, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBit_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit_Max(int? fBit_Max, int top_)
		{
			return GetByFBit_Max(fBit_Max, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBit_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit_Max(int? fBit_Max, int top_, TransactionManager tm_)
		{
			return GetByFBit_Max(fBit_Max, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBit_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit_Max(int? fBit_Max, string sort_)
		{
			return GetByFBit_Max(fBit_Max, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBit_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit_Max(int? fBit_Max, string sort_, TransactionManager tm_)
		{
			return GetByFBit_Max(fBit_Max, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBit_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fBit_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBit_Max(int? fBit_Max, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fBit_Max.HasValue ? "`FBit_Max` = @FBit_Max" : "`FBit_Max` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fBit_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FBit_Max", fBit_Max.Value, MySqlDbType.Bit));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBit_Max
	
		#region GetByFTinyInt
		
		/// <summary>
		/// 按 FTinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt(int fTinyInt)
		{
			return GetByFTinyInt(fTinyInt, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt(int fTinyInt, TransactionManager tm_)
		{
			return GetByFTinyInt(fTinyInt, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt(int fTinyInt, int top_)
		{
			return GetByFTinyInt(fTinyInt, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt(int fTinyInt, int top_, TransactionManager tm_)
		{
			return GetByFTinyInt(fTinyInt, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt(int fTinyInt, string sort_)
		{
			return GetByFTinyInt(fTinyInt, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FTinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt(int fTinyInt, string sort_, TransactionManager tm_)
		{
			return GetByFTinyInt(fTinyInt, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FTinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt(int fTinyInt, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FTinyInt` = @FTinyInt", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FTinyInt", fTinyInt, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFTinyInt
	
		#region GetByFTinyInt_Unsigned
		
		/// <summary>
		/// 按 FTinyInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt_Unsigned(int? fTinyInt_Unsigned)
		{
			return GetByFTinyInt_Unsigned(fTinyInt_Unsigned, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt_Unsigned(int? fTinyInt_Unsigned, TransactionManager tm_)
		{
			return GetByFTinyInt_Unsigned(fTinyInt_Unsigned, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt_Unsigned(int? fTinyInt_Unsigned, int top_)
		{
			return GetByFTinyInt_Unsigned(fTinyInt_Unsigned, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt_Unsigned(int? fTinyInt_Unsigned, int top_, TransactionManager tm_)
		{
			return GetByFTinyInt_Unsigned(fTinyInt_Unsigned, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt_Unsigned(int? fTinyInt_Unsigned, string sort_)
		{
			return GetByFTinyInt_Unsigned(fTinyInt_Unsigned, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FTinyInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt_Unsigned(int? fTinyInt_Unsigned, string sort_, TransactionManager tm_)
		{
			return GetByFTinyInt_Unsigned(fTinyInt_Unsigned, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FTinyInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyInt_Unsigned(int? fTinyInt_Unsigned, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fTinyInt_Unsigned.HasValue ? "`FTinyInt_Unsigned` = @FTinyInt_Unsigned" : "`FTinyInt_Unsigned` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fTinyInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FTinyInt_Unsigned", fTinyInt_Unsigned.Value, MySqlDbType.UByte));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFTinyInt_Unsigned
	
		#region GetByFBool
		
		/// <summary>
		/// 按 FBool（字段） 查询
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool(bool? fBool)
		{
			return GetByFBool(fBool, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBool（字段） 查询
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool(bool? fBool, TransactionManager tm_)
		{
			return GetByFBool(fBool, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBool（字段） 查询
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool(bool? fBool, int top_)
		{
			return GetByFBool(fBool, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBool（字段） 查询
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool(bool? fBool, int top_, TransactionManager tm_)
		{
			return GetByFBool(fBool, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBool（字段） 查询
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool(bool? fBool, string sort_)
		{
			return GetByFBool(fBool, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBool（字段） 查询
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool(bool? fBool, string sort_, TransactionManager tm_)
		{
			return GetByFBool(fBool, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBool（字段） 查询
		/// </summary>
		/// /// <param name = "fBool"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool(bool? fBool, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fBool.HasValue ? "`FBool` = @FBool" : "`FBool` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fBool.HasValue)
				paras_.Add(Database.CreateInParameter("@FBool", fBool.Value, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBool
	
		#region GetByF_Boolean
		
		/// <summary>
		/// 按 F_Boolean（字段） 查询
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Boolean(bool f_Boolean)
		{
			return GetByF_Boolean(f_Boolean, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Boolean（字段） 查询
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Boolean(bool f_Boolean, TransactionManager tm_)
		{
			return GetByF_Boolean(f_Boolean, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Boolean（字段） 查询
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Boolean(bool f_Boolean, int top_)
		{
			return GetByF_Boolean(f_Boolean, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Boolean（字段） 查询
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Boolean(bool f_Boolean, int top_, TransactionManager tm_)
		{
			return GetByF_Boolean(f_Boolean, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Boolean（字段） 查询
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Boolean(bool f_Boolean, string sort_)
		{
			return GetByF_Boolean(f_Boolean, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 F_Boolean（字段） 查询
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Boolean(bool f_Boolean, string sort_, TransactionManager tm_)
		{
			return GetByF_Boolean(f_Boolean, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 F_Boolean（字段） 查询
		/// </summary>
		/// /// <param name = "f_Boolean"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Boolean(bool f_Boolean, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`F_Boolean` = @F_Boolean", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@F_Boolean", f_Boolean, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByF_Boolean
	
		#region GetByFBool_TinyInt
		
		/// <summary>
		/// 按 FBool_TinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool_TinyInt(bool? fBool_TinyInt)
		{
			return GetByFBool_TinyInt(fBool_TinyInt, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBool_TinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool_TinyInt(bool? fBool_TinyInt, TransactionManager tm_)
		{
			return GetByFBool_TinyInt(fBool_TinyInt, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBool_TinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool_TinyInt(bool? fBool_TinyInt, int top_)
		{
			return GetByFBool_TinyInt(fBool_TinyInt, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBool_TinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool_TinyInt(bool? fBool_TinyInt, int top_, TransactionManager tm_)
		{
			return GetByFBool_TinyInt(fBool_TinyInt, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBool_TinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool_TinyInt(bool? fBool_TinyInt, string sort_)
		{
			return GetByFBool_TinyInt(fBool_TinyInt, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBool_TinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool_TinyInt(bool? fBool_TinyInt, string sort_, TransactionManager tm_)
		{
			return GetByFBool_TinyInt(fBool_TinyInt, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBool_TinyInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBool_TinyInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBool_TinyInt(bool? fBool_TinyInt, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fBool_TinyInt.HasValue ? "`FBool_TinyInt` = @FBool_TinyInt" : "`FBool_TinyInt` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fBool_TinyInt.HasValue)
				paras_.Add(Database.CreateInParameter("@FBool_TinyInt", fBool_TinyInt.Value, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBool_TinyInt
	
		#region GetByFSmallInt
		
		/// <summary>
		/// 按 FSmallInt（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt(int fSmallInt)
		{
			return GetByFSmallInt(fSmallInt, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FSmallInt（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt(int fSmallInt, TransactionManager tm_)
		{
			return GetByFSmallInt(fSmallInt, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FSmallInt（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt(int fSmallInt, int top_)
		{
			return GetByFSmallInt(fSmallInt, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FSmallInt（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt(int fSmallInt, int top_, TransactionManager tm_)
		{
			return GetByFSmallInt(fSmallInt, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FSmallInt（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt(int fSmallInt, string sort_)
		{
			return GetByFSmallInt(fSmallInt, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FSmallInt（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt(int fSmallInt, string sort_, TransactionManager tm_)
		{
			return GetByFSmallInt(fSmallInt, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FSmallInt（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt(int fSmallInt, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FSmallInt` = @FSmallInt", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FSmallInt", fSmallInt, MySqlDbType.Int16));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFSmallInt
	
		#region GetByFSmallInt_Unsigned
		
		/// <summary>
		/// 按 FSmallInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt_Unsigned(int? fSmallInt_Unsigned)
		{
			return GetByFSmallInt_Unsigned(fSmallInt_Unsigned, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FSmallInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt_Unsigned(int? fSmallInt_Unsigned, TransactionManager tm_)
		{
			return GetByFSmallInt_Unsigned(fSmallInt_Unsigned, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FSmallInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt_Unsigned(int? fSmallInt_Unsigned, int top_)
		{
			return GetByFSmallInt_Unsigned(fSmallInt_Unsigned, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FSmallInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt_Unsigned(int? fSmallInt_Unsigned, int top_, TransactionManager tm_)
		{
			return GetByFSmallInt_Unsigned(fSmallInt_Unsigned, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FSmallInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt_Unsigned(int? fSmallInt_Unsigned, string sort_)
		{
			return GetByFSmallInt_Unsigned(fSmallInt_Unsigned, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FSmallInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt_Unsigned(int? fSmallInt_Unsigned, string sort_, TransactionManager tm_)
		{
			return GetByFSmallInt_Unsigned(fSmallInt_Unsigned, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FSmallInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fSmallInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSmallInt_Unsigned(int? fSmallInt_Unsigned, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fSmallInt_Unsigned.HasValue ? "`FSmallInt_Unsigned` = @FSmallInt_Unsigned" : "`FSmallInt_Unsigned` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fSmallInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FSmallInt_Unsigned", fSmallInt_Unsigned.Value, MySqlDbType.UInt16));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFSmallInt_Unsigned
	
		#region GetByFMediumInt
		
		/// <summary>
		/// 按 FMediumInt（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt(int fMediumInt)
		{
			return GetByFMediumInt(fMediumInt, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumInt（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt(int fMediumInt, TransactionManager tm_)
		{
			return GetByFMediumInt(fMediumInt, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumInt（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt(int fMediumInt, int top_)
		{
			return GetByFMediumInt(fMediumInt, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumInt（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt(int fMediumInt, int top_, TransactionManager tm_)
		{
			return GetByFMediumInt(fMediumInt, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumInt（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt(int fMediumInt, string sort_)
		{
			return GetByFMediumInt(fMediumInt, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FMediumInt（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt(int fMediumInt, string sort_, TransactionManager tm_)
		{
			return GetByFMediumInt(fMediumInt, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FMediumInt（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt(int fMediumInt, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FMediumInt` = @FMediumInt", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FMediumInt", fMediumInt, MySqlDbType.Int24));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFMediumInt
	
		#region GetByFMediumInt_Unsigned
		
		/// <summary>
		/// 按 FMediumInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt_Unsigned(int? fMediumInt_Unsigned)
		{
			return GetByFMediumInt_Unsigned(fMediumInt_Unsigned, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt_Unsigned(int? fMediumInt_Unsigned, TransactionManager tm_)
		{
			return GetByFMediumInt_Unsigned(fMediumInt_Unsigned, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt_Unsigned(int? fMediumInt_Unsigned, int top_)
		{
			return GetByFMediumInt_Unsigned(fMediumInt_Unsigned, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt_Unsigned(int? fMediumInt_Unsigned, int top_, TransactionManager tm_)
		{
			return GetByFMediumInt_Unsigned(fMediumInt_Unsigned, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt_Unsigned(int? fMediumInt_Unsigned, string sort_)
		{
			return GetByFMediumInt_Unsigned(fMediumInt_Unsigned, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FMediumInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt_Unsigned(int? fMediumInt_Unsigned, string sort_, TransactionManager tm_)
		{
			return GetByFMediumInt_Unsigned(fMediumInt_Unsigned, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FMediumInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumInt_Unsigned(int? fMediumInt_Unsigned, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fMediumInt_Unsigned.HasValue ? "`FMediumInt_Unsigned` = @FMediumInt_Unsigned" : "`FMediumInt_Unsigned` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fMediumInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FMediumInt_Unsigned", fMediumInt_Unsigned.Value, MySqlDbType.UInt24));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFMediumInt_Unsigned
	
		#region GetByFInt
		
		/// <summary>
		/// 按 FInt（字段） 查询
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt(int fInt)
		{
			return GetByFInt(fInt, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FInt（字段） 查询
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt(int fInt, TransactionManager tm_)
		{
			return GetByFInt(fInt, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FInt（字段） 查询
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt(int fInt, int top_)
		{
			return GetByFInt(fInt, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FInt（字段） 查询
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt(int fInt, int top_, TransactionManager tm_)
		{
			return GetByFInt(fInt, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FInt（字段） 查询
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt(int fInt, string sort_)
		{
			return GetByFInt(fInt, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FInt（字段） 查询
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt(int fInt, string sort_, TransactionManager tm_)
		{
			return GetByFInt(fInt, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FInt（字段） 查询
		/// </summary>
		/// /// <param name = "fInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt(int fInt, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FInt` = @FInt", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FInt", fInt, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFInt
	
		#region GetByFInt_Unsigned
		
		/// <summary>
		/// 按 FInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt_Unsigned(long? fInt_Unsigned)
		{
			return GetByFInt_Unsigned(fInt_Unsigned, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt_Unsigned(long? fInt_Unsigned, TransactionManager tm_)
		{
			return GetByFInt_Unsigned(fInt_Unsigned, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt_Unsigned(long? fInt_Unsigned, int top_)
		{
			return GetByFInt_Unsigned(fInt_Unsigned, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt_Unsigned(long? fInt_Unsigned, int top_, TransactionManager tm_)
		{
			return GetByFInt_Unsigned(fInt_Unsigned, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt_Unsigned(long? fInt_Unsigned, string sort_)
		{
			return GetByFInt_Unsigned(fInt_Unsigned, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt_Unsigned(long? fInt_Unsigned, string sort_, TransactionManager tm_)
		{
			return GetByFInt_Unsigned(fInt_Unsigned, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFInt_Unsigned(long? fInt_Unsigned, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fInt_Unsigned.HasValue ? "`FInt_Unsigned` = @FInt_Unsigned" : "`FInt_Unsigned` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FInt_Unsigned", fInt_Unsigned.Value, MySqlDbType.UInt32));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFInt_Unsigned
	
		#region GetByF_Integer
		
		/// <summary>
		/// 按 F_Integer（字段） 查询
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Integer(int? f_Integer)
		{
			return GetByF_Integer(f_Integer, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Integer（字段） 查询
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Integer(int? f_Integer, TransactionManager tm_)
		{
			return GetByF_Integer(f_Integer, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Integer（字段） 查询
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Integer(int? f_Integer, int top_)
		{
			return GetByF_Integer(f_Integer, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Integer（字段） 查询
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Integer(int? f_Integer, int top_, TransactionManager tm_)
		{
			return GetByF_Integer(f_Integer, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Integer（字段） 查询
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Integer(int? f_Integer, string sort_)
		{
			return GetByF_Integer(f_Integer, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 F_Integer（字段） 查询
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Integer(int? f_Integer, string sort_, TransactionManager tm_)
		{
			return GetByF_Integer(f_Integer, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 F_Integer（字段） 查询
		/// </summary>
		/// /// <param name = "f_Integer"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Integer(int? f_Integer, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(f_Integer.HasValue ? "`F_Integer` = @F_Integer" : "`F_Integer` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (f_Integer.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Integer", f_Integer.Value, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByF_Integer
	
		#region GetByFBigInt
		
		/// <summary>
		/// 按 FBigInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt(long fBigInt)
		{
			return GetByFBigInt(fBigInt, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBigInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt(long fBigInt, TransactionManager tm_)
		{
			return GetByFBigInt(fBigInt, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBigInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt(long fBigInt, int top_)
		{
			return GetByFBigInt(fBigInt, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBigInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt(long fBigInt, int top_, TransactionManager tm_)
		{
			return GetByFBigInt(fBigInt, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBigInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt(long fBigInt, string sort_)
		{
			return GetByFBigInt(fBigInt, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBigInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt(long fBigInt, string sort_, TransactionManager tm_)
		{
			return GetByFBigInt(fBigInt, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBigInt（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt(long fBigInt, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FBigInt` = @FBigInt", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FBigInt", fBigInt, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBigInt
	
		#region GetByFBigInt_Unsigned
		
		/// <summary>
		/// 按 FBigInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt_Unsigned(ulong? fBigInt_Unsigned)
		{
			return GetByFBigInt_Unsigned(fBigInt_Unsigned, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBigInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt_Unsigned(ulong? fBigInt_Unsigned, TransactionManager tm_)
		{
			return GetByFBigInt_Unsigned(fBigInt_Unsigned, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBigInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt_Unsigned(ulong? fBigInt_Unsigned, int top_)
		{
			return GetByFBigInt_Unsigned(fBigInt_Unsigned, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBigInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt_Unsigned(ulong? fBigInt_Unsigned, int top_, TransactionManager tm_)
		{
			return GetByFBigInt_Unsigned(fBigInt_Unsigned, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBigInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt_Unsigned(ulong? fBigInt_Unsigned, string sort_)
		{
			return GetByFBigInt_Unsigned(fBigInt_Unsigned, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBigInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt_Unsigned(ulong? fBigInt_Unsigned, string sort_, TransactionManager tm_)
		{
			return GetByFBigInt_Unsigned(fBigInt_Unsigned, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBigInt_Unsigned（字段） 查询
		/// </summary>
		/// /// <param name = "fBigInt_Unsigned"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBigInt_Unsigned(ulong? fBigInt_Unsigned, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fBigInt_Unsigned.HasValue ? "`FBigInt_Unsigned` = @FBigInt_Unsigned" : "`FBigInt_Unsigned` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fBigInt_Unsigned.HasValue)
				paras_.Add(Database.CreateInParameter("@FBigInt_Unsigned", fBigInt_Unsigned.Value, MySqlDbType.UInt64));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBigInt_Unsigned
	
		#region GetByFFloat
		
		/// <summary>
		/// 按 FFloat（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat(float fFloat)
		{
			return GetByFFloat(fFloat, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FFloat（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat(float fFloat, TransactionManager tm_)
		{
			return GetByFFloat(fFloat, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FFloat（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat(float fFloat, int top_)
		{
			return GetByFFloat(fFloat, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FFloat（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat(float fFloat, int top_, TransactionManager tm_)
		{
			return GetByFFloat(fFloat, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FFloat（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat(float fFloat, string sort_)
		{
			return GetByFFloat(fFloat, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FFloat（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat(float fFloat, string sort_, TransactionManager tm_)
		{
			return GetByFFloat(fFloat, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FFloat（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat(float fFloat, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FFloat` = @FFloat", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FFloat", fFloat, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFFloat
	
		#region GetByFFloat_Max
		
		/// <summary>
		/// 按 FFloat_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat_Max(float? fFloat_Max)
		{
			return GetByFFloat_Max(fFloat_Max, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FFloat_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat_Max(float? fFloat_Max, TransactionManager tm_)
		{
			return GetByFFloat_Max(fFloat_Max, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FFloat_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat_Max(float? fFloat_Max, int top_)
		{
			return GetByFFloat_Max(fFloat_Max, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FFloat_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat_Max(float? fFloat_Max, int top_, TransactionManager tm_)
		{
			return GetByFFloat_Max(fFloat_Max, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FFloat_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat_Max(float? fFloat_Max, string sort_)
		{
			return GetByFFloat_Max(fFloat_Max, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FFloat_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat_Max(float? fFloat_Max, string sort_, TransactionManager tm_)
		{
			return GetByFFloat_Max(fFloat_Max, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FFloat_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fFloat_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFFloat_Max(float? fFloat_Max, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fFloat_Max.HasValue ? "`FFloat_Max` = @FFloat_Max" : "`FFloat_Max` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fFloat_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FFloat_Max", fFloat_Max.Value, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFFloat_Max
	
		#region GetByFDouble
		
		/// <summary>
		/// 按 FDouble（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble(double fDouble)
		{
			return GetByFDouble(fDouble, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDouble（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble(double fDouble, TransactionManager tm_)
		{
			return GetByFDouble(fDouble, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDouble（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble(double fDouble, int top_)
		{
			return GetByFDouble(fDouble, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDouble（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble(double fDouble, int top_, TransactionManager tm_)
		{
			return GetByFDouble(fDouble, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDouble（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble(double fDouble, string sort_)
		{
			return GetByFDouble(fDouble, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FDouble（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble(double fDouble, string sort_, TransactionManager tm_)
		{
			return GetByFDouble(fDouble, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FDouble（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble(double fDouble, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FDouble` = @FDouble", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FDouble", fDouble, MySqlDbType.Double));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFDouble
	
		#region GetByFDouble_Max
		
		/// <summary>
		/// 按 FDouble_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble_Max(double? fDouble_Max)
		{
			return GetByFDouble_Max(fDouble_Max, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDouble_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble_Max(double? fDouble_Max, TransactionManager tm_)
		{
			return GetByFDouble_Max(fDouble_Max, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDouble_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble_Max(double? fDouble_Max, int top_)
		{
			return GetByFDouble_Max(fDouble_Max, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDouble_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble_Max(double? fDouble_Max, int top_, TransactionManager tm_)
		{
			return GetByFDouble_Max(fDouble_Max, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDouble_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble_Max(double? fDouble_Max, string sort_)
		{
			return GetByFDouble_Max(fDouble_Max, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FDouble_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble_Max(double? fDouble_Max, string sort_, TransactionManager tm_)
		{
			return GetByFDouble_Max(fDouble_Max, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FDouble_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDouble_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDouble_Max(double? fDouble_Max, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fDouble_Max.HasValue ? "`FDouble_Max` = @FDouble_Max" : "`FDouble_Max` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fDouble_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FDouble_Max", fDouble_Max.Value, MySqlDbType.Double));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFDouble_Max
	
		#region GetByF_Real
		
		/// <summary>
		/// 按 F_Real（字段） 查询
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Real(double? f_Real)
		{
			return GetByF_Real(f_Real, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Real（字段） 查询
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Real(double? f_Real, TransactionManager tm_)
		{
			return GetByF_Real(f_Real, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Real（字段） 查询
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Real(double? f_Real, int top_)
		{
			return GetByF_Real(f_Real, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Real（字段） 查询
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Real(double? f_Real, int top_, TransactionManager tm_)
		{
			return GetByF_Real(f_Real, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Real（字段） 查询
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Real(double? f_Real, string sort_)
		{
			return GetByF_Real(f_Real, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 F_Real（字段） 查询
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Real(double? f_Real, string sort_, TransactionManager tm_)
		{
			return GetByF_Real(f_Real, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 F_Real（字段） 查询
		/// </summary>
		/// /// <param name = "f_Real"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Real(double? f_Real, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(f_Real.HasValue ? "`F_Real` = @F_Real" : "`F_Real` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (f_Real.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Real", f_Real.Value, MySqlDbType.Double));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByF_Real
	
		#region GetByF_Double_Precision
		
		/// <summary>
		/// 按 F_Double_Precision（字段） 查询
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Double_Precision(double? f_Double_Precision)
		{
			return GetByF_Double_Precision(f_Double_Precision, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Double_Precision（字段） 查询
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Double_Precision(double? f_Double_Precision, TransactionManager tm_)
		{
			return GetByF_Double_Precision(f_Double_Precision, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Double_Precision（字段） 查询
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Double_Precision(double? f_Double_Precision, int top_)
		{
			return GetByF_Double_Precision(f_Double_Precision, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Double_Precision（字段） 查询
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Double_Precision(double? f_Double_Precision, int top_, TransactionManager tm_)
		{
			return GetByF_Double_Precision(f_Double_Precision, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Double_Precision（字段） 查询
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Double_Precision(double? f_Double_Precision, string sort_)
		{
			return GetByF_Double_Precision(f_Double_Precision, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 F_Double_Precision（字段） 查询
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Double_Precision(double? f_Double_Precision, string sort_, TransactionManager tm_)
		{
			return GetByF_Double_Precision(f_Double_Precision, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 F_Double_Precision（字段） 查询
		/// </summary>
		/// /// <param name = "f_Double_Precision"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Double_Precision(double? f_Double_Precision, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(f_Double_Precision.HasValue ? "`F_Double_Precision` = @F_Double_Precision" : "`F_Double_Precision` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (f_Double_Precision.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Double_Precision", f_Double_Precision.Value, MySqlDbType.Double));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByF_Double_Precision
	
		#region GetByFYear
		
		/// <summary>
		/// 按 FYear（字段） 查询
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFYear(int? fYear)
		{
			return GetByFYear(fYear, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FYear（字段） 查询
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFYear(int? fYear, TransactionManager tm_)
		{
			return GetByFYear(fYear, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FYear（字段） 查询
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFYear(int? fYear, int top_)
		{
			return GetByFYear(fYear, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FYear（字段） 查询
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFYear(int? fYear, int top_, TransactionManager tm_)
		{
			return GetByFYear(fYear, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FYear（字段） 查询
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFYear(int? fYear, string sort_)
		{
			return GetByFYear(fYear, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FYear（字段） 查询
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFYear(int? fYear, string sort_, TransactionManager tm_)
		{
			return GetByFYear(fYear, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FYear（字段） 查询
		/// </summary>
		/// /// <param name = "fYear"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFYear(int? fYear, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fYear.HasValue ? "`FYear` = @FYear" : "`FYear` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fYear.HasValue)
				paras_.Add(Database.CreateInParameter("@FYear", fYear.Value, MySqlDbType.Year));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFYear
	
		#region GetByFDate
		
		/// <summary>
		/// 按 FDate（字段） 查询
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDate(DateTime? fDate)
		{
			return GetByFDate(fDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDate（字段） 查询
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDate(DateTime? fDate, TransactionManager tm_)
		{
			return GetByFDate(fDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDate（字段） 查询
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDate(DateTime? fDate, int top_)
		{
			return GetByFDate(fDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDate（字段） 查询
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDate(DateTime? fDate, int top_, TransactionManager tm_)
		{
			return GetByFDate(fDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDate（字段） 查询
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDate(DateTime? fDate, string sort_)
		{
			return GetByFDate(fDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FDate（字段） 查询
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDate(DateTime? fDate, string sort_, TransactionManager tm_)
		{
			return GetByFDate(fDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FDate（字段） 查询
		/// </summary>
		/// /// <param name = "fDate"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDate(DateTime? fDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fDate.HasValue ? "`FDate` = @FDate" : "`FDate` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fDate.HasValue)
				paras_.Add(Database.CreateInParameter("@FDate", fDate.Value, MySqlDbType.Date));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFDate
	
		#region GetByFTime
		
		/// <summary>
		/// 按 FTime（字段） 查询
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTime(TimeSpan? fTime)
		{
			return GetByFTime(fTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTime（字段） 查询
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTime(TimeSpan? fTime, TransactionManager tm_)
		{
			return GetByFTime(fTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTime（字段） 查询
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTime(TimeSpan? fTime, int top_)
		{
			return GetByFTime(fTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTime（字段） 查询
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTime(TimeSpan? fTime, int top_, TransactionManager tm_)
		{
			return GetByFTime(fTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTime（字段） 查询
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTime(TimeSpan? fTime, string sort_)
		{
			return GetByFTime(fTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FTime（字段） 查询
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTime(TimeSpan? fTime, string sort_, TransactionManager tm_)
		{
			return GetByFTime(fTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FTime（字段） 查询
		/// </summary>
		/// /// <param name = "fTime"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTime(TimeSpan? fTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fTime.HasValue ? "`FTime` = @FTime" : "`FTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fTime.HasValue)
				paras_.Add(Database.CreateInParameter("@FTime", fTime.Value, MySqlDbType.Time));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFTime
	
		#region GetByFTimestamp
		
		/// <summary>
		/// 按 FTimestamp（字段） 查询
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTimestamp(DateTime fTimestamp)
		{
			return GetByFTimestamp(fTimestamp, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTimestamp（字段） 查询
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTimestamp(DateTime fTimestamp, TransactionManager tm_)
		{
			return GetByFTimestamp(fTimestamp, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTimestamp（字段） 查询
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTimestamp(DateTime fTimestamp, int top_)
		{
			return GetByFTimestamp(fTimestamp, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTimestamp（字段） 查询
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTimestamp(DateTime fTimestamp, int top_, TransactionManager tm_)
		{
			return GetByFTimestamp(fTimestamp, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTimestamp（字段） 查询
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTimestamp(DateTime fTimestamp, string sort_)
		{
			return GetByFTimestamp(fTimestamp, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FTimestamp（字段） 查询
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTimestamp(DateTime fTimestamp, string sort_, TransactionManager tm_)
		{
			return GetByFTimestamp(fTimestamp, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FTimestamp（字段） 查询
		/// </summary>
		/// /// <param name = "fTimestamp"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTimestamp(DateTime fTimestamp, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FTimestamp` = @FTimestamp", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FTimestamp", fTimestamp, MySqlDbType.Timestamp));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFTimestamp
	
		#region GetByFDateTime
		
		/// <summary>
		/// 按 FDateTime（字段） 查询
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDateTime(DateTime? fDateTime)
		{
			return GetByFDateTime(fDateTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDateTime（字段） 查询
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDateTime(DateTime? fDateTime, TransactionManager tm_)
		{
			return GetByFDateTime(fDateTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDateTime（字段） 查询
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDateTime(DateTime? fDateTime, int top_)
		{
			return GetByFDateTime(fDateTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDateTime（字段） 查询
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDateTime(DateTime? fDateTime, int top_, TransactionManager tm_)
		{
			return GetByFDateTime(fDateTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDateTime（字段） 查询
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDateTime(DateTime? fDateTime, string sort_)
		{
			return GetByFDateTime(fDateTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FDateTime（字段） 查询
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDateTime(DateTime? fDateTime, string sort_, TransactionManager tm_)
		{
			return GetByFDateTime(fDateTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FDateTime（字段） 查询
		/// </summary>
		/// /// <param name = "fDateTime"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDateTime(DateTime? fDateTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fDateTime.HasValue ? "`FDateTime` = @FDateTime" : "`FDateTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fDateTime.HasValue)
				paras_.Add(Database.CreateInParameter("@FDateTime", fDateTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFDateTime
	
		#region GetByFChar
		
		/// <summary>
		/// 按 FChar（字段） 查询
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFChar(string fChar)
		{
			return GetByFChar(fChar, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FChar（字段） 查询
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFChar(string fChar, TransactionManager tm_)
		{
			return GetByFChar(fChar, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FChar（字段） 查询
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFChar(string fChar, int top_)
		{
			return GetByFChar(fChar, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FChar（字段） 查询
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFChar(string fChar, int top_, TransactionManager tm_)
		{
			return GetByFChar(fChar, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FChar（字段） 查询
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFChar(string fChar, string sort_)
		{
			return GetByFChar(fChar, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FChar（字段） 查询
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFChar(string fChar, string sort_, TransactionManager tm_)
		{
			return GetByFChar(fChar, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FChar（字段） 查询
		/// </summary>
		/// /// <param name = "fChar"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFChar(string fChar, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fChar != null ? "`FChar` = @FChar" : "`FChar` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fChar != null)
				paras_.Add(Database.CreateInParameter("@FChar", fChar, MySqlDbType.String));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFChar
	
		#region GetByFVarChar
		
		/// <summary>
		/// 按 FVarChar（字段） 查询
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarChar(string fVarChar)
		{
			return GetByFVarChar(fVarChar, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FVarChar（字段） 查询
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarChar(string fVarChar, TransactionManager tm_)
		{
			return GetByFVarChar(fVarChar, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FVarChar（字段） 查询
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarChar(string fVarChar, int top_)
		{
			return GetByFVarChar(fVarChar, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FVarChar（字段） 查询
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarChar(string fVarChar, int top_, TransactionManager tm_)
		{
			return GetByFVarChar(fVarChar, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FVarChar（字段） 查询
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarChar(string fVarChar, string sort_)
		{
			return GetByFVarChar(fVarChar, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FVarChar（字段） 查询
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarChar(string fVarChar, string sort_, TransactionManager tm_)
		{
			return GetByFVarChar(fVarChar, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FVarChar（字段） 查询
		/// </summary>
		/// /// <param name = "fVarChar"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarChar(string fVarChar, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fVarChar != null ? "`FVarChar` = @FVarChar" : "`FVarChar` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fVarChar != null)
				paras_.Add(Database.CreateInParameter("@FVarChar", fVarChar, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFVarChar
	
		#region GetByFBinary
		
		/// <summary>
		/// 按 FBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBinary(byte[] fBinary)
		{
			return GetByFBinary(fBinary, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBinary(byte[] fBinary, TransactionManager tm_)
		{
			return GetByFBinary(fBinary, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBinary(byte[] fBinary, int top_)
		{
			return GetByFBinary(fBinary, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBinary(byte[] fBinary, int top_, TransactionManager tm_)
		{
			return GetByFBinary(fBinary, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBinary(byte[] fBinary, string sort_)
		{
			return GetByFBinary(fBinary, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBinary(byte[] fBinary, string sort_, TransactionManager tm_)
		{
			return GetByFBinary(fBinary, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fBinary"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBinary(byte[] fBinary, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fBinary != null ? "`FBinary` = @FBinary" : "`FBinary` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fBinary != null)
				paras_.Add(Database.CreateInParameter("@FBinary", fBinary, MySqlDbType.Binary));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBinary
	
		#region GetByFVarBinary
		
		/// <summary>
		/// 按 FVarBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarBinary(byte[] fVarBinary)
		{
			return GetByFVarBinary(fVarBinary, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FVarBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarBinary(byte[] fVarBinary, TransactionManager tm_)
		{
			return GetByFVarBinary(fVarBinary, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FVarBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarBinary(byte[] fVarBinary, int top_)
		{
			return GetByFVarBinary(fVarBinary, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FVarBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarBinary(byte[] fVarBinary, int top_, TransactionManager tm_)
		{
			return GetByFVarBinary(fVarBinary, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FVarBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarBinary(byte[] fVarBinary, string sort_)
		{
			return GetByFVarBinary(fVarBinary, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FVarBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarBinary(byte[] fVarBinary, string sort_, TransactionManager tm_)
		{
			return GetByFVarBinary(fVarBinary, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FVarBinary（字段） 查询
		/// </summary>
		/// /// <param name = "fVarBinary"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFVarBinary(byte[] fVarBinary, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fVarBinary != null ? "`FVarBinary` = @FVarBinary" : "`FVarBinary` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fVarBinary != null)
				paras_.Add(Database.CreateInParameter("@FVarBinary", fVarBinary, MySqlDbType.VarBinary));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFVarBinary
	
		#region GetByFTinyText
		
		/// <summary>
		/// 按 FTinyText（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyText(string fTinyText)
		{
			return GetByFTinyText(fTinyText, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyText（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyText(string fTinyText, TransactionManager tm_)
		{
			return GetByFTinyText(fTinyText, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyText（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyText(string fTinyText, int top_)
		{
			return GetByFTinyText(fTinyText, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyText（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyText(string fTinyText, int top_, TransactionManager tm_)
		{
			return GetByFTinyText(fTinyText, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyText（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyText(string fTinyText, string sort_)
		{
			return GetByFTinyText(fTinyText, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FTinyText（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyText(string fTinyText, string sort_, TransactionManager tm_)
		{
			return GetByFTinyText(fTinyText, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FTinyText（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyText(string fTinyText, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fTinyText != null ? "`FTinyText` = @FTinyText" : "`FTinyText` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fTinyText != null)
				paras_.Add(Database.CreateInParameter("@FTinyText", fTinyText, MySqlDbType.TinyText));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFTinyText
	
		#region GetByFText
		
		/// <summary>
		/// 按 FText（字段） 查询
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFText(string fText)
		{
			return GetByFText(fText, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FText（字段） 查询
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFText(string fText, TransactionManager tm_)
		{
			return GetByFText(fText, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FText（字段） 查询
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFText(string fText, int top_)
		{
			return GetByFText(fText, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FText（字段） 查询
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFText(string fText, int top_, TransactionManager tm_)
		{
			return GetByFText(fText, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FText（字段） 查询
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFText(string fText, string sort_)
		{
			return GetByFText(fText, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FText（字段） 查询
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFText(string fText, string sort_, TransactionManager tm_)
		{
			return GetByFText(fText, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FText（字段） 查询
		/// </summary>
		/// /// <param name = "fText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFText(string fText, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fText != null ? "`FText` = @FText" : "`FText` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fText != null)
				paras_.Add(Database.CreateInParameter("@FText", fText, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFText
	
		#region GetByFMediumText
		
		/// <summary>
		/// 按 FMediumText（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumText(string fMediumText)
		{
			return GetByFMediumText(fMediumText, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumText（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumText(string fMediumText, TransactionManager tm_)
		{
			return GetByFMediumText(fMediumText, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumText（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumText(string fMediumText, int top_)
		{
			return GetByFMediumText(fMediumText, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumText（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumText(string fMediumText, int top_, TransactionManager tm_)
		{
			return GetByFMediumText(fMediumText, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumText（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumText(string fMediumText, string sort_)
		{
			return GetByFMediumText(fMediumText, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FMediumText（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumText(string fMediumText, string sort_, TransactionManager tm_)
		{
			return GetByFMediumText(fMediumText, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FMediumText（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumText(string fMediumText, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fMediumText != null ? "`FMediumText` = @FMediumText" : "`FMediumText` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fMediumText != null)
				paras_.Add(Database.CreateInParameter("@FMediumText", fMediumText, MySqlDbType.MediumText));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFMediumText
	
		#region GetByFLongText
		
		/// <summary>
		/// 按 FLongText（字段） 查询
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongText(string fLongText)
		{
			return GetByFLongText(fLongText, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FLongText（字段） 查询
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongText(string fLongText, TransactionManager tm_)
		{
			return GetByFLongText(fLongText, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FLongText（字段） 查询
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongText(string fLongText, int top_)
		{
			return GetByFLongText(fLongText, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FLongText（字段） 查询
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongText(string fLongText, int top_, TransactionManager tm_)
		{
			return GetByFLongText(fLongText, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FLongText（字段） 查询
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongText(string fLongText, string sort_)
		{
			return GetByFLongText(fLongText, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FLongText（字段） 查询
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongText(string fLongText, string sort_, TransactionManager tm_)
		{
			return GetByFLongText(fLongText, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FLongText（字段） 查询
		/// </summary>
		/// /// <param name = "fLongText"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongText(string fLongText, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fLongText != null ? "`FLongText` = @FLongText" : "`FLongText` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fLongText != null)
				paras_.Add(Database.CreateInParameter("@FLongText", fLongText, MySqlDbType.LongText));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFLongText
	
		#region GetByFTinyBlob
		
		/// <summary>
		/// 按 FTinyBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyBlob(byte[] fTinyBlob)
		{
			return GetByFTinyBlob(fTinyBlob, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyBlob(byte[] fTinyBlob, TransactionManager tm_)
		{
			return GetByFTinyBlob(fTinyBlob, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyBlob(byte[] fTinyBlob, int top_)
		{
			return GetByFTinyBlob(fTinyBlob, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FTinyBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyBlob(byte[] fTinyBlob, int top_, TransactionManager tm_)
		{
			return GetByFTinyBlob(fTinyBlob, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FTinyBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyBlob(byte[] fTinyBlob, string sort_)
		{
			return GetByFTinyBlob(fTinyBlob, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FTinyBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyBlob(byte[] fTinyBlob, string sort_, TransactionManager tm_)
		{
			return GetByFTinyBlob(fTinyBlob, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FTinyBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fTinyBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFTinyBlob(byte[] fTinyBlob, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fTinyBlob != null ? "`FTinyBlob` = @FTinyBlob" : "`FTinyBlob` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fTinyBlob != null)
				paras_.Add(Database.CreateInParameter("@FTinyBlob", fTinyBlob, MySqlDbType.TinyBlob));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFTinyBlob
	
		#region GetByFBlob
		
		/// <summary>
		/// 按 FBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBlob(byte[] fBlob)
		{
			return GetByFBlob(fBlob, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBlob(byte[] fBlob, TransactionManager tm_)
		{
			return GetByFBlob(fBlob, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBlob(byte[] fBlob, int top_)
		{
			return GetByFBlob(fBlob, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBlob(byte[] fBlob, int top_, TransactionManager tm_)
		{
			return GetByFBlob(fBlob, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBlob(byte[] fBlob, string sort_)
		{
			return GetByFBlob(fBlob, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBlob(byte[] fBlob, string sort_, TransactionManager tm_)
		{
			return GetByFBlob(fBlob, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFBlob(byte[] fBlob, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fBlob != null ? "`FBlob` = @FBlob" : "`FBlob` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fBlob != null)
				paras_.Add(Database.CreateInParameter("@FBlob", fBlob, MySqlDbType.Blob));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFBlob
	
		#region GetByFMediumBlob
		
		/// <summary>
		/// 按 FMediumBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumBlob(byte[] fMediumBlob)
		{
			return GetByFMediumBlob(fMediumBlob, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumBlob(byte[] fMediumBlob, TransactionManager tm_)
		{
			return GetByFMediumBlob(fMediumBlob, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumBlob(byte[] fMediumBlob, int top_)
		{
			return GetByFMediumBlob(fMediumBlob, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FMediumBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumBlob(byte[] fMediumBlob, int top_, TransactionManager tm_)
		{
			return GetByFMediumBlob(fMediumBlob, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FMediumBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumBlob(byte[] fMediumBlob, string sort_)
		{
			return GetByFMediumBlob(fMediumBlob, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FMediumBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumBlob(byte[] fMediumBlob, string sort_, TransactionManager tm_)
		{
			return GetByFMediumBlob(fMediumBlob, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FMediumBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fMediumBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFMediumBlob(byte[] fMediumBlob, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fMediumBlob != null ? "`FMediumBlob` = @FMediumBlob" : "`FMediumBlob` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fMediumBlob != null)
				paras_.Add(Database.CreateInParameter("@FMediumBlob", fMediumBlob, MySqlDbType.MediumBlob));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFMediumBlob
	
		#region GetByFLongBlob
		
		/// <summary>
		/// 按 FLongBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongBlob(byte[] fLongBlob)
		{
			return GetByFLongBlob(fLongBlob, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FLongBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongBlob(byte[] fLongBlob, TransactionManager tm_)
		{
			return GetByFLongBlob(fLongBlob, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FLongBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongBlob(byte[] fLongBlob, int top_)
		{
			return GetByFLongBlob(fLongBlob, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FLongBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongBlob(byte[] fLongBlob, int top_, TransactionManager tm_)
		{
			return GetByFLongBlob(fLongBlob, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FLongBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongBlob(byte[] fLongBlob, string sort_)
		{
			return GetByFLongBlob(fLongBlob, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FLongBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongBlob(byte[] fLongBlob, string sort_, TransactionManager tm_)
		{
			return GetByFLongBlob(fLongBlob, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FLongBlob（字段） 查询
		/// </summary>
		/// /// <param name = "fLongBlob"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFLongBlob(byte[] fLongBlob, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fLongBlob != null ? "`FLongBlob` = @FLongBlob" : "`FLongBlob` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fLongBlob != null)
				paras_.Add(Database.CreateInParameter("@FLongBlob", fLongBlob, MySqlDbType.LongBlob));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFLongBlob
	
		#region GetByFEnum
		
		/// <summary>
		/// 按 FEnum（字段） 查询
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFEnum(string fEnum)
		{
			return GetByFEnum(fEnum, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FEnum（字段） 查询
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFEnum(string fEnum, TransactionManager tm_)
		{
			return GetByFEnum(fEnum, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FEnum（字段） 查询
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFEnum(string fEnum, int top_)
		{
			return GetByFEnum(fEnum, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FEnum（字段） 查询
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFEnum(string fEnum, int top_, TransactionManager tm_)
		{
			return GetByFEnum(fEnum, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FEnum（字段） 查询
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFEnum(string fEnum, string sort_)
		{
			return GetByFEnum(fEnum, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FEnum（字段） 查询
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFEnum(string fEnum, string sort_, TransactionManager tm_)
		{
			return GetByFEnum(fEnum, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FEnum（字段） 查询
		/// </summary>
		/// /// <param name = "fEnum"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFEnum(string fEnum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fEnum != null ? "`FEnum` = @FEnum" : "`FEnum` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fEnum != null)
				paras_.Add(Database.CreateInParameter("@FEnum", fEnum, MySqlDbType.Enum));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFEnum
	
		#region GetByFSet
		
		/// <summary>
		/// 按 FSet（字段） 查询
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSet(string fSet)
		{
			return GetByFSet(fSet, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FSet（字段） 查询
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSet(string fSet, TransactionManager tm_)
		{
			return GetByFSet(fSet, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FSet（字段） 查询
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSet(string fSet, int top_)
		{
			return GetByFSet(fSet, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FSet（字段） 查询
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSet(string fSet, int top_, TransactionManager tm_)
		{
			return GetByFSet(fSet, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FSet（字段） 查询
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSet(string fSet, string sort_)
		{
			return GetByFSet(fSet, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FSet（字段） 查询
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSet(string fSet, string sort_, TransactionManager tm_)
		{
			return GetByFSet(fSet, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FSet（字段） 查询
		/// </summary>
		/// /// <param name = "fSet"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFSet(string fSet, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fSet != null ? "`FSet` = @FSet" : "`FSet` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fSet != null)
				paras_.Add(Database.CreateInParameter("@FSet", fSet, MySqlDbType.Set));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFSet
	
		#region GetByFDecimal
		
		/// <summary>
		/// 按 FDecimal（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal(decimal fDecimal)
		{
			return GetByFDecimal(fDecimal, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDecimal（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal(decimal fDecimal, TransactionManager tm_)
		{
			return GetByFDecimal(fDecimal, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDecimal（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal(decimal fDecimal, int top_)
		{
			return GetByFDecimal(fDecimal, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDecimal（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal(decimal fDecimal, int top_, TransactionManager tm_)
		{
			return GetByFDecimal(fDecimal, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDecimal（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal(decimal fDecimal, string sort_)
		{
			return GetByFDecimal(fDecimal, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FDecimal（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal(decimal fDecimal, string sort_, TransactionManager tm_)
		{
			return GetByFDecimal(fDecimal, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FDecimal（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal(decimal fDecimal, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FDecimal` = @FDecimal", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FDecimal", fDecimal, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFDecimal
	
		#region GetByFDecimal_Max
		
		/// <summary>
		/// 按 FDecimal_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal_Max(decimal? fDecimal_Max)
		{
			return GetByFDecimal_Max(fDecimal_Max, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDecimal_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal_Max(decimal? fDecimal_Max, TransactionManager tm_)
		{
			return GetByFDecimal_Max(fDecimal_Max, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDecimal_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal_Max(decimal? fDecimal_Max, int top_)
		{
			return GetByFDecimal_Max(fDecimal_Max, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FDecimal_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal_Max(decimal? fDecimal_Max, int top_, TransactionManager tm_)
		{
			return GetByFDecimal_Max(fDecimal_Max, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FDecimal_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal_Max(decimal? fDecimal_Max, string sort_)
		{
			return GetByFDecimal_Max(fDecimal_Max, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FDecimal_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal_Max(decimal? fDecimal_Max, string sort_, TransactionManager tm_)
		{
			return GetByFDecimal_Max(fDecimal_Max, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FDecimal_Max（字段） 查询
		/// </summary>
		/// /// <param name = "fDecimal_Max"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByFDecimal_Max(decimal? fDecimal_Max, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fDecimal_Max.HasValue ? "`FDecimal_Max` = @FDecimal_Max" : "`FDecimal_Max` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fDecimal_Max.HasValue)
				paras_.Add(Database.CreateInParameter("@FDecimal_Max", fDecimal_Max.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByFDecimal_Max
	
		#region GetByF_Numeric
		
		/// <summary>
		/// 按 F_Numeric（字段） 查询
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Numeric(decimal? f_Numeric)
		{
			return GetByF_Numeric(f_Numeric, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Numeric（字段） 查询
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Numeric(decimal? f_Numeric, TransactionManager tm_)
		{
			return GetByF_Numeric(f_Numeric, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Numeric（字段） 查询
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Numeric(decimal? f_Numeric, int top_)
		{
			return GetByF_Numeric(f_Numeric, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Numeric（字段） 查询
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Numeric(decimal? f_Numeric, int top_, TransactionManager tm_)
		{
			return GetByF_Numeric(f_Numeric, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Numeric（字段） 查询
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Numeric(decimal? f_Numeric, string sort_)
		{
			return GetByF_Numeric(f_Numeric, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 F_Numeric（字段） 查询
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Numeric(decimal? f_Numeric, string sort_, TransactionManager tm_)
		{
			return GetByF_Numeric(f_Numeric, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 F_Numeric（字段） 查询
		/// </summary>
		/// /// <param name = "f_Numeric"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Numeric(decimal? f_Numeric, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(f_Numeric.HasValue ? "`F_Numeric` = @F_Numeric" : "`F_Numeric` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (f_Numeric.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Numeric", f_Numeric.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByF_Numeric
	
		#region GetByF_Dec
		
		/// <summary>
		/// 按 F_Dec（字段） 查询
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Dec(decimal? f_Dec)
		{
			return GetByF_Dec(f_Dec, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Dec（字段） 查询
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Dec(decimal? f_Dec, TransactionManager tm_)
		{
			return GetByF_Dec(f_Dec, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Dec（字段） 查询
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Dec(decimal? f_Dec, int top_)
		{
			return GetByF_Dec(f_Dec, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Dec（字段） 查询
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Dec(decimal? f_Dec, int top_, TransactionManager tm_)
		{
			return GetByF_Dec(f_Dec, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Dec（字段） 查询
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Dec(decimal? f_Dec, string sort_)
		{
			return GetByF_Dec(f_Dec, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 F_Dec（字段） 查询
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Dec(decimal? f_Dec, string sort_, TransactionManager tm_)
		{
			return GetByF_Dec(f_Dec, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 F_Dec（字段） 查询
		/// </summary>
		/// /// <param name = "f_Dec"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Dec(decimal? f_Dec, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(f_Dec.HasValue ? "`F_Dec` = @F_Dec" : "`F_Dec` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (f_Dec.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Dec", f_Dec.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByF_Dec
	
		#region GetByF_Fixed
		
		/// <summary>
		/// 按 F_Fixed（字段） 查询
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Fixed(decimal? f_Fixed)
		{
			return GetByF_Fixed(f_Fixed, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Fixed（字段） 查询
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Fixed(decimal? f_Fixed, TransactionManager tm_)
		{
			return GetByF_Fixed(f_Fixed, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Fixed（字段） 查询
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Fixed(decimal? f_Fixed, int top_)
		{
			return GetByF_Fixed(f_Fixed, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 F_Fixed（字段） 查询
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Fixed(decimal? f_Fixed, int top_, TransactionManager tm_)
		{
			return GetByF_Fixed(f_Fixed, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 F_Fixed（字段） 查询
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Fixed(decimal? f_Fixed, string sort_)
		{
			return GetByF_Fixed(f_Fixed, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 F_Fixed（字段） 查询
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Fixed(decimal? f_Fixed, string sort_, TransactionManager tm_)
		{
			return GetByF_Fixed(f_Fixed, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 F_Fixed（字段） 查询
		/// </summary>
		/// /// <param name = "f_Fixed"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_userEO> GetByF_Fixed(decimal? f_Fixed, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(f_Fixed.HasValue ? "`F_Fixed` = @F_Fixed" : "`F_Fixed` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (f_Fixed.HasValue)
				paras_.Add(Database.CreateInParameter("@F_Fixed", f_Fixed.Value, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_userEO.MapDataReader);
		}
		#endregion // GetByF_Fixed
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
