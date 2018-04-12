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
	/// 添加修改模板
	/// 【表 admin_gen_addedit 的实体类】
	/// </summary>
	[Serializable]
	public class Admin_gen_addeditEO : IRowMapper<Admin_gen_addeditEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Admin_gen_addeditEO()
		{
			this.Status = 0;
			this.RecDate = DateTime.Now;
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected long _originalAddEditID;
		/// <summary>
		/// 【数据库中的原始主键 AddEditID 值的副本，用于主键值更新】
		/// </summary>
		public long OriginalAddEditID
		{
			get { return _originalAddEditID; }
			set { HasOriginal = true; _originalAddEditID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "AddEditID", AddEditID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 编码
		/// 【主键 bigint(20)】
		/// </summary>
		public long AddEditID { get; set; }
		/// <summary>
		/// 数据连接名称
		/// 【字段 varchar(50)】
		/// </summary>
		public string ConnStrName { get; set; }
		/// <summary>
		/// 服务器
		/// 【字段 varchar(50)】
		/// </summary>
		public string ServerName { get; set; }
		/// <summary>
		/// 数据库名称
		/// 【字段 varchar(50)】
		/// </summary>
		public string DatabaseName { get; set; }
		/// <summary>
		/// 数据库表名称
		/// 【字段 varchar(50)】
		/// </summary>
		public string TableName { get; set; }
		/// <summary>
		/// 页面标题
		/// 【字段 varchar(100)】
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// 窗体宽度
		/// 【字段 varchar(20)】
		/// </summary>
		public string Width { get; set; }
		/// <summary>
		/// 窗体高度
		/// 【字段 varchar(20)】
		/// </summary>
		public string Height { get; set; }
		/// <summary>
		/// 生成保存路径
		/// 【字段 varchar(255)】
		/// </summary>
		public string GenPath { get; set; }
		/// <summary>
		/// 描述
		/// 【字段 varchar(255)】
		/// </summary>
		public string Note { get; set; }
		/// <summary>
		/// 表的Schema数据
		/// 【字段 blob】
		/// </summary>
		public byte[] TableSchema { get; set; }
		/// <summary>
		/// 序列化的列数据
		/// 【字段 blob】
		/// </summary>
		public byte[] ColumnsData { get; set; }
		/// <summary>
		/// 状态 0-初始 1-有效 2-无效
		/// 【字段 tinyint(4)】
		/// </summary>
		public int Status { get; set; }
		/// <summary>
		/// 记录日期
		/// 【字段 datetime】
		/// </summary>
		public DateTime RecDate { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Admin_gen_addeditEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Admin_gen_addeditEO MapDataReader(IDataReader reader)
		{
		    Admin_gen_addeditEO ret = new Admin_gen_addeditEO();
			ret.AddEditID = reader.ToInt64("AddEditID");
			ret.OriginalAddEditID = ret.AddEditID;
			ret.ConnStrName = reader.ToString("ConnStrName");
			ret.ServerName = reader.ToString("ServerName");
			ret.DatabaseName = reader.ToString("DatabaseName");
			ret.TableName = reader.ToString("TableName");
			ret.Title = reader.ToString("Title");
			ret.Width = reader.ToString("Width");
			ret.Height = reader.ToString("Height");
			ret.GenPath = reader.ToString("GenPath");
			ret.Note = reader.ToString("Note");
			ret.TableSchema = reader.ToBytes("TableSchema");
			ret.ColumnsData = reader.ToBytes("ColumnsData");
			ret.Status = reader.ToInt32("Status");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 添加修改模板
	/// 【表 admin_gen_addedit 的操作类】
	/// </summary>
	public class Admin_gen_addeditMO : MySqlTableMO<Admin_gen_addeditEO>
	{
	    public override string TableName => "`admin_gen_addedit`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Admin_gen_addeditMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Admin_gen_addeditMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Admin_gen_addeditMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Admin_gen_addeditEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `admin_gen_addedit` (`ConnStrName`, `ServerName`, `DatabaseName`, `TableName`, `Title`, `Width`, `Height`, `GenPath`, `Note`, `TableSchema`, `ColumnsData`, `Status`, `RecDate`) VALUE (@ConnStrName, @ServerName, @DatabaseName, @TableName, @Title, @Width, @Height, @GenPath, @Note, @TableSchema, @ColumnsData, @Status, @RecDate);SELECT LAST_INSERT_ID();";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConnStrName", item.ConnStrName != null ? item.ConnStrName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ServerName", item.ServerName, MySqlDbType.VarChar),
				Database.CreateInParameter("@DatabaseName", item.DatabaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@TableName", item.TableName, MySqlDbType.VarChar),
				Database.CreateInParameter("@Title", item.Title != null ? item.Title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Width", item.Width != null ? item.Width : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Height", item.Height != null ? item.Height : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@GenPath", item.GenPath != null ? item.GenPath : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@TableSchema", item.TableSchema != null ? item.TableSchema : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@ColumnsData", item.ColumnsData != null ? item.ColumnsData : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
			item.AddEditID = Database.ExecSqlScalar<long>(sql, paras, tm); 
	        return 1;
		}
	    
	    #endregion // Add
	    
		#region  Remove
		
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long addEditID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Admin_gen_addeditEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.AddEditID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByConnStrName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByConnStrName(string connStrName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (connStrName != null ? "`ConnStrName` = @ConnStrName" : "`ConnStrName` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (connStrName != null)
				paras_.Add(Database.CreateInParameter("@ConnStrName", connStrName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByConnStrName
	
		#region RemoveByServerName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByServerName(string serverName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE `ServerName` = @ServerName";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByServerName
	
		#region RemoveByDatabaseName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByDatabaseName(string databaseName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE `DatabaseName` = @DatabaseName";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByDatabaseName
	
		#region RemoveByTableName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTableName(string tableName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE `TableName` = @TableName";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByTableName
	
		#region RemoveByTitle
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTitle(string title, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (title != null ? "`Title` = @Title" : "`Title` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (title != null)
				paras_.Add(Database.CreateInParameter("@Title", title, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByTitle
	
		#region RemoveByWidth
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByWidth(string width, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (width != null ? "`Width` = @Width" : "`Width` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (width != null)
				paras_.Add(Database.CreateInParameter("@Width", width, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByWidth
	
		#region RemoveByHeight
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHeight(string height, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (height != null ? "`Height` = @Height" : "`Height` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (height != null)
				paras_.Add(Database.CreateInParameter("@Height", height, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByHeight
	
		#region RemoveByGenPath
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGenPath(string genPath, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (genPath != null ? "`GenPath` = @GenPath" : "`GenPath` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (genPath != null)
				paras_.Add(Database.CreateInParameter("@GenPath", genPath, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByGenPath
	
		#region RemoveByNote
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByNote(string note, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (note != null ? "`Note` = @Note" : "`Note` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByNote
	
		#region RemoveByTableSchema
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTableSchema(byte[] tableSchema, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (tableSchema != null ? "`TableSchema` = @TableSchema" : "`TableSchema` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (tableSchema != null)
				paras_.Add(Database.CreateInParameter("@TableSchema", tableSchema, MySqlDbType.Blob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByTableSchema
	
		#region RemoveByColumnsData
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByColumnsData(byte[] columnsData, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE " + (columnsData != null ? "`ColumnsData` = @ColumnsData" : "`ColumnsData` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (columnsData != null)
				paras_.Add(Database.CreateInParameter("@ColumnsData", columnsData, MySqlDbType.Blob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByColumnsData
	
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE `Status` = @Status";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByStatus
	
		#region RemoveByRecDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE `RecDate` = @RecDate";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByRecDate
	
		#endregion // RemoveByXXX
	
		#region RemoveByFKOrUnique
	
		#region RemoveByServerNameAndDatabaseNameAndTableName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// /// <param name = "databaseName">数据库名称</param>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByServerNameAndDatabaseNameAndTableName(string serverName, string databaseName, string tableName, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_gen_addedit` WHERE `ServerName` = @ServerName AND `DatabaseName` = @DatabaseName AND `TableName` = @TableName";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar),
				Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByServerNameAndDatabaseNameAndTableName
	
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
		public int Put(Admin_gen_addeditEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `admin_gen_addedit` SET `ConnStrName` = @ConnStrName, `ServerName` = @ServerName, `DatabaseName` = @DatabaseName, `TableName` = @TableName, `Title` = @Title, `Width` = @Width, `Height` = @Height, `GenPath` = @GenPath, `Note` = @Note, `TableSchema` = @TableSchema, `ColumnsData` = @ColumnsData, `Status` = @Status WHERE `AddEditID` = @AddEditID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConnStrName", item.ConnStrName != null ? item.ConnStrName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ServerName", item.ServerName, MySqlDbType.VarChar),
				Database.CreateInParameter("@DatabaseName", item.DatabaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@TableName", item.TableName, MySqlDbType.VarChar),
				Database.CreateInParameter("@Title", item.Title != null ? item.Title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Width", item.Width != null ? item.Width : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Height", item.Height != null ? item.Height : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@GenPath", item.GenPath != null ? item.GenPath : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@TableSchema", item.TableSchema != null ? item.TableSchema : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@ColumnsData", item.ColumnsData != null ? item.ColumnsData : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@AddEditID_Original", item.HasOriginal ? item.OriginalAddEditID : item.AddEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Admin_gen_addeditEO> items, TransactionManager tm = null)
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
		/// /// <param name = "addEditID">编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long addEditID, string set_, params object[] values_)
		{
			return Put(set_, "`AddEditID` = @AddEditID", ConcatValues(values_, addEditID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long addEditID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`AddEditID` = @AddEditID", tm_, ConcatValues(values_, addEditID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long addEditID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
	        };
			return Put(set_, "`AddEditID` = @AddEditID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutConnStrName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutConnStrNameByPK(long addEditID, string connStrName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `ConnStrName` = @ConnStrName  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConnStrName", connStrName != null ? connStrName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutConnStrName(string connStrName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `ConnStrName` = @ConnStrName";
			var parameter_ = Database.CreateInParameter("@ConnStrName", connStrName != null ? connStrName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutConnStrName
	
		#region PutServerName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "serverName">服务器</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutServerNameByPK(long addEditID, string serverName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `ServerName` = @ServerName  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutServerName(string serverName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `ServerName` = @ServerName";
			var parameter_ = Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutServerName
	
		#region PutDatabaseName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDatabaseNameByPK(long addEditID, string databaseName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `DatabaseName` = @DatabaseName  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDatabaseName(string databaseName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `DatabaseName` = @DatabaseName";
			var parameter_ = Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutDatabaseName
	
		#region PutTableName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTableNameByPK(long addEditID, string tableName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `TableName` = @TableName  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTableName(string tableName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `TableName` = @TableName";
			var parameter_ = Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTableName
	
		#region PutTitle
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "title">页面标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTitleByPK(long addEditID, string title, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Title` = @Title  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Title", title != null ? title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTitle(string title, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Title` = @Title";
			var parameter_ = Database.CreateInParameter("@Title", title != null ? title : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTitle
	
		#region PutWidth
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWidthByPK(long addEditID, string width, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Width` = @Width  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Width", width != null ? width : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWidth(string width, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Width` = @Width";
			var parameter_ = Database.CreateInParameter("@Width", width != null ? width : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutWidth
	
		#region PutHeight
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "height">窗体高度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHeightByPK(long addEditID, string height, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Height` = @Height  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Height", height != null ? height : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHeight(string height, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Height` = @Height";
			var parameter_ = Database.CreateInParameter("@Height", height != null ? height : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHeight
	
		#region PutGenPath
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGenPathByPK(long addEditID, string genPath, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `GenPath` = @GenPath  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GenPath", genPath != null ? genPath : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGenPath(string genPath, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `GenPath` = @GenPath";
			var parameter_ = Database.CreateInParameter("@GenPath", genPath != null ? genPath : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGenPath
	
		#region PutNote
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNoteByPK(long addEditID, string note, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Note` = @Note  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNote(string note, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Note` = @Note";
			var parameter_ = Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutNote
	
		#region PutTableSchema
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTableSchemaByPK(long addEditID, byte[] tableSchema, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `TableSchema` = @TableSchema  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TableSchema", tableSchema != null ? tableSchema : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTableSchema(byte[] tableSchema, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `TableSchema` = @TableSchema";
			var parameter_ = Database.CreateInParameter("@TableSchema", tableSchema != null ? tableSchema : (object)DBNull.Value, MySqlDbType.Blob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTableSchema
	
		#region PutColumnsData
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutColumnsDataByPK(long addEditID, byte[] columnsData, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `ColumnsData` = @ColumnsData  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ColumnsData", columnsData != null ? columnsData : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutColumnsData(byte[] columnsData, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `ColumnsData` = @ColumnsData";
			var parameter_ = Database.CreateInParameter("@ColumnsData", columnsData != null ? columnsData : (object)DBNull.Value, MySqlDbType.Blob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutColumnsData
	
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(long addEditID, int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Status` = @Status  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Byte),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatus(int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
	
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "addEditID">编码</param>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(long addEditID, DateTime recDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `RecDate` = @RecDate  WHERE `AddEditID` = @AddEditID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_addedit` SET `RecDate` = @RecDate";
			var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRecDate
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Admin_gen_addeditEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.AddEditID) == null)
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
		/// /// <param name = "addEditID">编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Admin_gen_addeditEO GetByPK(long addEditID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`AddEditID` = @AddEditID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AddEditID", addEditID, MySqlDbType.Int64),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByPK
		
		#region GetByUnique
		/// <summary>
		/// 按【唯一索引】查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// /// <param name = "databaseName">数据库名称</param>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name="tm_">事务管理对象</param>
		public Admin_gen_addeditEO GetByServerNameAndDatabaseNameAndTableName(string serverName, string databaseName, string tableName, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`ServerName` = @ServerName AND `DatabaseName` = @DatabaseName AND `TableName` = @TableName", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar),
				Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
	
		#endregion // GetByUnique
	
	
		#region GetByXXX
	
		#region GetByConnStrName
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByConnStrName(string connStrName)
		{
			return GetByConnStrName(connStrName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByConnStrName(string connStrName, TransactionManager tm_)
		{
			return GetByConnStrName(connStrName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByConnStrName(string connStrName, int top_)
		{
			return GetByConnStrName(connStrName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByConnStrName(string connStrName, int top_, TransactionManager tm_)
		{
			return GetByConnStrName(connStrName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByConnStrName(string connStrName, string sort_)
		{
			return GetByConnStrName(connStrName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByConnStrName(string connStrName, string sort_, TransactionManager tm_)
		{
			return GetByConnStrName(connStrName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByConnStrName(string connStrName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(connStrName != null ? "`ConnStrName` = @ConnStrName" : "`ConnStrName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (connStrName != null)
				paras_.Add(Database.CreateInParameter("@ConnStrName", connStrName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByConnStrName
	
		#region GetByServerName
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByServerName(string serverName)
		{
			return GetByServerName(serverName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByServerName(string serverName, TransactionManager tm_)
		{
			return GetByServerName(serverName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByServerName(string serverName, int top_)
		{
			return GetByServerName(serverName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByServerName(string serverName, int top_, TransactionManager tm_)
		{
			return GetByServerName(serverName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByServerName(string serverName, string sort_)
		{
			return GetByServerName(serverName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByServerName(string serverName, string sort_, TransactionManager tm_)
		{
			return GetByServerName(serverName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByServerName(string serverName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ServerName` = @ServerName", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByServerName
	
		#region GetByDatabaseName
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByDatabaseName(string databaseName)
		{
			return GetByDatabaseName(databaseName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByDatabaseName(string databaseName, TransactionManager tm_)
		{
			return GetByDatabaseName(databaseName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByDatabaseName(string databaseName, int top_)
		{
			return GetByDatabaseName(databaseName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByDatabaseName(string databaseName, int top_, TransactionManager tm_)
		{
			return GetByDatabaseName(databaseName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByDatabaseName(string databaseName, string sort_)
		{
			return GetByDatabaseName(databaseName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByDatabaseName(string databaseName, string sort_, TransactionManager tm_)
		{
			return GetByDatabaseName(databaseName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByDatabaseName(string databaseName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DatabaseName` = @DatabaseName", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByDatabaseName
	
		#region GetByTableName
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableName(string tableName)
		{
			return GetByTableName(tableName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableName(string tableName, TransactionManager tm_)
		{
			return GetByTableName(tableName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableName(string tableName, int top_)
		{
			return GetByTableName(tableName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableName(string tableName, int top_, TransactionManager tm_)
		{
			return GetByTableName(tableName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableName(string tableName, string sort_)
		{
			return GetByTableName(tableName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableName(string tableName, string sort_, TransactionManager tm_)
		{
			return GetByTableName(tableName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">数据库表名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableName(string tableName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TableName` = @TableName", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByTableName
	
		#region GetByTitle
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTitle(string title)
		{
			return GetByTitle(title, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTitle(string title, TransactionManager tm_)
		{
			return GetByTitle(title, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTitle(string title, int top_)
		{
			return GetByTitle(title, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTitle(string title, int top_, TransactionManager tm_)
		{
			return GetByTitle(title, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTitle(string title, string sort_)
		{
			return GetByTitle(title, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTitle(string title, string sort_, TransactionManager tm_)
		{
			return GetByTitle(title, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTitle(string title, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(title != null ? "`Title` = @Title" : "`Title` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (title != null)
				paras_.Add(Database.CreateInParameter("@Title", title, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByTitle
	
		#region GetByWidth
		
		/// <summary>
		/// 按 Width（字段） 查询
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByWidth(string width)
		{
			return GetByWidth(width, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Width（字段） 查询
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByWidth(string width, TransactionManager tm_)
		{
			return GetByWidth(width, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Width（字段） 查询
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByWidth(string width, int top_)
		{
			return GetByWidth(width, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Width（字段） 查询
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByWidth(string width, int top_, TransactionManager tm_)
		{
			return GetByWidth(width, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Width（字段） 查询
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByWidth(string width, string sort_)
		{
			return GetByWidth(width, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Width（字段） 查询
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByWidth(string width, string sort_, TransactionManager tm_)
		{
			return GetByWidth(width, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Width（字段） 查询
		/// </summary>
		/// /// <param name = "width">窗体宽度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByWidth(string width, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(width != null ? "`Width` = @Width" : "`Width` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (width != null)
				paras_.Add(Database.CreateInParameter("@Width", width, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByWidth
	
		#region GetByHeight
		
		/// <summary>
		/// 按 Height（字段） 查询
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByHeight(string height)
		{
			return GetByHeight(height, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Height（字段） 查询
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByHeight(string height, TransactionManager tm_)
		{
			return GetByHeight(height, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Height（字段） 查询
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByHeight(string height, int top_)
		{
			return GetByHeight(height, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Height（字段） 查询
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByHeight(string height, int top_, TransactionManager tm_)
		{
			return GetByHeight(height, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Height（字段） 查询
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByHeight(string height, string sort_)
		{
			return GetByHeight(height, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Height（字段） 查询
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByHeight(string height, string sort_, TransactionManager tm_)
		{
			return GetByHeight(height, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Height（字段） 查询
		/// </summary>
		/// /// <param name = "height">窗体高度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByHeight(string height, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(height != null ? "`Height` = @Height" : "`Height` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (height != null)
				paras_.Add(Database.CreateInParameter("@Height", height, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByHeight
	
		#region GetByGenPath
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByGenPath(string genPath)
		{
			return GetByGenPath(genPath, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByGenPath(string genPath, TransactionManager tm_)
		{
			return GetByGenPath(genPath, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByGenPath(string genPath, int top_)
		{
			return GetByGenPath(genPath, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByGenPath(string genPath, int top_, TransactionManager tm_)
		{
			return GetByGenPath(genPath, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByGenPath(string genPath, string sort_)
		{
			return GetByGenPath(genPath, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByGenPath(string genPath, string sort_, TransactionManager tm_)
		{
			return GetByGenPath(genPath, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByGenPath(string genPath, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(genPath != null ? "`GenPath` = @GenPath" : "`GenPath` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (genPath != null)
				paras_.Add(Database.CreateInParameter("@GenPath", genPath, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByGenPath
	
		#region GetByNote
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByNote(string note)
		{
			return GetByNote(note, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByNote(string note, TransactionManager tm_)
		{
			return GetByNote(note, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByNote(string note, int top_)
		{
			return GetByNote(note, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByNote(string note, int top_, TransactionManager tm_)
		{
			return GetByNote(note, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByNote(string note, string sort_)
		{
			return GetByNote(note, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByNote(string note, string sort_, TransactionManager tm_)
		{
			return GetByNote(note, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByNote(string note, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(note != null ? "`Note` = @Note" : "`Note` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByNote
	
		#region GetByTableSchema
		
		/// <summary>
		/// 按 TableSchema（字段） 查询
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableSchema(byte[] tableSchema)
		{
			return GetByTableSchema(tableSchema, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TableSchema（字段） 查询
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableSchema(byte[] tableSchema, TransactionManager tm_)
		{
			return GetByTableSchema(tableSchema, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TableSchema（字段） 查询
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableSchema(byte[] tableSchema, int top_)
		{
			return GetByTableSchema(tableSchema, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TableSchema（字段） 查询
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableSchema(byte[] tableSchema, int top_, TransactionManager tm_)
		{
			return GetByTableSchema(tableSchema, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TableSchema（字段） 查询
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableSchema(byte[] tableSchema, string sort_)
		{
			return GetByTableSchema(tableSchema, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TableSchema（字段） 查询
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableSchema(byte[] tableSchema, string sort_, TransactionManager tm_)
		{
			return GetByTableSchema(tableSchema, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TableSchema（字段） 查询
		/// </summary>
		/// /// <param name = "tableSchema">表的Schema数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByTableSchema(byte[] tableSchema, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(tableSchema != null ? "`TableSchema` = @TableSchema" : "`TableSchema` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (tableSchema != null)
				paras_.Add(Database.CreateInParameter("@TableSchema", tableSchema, MySqlDbType.Blob));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByTableSchema
	
		#region GetByColumnsData
		
		/// <summary>
		/// 按 ColumnsData（字段） 查询
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByColumnsData(byte[] columnsData)
		{
			return GetByColumnsData(columnsData, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ColumnsData（字段） 查询
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByColumnsData(byte[] columnsData, TransactionManager tm_)
		{
			return GetByColumnsData(columnsData, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ColumnsData（字段） 查询
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByColumnsData(byte[] columnsData, int top_)
		{
			return GetByColumnsData(columnsData, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ColumnsData（字段） 查询
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByColumnsData(byte[] columnsData, int top_, TransactionManager tm_)
		{
			return GetByColumnsData(columnsData, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ColumnsData（字段） 查询
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByColumnsData(byte[] columnsData, string sort_)
		{
			return GetByColumnsData(columnsData, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ColumnsData（字段） 查询
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByColumnsData(byte[] columnsData, string sort_, TransactionManager tm_)
		{
			return GetByColumnsData(columnsData, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ColumnsData（字段） 查询
		/// </summary>
		/// /// <param name = "columnsData">序列化的列数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByColumnsData(byte[] columnsData, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(columnsData != null ? "`ColumnsData` = @ColumnsData" : "`ColumnsData` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (columnsData != null)
				paras_.Add(Database.CreateInParameter("@ColumnsData", columnsData, MySqlDbType.Blob));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByColumnsData
	
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByStatus
	
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_addeditEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_addeditEO.MapDataReader);
		}
		#endregion // GetByRecDate
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
