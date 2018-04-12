namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    partial class DBOListWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBOListWindow));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点3", 2, 2);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点4", 2, 2);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("表", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点9", 3, 3);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点10", 3, 3);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("视图", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点12", 4, 4);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点13", 4, 4);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("存储过程", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("TESTDB", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点5", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.自定义数据库连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从TinyFx配置文件获取连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDisconnect = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tsbDisconnect,
            this.tsbRefresh,
            this.tsbSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义数据库连接ToolStripMenuItem,
            this.从TinyFx配置文件获取连接ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 24);
            this.toolStripDropDownButton1.Text = "连接";
            this.toolStripDropDownButton1.ToolTipText = "连接数据库";
            // 
            // 自定义数据库连接ToolStripMenuItem
            // 
            this.自定义数据库连接ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("自定义数据库连接ToolStripMenuItem.Image")));
            this.自定义数据库连接ToolStripMenuItem.Name = "自定义数据库连接ToolStripMenuItem";
            this.自定义数据库连接ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.自定义数据库连接ToolStripMenuItem.Text = "自定义数据库连接...";
            this.自定义数据库连接ToolStripMenuItem.Click += new System.EventHandler(this.自定义数据库连接ToolStripMenuItem_Click);
            // 
            // 从TinyFx配置文件获取连接ToolStripMenuItem
            // 
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("从TinyFx配置文件获取连接ToolStripMenuItem.Image")));
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Name = "从TinyFx配置文件获取连接ToolStripMenuItem";
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Text = "从TinyFx配置文件获取连接...";
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Click += new System.EventHandler(this.从TinyFx配置文件获取连接ToolStripMenuItem_Click);
            // 
            // tsbDisconnect
            // 
            this.tsbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDisconnect.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._00048;
            this.tsbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisconnect.Name = "tsbDisconnect";
            this.tsbDisconnect.Size = new System.Drawing.Size(24, 24);
            this.tsbDisconnect.Text = "断开连接";
            this.tsbDisconnect.Click += new System.EventHandler(this.tsbDisconnect_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(24, 24);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.ToolTipText = "刷新(F5)";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01347;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(24, 24);
            this.tsbSave.Text = "全部保存";
            this.tsbSave.ToolTipText = "全部保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvMain.HideSelection = false;
            this.tvMain.ImageIndex = 0;
            this.tvMain.ImageList = this.imgList;
            this.tvMain.ItemHeight = 20;
            this.tvMain.LineColor = System.Drawing.Color.White;
            this.tvMain.Location = new System.Drawing.Point(0, 27);
            this.tvMain.Margin = new System.Windows.Forms.Padding(2);
            this.tvMain.Name = "tvMain";
            treeNode1.ImageIndex = 2;
            treeNode1.Name = "节点3";
            treeNode1.SelectedImageIndex = 2;
            treeNode1.Text = "节点3";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "节点4";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Text = "节点4";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "节点2";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Text = "表";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "节点9";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "节点9";
            treeNode5.ImageIndex = 3;
            treeNode5.Name = "节点10";
            treeNode5.SelectedImageIndex = 3;
            treeNode5.Text = "节点10";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "节点8";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Text = "视图";
            treeNode7.ImageIndex = 4;
            treeNode7.Name = "节点12";
            treeNode7.SelectedImageIndex = 4;
            treeNode7.Text = "节点12";
            treeNode8.ImageIndex = 4;
            treeNode8.Name = "节点13";
            treeNode8.SelectedImageIndex = 4;
            treeNode8.Text = "节点13";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "节点11";
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Text = "存储过程";
            treeNode10.Name = "节点0";
            treeNode10.Text = "TESTDB";
            treeNode11.Name = "节点6";
            treeNode11.Text = "节点6";
            treeNode12.Name = "节点7";
            treeNode12.Text = "节点7";
            treeNode13.ImageIndex = 1;
            treeNode13.Name = "节点5";
            treeNode13.SelectedImageIndex = 1;
            treeNode13.Text = "节点5";
            treeNode14.Name = "节点1";
            treeNode14.Text = "节点1";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14});
            this.tvMain.SelectedImageIndex = 0;
            this.tvMain.ShowLines = false;
            this.tvMain.Size = new System.Drawing.Size(284, 506);
            this.tvMain.TabIndex = 1;
            this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "db.png");
            this.imgList.Images.SetKeyName(1, "dir.png");
            this.imgList.Images.SetKeyName(2, "table.png");
            this.imgList.Images.SetKeyName(3, "view.png");
            this.imgList.Images.SetKeyName(4, "sp.png");
            // 
            // DBOListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 533);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DBOListWindow";
            this.Text = "数据库对象列表";
            this.Load += new System.EventHandler(this.DBOListWindow_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ImageList imgList;
        public System.Windows.Forms.ToolStripMenuItem 自定义数据库连接ToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton tsbDisconnect;
        public System.Windows.Forms.ToolStripButton tsbRefresh;
        public System.Windows.Forms.ToolStripMenuItem 从TinyFx配置文件获取连接ToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton tsbSave;
    }
}