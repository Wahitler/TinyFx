/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0 by JiangHui 2016-06-20
 * 文档生成时间：2018-04-11 11: 25:10
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
	/// 课程
	/// 【表 demo_course 的实体类】
	/// </summary>
	[Serializable]
	public class Demo_courseEO : IRowMapper<Demo_courseEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Demo_courseEO()
		{
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected int _originalYear;
		/// <summary>
		/// 【数据库中的原始主键 Year 值的副本，用于主键值更新】
		/// </summary>
		public int OriginalYear
		{
			get { return _originalYear; }
			set { HasOriginal = true; _originalYear = value; }
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
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "Year", Year },  { "CourseID", CourseID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
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
		/// 名称
		/// 【字段 varchar(10)】
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 
		/// 【字段 int(11)】
		/// </summary>
		public int OrderNum { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Demo_courseEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Demo_courseEO MapDataReader(IDataReader reader)
		{
		    Demo_courseEO ret = new Demo_courseEO();
			ret.Year = reader.ToInt32("Year");
			ret.OriginalYear = ret.Year;
			ret.CourseID = reader.ToString("CourseID");
			ret.OriginalCourseID = ret.CourseID;
			ret.Name = reader.ToString("Name");
			ret.OrderNum = reader.ToInt32("OrderNum");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 课程
	/// 【表 demo_course 的操作类】
	/// </summary>
	public class Demo_courseMO : MySqlTableMO<Demo_courseEO>
	{
	    public override string TableName => "`demo_course`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Demo_courseMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Demo_courseMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Demo_courseMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Demo_courseEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `demo_course` (`Year`, `CourseID`, `Name`, `OrderNum`) VALUE (@Year, @CourseID, @Name, @OrderNum);";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Year", item.Year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", item.CourseID, MySqlDbType.String),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
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
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(int year, string courseID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `demo_course` WHERE `Year` = @Year AND `CourseID` = @CourseID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Demo_courseEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.Year, item.CourseID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByYear
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByYear(int year, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_course` WHERE `Year` = @Year";
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
			string sql_ = @"DELETE FROM `demo_course` WHERE `CourseID` = @CourseID";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByCourseID
	
		#region RemoveByName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByName(string name, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_course` WHERE " + (name != null ? "`Name` = @Name" : "`Name` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByName
	
		#region RemoveByOrderNum
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderNum"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderNum(int orderNum, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_course` WHERE `OrderNum` = @OrderNum";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByOrderNum
	
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
		public int Put(Demo_courseEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `demo_course` SET `Year` = @Year, `CourseID` = @CourseID, `Name` = @Name, `OrderNum` = @OrderNum WHERE `Year` = @Year_Original AND `CourseID` = @CourseID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Year", item.Year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", item.CourseID, MySqlDbType.String),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
				Database.CreateInParameter("@Year_Original", item.HasOriginal ? item.OriginalYear : item.Year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID_Original", item.HasOriginal ? item.OriginalCourseID : item.CourseID, MySqlDbType.String),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Demo_courseEO> items, TransactionManager tm = null)
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
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int year, string courseID, string set_, params object[] values_)
		{
			return Put(set_, "`Year` = @Year AND `CourseID` = @CourseID", ConcatValues(values_, year, courseID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int year, string courseID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`Year` = @Year AND `CourseID` = @CourseID", tm_, ConcatValues(values_, year, courseID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int year, string courseID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
	        };
			return Put(set_, "`Year` = @Year AND `CourseID` = @CourseID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutYear
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutYear(int year, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_course` SET `Year` = @Year";
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
			const string sql_ = @"UPDATE `demo_course` SET `CourseID` = @CourseID";
			var parameter_ = Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCourseID
	
		#region PutName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "name">名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNameByPK(int year, string courseID, string name, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_course` SET `Name` = @Name  WHERE `Year` = @Year AND `CourseID` = @CourseID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutName(string name, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_course` SET `Name` = @Name";
			var parameter_ = Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutName
	
		#region PutOrderNum
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// /// <param name = "orderNum"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderNumByPK(int year, string courseID, int orderNum, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_course` SET `OrderNum` = @OrderNum  WHERE `Year` = @Year AND `CourseID` = @CourseID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32),
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderNum"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderNum(int orderNum, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_course` SET `OrderNum` = @OrderNum";
			var parameter_ = Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderNum
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Demo_courseEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.Year, item.CourseID) == null)
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
		/// /// <param name = "year">学年</param>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Demo_courseEO GetByPK(int year, string courseID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`Year` = @Year AND `CourseID` = @CourseID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Year", year, MySqlDbType.Year),
				Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Demo_courseEO.MapDataReader);
		}
		#endregion // GetByPK
		
		#region GetByUnique
		/// <summary>
		/// 按【唯一索引】查询
		/// </summary>
		/// /// <param name = "orderNum"></param>
		/// <param name="tm_">事务管理对象</param>
		public Demo_courseEO GetByOrderNum(int orderNum, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`OrderNum` = @OrderNum", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Demo_courseEO.MapDataReader);
		}
	
		#endregion // GetByUnique
	
	
		#region GetByXXX
	
		#region GetByYear
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByYear(int year)
		{
			return GetByYear(year, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByYear(int year, TransactionManager tm_)
		{
			return GetByYear(year, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByYear(int year, int top_)
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
		public List<Demo_courseEO> GetByYear(int year, int top_, TransactionManager tm_)
		{
			return GetByYear(year, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Year（字段） 查询
		/// </summary>
		/// /// <param name = "year">学年</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByYear(int year, string sort_)
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
		public List<Demo_courseEO> GetByYear(int year, string sort_, TransactionManager tm_)
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
		public List<Demo_courseEO> GetByYear(int year, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Year` = @Year", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Year", year, MySqlDbType.Year));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_courseEO.MapDataReader);
		}
		#endregion // GetByYear
	
		#region GetByCourseID
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByCourseID(string courseID)
		{
			return GetByCourseID(courseID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByCourseID(string courseID, TransactionManager tm_)
		{
			return GetByCourseID(courseID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByCourseID(string courseID, int top_)
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
		public List<Demo_courseEO> GetByCourseID(string courseID, int top_, TransactionManager tm_)
		{
			return GetByCourseID(courseID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CourseID（字段） 查询
		/// </summary>
		/// /// <param name = "courseID">课程编码（GUID）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByCourseID(string courseID, string sort_)
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
		public List<Demo_courseEO> GetByCourseID(string courseID, string sort_, TransactionManager tm_)
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
		public List<Demo_courseEO> GetByCourseID(string courseID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CourseID` = @CourseID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CourseID", courseID, MySqlDbType.String));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_courseEO.MapDataReader);
		}
		#endregion // GetByCourseID
	
		#region GetByName
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByName(string name)
		{
			return GetByName(name, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByName(string name, TransactionManager tm_)
		{
			return GetByName(name, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByName(string name, int top_)
		{
			return GetByName(name, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByName(string name, int top_, TransactionManager tm_)
		{
			return GetByName(name, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByName(string name, string sort_)
		{
			return GetByName(name, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByName(string name, string sort_, TransactionManager tm_)
		{
			return GetByName(name, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_courseEO> GetByName(string name, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(name != null ? "`Name` = @Name" : "`Name` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_courseEO.MapDataReader);
		}
		#endregion // GetByName
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
