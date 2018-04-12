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
	/// 类别
	/// 这里有很多说明
	/// 【表 demo_class 的实体类】
	/// </summary>
	[Serializable]
	public class Demo_classEO : IRowMapper<Demo_classEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Demo_classEO()
		{
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected string _originalClassID;
		/// <summary>
		/// 【数据库中的原始主键 ClassID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalClassID
		{
			get { return _originalClassID; }
			set { HasOriginal = true; _originalClassID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "ClassID", ClassID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 类别编码
		/// 【主键 varchar(10)】
		/// </summary>
		public string ClassID { get; set; }
		/// <summary>
		/// 类别
		/// 【字段 varchar(10)】
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 
		/// 【字段 int(11)】
		/// </summary>
		public int Sort1 { get; set; }
		/// <summary>
		/// 
		/// 【字段 int(11)】
		/// </summary>
		public int Sort2 { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Demo_classEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Demo_classEO MapDataReader(IDataReader reader)
		{
		    Demo_classEO ret = new Demo_classEO();
			ret.ClassID = reader.ToString("ClassID");
			ret.OriginalClassID = ret.ClassID;
			ret.Name = reader.ToString("Name");
			ret.Sort1 = reader.ToInt32("Sort1");
			ret.Sort2 = reader.ToInt32("Sort2");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 类别
	/// 这里有很多说明
	/// 【表 demo_class 的操作类】
	/// </summary>
	public class Demo_classMO : MySqlTableMO<Demo_classEO>
	{
	    public override string TableName => "`demo_class`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Demo_classMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Demo_classMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Demo_classMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Demo_classEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `demo_class` (`ClassID`, `Name`, `Sort1`, `Sort2`) VALUE (@ClassID, @Name, @Sort1, @Sort2);";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ClassID", item.ClassID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Sort1", item.Sort1, MySqlDbType.Int32),
				Database.CreateInParameter("@Sort2", item.Sort2, MySqlDbType.Int32),
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
		/// /// <param name = "classID">类别编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string classID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `demo_class` WHERE `ClassID` = @ClassID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Demo_classEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.ClassID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByName(string name, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_class` WHERE " + (name != null ? "`Name` = @Name" : "`Name` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByName
	
		#region RemoveBySort1
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySort1(int sort1, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_class` WHERE `Sort1` = @Sort1";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Sort1", sort1, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveBySort1
	
		#region RemoveBySort2
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySort2(int sort2, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `demo_class` WHERE `Sort2` = @Sort2";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Sort2", sort2, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveBySort2
	
		#endregion // RemoveByXXX
	
		#region RemoveByFKOrUnique
	
		#region RemoveBySort1AndSort2
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// /// <param name = "sort2"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySort1AndSort2(int sort1, int sort2, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `demo_class` WHERE `Sort1` = @Sort1 AND `Sort2` = @Sort2";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Sort1", sort1, MySqlDbType.Int32),
				Database.CreateInParameter("@Sort2", sort2, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveBySort1AndSort2
	
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
		public int Put(Demo_classEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `demo_class` SET `ClassID` = @ClassID, `Name` = @Name, `Sort1` = @Sort1, `Sort2` = @Sort2 WHERE `ClassID` = @ClassID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ClassID", item.ClassID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Sort1", item.Sort1, MySqlDbType.Int32),
				Database.CreateInParameter("@Sort2", item.Sort2, MySqlDbType.Int32),
				Database.CreateInParameter("@ClassID_Original", item.HasOriginal ? item.OriginalClassID : item.ClassID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Demo_classEO> items, TransactionManager tm = null)
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
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string classID, string set_, params object[] values_)
		{
			return Put(set_, "`ClassID` = @ClassID", ConcatValues(values_, classID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string classID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`ClassID` = @ClassID", tm_, ConcatValues(values_, classID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string classID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`ClassID` = @ClassID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// /// <param name = "name">类别</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNameByPK(string classID, string name, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_class` SET `Name` = @Name  WHERE `ClassID` = @ClassID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutName(string name, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_class` SET `Name` = @Name";
			var parameter_ = Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutName
	
		#region PutSort1
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// /// <param name = "sort1"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSort1ByPK(string classID, int sort1, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_class` SET `Sort1` = @Sort1  WHERE `ClassID` = @ClassID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Sort1", sort1, MySqlDbType.Int32),
				Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSort1(int sort1, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_class` SET `Sort1` = @Sort1";
			var parameter_ = Database.CreateInParameter("@Sort1", sort1, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSort1
	
		#region PutSort2
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "classID">类别编码</param>
		/// /// <param name = "sort2"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSort2ByPK(string classID, int sort2, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_class` SET `Sort2` = @Sort2  WHERE `ClassID` = @ClassID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Sort2", sort2, MySqlDbType.Int32),
				Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSort2(int sort2, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `demo_class` SET `Sort2` = @Sort2";
			var parameter_ = Database.CreateInParameter("@Sort2", sort2, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSort2
	
		#endregion // PutXXX
		
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Demo_classEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.ClassID) == null)
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
		/// /// <param name = "classID">类别编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Demo_classEO GetByPK(string classID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`ClassID` = @ClassID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ClassID", classID, MySqlDbType.VarChar),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Demo_classEO.MapDataReader);
		}
		#endregion // GetByPK
		
		#region GetByUnique
		/// <summary>
		/// 按【唯一索引】查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// /// <param name = "sort2"></param>
		/// <param name="tm_">事务管理对象</param>
		public Demo_classEO GetBySort1AndSort2(int sort1, int sort2, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`Sort1` = @Sort1 AND `Sort2` = @Sort2", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Sort1", sort1, MySqlDbType.Int32),
				Database.CreateInParameter("@Sort2", sort2, MySqlDbType.Int32),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Demo_classEO.MapDataReader);
		}
	
		#endregion // GetByUnique
	
	
		#region GetByXXX
	
		#region GetByName
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetByName(string name)
		{
			return GetByName(name, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetByName(string name, TransactionManager tm_)
		{
			return GetByName(name, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetByName(string name, int top_)
		{
			return GetByName(name, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetByName(string name, int top_, TransactionManager tm_)
		{
			return GetByName(name, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetByName(string name, string sort_)
		{
			return GetByName(name, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetByName(string name, string sort_, TransactionManager tm_)
		{
			return GetByName(name, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">类别</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetByName(string name, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(name != null ? "`Name` = @Name" : "`Name` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_classEO.MapDataReader);
		}
		#endregion // GetByName
	
		#region GetBySort1
		
		/// <summary>
		/// 按 Sort1（字段） 查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort1(int sort1)
		{
			return GetBySort1(sort1, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Sort1（字段） 查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort1(int sort1, TransactionManager tm_)
		{
			return GetBySort1(sort1, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Sort1（字段） 查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort1(int sort1, int top_)
		{
			return GetBySort1(sort1, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Sort1（字段） 查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort1(int sort1, int top_, TransactionManager tm_)
		{
			return GetBySort1(sort1, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Sort1（字段） 查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort1(int sort1, string sort_)
		{
			return GetBySort1(sort1, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Sort1（字段） 查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort1(int sort1, string sort_, TransactionManager tm_)
		{
			return GetBySort1(sort1, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Sort1（字段） 查询
		/// </summary>
		/// /// <param name = "sort1"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort1(int sort1, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Sort1` = @Sort1", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Sort1", sort1, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_classEO.MapDataReader);
		}
		#endregion // GetBySort1
	
		#region GetBySort2
		
		/// <summary>
		/// 按 Sort2（字段） 查询
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort2(int sort2)
		{
			return GetBySort2(sort2, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Sort2（字段） 查询
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort2(int sort2, TransactionManager tm_)
		{
			return GetBySort2(sort2, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Sort2（字段） 查询
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort2(int sort2, int top_)
		{
			return GetBySort2(sort2, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Sort2（字段） 查询
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort2(int sort2, int top_, TransactionManager tm_)
		{
			return GetBySort2(sort2, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Sort2（字段） 查询
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort2(int sort2, string sort_)
		{
			return GetBySort2(sort2, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Sort2（字段） 查询
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort2(int sort2, string sort_, TransactionManager tm_)
		{
			return GetBySort2(sort2, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Sort2（字段） 查询
		/// </summary>
		/// /// <param name = "sort2"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Demo_classEO> GetBySort2(int sort2, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Sort2` = @Sort2", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Sort2", sort2, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Demo_classEO.MapDataReader);
		}
		#endregion // GetBySort2
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
