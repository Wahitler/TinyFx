using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TinyFx.Collections
{
    /// <summary>
    /// 可XML序列化的字典集合
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        #region IXmlSerializable
        /// <summary>
        /// 此方法是保留方法，请不要使用
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema() => null;
        /// <summary>
        /// 从对象的 XML 表示形式生成该对象
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty) return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                this.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }
        /// <summary>
        /// 将对象转换为其 XML 表示形式
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                TValue value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
        #endregion

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="arr"></param>
        public void Add(IDictionary<TKey, TValue> arr)
        {
            if (arr == null) return;
            foreach (TKey key in arr.Keys)
                Add(key, arr[key]);
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="arr"></param>
        public void Add(IDictionary arr)
        {
            if (arr == null) return;
            foreach (DictionaryEntry entry in arr)
                Add((TKey)entry.Key, (TValue)entry.Value);
        }

        /// <summary>
        /// 序列化到Xml
        /// </summary>
        /// <returns></returns>
        public string SerializeXml()
        {
            string ret = string.Empty;
            if (this != null && this.Count > 0)
            {
                ret = SerializerUtil.SerializeXml<SerializableDictionary<TKey, TValue>>(this);
            }
            return ret;
        }

        /// <summary>
        /// XML反序列化获得集合
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static SerializableDictionary<TKey, TValue> DeserializeXml(string xml)
        {
            SerializableDictionary<TKey, TValue> ret = null;
            if (!string.IsNullOrEmpty(xml))
                ret = SerializerUtil.DeserializeXml<SerializableDictionary<TKey, TValue>>(xml);
            return ret;
        }
    }
}
