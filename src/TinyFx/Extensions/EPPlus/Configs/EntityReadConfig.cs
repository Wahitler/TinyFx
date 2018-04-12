using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using OfficeOpenXml;

namespace TinyFx.Extensions.EPPlus
{
    public class EntityReadConfig<TEntity> : ExcelReadConfig 
        where TEntity : class, new()
    {
        public Dictionary<PropertyInfo, HeaderMapConfig> PropertyConfigs { get; } = new Dictionary<PropertyInfo, HeaderMapConfig>();

        /// <summary>
        /// 设置属性映射
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
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
        public TEntity MapEntity(ExcelRowEx row)
        {
            TEntity ret = new TEntity();
            foreach (var property in PropertyConfigs.Keys)
            {
                var config = PropertyConfigs[property];
                var cell = row[config.ColumnIndex];
                object value = cell.Value;
                if (config.ReadCellValueDelegate != null)
                    value = config.ReadCellValueDelegate(cell);
                else
                {
                    try
                    {
                        value = TinyFxUtil.ConvertTo(value, property.PropertyType, config.Formatter);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Excel值转换Entity属性值失败。Cell值:{value} 属性名:{property.Name} Message:{ex.Message}");
                    }
                }
                property.SetValue(ret, value, null);
            }
            return ret;
        }
    }
}
