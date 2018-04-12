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
	/// 用户与用户组
	/// 【表 admin_user_group 的实体类】
	/// </summary>
	[Serializable]
	public class Admin_user_groupEO : IRowMapper<Admin_user_groupEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Admin_user_groupEO()
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
		protected string _originalAdminID;
		/// <summary>
		/// 【数据库中的原始主键 AdminID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalAdminID
		{
			get { return _originalAdminID; }
			set { HasOriginal = true; _originalAdminID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "GroupID", GroupID },  { "AdminID", AdminID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 用户ID
		/// 【主键 varchar(20)】
		/// </summary>
		public string AdminID { get; set; }
		/// <summary>
		/// 用户组ID
		/// 【主键 bigint(20)】
		/// </summary>
		public long GroupID { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Admin_user_groupEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Admin_user_groupEO MapDataReader(IDataReader reader)
		{
		    Admin_user_groupEO ret = new Admin_user_groupEO();
			ret.AdminID = reader.ToString("AdminID");
			ret.OriginalAdminID = ret.AdminID;
			ret.GroupID = reader.ToInt64("GroupID");
			ret.OriginalGroupID = ret.GroupID;
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 用户与用户组
	/// 【表 admin_user_group 的操作类】
	/// </summary>
	public class Admin_user_groupMO : MySqlTableMO<Admin_user_groupEO>
	{
	    public override string TableName => "`admin_user_group`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Admin_user_groupMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Admin_user_groupMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Admin_user_groupMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Admin_user_groupEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `admin_user_group` (`AdminID`, `GroupID`) VALUE (@AdminID, @GroupID);";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AdminID", item.AdminID, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupID", item.GroupID, MySqlDbType.Int64),
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
		/// /// <param name = "adminID">用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long groupID, string adminID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_user_group` WHERE `GroupID` = @GroupID AND `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Admin_user_groupEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.GroupID, item.AdminID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByAdminID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAdminID(string adminID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_user_group` WHERE `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByAdminID
	
		#region RemoveByGroupID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGroupID(long groupID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_user_group` WHERE `GroupID` = @GroupID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByGroupID
	
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
		public int Put(Admin_user_groupEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `admin_user_group` SET `AdminID` = @AdminID, `GroupID` = @GroupID WHERE `GroupID` = @GroupID_Original AND `AdminID` = @AdminID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AdminID", item.AdminID, MySqlDbType.VarChar),
				Database.CreateInParameter("@GroupID", item.GroupID, MySqlDbType.Int64),
				Database.CreateInParameter("@GroupID_Original", item.HasOriginal ? item.OriginalGroupID : item.GroupID, MySqlDbType.Int64),
				Database.CreateInParameter("@AdminID_Original", item.HasOriginal ? item.OriginalAdminID : item.AdminID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Admin_user_groupEO> items, TransactionManager tm = null)
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
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long groupID, string adminID, string set_, params object[] values_)
		{
			return Put(set_, "`GroupID` = @GroupID AND `AdminID` = @AdminID", ConcatValues(values_, groupID, adminID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long groupID, string adminID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`GroupID` = @GroupID AND `AdminID` = @AdminID", tm_, ConcatValues(values_, groupID, adminID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long groupID, string adminID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`GroupID` = @GroupID AND `AdminID` = @AdminID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutAdminID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAdminID(string adminID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user_group` SET `AdminID` = @AdminID";
			var parameter_ = Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAdminID
	
		#region PutGroupID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGroupID(long groupID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user_group` SET `GroupID` = @GroupID";
			var parameter_ = Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGroupID
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Admin_user_groupEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.GroupID, item.AdminID) == null)
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
		/// /// <param name = "adminID">用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Admin_user_groupEO GetByPK(long groupID, string adminID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`GroupID` = @GroupID AND `AdminID` = @AdminID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_user_groupEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
	
		#region GetByXXX
	
		#region GetByAdminID
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByAdminID(string adminID)
		{
			return GetByAdminID(adminID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByAdminID(string adminID, TransactionManager tm_)
		{
			return GetByAdminID(adminID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByAdminID(string adminID, int top_)
		{
			return GetByAdminID(adminID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByAdminID(string adminID, int top_, TransactionManager tm_)
		{
			return GetByAdminID(adminID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByAdminID(string adminID, string sort_)
		{
			return GetByAdminID(adminID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByAdminID(string adminID, string sort_, TransactionManager tm_)
		{
			return GetByAdminID(adminID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AdminID（字段） 查询
		/// </summary>
		/// /// <param name = "adminID">用户ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByAdminID(string adminID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AdminID` = @AdminID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_user_groupEO.MapDataReader);
		}
		#endregion // GetByAdminID
	
		#region GetByGroupID
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByGroupID(long groupID)
		{
			return GetByGroupID(groupID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByGroupID(long groupID, TransactionManager tm_)
		{
			return GetByGroupID(groupID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByGroupID(long groupID, int top_)
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
		public List<Admin_user_groupEO> GetByGroupID(long groupID, int top_, TransactionManager tm_)
		{
			return GetByGroupID(groupID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GroupID（字段） 查询
		/// </summary>
		/// /// <param name = "groupID">用户组ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_user_groupEO> GetByGroupID(long groupID, string sort_)
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
		public List<Admin_user_groupEO> GetByGroupID(long groupID, string sort_, TransactionManager tm_)
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
		public List<Admin_user_groupEO> GetByGroupID(long groupID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GroupID` = @GroupID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GroupID", groupID, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_user_groupEO.MapDataReader);
		}
		#endregion // GetByGroupID
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
