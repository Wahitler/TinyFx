using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyFx.Data;
using TinyFx.Data.MySqlClient;
using System.IO;
using TinyFx;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppContext.BaseDirectory);
            Console.WriteLine(Environment.CurrentDirectory);
        }
    }
}
