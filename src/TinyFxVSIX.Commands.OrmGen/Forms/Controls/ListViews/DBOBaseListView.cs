using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Windows;
using TinyFx.Windows.Components;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class DBOBaseListView : ListView
    {
        public DBOBaseListView()
        {
            InitializeComponent();
            Init();
        }

        public DBOBaseListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.AllowColumnReorder = true;
            this.FullRowSelect = true;
            this.SmallImageList = imglMain;
            this.MultiSelect = false;
            this.CheckBoxes = true;
            this.Sorting = SortOrder.Ascending;
            this.GridLines = true;
            this.View = View.Details;
            this.Scrollable = true;
            ListViewColumnSorter.SetColumnSorter(this);
        }
    }
}
