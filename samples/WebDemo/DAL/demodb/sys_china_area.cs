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
	/// 中国省市4级数据
	/// 【表 sys_china_area 的实体类】
	/// </summary>
	[Serializable]
	public class Sys_china_areaEO : IRowMapper<Sys_china_areaEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sys_china_areaEO()
		{
			this.Status = 0;
		}
	
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		protected int _originalAreaID;
		/// <summary>
		/// 【数据库中的原始主键 AreaID 值的副本，用于主键值更新】
		/// </summary>
		public int OriginalAreaID
		{
			get { return _originalAreaID; }
			set { HasOriginal = true; _originalAreaID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "AreaID", AreaID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
	
		#region 所有字段
		/// <summary>
		/// 行政区划码
		/// 【主键 int(11)】
		/// </summary>
		public int AreaID { get; set; }
		/// <summary>
		/// 省市名称，如北京市
		/// 【字段 varchar(20)】
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 父级编码
		///              0- 根
		///              100000 -中国
		/// 【字段 int(11)】
		/// </summary>
		public int ParentId { get; set; }
		/// <summary>
		/// 名称简写，如北京
		/// 【字段 varchar(20)】
		/// </summary>
		public string ShortName { get; set; }
		/// <summary>
		/// 级别
		///              0-根
		///              1-省，自治区，直辖市，特别行政区
		///              2-市，地区，自治州，盟，直辖市所属市辖区和县
		///              3-县，市辖区，县级市，旗
		///              4-乡镇（街道办事处）
		/// 【字段 int(11)】
		/// </summary>
		public int Level { get; set; }
		/// <summary>
		/// 城市代码（电话区号）
		/// 【字段 varchar(10)】
		/// </summary>
		public string CityCode { get; set; }
		/// <summary>
		/// 邮政编码
		/// 【字段 varchar(10)】
		/// </summary>
		public string ZipCode { get; set; }
		/// <summary>
		/// 长名称，如中国，北京，北京市
		/// 【字段 varchar(50)】
		/// </summary>
		public string MergerName { get; set; }
		/// <summary>
		/// 经度
		/// 【字段 double(10,5)】
		/// </summary>
		public double Lng { get; set; }
		/// <summary>
		/// 纬度
		/// 【字段 double(10,5)】
		/// </summary>
		public double Lat { get; set; }
		/// <summary>
		/// 拼音
		/// 【字段 varchar(20)】
		/// </summary>
		public string PinYin { get; set; }
		/// <summary>
		/// 简拼
		/// 【字段 varchar(20)】
		/// </summary>
		public string JianPin { get; set; }
		/// <summary>
		/// 别名，如川
		/// 【字段 varchar(6)】
		/// </summary>
		public string Alias { get; set; }
		/// <summary>
		/// 其他别名，如蜀
		/// 【字段 varchar(10)】
		/// </summary>
		public string OtherAlias { get; set; }
		/// <summary>
		/// 有效状态
		///              0-有效
		///              1-无效
		///              2-变更
		///              3-删除
		/// 【字段 int(11)】
		/// </summary>
		public int Status { get; set; }
		#endregion // 所有列
	
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sys_china_areaEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sys_china_areaEO MapDataReader(IDataReader reader)
		{
		    Sys_china_areaEO ret = new Sys_china_areaEO();
			ret.AreaID = reader.ToInt32("AreaID");
			ret.OriginalAreaID = ret.AreaID;
			ret.Name = reader.ToString("Name");
			ret.ParentId = reader.ToInt32("ParentId");
			ret.ShortName = reader.ToString("ShortName");
			ret.Level = reader.ToInt32("Level");
			ret.CityCode = reader.ToString("CityCode");
			ret.ZipCode = reader.ToString("ZipCode");
			ret.MergerName = reader.ToString("MergerName");
			ret.Lng = reader.ToDouble("Lng");
			ret.Lat = reader.ToDouble("Lat");
			ret.PinYin = reader.ToString("PinYin");
			ret.JianPin = reader.ToString("JianPin");
			ret.Alias = reader.ToString("Alias");
			ret.OtherAlias = reader.ToString("OtherAlias");
			ret.Status = reader.ToInt32("Status");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO
	
	#region MO
	/// <summary>
	/// 中国省市4级数据
	/// 【表 sys_china_area 的操作类】
	/// </summary>
	public class Sys_china_areaMO : MySqlTableMO<Sys_china_areaEO>
	{
	    public override string TableName => "`sys_china_area`"; 
	
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sys_china_areaMO(MySqlDatabase database) : base(database) { }
	
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sys_china_areaMO(string connectionStringName = null) : base(connectionStringName) { }
	
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sys_china_areaMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public override int Add(Sys_china_areaEO item, TransactionManager tm = null)
		{
			const string sql = @"INSERT INTO `sys_china_area` (`AreaID`, `Name`, `ParentId`, `ShortName`, `Level`, `CityCode`, `ZipCode`, `MergerName`, `Lng`, `Lat`, `PinYin`, `JianPin`, `Alias`, `OtherAlias`, `Status`) VALUE (@AreaID, @Name, @ParentId, @ShortName, @Level, @CityCode, @ZipCode, @MergerName, @Lng, @Lat, @PinYin, @JianPin, @Alias, @OtherAlias, @Status);";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AreaID", item.AreaID, MySqlDbType.Int32),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ParentId", item.ParentId, MySqlDbType.Int32),
				Database.CreateInParameter("@ShortName", item.ShortName != null ? item.ShortName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Level", item.Level, MySqlDbType.Int32),
				Database.CreateInParameter("@CityCode", item.CityCode != null ? item.CityCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ZipCode", item.ZipCode != null ? item.ZipCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MergerName", item.MergerName != null ? item.MergerName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Lng", item.Lng, MySqlDbType.Double),
				Database.CreateInParameter("@Lat", item.Lat, MySqlDbType.Double),
				Database.CreateInParameter("@PinYin", item.PinYin != null ? item.PinYin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@JianPin", item.JianPin != null ? item.JianPin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Alias", item.Alias != null ? item.Alias : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OtherAlias", item.OtherAlias != null ? item.OtherAlias : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
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
		/// /// <param name = "areaID">行政区划码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(int areaID, TransactionManager tm_ = null)
		{
			const string sql_ = @"DELETE FROM `sys_china_area` WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sys_china_areaEO item, TransactionManager tm = null)
		{
			return RemoveByPK(item.AreaID, tm);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
	
		#region RemoveByName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByName(string name, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (name != null ? "`Name` = @Name" : "`Name` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByName
	
		#region RemoveByParentId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByParentId(int parentId, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE `ParentId` = @ParentId";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ParentId", parentId, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByParentId
	
		#region RemoveByShortName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByShortName(string shortName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (shortName != null ? "`ShortName` = @ShortName" : "`ShortName` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (shortName != null)
				paras_.Add(Database.CreateInParameter("@ShortName", shortName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByShortName
	
		#region RemoveByLevel
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByLevel(int level, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE `Level` = @Level";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Level", level, MySqlDbType.Int32));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByLevel
	
		#region RemoveByCityCode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCityCode(string cityCode, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (cityCode != null ? "`CityCode` = @CityCode" : "`CityCode` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (cityCode != null)
				paras_.Add(Database.CreateInParameter("@CityCode", cityCode, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByCityCode
	
		#region RemoveByZipCode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByZipCode(string zipCode, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (zipCode != null ? "`ZipCode` = @ZipCode" : "`ZipCode` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (zipCode != null)
				paras_.Add(Database.CreateInParameter("@ZipCode", zipCode, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByZipCode
	
		#region RemoveByMergerName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByMergerName(string mergerName, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (mergerName != null ? "`MergerName` = @MergerName" : "`MergerName` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (mergerName != null)
				paras_.Add(Database.CreateInParameter("@MergerName", mergerName, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByMergerName
	
		#region RemoveByLng
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByLng(double lng, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE `Lng` = @Lng";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Lng", lng, MySqlDbType.Double));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByLng
	
		#region RemoveByLat
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByLat(double lat, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE `Lat` = @Lat";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Lat", lat, MySqlDbType.Double));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByLat
	
		#region RemoveByPinYin
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPinYin(string pinYin, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (pinYin != null ? "`PinYin` = @PinYin" : "`PinYin` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (pinYin != null)
				paras_.Add(Database.CreateInParameter("@PinYin", pinYin, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByPinYin
	
		#region RemoveByJianPin
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByJianPin(string jianPin, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (jianPin != null ? "`JianPin` = @JianPin" : "`JianPin` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (jianPin != null)
				paras_.Add(Database.CreateInParameter("@JianPin", jianPin, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByJianPin
	
		#region RemoveByAlias
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAlias(string alias, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (alias != null ? "`Alias` = @Alias" : "`Alias` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (alias != null)
				paras_.Add(Database.CreateInParameter("@Alias", alias, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByAlias
	
		#region RemoveByOtherAlias
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOtherAlias(string otherAlias, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE " + (otherAlias != null ? "`OtherAlias` = @OtherAlias" : "`OtherAlias` IS NULL");
			var paras_ = new List<MySqlParameter>();
			if (otherAlias != null)
				paras_.Add(Database.CreateInParameter("@OtherAlias", otherAlias, MySqlDbType.VarChar));
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		#endregion // RemoveByOtherAlias
	
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = @"DELETE FROM `sys_china_area` WHERE `Status` = @Status";
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
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
		public int Put(Sys_china_areaEO item, TransactionManager tm = null)
		{
			const string sql = @"UPDATE `sys_china_area` SET `AreaID` = @AreaID, `Name` = @Name, `ParentId` = @ParentId, `ShortName` = @ShortName, `Level` = @Level, `CityCode` = @CityCode, `ZipCode` = @ZipCode, `MergerName` = @MergerName, `Lng` = @Lng, `Lat` = @Lat, `PinYin` = @PinYin, `JianPin` = @JianPin, `Alias` = @Alias, `OtherAlias` = @OtherAlias, `Status` = @Status WHERE `AreaID` = @AreaID_Original";
			var paras = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AreaID", item.AreaID, MySqlDbType.Int32),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ParentId", item.ParentId, MySqlDbType.Int32),
				Database.CreateInParameter("@ShortName", item.ShortName != null ? item.ShortName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Level", item.Level, MySqlDbType.Int32),
				Database.CreateInParameter("@CityCode", item.CityCode != null ? item.CityCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@ZipCode", item.ZipCode != null ? item.ZipCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@MergerName", item.MergerName != null ? item.MergerName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Lng", item.Lng, MySqlDbType.Double),
				Database.CreateInParameter("@Lat", item.Lat, MySqlDbType.Double),
				Database.CreateInParameter("@PinYin", item.PinYin != null ? item.PinYin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@JianPin", item.JianPin != null ? item.JianPin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Alias", item.Alias != null ? item.Alias : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OtherAlias", item.OtherAlias != null ? item.OtherAlias : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@AreaID_Original", item.HasOriginal ? item.OriginalAreaID : item.AreaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql, paras, tm);
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sys_china_areaEO> items, TransactionManager tm = null)
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
		/// /// <param name = "areaID">行政区划码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int areaID, string set_, params object[] values_)
		{
			return Put(set_, "`AreaID` = @AreaID", ConcatValues(values_, areaID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int areaID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`AreaID` = @AreaID", tm_, ConcatValues(values_, areaID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int areaID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
	        };
			return Put(set_, "`AreaID` = @AreaID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
	
		#region PutName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNameByPK(int areaID, string name, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Name` = @Name  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutName(string name, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Name` = @Name";
			var parameter_ = Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutName
	
		#region PutParentId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutParentIdByPK(int areaID, int parentId, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `ParentId` = @ParentId  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ParentId", parentId, MySqlDbType.Int32),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutParentId(int parentId, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `ParentId` = @ParentId";
			var parameter_ = Database.CreateInParameter("@ParentId", parentId, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutParentId
	
		#region PutShortName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutShortNameByPK(int areaID, string shortName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `ShortName` = @ShortName  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ShortName", shortName != null ? shortName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutShortName(string shortName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `ShortName` = @ShortName";
			var parameter_ = Database.CreateInParameter("@ShortName", shortName != null ? shortName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutShortName
	
		#region PutLevel
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "level">级别</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLevelByPK(int areaID, int level, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Level` = @Level  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Level", level, MySqlDbType.Int32),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLevel(int level, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Level` = @Level";
			var parameter_ = Database.CreateInParameter("@Level", level, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutLevel
	
		#region PutCityCode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCityCodeByPK(int areaID, string cityCode, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `CityCode` = @CityCode  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CityCode", cityCode != null ? cityCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCityCode(string cityCode, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `CityCode` = @CityCode";
			var parameter_ = Database.CreateInParameter("@CityCode", cityCode != null ? cityCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCityCode
	
		#region PutZipCode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutZipCodeByPK(int areaID, string zipCode, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `ZipCode` = @ZipCode  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ZipCode", zipCode != null ? zipCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutZipCode(string zipCode, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `ZipCode` = @ZipCode";
			var parameter_ = Database.CreateInParameter("@ZipCode", zipCode != null ? zipCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutZipCode
	
		#region PutMergerName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMergerNameByPK(int areaID, string mergerName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `MergerName` = @MergerName  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@MergerName", mergerName != null ? mergerName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMergerName(string mergerName, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `MergerName` = @MergerName";
			var parameter_ = Database.CreateInParameter("@MergerName", mergerName != null ? mergerName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutMergerName
	
		#region PutLng
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "lng">经度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLngByPK(int areaID, double lng, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Lng` = @Lng  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Lng", lng, MySqlDbType.Double),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLng(double lng, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Lng` = @Lng";
			var parameter_ = Database.CreateInParameter("@Lng", lng, MySqlDbType.Double);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutLng
	
		#region PutLat
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "lat">纬度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLatByPK(int areaID, double lat, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Lat` = @Lat  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Lat", lat, MySqlDbType.Double),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutLat(double lat, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Lat` = @Lat";
			var parameter_ = Database.CreateInParameter("@Lat", lat, MySqlDbType.Double);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutLat
	
		#region PutPinYin
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPinYinByPK(int areaID, string pinYin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `PinYin` = @PinYin  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PinYin", pinYin != null ? pinYin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPinYin(string pinYin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `PinYin` = @PinYin";
			var parameter_ = Database.CreateInParameter("@PinYin", pinYin != null ? pinYin : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPinYin
	
		#region PutJianPin
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutJianPinByPK(int areaID, string jianPin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `JianPin` = @JianPin  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@JianPin", jianPin != null ? jianPin : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutJianPin(string jianPin, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `JianPin` = @JianPin";
			var parameter_ = Database.CreateInParameter("@JianPin", jianPin != null ? jianPin : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutJianPin
	
		#region PutAlias
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAliasByPK(int areaID, string alias, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Alias` = @Alias  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Alias", alias != null ? alias : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAlias(string alias, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Alias` = @Alias";
			var parameter_ = Database.CreateInParameter("@Alias", alias != null ? alias : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAlias
	
		#region PutOtherAlias
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOtherAliasByPK(int areaID, string otherAlias, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `OtherAlias` = @OtherAlias  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OtherAlias", otherAlias != null ? otherAlias : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOtherAlias(string otherAlias, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `OtherAlias` = @OtherAlias";
			var parameter_ = Database.CreateInParameter("@OtherAlias", otherAlias != null ? otherAlias : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOtherAlias
	
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "areaID">行政区划码</param>
		/// /// <param name = "status">有效状态</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(int areaID, int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Status` = @Status  WHERE `AreaID` = @AreaID";
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Int32),
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatus(int status, TransactionManager tm_ = null)
		{
			const string sql_ = @"UPDATE `sys_china_area` SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Int32);
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
		public bool Set(Sys_china_areaEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.AreaID) == null)
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
		/// /// <param name = "areaID">行政区划码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public Sys_china_areaEO GetByPK(int areaID, TransactionManager tm_ = null)
		{
			var sql_ = BuildSelectSQL("`AreaID` = @AreaID", 0, null);
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AreaID", areaID, MySqlDbType.Int32),
			};
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByPK
		
	
	
		#region GetByXXX
	
		#region GetByName
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByName(string name)
		{
			return GetByName(name, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByName(string name, TransactionManager tm_)
		{
			return GetByName(name, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByName(string name, int top_)
		{
			return GetByName(name, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByName(string name, int top_, TransactionManager tm_)
		{
			return GetByName(name, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByName(string name, string sort_)
		{
			return GetByName(name, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByName(string name, string sort_, TransactionManager tm_)
		{
			return GetByName(name, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">省市名称，如北京市</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByName(string name, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(name != null ? "`Name` = @Name" : "`Name` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByName
	
		#region GetByParentId
		
		/// <summary>
		/// 按 ParentId（字段） 查询
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByParentId(int parentId)
		{
			return GetByParentId(parentId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ParentId（字段） 查询
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByParentId(int parentId, TransactionManager tm_)
		{
			return GetByParentId(parentId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ParentId（字段） 查询
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByParentId(int parentId, int top_)
		{
			return GetByParentId(parentId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ParentId（字段） 查询
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByParentId(int parentId, int top_, TransactionManager tm_)
		{
			return GetByParentId(parentId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ParentId（字段） 查询
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByParentId(int parentId, string sort_)
		{
			return GetByParentId(parentId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ParentId（字段） 查询
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByParentId(int parentId, string sort_, TransactionManager tm_)
		{
			return GetByParentId(parentId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ParentId（字段） 查询
		/// </summary>
		/// /// <param name = "parentId">父级编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByParentId(int parentId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ParentId` = @ParentId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ParentId", parentId, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByParentId
	
		#region GetByShortName
		
		/// <summary>
		/// 按 ShortName（字段） 查询
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByShortName(string shortName)
		{
			return GetByShortName(shortName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ShortName（字段） 查询
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByShortName(string shortName, TransactionManager tm_)
		{
			return GetByShortName(shortName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ShortName（字段） 查询
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByShortName(string shortName, int top_)
		{
			return GetByShortName(shortName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ShortName（字段） 查询
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByShortName(string shortName, int top_, TransactionManager tm_)
		{
			return GetByShortName(shortName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ShortName（字段） 查询
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByShortName(string shortName, string sort_)
		{
			return GetByShortName(shortName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ShortName（字段） 查询
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByShortName(string shortName, string sort_, TransactionManager tm_)
		{
			return GetByShortName(shortName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ShortName（字段） 查询
		/// </summary>
		/// /// <param name = "shortName">名称简写，如北京</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByShortName(string shortName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(shortName != null ? "`ShortName` = @ShortName" : "`ShortName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (shortName != null)
				paras_.Add(Database.CreateInParameter("@ShortName", shortName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByShortName
	
		#region GetByLevel
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLevel(int level)
		{
			return GetByLevel(level, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLevel(int level, TransactionManager tm_)
		{
			return GetByLevel(level, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLevel(int level, int top_)
		{
			return GetByLevel(level, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLevel(int level, int top_, TransactionManager tm_)
		{
			return GetByLevel(level, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLevel(int level, string sort_)
		{
			return GetByLevel(level, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLevel(int level, string sort_, TransactionManager tm_)
		{
			return GetByLevel(level, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Level（字段） 查询
		/// </summary>
		/// /// <param name = "level">级别</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLevel(int level, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Level` = @Level", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Level", level, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByLevel
	
		#region GetByCityCode
		
		/// <summary>
		/// 按 CityCode（字段） 查询
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByCityCode(string cityCode)
		{
			return GetByCityCode(cityCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CityCode（字段） 查询
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByCityCode(string cityCode, TransactionManager tm_)
		{
			return GetByCityCode(cityCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CityCode（字段） 查询
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByCityCode(string cityCode, int top_)
		{
			return GetByCityCode(cityCode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CityCode（字段） 查询
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByCityCode(string cityCode, int top_, TransactionManager tm_)
		{
			return GetByCityCode(cityCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CityCode（字段） 查询
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByCityCode(string cityCode, string sort_)
		{
			return GetByCityCode(cityCode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CityCode（字段） 查询
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByCityCode(string cityCode, string sort_, TransactionManager tm_)
		{
			return GetByCityCode(cityCode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CityCode（字段） 查询
		/// </summary>
		/// /// <param name = "cityCode">城市代码（电话区号）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByCityCode(string cityCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(cityCode != null ? "`CityCode` = @CityCode" : "`CityCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (cityCode != null)
				paras_.Add(Database.CreateInParameter("@CityCode", cityCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByCityCode
	
		#region GetByZipCode
		
		/// <summary>
		/// 按 ZipCode（字段） 查询
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByZipCode(string zipCode)
		{
			return GetByZipCode(zipCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ZipCode（字段） 查询
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByZipCode(string zipCode, TransactionManager tm_)
		{
			return GetByZipCode(zipCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ZipCode（字段） 查询
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByZipCode(string zipCode, int top_)
		{
			return GetByZipCode(zipCode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ZipCode（字段） 查询
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByZipCode(string zipCode, int top_, TransactionManager tm_)
		{
			return GetByZipCode(zipCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ZipCode（字段） 查询
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByZipCode(string zipCode, string sort_)
		{
			return GetByZipCode(zipCode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ZipCode（字段） 查询
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByZipCode(string zipCode, string sort_, TransactionManager tm_)
		{
			return GetByZipCode(zipCode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ZipCode（字段） 查询
		/// </summary>
		/// /// <param name = "zipCode">邮政编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByZipCode(string zipCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(zipCode != null ? "`ZipCode` = @ZipCode" : "`ZipCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (zipCode != null)
				paras_.Add(Database.CreateInParameter("@ZipCode", zipCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByZipCode
	
		#region GetByMergerName
		
		/// <summary>
		/// 按 MergerName（字段） 查询
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByMergerName(string mergerName)
		{
			return GetByMergerName(mergerName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MergerName（字段） 查询
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByMergerName(string mergerName, TransactionManager tm_)
		{
			return GetByMergerName(mergerName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MergerName（字段） 查询
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByMergerName(string mergerName, int top_)
		{
			return GetByMergerName(mergerName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 MergerName（字段） 查询
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByMergerName(string mergerName, int top_, TransactionManager tm_)
		{
			return GetByMergerName(mergerName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 MergerName（字段） 查询
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByMergerName(string mergerName, string sort_)
		{
			return GetByMergerName(mergerName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 MergerName（字段） 查询
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByMergerName(string mergerName, string sort_, TransactionManager tm_)
		{
			return GetByMergerName(mergerName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 MergerName（字段） 查询
		/// </summary>
		/// /// <param name = "mergerName">长名称，如中国，北京，北京市</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByMergerName(string mergerName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(mergerName != null ? "`MergerName` = @MergerName" : "`MergerName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (mergerName != null)
				paras_.Add(Database.CreateInParameter("@MergerName", mergerName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByMergerName
	
		#region GetByLng
		
		/// <summary>
		/// 按 Lng（字段） 查询
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLng(double lng)
		{
			return GetByLng(lng, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Lng（字段） 查询
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLng(double lng, TransactionManager tm_)
		{
			return GetByLng(lng, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Lng（字段） 查询
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLng(double lng, int top_)
		{
			return GetByLng(lng, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Lng（字段） 查询
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLng(double lng, int top_, TransactionManager tm_)
		{
			return GetByLng(lng, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Lng（字段） 查询
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLng(double lng, string sort_)
		{
			return GetByLng(lng, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Lng（字段） 查询
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLng(double lng, string sort_, TransactionManager tm_)
		{
			return GetByLng(lng, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Lng（字段） 查询
		/// </summary>
		/// /// <param name = "lng">经度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLng(double lng, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Lng` = @Lng", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Lng", lng, MySqlDbType.Double));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByLng
	
		#region GetByLat
		
		/// <summary>
		/// 按 Lat（字段） 查询
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLat(double lat)
		{
			return GetByLat(lat, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Lat（字段） 查询
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLat(double lat, TransactionManager tm_)
		{
			return GetByLat(lat, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Lat（字段） 查询
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLat(double lat, int top_)
		{
			return GetByLat(lat, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Lat（字段） 查询
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLat(double lat, int top_, TransactionManager tm_)
		{
			return GetByLat(lat, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Lat（字段） 查询
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLat(double lat, string sort_)
		{
			return GetByLat(lat, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Lat（字段） 查询
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLat(double lat, string sort_, TransactionManager tm_)
		{
			return GetByLat(lat, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Lat（字段） 查询
		/// </summary>
		/// /// <param name = "lat">纬度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByLat(double lat, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Lat` = @Lat", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Lat", lat, MySqlDbType.Double));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByLat
	
		#region GetByPinYin
		
		/// <summary>
		/// 按 PinYin（字段） 查询
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByPinYin(string pinYin)
		{
			return GetByPinYin(pinYin, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PinYin（字段） 查询
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByPinYin(string pinYin, TransactionManager tm_)
		{
			return GetByPinYin(pinYin, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PinYin（字段） 查询
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByPinYin(string pinYin, int top_)
		{
			return GetByPinYin(pinYin, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PinYin（字段） 查询
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByPinYin(string pinYin, int top_, TransactionManager tm_)
		{
			return GetByPinYin(pinYin, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PinYin（字段） 查询
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByPinYin(string pinYin, string sort_)
		{
			return GetByPinYin(pinYin, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PinYin（字段） 查询
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByPinYin(string pinYin, string sort_, TransactionManager tm_)
		{
			return GetByPinYin(pinYin, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PinYin（字段） 查询
		/// </summary>
		/// /// <param name = "pinYin">拼音</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByPinYin(string pinYin, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(pinYin != null ? "`PinYin` = @PinYin" : "`PinYin` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (pinYin != null)
				paras_.Add(Database.CreateInParameter("@PinYin", pinYin, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByPinYin
	
		#region GetByJianPin
		
		/// <summary>
		/// 按 JianPin（字段） 查询
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByJianPin(string jianPin)
		{
			return GetByJianPin(jianPin, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 JianPin（字段） 查询
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByJianPin(string jianPin, TransactionManager tm_)
		{
			return GetByJianPin(jianPin, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 JianPin（字段） 查询
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByJianPin(string jianPin, int top_)
		{
			return GetByJianPin(jianPin, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 JianPin（字段） 查询
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByJianPin(string jianPin, int top_, TransactionManager tm_)
		{
			return GetByJianPin(jianPin, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 JianPin（字段） 查询
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByJianPin(string jianPin, string sort_)
		{
			return GetByJianPin(jianPin, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 JianPin（字段） 查询
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByJianPin(string jianPin, string sort_, TransactionManager tm_)
		{
			return GetByJianPin(jianPin, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 JianPin（字段） 查询
		/// </summary>
		/// /// <param name = "jianPin">简拼</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByJianPin(string jianPin, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(jianPin != null ? "`JianPin` = @JianPin" : "`JianPin` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (jianPin != null)
				paras_.Add(Database.CreateInParameter("@JianPin", jianPin, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByJianPin
	
		#region GetByAlias
		
		/// <summary>
		/// 按 Alias（字段） 查询
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByAlias(string alias)
		{
			return GetByAlias(alias, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Alias（字段） 查询
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByAlias(string alias, TransactionManager tm_)
		{
			return GetByAlias(alias, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Alias（字段） 查询
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByAlias(string alias, int top_)
		{
			return GetByAlias(alias, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Alias（字段） 查询
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByAlias(string alias, int top_, TransactionManager tm_)
		{
			return GetByAlias(alias, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Alias（字段） 查询
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByAlias(string alias, string sort_)
		{
			return GetByAlias(alias, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Alias（字段） 查询
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByAlias(string alias, string sort_, TransactionManager tm_)
		{
			return GetByAlias(alias, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Alias（字段） 查询
		/// </summary>
		/// /// <param name = "alias">别名，如川</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByAlias(string alias, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(alias != null ? "`Alias` = @Alias" : "`Alias` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (alias != null)
				paras_.Add(Database.CreateInParameter("@Alias", alias, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByAlias
	
		#region GetByOtherAlias
		
		/// <summary>
		/// 按 OtherAlias（字段） 查询
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByOtherAlias(string otherAlias)
		{
			return GetByOtherAlias(otherAlias, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OtherAlias（字段） 查询
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByOtherAlias(string otherAlias, TransactionManager tm_)
		{
			return GetByOtherAlias(otherAlias, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OtherAlias（字段） 查询
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByOtherAlias(string otherAlias, int top_)
		{
			return GetByOtherAlias(otherAlias, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OtherAlias（字段） 查询
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByOtherAlias(string otherAlias, int top_, TransactionManager tm_)
		{
			return GetByOtherAlias(otherAlias, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OtherAlias（字段） 查询
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByOtherAlias(string otherAlias, string sort_)
		{
			return GetByOtherAlias(otherAlias, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OtherAlias（字段） 查询
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByOtherAlias(string otherAlias, string sort_, TransactionManager tm_)
		{
			return GetByOtherAlias(otherAlias, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OtherAlias（字段） 查询
		/// </summary>
		/// /// <param name = "otherAlias">其他别名，如蜀</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByOtherAlias(string otherAlias, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(otherAlias != null ? "`OtherAlias` = @OtherAlias" : "`OtherAlias` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (otherAlias != null)
				paras_.Add(Database.CreateInParameter("@OtherAlias", otherAlias, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByOtherAlias
	
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">有效状态</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sys_china_areaEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sys_china_areaEO.MapDataReader);
		}
		#endregion // GetByStatus
	
		#endregion // GetByXXX
	
		#endregion // Get
	}
	#endregion // MO
}
