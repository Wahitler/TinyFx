using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using TinyFx.Configuration;

namespace TinyFx.Data.SqlClient
{
//    internal class ProcPager : IDataPager
//    {
//        #region 分页存储过程
//        /*
         
//ALTER PROCEDURE [dbo].[Usp_CommonPager]
//    @sFrom nvarchar(4000),			--表名或From子句（注意：不要加From，子句只包含From后Where前的语句）
//    @sFields nvarchar(2000) = '',	--需要返回的列名
//    @sWhere nvarchar(2000) = '',	--Where子句（注意: 不要加 where）
//    @sGroupBy nvarchar(2000) = '',	--Group By子句（注意: 不要加 Group by）
//    @sHaving nvarchar(2000) = '',	--Having子句（注意: 不要加 Having）
//    @sOrderBy nvarchar(2000) = '',	--Order By子句（注意：不要加Order By）
//    @sKeyField nvarchar(200) = '',	--查询关键字段（注意：最好赋值，必须唯一最好聚集，只支持单一字段）
//    @iPageSize int,					--分页大小
//    @iPageIndex bigint = 1,				--当前分页页码
//    @iRecordCount bigint = 0 OUTPUT,	--当@iPageCount = -1 时查询记录并返回，=0时不查记录返回分页数据，>0时根据情况查记录返回分页数据
//    @sPagerSql nvarchar(4000) = '' OUTPUT -- 返回执行的分页SQL语句，用于查找错误
//AS SET NOCOUNT ON
//BEGIN TRY
//    DECLARE
//        @obj_id int,			--对象ID
//        @execState int,			--根据@iRecordCount获取的执行方式
//        @hasGroupBy bit,		--是否包含Group By子句
//        @pageSize nvarchar(30),	--页大小的字符串形式
//        @SQL nvarchar(4000)		--最终执行的SQL语句
	
//    SELECT
//        @sFrom = LTRIM(RTRIM(@sFrom)),
//        @obj_id = OBJECT_ID(@sFrom),
//        @sFrom = N' FROM ' + @sFrom,
//        @sFields = CASE WHEN @sFields > N'' THEN N' ' + @sFields ELSE N' *' END,
//        @sWhere = CASE WHEN @sWhere > N'' THEN N' WHERE ' + @sWhere ELSE N' ' END,
//        @sGroupBy = CASE WHEN @sGroupBy > N'' THEN N' GROUP BY ' + @sGroupBy ELSE N' ' END,
//        @sHaving = CASE WHEN @sHaving > N'' THEN N' HAVING ' + @sHaving ELSE N' ' END,
//        @sOrderBy = CASE WHEN @sOrderBy > N'' THEN N' ORDER BY ' + @sOrderBy ELSE N' ' END,
//        @sKeyField = CASE WHEN @sKeyField > N'' THEN RTRIM(LTRIM(@sKeyField)) ELSE '' END,
//        @pageSize = CAST(@iPageSize AS nvarchar),
//        @hasGroupBy = CASE WHEN @sGroupBy = N' ' THEN 0 ELSE 1 END,
//        @execState = @iRecordCount

//    -- -1 查记录并返回 0 不查记录 >0根据情况查记录
//    IF @iRecordCount = -1 OR (@iRecordCount > 0 AND (@iPageIndex - 1) * @iPageSize > @iRecordCount)
//    BEGIN
//        IF @hasGroupBy = 1
//            SET @SQL='SELECT @iRecordCount=Count(0) FROM (SELECT ' + @sFields + @sFrom + @sWhere + @sGroupBy + @sHaving + ') Temp_Table_A'
//        ELSE
//            SET @SQL='SELECT @iRecordCount=Count(0) ' + @sFrom + @sWhere 
//        EXEC sp_executesql @SQL, N'@iRecordCount int OUT', @iRecordCount OUT
//    END
	
//    IF @execState = -1 RETURN
//    IF @iPageIndex < 1 SET @iPageIndex = 1
//    IF @execState > 0
//    BEGIN
//        IF @iRecordCount <= (@iPageIndex - 1) * @iPageSize
//        BEGIN
//            IF @iRecordCount % @iPageSize = 0
//                SET @iPageIndex = CEILING(@iRecordCount/@iPageSize)
//            ELSE
//                SET @iPageIndex = CEILING(@iRecordCount/@iPageSize) + 1
//        END
//    END
	
//    IF @iPageIndex = 1 
//    BEGIN
//        IF @hasGroupBy = 1
//            SET @SQL = 'SELECT TOP ' + @pageSize + @sFields + ' FROM ' + '(SELECT ' + @sFields + @sFrom + @sWhere + @sGroupBy + @sHaving + ') AS Temp_Table_A ' + @sOrderBy
//        ELSE
//            SET @SQL = 'SELECT TOP ' + @pageSize + @sFields + @sFrom + @sWhere + @sOrderBy
//        GOTO LB_RETURN --执行并返回
//    END

//    --空关键字段处理
//    IF @sKeyField = N'' AND @obj_id IS NOT NULL 
//    BEGIN
//        --获取只有一个字段的主键
//        SELECT @sKeyField = t1.name FROM sys.columns t1, sys.index_columns t2
//            , (SELECT b.object_id, b.index_id FROM sys.indexes a, sys.index_columns b
//                WHERE a.object_id = b.object_id AND a.index_id = b.index_id AND a.is_primary_key = 1 
//                    AND a.object_id = @obj_id
//                GROUP BY b.object_id, b.index_id
//                HAVING count(*) = 1) t3
//        WHERE t1.object_id = t2.object_id AND t2.object_id = t3.object_id
//            AND t1.column_id=t2.column_id AND t2.index_id = t3.index_id
//    END
	
//    DECLARE @id1 nvarchar(30),
//            @id2 nvarchar(30)
//    SELECT @id1 = CAST((@iPageIndex-1)*@iPageSize AS nvarchar),
//           @id2 = CAST(@iPageIndex*@iPageSize AS nvarchar)
	
//    IF @sKeyField = N''
//    BEGIN
//        IF @hasGroupBy = 1
//            SET @sFrom = ' FROM (SELECT ' + @sFields + @sFrom + @sWhere + @sGroupBy + @sHaving + ') AS Temp_Table_A '
//        ELSE
//            SET @sFrom = @sFrom + @sWhere
//        --(1)无关键字，有排序（使用ROW_NUMBER方式分页）
//        IF @sOrderBy <> ' '  
//        BEGIN
//            SET @SQL = 'SELECT ' + @sFields + ' FROM (SELECT ROW_NUMBER() OVER (' + @sOrderBy + ') AS RowNumber, ' + @sFields 
//                    + @sFrom + ') AS Temp_Table_B WHERE Temp_Table_B.RowNumber > ' + @id1 + ' AND Temp_Table_B.RowNumber <= ' + @id2
//            GOTO LB_RETURN --执行并返回
//        END
//        --(2)无关键字，无排序（使用TempTable方式分页）
//        ELSE BEGIN			
//            SET @SQL = 'SELECT ID_IDENTITY = IDENTITY(int, 1, 1),' + @sFields 
//                + ' INTO #Pager_Temp_Table FROM (SELECT TOP 100 PERCENT * ' + @sFrom
//                + ') Temp_Table_B SELECT ' + @sFields + ' FROM #Pager_Temp_Table WHERE ID_IDENTITY > ' + @id1 + ' AND ID_IDENTITY <= ' + @id2
//            GOTO LB_RETURN --执行并返回
//        END
//    END
//    ELSE BEGIN
//        IF LTRIM(RTRIM(@sOrderBy)) = ''
//            SET @sOrderBy = ' ORDER BY ' + @sKeyField
//        --(3)有关键字，存在GroupBy子句（使用TopNotIn方式分页）
//        IF @hasGroupBy = 1
//        BEGIN
//            SET @SQL = 'SELECT TOP ' + @pageSize + @sFields + ' FROM (SELECT TOP ' + @id2 + @sFields 
//                + @sFrom + @sWhere + @sGroupBy + @sHaving + @sOrderBy + ') AS Temp_Table_A '
//                + 'WHERE ' + @sKeyField + ' NOT IN(SELECT TOP ' + @id1 + ' ' + @sKeyField 
//                + @sFrom + @sWhere + @sGroupBy + @sHaving + @sOrderBy + ') AS Temp_Table_B)' + @sOrderBy

//            GOTO LB_RETURN --执行并返回
//        END 
//        ELSE BEGIN
//            DECLARE	@tmpWhere nvarchar(2000)
//            IF (RTRIM(@sWhere) = '')
//                SET @tmpWhere = ' WHERE '
//            ELSE
//                SET @tmpWhere = @sWhere + ' AND '

//            --(4)有关键字，不存在GroupBy子句，@sOrder包含关键字（使用MaxMin方式分页）
//            IF CHARINDEX(' ORDER BY ' + @sKeyField, @sOrderBy) = 1 
//            BEGIN
//                DECLARE @sTmp nvarchar(30)
//                IF CHARINDEX(' ORDER BY ' + @sKeyField + ' DESC', @sOrderBy) = 1
//                    SET @sTmp = '<(SELECT MIN('
//                ELSE
//                    SET @sTmp = '>(SELECT MAX('
//                SET @SQL = 'SELECT TOP ' + @pageSize + @sFields 
//                    + @sFrom + @tmpWhere + @sKeyField + @sTmp + @sKeyField 
//                    + ') FROM (SELECT TOP ' + @id1 + ' ' + @sKeyField 
//                    + @sFrom + @sWhere + @sOrderBy + ') AS Temp_Table_A)' + @sOrderBy
//                GOTO LB_RETURN --执行并返回
//            END
//            --(5)有关键字，不存在GroupBy子句，@sOrder不包含关键字（使用TopNotIn方式分页）
//            ELSE BEGIN 
//                SET @SQL = 'SELECT TOP ' + @pageSize + @sFields + @sFrom + @tmpWhere
//                    + @sKeyField + ' NOT IN(SELECT TOP ' + @id1 + @sKeyField
//                    + @sFrom + @sWhere + @sOrderBy + ')' + @sOrderBy
//                GOTO LB_RETURN --执行并返回
//            END
//        END
//    END

//LB_RETURN:
//    PRINT(@SQL)
//    PRINT(@iRecordCount)
//    EXEC(@SQL)
//    RETURN
//END TRY
//BEGIN CATCH
//    SET @sPagerSql = @SQL
//    DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity INT
//    SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
//    RAISERROR(@ErrMsg, @ErrSeverity, 1)
//    PRINT(@SQL)
//END CATCH

//SET NOCOUNT OFF

//         */
//        #endregion

//        public ProcDao ProcDao { get; set; }
//        public SqlStruct SqlStruct { get; set; }
//        public int PageSize { get; set; }
//        public string KeyField { get; set; }
        
//        private static Dictionary<string, SqlStruct> _sqlStructCache = new Dictionary<string, SqlStruct>();
//        private static object _syncLock = new object();

//        public ProcPager(string sql, int pageSize)
//            : this(sql, pageSize, null, DatabaseFactory.Create()) { }
//        public ProcPager(string sql, int pageSize, string keyField)
//            : this(sql, pageSize, keyField, DatabaseFactory.Create()) { }
//        public ProcPager(string sql, int pageSize, string keyField, string connectionStringName)
//            : this(sql, pageSize, keyField, DatabaseFactory.Create(connectionStringName)) { }
//        public ProcPager(string sql, int pageSize, Database database)
//            : this(sql, pageSize, null, database) { }
//        public ProcPager(string sql, int pageSize, string keyField, Database database)
//        {
//            if (!_sqlStructCache.ContainsKey(sql))
//            {
//                lock (_syncLock)
//                {
//                    if (!_sqlStructCache.ContainsKey(sql))
//                    {
//                        SqlStruct = new SqlParser().Parse(sql);
//                        _sqlStructCache.Add(sql, SqlStruct);
//                    }
//                }
//            }
//            else SqlStruct = _sqlStructCache[sql];

//            PageSize = pageSize;
//            KeyField = keyField;
//            if (database == null) database = DatabaseFactory.Create();
//            TinyFxSection section = TinyFxSection.GetSection();
//            if (section != null)
//            {
//                ProcDao = database.CreateProcDao(section.DataConfig.PagerSpName);
//                ProcDao.AddInParameter("@sFrom", SqlStruct.From, DbType.AnsiString)
//                    .AddInParameter("@sFields", SqlStruct.Fields, DbType.AnsiString)
//                    .AddInParameter("@sWhere", SqlStruct.Where, DbType.AnsiString)
//                    .AddInParameter("@sGroupBy", SqlStruct.GroupBy, DbType.AnsiString)
//                    .AddInParameter("@sHaving", SqlStruct.Having, DbType.AnsiString)
//                    .AddInParameter("@sOrderBy", SqlStruct.OrderBy, DbType.AnsiString)
//                    .AddInParameter("@sKeyField", KeyField, DbType.AnsiString)
//                    .AddInParameter("@iPageSize", PageSize, DbType.Int32)
//                    .AddParameter("@iPageIndex", DbType.Int64)
//                    .AddInOutParameter("@iRecordCount", -1, DbType.Int64, 8)
//                    .AddOutParameter("@sPagerSql", DbType.AnsiString, 4000);
//            }
//            LastRefreshRecordCount = DateTime.MinValue;
//        }

//        private long _recordCount = -1;
//        public DateTime LastRefreshRecordCount { get; internal set; }
//        public long PageCount { get; internal set; }
//        private void InitPageCount()
//        {
//            long rem;
//            PageCount = Math.DivRem(_recordCount, PageSize, out rem);
//            PageCount += rem == 0 ? 0 : 1;
//        }
//        public long GetRecordCount(bool refresh = true)
//        {
//            if (refresh || _recordCount == -1)
//            {
//                try
//                {
//                    ProcDao.SetParameterValue("@iRecordCount", -1).ExecNonQuery();
//                    object o = ProcDao.GetParameterValue("@iRecordCount");
//                    _recordCount = (long)(ProcDao.GetParameterValue("@iRecordCount") ?? 0);
//                    InitPageCount();
//                    LastRefreshRecordCount = DateTime.Now;
//                }
//                catch (Exception ex)
//                {
//                    if (ProcDao.GetParameterValue("@sPagerSql") != DBNull.Value)
//                        ex.AddUserData((string)ProcDao.GetParameterValue("@sPagerSql"));
//                    ex.Preserve();
//                }
//            }
//            return _recordCount;
//        }
//        public DbDataReader GetPageData(long pageIndex)
//        {
//            DbDataReader ret = null;
//            try
//            {
//                ret = ProcDao.SetParameterValue("@iRecordCount", _recordCount).SetParameterValue("@iPageIndex", pageIndex).ExecReader();
//            }
//            catch (Exception ex)
//            {
//                if (ProcDao.GetParameterValue("@sPagerSql") != DBNull.Value)
//                    ex.AddUserData((string)ProcDao.GetParameterValue("@sPagerSql"));
//                ex.Preserve();
//            }
//            return ret;
//        }


//        public DbDataReader GetPageData(int pageIndex)
//        {
//            return GetPageData((long)pageIndex);
//        }


//        public void AddInParameter(string name, object value = null, DbType dbType = DbType.AnsiString, int size = 0)
//        {
//            throw new NotImplementedException("分页存储过程不支持参数传入。");
//        }

//        public void AddParameters(IEnumerable<DbParameter> paras)
//        {
//            throw new NotImplementedException("分页存储过程不支持参数传入。");
//        }


//        public IEnumerable<T> GetPageData<T>(long pageIndex)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<T> GetPageData<T>(int pageIndex)
//        {
//            throw new NotImplementedException();
//        }
//    }
}
