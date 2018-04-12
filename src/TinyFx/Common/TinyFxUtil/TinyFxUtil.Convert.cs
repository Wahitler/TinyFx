using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TinyFx
{
    /// <summary>
    /// 提供TinyFx辅助方法
    /// </summary>
    public static partial class TinyFxUtil
    {
        #region ConvertTo 类型转换

        /// <summary>
        ///  通用类型转换函数，函数会将DBNull类型转换成null或可空类型
        /// </summary>
        /// <typeparam name="T">转换的类型</typeparam>
        /// <param name="value">需转换的值</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object value)
            => (T)ConvertTo(value, typeof(T));

        /// <summary>
        /// 通用类型转换函数，函数会将DBNull类型转换成null或可空类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="toType"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static object ConvertTo(this object value, Type toType, string format=null)
        {
            // DBNull ==> 引用类型/可空类型
            if (value == DBNull.Value || value == null)
            {
                // toType.FullName.StartsWith("System.Nullable`")
                if (!toType.IsValueType || IsNullableType(toType))
                    return null;
                throw new Exception($"无法转换null或DBNull为类型 {toType.FullName}");
            }
            // 基类型
            Type baseType = Nullable.GetUnderlyingType(toType) ?? toType;
            // 同类型
            if (baseType.IsInstanceOfType(value))
                return value;
            // 简单类型
            switch (baseType.FullName)
            {
                #region 简单类型转换
                case SimpleTypeNames.Byte:
                    return Convert.ToByte(value);
                case SimpleTypeNames.SByte:
                    return Convert.ToSByte(value);
                case SimpleTypeNames.Int16:
                    return Convert.ToInt16(value);
                case SimpleTypeNames.UInt16:
                    return Convert.ToUInt16(value);
                case SimpleTypeNames.Int32:
                    return Convert.ToInt32(value);
                case SimpleTypeNames.UInt32:
                    return Convert.ToUInt32(value);
                case SimpleTypeNames.Int64:
                    return Convert.ToInt64(value);
                case SimpleTypeNames.UInt64:
                    return Convert.ToUInt64(value);
                case SimpleTypeNames.Single:
                    return Convert.ToSingle(value);
                case SimpleTypeNames.Double:
                    return Convert.ToDouble(value);
                case SimpleTypeNames.Decimal:
                    return Convert.ToDecimal(value);
                case SimpleTypeNames.String:
                    return (value is DateTime) ? ((DateTime)value).ToString(format) : Convert.ToString(value);
                case SimpleTypeNames.Char:
                    return Convert.ToChar(value);
                case SimpleTypeNames.Boolean:
                    return ConverterBuilder.GetBooleanConverter().Invoke(value);
                case SimpleTypeNames.DateTime:
                    return ConverterBuilder.GetDateTimeConverter(format).Invoke(value);
                case SimpleTypeNames.TimeSpan:
                    return ConverterBuilder.GetTimeSpanConverter(format).Invoke(value);
                case SimpleTypeNames.DateTimeOffset:
                    return ConverterBuilder.GetDateTimeOffsetConverter(format).Invoke(value);
                case SimpleTypeNames.Guid:
                    return ConverterBuilder.GetGuidConverter().Invoke(value);
                case SimpleTypeNames.Bytes:
                    return ConverterBuilder.GetBytesConverter().Invoke(value);
                #endregion
            }
            if (baseType.IsEnum)
                return ConverterBuilder.GetEnumConverter(baseType)(value);

            #region IConvertible && TypeConverter
            // IConvertible
            if (value is IConvertible)
                return Convert.ChangeType(value, baseType);

            // TypeConverter
            TypeConverter converter = TypeDescriptor.GetConverter(baseType);
            bool flag = converter.CanConvertFrom(value.GetType());
            if (!flag)
                converter = TypeDescriptor.GetConverter(value.GetType());
            if (!flag && !converter.CanConvertTo(baseType))
                throw new InvalidOperationException($"无法转换成类型：{Convert.ToString(value)} ==> {baseType.FullName}");

            try
            {
                return flag ? converter.ConvertFrom(value) : converter.ConvertTo(value, baseType);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"类型转换出错：{Convert.ToString(value)} ==> {baseType.FullName}", ex);
            }
            #endregion
        }

        /*
        /// <summary>
        /// 将.NET对象转换成数据库兼容类型，null转换为DBNull
        /// </summary>
        /// <param name="value">需要转换的对象</param>
        /// <param name="dbType">转换成数据库兼容的.NET类型，存储数据时数据库只兼容一部分.NET类型</param>
        /// <returns></returns>
        public static object ConvertToDBValue(object value, Type dbType)
        {
            if (value == null)
                return DBNull.Value;
            // 同类型
            if (dbType.IsInstanceOfType(value))
                return value;
            object ret = null;
            switch (dbType.FullName)
            {
                case SimpleTypeNames.String:
                    ret = Convert.ToString(value);
                    break;
                case SimpleTypeNames.Byte:
                    ret = Convert.ToByte(value);
                    break;
                case SimpleTypeNames.Int16:
                    ret = Convert.ToInt16(value);
                    break;
                case SimpleTypeNames.Int32:
                    ret = Convert.ToInt32(value);
                    break;
                case SimpleTypeNames.Int64:
                    ret = Convert.ToInt64(value);
                    break;
                case SimpleTypeNames.Single:
                    ret = Convert.ToSingle(value);
                    break;
                case SimpleTypeNames.Double:
                    ret = Convert.ToDouble(value);
                    break;
                case SimpleTypeNames.Decimal:
                    ret = Convert.ToDecimal(value);
                    break;
                //
                case SimpleTypeNames.Boolean:
                    ret = ConverterBuilder.GetBooleanConverter().Invoke(value);
                    break;
                case SimpleTypeNames.DateTime:
                    ret = ConverterBuilder.GetDateTimeConverter().Invoke(value);
                    break;
                case SimpleTypeNames.DateTimeOffset:
                    ret = ConverterBuilder.GetDateTimeOffsetConverter().Invoke(value);
                    break;
                case SimpleTypeNames.TimeSpan:
                    ret = ConverterBuilder.GetTimeSpanConverter().Invoke(value);
                    break;
                case SimpleTypeNames.Guid:
                    ret = ConverterBuilder.GetGuidConverter().Invoke(value);
                    break;
                case SimpleTypeNames.Bytes:
                    ret = ConverterBuilder.GetBytesConverter().Invoke(value);
                    break;
                default:
                    ret = TinyFxUtil.ConvertTo(value, dbType);
                    break;
            }
            return ret;
        }
        */

        /// <summary>
        /// 转换矩形数组为交错数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[][] ConvertArray<T>(T[,] array)
        {
            T[][] ret = new T[array.GetLength(0)][];
            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                T[] item = new T[array.GetLength(1)];
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    item[j] = array[i, j];
                }
                ret[i] = item;
            }
            return ret;
        }

        #endregion
    }
}
