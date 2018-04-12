using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.AspNet.WebApi.Authentication
{
    public class JwtExpireException:Exception
    {
        public DateTime CurrentDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public JwtExpireException(string message, DateTime current, DateTime expire)
            :base(message)
        {
            CurrentDate = current;
            ExpireDate = expire;
        }
    }
}
