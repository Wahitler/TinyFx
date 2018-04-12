using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class ProcsListView : DBOBaseListView
    {
        public ProcsListView()
        {
            InitializeComponent();
            Init();
        }

        public ProcsListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.Columns.Add("存储过程名", -1, HorizontalAlignment.Left);
            this.Columns.Add("描述", 250, HorizontalAlignment.Left);
            this.Columns.Add("参数", -1, HorizontalAlignment.Left);
        }
        public void BindData(SchemaCollection<ProcSchema> procs)
        {
            this.Items.Clear();
            foreach (var proc in procs)
            {
                ListViewItem item = new ListViewItem(proc.ProcName, 2);
                item.SubItems.Add(proc.Comment);
                string paramStr = string.Empty;
                if (proc.Parameters != null)
                {
                    foreach (DbParameterSchema param in proc.Parameters)
                    {
                        paramStr += string.Format("{0}({1}); ", param.ParameterName, param.Direction.ToString());
                    }
                }
                item.Tag = proc;
                item.SubItems.Add(paramStr);
                this.Items.Add(item);
            }
        }
    }
}
