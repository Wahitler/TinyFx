using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.AutoMapper;

namespace WebDemo.BLL.Demo
{
    /*
     * (ipo) <=> EO <=> Model <=> Dto
     */
    /// <summary>
    /// 需要封装的业务对象
    /// </summary>
    public class DemoModel
    {
    }
    /// <summary>
    /// 返回客户端对象
    /// </summary>
    public class DemoDto : IMapFrom<DemoModel>
    {
        public void MapFrom(DemoModel src)
        {
        }
    }
    /// <summary>
    /// API输入参数对象
    /// </summary>
    public class DemoIpo : IMapTo<DemoModel>
    {
        public void MapTo(DemoModel dest)
        {
        }
    }
}
