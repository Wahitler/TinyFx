using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TinyFxActiveX
{
    [Guid("41CCC939-0BDB-4838-93F3-2E6072B81922"), ProgId("TinyFxActiveX.Demo2"), ComVisible(true)]
    public partial class Demo2 : ActiveXControl
    {
        public Demo2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.textBox1.Text);
        }

        public string GetString()
        {
            return "Version: 1.1";
        }
    }
}
