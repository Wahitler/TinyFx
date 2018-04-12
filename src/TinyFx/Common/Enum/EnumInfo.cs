using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace TinyFx
{
    /// <summary>
    /// 枚举类型的描述信息
    /// </summary>
    public class EnumInfo
    {
        /// <summary>
        /// 枚举类型信息
        /// </summary>
        public Type EnumType { get; private set; }

        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name => EnumType.Name;

        /// <summary>
        /// Enum类型上添加DescriptionAttribute中定义的描述
        /// </summary>
        public string Description { get; set; }

        private Dictionary<int, EnumItemInfo> _items;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="enumType"></param>
        public EnumInfo(Type enumType)
        {
            EnumType = enumType;
            var enumAttr = Attribute.GetCustomAttribute(EnumType, typeof(DescriptionAttribute)) as DescriptionAttribute;
            Description = (enumAttr != null) ? enumAttr.Description : null;
            var fields = EnumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            _items = new Dictionary<int, EnumItemInfo>();
            foreach (var field in fields)
            {
                var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                var item = new EnumItemInfo()
                {
                    Name = field.Name,
                    Value = (int)Enum.Parse(EnumType, field.Name),
                    Description = (attr != null) ? attr.Description : null
                };
                _items.Add(item.Value, item);
            }
        }

        /// <summary>
        /// 获取枚举项列表
        /// </summary>
        /// <returns></returns>
        public List<EnumItemInfo> GetList() => _items.Values.ToList();

        /// <summary>
        /// 获取枚举项信息
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public EnumItemInfo GetItem(int enumValue)
        {
            if (!_items.ContainsKey(enumValue))
                throw new Exception($"枚举值不能存在。EnumType:{EnumType} Value:{enumValue}");
            return _items[enumValue];
        }

        /// <summary>
        /// 获取枚举项信息
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public EnumItemInfo GetItem(object value)
        {
            int key = (value is int || value.GetType() == EnumType) ? (int)value 
                : (int)Enum.Parse(EnumType, Convert.ToString(value), true);
            return GetItem(key);
        }
    }
}
