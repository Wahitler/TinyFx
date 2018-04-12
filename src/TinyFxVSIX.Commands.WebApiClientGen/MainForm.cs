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

namespace TinyFxVSIX.Commands.WebApiClientGen
{
    public partial class MainForm : Form
    {
        #region Constructors
        public static string[] InputArgs { get; set; }
        public static EnvDTEWraper CurrentDTE { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(EnvDTEWraper dte) : this()
        {
            CurrentDTE = dte;
        }
        #endregion

        private void btnFonlow_Click(object sender, EventArgs e)
        {
            var form = new Fonlow.FonlowGenForm();
            form.ShowDialog();
        }

        private void btnTinyFx_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
