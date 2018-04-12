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
	/// 【视图 v_admin_priv 的实体类】
	/// </summary>
	[Serializable]
	public class V_admin_privEO : IRowMapper<V_admin_privEO>
	{
		#region 所有字段
		/// <summary>
		/// 权限ID
		/// 【字段 bigint(20)】
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
		public int PrivKind { get; set; }
		/// <summary>
		/// 菜单编码
		/// 【字段 bigint(20)】
		/// </summary>
		public long? MenuID { get; set; }
		/// <summary>
		/// 菜单显示标题
		/// 【字段 varchar(50)】
		/// </summary>
		public string MenuTitle { get; set; }
		/// <summary>
		/// 图标
		/// 【字段 varchar(250)】
		/// </summary>
		public string MenuIcon { get; set; }
		/// <summary>
		/// 类型 0-目录项 1-链接项
		/// 【字段 tinyint(4)】
		/// </summary>
		public int? MenuKind { get; set; }
		/// <summary>
		/// 菜单URL，尽量使用相对路径
		/// 【字段 varchar(250)】
		/// </summary>
		public string MenuUrl { get; set; }
		/// <summary>
		/// 链接模式 0-TAB打开 1-新窗口打开
		/// 【字段 tinyint(4)】
		/// </summary>
		public int? MenuUrlTarget { get; set; }
		/// <summary>
		/// 功能和数据权限参数。格式：类型-参数| 类型-参数
		///              用于在定义页面内权限时可设置的权限选项列表
		///              如：ControlID-btnOk|ControlID-btnCancle
		/// 【字段 varchar(250)】
		/// </summary>
		public string MenuPrivParams { get; set; }
		/// <summary>
		/// 排序，从小到大
		/// 【字段 int(11)】
		/// </summary>
		public int? MenuOrderNum { get; set; }
		/// <summary>
		/// 父菜单编码 0-根菜单
		/// 【字段 bigint(20)】
		/// </summary>
		public long? MenuParentID { get; set; }
		/// <summary>
		/// 拼音
		/// 【字段 varchar(20)】
		/// </summary>
		public string MenuPinyin { get; set; }
		/// <summary>
		/// 描述
		/// 【字段 varchar(500)】
		/// </summary>
		public string MenuNote { get; set; }
		/// <summary>
		/// 描述
		/// 【字段 varchar(255)】
		/// </summary>
		public string PrivNote { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public V_admin_privEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static V_admin_privEO MapDataReader(IDataReader reader)
		{
		    V_admin_privEO ret = new V_admin_privEO();
			ret.PrivilegeID = reader.ToInt64("PrivilegeID");
			ret.PrivilegeName = reader.ToString("PrivilegeName");
			ret.PrivKind = reader.ToInt32("PrivKind");
			ret.MenuID = reader.ToInt64N("MenuID");
			ret.MenuTitle = reader.ToString("MenuTitle");
			ret.MenuIcon = reader.ToString("MenuIcon");
			ret.MenuKind = reader.ToInt32N("MenuKind");
			ret.MenuUrl = reader.ToString("MenuUrl");
			ret.MenuUrlTarget = reader.ToInt32N("MenuUrlTarget");
			ret.MenuPrivParams = reader.ToString("MenuPrivParams");
			ret.MenuOrderNum = reader.ToInt32N("MenuOrderNum");
			ret.MenuParentID = reader.ToInt64N("MenuParentID");
			ret.MenuPinyin = reader.ToString("MenuPinyin");
			ret.MenuNote = reader.ToString("MenuNote");
			ret.PrivNote = reader.ToString("PrivNote");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 
	/// 【视图 v_admin_priv 的操作类】
	/// </summary>
	public class V_admin_privMO : MySqlViewMO<V_admin_privEO>
	{
	    public override string ViewName => "`v_admin_priv`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public V_admin_privMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public V_admin_privMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public V_admin_privMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
		#region Get
	
		#region GetByPrivilegeID
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeID(long privilegeID)
		{
			return GetByPrivilegeID(privilegeID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeID(long privilegeID, TransactionManager tm_)
		{
			return GetByPrivilegeID(privilegeID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeID(long privilegeID, int top_)
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
		public List<V_admin_privEO> GetByPrivilegeID(long privilegeID, int top_, TransactionManager tm_)
		{
			return GetByPrivilegeID(privilegeID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeID（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeID">权限ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeID(long privilegeID, string sort_)
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
		public List<V_admin_privEO> GetByPrivilegeID(long privilegeID, string sort_, TransactionManager tm_)
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
		public List<V_admin_privEO> GetByPrivilegeID(long privilegeID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PrivilegeID` = @PrivilegeID", top_, sort_);
			var parameter_ = Database.CreateInParameter("@PrivilegeID", privilegeID, MySqlDbType.Int64);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByPrivilegeID
	
		#region GetByPrivilegeName
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeName(string privilegeName)
		{
			return GetByPrivilegeName(privilegeName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeName(string privilegeName, TransactionManager tm_)
		{
			return GetByPrivilegeName(privilegeName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeName(string privilegeName, int top_)
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
		public List<V_admin_privEO> GetByPrivilegeName(string privilegeName, int top_, TransactionManager tm_)
		{
			return GetByPrivilegeName(privilegeName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivilegeName（字段） 查询
		/// </summary>
		/// /// <param name = "privilegeName">权限名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivilegeName(string privilegeName, string sort_)
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
		public List<V_admin_privEO> GetByPrivilegeName(string privilegeName, string sort_, TransactionManager tm_)
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
		public List<V_admin_privEO> GetByPrivilegeName(string privilegeName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PrivilegeName` = @PrivilegeName", top_, sort_);
			var parameter_ = Database.CreateInParameter("@PrivilegeName", privilegeName != null ? privilegeName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByPrivilegeName
	
		#region GetByPrivKind
		
		/// <summary>
		/// 按 PrivKind（字段） 查询
		/// </summary>
		/// /// <param name = "privKind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivKind(int privKind)
		{
			return GetByPrivKind(privKind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivKind（字段） 查询
		/// </summary>
		/// /// <param name = "privKind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivKind(int privKind, TransactionManager tm_)
		{
			return GetByPrivKind(privKind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivKind（字段） 查询
		/// </summary>
		/// /// <param name = "privKind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivKind(int privKind, int top_)
		{
			return GetByPrivKind(privKind, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivKind（字段） 查询
		/// </summary>
		/// /// <param name = "privKind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivKind(int privKind, int top_, TransactionManager tm_)
		{
			return GetByPrivKind(privKind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivKind（字段） 查询
		/// </summary>
		/// /// <param name = "privKind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivKind(int privKind, string sort_)
		{
			return GetByPrivKind(privKind, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PrivKind（字段） 查询
		/// </summary>
		/// /// <param name = "privKind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivKind(int privKind, string sort_, TransactionManager tm_)
		{
			return GetByPrivKind(privKind, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PrivKind（字段） 查询
		/// </summary>
		/// /// <param name = "privKind">权限类型 0-自定义 1-菜单表Menu</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivKind(int privKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PrivKind` = @PrivKind", top_, sort_);
			var parameter_ = Database.CreateInParameter("@PrivKind", privKind, MySqlDbType.Byte);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByPrivKind
	
		#region GetByMenuID
		
		/// <summary>
		/// 按 MenuID（字段） 查询
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuID(long? menuID)
		{
			return GetByMenuID(menuID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuID（字段） 查询
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuID(long? menuID, TransactionManager tm_)
		{
			return GetByMenuID(menuID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuID（字段） 查询
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuID(long? menuID, int top_)
		{
			return GetByMenuID(menuID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuID（字段） 查询
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuID(long? menuID, int top_, TransactionManager tm_)
		{
			return GetByMenuID(menuID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuID（字段） 查询
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuID(long? menuID, string sort_)
		{
			return GetByMenuID(menuID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuID（字段） 查询
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuID(long? menuID, string sort_, TransactionManager tm_)
		{
			return GetByMenuID(menuID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuID（字段） 查询
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuID(long? menuID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuID` = @MenuID", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuID", menuID.HasValue ? menuID.Value : (object)DBNull.Value, MySqlDbType.Int64);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuID
	
		#region GetByMenuTitle
		
		/// <summary>
		/// 按 MenuTitle（字段） 查询
		/// </summary>
		/// /// <param name = "menuTitle">菜单显示标题</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuTitle(string menuTitle)
		{
			return GetByMenuTitle(menuTitle, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuTitle（字段） 查询
		/// </summary>
		/// /// <param name = "menuTitle">菜单显示标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuTitle(string menuTitle, TransactionManager tm_)
		{
			return GetByMenuTitle(menuTitle, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuTitle（字段） 查询
		/// </summary>
		/// /// <param name = "menuTitle">菜单显示标题</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuTitle(string menuTitle, int top_)
		{
			return GetByMenuTitle(menuTitle, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuTitle（字段） 查询
		/// </summary>
		/// /// <param name = "menuTitle">菜单显示标题</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuTitle(string menuTitle, int top_, TransactionManager tm_)
		{
			return GetByMenuTitle(menuTitle, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuTitle（字段） 查询
		/// </summary>
		/// /// <param name = "menuTitle">菜单显示标题</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuTitle(string menuTitle, string sort_)
		{
			return GetByMenuTitle(menuTitle, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuTitle（字段） 查询
		/// </summary>
		/// /// <param name = "menuTitle">菜单显示标题</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuTitle(string menuTitle, string sort_, TransactionManager tm_)
		{
			return GetByMenuTitle(menuTitle, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuTitle（字段） 查询
		/// </summary>
		/// /// <param name = "menuTitle">菜单显示标题</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuTitle(string menuTitle, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuTitle` = @MenuTitle", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuTitle", menuTitle != null ? menuTitle : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuTitle
	
		#region GetByMenuIcon
		
		/// <summary>
		/// 按 MenuIcon（字段） 查询
		/// </summary>
		/// /// <param name = "menuIcon">图标</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuIcon(string menuIcon)
		{
			return GetByMenuIcon(menuIcon, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuIcon（字段） 查询
		/// </summary>
		/// /// <param name = "menuIcon">图标</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuIcon(string menuIcon, TransactionManager tm_)
		{
			return GetByMenuIcon(menuIcon, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuIcon（字段） 查询
		/// </summary>
		/// /// <param name = "menuIcon">图标</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuIcon(string menuIcon, int top_)
		{
			return GetByMenuIcon(menuIcon, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuIcon（字段） 查询
		/// </summary>
		/// /// <param name = "menuIcon">图标</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuIcon(string menuIcon, int top_, TransactionManager tm_)
		{
			return GetByMenuIcon(menuIcon, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuIcon（字段） 查询
		/// </summary>
		/// /// <param name = "menuIcon">图标</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuIcon(string menuIcon, string sort_)
		{
			return GetByMenuIcon(menuIcon, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuIcon（字段） 查询
		/// </summary>
		/// /// <param name = "menuIcon">图标</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuIcon(string menuIcon, string sort_, TransactionManager tm_)
		{
			return GetByMenuIcon(menuIcon, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuIcon（字段） 查询
		/// </summary>
		/// /// <param name = "menuIcon">图标</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuIcon(string menuIcon, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuIcon` = @MenuIcon", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuIcon", menuIcon != null ? menuIcon : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuIcon
	
		#region GetByMenuKind
		
		/// <summary>
		/// 按 MenuKind（字段） 查询
		/// </summary>
		/// /// <param name = "menuKind">类型 0-目录项 1-链接项</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuKind(int? menuKind)
		{
			return GetByMenuKind(menuKind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuKind（字段） 查询
		/// </summary>
		/// /// <param name = "menuKind">类型 0-目录项 1-链接项</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuKind(int? menuKind, TransactionManager tm_)
		{
			return GetByMenuKind(menuKind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuKind（字段） 查询
		/// </summary>
		/// /// <param name = "menuKind">类型 0-目录项 1-链接项</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuKind(int? menuKind, int top_)
		{
			return GetByMenuKind(menuKind, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuKind（字段） 查询
		/// </summary>
		/// /// <param name = "menuKind">类型 0-目录项 1-链接项</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuKind(int? menuKind, int top_, TransactionManager tm_)
		{
			return GetByMenuKind(menuKind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuKind（字段） 查询
		/// </summary>
		/// /// <param name = "menuKind">类型 0-目录项 1-链接项</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuKind(int? menuKind, string sort_)
		{
			return GetByMenuKind(menuKind, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuKind（字段） 查询
		/// </summary>
		/// /// <param name = "menuKind">类型 0-目录项 1-链接项</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuKind(int? menuKind, string sort_, TransactionManager tm_)
		{
			return GetByMenuKind(menuKind, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuKind（字段） 查询
		/// </summary>
		/// /// <param name = "menuKind">类型 0-目录项 1-链接项</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuKind(int? menuKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuKind` = @MenuKind", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuKind", menuKind.HasValue ? menuKind.Value : (object)DBNull.Value, MySqlDbType.Byte);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuKind
	
		#region GetByMenuUrl
		
		/// <summary>
		/// 按 MenuUrl（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrl">菜单URL，尽量使用相对路径</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrl(string menuUrl)
		{
			return GetByMenuUrl(menuUrl, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuUrl（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrl">菜单URL，尽量使用相对路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrl(string menuUrl, TransactionManager tm_)
		{
			return GetByMenuUrl(menuUrl, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuUrl（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrl">菜单URL，尽量使用相对路径</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrl(string menuUrl, int top_)
		{
			return GetByMenuUrl(menuUrl, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuUrl（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrl">菜单URL，尽量使用相对路径</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrl(string menuUrl, int top_, TransactionManager tm_)
		{
			return GetByMenuUrl(menuUrl, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuUrl（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrl">菜单URL，尽量使用相对路径</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrl(string menuUrl, string sort_)
		{
			return GetByMenuUrl(menuUrl, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuUrl（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrl">菜单URL，尽量使用相对路径</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrl(string menuUrl, string sort_, TransactionManager tm_)
		{
			return GetByMenuUrl(menuUrl, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuUrl（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrl">菜单URL，尽量使用相对路径</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrl(string menuUrl, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuUrl` = @MenuUrl", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuUrl", menuUrl != null ? menuUrl : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuUrl
	
		#region GetByMenuUrlTarget
		
		/// <summary>
		/// 按 MenuUrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrlTarget(int? menuUrlTarget)
		{
			return GetByMenuUrlTarget(menuUrlTarget, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuUrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrlTarget(int? menuUrlTarget, TransactionManager tm_)
		{
			return GetByMenuUrlTarget(menuUrlTarget, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuUrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrlTarget(int? menuUrlTarget, int top_)
		{
			return GetByMenuUrlTarget(menuUrlTarget, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuUrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrlTarget(int? menuUrlTarget, int top_, TransactionManager tm_)
		{
			return GetByMenuUrlTarget(menuUrlTarget, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuUrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrlTarget(int? menuUrlTarget, string sort_)
		{
			return GetByMenuUrlTarget(menuUrlTarget, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuUrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrlTarget(int? menuUrlTarget, string sort_, TransactionManager tm_)
		{
			return GetByMenuUrlTarget(menuUrlTarget, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuUrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "menuUrlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuUrlTarget(int? menuUrlTarget, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuUrlTarget` = @MenuUrlTarget", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuUrlTarget", menuUrlTarget.HasValue ? menuUrlTarget.Value : (object)DBNull.Value, MySqlDbType.Byte);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuUrlTarget
	
		#region GetByMenuPrivParams
		
		/// <summary>
		/// 按 MenuPrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "menuPrivParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPrivParams(string menuPrivParams)
		{
			return GetByMenuPrivParams(menuPrivParams, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuPrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "menuPrivParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPrivParams(string menuPrivParams, TransactionManager tm_)
		{
			return GetByMenuPrivParams(menuPrivParams, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuPrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "menuPrivParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPrivParams(string menuPrivParams, int top_)
		{
			return GetByMenuPrivParams(menuPrivParams, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuPrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "menuPrivParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPrivParams(string menuPrivParams, int top_, TransactionManager tm_)
		{
			return GetByMenuPrivParams(menuPrivParams, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuPrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "menuPrivParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPrivParams(string menuPrivParams, string sort_)
		{
			return GetByMenuPrivParams(menuPrivParams, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuPrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "menuPrivParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPrivParams(string menuPrivParams, string sort_, TransactionManager tm_)
		{
			return GetByMenuPrivParams(menuPrivParams, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuPrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "menuPrivParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPrivParams(string menuPrivParams, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuPrivParams` = @MenuPrivParams", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuPrivParams", menuPrivParams != null ? menuPrivParams : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuPrivParams
	
		#region GetByMenuOrderNum
		
		/// <summary>
		/// 按 MenuOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "menuOrderNum">排序，从小到大</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuOrderNum(int? menuOrderNum)
		{
			return GetByMenuOrderNum(menuOrderNum, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "menuOrderNum">排序，从小到大</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuOrderNum(int? menuOrderNum, TransactionManager tm_)
		{
			return GetByMenuOrderNum(menuOrderNum, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "menuOrderNum">排序，从小到大</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuOrderNum(int? menuOrderNum, int top_)
		{
			return GetByMenuOrderNum(menuOrderNum, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "menuOrderNum">排序，从小到大</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuOrderNum(int? menuOrderNum, int top_, TransactionManager tm_)
		{
			return GetByMenuOrderNum(menuOrderNum, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "menuOrderNum">排序，从小到大</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuOrderNum(int? menuOrderNum, string sort_)
		{
			return GetByMenuOrderNum(menuOrderNum, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "menuOrderNum">排序，从小到大</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuOrderNum(int? menuOrderNum, string sort_, TransactionManager tm_)
		{
			return GetByMenuOrderNum(menuOrderNum, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "menuOrderNum">排序，从小到大</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuOrderNum(int? menuOrderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuOrderNum` = @MenuOrderNum", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuOrderNum", menuOrderNum.HasValue ? menuOrderNum.Value : (object)DBNull.Value, MySqlDbType.Int32);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuOrderNum
	
		#region GetByMenuParentID
		
		/// <summary>
		/// 按 MenuParentID（字段） 查询
		/// </summary>
		/// /// <param name = "menuParentID">父菜单编码 0-根菜单</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuParentID(long? menuParentID)
		{
			return GetByMenuParentID(menuParentID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuParentID（字段） 查询
		/// </summary>
		/// /// <param name = "menuParentID">父菜单编码 0-根菜单</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuParentID(long? menuParentID, TransactionManager tm_)
		{
			return GetByMenuParentID(menuParentID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuParentID（字段） 查询
		/// </summary>
		/// /// <param name = "menuParentID">父菜单编码 0-根菜单</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuParentID(long? menuParentID, int top_)
		{
			return GetByMenuParentID(menuParentID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuParentID（字段） 查询
		/// </summary>
		/// /// <param name = "menuParentID">父菜单编码 0-根菜单</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuParentID(long? menuParentID, int top_, TransactionManager tm_)
		{
			return GetByMenuParentID(menuParentID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuParentID（字段） 查询
		/// </summary>
		/// /// <param name = "menuParentID">父菜单编码 0-根菜单</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuParentID(long? menuParentID, string sort_)
		{
			return GetByMenuParentID(menuParentID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuParentID（字段） 查询
		/// </summary>
		/// /// <param name = "menuParentID">父菜单编码 0-根菜单</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuParentID(long? menuParentID, string sort_, TransactionManager tm_)
		{
			return GetByMenuParentID(menuParentID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuParentID（字段） 查询
		/// </summary>
		/// /// <param name = "menuParentID">父菜单编码 0-根菜单</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuParentID(long? menuParentID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuParentID` = @MenuParentID", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuParentID", menuParentID.HasValue ? menuParentID.Value : (object)DBNull.Value, MySqlDbType.Int64);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuParentID
	
		#region GetByMenuPinyin
		
		/// <summary>
		/// 按 MenuPinyin（字段） 查询
		/// </summary>
		/// /// <param name = "menuPinyin">拼音</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPinyin(string menuPinyin)
		{
			return GetByMenuPinyin(menuPinyin, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuPinyin（字段） 查询
		/// </summary>
		/// /// <param name = "menuPinyin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPinyin(string menuPinyin, TransactionManager tm_)
		{
			return GetByMenuPinyin(menuPinyin, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuPinyin（字段） 查询
		/// </summary>
		/// /// <param name = "menuPinyin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPinyin(string menuPinyin, int top_)
		{
			return GetByMenuPinyin(menuPinyin, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuPinyin（字段） 查询
		/// </summary>
		/// /// <param name = "menuPinyin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPinyin(string menuPinyin, int top_, TransactionManager tm_)
		{
			return GetByMenuPinyin(menuPinyin, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuPinyin（字段） 查询
		/// </summary>
		/// /// <param name = "menuPinyin">拼音</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPinyin(string menuPinyin, string sort_)
		{
			return GetByMenuPinyin(menuPinyin, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuPinyin（字段） 查询
		/// </summary>
		/// /// <param name = "menuPinyin">拼音</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPinyin(string menuPinyin, string sort_, TransactionManager tm_)
		{
			return GetByMenuPinyin(menuPinyin, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuPinyin（字段） 查询
		/// </summary>
		/// /// <param name = "menuPinyin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuPinyin(string menuPinyin, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuPinyin` = @MenuPinyin", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuPinyin", menuPinyin != null ? menuPinyin : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuPinyin
	
		#region GetByMenuNote
		
		/// <summary>
		/// 按 MenuNote（字段） 查询
		/// </summary>
		/// /// <param name = "menuNote">描述</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuNote(string menuNote)
		{
			return GetByMenuNote(menuNote, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuNote（字段） 查询
		/// </summary>
		/// /// <param name = "menuNote">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuNote(string menuNote, TransactionManager tm_)
		{
			return GetByMenuNote(menuNote, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuNote（字段） 查询
		/// </summary>
		/// /// <param name = "menuNote">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuNote(string menuNote, int top_)
		{
			return GetByMenuNote(menuNote, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MenuNote（字段） 查询
		/// </summary>
		/// /// <param name = "menuNote">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuNote(string menuNote, int top_, TransactionManager tm_)
		{
			return GetByMenuNote(menuNote, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MenuNote（字段） 查询
		/// </summary>
		/// /// <param name = "menuNote">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuNote(string menuNote, string sort_)
		{
			return GetByMenuNote(menuNote, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MenuNote（字段） 查询
		/// </summary>
		/// /// <param name = "menuNote">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuNote(string menuNote, string sort_, TransactionManager tm_)
		{
			return GetByMenuNote(menuNote, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MenuNote（字段） 查询
		/// </summary>
		/// /// <param name = "menuNote">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByMenuNote(string menuNote, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`MenuNote` = @MenuNote", top_, sort_);
			var parameter_ = Database.CreateInParameter("@MenuNote", menuNote != null ? menuNote : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByMenuNote
	
		#region GetByPrivNote
		
		/// <summary>
		/// 按 PrivNote（字段） 查询
		/// </summary>
		/// /// <param name = "privNote">描述</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivNote(string privNote)
		{
			return GetByPrivNote(privNote, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivNote（字段） 查询
		/// </summary>
		/// /// <param name = "privNote">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivNote(string privNote, TransactionManager tm_)
		{
			return GetByPrivNote(privNote, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivNote（字段） 查询
		/// </summary>
		/// /// <param name = "privNote">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivNote(string privNote, int top_)
		{
			return GetByPrivNote(privNote, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivNote（字段） 查询
		/// </summary>
		/// /// <param name = "privNote">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivNote(string privNote, int top_, TransactionManager tm_)
		{
			return GetByPrivNote(privNote, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivNote（字段） 查询
		/// </summary>
		/// /// <param name = "privNote">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivNote(string privNote, string sort_)
		{
			return GetByPrivNote(privNote, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PrivNote（字段） 查询
		/// </summary>
		/// /// <param name = "privNote">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivNote(string privNote, string sort_, TransactionManager tm_)
		{
			return GetByPrivNote(privNote, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PrivNote（字段） 查询
		/// </summary>
		/// /// <param name = "privNote">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<V_admin_privEO> GetByPrivNote(string privNote, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PrivNote` = @PrivNote", top_, sort_);
			var parameter_ = Database.CreateInParameter("@PrivNote", privNote != null ? privNote : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlList(sql_, new MySqlParameter[] { parameter_ }, tm_, V_admin_privEO.MapDataReader);
		}
		#endregion // GetByPrivNote
	
	
		#endregion // Get
	}
	#endregion // MO
}
