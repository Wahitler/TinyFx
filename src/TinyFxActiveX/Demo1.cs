using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TinyFxActiveX
{
    [Guid("7135A5E0-CE78-4A0B-82F9-0966FEF5016A"), ProgId("TinyFxActiveX.Demo1"), ComVisible(true)]
    public class Demo1: ActiveXBase
    {
        public string GetMacAddress()
        {
            var ret = string.Empty;
            var ipEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in ipEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ret = ip.ToString();
                    break;
                }
            }
            return ret;
        }
        public void ShowForm()
        {
            var frm = new Form1();
            frm.ShowDialog();
        }
    }
}
