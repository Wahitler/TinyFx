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
using TinyFx.Data.MySqlClient;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class TableListInfoCtl : DBInfoControlBase, IDBInfoRefresh
    {
        public TableListInfoCtl()
        {
            InitializeComponent();
        }
        private SchemaCollection<TableSchema> _tables;
        public void RefreshData()
        {
            _tables = _args.CurrentNode.Data as SchemaCollection<TableSchema>;
            this.lvTables.BindData(_tables);
        }
    }
}
