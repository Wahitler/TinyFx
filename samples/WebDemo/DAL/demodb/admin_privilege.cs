/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0 by JiangHui 2016-06-20
 * 文档生成时间：2018-04-11 11: 25:06
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
	/// 权限
	/// 【表 admin_privilege 的实体类】
	/// </summary>
	[Serializable]
	public class Admin_privilegeEO : IRowMapper<Admin_privilegeEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Admin_privilegeEO()
		{
			this.Kind = 0;
			this.Status = 0;
			this.RecDate = DateTime.Now;
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected long _originalPrivilegeID;
		/// <summary>
		/// 【数据库中的原始主键 PrivilegeID 值的副本，用于主键值更新】
		/// </summary>
		public long OriginalPrivilegeID
		{
			get { return _originalPrivilegeID; }
			set { HasOriginal = true; _originalPrivilegeID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "PrivilegeID", PrivilegeID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 权限ID
		/// 【主键 bigint(20)】
		/// </summary>
		public long PrivilegeID { get; set; }
		/// <summary>
		/// 权限名称
		/// 【字段 varchar(100)】
		/// </summary>
		public string PrivilegeName { get; set; }
		/// <summary>
		/// 权限类型 0-自定义 1-菜单表Menu
		/// 【字段 tinyint(4)】
		/// </summary>
		public int Kind { get; set; }
		/// <summary>
		/// 来源表编码
		/// 【字段 varchar(50)】
		/// </summary>
		public string KindID { get; set; }
		/// <summary>
		/// 描述
		/// 【字段 varchar(255)】
		/// </summary>
		public string Note { get; set; }
		/// <summary>
		/// 状态 0-无效 1-有效
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
		public Admin_privilegeEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Admin_privilegeEO MapDataReader(IDataReader reader)
		{
		    Admin_privilegeEO ret = new Admin_privilegeEO();
			ret.PrivilegeID = reader.ToInt64("PrivilegeID");
			ret.OriginalPrivilegeID = ret.PrivilegeID;
			ret.PrivilegeName = reader.ToString("PrivilegeName");
			ret.Kind = reader.ToInt32("Kind");
			ret.KindID = reader.ToString("KindID");
			ret.Note = reader.ToString("Note");
			ret.Status = reader.ToInt32("Status");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 权限
	/// 【表 admin_privilege 的操作类】
	/// </summary>
	public class Admin_privilegeMO : MySqlTableMO<Admin_privilegeEO>
	{
	    public override string TableName => "`admin_privilege`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Admin_privilegeMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Admin_privilegeMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Admin_privilegeMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Admin_privilegeEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `admin_privilege` (`PrivilegeName`, `Kind`, `KindID`, `Note`, `Status`, `RecDate`) VALUE (@PrivilegeName, @Kind, @KindID, @Note, @Status, @RecDate);SELECT LAST_INSERT_ID();";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrivilegeName", item.PrivilegeName != null ? item.PrivilegeName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Kind", item.Kind, MySqlDbType.Byte),
				Database.CreateInParameter("@KindID", item.KindID != null ? item.KindID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
			item.PrivilegeID = Database.ExecSqlScalar<long>(sql, paras, tm); 
	        return 1;
		}
	    
	    #endregion // Add
	    
		#region  Remove
		
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long privilegeID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_privilege` WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Admin_privilegeEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.PrivilegeID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByPrivilegeName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPrivilegeName(string privilegeName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_privilege` WHERE " + (privilegeName != null ? "`PrivilegeName` = @PrivilegeName" : "`PrivilegeName` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (privilegeName != null)
				paras_.Add(Database.CreateInParameter("@PrivilegeName", privilegeName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPrivilegeName
	
		#region RemoveByKind
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByKind(int kind, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_privilege` WHERE `Kind` = @Kind";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByKind
	
		#region RemoveByKindID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByKindID(string kindID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_privilege` WHERE " + (kindID != null ? "`KindID` = @KindID" : "`KindID` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (kindID != null)
				paras_.Add(Database.CreateInParameter("@KindID", kindID, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByKindID
	
		#region RemoveByNote
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByNote(string note, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_privilege` WHERE " + (note != null ? "`Note` = @Note" : "`Note` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByNote
	
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_privilege` WHERE `Status` = @Status";
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
			string sql_ = @"DELETE FROM `admin_privilege` WHERE `RecDate` = @RecDate";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByRecDate
	
		#endregion // RemoveByXXX
	
		#region RemoveByFKOrUnique
	
		#region RemoveByKindAndKindID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByKindAndKindID(int kind, string kindID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_privilege` WHERE `Kind` = @Kind AND `KindID` = @KindID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte),
				Database.CreateInParameter("@KindID", kindID != null ? kindID : (object)DBNull.Value, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByKindAndKindID
	
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
		public int Put(Admin_privilegeEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `admin_privilege` SET `PrivilegeName` = @PrivilegeName, `Kind` = @Kind, `KindID` = @KindID, `Note` = @Note, `Status` = @Status WHERE `PrivilegeID` = @PrivilegeID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrivilegeName", item.PrivilegeName != null ? item.PrivilegeName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Kind", item.Kind, MySqlDbType.Byte),
				Database.CreateInParameter("@KindID", item.KindID != null ? item.KindID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@PrivilegeID_Original", item.HasOriginal ? item.OriginalPrivilegeID : item.PrivilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Admin_privilegeEO> items, TransactionManager tm = null)
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
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long privilegeID, string set_, params object[] values_)
		{
			return Put(set_, "`PrivilegeID` = @PrivilegeID", ConcatValues(values_, privilegeID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long privilegeID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`PrivilegeID` = @PrivilegeID", tm_, ConcatValues(values_, privilegeID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long privilegeID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
	        };
			return Put(set_, "`PrivilegeID` = @PrivilegeID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutPrivilegeName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrivilegeNameByPK(long privilegeID, string privilegeName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `PrivilegeName` = @PrivilegeName  WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrivilegeName", privilegeName != null ? privilegeName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrivilegeName(string privilegeName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `PrivilegeName` = @PrivilegeName";
			var parameter_ = Database.CreateInParameter("@PrivilegeName", privilegeName != null ? privilegeName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPrivilegeName
	
		#region PutKind
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutKindByPK(long privilegeID, int kind, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `Kind` = @Kind  WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutKind(int kind, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `Kind` = @Kind";
			var parameter_ = Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutKind
	
		#region PutKindID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutKindIDByPK(long privilegeID, string kindID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `KindID` = @KindID  WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@KindID", kindID != null ? kindID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutKindID(string kindID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `KindID` = @KindID";
			var parameter_ = Database.CreateInParameter("@KindID", kindID != null ? kindID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutKindID
	
		#region PutNote
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNoteByPK(long privilegeID, string note, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `Note` = @Note  WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_privilege` SET `Note` = @Note";
			var parameter_ = Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutNote
	
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(long privilegeID, int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `Status` = @Status  WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Byte),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatus(int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
	
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(long privilegeID, DateTime recDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_privilege` SET `RecDate` = @RecDate  WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_privilege` SET `RecDate` = @RecDate";
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
		public bool Set(Admin_privilegeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.PrivilegeID) == null)
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
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Admin_privilegeEO GetByPK(long privilegeID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`PrivilegeID` = @PrivilegeID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
		#endregion // GetByPK
		
		#region GetByUnique
		/// <summary>
		/// 按【唯一索引】查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		public Admin_privilegeEO GetByKindAndKindID(int kind, string kindID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`Kind` = @Kind AND `KindID` = @KindID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte),
				Database.CreateInParameter("@KindID", kindID != null ? kindID : (object)DBNull.Value, MySqlDbType.VarChar),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
	
		#endregion // GetByUnique
	
	
		#region GetByXXX
	
		#region GetByPrivilegeName
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByPrivilegeName(string privilegeName)
		{
			return GetByPrivilegeName(privilegeName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByPrivilegeName(string privilegeName, TransactionManager tm_)
		{
			return GetByPrivilegeName(privilegeName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByPrivilegeName(string privilegeName, int top_)
		{
			return GetByPrivilegeName(privilegeName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByPrivilegeName(string privilegeName, int top_, TransactionManager tm_)
		{
			return GetByPrivilegeName(privilegeName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByPrivilegeName(string privilegeName, string sort_)
		{
			return GetByPrivilegeName(privilegeName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByPrivilegeName(string privilegeName, string sort_, TransactionManager tm_)
		{
			return GetByPrivilegeName(privilegeName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByPrivilegeName(string privilegeName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(privilegeName != null ? "`PrivilegeName` = @PrivilegeName" : "`PrivilegeName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (privilegeName != null)
				paras_.Add(Database.CreateInParameter("@PrivilegeName", privilegeName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
		#endregion // GetByPrivilegeName
	
		#region GetByKind
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKind(int kind)
		{
			return GetByKind(kind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKind(int kind, TransactionManager tm_)
		{
			return GetByKind(kind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKind(int kind, int top_)
		{
			return GetByKind(kind, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKind(int kind, int top_, TransactionManager tm_)
		{
			return GetByKind(kind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKind(int kind, string sort_)
		{
			return GetByKind(kind, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKind(int kind, string sort_, TransactionManager tm_)
		{
			return GetByKind(kind, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKind(int kind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Kind` = @Kind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
		#endregion // GetByKind
	
		#region GetByKindID
		
		/// <summary>
		/// 按 KindID（字段） 查询
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKindID(string kindID)
		{
			return GetByKindID(kindID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 KindID（字段） 查询
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKindID(string kindID, TransactionManager tm_)
		{
			return GetByKindID(kindID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 KindID（字段） 查询
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKindID(string kindID, int top_)
		{
			return GetByKindID(kindID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 KindID（字段） 查询
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKindID(string kindID, int top_, TransactionManager tm_)
		{
			return GetByKindID(kindID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 KindID（字段） 查询
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKindID(string kindID, string sort_)
		{
			return GetByKindID(kindID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 KindID（字段） 查询
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKindID(string kindID, string sort_, TransactionManager tm_)
		{
			return GetByKindID(kindID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 KindID（字段） 查询
		/// </summary>
		/// /// <param name = "kindID">来源表编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByKindID(string kindID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(kindID != null ? "`KindID` = @KindID" : "`KindID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (kindID != null)
				paras_.Add(Database.CreateInParameter("@KindID", kindID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
		#endregion // GetByKindID
	
		#region GetByNote
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByNote(string note)
		{
			return GetByNote(note, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByNote(string note, TransactionManager tm_)
		{
			return GetByNote(note, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByNote(string note, int top_)
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
		public List<Admin_privilegeEO> GetByNote(string note, int top_, TransactionManager tm_)
		{
			return GetByNote(note, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByNote(string note, string sort_)
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
		public List<Admin_privilegeEO> GetByNote(string note, string sort_, TransactionManager tm_)
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
		public List<Admin_privilegeEO> GetByNote(string note, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(note != null ? "`Note` = @Note" : "`Note` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
		#endregion // GetByNote
	
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
		#endregion // GetByStatus
	
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByRecDate(DateTime recDate, int top_)
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
		public List<Admin_privilegeEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_privilegeEO> GetByRecDate(DateTime recDate, string sort_)
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
		public List<Admin_privilegeEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Admin_privilegeEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_privilegeEO.MapDataReader);
		}
		#endregion // GetByRecDate
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
