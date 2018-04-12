﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using TinyFx.Reflection;

namespace TinyFx.Data.DataMapping
{
    /// <summary>
    /// 通过反射实现 IDataReader ==> Entity 的映射类
    /// 如果定义了DataColumnMapperAttribute则使用，否则按照属性名称和数据字段名映射
    /// </summary>
    internal class ReflectionDataMapping
    {
        private static readonly Dictionary<Type, ReflectionMapperBuilder> _mapCache = new Dictionary<Type, ReflectionMapperBuilder>();
        private static object _syncLock = new object();
        public static Func<IDataReader, T> GetRowMapper<T>()
        {
            Func<IDataReader, T> ret = null;
            Type type = typeof(T);
            if (!_mapCache.ContainsKey(type))
            {
                lock (_syncLock)
                {
                    if (!_mapCache.ContainsKey(type))
                    {
                        ReflectionMapperBuilder builder = new ReflectionMapperBuilder(type);
                        _mapCache.Add(type, builder);
                        ret = builder.Build<T>;
                    }
                }
            }
            else
            {
                ret = _mapCache[type].Build<T>;
            }
            return ret;
        }

    }
    internal class ReflectionMapperBuilder
    {
        private Type _type;
        // key: columnName小写
        private Dictionary<string, PropertySetter> _columnMapper = new Dictionary<string, PropertySetter>();

        public ReflectionMapperBuilder(Type t)
        {
            _type = t;
            PropertyInfo[] properties = (from p in _type.GetProperties()
                                         where p.CanWrite // && p.IsDefined(typeof(DataColumnMapperAttribute), true)
                                         select p).ToArray();
            if (properties == null || properties.Length == 0) return;
            foreach (PropertyInfo property in properties)
            {
                DataColumnMapperAttribute attr = (DataColumnMapperAttribute)Attribute.GetCustomAttribute(property, typeof(DataColumnMapperAttribute));
                string key = (attr != null && !string.IsNullOrEmpty(attr.ColumnName)) ? attr.ColumnName.ToLower() : property.Name.ToLower();

                var setter = new PropertySetter()
                {
                    Handler = ReflectionUtil.SetPropertyValue,
                    Type = property.PropertyType,
                    Name = property.Name
                };
                _columnMapper.Add(key, setter);
            }
        }
        public T Build<T>(IDataReader reader)
        {
            object ret = Activator.CreateInstance(_type);
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var columnName = reader.GetName(i);
                var key = columnName.ToLower();
                if (_columnMapper.ContainsKey(key))
                {
                    var item = _columnMapper[key];
                    object value = TinyFxUtil.ConvertTo(reader[columnName], item.Type);
                    item.Handler.Invoke(ret, item.Name, value);
                }
            }

            return (T)ret;
        }
        /// <summary>
        /// 属性设置类
        /// </summary>
        class PropertySetter
        {
            /// <summary>
            /// 属性设置方法
            /// </summary>
            public Action<object, string, object> Handler { get; set; }
            /// <summary>
            /// 属性类型
            /// </summary>
            public Type Type { get; set; }
            /// <summary>
            /// 属性名
            /// </summary>
            public string Name { get; set; }
        }
    }

}
