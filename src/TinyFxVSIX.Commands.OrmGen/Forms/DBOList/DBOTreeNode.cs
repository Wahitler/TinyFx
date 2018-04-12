using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    public class DBOTreeNode : TreeNode
    {
        public DBOTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex) { }
        public DBOListType DBOListType { get; set; }
        /// <summary>
        /// 当前Schema对象
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Orm代码生成设置
        /// </summary>
        public OrmSettings OrmSettings => DBNodeInfo.OrmSettings;

        public string DatabaseName => DBNodeInfo.ConnStrInfo.Database;
        public string DataSource => DBNodeInfo.ConnStrInfo.DataSource;

        public DBONodeInfo DBNodeInfo { get; set; }

    }
}
