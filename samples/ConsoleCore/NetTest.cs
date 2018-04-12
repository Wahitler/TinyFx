using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Net;

namespace ConsoleCore
{
    public class NetTest:ITestClass
    {
        public static void NetUtilTest()
        {
            Console.WriteLine(NetUtil.GetIpMode("172.16.0.0"));
        }

    }
}
