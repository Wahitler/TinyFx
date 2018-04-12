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
    public partial class ViewListInfoCtl : DBInfoControlBase, IDBInfoRefresh
    {
        public ViewListInfoCtl()
        {
            InitializeComponent();
        }

        private SchemaCollection<ViewSchema> _views;
        public void RefreshData()
        {
            _views = _args.CurrentNode.Data as SchemaCollection<ViewSchema>;
            this.lvViews.BindData(_views);
        }
    }
}
