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
	/// 查询模板
	/// 【表 admin_gen_query 的实体类】
	/// </summary>
	[Serializable]
	public class Admin_gen_queryEO : IRowMapper<Admin_gen_queryEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Admin_gen_queryEO()
		{
			this.HasAdd = true;
			this.HasEdit = true;
			this.HasView = false;
			this.HasDelete = true;
			this.Status = 0;
			this.RecDate = DateTime.Now;
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected long _originalQueryID;
		/// <summary>
		/// 【数据库中的原始主键 QueryID 值的副本，用于主键值更新】
		/// </summary>
		public long OriginalQueryID
		{
			get { return _originalQueryID; }
			set { HasOriginal = true; _originalQueryID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "QueryID", QueryID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 查询模板主键
		/// 【主键 bigint(20)】
		/// </summary>
		public long QueryID { get; set; }
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
		/// SQL语句
		/// 【字段 text】
		/// </summary>
		public string Sql { get; set; }
		/// <summary>
		/// 页面标题
		/// 【字段 varchar(100)】
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// 是否有添加
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool HasAdd { get; set; }
		/// <summary>
		/// 是否有编辑
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool HasEdit { get; set; }
		/// <summary>
		/// 是否有查看
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool HasView { get; set; }
		/// <summary>
		/// 是否有删除
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool HasDelete { get; set; }
		/// <summary>
		/// 添加编辑生成模板编码
		/// 【字段 bigint(20)】
		/// </summary>
		public long? AddEditID { get; set; }
		/// <summary>
		/// 目标表名
		/// 【字段 varchar(100)】
		/// </summary>
		public string TableName { get; set; }
		/// <summary>
		/// 目标表主键
		/// 【字段 blob】
		/// </summary>
		public byte[] PrimaryKey { get; set; }
		/// <summary>
		/// 页大小
		/// 【字段 int(11)】
		/// </summary>
		public int PageSize { get; set; }
		/// <summary>
		/// 查询控件配置数据
		/// 【字段 blob】
		/// </summary>
		public byte[] QueryItems { get; set; }
		/// <summary>
		/// GUID列配置数据
		/// 【字段 blob】
		/// </summary>
		public byte[] GridColumns { get; set; }
		/// <summary>
		/// 描述
		/// 【字段 varchar(255)】
		/// </summary>
		public string Note { get; set; }
		/// <summary>
		/// 生成保存路径
		/// 【字段 varchar(255)】
		/// </summary>
		public string GenPath { get; set; }
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
		public Admin_gen_queryEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Admin_gen_queryEO MapDataReader(IDataReader reader)
		{
		    Admin_gen_queryEO ret = new Admin_gen_queryEO();
			ret.QueryID = reader.ToInt64("QueryID");
			ret.OriginalQueryID = ret.QueryID;
			ret.ConnStrName = reader.ToString("ConnStrName");
			ret.ServerName = reader.ToString("ServerName");
			ret.DatabaseName = reader.ToString("DatabaseName");
			ret.Sql = reader.ToString("Sql");
			ret.Title = reader.ToString("Title");
			ret.HasAdd = reader.ToBoolean("HasAdd");
			ret.HasEdit = reader.ToBoolean("HasEdit");
			ret.HasView = reader.ToBoolean("HasView");
			ret.HasDelete = reader.ToBoolean("HasDelete");
			ret.AddEditID = reader.ToInt64N("AddEditID");
			ret.TableName = reader.ToString("TableName");
			ret.PrimaryKey = reader.ToBytes("PrimaryKey");
			ret.PageSize = reader.ToInt32("PageSize");
			ret.QueryItems = reader.ToBytes("QueryItems");
			ret.GridColumns = reader.ToBytes("GridColumns");
			ret.Note = reader.ToString("Note");
			ret.GenPath = reader.ToString("GenPath");
			ret.Status = reader.ToInt32("Status");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 查询模板
	/// 【表 admin_gen_query 的操作类】
	/// </summary>
	public class Admin_gen_queryMO : MySqlTableMO<Admin_gen_queryEO>
	{
	    public override string TableName => "`admin_gen_query`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Admin_gen_queryMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Admin_gen_queryMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Admin_gen_queryMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Admin_gen_queryEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `admin_gen_query` (`ConnStrName`, `ServerName`, `DatabaseName`, `Sql`, `Title`, `HasAdd`, `HasEdit`, `HasView`, `HasDelete`, `AddEditID`, `TableName`, `PrimaryKey`, `PageSize`, `QueryItems`, `GridColumns`, `Note`, `GenPath`, `Status`, `RecDate`) VALUE (@ConnStrName, @ServerName, @DatabaseName, @Sql, @Title, @HasAdd, @HasEdit, @HasView, @HasDelete, @AddEditID, @TableName, @PrimaryKey, @PageSize, @QueryItems, @GridColumns, @Note, @GenPath, @Status, @RecDate);SELECT LAST_INSERT_ID();";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConnStrName", item.ConnStrName != null ? item.ConnStrName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ServerName", item.ServerName, MySqlDbType.VarChar),
				Database.CreateInParameter("@DatabaseName", item.DatabaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@Sql", item.Sql != null ? item.Sql : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Title", item.Title != null ? item.Title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@HasAdd", item.HasAdd, MySqlDbType.Byte),
				Database.CreateInParameter("@HasEdit", item.HasEdit, MySqlDbType.Byte),
				Database.CreateInParameter("@HasView", item.HasView, MySqlDbType.Byte),
				Database.CreateInParameter("@HasDelete", item.HasDelete, MySqlDbType.Byte),
				Database.CreateInParameter("@AddEditID", item.AddEditID.HasValue ? item.AddEditID.Value : (object)DBNull.Value, MySqlDbType.Int64),
				Database.CreateInParameter("@TableName", item.TableName != null ? item.TableName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PrimaryKey", item.PrimaryKey != null ? item.PrimaryKey : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@PageSize", item.PageSize, MySqlDbType.Int32),
				Database.CreateInParameter("@QueryItems", item.QueryItems != null ? item.QueryItems : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@GridColumns", item.GridColumns != null ? item.GridColumns : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@GenPath", item.GenPath != null ? item.GenPath : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
			item.QueryID = Database.ExecSqlScalar<long>(sql, paras, tm); 
	        return 1;
		}
	    
	    #endregion // Add
	    
		#region  Remove
		
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long queryID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_gen_query` WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Admin_gen_queryEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.QueryID, tm);
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
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (connStrName != null ? "`ConnStrName` = @ConnStrName" : "`ConnStrName` IS NULL");
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
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `ServerName` = @ServerName";
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
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `DatabaseName` = @DatabaseName";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByDatabaseName
	
		#region RemoveBySql
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySql(string sql, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (sql != null ? "`Sql` = @Sql" : "`Sql` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (sql != null)
				paras_.Add(Database.CreateInParameter("@Sql", sql, MySqlDbType.Text));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveBySql
	
		#region RemoveByTitle
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTitle(string title, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (title != null ? "`Title` = @Title" : "`Title` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (title != null)
				paras_.Add(Database.CreateInParameter("@Title", title, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByTitle
	
		#region RemoveByHasAdd
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHasAdd(bool hasAdd, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `HasAdd` = @HasAdd";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasAdd", hasAdd, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByHasAdd
	
		#region RemoveByHasEdit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHasEdit(bool hasEdit, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `HasEdit` = @HasEdit";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasEdit", hasEdit, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByHasEdit
	
		#region RemoveByHasView
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHasView(bool hasView, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `HasView` = @HasView";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasView", hasView, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByHasView
	
		#region RemoveByHasDelete
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHasDelete(bool hasDelete, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `HasDelete` = @HasDelete";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasDelete", hasDelete, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByHasDelete
	
		#region RemoveByAddEditID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAddEditID(long? addEditID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (addEditID.HasValue ? "`AddEditID` = @AddEditID" : "`AddEditID` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (addEditID.HasValue)
				paras_.Add(Database.CreateInParameter("@AddEditID", addEditID.Value, MySqlDbType.Int64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByAddEditID
	
		#region RemoveByTableName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTableName(string tableName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (tableName != null ? "`TableName` = @TableName" : "`TableName` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (tableName != null)
				paras_.Add(Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByTableName
	
		#region RemoveByPrimaryKey
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPrimaryKey(byte[] primaryKey, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (primaryKey != null ? "`PrimaryKey` = @PrimaryKey" : "`PrimaryKey` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (primaryKey != null)
				paras_.Add(Database.CreateInParameter("@PrimaryKey", primaryKey, MySqlDbType.Blob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPrimaryKey
	
		#region RemoveByPageSize
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPageSize(int pageSize, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `PageSize` = @PageSize";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PageSize", pageSize, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPageSize
	
		#region RemoveByQueryItems
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByQueryItems(byte[] queryItems, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (queryItems != null ? "`QueryItems` = @QueryItems" : "`QueryItems` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (queryItems != null)
				paras_.Add(Database.CreateInParameter("@QueryItems", queryItems, MySqlDbType.Blob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByQueryItems
	
		#region RemoveByGridColumns
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGridColumns(byte[] gridColumns, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (gridColumns != null ? "`GridColumns` = @GridColumns" : "`GridColumns` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (gridColumns != null)
				paras_.Add(Database.CreateInParameter("@GridColumns", gridColumns, MySqlDbType.Blob));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByGridColumns
	
		#region RemoveByNote
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByNote(string note, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (note != null ? "`Note` = @Note" : "`Note` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByNote
	
		#region RemoveByGenPath
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGenPath(string genPath, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE " + (genPath != null ? "`GenPath` = @GenPath" : "`GenPath` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (genPath != null)
				paras_.Add(Database.CreateInParameter("@GenPath", genPath, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByGenPath
	
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `Status` = @Status";
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
			string sql_ = @"DELETE FROM `admin_gen_query` WHERE `RecDate` = @RecDate";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByRecDate
	
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
		public int Put(Admin_gen_queryEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `admin_gen_query` SET `ConnStrName` = @ConnStrName, `ServerName` = @ServerName, `DatabaseName` = @DatabaseName, `Sql` = @Sql, `Title` = @Title, `HasAdd` = @HasAdd, `HasEdit` = @HasEdit, `HasView` = @HasView, `HasDelete` = @HasDelete, `AddEditID` = @AddEditID, `TableName` = @TableName, `PrimaryKey` = @PrimaryKey, `PageSize` = @PageSize, `QueryItems` = @QueryItems, `GridColumns` = @GridColumns, `Note` = @Note, `GenPath` = @GenPath, `Status` = @Status WHERE `QueryID` = @QueryID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConnStrName", item.ConnStrName != null ? item.ConnStrName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ServerName", item.ServerName, MySqlDbType.VarChar),
				Database.CreateInParameter("@DatabaseName", item.DatabaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@Sql", item.Sql != null ? item.Sql : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Title", item.Title != null ? item.Title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@HasAdd", item.HasAdd, MySqlDbType.Byte),
				Database.CreateInParameter("@HasEdit", item.HasEdit, MySqlDbType.Byte),
				Database.CreateInParameter("@HasView", item.HasView, MySqlDbType.Byte),
				Database.CreateInParameter("@HasDelete", item.HasDelete, MySqlDbType.Byte),
				Database.CreateInParameter("@AddEditID", item.AddEditID.HasValue ? item.AddEditID.Value : (object)DBNull.Value, MySqlDbType.Int64),
				Database.CreateInParameter("@TableName", item.TableName != null ? item.TableName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PrimaryKey", item.PrimaryKey != null ? item.PrimaryKey : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@PageSize", item.PageSize, MySqlDbType.Int32),
				Database.CreateInParameter("@QueryItems", item.QueryItems != null ? item.QueryItems : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@GridColumns", item.GridColumns != null ? item.GridColumns : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@GenPath", item.GenPath != null ? item.GenPath : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@QueryID_Original", item.HasOriginal ? item.OriginalQueryID : item.QueryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Admin_gen_queryEO> items, TransactionManager tm = null)
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
		/// /// <param name = "queryID">查询模板主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long queryID, string set_, params object[] values_)
		{
			return Put(set_, "`QueryID` = @QueryID", ConcatValues(values_, queryID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long queryID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`QueryID` = @QueryID", tm_, ConcatValues(values_, queryID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long queryID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
	        };
			return Put(set_, "`QueryID` = @QueryID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutConnStrName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutConnStrNameByPK(long queryID, string connStrName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `ConnStrName` = @ConnStrName  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConnStrName", connStrName != null ? connStrName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `ConnStrName` = @ConnStrName";
			var parameter_ = Database.CreateInParameter("@ConnStrName", connStrName != null ? connStrName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutConnStrName
	
		#region PutServerName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "serverName">服务器</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutServerNameByPK(long queryID, string serverName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `ServerName` = @ServerName  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `ServerName` = @ServerName";
			var parameter_ = Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutServerName
	
		#region PutDatabaseName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDatabaseNameByPK(long queryID, string databaseName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `DatabaseName` = @DatabaseName  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `DatabaseName` = @DatabaseName";
			var parameter_ = Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutDatabaseName
	
		#region PutSql
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSqlByPK(long queryID, string sql, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `Sql` = @Sql  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Sql", sql != null ? sql : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSql(string sql, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `Sql` = @Sql";
			var parameter_ = Database.CreateInParameter("@Sql", sql != null ? sql : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSql
	
		#region PutTitle
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "title">页面标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTitleByPK(long queryID, string title, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `Title` = @Title  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Title", title != null ? title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `Title` = @Title";
			var parameter_ = Database.CreateInParameter("@Title", title != null ? title : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTitle
	
		#region PutHasAdd
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasAddByPK(long queryID, bool hasAdd, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasAdd` = @HasAdd  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HasAdd", hasAdd, MySqlDbType.Byte),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasAdd(bool hasAdd, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasAdd` = @HasAdd";
			var parameter_ = Database.CreateInParameter("@HasAdd", hasAdd, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHasAdd
	
		#region PutHasEdit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasEditByPK(long queryID, bool hasEdit, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasEdit` = @HasEdit  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HasEdit", hasEdit, MySqlDbType.Byte),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasEdit(bool hasEdit, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasEdit` = @HasEdit";
			var parameter_ = Database.CreateInParameter("@HasEdit", hasEdit, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHasEdit
	
		#region PutHasView
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasViewByPK(long queryID, bool hasView, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasView` = @HasView  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HasView", hasView, MySqlDbType.Byte),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasView(bool hasView, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasView` = @HasView";
			var parameter_ = Database.CreateInParameter("@HasView", hasView, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHasView
	
		#region PutHasDelete
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasDeleteByPK(long queryID, bool hasDelete, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasDelete` = @HasDelete  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HasDelete", hasDelete, MySqlDbType.Byte),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHasDelete(bool hasDelete, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `HasDelete` = @HasDelete";
			var parameter_ = Database.CreateInParameter("@HasDelete", hasDelete, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHasDelete
	
		#region PutAddEditID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAddEditIDByPK(long queryID, long? addEditID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `AddEditID` = @AddEditID  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AddEditID", addEditID.HasValue ? addEditID.Value : (object)DBNull.Value, MySqlDbType.Int64),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAddEditID(long? addEditID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `AddEditID` = @AddEditID";
			var parameter_ = Database.CreateInParameter("@AddEditID", addEditID.HasValue ? addEditID.Value : (object)DBNull.Value, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAddEditID
	
		#region PutTableName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTableNameByPK(long queryID, string tableName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `TableName` = @TableName  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TableName", tableName != null ? tableName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTableName(string tableName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `TableName` = @TableName";
			var parameter_ = Database.CreateInParameter("@TableName", tableName != null ? tableName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTableName
	
		#region PutPrimaryKey
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrimaryKeyByPK(long queryID, byte[] primaryKey, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `PrimaryKey` = @PrimaryKey  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrimaryKey", primaryKey != null ? primaryKey : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrimaryKey(byte[] primaryKey, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `PrimaryKey` = @PrimaryKey";
			var parameter_ = Database.CreateInParameter("@PrimaryKey", primaryKey != null ? primaryKey : (object)DBNull.Value, MySqlDbType.Blob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPrimaryKey
	
		#region PutPageSize
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPageSizeByPK(long queryID, int pageSize, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `PageSize` = @PageSize  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PageSize", pageSize, MySqlDbType.Int32),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPageSize(int pageSize, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `PageSize` = @PageSize";
			var parameter_ = Database.CreateInParameter("@PageSize", pageSize, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPageSize
	
		#region PutQueryItems
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutQueryItemsByPK(long queryID, byte[] queryItems, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `QueryItems` = @QueryItems  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@QueryItems", queryItems != null ? queryItems : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutQueryItems(byte[] queryItems, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `QueryItems` = @QueryItems";
			var parameter_ = Database.CreateInParameter("@QueryItems", queryItems != null ? queryItems : (object)DBNull.Value, MySqlDbType.Blob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutQueryItems
	
		#region PutGridColumns
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGridColumnsByPK(long queryID, byte[] gridColumns, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `GridColumns` = @GridColumns  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GridColumns", gridColumns != null ? gridColumns : (object)DBNull.Value, MySqlDbType.Blob),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGridColumns(byte[] gridColumns, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `GridColumns` = @GridColumns";
			var parameter_ = Database.CreateInParameter("@GridColumns", gridColumns != null ? gridColumns : (object)DBNull.Value, MySqlDbType.Blob);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGridColumns
	
		#region PutNote
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNoteByPK(long queryID, string note, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `Note` = @Note  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `Note` = @Note";
			var parameter_ = Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutNote
	
		#region PutGenPath
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGenPathByPK(long queryID, string genPath, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `GenPath` = @GenPath  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GenPath", genPath != null ? genPath : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `GenPath` = @GenPath";
			var parameter_ = Database.CreateInParameter("@GenPath", genPath != null ? genPath : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGenPath
	
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(long queryID, int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `Status` = @Status  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Byte),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
	
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "queryID">查询模板主键</param>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(long queryID, DateTime recDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_gen_query` SET `RecDate` = @RecDate  WHERE `QueryID` = @QueryID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_gen_query` SET `RecDate` = @RecDate";
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
		public bool Set(Admin_gen_queryEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.QueryID) == null)
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
		/// /// <param name = "queryID">查询模板主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Admin_gen_queryEO GetByPK(long queryID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`QueryID` = @QueryID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@QueryID", queryID, MySqlDbType.Int64),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
	
		#region GetByXXX
	
		#region GetByConnStrName
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByConnStrName(string connStrName)
		{
			return GetByConnStrName(connStrName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByConnStrName(string connStrName, TransactionManager tm_)
		{
			return GetByConnStrName(connStrName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByConnStrName(string connStrName, int top_)
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
		public List<Admin_gen_queryEO> GetByConnStrName(string connStrName, int top_, TransactionManager tm_)
		{
			return GetByConnStrName(connStrName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConnStrName（字段） 查询
		/// </summary>
		/// /// <param name = "connStrName">数据连接名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByConnStrName(string connStrName, string sort_)
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
		public List<Admin_gen_queryEO> GetByConnStrName(string connStrName, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByConnStrName(string connStrName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(connStrName != null ? "`ConnStrName` = @ConnStrName" : "`ConnStrName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (connStrName != null)
				paras_.Add(Database.CreateInParameter("@ConnStrName", connStrName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByConnStrName
	
		#region GetByServerName
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByServerName(string serverName)
		{
			return GetByServerName(serverName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByServerName(string serverName, TransactionManager tm_)
		{
			return GetByServerName(serverName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByServerName(string serverName, int top_)
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
		public List<Admin_gen_queryEO> GetByServerName(string serverName, int top_, TransactionManager tm_)
		{
			return GetByServerName(serverName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ServerName（字段） 查询
		/// </summary>
		/// /// <param name = "serverName">服务器</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByServerName(string serverName, string sort_)
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
		public List<Admin_gen_queryEO> GetByServerName(string serverName, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByServerName(string serverName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ServerName` = @ServerName", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ServerName", serverName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByServerName
	
		#region GetByDatabaseName
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByDatabaseName(string databaseName)
		{
			return GetByDatabaseName(databaseName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByDatabaseName(string databaseName, TransactionManager tm_)
		{
			return GetByDatabaseName(databaseName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByDatabaseName(string databaseName, int top_)
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
		public List<Admin_gen_queryEO> GetByDatabaseName(string databaseName, int top_, TransactionManager tm_)
		{
			return GetByDatabaseName(databaseName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DatabaseName（字段） 查询
		/// </summary>
		/// /// <param name = "databaseName">数据库名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByDatabaseName(string databaseName, string sort_)
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
		public List<Admin_gen_queryEO> GetByDatabaseName(string databaseName, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByDatabaseName(string databaseName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DatabaseName` = @DatabaseName", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DatabaseName", databaseName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByDatabaseName
	
		#region GetBySql
		
		/// <summary>
		/// 按 Sql（字段） 查询
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetBySql(string sql)
		{
			return GetBySql(sql, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Sql（字段） 查询
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetBySql(string sql, TransactionManager tm_)
		{
			return GetBySql(sql, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Sql（字段） 查询
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetBySql(string sql, int top_)
		{
			return GetBySql(sql, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Sql（字段） 查询
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetBySql(string sql, int top_, TransactionManager tm_)
		{
			return GetBySql(sql, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Sql（字段） 查询
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetBySql(string sql, string sort_)
		{
			return GetBySql(sql, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Sql（字段） 查询
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetBySql(string sql, string sort_, TransactionManager tm_)
		{
			return GetBySql(sql, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Sql（字段） 查询
		/// </summary>
		/// /// <param name = "sql">SQL语句</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetBySql(string sql, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(sql != null ? "`Sql` = @Sql" : "`Sql` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (sql != null)
				paras_.Add(Database.CreateInParameter("@Sql", sql, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetBySql
	
		#region GetByTitle
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTitle(string title)
		{
			return GetByTitle(title, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTitle(string title, TransactionManager tm_)
		{
			return GetByTitle(title, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTitle(string title, int top_)
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
		public List<Admin_gen_queryEO> GetByTitle(string title, int top_, TransactionManager tm_)
		{
			return GetByTitle(title, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">页面标题</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTitle(string title, string sort_)
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
		public List<Admin_gen_queryEO> GetByTitle(string title, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByTitle(string title, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(title != null ? "`Title` = @Title" : "`Title` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (title != null)
				paras_.Add(Database.CreateInParameter("@Title", title, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByTitle
	
		#region GetByHasAdd
		
		/// <summary>
		/// 按 HasAdd（字段） 查询
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasAdd(bool hasAdd)
		{
			return GetByHasAdd(hasAdd, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasAdd（字段） 查询
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasAdd(bool hasAdd, TransactionManager tm_)
		{
			return GetByHasAdd(hasAdd, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasAdd（字段） 查询
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasAdd(bool hasAdd, int top_)
		{
			return GetByHasAdd(hasAdd, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasAdd（字段） 查询
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasAdd(bool hasAdd, int top_, TransactionManager tm_)
		{
			return GetByHasAdd(hasAdd, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasAdd（字段） 查询
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasAdd(bool hasAdd, string sort_)
		{
			return GetByHasAdd(hasAdd, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HasAdd（字段） 查询
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasAdd(bool hasAdd, string sort_, TransactionManager tm_)
		{
			return GetByHasAdd(hasAdd, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HasAdd（字段） 查询
		/// </summary>
		/// /// <param name = "hasAdd">是否有添加</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasAdd(bool hasAdd, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HasAdd` = @HasAdd", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasAdd", hasAdd, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByHasAdd
	
		#region GetByHasEdit
		
		/// <summary>
		/// 按 HasEdit（字段） 查询
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasEdit(bool hasEdit)
		{
			return GetByHasEdit(hasEdit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasEdit（字段） 查询
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasEdit(bool hasEdit, TransactionManager tm_)
		{
			return GetByHasEdit(hasEdit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasEdit（字段） 查询
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasEdit(bool hasEdit, int top_)
		{
			return GetByHasEdit(hasEdit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasEdit（字段） 查询
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasEdit(bool hasEdit, int top_, TransactionManager tm_)
		{
			return GetByHasEdit(hasEdit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasEdit（字段） 查询
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasEdit(bool hasEdit, string sort_)
		{
			return GetByHasEdit(hasEdit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HasEdit（字段） 查询
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasEdit(bool hasEdit, string sort_, TransactionManager tm_)
		{
			return GetByHasEdit(hasEdit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HasEdit（字段） 查询
		/// </summary>
		/// /// <param name = "hasEdit">是否有编辑</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasEdit(bool hasEdit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HasEdit` = @HasEdit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasEdit", hasEdit, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByHasEdit
	
		#region GetByHasView
		
		/// <summary>
		/// 按 HasView（字段） 查询
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasView(bool hasView)
		{
			return GetByHasView(hasView, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasView（字段） 查询
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasView(bool hasView, TransactionManager tm_)
		{
			return GetByHasView(hasView, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasView（字段） 查询
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasView(bool hasView, int top_)
		{
			return GetByHasView(hasView, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasView（字段） 查询
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasView(bool hasView, int top_, TransactionManager tm_)
		{
			return GetByHasView(hasView, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasView（字段） 查询
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasView(bool hasView, string sort_)
		{
			return GetByHasView(hasView, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HasView（字段） 查询
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasView(bool hasView, string sort_, TransactionManager tm_)
		{
			return GetByHasView(hasView, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HasView（字段） 查询
		/// </summary>
		/// /// <param name = "hasView">是否有查看</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasView(bool hasView, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HasView` = @HasView", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasView", hasView, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByHasView
	
		#region GetByHasDelete
		
		/// <summary>
		/// 按 HasDelete（字段） 查询
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasDelete(bool hasDelete)
		{
			return GetByHasDelete(hasDelete, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasDelete（字段） 查询
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasDelete(bool hasDelete, TransactionManager tm_)
		{
			return GetByHasDelete(hasDelete, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasDelete（字段） 查询
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasDelete(bool hasDelete, int top_)
		{
			return GetByHasDelete(hasDelete, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HasDelete（字段） 查询
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasDelete(bool hasDelete, int top_, TransactionManager tm_)
		{
			return GetByHasDelete(hasDelete, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HasDelete（字段） 查询
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasDelete(bool hasDelete, string sort_)
		{
			return GetByHasDelete(hasDelete, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HasDelete（字段） 查询
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasDelete(bool hasDelete, string sort_, TransactionManager tm_)
		{
			return GetByHasDelete(hasDelete, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HasDelete（字段） 查询
		/// </summary>
		/// /// <param name = "hasDelete">是否有删除</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByHasDelete(bool hasDelete, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HasDelete` = @HasDelete", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HasDelete", hasDelete, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByHasDelete
	
		#region GetByAddEditID
		
		/// <summary>
		/// 按 AddEditID（字段） 查询
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByAddEditID(long? addEditID)
		{
			return GetByAddEditID(addEditID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AddEditID（字段） 查询
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByAddEditID(long? addEditID, TransactionManager tm_)
		{
			return GetByAddEditID(addEditID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AddEditID（字段） 查询
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByAddEditID(long? addEditID, int top_)
		{
			return GetByAddEditID(addEditID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AddEditID（字段） 查询
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByAddEditID(long? addEditID, int top_, TransactionManager tm_)
		{
			return GetByAddEditID(addEditID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AddEditID（字段） 查询
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByAddEditID(long? addEditID, string sort_)
		{
			return GetByAddEditID(addEditID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AddEditID（字段） 查询
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByAddEditID(long? addEditID, string sort_, TransactionManager tm_)
		{
			return GetByAddEditID(addEditID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AddEditID（字段） 查询
		/// </summary>
		/// /// <param name = "addEditID">添加编辑生成模板编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByAddEditID(long? addEditID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(addEditID.HasValue ? "`AddEditID` = @AddEditID" : "`AddEditID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (addEditID.HasValue)
				paras_.Add(Database.CreateInParameter("@AddEditID", addEditID.Value, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByAddEditID
	
		#region GetByTableName
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTableName(string tableName)
		{
			return GetByTableName(tableName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTableName(string tableName, TransactionManager tm_)
		{
			return GetByTableName(tableName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTableName(string tableName, int top_)
		{
			return GetByTableName(tableName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTableName(string tableName, int top_, TransactionManager tm_)
		{
			return GetByTableName(tableName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTableName(string tableName, string sort_)
		{
			return GetByTableName(tableName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTableName(string tableName, string sort_, TransactionManager tm_)
		{
			return GetByTableName(tableName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TableName（字段） 查询
		/// </summary>
		/// /// <param name = "tableName">目标表名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByTableName(string tableName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(tableName != null ? "`TableName` = @TableName" : "`TableName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (tableName != null)
				paras_.Add(Database.CreateInParameter("@TableName", tableName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByTableName
	
		#region GetByPrimaryKey
		
		/// <summary>
		/// 按 PrimaryKey（字段） 查询
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPrimaryKey(byte[] primaryKey)
		{
			return GetByPrimaryKey(primaryKey, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrimaryKey（字段） 查询
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPrimaryKey(byte[] primaryKey, TransactionManager tm_)
		{
			return GetByPrimaryKey(primaryKey, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrimaryKey（字段） 查询
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPrimaryKey(byte[] primaryKey, int top_)
		{
			return GetByPrimaryKey(primaryKey, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrimaryKey（字段） 查询
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPrimaryKey(byte[] primaryKey, int top_, TransactionManager tm_)
		{
			return GetByPrimaryKey(primaryKey, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrimaryKey（字段） 查询
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPrimaryKey(byte[] primaryKey, string sort_)
		{
			return GetByPrimaryKey(primaryKey, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PrimaryKey（字段） 查询
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPrimaryKey(byte[] primaryKey, string sort_, TransactionManager tm_)
		{
			return GetByPrimaryKey(primaryKey, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PrimaryKey（字段） 查询
		/// </summary>
		/// /// <param name = "primaryKey">目标表主键</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPrimaryKey(byte[] primaryKey, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(primaryKey != null ? "`PrimaryKey` = @PrimaryKey" : "`PrimaryKey` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (primaryKey != null)
				paras_.Add(Database.CreateInParameter("@PrimaryKey", primaryKey, MySqlDbType.Blob));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByPrimaryKey
	
		#region GetByPageSize
		
		/// <summary>
		/// 按 PageSize（字段） 查询
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPageSize(int pageSize)
		{
			return GetByPageSize(pageSize, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PageSize（字段） 查询
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPageSize(int pageSize, TransactionManager tm_)
		{
			return GetByPageSize(pageSize, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PageSize（字段） 查询
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPageSize(int pageSize, int top_)
		{
			return GetByPageSize(pageSize, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PageSize（字段） 查询
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPageSize(int pageSize, int top_, TransactionManager tm_)
		{
			return GetByPageSize(pageSize, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PageSize（字段） 查询
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPageSize(int pageSize, string sort_)
		{
			return GetByPageSize(pageSize, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PageSize（字段） 查询
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPageSize(int pageSize, string sort_, TransactionManager tm_)
		{
			return GetByPageSize(pageSize, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PageSize（字段） 查询
		/// </summary>
		/// /// <param name = "pageSize">页大小</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByPageSize(int pageSize, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PageSize` = @PageSize", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PageSize", pageSize, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByPageSize
	
		#region GetByQueryItems
		
		/// <summary>
		/// 按 QueryItems（字段） 查询
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByQueryItems(byte[] queryItems)
		{
			return GetByQueryItems(queryItems, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 QueryItems（字段） 查询
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByQueryItems(byte[] queryItems, TransactionManager tm_)
		{
			return GetByQueryItems(queryItems, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 QueryItems（字段） 查询
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByQueryItems(byte[] queryItems, int top_)
		{
			return GetByQueryItems(queryItems, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 QueryItems（字段） 查询
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByQueryItems(byte[] queryItems, int top_, TransactionManager tm_)
		{
			return GetByQueryItems(queryItems, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 QueryItems（字段） 查询
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByQueryItems(byte[] queryItems, string sort_)
		{
			return GetByQueryItems(queryItems, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 QueryItems（字段） 查询
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByQueryItems(byte[] queryItems, string sort_, TransactionManager tm_)
		{
			return GetByQueryItems(queryItems, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 QueryItems（字段） 查询
		/// </summary>
		/// /// <param name = "queryItems">查询控件配置数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByQueryItems(byte[] queryItems, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(queryItems != null ? "`QueryItems` = @QueryItems" : "`QueryItems` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (queryItems != null)
				paras_.Add(Database.CreateInParameter("@QueryItems", queryItems, MySqlDbType.Blob));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByQueryItems
	
		#region GetByGridColumns
		
		/// <summary>
		/// 按 GridColumns（字段） 查询
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGridColumns(byte[] gridColumns)
		{
			return GetByGridColumns(gridColumns, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GridColumns（字段） 查询
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGridColumns(byte[] gridColumns, TransactionManager tm_)
		{
			return GetByGridColumns(gridColumns, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GridColumns（字段） 查询
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGridColumns(byte[] gridColumns, int top_)
		{
			return GetByGridColumns(gridColumns, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GridColumns（字段） 查询
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGridColumns(byte[] gridColumns, int top_, TransactionManager tm_)
		{
			return GetByGridColumns(gridColumns, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GridColumns（字段） 查询
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGridColumns(byte[] gridColumns, string sort_)
		{
			return GetByGridColumns(gridColumns, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GridColumns（字段） 查询
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGridColumns(byte[] gridColumns, string sort_, TransactionManager tm_)
		{
			return GetByGridColumns(gridColumns, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GridColumns（字段） 查询
		/// </summary>
		/// /// <param name = "gridColumns">GUID列配置数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGridColumns(byte[] gridColumns, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(gridColumns != null ? "`GridColumns` = @GridColumns" : "`GridColumns` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (gridColumns != null)
				paras_.Add(Database.CreateInParameter("@GridColumns", gridColumns, MySqlDbType.Blob));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByGridColumns
	
		#region GetByNote
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByNote(string note)
		{
			return GetByNote(note, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByNote(string note, TransactionManager tm_)
		{
			return GetByNote(note, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByNote(string note, int top_)
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
		public List<Admin_gen_queryEO> GetByNote(string note, int top_, TransactionManager tm_)
		{
			return GetByNote(note, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByNote(string note, string sort_)
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
		public List<Admin_gen_queryEO> GetByNote(string note, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByNote(string note, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(note != null ? "`Note` = @Note" : "`Note` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByNote
	
		#region GetByGenPath
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGenPath(string genPath)
		{
			return GetByGenPath(genPath, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGenPath(string genPath, TransactionManager tm_)
		{
			return GetByGenPath(genPath, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGenPath(string genPath, int top_)
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
		public List<Admin_gen_queryEO> GetByGenPath(string genPath, int top_, TransactionManager tm_)
		{
			return GetByGenPath(genPath, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GenPath（字段） 查询
		/// </summary>
		/// /// <param name = "genPath">生成保存路径</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByGenPath(string genPath, string sort_)
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
		public List<Admin_gen_queryEO> GetByGenPath(string genPath, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByGenPath(string genPath, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(genPath != null ? "`GenPath` = @GenPath" : "`GenPath` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (genPath != null)
				paras_.Add(Database.CreateInParameter("@GenPath", genPath, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByGenPath
	
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByStatus(int status, int top_)
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
		public List<Admin_gen_queryEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-初始 1-有效 2-无效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByStatus(int status, string sort_)
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
		public List<Admin_gen_queryEO> GetByStatus(int status, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByStatus
	
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByRecDate(DateTime recDate, int top_)
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
		public List<Admin_gen_queryEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_gen_queryEO> GetByRecDate(DateTime recDate, string sort_)
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
		public List<Admin_gen_queryEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Admin_gen_queryEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_gen_queryEO.MapDataReader);
		}
		#endregion // GetByRecDate
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
