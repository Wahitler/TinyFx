using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.EntLib;
using TinyFx.Text;

namespace ConsoleCore
{
    public class TextTest: ITestClass
    {
        public static void IDCardInfoTest()
        {
            var id = new IDCardInfo("321083197812162119");
            Console.WriteLine(id.Birthday);
            Console.WriteLine(id.Province);
            Console.WriteLine(id.Sex);
        }
        public static void DirtyStringFilterTest()
        {
            var filter = new DirtyStringFilter();
            var str = "你怎么操你怎么";
            Console.WriteLine(filter.HasDirty(str));
            Console.WriteLine(filter.Replace(str, '*'));
        }

        public static void LimitedCharFilterTest()
        {
            var filter = new LimitedCharFilter(true);
            filter.AddLetterChars();
            var input = "ab?cd";
            Console.WriteLine(filter.IsValid(input));
            Console.WriteLine(filter.Replace(input, "-"));
            filter = new LimitedCharFilter(false);//只禁止
            filter.AddLetterChars();
            Console.WriteLine(filter.IsValid(input));
            Console.WriteLine(filter.Replace(input, "-"));
        }
        public static void MoneyUtilTest()
        {
            var amount = 10235.34;
            Console.WriteLine(MoneyUtil.ToCN((decimal)amount));
            Console.WriteLine(MoneyUtil.ToEN(amount.ToString()));
        }
        public static void RandomStringTest()
        {
            Console.WriteLine(RandomString.Next(TinyFx.CharsScope.NumbersAndLetters, 10));
        }
        public static void TimestampIDGeneratorTest()
        {
            var gen = new TimestampIDGenerator();
            for(int i = 0; i < 10;i++)
                Console.WriteLine(gen.Generate());
        }
        public static void PinyinTest()
        {
            Console.WriteLine(TinyFx.EntLib.Pinyin.PinyinUtil.GetPinyin('张').Pinyins[0].Pinyin);
        }
    }
}
