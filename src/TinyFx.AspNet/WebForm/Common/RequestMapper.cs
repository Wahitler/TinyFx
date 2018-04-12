using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Reflection;

namespace TinyFx.AspNet.WebForm
{
    /// <summary>
    /// 通过获取Request的集合信息获得实体对象，可通过RequestMapperAttribute定义映射关系，
    /// </summary>
    internal class RequestMapper
    {
        #region 实例成员
        private Type _type;
        private Func<object> _buildHandler; //构建实体对象的代理
        //private List<RequestMappingData> _propertyMappings = new List<RequestMappingData>(); //设置属性的代理对象
        private Dictionary<string, RequestMappingData> _mappingCache = new Dictionary<string, RequestMappingData>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type">映射的实体对象类型信息</param>
        public RequestMapper(Type type)
        {
            _type = type;
            _buildHandler = DynamicCompiler.CreateBuilder(type);
            bool isDefined = true;
            PropertyInfo[] properties = (from p in type.GetProperties()
                                         where p.IsDefined(typeof(RequestMapperAttribute), true)
                                         select p).ToArray<PropertyInfo>();
            //没有定义RequestMapperAttribute取所有属性
            if (properties == null || properties.Length == 0)
            {
                isDefined = false;
                properties = type.GetProperties();
            }
            //获得属性赋值代理
            foreach (PropertyInfo property in properties)
            {
                RequestMappingData item = new RequestMappingData();
                if (isDefined)
                {
                    item.Attribute = (RequestMapperAttribute)Attribute.GetCustomAttribute(property, typeof(RequestMapperAttribute));
                    if (string.IsNullOrEmpty(item.Attribute.Name))
                    {
                        item.Attribute.Name = property.Name;
                    }
                }
                else
                {
                    item.Attribute = new RequestMapperAttribute(property.Name);
                }
                item.Property = property;
                item.SetHandler = DynamicCompiler.CreateSetter(type, property);
                _mappingCache.Add(item.Attribute.Name.ToLower(), item);
            }
        }

        /// <summary>
        /// 构建实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public T Build<T>(NameValueCollection values)
        {
            object ret = _buildHandler();
            foreach (string key in values.Keys)
            {
                string curr = key.ToLower();
                if (_mappingCache.ContainsKey(curr))
                {
                    RequestMappingData mapping = _mappingCache[curr];
                    object value = TinyFxUtil.ConvertTo(values[key], mapping.Property.PropertyType);
                    mapping.SetHandler.Invoke(ret, value);
                }
            }
            return (T)ret;
        }


        // 反射属性时获得的数据
        public class RequestMappingData
        {
            public RequestMapperAttribute Attribute { get; set; }
            public PropertyInfo Property { get; set; }
            public Action<object, object> SetHandler { get; set; }
        }
        #endregion

        #region 静态成员
        private static readonly Dictionary<Type, RequestMapper> _mapperCache = new Dictionary<Type, RequestMapper>();//缓存
        private static object _lock = new object();

        /// <summary>
        /// 获得构建对象的代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<NameValueCollection, T> GetMapper<T>()
        {
            Type type = typeof(T);
            if (!_mapperCache.ContainsKey(type))
            {
                lock (_lock)
                {
                    if (!_mapperCache.ContainsKey(type))
                    {
                        RequestMapper mapper = new RequestMapper(type);
                        _mapperCache.Add(type, mapper);
                    }
                }
            }
            return new Func<NameValueCollection, T>(_mapperCache[type].Build<T>);
        }

        /// <summary>
        /// 映射对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T Map<T>(NameValueCollection array)
        {
            Func<NameValueCollection, T> func = GetMapper<T>();
            return func(array);
        }
        #endregion
    }

    /// <summary>
    /// HttpRequest与实体对象字段的映射的特性类，通过WebFormUtil.MapTo(T)()方法实现实体映射转换。
    /// </summary>
    public class RequestMapperAttribute : Attribute
    {
        /// <summary>
        /// HttpRequest的项的键
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RequestMapperAttribute() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">HttpRequest的项的键</param>
        public RequestMapperAttribute(string name)
        {
            Name = name;
        }
    }
}
