using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Data.ORM
{
    public abstract class DbEOBase
    {
        /// <summary> 
        /// 数据提供程序类型
        /// </summary>
        public abstract DbDataProvider Provider { get; }
        /// <summary>
        /// 数据对象类型
        /// </summary>
        public abstract DbObjectType SourceType { get; }

        /// <summary>
        /// 数据对象名称
        /// </summary>
        public abstract string SourceName { get; }
        public abstract bool HasPrimaryKeys { get; }
        public abstract Dictionary<string, object> GetPrimaryKeys();
        public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
    }
}
