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
	/// 后台用户表
	/// 【表 admin_user 的实体类】
	/// </summary>
	[Serializable]
	public class Admin_userEO : IRowMapper<Admin_userEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Admin_userEO()
		{
			this.Status = 0;
			this.IsAdmin = false;
			this.RecDate = DateTime.Now;
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
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
	        return new Dictionary<string, object>() { { "AdminID", AdminID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 管理用户ID
		/// 【主键 varchar(20)】
		/// </summary>
		public string AdminID { get; set; }
		/// <summary>
		/// 登录密码
		/// 【字段 varchar(100)】
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// 用户真实姓名
		/// 【字段 varchar(20)】
		/// </summary>
		public string RealName { get; set; }
		/// <summary>
		/// 状态 0-无效 1-有效
		/// 【字段 tinyint(4)】
		/// </summary>
		public int Status { get; set; }
		/// <summary>
		/// 是否管理员
		/// 【字段 tinyint(1)】
		/// </summary>
		public bool IsAdmin { get; set; }
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
		public Admin_userEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Admin_userEO MapDataReader(IDataReader reader)
		{
		    Admin_userEO ret = new Admin_userEO();
			ret.AdminID = reader.ToString("AdminID");
			ret.OriginalAdminID = ret.AdminID;
			ret.Password = reader.ToString("Password");
			ret.RealName = reader.ToString("RealName");
			ret.Status = reader.ToInt32("Status");
			ret.IsAdmin = reader.ToBoolean("IsAdmin");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 后台用户表
	/// 【表 admin_user 的操作类】
	/// </summary>
	public class Admin_userMO : MySqlTableMO<Admin_userEO>
	{
	    public override string TableName => "`admin_user`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Admin_userMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Admin_userMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Admin_userMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Admin_userEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `admin_user` (`AdminID`, `Password`, `RealName`, `Status`, `IsAdmin`, `RecDate`) VALUE (@AdminID, @Password, @RealName, @Status, @IsAdmin, @RecDate);";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AdminID", item.AdminID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Password", item.Password != null ? item.Password : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RealName", item.RealName != null ? item.RealName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@IsAdmin", item.IsAdmin, MySqlDbType.Byte),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
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
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string adminID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `admin_user` WHERE `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>() 
			{
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
		public int Remove(Admin_userEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.AdminID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByPassword
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPassword(string password, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_user` WHERE " + (password != null ? "`Password` = @Password" : "`Password` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (password != null)
				paras_.Add(Database.CreateInParameter("@Password", password, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPassword
	
		#region RemoveByRealName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRealName(string realName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_user` WHERE " + (realName != null ? "`RealName` = @RealName" : "`RealName` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (realName != null)
				paras_.Add(Database.CreateInParameter("@RealName", realName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByRealName
	
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_user` WHERE `Status` = @Status";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByStatus
	
		#region RemoveByIsAdmin
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsAdmin(bool isAdmin, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_user` WHERE `IsAdmin` = @IsAdmin";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAdmin", isAdmin, MySqlDbType.Byte));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByIsAdmin
	
		#region RemoveByRecDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `admin_user` WHERE `RecDate` = @RecDate";
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
		public int Put(Admin_userEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `admin_user` SET `AdminID` = @AdminID, `Password` = @Password, `RealName` = @RealName, `Status` = @Status, `IsAdmin` = @IsAdmin WHERE `AdminID` = @AdminID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AdminID", item.AdminID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Password", item.Password != null ? item.Password : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RealName", item.RealName != null ? item.RealName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@IsAdmin", item.IsAdmin, MySqlDbType.Byte),
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
		public int Put(IEnumerable<Admin_userEO> items, TransactionManager tm = null)
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
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string adminID, string set_, params object[] values_)
		{
			return Put(set_, "`AdminID` = @AdminID", ConcatValues(values_, adminID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string adminID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`AdminID` = @AdminID", tm_, ConcatValues(values_, adminID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string adminID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`AdminID` = @AdminID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutPassword
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// /// <param name = "password">登录密码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPasswordByPK(string adminID, string password, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `Password` = @Password  WHERE `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Password", password != null ? password : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPassword(string password, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `Password` = @Password";
			var parameter_ = Database.CreateInParameter("@Password", password != null ? password : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPassword
	
		#region PutRealName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRealNameByPK(string adminID, string realName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `RealName` = @RealName  WHERE `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RealName", realName != null ? realName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRealName(string realName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `RealName` = @RealName";
			var parameter_ = Database.CreateInParameter("@RealName", realName != null ? realName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRealName
	
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(string adminID, int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `Status` = @Status  WHERE `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Byte),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
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
			const string sql_ = @"UPDATE `admin_user` SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
	
		#region PutIsAdmin
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAdminByPK(string adminID, bool isAdmin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `IsAdmin` = @IsAdmin  WHERE `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsAdmin", isAdmin, MySqlDbType.Byte),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAdmin(bool isAdmin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `IsAdmin` = @IsAdmin";
			var parameter_ = Database.CreateInParameter("@IsAdmin", isAdmin, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsAdmin
	
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "adminID">管理用户ID</param>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string adminID, DateTime recDate, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `admin_user` SET `RecDate` = @RecDate  WHERE `AdminID` = @AdminID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
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
			const string sql_ = @"UPDATE `admin_user` SET `RecDate` = @RecDate";
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
		public bool Set(Admin_userEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.AdminID) == null)
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
		/// /// <param name = "adminID">管理用户ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Admin_userEO GetByPK(string adminID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`AdminID` = @AdminID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AdminID", adminID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Admin_userEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
	
		#region GetByXXX
	
		#region GetByPassword
		
		/// <summary>
		/// 按 Password（字段） 查询
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByPassword(string password)
		{
			return GetByPassword(password, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Password（字段） 查询
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByPassword(string password, TransactionManager tm_)
		{
			return GetByPassword(password, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Password（字段） 查询
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByPassword(string password, int top_)
		{
			return GetByPassword(password, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Password（字段） 查询
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByPassword(string password, int top_, TransactionManager tm_)
		{
			return GetByPassword(password, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Password（字段） 查询
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByPassword(string password, string sort_)
		{
			return GetByPassword(password, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Password（字段） 查询
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByPassword(string password, string sort_, TransactionManager tm_)
		{
			return GetByPassword(password, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Password（字段） 查询
		/// </summary>
		/// /// <param name = "password">登录密码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByPassword(string password, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(password != null ? "`Password` = @Password" : "`Password` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (password != null)
				paras_.Add(Database.CreateInParameter("@Password", password, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_userEO.MapDataReader);
		}
		#endregion // GetByPassword
	
		#region GetByRealName
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRealName(string realName)
		{
			return GetByRealName(realName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRealName(string realName, TransactionManager tm_)
		{
			return GetByRealName(realName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRealName(string realName, int top_)
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
		public List<Admin_userEO> GetByRealName(string realName, int top_, TransactionManager tm_)
		{
			return GetByRealName(realName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RealName（字段） 查询
		/// </summary>
		/// /// <param name = "realName">用户真实姓名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRealName(string realName, string sort_)
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
		public List<Admin_userEO> GetByRealName(string realName, string sort_, TransactionManager tm_)
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
		public List<Admin_userEO> GetByRealName(string realName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(realName != null ? "`RealName` = @RealName" : "`RealName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (realName != null)
				paras_.Add(Database.CreateInParameter("@RealName", realName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_userEO.MapDataReader);
		}
		#endregion // GetByRealName
	
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByStatus(int status, int top_)
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
		public List<Admin_userEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态 0-无效 1-有效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByStatus(int status, string sort_)
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
		public List<Admin_userEO> GetByStatus(int status, string sort_, TransactionManager tm_)
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
		public List<Admin_userEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_userEO.MapDataReader);
		}
		#endregion // GetByStatus
	
		#region GetByIsAdmin
		
		/// <summary>
		/// 按 IsAdmin（字段） 查询
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByIsAdmin(bool isAdmin)
		{
			return GetByIsAdmin(isAdmin, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAdmin（字段） 查询
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByIsAdmin(bool isAdmin, TransactionManager tm_)
		{
			return GetByIsAdmin(isAdmin, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAdmin（字段） 查询
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByIsAdmin(bool isAdmin, int top_)
		{
			return GetByIsAdmin(isAdmin, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAdmin（字段） 查询
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByIsAdmin(bool isAdmin, int top_, TransactionManager tm_)
		{
			return GetByIsAdmin(isAdmin, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAdmin（字段） 查询
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByIsAdmin(bool isAdmin, string sort_)
		{
			return GetByIsAdmin(isAdmin, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsAdmin（字段） 查询
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByIsAdmin(bool isAdmin, string sort_, TransactionManager tm_)
		{
			return GetByIsAdmin(isAdmin, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsAdmin（字段） 查询
		/// </summary>
		/// /// <param name = "isAdmin">是否管理员</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByIsAdmin(bool isAdmin, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAdmin` = @IsAdmin", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAdmin", isAdmin, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_userEO.MapDataReader);
		}
		#endregion // GetByIsAdmin
	
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRecDate(DateTime recDate, int top_)
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
		public List<Admin_userEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录日期</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Admin_userEO> GetByRecDate(DateTime recDate, string sort_)
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
		public List<Admin_userEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Admin_userEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Admin_userEO.MapDataReader);
		}
		#endregion // GetByRecDate
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
