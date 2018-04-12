using System;
using System.Collections.Generic;
using System.Text;
using TinyFx;
using TinyFx.IO;

namespace ConsoleCore
{
    public class IOTest: ITestClass
    {
        public static void CompressUtilClass()
        {
            TinyFx.IO.CompressionUtil.SevenZip("IO\\ChinaAreaData.txt", "IO\\ChinaAreaData.7z");
            var data = TinyFx.IO.CompressionUtil.UnSevenZipToBytes(IOUtil.ReadFileToStream("IO\\ChinaAreaData.7z"));
            Console.WriteLine(Encoding.UTF8.GetString(data));

            TinyFx.IO.CompressionUtil.SevenZip("IO\\DirtyStringFilter.dic.20160817.txt", "IO\\DirtyStringFilter.dic.20160817.7z");
            data = TinyFx.IO.CompressionUtil.UnSevenZipToBytes(IOUtil.ReadFileToStream("IO\\DirtyStringFilter.dic.20160817.7z"));
            Console.WriteLine(Encoding.UTF8.GetString(data));

            TinyFx.IO.CompressionUtil.SevenZip("IO\\PinYinDB.txt", "IO\\PinYinDB.7z");
        }

        public static void GZipUtilClass()
        {
            //GZipUtil.Compress(@"D:\TinyFx\develop\samples\ConsoleCore\bin\Debug\netcoreapp2.0\zipdir"
            //    , @"D:\TinyFx\develop\samples\ConsoleCore\bin\Debug\netcoreapp2.0\zipdir.gz");
        }
    }
}
