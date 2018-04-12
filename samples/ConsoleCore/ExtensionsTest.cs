using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Extensions.SevenZipSharp;
using System.IO;

namespace ConsoleCore
{
    public class ExtensionsTest: ITestClass
    {
        public static void SevenZipTest()
        {
            SevenZipUtil.ZipDirectory(Path.Combine(AppContext.BaseDirectory, "zipdir"), Path.Combine(AppContext.BaseDirectory, "zipdir.7z"));
            SevenZipUtil.UnzipArchive(Path.Combine(AppContext.BaseDirectory, "zipdir.7z"), Path.Combine(AppContext.BaseDirectory, "zipout"));
        }
    }
}
