using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Collections;

namespace ConsoleCore.Collections
{
    public class CollectionTest : ITestClass
    {
        public static void ToPage()
        {
            List<string> list = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            foreach (var item in list.ToPage(2, 4))
                Console.WriteLine(item);
        }

        public static void ObjectPool()
        {
            var pool = new ObjectPool<Guid>(Guid.NewGuid);
            for(int i = 0; i < 3; i++)
                Console.WriteLine(pool.Get());
        }

        public static void SerializableDictionary()
        {
            var dic = new SerializableDictionary<int, string>();
            dic.Add(1, "aaa");
            dic.Add(2, "bbb");
            dic.Add(3, "ccc");
            var xml = dic.SerializeXml();
            Console.WriteLine(xml);
            var obj = SerializableDictionary<int, string>.DeserializeXml(xml);
            foreach(var item in obj)
                Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}
