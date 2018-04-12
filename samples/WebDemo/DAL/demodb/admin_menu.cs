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
	/// 管理菜单
	/// 【表 admin_menu 的实体类】
	/// </summary>
	[Serializable]
	public class Admin_menuEO : IRowMapper<Admin_menuEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Admin_menuEO()
		{
			this.Kind = 0;
			this.UrlTarget = 0;
			this.OrderNum = 0;
			this.ParentID = 0;
			this.Status = 0;
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected long _originalMenuID;
		/// <summary>
		/// 【数据库中的原始主键 MenuID 值的副本，用于主键值更新】
		/// </summary>
		public long OriginalMenuID
		{
			get { return _originalMenuID; }
			set { HasOriginal = true; _originalMenuID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "MenuID", MenuID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 菜单编码
		/// 【主键 bigint(20)】
		/// </summary>
		public long MenuID { get; set; }
		/// <summary>
		/// 菜单显示标题
		/// 【字段 varchar(50)】
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// 类型 0-目录项 1-链接项
		/// 【字段 tinyint(4)】
		/// </summary>
		public int Kind { get; set; }
		/// <summary>
		/// 图标
		/// 【字段 varchar(250)】
		/// </summary>
		public string Icon { get; set; }
		/// <summary>
		/// 菜单URL，尽量使用相对路径
		/// 【字段 varchar(250)】
		/// </summary>
		public string Url { get; set; }
		/// <summary>
		/// 链接模式 0-TAB打开 1-新窗口打开
		/// 【字段 tinyint(4)】
		/// </summary>
		public int UrlTarget { get; set; }
		/// <summary>
		/// 功能和数据权限参数。格式：类型-参数| 类型-参数
		///              用于在定义页面内权限时可设置的权限选项列表
		///              如：ControlID-btnOk|ControlID-btnCancle
		/// 【字段 varchar(250)】
		/// </summary>
		public string PrivParams { get; set; }
		/// <summary>
		/// 拼音
		/// 【字段 varchar(20)】
		/// </summary>
		public string Pinyin { get; set; }
		/// <summary>
		/// 描述
		/// 【字段 varchar(500)】
		/// </summary>
		public string Note { get; set; }
		/// <summary>
		/// 排序，从小到大
		/// 【字段 int(11)】
		/// </summary>
		public int OrderNum { get; set; }
		/// <summary>
		/// 父菜单编码 0-根菜单
		/// 【字段 bigint(20)】
		/// </summary>
		public long ParentID { get; set; }
		/// <summary>
		/// 状态 0-无效 1-有效
		/// 【字段 tinyint(4)】
		/// </summary>
		public int Status { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Admin_menuEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Admin_menuEO MapDataReader(IDataReader reader)
		{
		    Admin_menuEO ret = new Admin_menuEO();
			ret.MenuID = reader.ToInt64("MenuID");
			ret.OriginalMenuID = ret.MenuID;
			ret.Title = reader.ToString("Title");
			ret.Kind = reader.ToInt32("Kind");
			ret.Icon = reader.ToString("Icon");
			ret.Url = reader.ToString("Url");
			ret.UrlTarget = reader.ToInt32("UrlTarget");
			ret.PrivParams = reader.ToString("PrivParams");
			ret.Pinyin = reader.ToString("Pinyin");
			ret.Note = reader.ToString("Note");
			ret.OrderNum = reader.ToInt32("OrderNum");
			ret.ParentID = reader.ToInt64("ParentID");
			ret.Status = reader.ToInt32("Status");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 管理菜单
	/// 【表 admin_menu 的操作类】
	/// </summary>
	public class Admin_menuMO : MySqlTableMO<Admin_menuEO>
	{
	    public override string TableName => "`admin_menu`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Admin_menuMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Admin_menuMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Admin_menuMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Admin_menuEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `admin_menu` (`Title`, `Kind`, `Icon`, `Url`, `UrlTarget`, `PrivParams`, `Pinyin`, `Note`, `OrderNum`, `ParentID`, `Status`) VALUE (@Title, @Kind, @Icon, @Url, @UrlTarget, @PrivParams, @Pinyin, @Note, @OrderNum, @ParentID, @Status);SELECT LAST_INSERT_ID();";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Title", item.Title != null ? item.Title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Kind", item.Kind, MySqlDbType.Byte),
				Database.CreateInParameter("@Icon", item.Icon != null ? item.Icon : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Url", item.Url != null ? item.Url : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UrlTarget", item.UrlTarget, MySqlDbType.Byte),
				Database.CreateInParameter("@PrivParams", item.PrivParams != null ? item.PrivParams : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Pinyin", item.Pinyin != null ? item.Pinyin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
				Database.CreateInParameter("@ParentID", item.ParentID, MySqlDbType.Int64),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
			};
			item.MenuID = Database.ExecSqlScalar<long>(sql, paras, tm); 
	        return 1;
		}
	    
	    #endregion // Add
	    
		#region  Remove
		
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long menuID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_menu` WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Admin_menuEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.MenuID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByTitle
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTitle(string title, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE " + (title != null ? "`Title` = @Title" : "`Title` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (title != null)
				paras_.Add(Database.CreateInParameter("@Title", title, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByTitle
	
		#region RemoveByKind
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByKind(int kind, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE `Kind` = @Kind";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByKind
	
		#region RemoveByIcon
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIcon(string icon, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE " + (icon != null ? "`Icon` = @Icon" : "`Icon` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (icon != null)
				paras_.Add(Database.CreateInParameter("@Icon", icon, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByIcon
	
		#region RemoveByUrl
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUrl(string url, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE " + (url != null ? "`Url` = @Url" : "`Url` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (url != null)
				paras_.Add(Database.CreateInParameter("@Url", url, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByUrl
	
		#region RemoveByUrlTarget
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUrlTarget(int urlTarget, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE `UrlTarget` = @UrlTarget";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UrlTarget", urlTarget, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByUrlTarget
	
		#region RemoveByPrivParams
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPrivParams(string privParams, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE " + (privParams != null ? "`PrivParams` = @PrivParams" : "`PrivParams` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (privParams != null)
				paras_.Add(Database.CreateInParameter("@PrivParams", privParams, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPrivParams
	
		#region RemoveByPinyin
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPinyin(string pinyin, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE " + (pinyin != null ? "`Pinyin` = @Pinyin" : "`Pinyin` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (pinyin != null)
				paras_.Add(Database.CreateInParameter("@Pinyin", pinyin, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPinyin
	
		#region RemoveByNote
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByNote(string note, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE " + (note != null ? "`Note` = @Note" : "`Note` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByNote
	
		#region RemoveByOrderNum
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderNum(int orderNum, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE `OrderNum` = @OrderNum";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByOrderNum
	
		#region RemoveByParentID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByParentID(long parentID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE `ParentID` = @ParentID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ParentID", parentID, MySqlDbType.Int64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByParentID
	
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_menu` WHERE `Status` = @Status";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByStatus
	
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
		public int Put(Admin_menuEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `admin_menu` SET `Title` = @Title, `Kind` = @Kind, `Icon` = @Icon, `Url` = @Url, `UrlTarget` = @UrlTarget, `PrivParams` = @PrivParams, `Pinyin` = @Pinyin, `Note` = @Note, `OrderNum` = @OrderNum, `ParentID` = @ParentID, `Status` = @Status WHERE `MenuID` = @MenuID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Title", item.Title != null ? item.Title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Kind", item.Kind, MySqlDbType.Byte),
				Database.CreateInParameter("@Icon", item.Icon != null ? item.Icon : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Url", item.Url != null ? item.Url : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UrlTarget", item.UrlTarget, MySqlDbType.Byte),
				Database.CreateInParameter("@PrivParams", item.PrivParams != null ? item.PrivParams : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Pinyin", item.Pinyin != null ? item.Pinyin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
				Database.CreateInParameter("@ParentID", item.ParentID, MySqlDbType.Int64),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@MenuID_Original", item.HasOriginal ? item.OriginalMenuID : item.MenuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Admin_menuEO> items, TransactionManager tm = null)
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
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long menuID, string set_, params object[] values_)
		{
			return Put(set_, "`MenuID` = @MenuID", ConcatValues(values_, menuID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long menuID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`MenuID` = @MenuID", tm_, ConcatValues(values_, menuID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long menuID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
	        };
			return Put(set_, "`MenuID` = @MenuID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutTitle
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTitleByPK(long menuID, string title, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Title` = @Title  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Title", title != null ? title : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTitle(string title, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Title` = @Title";
			var parameter_ = Database.CreateInParameter("@Title", title != null ? title : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTitle
	
		#region PutKind
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutKindByPK(long menuID, int kind, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Kind` = @Kind  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutKind(int kind, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Kind` = @Kind";
			var parameter_ = Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutKind
	
		#region PutIcon
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "icon">图标</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIconByPK(long menuID, string icon, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Icon` = @Icon  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Icon", icon != null ? icon : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIcon(string icon, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Icon` = @Icon";
			var parameter_ = Database.CreateInParameter("@Icon", icon != null ? icon : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIcon
	
		#region PutUrl
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUrlByPK(long menuID, string url, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Url` = @Url  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Url", url != null ? url : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUrl(string url, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Url` = @Url";
			var parameter_ = Database.CreateInParameter("@Url", url != null ? url : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUrl
	
		#region PutUrlTarget
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUrlTargetByPK(long menuID, int urlTarget, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `UrlTarget` = @UrlTarget  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UrlTarget", urlTarget, MySqlDbType.Byte),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUrlTarget(int urlTarget, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `UrlTarget` = @UrlTarget";
			var parameter_ = Database.CreateInParameter("@UrlTarget", urlTarget, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUrlTarget
	
		#region PutPrivParams
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrivParamsByPK(long menuID, string privParams, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `PrivParams` = @PrivParams  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PrivParams", privParams != null ? privParams : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPrivParams(string privParams, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `PrivParams` = @PrivParams";
			var parameter_ = Database.CreateInParameter("@PrivParams", privParams != null ? privParams : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPrivParams
	
		#region PutPinyin
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPinyinByPK(long menuID, string pinyin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Pinyin` = @Pinyin  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Pinyin", pinyin != null ? pinyin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPinyin(string pinyin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Pinyin` = @Pinyin";
			var parameter_ = Database.CreateInParameter("@Pinyin", pinyin != null ? pinyin : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPinyin
	
		#region PutNote
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNoteByPK(long menuID, string note, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Note` = @Note  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_menu` SET `Note` = @Note";
			var parameter_ = Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutNote
	
		#region PutOrderNum
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderNumByPK(long menuID, int orderNum, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `OrderNum` = @OrderNum  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderNum(int orderNum, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `OrderNum` = @OrderNum";
			var parameter_ = Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderNum
	
		#region PutParentID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutParentIDByPK(long menuID, long parentID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `ParentID` = @ParentID  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ParentID", parentID, MySqlDbType.Int64),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutParentID(long parentID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `ParentID` = @ParentID";
			var parameter_ = Database.CreateInParameter("@ParentID", parentID, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutParentID
	
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "menuID">菜单编码</param>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(long menuID, int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_menu` SET `Status` = @Status  WHERE `MenuID` = @MenuID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Byte),
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
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
			const string sql_ = @"UPDATE `admin_menu` SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Admin_menuEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.MenuID) == null)
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
		/// /// <param name = "menuID">菜单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Admin_menuEO GetByPK(long menuID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`MenuID` = @MenuID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@MenuID", menuID, MySqlDbType.Int64),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
	
		#region GetByXXX
	
		#region GetByTitle
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByTitle(string title)
		{
			return GetByTitle(title, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByTitle(string title, TransactionManager tm_)
		{
			return GetByTitle(title, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByTitle(string title, int top_)
		{
			return GetByTitle(title, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByTitle(string title, int top_, TransactionManager tm_)
		{
			return GetByTitle(title, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByTitle(string title, string sort_)
		{
			return GetByTitle(title, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByTitle(string title, string sort_, TransactionManager tm_)
		{
			return GetByTitle(title, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Title（字段） 查询
		/// </summary>
		/// /// <param name = "title">菜单显示标题</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByTitle(string title, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(title != null ? "`Title` = @Title" : "`Title` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (title != null)
				paras_.Add(Database.CreateInParameter("@Title", title, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByTitle
	
		#region GetByKind
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByKind(int kind)
		{
			return GetByKind(kind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByKind(int kind, TransactionManager tm_)
		{
			return GetByKind(kind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByKind(int kind, int top_)
		{
			return GetByKind(kind, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByKind(int kind, int top_, TransactionManager tm_)
		{
			return GetByKind(kind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByKind(int kind, string sort_)
		{
			return GetByKind(kind, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByKind(int kind, string sort_, TransactionManager tm_)
		{
			return GetByKind(kind, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Kind（字段） 查询
		/// </summary>
		/// /// <param name = "kind">类型 0-目录项 1-链接项</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByKind(int kind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Kind` = @Kind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Kind", kind, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByKind
	
		#region GetByIcon
		
		/// <summary>
		/// 按 Icon（字段） 查询
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByIcon(string icon)
		{
			return GetByIcon(icon, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Icon（字段） 查询
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByIcon(string icon, TransactionManager tm_)
		{
			return GetByIcon(icon, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Icon（字段） 查询
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByIcon(string icon, int top_)
		{
			return GetByIcon(icon, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Icon（字段） 查询
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByIcon(string icon, int top_, TransactionManager tm_)
		{
			return GetByIcon(icon, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Icon（字段） 查询
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByIcon(string icon, string sort_)
		{
			return GetByIcon(icon, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Icon（字段） 查询
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByIcon(string icon, string sort_, TransactionManager tm_)
		{
			return GetByIcon(icon, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Icon（字段） 查询
		/// </summary>
		/// /// <param name = "icon">图标</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByIcon(string icon, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(icon != null ? "`Icon` = @Icon" : "`Icon` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (icon != null)
				paras_.Add(Database.CreateInParameter("@Icon", icon, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByIcon
	
		#region GetByUrl
		
		/// <summary>
		/// 按 Url（字段） 查询
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrl(string url)
		{
			return GetByUrl(url, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Url（字段） 查询
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrl(string url, TransactionManager tm_)
		{
			return GetByUrl(url, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Url（字段） 查询
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrl(string url, int top_)
		{
			return GetByUrl(url, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Url（字段） 查询
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrl(string url, int top_, TransactionManager tm_)
		{
			return GetByUrl(url, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Url（字段） 查询
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrl(string url, string sort_)
		{
			return GetByUrl(url, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Url（字段） 查询
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrl(string url, string sort_, TransactionManager tm_)
		{
			return GetByUrl(url, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Url（字段） 查询
		/// </summary>
		/// /// <param name = "url">菜单URL，尽量使用相对路径</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrl(string url, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(url != null ? "`Url` = @Url" : "`Url` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (url != null)
				paras_.Add(Database.CreateInParameter("@Url", url, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByUrl
	
		#region GetByUrlTarget
		
		/// <summary>
		/// 按 UrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrlTarget(int urlTarget)
		{
			return GetByUrlTarget(urlTarget, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrlTarget(int urlTarget, TransactionManager tm_)
		{
			return GetByUrlTarget(urlTarget, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrlTarget(int urlTarget, int top_)
		{
			return GetByUrlTarget(urlTarget, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrlTarget(int urlTarget, int top_, TransactionManager tm_)
		{
			return GetByUrlTarget(urlTarget, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrlTarget(int urlTarget, string sort_)
		{
			return GetByUrlTarget(urlTarget, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrlTarget(int urlTarget, string sort_, TransactionManager tm_)
		{
			return GetByUrlTarget(urlTarget, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UrlTarget（字段） 查询
		/// </summary>
		/// /// <param name = "urlTarget">链接模式 0-TAB打开 1-新窗口打开</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByUrlTarget(int urlTarget, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UrlTarget` = @UrlTarget", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UrlTarget", urlTarget, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByUrlTarget
	
		#region GetByPrivParams
		
		/// <summary>
		/// 按 PrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPrivParams(string privParams)
		{
			return GetByPrivParams(privParams, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPrivParams(string privParams, TransactionManager tm_)
		{
			return GetByPrivParams(privParams, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPrivParams(string privParams, int top_)
		{
			return GetByPrivParams(privParams, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPrivParams(string privParams, int top_, TransactionManager tm_)
		{
			return GetByPrivParams(privParams, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPrivParams(string privParams, string sort_)
		{
			return GetByPrivParams(privParams, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPrivParams(string privParams, string sort_, TransactionManager tm_)
		{
			return GetByPrivParams(privParams, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PrivParams（字段） 查询
		/// </summary>
		/// /// <param name = "privParams">功能和数据权限参数。格式：类型-参数| 类型-参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPrivParams(string privParams, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(privParams != null ? "`PrivParams` = @PrivParams" : "`PrivParams` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (privParams != null)
				paras_.Add(Database.CreateInParameter("@PrivParams", privParams, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByPrivParams
	
		#region GetByPinyin
		
		/// <summary>
		/// 按 Pinyin（字段） 查询
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPinyin(string pinyin)
		{
			return GetByPinyin(pinyin, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Pinyin（字段） 查询
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPinyin(string pinyin, TransactionManager tm_)
		{
			return GetByPinyin(pinyin, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Pinyin（字段） 查询
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPinyin(string pinyin, int top_)
		{
			return GetByPinyin(pinyin, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Pinyin（字段） 查询
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPinyin(string pinyin, int top_, TransactionManager tm_)
		{
			return GetByPinyin(pinyin, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Pinyin（字段） 查询
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPinyin(string pinyin, string sort_)
		{
			return GetByPinyin(pinyin, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Pinyin（字段） 查询
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPinyin(string pinyin, string sort_, TransactionManager tm_)
		{
			return GetByPinyin(pinyin, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Pinyin（字段） 查询
		/// </summary>
		/// /// <param name = "pinyin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByPinyin(string pinyin, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(pinyin != null ? "`Pinyin` = @Pinyin" : "`Pinyin` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (pinyin != null)
				paras_.Add(Database.CreateInParameter("@Pinyin", pinyin, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByPinyin
	
		#region GetByNote
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByNote(string note)
		{
			return GetByNote(note, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByNote(string note, TransactionManager tm_)
		{
			return GetByNote(note, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByNote(string note, int top_)
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
		public List<Admin_menuEO> GetByNote(string note, int top_, TransactionManager tm_)
		{
			return GetByNote(note, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">描述</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByNote(string note, string sort_)
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
		public List<Admin_menuEO> GetByNote(string note, string sort_, TransactionManager tm_)
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
		public List<Admin_menuEO> GetByNote(string note, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(note != null ? "`Note` = @Note" : "`Note` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByNote
	
		#region GetByOrderNum
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByOrderNum(int orderNum)
		{
			return GetByOrderNum(orderNum, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByOrderNum(int orderNum, TransactionManager tm_)
		{
			return GetByOrderNum(orderNum, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByOrderNum(int orderNum, int top_)
		{
			return GetByOrderNum(orderNum, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByOrderNum(int orderNum, int top_, TransactionManager tm_)
		{
			return GetByOrderNum(orderNum, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByOrderNum(int orderNum, string sort_)
		{
			return GetByOrderNum(orderNum, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByOrderNum(int orderNum, string sort_, TransactionManager tm_)
		{
			return GetByOrderNum(orderNum, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序，从小到大</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByOrderNum(int orderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderNum` = @OrderNum", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByOrderNum
	
		#region GetByParentID
		
		/// <summary>
		/// 按 ParentID（字段） 查询
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByParentID(long parentID)
		{
			return GetByParentID(parentID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ParentID（字段） 查询
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByParentID(long parentID, TransactionManager tm_)
		{
			return GetByParentID(parentID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ParentID（字段） 查询
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByParentID(long parentID, int top_)
		{
			return GetByParentID(parentID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ParentID（字段） 查询
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByParentID(long parentID, int top_, TransactionManager tm_)
		{
			return GetByParentID(parentID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ParentID（字段） 查询
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByParentID(long parentID, string sort_)
		{
			return GetByParentID(parentID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ParentID（字段） 查询
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByParentID(long parentID, string sort_, TransactionManager tm_)
		{
			return GetByParentID(parentID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ParentID（字段） 查询
		/// </summary>
		/// /// <param name = "parentID">父菜单编码 0-根菜单</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByParentID(long parentID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ParentID` = @ParentID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ParentID", parentID, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByParentID
	
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByStatus(int status, int top_)
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
		public List<Admin_menuEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_menuEO> GetByStatus(int status, string sort_)
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
		public List<Admin_menuEO> GetByStatus(int status, string sort_, TransactionManager tm_)
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
		public List<Admin_menuEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_menuEO.MapDataReader);
		}
		#endregion // GetByStatus
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
