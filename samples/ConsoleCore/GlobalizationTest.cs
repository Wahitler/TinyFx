using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.EntLib;
using TinyFx.Globalization;

namespace ConsoleCore
{
    public class GlobalizationTest: ITestClass
    {
        public static void ChinaArea()
        {
            var items = ChinaAreaUtil.GetAll();
            Console.WriteLine(items[0].Name);
            Console.WriteLine(ChinaAreaUtil.GetById(440600).Name);
            Console.WriteLine(ChinaAreaUtil.GetByName("佛山")[0].AreaID);
            Console.WriteLine(ChinaAreaUtil.GetByAlias("黔").MergerName);
            Console.WriteLine(ChinaAreaUtil.GetProvinces()[0].MergerName);
            foreach (var city in ChinaAreaUtil.GetCities(510000))
                Console.WriteLine(city.MergerName);
        }
    }
}
