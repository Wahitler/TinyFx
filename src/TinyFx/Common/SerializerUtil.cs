using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;
using TinyFx.IO;
using Newtonsoft.Json;

namespace TinyFx
{
    /// <summary>
    /// 序列化辅助类,提供Binary,Xml和Json序列化
    /// </summary>
    public static class SerializerUtil
    {
        #region Binary Serializer
        /// <summary>
        /// 二进制序列化，对象需要 SerializableAttribute
        /// </summary>
        /// <param name="source">序列化对象</param>
        /// <returns></returns>
        public static byte[] SerializeBinary(object source)
        {
            byte[] ret = null;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, source);
                ret = ms.ToArray();
            }
            return ret;
        }

        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <param name="input">序列化字节数组</param>
        /// <returns></returns>
        public static object DeserializeBinary(byte[] input)
        {
            object ret = null;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(input))
            {
                ret = formatter.Deserialize(ms);
            }
            return ret;
        }

        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="input">序列化字节数组</param>
        /// <returns></returns>
        public static T DeserializeBinary<T>(byte[] input) where T : class
            => DeserializeBinary(input) as T;

        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <param name="source">序列化对象</param>
        /// <param name="filename">序列化到文件</param>
        public static void SerializeBinaryToFile(object source, string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                formatter.Serialize(fs, source);
            }
        }

        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static object DeserializeBinaryFromFile(string filename)
        {
            object ret = null;
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                ret = formatter.Deserialize(fs);
            }
            return ret;
        }
        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static T DeserializeBinaryFromFile<T>(string filename) where T : class
            => DeserializeBinaryFromFile(filename) as T;

        #endregion //Binary Serializer

        #region Xml Serializer

        /// <summary>
        /// Xml序列化到bytes
        /// </summary>
        /// <param name="type">序列化对象类型</param>
        /// <param name="source">序列化对象</param>
        /// <returns></returns>
        public static byte[] SerializeXmlToBytes(Type type, object source)
        {
            byte[] ret = null;
            XmlSerializer ser = new XmlSerializer(type);
            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, source);
                ret = ms.ToArray();
            }
            return ret;
        }

        /// <summary>
        /// Xml序列化到bytes
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="source">序列化对象</param>
        /// <returns></returns>
        public static byte[] SerializeXmlToBytes<T>(T source) 
            => SerializeXmlToBytes(typeof(T), source);

        /// <summary>
        /// Xml序列化到string
        /// </summary>
        /// <param name="type">序列化对象类型</param>
        /// <param name="source">序列化对象</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string SerializeXml(Type type, object source, Encoding encoding = null)
            => (encoding ?? Encoding.UTF8).GetString(SerializeXmlToBytes(type, source));

        /// <summary>
        /// Xml序列化string
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="source">序列化对象</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string SerializeXml<T>(T source, Encoding encoding = null)
            => (encoding ?? Encoding.UTF8).GetString(SerializeXmlToBytes(typeof(T), source));

        /// <summary>
        /// Xml反序列化从bytes
        /// </summary>
        /// <param name="type">反序列化对象类型</param>
        /// <param name="input">反序列化对象的bytes</param>
        /// <returns></returns>
        public static object DeserializeXmlFromBytes(Type type, byte[] input)
        {
            object ret = null;
            XmlSerializer ser = new XmlSerializer(type);
            using (MemoryStream ms = new MemoryStream(input))
            {
                ret = ser.Deserialize(ms);
            }
            return ret;
        }

        /// <summary>
        /// Xml反序列化从bytes
        /// </summary>
        /// <typeparam name="T">反序列化对象类型</typeparam>
        /// <param name="input">序列化对象</param>
        /// <returns></returns>
        public static T DeserializeXmlFromBytes<T>(byte[] input) where T : class
            => DeserializeXmlFromBytes(typeof(T), input) as T;

        /// <summary>
        /// Xml反序列化从string
        /// </summary>
        /// <param name="type">反序列化对象类型</param>
        /// <param name="input">可反序列化的字符串</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static object DeserializeXml(Type type, string input, Encoding encoding = null)
            => DeserializeXmlFromBytes(type, (encoding ?? Encoding.UTF8).GetBytes(input));

        /// <summary>
        /// Xml反序列化从Stream
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static object DeserializeXml(Type type, Stream input)
            => new XmlSerializer(type).Deserialize(input);

        /// <summary>
        /// Xml反序列化从Stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T DeserializeXml<T>(Stream input)
            => (T)DeserializeXml(typeof(T), input);

        /// <summary>
        /// Xml反序列化
        /// </summary>
        /// <typeparam name="T">反序列化对象类型</typeparam>
        /// <param name="input">可反序列化的字符串</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static T DeserializeXml<T>(string input, Encoding encoding = null) where T : class
            => (T)DeserializeXmlFromBytes(typeof(T), (encoding ?? Encoding.UTF8).GetBytes(input));
        #endregion //Xml Serializer

        #region JSON Serializer 使用Json.NET
        /*
         *  Newtonsoft.Json 说明
         *  支持DataTable，DataSet，Entity，EF
         *  1）序列化时Entry属性设置：属性名，包含忽略，空值处理
         *      类Attribute：JsonObject 属性Attribute: JsonProperty, JsonIgnore
         *  2）默认值
         *      settings: DefaultValueHandling.Ignore
         *  3）null值的处理
         *      settings: NullValueHandling.Include
         *  4）序列化时Entry属性值类型转换
         *      JsonConverterAttribute: 日期转换
         */
        private static JsonSerializerSettings _jsetting = new JsonSerializerSettings() {
            DefaultValueHandling = DefaultValueHandling.Include, // 默认值处理
            NullValueHandling = NullValueHandling.Include, // 空值处理
            // 日期格式
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
        };
        
        /// <summary>
        /// 序列化JSON对象，对象需要 DataContractAttribute,DataMember,IgnoreDataMember
        /// </summary>
        /// <param name="source">对象</param>
        /// <returns></returns>
        public static string SerializeJson(object source)
            => JsonConvert.SerializeObject(source, _jsetting);

        /// <summary>
        /// 反序列化JSON对象
        /// </summary>
        /// <param name="type">JSON类型</param>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static object DeserializeJson(Type type, string json)
            => new JsonSerializer().Deserialize(new StringReader(json), type);

        /// <summary>
        /// 反序列化JSON对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object DeserializeJson(Type type, Stream stream, Encoding encoding = null)
            => DeserializeJson(type, IOUtil.ReadStreamToString(stream, encoding));
        
        /// <summary>
        /// 反序列化JSON对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static T DeserializeJson<T>(string json)
            => (T)DeserializeJson(typeof(T), json);
        #endregion
    }
}
