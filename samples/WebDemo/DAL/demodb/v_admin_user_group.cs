/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0 by JiangHui 2016-06-20
 * 文档生成时间：2018-04-11 11: 25:11
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
	/// 
	/// 【视图 v_admin_user_group 的实体类】
	/// </summary>
	[Serializable]
	public class V_admin_user_groupEO : IRowMapper<V_admin_user_groupEO>
	{
		#region 所有字段
		/// <summary>
		/// 管理用户ID
		/// 【字段 varchar(20)】
		/// </summary>
		public string AdminID { get; set; }
		/// <summary>
		/// 用户真实姓名
		/// 【字段 varchar(20)】
		/// </summary>
		public string RealName { get; set; }
		/// <summary>
		/// 用户组ID
		/// 【字段 bigint(20)】
		/// </summary>
		public long? GroupID { get; set; }
		/// <summary>
		/// 组名称
		/// 【字段 varchar(20)】
		/// </summary>
		public string GroupName { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public V_admin_user_groupEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static V_admin_user_groupEO MapDataReader(IDataReader reader)
		{
		    V_admin_user_groupEO ret = new V_admin_user_groupEO();
			ret.AdminID = reader.ToString("AdminID");
			ret.RealName = reader.ToString("RealName");
			ret.GroupID = reader.ToInt64N("GroupID");
			ret.GroupName = reader.ToString("GroupName");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 
	/// 【视图 v_admin_user_group 的操作类】
	/// </summary>
	public class V_admin_user_groupMO : MySqlViewMO<V_admin_user_groupEO>
	{
	    public override string ViewName => "`v_admin_user_group`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public V_admin_user_groupMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public V_admin_user_groupMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public V_admin_user_groupMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
		#region Get
	
		#region GetByAdminID
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByAdminID(string adminID)
		{
			return GetByAdminID(adminID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByAdminID(string adminID, TransactionManager tm_)
		{
			return GetByAdminID(adminID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByAdminID(string adminID, int top_)
		{
			return GetByAdminID(adminID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByAdminID(string adminID, int top_, TransactionManager tm_)
		{
			return GetByAdminID(adminID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByAdminID(string adminID, string sort_)
		{
			return GetByAdminID(adminID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByAdminID(string adminID, string sort_, TransactionManager tm_)
		{
			return GetByAdminID(adminID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByAdminID(string adminID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AdminID` = @AdminID", top_, sort_);
			var parameter_ = Database.CreateInParameter("@AdminID", adminID != null ? adminID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_user_groupEO.MapDataReader);
		}
		#endregion // GetByAdminID
	
		#region GetByRealName
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByRealName(string realName)
		{
			return GetByRealName(realName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByRealName(string realName, TransactionManager tm_)
		{
			return GetByRealName(realName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByRealName(string realName, int top_)
		{
			return GetByRealName(realName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByRealName(string realName, int top_, TransactionManager tm_)
		{
			return GetByRealName(realName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByRealName(string realName, string sort_)
		{
			return GetByRealName(realName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByRealName(string realName, string sort_, TransactionManager tm_)
		{
			return GetByRealName(realName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByRealName(string realName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RealName` = @RealName", top_, sort_);
			var parameter_ = Database.CreateInParameter("@RealName", realName != null ? realName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_user_groupEO.MapDataReader);
		}
		#endregion // GetByRealName
	
		#region GetByGroupID
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupID(long? groupID)
		{
			return GetByGroupID(groupID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupID(long? groupID, TransactionManager tm_)
		{
			return GetByGroupID(groupID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupID(long? groupID, int top_)
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
		public List<V_admin_user_groupEO> GetByGroupID(long? groupID, int top_, TransactionManager tm_)
		{
			return GetByGroupID(groupID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupID(long? groupID, string sort_)
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
		public List<V_admin_user_groupEO> GetByGroupID(long? groupID, string sort_, TransactionManager tm_)
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
		public List<V_admin_user_groupEO> GetByGroupID(long? groupID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupID` = @GroupID", top_, sort_);
			var parameter_ = Database.CreateInParameter("@GroupID", groupID.HasValue ? groupID.Value : (object)DBNull.Value, MySqlDbType.Int64);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_user_groupEO.MapDataReader);
		}
		#endregion // GetByGroupID
	
		#region GetByGroupName
		
		/// <summary>
		/// 按 GroupName（字段） 查询
		/// </summary>
		/// /// <param name = "groupName">组名称</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupName(string groupName)
		{
			return GetByGroupName(groupName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupName（字段） 查询
		/// </summary>
		/// /// <param name = "groupName">组名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupName(string groupName, TransactionManager tm_)
		{
			return GetByGroupName(groupName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupName（字段） 查询
		/// </summary>
		/// /// <param name = "groupName">组名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupName(string groupName, int top_)
		{
			return GetByGroupName(groupName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupName（字段） 查询
		/// </summary>
		/// /// <param name = "groupName">组名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupName(string groupName, int top_, TransactionManager tm_)
		{
			return GetByGroupName(groupName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupName（字段） 查询
		/// </summary>
		/// /// <param name = "groupName">组名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupName(string groupName, string sort_)
		{
			return GetByGroupName(groupName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GroupName（字段） 查询
		/// </summary>
		/// /// <param name = "groupName">组名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupName(string groupName, string sort_, TransactionManager tm_)
		{
			return GetByGroupName(groupName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GroupName（字段） 查询
		/// </summary>
		/// /// <param name = "groupName">组名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_user_groupEO> GetByGroupName(string groupName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupName` = @GroupName", top_, sort_);
			var parameter_ = Database.CreateInParameter("@GroupName", groupName != null ? groupName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_user_groupEO.MapDataReader);
		}
		#endregion // GetByGroupName
	
	
		#endregion // Get
	}
	#endregion // MO
}
