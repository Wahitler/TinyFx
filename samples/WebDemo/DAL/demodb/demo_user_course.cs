/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0 by JiangHui 2016-06-20
 * 文档生成时间：2018-04-11 11: 25:08
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
	/// 用户分类表
	/// 【表 demo_user_course 的实体类】
	/// </summary>
	[Serializable]
	public class Demo_user_courseEO : IRowMapper<Demo_user_courseEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Demo_user_courseEO()
		{
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected long _originalUserID;
		/// <summary>
		/// 【数据库中的原始主键 UserID 值的副本，用于主键值更新】
		/// </summary>
		public long OriginalUserID
		{
			get { return _originalUserID; }
			set { HasOriginal = true; _originalUserID = value; }
		}
		protected string _originalCourseID;
		/// <summary>
		/// 【数据库中的原始主键 CourseID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalCourseID
		{
			get { return _originalCourseID; }
			set { HasOriginal = true; _originalCourseID = value; }
		}
		protected int _originalYear;
		/// <summary>
		/// 【数据库中的原始主键 Year 值的副本，用于主键值更新】
		/// </summary>
		public int OriginalYear
		{
			get { return _originalYear; }
			set { HasOriginal = true; _originalYear = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "UserID", UserID },  { "CourseID", CourseID },  { "Year", Year }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 用户编码（自增字段）
		/// 【主键 bigint(20)】
		/// </summary>
		public long UserID { get; set; }
		/// <summary>
		/// 学年
		/// 【主键 year(4)】
		/// </summary>
		public int Year { get; set; }
		/// <summary>
		/// 课程编码（GUID）
		/// 【主键 char(36)】
		/// </summary>
		public string CourseID { get; set; }
		/// <summary>
		/// 说明
		/// 【字段 text】
		/// </summary>
		public string Note { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Demo_user_courseEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Demo_user_courseEO MapDataReader(IDataReader reader)
		{
		    Demo_user_courseEO ret = new Demo_user_courseEO();
			ret.UserID = reader.ToInt64("UserID");
			ret.OriginalUserID = ret.UserID;
			ret.Year = reader.ToInt32("Year");
			ret.OriginalYear = ret.Year;
			ret.CourseID = reader.ToString("CourseID");
			ret.OriginalCourseID = ret.CourseID;
			ret.Note = reader.ToString("Note");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 用户分类表
	/// 【表 demo_user_course 的操作类】
	/// </summary>
	public class Demo_user_courseMO : MySqlTableMO<Demo_user_courseEO>
	{
	    public override string TableName => "`demo_user_course`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Demo_user_courseMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Demo_user_courseMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Demo_user_courseMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Demo_user_courseEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `demo_user_course` (`UserID`, `Year`, `CourseID`, `Note`) VALUE (@UserID, @Year, @CourseID, @Note);";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.Int64),
				Database.CreateInParameter("@Year", item.Year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", item.CourseID, MySqlDbType.String),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.Text),
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
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(long userID, string courseID, int year, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `demo_user_course` WHERE `UserID` = @UserID AND `CourseID` = @CourseID AND `Year` = @Year";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Demo_user_courseEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.UserID, item.CourseID, item.Year, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByUserID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUserID(long userID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user_course` WHERE `UserID` = @UserID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByUserID
	
		#region RemoveByYear
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByYear(int year, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user_course` WHERE `Year` = @Year";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Year", year, MySqlDbType.Year));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByYear
	
		#region RemoveByCourseID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCourseID(string courseID, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user_course` WHERE `CourseID` = @CourseID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByCourseID
	
		#region RemoveByNote
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByNote(string note, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_user_course` WHERE " + (note != null ? "`Note` = @Note" : "`Note` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.Text));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByNote
	
		#endregion // RemoveByXXX
	
		#region RemoveByFKOrUnique
	
		#region RemoveByYearAndCourseID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByYearAndCourseID(int year, string courseID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `demo_user_course` WHERE `Year` = @Year AND `CourseID` = @CourseID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByYearAndCourseID
	
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
		public int Put(Demo_user_courseEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `demo_user_course` SET `UserID` = @UserID, `Year` = @Year, `CourseID` = @CourseID, `Note` = @Note WHERE `UserID` = @UserID_Original AND `CourseID` = @CourseID_Original AND `Year` = @Year_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.Int64),
				Database.CreateInParameter("@Year", item.Year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", item.CourseID, MySqlDbType.String),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@UserID_Original", item.HasOriginal ? item.OriginalUserID : item.UserID, MySqlDbType.Int64),
				Database.CreateInParameter("@CourseID_Original", item.HasOriginal ? item.OriginalCourseID : item.CourseID, MySqlDbType.String),
				Database.CreateInParameter("@Year_Original", item.HasOriginal ? item.OriginalYear : item.Year, MySqlDbType.Year),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Demo_user_courseEO> items, TransactionManager tm = null)
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
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "year">学年</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long userID, string courseID, int year, string set_, params object[] values_)
		{
			return Put(set_, "`UserID` = @UserID AND `CourseID` = @CourseID AND `Year` = @Year", ConcatValues(values_, userID, courseID, year));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "year">学年</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long userID, string courseID, int year, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`UserID` = @UserID AND `CourseID` = @CourseID AND `Year` = @Year", tm_, ConcatValues(values_, userID, courseID, year));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "year">学年</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(long userID, string courseID, int year, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
	        };
			return Put(set_, "`UserID` = @UserID AND `CourseID` = @CourseID AND `Year` = @Year", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutUserID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserID(long userID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user_course` SET `UserID` = @UserID";
			var parameter_ = Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserID
	
		#region PutYear
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutYear(int year, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user_course` SET `Year` = @Year";
			var parameter_ = Database.CreateInParameter("@Year", year, MySqlDbType.Year);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutYear
	
		#region PutCourseID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCourseID(string courseID, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user_course` SET `CourseID` = @CourseID";
			var parameter_ = Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCourseID
	
		#region PutNote
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "year">学年</param>
		/// /// <param name = "note">说明</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNoteByPK(long userID, string courseID, int year, string note, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user_course` SET `Note` = @Note  WHERE `UserID` = @UserID AND `CourseID` = @CourseID AND `Year` = @Year";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNote(string note, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_user_course` SET `Note` = @Note";
			var parameter_ = Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutNote
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Demo_user_courseEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.UserID, item.CourseID, item.Year) == null)
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
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Demo_user_courseEO GetByPK(long userID, string courseID, int year, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID AND `CourseID` = @CourseID AND `Year` = @Year", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Demo_user_courseEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
		#region GetByFK
	
		/// <summary>
		/// 按【外键】查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		public List<Demo_user_courseEO> GetByYearAndCourseID(int year, string courseID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`Year` = @Year AND `CourseID` = @CourseID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
			};
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_user_courseEO.MapDataReader);
		}
		#endregion // GetByFK
	
		#region GetByXXX
	
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByUserID(long userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByUserID(long userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByUserID(long userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByUserID(long userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByUserID(long userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByUserID(long userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码（自增字段）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByUserID(long userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_user_courseEO.MapDataReader);
		}
		#endregion // GetByUserID
	
		#region GetByYear
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByYear(int year)
		{
			return GetByYear(year, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByYear(int year, TransactionManager tm_)
		{
			return GetByYear(year, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByYear(int year, int top_)
		{
			return GetByYear(year, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByYear(int year, int top_, TransactionManager tm_)
		{
			return GetByYear(year, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByYear(int year, string sort_)
		{
			return GetByYear(year, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByYear(int year, string sort_, TransactionManager tm_)
		{
			return GetByYear(year, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByYear(int year, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Year` = @Year", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Year", year, MySqlDbType.Year));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_user_courseEO.MapDataReader);
		}
		#endregion // GetByYear
	
		#region GetByCourseID
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByCourseID(string courseID)
		{
			return GetByCourseID(courseID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByCourseID(string courseID, TransactionManager tm_)
		{
			return GetByCourseID(courseID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByCourseID(string courseID, int top_)
		{
			return GetByCourseID(courseID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByCourseID(string courseID, int top_, TransactionManager tm_)
		{
			return GetByCourseID(courseID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByCourseID(string courseID, string sort_)
		{
			return GetByCourseID(courseID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByCourseID(string courseID, string sort_, TransactionManager tm_)
		{
			return GetByCourseID(courseID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByCourseID(string courseID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CourseID` = @CourseID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_user_courseEO.MapDataReader);
		}
		#endregion // GetByCourseID
	
		#region GetByNote
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByNote(string note)
		{
			return GetByNote(note, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByNote(string note, TransactionManager tm_)
		{
			return GetByNote(note, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByNote(string note, int top_)
		{
			return GetByNote(note, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByNote(string note, int top_, TransactionManager tm_)
		{
			return GetByNote(note, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByNote(string note, string sort_)
		{
			return GetByNote(note, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByNote(string note, string sort_, TransactionManager tm_)
		{
			return GetByNote(note, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">说明</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_user_courseEO> GetByNote(string note, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(note != null ? "`Note` = @Note" : "`Note` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_user_courseEO.MapDataReader);
		}
		#endregion // GetByNote
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
