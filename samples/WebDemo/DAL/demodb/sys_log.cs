/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0 by JiangHui 2016-06-20
 * 文档生成时间：2018-04-11 11: 25:07
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
	/// 系统级日志表，用于平台应用
	/// 【表 sys_log 的实体类】
	/// </summary>
	[Serializable]
	public class Sys_logEO : IRowMapper<Sys_logEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sys_logEO()
		{
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected ulong _originalLogID;
		/// <summary>
		/// 【数据库中的原始主键 LogID 值的副本，用于主键值更新】
		/// </summary>
		public ulong OriginalLogID
		{
			get { return _originalLogID; }
			set { HasOriginal = true; _originalLogID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "LogID", LogID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 日志主键
		/// 【主键 bigint(20) unsigned】
		/// </summary>
		public ulong LogID { get; set; }
		/// <summary>
		/// 日志生成时间
		/// 【字段 datetime】
		/// </summary>
		public DateTime LogDate { get; set; }
		/// <summary>
		/// 日志等级
		///              0-未知
		///              1-DEBUG
		///              2-INFO
		///              3-WARN
		///              4-ERROR
		///              5-FATAL
		/// 【字段 varchar(10)】
		/// </summary>
		public string Level { get; set; }
		/// <summary>
		/// 日志记录类名称
		/// 【字段 varchar(50)】
		/// </summary>
		public string Logger { get; set; }
		/// <summary>
		/// 日志消息
		/// 【字段 text】
		/// </summary>
		public string Message { get; set; }
		/// <summary>
		/// 异常
		/// 【字段 text】
		/// </summary>
		public string Exception { get; set; }
		/// <summary>
		/// 异常用户数据
		/// 【字段 text】
		/// </summary>
		public string ExpUserData { get; set; }
		/// <summary>
		/// 线程ID
		/// 【字段 varchar(100)】
		/// </summary>
		public string Thread { get; set; }
		/// <summary>
		/// 方法名，源文件和行号
		///              警告：会影响性能。没有pdb文件的话，只有方法名，没有源文件名和行号。
		/// 【字段 varchar(500)】
		/// </summary>
		public string Location { get; set; }
		/// <summary>
		/// 主机名
		/// 【字段 varchar(100)】
		/// </summary>
		public string HostName { get; set; }
		/// <summary>
		/// 主机IP
		/// 【字段 varchar(20)】
		/// </summary>
		public string HostIp { get; set; }
		/// <summary>
		/// 操作者
		/// 【字段 varchar(50)】
		/// </summary>
		public string Operator { get; set; }
		/// <summary>
		/// 程序标识
		/// 【字段 varchar(100)】
		/// </summary>
		public string ProjectId { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sys_logEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sys_logEO MapDataReader(IDataReader reader)
		{
		    Sys_logEO ret = new Sys_logEO();
			ret.LogID = reader.ToUInt64("LogID");
			ret.OriginalLogID = ret.LogID;
			ret.LogDate = reader.ToDateTime("LogDate");
			ret.Level = reader.ToString("Level");
			ret.Logger = reader.ToString("Logger");
			ret.Message = reader.ToString("Message");
			ret.Exception = reader.ToString("Exception");
			ret.ExpUserData = reader.ToString("ExpUserData");
			ret.Thread = reader.ToString("Thread");
			ret.Location = reader.ToString("Location");
			ret.HostName = reader.ToString("HostName");
			ret.HostIp = reader.ToString("HostIp");
			ret.Operator = reader.ToString("Operator");
			ret.ProjectId = reader.ToString("ProjectId");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 系统级日志表，用于平台应用
	/// 【表 sys_log 的操作类】
	/// </summary>
	public class Sys_logMO : MySqlTableMO<Sys_logEO>
	{
	    public override string TableName => "`sys_log`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sys_logMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sys_logMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sys_logMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Sys_logEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `sys_log` (`LogDate`, `Level`, `Logger`, `Message`, `Exception`, `ExpUserData`, `Thread`, `Location`, `HostName`, `HostIp`, `Operator`, `ProjectId`) VALUE (@LogDate, @Level, @Logger, @Message, @Exception, @ExpUserData, @Thread, @Location, @HostName, @HostIp, @Operator, @ProjectId);SELECT LAST_INSERT_ID();";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@LogDate", item.LogDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@Level", item.Level, MySqlDbType.VarChar),
				Database.CreateInParameter("@Logger", item.Logger != null ? item.Logger : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Message", item.Message != null ? item.Message : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Exception", item.Exception != null ? item.Exception : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@ExpUserData", item.ExpUserData != null ? item.ExpUserData : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Thread", item.Thread != null ? item.Thread : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Location", item.Location != null ? item.Location : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@HostName", item.HostName != null ? item.HostName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@HostIp", item.HostIp != null ? item.HostIp : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Operator", item.Operator != null ? item.Operator : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProjectId", item.ProjectId != null ? item.ProjectId : (object)DBNull.Value, MySqlDbType.VarChar),
			};
			item.LogID = Database.ExecSqlScalar<ulong>(sql, paras, tm); 
	        return 1;
		}
	    
	    #endregion // Add
	    
		#region  Remove
		
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(ulong logID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `sys_log` WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sys_logEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.LogID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByLogDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByLogDate(DateTime logDate, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE `LogDate` = @LogDate";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@LogDate", logDate, MySqlDbType.DateTime));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByLogDate
	
		#region RemoveByLevel
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByLevel(string level, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE `Level` = @Level";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Level", level, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByLevel
	
		#region RemoveByLogger
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByLogger(string logger, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (logger != null ? "`Logger` = @Logger" : "`Logger` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (logger != null)
				paras_.Add(Database.CreateInParameter("@Logger", logger, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByLogger
	
		#region RemoveByMessage
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByMessage(string message, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (message != null ? "`Message` = @Message" : "`Message` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (message != null)
				paras_.Add(Database.CreateInParameter("@Message", message, MySqlDbType.Text));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByMessage
	
		#region RemoveByException
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByException(string exception, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (exception != null ? "`Exception` = @Exception" : "`Exception` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (exception != null)
				paras_.Add(Database.CreateInParameter("@Exception", exception, MySqlDbType.Text));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByException
	
		#region RemoveByExpUserData
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByExpUserData(string expUserData, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (expUserData != null ? "`ExpUserData` = @ExpUserData" : "`ExpUserData` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (expUserData != null)
				paras_.Add(Database.CreateInParameter("@ExpUserData", expUserData, MySqlDbType.Text));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByExpUserData
	
		#region RemoveByThread
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByThread(string thread, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (thread != null ? "`Thread` = @Thread" : "`Thread` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (thread != null)
				paras_.Add(Database.CreateInParameter("@Thread", thread, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByThread
	
		#region RemoveByLocation
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByLocation(string location, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (location != null ? "`Location` = @Location" : "`Location` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (location != null)
				paras_.Add(Database.CreateInParameter("@Location", location, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByLocation
	
		#region RemoveByHostName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHostName(string hostName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (hostName != null ? "`HostName` = @HostName" : "`HostName` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (hostName != null)
				paras_.Add(Database.CreateInParameter("@HostName", hostName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByHostName
	
		#region RemoveByHostIp
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHostIp(string hostIp, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (hostIp != null ? "`HostIp` = @HostIp" : "`HostIp` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (hostIp != null)
				paras_.Add(Database.CreateInParameter("@HostIp", hostIp, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByHostIp
	
		#region RemoveByOperator
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOperator(string operatorValue, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (operatorValue != null ? "`Operator` = @Operator" : "`Operator` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (operatorValue != null)
				paras_.Add(Database.CreateInParameter("@Operator", operatorValue, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByOperator
	
		#region RemoveByProjectId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByProjectId(string projectId, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_log` WHERE " + (projectId != null ? "`ProjectId` = @ProjectId" : "`ProjectId` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (projectId != null)
				paras_.Add(Database.CreateInParameter("@ProjectId", projectId, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByProjectId
	
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
		public int Put(Sys_logEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `sys_log` SET `LogDate` = @LogDate, `Level` = @Level, `Logger` = @Logger, `Message` = @Message, `Exception` = @Exception, `ExpUserData` = @ExpUserData, `Thread` = @Thread, `Location` = @Location, `HostName` = @HostName, `HostIp` = @HostIp, `Operator` = @Operator, `ProjectId` = @ProjectId WHERE `LogID` = @LogID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@LogDate", item.LogDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@Level", item.Level, MySqlDbType.VarChar),
				Database.CreateInParameter("@Logger", item.Logger != null ? item.Logger : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Message", item.Message != null ? item.Message : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Exception", item.Exception != null ? item.Exception : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@ExpUserData", item.ExpUserData != null ? item.ExpUserData : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Thread", item.Thread != null ? item.Thread : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Location", item.Location != null ? item.Location : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@HostName", item.HostName != null ? item.HostName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@HostIp", item.HostIp != null ? item.HostIp : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Operator", item.Operator != null ? item.Operator : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProjectId", item.ProjectId != null ? item.ProjectId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID_Original", item.HasOriginal ? item.OriginalLogID : item.LogID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sys_logEO> items, TransactionManager tm = null)
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
		/// /// <param name = "logID">日志主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(ulong logID, string set_, params object[] values_)
		{
			return Put(set_, "`LogID` = @LogID", ConcatValues(values_, logID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(ulong logID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`LogID` = @LogID", tm_, ConcatValues(values_, logID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(ulong logID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
	        };
			return Put(set_, "`LogID` = @LogID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutLogDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLogDateByPK(ulong logID, DateTime logDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `LogDate` = @LogDate  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@LogDate", logDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLogDate(DateTime logDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `LogDate` = @LogDate";
			var parameter_ = Database.CreateInParameter("@LogDate", logDate, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutLogDate
	
		#region PutLevel
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "level">日志等级</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLevelByPK(ulong logID, string level, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Level` = @Level  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Level", level, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLevel(string level, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Level` = @Level";
			var parameter_ = Database.CreateInParameter("@Level", level, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutLevel
	
		#region PutLogger
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLoggerByPK(ulong logID, string logger, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Logger` = @Logger  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Logger", logger != null ? logger : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLogger(string logger, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Logger` = @Logger";
			var parameter_ = Database.CreateInParameter("@Logger", logger != null ? logger : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutLogger
	
		#region PutMessage
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "message">日志消息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMessageByPK(ulong logID, string message, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Message` = @Message  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Message", message != null ? message : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMessage(string message, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Message` = @Message";
			var parameter_ = Database.CreateInParameter("@Message", message != null ? message : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutMessage
	
		#region PutException
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "exception">异常</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutExceptionByPK(ulong logID, string exception, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Exception` = @Exception  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Exception", exception != null ? exception : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutException(string exception, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Exception` = @Exception";
			var parameter_ = Database.CreateInParameter("@Exception", exception != null ? exception : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutException
	
		#region PutExpUserData
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutExpUserDataByPK(ulong logID, string expUserData, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `ExpUserData` = @ExpUserData  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ExpUserData", expUserData != null ? expUserData : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutExpUserData(string expUserData, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `ExpUserData` = @ExpUserData";
			var parameter_ = Database.CreateInParameter("@ExpUserData", expUserData != null ? expUserData : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutExpUserData
	
		#region PutThread
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "thread">线程ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutThreadByPK(ulong logID, string thread, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Thread` = @Thread  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Thread", thread != null ? thread : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutThread(string thread, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Thread` = @Thread";
			var parameter_ = Database.CreateInParameter("@Thread", thread != null ? thread : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutThread
	
		#region PutLocation
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLocationByPK(ulong logID, string location, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Location` = @Location  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Location", location != null ? location : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLocation(string location, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Location` = @Location";
			var parameter_ = Database.CreateInParameter("@Location", location != null ? location : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutLocation
	
		#region PutHostName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "hostName">主机名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHostNameByPK(ulong logID, string hostName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `HostName` = @HostName  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HostName", hostName != null ? hostName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHostName(string hostName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `HostName` = @HostName";
			var parameter_ = Database.CreateInParameter("@HostName", hostName != null ? hostName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHostName
	
		#region PutHostIp
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHostIpByPK(ulong logID, string hostIp, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `HostIp` = @HostIp  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HostIp", hostIp != null ? hostIp : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHostIp(string hostIp, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `HostIp` = @HostIp";
			var parameter_ = Database.CreateInParameter("@HostIp", hostIp != null ? hostIp : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHostIp
	
		#region PutOperator
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorByPK(ulong logID, string operatorValue, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Operator` = @Operator  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Operator", operatorValue != null ? operatorValue : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperator(string operatorValue, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `Operator` = @Operator";
			var parameter_ = Database.CreateInParameter("@Operator", operatorValue != null ? operatorValue : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperator
	
		#region PutProjectId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "logID">日志主键</param>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutProjectIdByPK(ulong logID, string projectId, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `ProjectId` = @ProjectId  WHERE `LogID` = @LogID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ProjectId", projectId != null ? projectId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutProjectId(string projectId, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_log` SET `ProjectId` = @ProjectId";
			var parameter_ = Database.CreateInParameter("@ProjectId", projectId != null ? projectId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutProjectId
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sys_logEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.LogID) == null)
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
		/// /// <param name = "logID">日志主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Sys_logEO GetByPK(ulong logID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`LogID` = @LogID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@LogID", logID, MySqlDbType.UInt64),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
	
		#region GetByXXX
	
		#region GetByLogDate
		
		/// <summary>
		/// 按 LogDate（字段） 查询
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogDate(DateTime logDate)
		{
			return GetByLogDate(logDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 LogDate（字段） 查询
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogDate(DateTime logDate, TransactionManager tm_)
		{
			return GetByLogDate(logDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 LogDate（字段） 查询
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogDate(DateTime logDate, int top_)
		{
			return GetByLogDate(logDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 LogDate（字段） 查询
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogDate(DateTime logDate, int top_, TransactionManager tm_)
		{
			return GetByLogDate(logDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 LogDate（字段） 查询
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogDate(DateTime logDate, string sort_)
		{
			return GetByLogDate(logDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 LogDate（字段） 查询
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogDate(DateTime logDate, string sort_, TransactionManager tm_)
		{
			return GetByLogDate(logDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 LogDate（字段） 查询
		/// </summary>
		/// /// <param name = "logDate">日志生成时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogDate(DateTime logDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`LogDate` = @LogDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@LogDate", logDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByLogDate
	
		#region GetByLevel
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLevel(string level)
		{
			return GetByLevel(level, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLevel(string level, TransactionManager tm_)
		{
			return GetByLevel(level, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLevel(string level, int top_)
		{
			return GetByLevel(level, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLevel(string level, int top_, TransactionManager tm_)
		{
			return GetByLevel(level, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLevel(string level, string sort_)
		{
			return GetByLevel(level, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLevel(string level, string sort_, TransactionManager tm_)
		{
			return GetByLevel(level, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">日志等级</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLevel(string level, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Level` = @Level", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Level", level, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByLevel
	
		#region GetByLogger
		
		/// <summary>
		/// 按 Logger（字段） 查询
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogger(string logger)
		{
			return GetByLogger(logger, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Logger（字段） 查询
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogger(string logger, TransactionManager tm_)
		{
			return GetByLogger(logger, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Logger（字段） 查询
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogger(string logger, int top_)
		{
			return GetByLogger(logger, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Logger（字段） 查询
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogger(string logger, int top_, TransactionManager tm_)
		{
			return GetByLogger(logger, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Logger（字段） 查询
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogger(string logger, string sort_)
		{
			return GetByLogger(logger, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Logger（字段） 查询
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogger(string logger, string sort_, TransactionManager tm_)
		{
			return GetByLogger(logger, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Logger（字段） 查询
		/// </summary>
		/// /// <param name = "logger">日志记录类名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLogger(string logger, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(logger != null ? "`Logger` = @Logger" : "`Logger` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (logger != null)
				paras_.Add(Database.CreateInParameter("@Logger", logger, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByLogger
	
		#region GetByMessage
		
		/// <summary>
		/// 按 Message（字段） 查询
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByMessage(string message)
		{
			return GetByMessage(message, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Message（字段） 查询
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByMessage(string message, TransactionManager tm_)
		{
			return GetByMessage(message, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Message（字段） 查询
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByMessage(string message, int top_)
		{
			return GetByMessage(message, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Message（字段） 查询
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByMessage(string message, int top_, TransactionManager tm_)
		{
			return GetByMessage(message, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Message（字段） 查询
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByMessage(string message, string sort_)
		{
			return GetByMessage(message, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Message（字段） 查询
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByMessage(string message, string sort_, TransactionManager tm_)
		{
			return GetByMessage(message, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Message（字段） 查询
		/// </summary>
		/// /// <param name = "message">日志消息</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByMessage(string message, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(message != null ? "`Message` = @Message" : "`Message` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (message != null)
				paras_.Add(Database.CreateInParameter("@Message", message, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByMessage
	
		#region GetByException
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByException(string exception)
		{
			return GetByException(exception, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByException(string exception, TransactionManager tm_)
		{
			return GetByException(exception, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByException(string exception, int top_)
		{
			return GetByException(exception, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByException(string exception, int top_, TransactionManager tm_)
		{
			return GetByException(exception, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByException(string exception, string sort_)
		{
			return GetByException(exception, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByException(string exception, string sort_, TransactionManager tm_)
		{
			return GetByException(exception, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByException(string exception, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(exception != null ? "`Exception` = @Exception" : "`Exception` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (exception != null)
				paras_.Add(Database.CreateInParameter("@Exception", exception, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByException
	
		#region GetByExpUserData
		
		/// <summary>
		/// 按 ExpUserData（字段） 查询
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByExpUserData(string expUserData)
		{
			return GetByExpUserData(expUserData, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ExpUserData（字段） 查询
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByExpUserData(string expUserData, TransactionManager tm_)
		{
			return GetByExpUserData(expUserData, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ExpUserData（字段） 查询
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByExpUserData(string expUserData, int top_)
		{
			return GetByExpUserData(expUserData, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ExpUserData（字段） 查询
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByExpUserData(string expUserData, int top_, TransactionManager tm_)
		{
			return GetByExpUserData(expUserData, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ExpUserData（字段） 查询
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByExpUserData(string expUserData, string sort_)
		{
			return GetByExpUserData(expUserData, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ExpUserData（字段） 查询
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByExpUserData(string expUserData, string sort_, TransactionManager tm_)
		{
			return GetByExpUserData(expUserData, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ExpUserData（字段） 查询
		/// </summary>
		/// /// <param name = "expUserData">异常用户数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByExpUserData(string expUserData, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(expUserData != null ? "`ExpUserData` = @ExpUserData" : "`ExpUserData` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (expUserData != null)
				paras_.Add(Database.CreateInParameter("@ExpUserData", expUserData, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByExpUserData
	
		#region GetByThread
		
		/// <summary>
		/// 按 Thread（字段） 查询
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByThread(string thread)
		{
			return GetByThread(thread, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Thread（字段） 查询
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByThread(string thread, TransactionManager tm_)
		{
			return GetByThread(thread, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Thread（字段） 查询
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByThread(string thread, int top_)
		{
			return GetByThread(thread, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Thread（字段） 查询
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByThread(string thread, int top_, TransactionManager tm_)
		{
			return GetByThread(thread, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Thread（字段） 查询
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByThread(string thread, string sort_)
		{
			return GetByThread(thread, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Thread（字段） 查询
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByThread(string thread, string sort_, TransactionManager tm_)
		{
			return GetByThread(thread, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Thread（字段） 查询
		/// </summary>
		/// /// <param name = "thread">线程ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByThread(string thread, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(thread != null ? "`Thread` = @Thread" : "`Thread` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (thread != null)
				paras_.Add(Database.CreateInParameter("@Thread", thread, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByThread
	
		#region GetByLocation
		
		/// <summary>
		/// 按 Location（字段） 查询
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLocation(string location)
		{
			return GetByLocation(location, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Location（字段） 查询
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLocation(string location, TransactionManager tm_)
		{
			return GetByLocation(location, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Location（字段） 查询
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLocation(string location, int top_)
		{
			return GetByLocation(location, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Location（字段） 查询
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLocation(string location, int top_, TransactionManager tm_)
		{
			return GetByLocation(location, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Location（字段） 查询
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLocation(string location, string sort_)
		{
			return GetByLocation(location, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Location（字段） 查询
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLocation(string location, string sort_, TransactionManager tm_)
		{
			return GetByLocation(location, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Location（字段） 查询
		/// </summary>
		/// /// <param name = "location">方法名，源文件和行号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByLocation(string location, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(location != null ? "`Location` = @Location" : "`Location` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (location != null)
				paras_.Add(Database.CreateInParameter("@Location", location, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByLocation
	
		#region GetByHostName
		
		/// <summary>
		/// 按 HostName（字段） 查询
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostName(string hostName)
		{
			return GetByHostName(hostName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HostName（字段） 查询
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostName(string hostName, TransactionManager tm_)
		{
			return GetByHostName(hostName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HostName（字段） 查询
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostName(string hostName, int top_)
		{
			return GetByHostName(hostName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HostName（字段） 查询
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostName(string hostName, int top_, TransactionManager tm_)
		{
			return GetByHostName(hostName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HostName（字段） 查询
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostName(string hostName, string sort_)
		{
			return GetByHostName(hostName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HostName（字段） 查询
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostName(string hostName, string sort_, TransactionManager tm_)
		{
			return GetByHostName(hostName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HostName（字段） 查询
		/// </summary>
		/// /// <param name = "hostName">主机名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostName(string hostName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(hostName != null ? "`HostName` = @HostName" : "`HostName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (hostName != null)
				paras_.Add(Database.CreateInParameter("@HostName", hostName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByHostName
	
		#region GetByHostIp
		
		/// <summary>
		/// 按 HostIp（字段） 查询
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostIp(string hostIp)
		{
			return GetByHostIp(hostIp, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HostIp（字段） 查询
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostIp(string hostIp, TransactionManager tm_)
		{
			return GetByHostIp(hostIp, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HostIp（字段） 查询
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostIp(string hostIp, int top_)
		{
			return GetByHostIp(hostIp, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HostIp（字段） 查询
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostIp(string hostIp, int top_, TransactionManager tm_)
		{
			return GetByHostIp(hostIp, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HostIp（字段） 查询
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostIp(string hostIp, string sort_)
		{
			return GetByHostIp(hostIp, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HostIp（字段） 查询
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostIp(string hostIp, string sort_, TransactionManager tm_)
		{
			return GetByHostIp(hostIp, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HostIp（字段） 查询
		/// </summary>
		/// /// <param name = "hostIp">主机IP</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByHostIp(string hostIp, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(hostIp != null ? "`HostIp` = @HostIp" : "`HostIp` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (hostIp != null)
				paras_.Add(Database.CreateInParameter("@HostIp", hostIp, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByHostIp
	
		#region GetByOperator
		
		/// <summary>
		/// 按 Operator（字段） 查询
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByOperator(string operatorValue)
		{
			return GetByOperator(operatorValue, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Operator（字段） 查询
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByOperator(string operatorValue, TransactionManager tm_)
		{
			return GetByOperator(operatorValue, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Operator（字段） 查询
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByOperator(string operatorValue, int top_)
		{
			return GetByOperator(operatorValue, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Operator（字段） 查询
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByOperator(string operatorValue, int top_, TransactionManager tm_)
		{
			return GetByOperator(operatorValue, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Operator（字段） 查询
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByOperator(string operatorValue, string sort_)
		{
			return GetByOperator(operatorValue, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Operator（字段） 查询
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByOperator(string operatorValue, string sort_, TransactionManager tm_)
		{
			return GetByOperator(operatorValue, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Operator（字段） 查询
		/// </summary>
		/// /// <param name = "operatorValue">操作者</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByOperator(string operatorValue, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorValue != null ? "`Operator` = @Operator" : "`Operator` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorValue != null)
				paras_.Add(Database.CreateInParameter("@Operator", operatorValue, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByOperator
	
		#region GetByProjectId
		
		/// <summary>
		/// 按 ProjectId（字段） 查询
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByProjectId(string projectId)
		{
			return GetByProjectId(projectId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ProjectId（字段） 查询
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByProjectId(string projectId, TransactionManager tm_)
		{
			return GetByProjectId(projectId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProjectId（字段） 查询
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByProjectId(string projectId, int top_)
		{
			return GetByProjectId(projectId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ProjectId（字段） 查询
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByProjectId(string projectId, int top_, TransactionManager tm_)
		{
			return GetByProjectId(projectId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProjectId（字段） 查询
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByProjectId(string projectId, string sort_)
		{
			return GetByProjectId(projectId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ProjectId（字段） 查询
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByProjectId(string projectId, string sort_, TransactionManager tm_)
		{
			return GetByProjectId(projectId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ProjectId（字段） 查询
		/// </summary>
		/// /// <param name = "projectId">程序标识</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_logEO> GetByProjectId(string projectId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(projectId != null ? "`ProjectId` = @ProjectId" : "`ProjectId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (projectId != null)
				paras_.Add(Database.CreateInParameter("@ProjectId", projectId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_logEO.MapDataReader);
		}
		#endregion // GetByProjectId
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
