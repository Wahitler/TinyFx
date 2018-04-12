using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TinyFx.Extensions.EPPlus
{
    public class EntityWriteConfig<TEntity> : ExcelWriteConfig
        where TEntity : class, new()
    {
        public Dictionary<PropertyInfo, HeaderMapConfig> PropertyConfigs { get; } = new Dictionary<PropertyInfo, HeaderMapConfig>();
        public HeaderMapConfig Property<TProperty>(Expression<Func<TEntity, TProperty>> expr)
        {
            var config = new HeaderMapConfig();
            var prop = GetPropertyInfo(expr);
            if (PropertyConfigs.ContainsKey(prop))
                PropertyConfigs[prop] = config;
            else
                PropertyConfigs.Add(prop, config);
            ConfigHeaders.Add(config);
            return config;
        }
    }
}
