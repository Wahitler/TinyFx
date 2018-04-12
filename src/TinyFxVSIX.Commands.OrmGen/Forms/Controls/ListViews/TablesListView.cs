using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class TablesListView : DBOBaseListView
    {
        public TablesListView()
        {
            InitializeComponent();
            Init();
        }

        public TablesListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }
        private void Init()
        {
            var h =this.Columns.Add("表名", -1, HorizontalAlignment.Left);
            this.Columns.Add("描述", 250, HorizontalAlignment.Left);
            this.Columns.Add("主键", -2, HorizontalAlignment.Left);
            this.Columns.Add("外键", -2, HorizontalAlignment.Left);
            this.Columns.Add("唯一键", -2, HorizontalAlignment.Left);
            this.Columns.Add("自增字段", -2, HorizontalAlignment.Left);
            this.Columns.Add("字段数", -2, HorizontalAlignment.Left);
        }
        public void BindData(SchemaCollection<TableSchema> tables)
        {
            this.Items.Clear();
            foreach (var table in tables)
            {
                ListViewItem item = new ListViewItem(table.TableName, 0);
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(table.Comment);
                item.SubItems.Add(GetSubItem(table.HasPrimaryKey.ToString(), 1));
                item.SubItems.Add(GetSubItem(table.HasForeignKey.ToString(), 2));
                item.SubItems.Add(GetSubItem(table.HasUniqueIndex.ToString(), 3));
                item.SubItems.Add(GetSubItem(table.HasAutoIncrementColumn.ToString(), 4));
                item.SubItems.Add(table.Columns.Count.ToString());
                item.Tag = table;
                this.Items.Add(item);
            }
        }
        private ListViewItem.ListViewSubItem GetSubItem(string value, int index = 0)
        {
            ListViewItem.ListViewSubItem ret = new ListViewItem.ListViewSubItem();
            value = value.ToUpper();
            switch (index)
            {
                case 1:
                    if (value == "TRUE")
                    {
                        value = "Y";
                    }
                    else
                    {
                        value = "N";
                        ret.ForeColor = System.Drawing.Color.Red;
                    }
                    break;
                default:
                    if (value == "TRUE")
                    {
                        value = "Y";
                        ret.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        value = "N";
                    }
                    break;
            }
            ret.Text = value;
            return ret;
        }
    }
}
