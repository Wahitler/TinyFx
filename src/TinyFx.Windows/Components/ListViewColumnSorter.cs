using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TinyFx.Windows.Components
{
    /// <summary>
    /// 用于ListView.ListViewItemSorter方法的的排序比较器
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        private int _columnIndex;
        private bool _isDesc;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ListViewColumnSorter()
        {
            _columnIndex = 0;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="isDesc"></param>
        public ListViewColumnSorter(int columnIndex, bool isDesc)
        {
            _isDesc = isDesc;
            _columnIndex = columnIndex; //当前列,0,1,2...,参数由ListView控件的ColumnClick事件传递   
        }
        /// <summary>
        /// 比较器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int ret = String.Compare(((ListViewItem)x).SubItems[_columnIndex].Text, ((ListViewItem)y).SubItems[_columnIndex].Text);
            return _isDesc ? -ret : ret;
        }
        /// <summary>
        /// 设置ListView的ColumnClick事件
        /// </summary>
        /// <param name="lv"></param>
        public static void SetColumnSorter(ListView lv)
        {
            lv.ColumnClick += Lv_ColumnClick;
        }

        private static void Lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = (ListView)sender;
            var header = lv.Columns[e.Column];
            if (header.Tag == null)
                header.Tag = true;
            bool tab = (bool)header.Tag;
            header.Tag = !tab;
            lv.ListViewItemSorter = new ListViewColumnSorter(e.Column, tab);
            lv.Sort();
        }
    }

}
