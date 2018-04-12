using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using TinyFx;
using TinyFx.Collections;

namespace ConsoleCore
{
    public class CommonTest: ITestClass
    {
        public static void EnumInfo()
        {
            var info = EnumUtil.GetInfo<TestEnum>();
            Console.WriteLine(info.Description);
            foreach(var item in info.GetList())
                Console.WriteLine($"{item.Value} {item.Name} {item.Description}");

            Console.WriteLine(EnumUtil.GetItemDescription<TestEnum>(TestEnum.B));
        }

        public static void HasFlag()
        {
            TestEnum a = TestEnum.B | TestEnum.C;
            Console.WriteLine(EnumUtil.HasFlag(a, TestEnum.D));
            Console.WriteLine(EnumUtil.HasFlag(a, TestEnum.B));
        }

        [Flags]
        [Description("测试枚举")]
        public enum TestEnum
        {
            [Description("枚举A")]
            A = 0,
            [Description("枚举B")]
            B=1,
            C=2,
            D=4
        }

        [DataContract]
        [Serializable]
        public class A
        {
            public int Id { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public DateTime Birthday { get; set; }
            public A() { }
            public A(int id, string name)
            {
                Id = id; Name = name;
                Birthday = DateTime.Now;
            }
        }

        public static void TestSerializerUtil()
        {
            var dic = new SerializableDictionary<int, string>() {
                { 1, "aaa"}, { 2,"bbb" },{ 3,"ccc"}
            };
            //var data = SerializerUtil.SerializeBinary(dic);
            //foreach (var item in SerializerUtil.DeserializeBinary<SerializableDictionary<int, string>>(data))
            //    Console.WriteLine(item.Key + item.Value);
            
            // 自定义SerializableDictionary的XML序列化
            var xml = SerializerUtil.SerializeXml(dic);
            Console.WriteLine(xml);
            foreach (var item in SerializerUtil.DeserializeXml<SerializableDictionary<int, string>>(xml))
                Console.WriteLine(item.Key + item.Value);
            Console.WriteLine("--------------xml end----------");
            
            // Dictionary的json序列化
            var dicJson = new Dictionary<int, string>() { { 1, "aaa" }, { 2, "bbb" }, { 3, "ccc" } };
            var json = SerializerUtil.SerializeJson(dicJson);
            Console.WriteLine(json);
            foreach (var item in SerializerUtil.DeserializeJson<Dictionary<int, string>>(json))
                Console.WriteLine(item.Key + item.Value);
            Console.WriteLine("--------------json end----------");

            // 二进制序列化
            var a = new A(2, "B");
            var aData = SerializerUtil.SerializeBinary(a);
            var aObj1 = SerializerUtil.DeserializeBinary<A>(aData);
            Console.WriteLine(aObj1.Id+ aObj1.Name + aObj1.Birthday);
            Console.WriteLine("--------------binary end----------");

            // xml序列化
            var aXml = SerializerUtil.SerializeXml<A>(a);
            Console.WriteLine(aXml);
            var aObj2 = SerializerUtil.DeserializeXml<A>(aXml);
            Console.WriteLine(aObj2.Id + aObj2.Name+aObj2.Birthday);
            Console.WriteLine("--------------xml end----------");
            // json序列化
            var aJson = SerializerUtil.SerializeJson(a);
            Console.WriteLine(aJson);
            var aObj3 = SerializerUtil.DeserializeJson<A>(aJson);
            Console.WriteLine(aObj3.Id+aObj3.Name + aObj3.Birthday);
            Console.WriteLine("--------------json end----------");
        }

        public static void GetCharArray()
        {
            var chars = StringUtil.GetCharArray(CharsScope.All);
            Console.WriteLine(new string(chars));
        }

        public static void TrimWidthSufix()
        {
            int size = 5;
            var strs = new List<string>() { "123", "123王", "12王3", "12王3a", "12王王", "123王a", "1234王", "12345a" };
            foreach (var str in strs)
            {
                Console.WriteLine(str + "\t" + str.TrimWidthSuffix(size) + "|\t字符串宽度"+StringUtil.GetStringWidth(str));
            }
            var str1 = "SF我。。#$#$";
            Console.WriteLine(StringUtil.Replace(str1, '&', 2,3));
            Console.WriteLine(StringUtil.Trim(str1, "S", "#$"));

        }

        public static void SerializerTest()
        {
            var obj = new List<TestClass>() { new TestClass(), new TestClass()};
            var json = SerializerUtil.SerializeJson(obj);
            Console.WriteLine(json);
            var dobj = SerializerUtil.DeserializeJson<List<TestClass>>(json);
            Console.WriteLine(dobj[0].Id);
        }
        class TestClass
        {
            public int Id { get; set; } = new Random().Next(100, 10000);
            public int DefaultValue { get; set; }
            public string Name { get; set; } = "测试"; 
            public string NullValue { get; set; }
            public DateTime Birthday { get; set; } = new DateTime(2001,2,3,4,5,6);
        }
    }
}
