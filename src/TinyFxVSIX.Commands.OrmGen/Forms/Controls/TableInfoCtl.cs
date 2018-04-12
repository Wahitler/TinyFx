using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class TableInfoCtl : DBInfoControlBase, IDBInfoRefresh
    {
        public TableInfoCtl()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
        }
    }
}
