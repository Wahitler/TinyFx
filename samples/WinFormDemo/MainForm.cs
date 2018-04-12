using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Windows.EnvDTE;

namespace WinFormDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var list = EnvDTEWraper.GetAllDTE();
            var form = new TinyFxVSIX.Commands.OrmGen.MainForm();
            TinyFxVSIX.Commands.OrmGen.MainForm.CurrentDTE = new EnvDTEWraper(VSProgID.VS2017);
            form.ShowDialog();
        }
    }
}
