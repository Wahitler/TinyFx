using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.BLL.Demo
{
    /// <summary>
    /// 业务服务对象，API层调用
    /// </summary>
    public class DemoSvc
    {
        public DemoDto GetDto(DemoModel model)
        {
            return AutoMapper.Mapper.Map<DemoDto>(model);
        }
    }
}
