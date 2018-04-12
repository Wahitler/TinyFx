using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Data.Schema;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// SQL Server 数据库概要信息提供程序
    /// </summary>
    public class SqlServerSchemaProvider
    {
        public SqlDatabase Database { get; private set; }
        public SqlServerSchemaProvider(SqlDatabase database)
        {
            Database = database;
        }
        public DatabaseSchema GetDatabase()
        {
            return null;
        }
        /*
select t3.name as SchemaName, t2.name as TableName, t1.name as ColumnName, t4.name as TypeName
	, t1.max_length, t1.precision, t1.scale, t1.is_nullable
from sys.columns t1 
	inner join sys.tables t2 on t1.object_id=t2.object_id
	left join sys.schemas t3 on t2.schema_id = t3.schema_id
	left join sys.types t4 on t1.user_type_id = t4.user_type_id and t4.schema_id=4 and t4.is_assembly_type=0
order by t1.object_id, t1.column_id

select t3.name as SchemaName, t2.name as ViewName, t1.name as ColumnName, t4.name as TypeName
	, t1.max_length, t1.precision, t1.scale, t1.is_nullable
from sys.columns t1 
	inner join sys.views t2 on t1.object_id=t2.object_id
	left join sys.schemas t3 on t2.schema_id = t3.schema_id
	left join sys.types t4 on t1.user_type_id = t4.user_type_id and t4.schema_id=4 and t4.is_assembly_type=0
order by t1.object_id, t1.column_id
         */
    }
}
