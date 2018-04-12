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
	/// 用户组权限
	/// 【表 admin_group_privilege 的实体类】
	/// </summary>
	[Serializable]
	public class Admin_group_privilegeEO : IRowMapper<Admin_group_privilegeEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Admin_group_privilegeEO()
		{
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected long _originalGroupID;
		/// <summary>
		/// 【数据库中的原始主键 GroupID 值的副本，用于主键值更新】
		/// </summary>
		public long OriginalGroupID
		{
			get { return _originalGroupID; }
			set { HasOriginal = true; _originalGroupID = value; }
		}
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
	        return new Dictionary<string, object>() { { "GroupID", GroupID },  { "PrivilegeID", PrivilegeID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 用户组ID
		/// 【主键 bigint(20)】
		/// </summary>
		public long GroupID { get; set; }
		/// <summary>
		/// 权限ID
		/// 【主键 bigint(20)】
		/// </summary>
		public long PrivilegeID { get; set; }
		/// <summary>
		/// 功能和数据权限参数。
		///              类型-参数-是否有权限| 类型-参数-是否有权限
		///              如：ControlID-btnOk-true|ControlID-btnCancle-false
		/// 【字段 varchar(250)】
		/// </summary>
		public string PrivParamsValue { get; set; }
		/// <summary>
		/// 映射的第三方平台用户编码
		///              在页面已存在于另一个管理平台中，已存在用户管理权限的情况下。
		///              通过URL参数传递，第三方平台需要直接授信此用户
		/// 【字段 varchar(20)】
		/// </summary>
		public string MapUserID { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Admin_group_privilegeEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Admin_group_privilegeEO MapDataReader(IDataReader reader)
		{
		    Admin_group_privilegeEO ret = new Admin_group_privilegeEO();
			ret.GroupID = reader.ToInt64("GroupID");
			ret.OriginalGroupID = ret.GroupID;
			ret.PrivilegeID = reader.ToInt64("PrivilegeID");
			ret.OriginalPrivilegeID = ret.PrivilegeID;
			ret.PrivParamsValue = reader.ToString("PrivParamsValue");
			ret.MapUserID = reader.ToString("MapUserID");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 用户组权限
	/// 【表 admin_group_privilege 的操作类】
	/// </summary>
	public class Admin_group_privilegeMO : MySqlTableMO<Admin_group_privilegeEO>
	{
	    public override string TableName => "`admin_group_privilege`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Admin_group_privilegeMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Admin_group_privilegeMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Admin_group_privilegeMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Admin_group_privilegeEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `admin_group_privilege` (`GroupID`, `PrivilegeID`, `PrivParamsValue`, `MapUserID`) VALUE (@GroupID, @PrivilegeID, @PrivParamsValue, @MapUserID);";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupID", item.GroupID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivilegeID", item.PrivilegeID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivParamsValue", item.PrivParamsValue != null ? item.PrivParamsValue : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MapUserID", item.MapUserID != null ? item.MapUserID : (object)DBNull.Value, MySqlDbType.VarChar),
			};
			Database.ExecSqlNonQuery(sql, paras, tm); 
	        return 1;
		}
	    
	    #endregion // Add
	    
		#region  Remove
		
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long groupID, long privilegeID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_group_privilege` WHERE `GroupID` = @GroupID AND `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
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
		public int Remove(Admin_group_privilegeEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.GroupID, item.PrivilegeID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByGroupID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGroupID(long groupID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_group_privilege` WHERE `GroupID` = @GroupID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByGroupID
	
		#region RemoveByPrivilegeID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPrivilegeID(long privilegeID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_group_privilege` WHERE `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPrivilegeID
	
		#region RemoveByPrivParamsValue
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPrivParamsValue(string privParamsValue, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_group_privilege` WHERE " + (privParamsValue != null ? "`PrivParamsValue` = @PrivParamsValue" : "`PrivParamsValue` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (privParamsValue != null)
				paras_.Add(Database.CreateInParameter("@PrivParamsValue", privParamsValue, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPrivParamsValue
	
		#region RemoveByMapUserID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByMapUserID(string mapUserID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_group_privilege` WHERE " + (mapUserID != null ? "`MapUserID` = @MapUserID" : "`MapUserID` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (mapUserID != null)
				paras_.Add(Database.CreateInParameter("@MapUserID", mapUserID, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByMapUserID
	
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
		public int Put(Admin_group_privilegeEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `admin_group_privilege` SET `GroupID` = @GroupID, `PrivilegeID` = @PrivilegeID, `PrivParamsValue` = @PrivParamsValue, `MapUserID` = @MapUserID WHERE `GroupID` = @GroupID_Original AND `PrivilegeID` = @PrivilegeID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupID", item.GroupID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivilegeID", item.PrivilegeID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivParamsValue", item.PrivParamsValue != null ? item.PrivParamsValue : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MapUserID", item.MapUserID != null ? item.MapUserID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupID_Original", item.HasOriginal ? item.OriginalGroupID : item.GroupID, MySqlDbType.Int64),
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
		public int Put(IEnumerable<Admin_group_privilegeEO> items, TransactionManager tm = null)
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
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long groupID, long privilegeID, string set_, params object[] values_)
		{
			return Put(set_, "`GroupID` = @GroupID AND `PrivilegeID` = @PrivilegeID", ConcatValues(values_, groupID, privilegeID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long groupID, long privilegeID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`GroupID` = @GroupID AND `PrivilegeID` = @PrivilegeID", tm_, ConcatValues(values_, groupID, privilegeID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long groupID, long privilegeID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
	        };
			return Put(set_, "`GroupID` = @GroupID AND `PrivilegeID` = @PrivilegeID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutGroupID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGroupID(long groupID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_group_privilege` SET `GroupID` = @GroupID";
			var parameter_ = Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGroupID
	
		#region PutPrivilegeID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrivilegeID(long privilegeID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_group_privilege` SET `PrivilegeID` = @PrivilegeID";
			var parameter_ = Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPrivilegeID
	
		#region PutPrivParamsValue
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrivParamsValueByPK(long groupID, long privilegeID, string privParamsValue, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_group_privilege` SET `PrivParamsValue` = @PrivParamsValue  WHERE `GroupID` = @GroupID AND `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrivParamsValue", privParamsValue != null ? privParamsValue : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrivParamsValue(string privParamsValue, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_group_privilege` SET `PrivParamsValue` = @PrivParamsValue";
			var parameter_ = Database.CreateInParameter("@PrivParamsValue", privParamsValue != null ? privParamsValue : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPrivParamsValue
	
		#region PutMapUserID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "privilegeID">权限ID</param>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMapUserIDByPK(long groupID, long privilegeID, string mapUserID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_group_privilege` SET `MapUserID` = @MapUserID  WHERE `GroupID` = @GroupID AND `PrivilegeID` = @PrivilegeID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@MapUserID", mapUserID != null ? mapUserID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMapUserID(string mapUserID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_group_privilege` SET `MapUserID` = @MapUserID";
			var parameter_ = Database.CreateInParameter("@MapUserID", mapUserID != null ? mapUserID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutMapUserID
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Admin_group_privilegeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.GroupID, item.PrivilegeID) == null)
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
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Admin_group_privilegeEO GetByPK(long groupID, long privilegeID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`GroupID` = @GroupID AND `PrivilegeID` = @PrivilegeID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
				Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_group_privilegeEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
	
		#region GetByXXX
	
		#region GetByGroupID
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByGroupID(long groupID)
		{
			return GetByGroupID(groupID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByGroupID(long groupID, TransactionManager tm_)
		{
			return GetByGroupID(groupID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByGroupID(long groupID, int top_)
		{
			return GetByGroupID(groupID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByGroupID(long groupID, int top_, TransactionManager tm_)
		{
			return GetByGroupID(groupID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByGroupID(long groupID, string sort_)
		{
			return GetByGroupID(groupID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByGroupID(long groupID, string sort_, TransactionManager tm_)
		{
			return GetByGroupID(groupID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByGroupID(long groupID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupID` = @GroupID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_group_privilegeEO.MapDataReader);
		}
		#endregion // GetByGroupID
	
		#region GetByPrivilegeID
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivilegeID(long privilegeID)
		{
			return GetByPrivilegeID(privilegeID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivilegeID(long privilegeID, TransactionManager tm_)
		{
			return GetByPrivilegeID(privilegeID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivilegeID(long privilegeID, int top_)
		{
			return GetByPrivilegeID(privilegeID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivilegeID(long privilegeID, int top_, TransactionManager tm_)
		{
			return GetByPrivilegeID(privilegeID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivilegeID(long privilegeID, string sort_)
		{
			return GetByPrivilegeID(privilegeID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivilegeID(long privilegeID, string sort_, TransactionManager tm_)
		{
			return GetByPrivilegeID(privilegeID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivilegeID(long privilegeID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PrivilegeID` = @PrivilegeID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_group_privilegeEO.MapDataReader);
		}
		#endregion // GetByPrivilegeID
	
		#region GetByPrivParamsValue
		
		/// <summary>
		/// 按 PrivParamsValue（字段） 查询
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivParamsValue(string privParamsValue)
		{
			return GetByPrivParamsValue(privParamsValue, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivParamsValue（字段） 查询
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivParamsValue(string privParamsValue, TransactionManager tm_)
		{
			return GetByPrivParamsValue(privParamsValue, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivParamsValue（字段） 查询
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivParamsValue(string privParamsValue, int top_)
		{
			return GetByPrivParamsValue(privParamsValue, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivParamsValue（字段） 查询
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivParamsValue(string privParamsValue, int top_, TransactionManager tm_)
		{
			return GetByPrivParamsValue(privParamsValue, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivParamsValue（字段） 查询
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivParamsValue(string privParamsValue, string sort_)
		{
			return GetByPrivParamsValue(privParamsValue, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PrivParamsValue（字段） 查询
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivParamsValue(string privParamsValue, string sort_, TransactionManager tm_)
		{
			return GetByPrivParamsValue(privParamsValue, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PrivParamsValue（字段） 查询
		/// </summary>
		/// /// <param name = "privParamsValue">功能和数据权限参数。</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByPrivParamsValue(string privParamsValue, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(privParamsValue != null ? "`PrivParamsValue` = @PrivParamsValue" : "`PrivParamsValue` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (privParamsValue != null)
				paras_.Add(Database.CreateInParameter("@PrivParamsValue", privParamsValue, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_group_privilegeEO.MapDataReader);
		}
		#endregion // GetByPrivParamsValue
	
		#region GetByMapUserID
		
		/// <summary>
		/// 按 MapUserID（字段） 查询
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByMapUserID(string mapUserID)
		{
			return GetByMapUserID(mapUserID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MapUserID（字段） 查询
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByMapUserID(string mapUserID, TransactionManager tm_)
		{
			return GetByMapUserID(mapUserID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MapUserID（字段） 查询
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByMapUserID(string mapUserID, int top_)
		{
			return GetByMapUserID(mapUserID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MapUserID（字段） 查询
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByMapUserID(string mapUserID, int top_, TransactionManager tm_)
		{
			return GetByMapUserID(mapUserID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MapUserID（字段） 查询
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByMapUserID(string mapUserID, string sort_)
		{
			return GetByMapUserID(mapUserID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MapUserID（字段） 查询
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByMapUserID(string mapUserID, string sort_, TransactionManager tm_)
		{
			return GetByMapUserID(mapUserID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MapUserID（字段） 查询
		/// </summary>
		/// /// <param name = "mapUserID">映射的第三方平台用户编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_group_privilegeEO> GetByMapUserID(string mapUserID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(mapUserID != null ? "`MapUserID` = @MapUserID" : "`MapUserID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (mapUserID != null)
				paras_.Add(Database.CreateInParameter("@MapUserID", mapUserID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_group_privilegeEO.MapDataReader);
		}
		#endregion // GetByMapUserID
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
