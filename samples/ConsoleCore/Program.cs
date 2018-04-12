using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using TinyFx;
using TinyFx.Collections;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using TinyFx.Globalization;
using System.Web;
using TinyFx.IO;
using System.Text;
using TinyFx.Configuration;
using TinyFx.Configuration.Data;
using StackExchange.Redis;
using TinyFx.Data;
using TinyFx.Data.MySqlClient;
using MySql.Data.MySqlClient;
using TinyFx.Data.SqlClient;

namespace ConsoleCore
{
    class Program
    {
        static void TestTemp()
        {
            var dbMySql = DbFactory.Create<MySqlDatabase>("server=172.28.9.211;user id=root;pwd=root;database=oscdb;Allow User Variables=True");
            Console.WriteLine(dbMySql.ExecSqlScalar("select Message from sys_log limit 1"));

            var dbSql = DbFactory.Create<SqlDatabase>("Data Source=172.28.9.211;Initial Catalog=ReportServer;Integrated Security=True;");
            Console.WriteLine(dbSql.ExecSqlScalar("select top 1 ItemID from dbo.Catalog"));

        }
        static void Main(string[] args)
        {
            TestTemp();
            var list = new Dictionary<int, Type>();
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(ITestClass).IsAssignableFrom(type) && type != typeof(ITestClass)).ToList();
            types.Sort((a, b) => a.Name.CompareTo(b.Name));
            for (int i = 0; i < types.Count; i++)
                list.Add(i, types[i]);
            while (true)
            {
                Console.Clear();
                ConsoleUtil.WriteLine("====== 【测试类列表】 ======", ConsoleColor.Green);
                foreach (var item in list)
                    Console.WriteLine($"{item.Key} - {item.Value.Name}");
                Console.WriteLine();
                ConsoleUtil.WriteLine("输入类编号：（输入q退出）", ConsoleColor.Yellow);
                var input = Console.ReadLine();
                int index;
                while ((!int.TryParse(input, out index) || !list.ContainsKey(index)) && input != "q")
                {
                    ConsoleUtil.WriteLine("输入错误,重新输入。", ConsoleColor.Red);
                    input = Console.ReadLine();
                }
                if (input == "q") break;
                var type = list[index];
                var methods = new Dictionary<int, MethodInfo>();
                var members = type.GetMethods(BindingFlags.Public | BindingFlags.Static).ToList();
                for (int i = 0; i < members.Count; i++)
                    methods.Add(i, members[i]);
                ConsoleUtil.WriteLine($"====== 【测试类方法列表：{type.Name} 】======", ConsoleColor.Green);
                foreach (var item in methods)
                    Console.WriteLine($"{item.Key} - {item.Value.Name}");

                Console.WriteLine();
                ConsoleUtil.WriteLine("输入方法编号：（输入q退出）", ConsoleColor.Yellow);
                input = Console.ReadLine();
                while ((!int.TryParse(input, out index) || !methods.ContainsKey(index)) && input != "q")
                {
                    ConsoleUtil.WriteLine("输入错误,重新输入。", ConsoleColor.Red);
                    input = Console.ReadLine();
                }
                if (input == "q") break;
                var method = methods[index];
                ConsoleUtil.WriteLine($"------ 【{type.Name}.{method.Name} 调用结果】------", ConsoleColor.Green);
                method.Invoke(null, null);
                ConsoleUtil.WriteLine("------ 回车重新测试 END------", ConsoleColor.Green);
                Console.ReadLine();
            }
        }
    }
    public interface ITestClass { }
}

