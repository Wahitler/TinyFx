using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Data.Schema
{
    [Serializable]
    public class SchemaCollection<T> : KeyedCollection<string, T>
        where T : ISchemaCollectionKey
    {
        protected override string GetKeyForItem(T item)
        {
            return item.GetKey();
        }
    }

    /// <summary>
    /// 定义Schema在集合SchemaColletion时的主键字段
    /// </summary>
    public interface ISchemaCollectionKey
    {
        string GetKey();
    }
}

