using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class ViewsListView : DBOBaseListView
    {
        public ViewsListView()
        {
            InitializeComponent();
            Init();
        }

        public ViewsListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.Columns.Add("视图名", -1, HorizontalAlignment.Left);
            this.Columns.Add("描述", 250, HorizontalAlignment.Left);
            this.Columns.Add("SQL查询语句", 300, HorizontalAlignment.Left);
            this.Columns.Add("字段数", -2, HorizontalAlignment.Right);
        }
        public void BindData(SchemaCollection<ViewSchema> views)
        {
            this.Items.Clear();
            foreach (var view in views)
            {
                ListViewItem item = new ListViewItem(view.ViewName, 1);
                //item.UseItemStyleForSubItems = false;
                item.SubItems.Add(view.Comment);
                item.SubItems.Add(view.Definition);
                item.SubItems.Add(view.Columns.Count.ToString());
                item.Tag = view;
                this.Items.Add(item);
            }
        }
    }
}
