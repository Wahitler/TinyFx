using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class ProcListInfoCtl : DBInfoControlBase, IDBInfoRefresh
    {
        public ProcListInfoCtl()
        {
            InitializeComponent();
        }

        private SchemaCollection<ProcSchema> _procs;
        public void RefreshData()
        {
            _procs = _args.CurrentNode.Data as SchemaCollection<ProcSchema>;
            this.lvProcs.BindData(_procs);
        }
    }
}
