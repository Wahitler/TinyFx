namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    partial class DBInfoCtl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabcMain = new System.Windows.Forms.TabControl();
            this.tabORMSetting = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabDBObjects = new System.Windows.Forms.TabControl();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.lvTables = new TinyFxVSIX.Commands.OrmGen.Forms.Controls.TablesListView(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelectNone1 = new System.Windows.Forms.Button();
            this.btnSelectInvert1 = new System.Windows.Forms.Button();
            this.btnSelectAll1 = new System.Windows.Forms.Button();
            this.tabViews = new System.Windows.Forms.TabPage();
            this.lvViews = new TinyFxVSIX.Commands.OrmGen.Forms.Controls.ViewsListView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSelectNone2 = new System.Windows.Forms.Button();
            this.btnSelectInvert2 = new System.Windows.Forms.Button();
            this.btnSelectAll2 = new System.Windows.Forms.Button();
            this.tabProcs = new System.Windows.Forms.TabPage();
            this.lvProcs = new TinyFxVSIX.Commands.OrmGen.Forms.Controls.ProcsListView(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSelectNone3 = new System.Windows.Forms.Button();
            this.btnSelectInvert3 = new System.Windows.Forms.Button();
            this.btnSelectAll3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxClassName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenSelect = new System.Windows.Forms.Button();
            this.btnGenAll = new System.Windows.Forms.Button();
            this.tabDBInfo = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBProvider = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabDbInit = new System.Windows.Forms.TabPage();
            this.tabcMain.SuspendLayout();
            this.tabORMSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDBObjects.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabViews.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabProcs.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDBInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabcMain
            // 
            this.tabcMain.Controls.Add(this.tabORMSetting);
            this.tabcMain.Controls.Add(this.tabDBInfo);
            this.tabcMain.Controls.Add(this.tabDbInit);
            this.tabcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcMain.Location = new System.Drawing.Point(0, 0);
            this.tabcMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabcMain.Name = "tabcMain";
            this.tabcMain.SelectedIndex = 0;
            this.tabcMain.Size = new System.Drawing.Size(525, 480);
            this.tabcMain.TabIndex = 1;
            // 
            // tabORMSetting
            // 
            this.tabORMSetting.Controls.Add(this.groupBox1);
            this.tabORMSetting.Controls.Add(this.groupBox2);
            this.tabORMSetting.Controls.Add(this.panel1);
            this.tabORMSetting.Location = new System.Drawing.Point(4, 22);
            this.tabORMSetting.Margin = new System.Windows.Forms.Padding(2);
            this.tabORMSetting.Name = "tabORMSetting";
            this.tabORMSetting.Padding = new System.Windows.Forms.Padding(2);
            this.tabORMSetting.Size = new System.Drawing.Size(517, 454);
            this.tabORMSetting.TabIndex = 1;
            this.tabORMSetting.Text = "ORM代码生成";
            this.tabORMSetting.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabDBObjects);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 158);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(513, 294);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择生成对象";
            // 
            // tabDBObjects
            // 
            this.tabDBObjects.Controls.Add(this.tabTables);
            this.tabDBObjects.Controls.Add(this.tabViews);
            this.tabDBObjects.Controls.Add(this.tabProcs);
            this.tabDBObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDBObjects.Location = new System.Drawing.Point(2, 16);
            this.tabDBObjects.Margin = new System.Windows.Forms.Padding(2);
            this.tabDBObjects.Name = "tabDBObjects";
            this.tabDBObjects.SelectedIndex = 0;
            this.tabDBObjects.Size = new System.Drawing.Size(509, 276);
            this.tabDBObjects.TabIndex = 0;
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.lvTables);
            this.tabTables.Controls.Add(this.panel2);
            this.tabTables.Location = new System.Drawing.Point(4, 22);
            this.tabTables.Margin = new System.Windows.Forms.Padding(2);
            this.tabTables.Name = "tabTables";
            this.tabTables.Padding = new System.Windows.Forms.Padding(2);
            this.tabTables.Size = new System.Drawing.Size(501, 250);
            this.tabTables.TabIndex = 0;
            this.tabTables.Text = "数据表";
            this.tabTables.UseVisualStyleBackColor = true;
            // 
            // lvTables
            // 
            this.lvTables.AllowColumnReorder = true;
            this.lvTables.CheckBoxes = true;
            this.lvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTables.FullRowSelect = true;
            this.lvTables.GridLines = true;
            this.lvTables.Location = new System.Drawing.Point(2, 44);
            this.lvTables.Margin = new System.Windows.Forms.Padding(2);
            this.lvTables.MultiSelect = false;
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(497, 204);
            this.lvTables.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTables.TabIndex = 2;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelectNone1);
            this.panel2.Controls.Add(this.btnSelectInvert1);
            this.panel2.Controls.Add(this.btnSelectAll1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 42);
            this.panel2.TabIndex = 1;
            // 
            // btnSelectNone1
            // 
            this.btnSelectNone1.Location = new System.Drawing.Point(131, 10);
            this.btnSelectNone1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectNone1.Name = "btnSelectNone1";
            this.btnSelectNone1.Size = new System.Drawing.Size(56, 20);
            this.btnSelectNone1.TabIndex = 17;
            this.btnSelectNone1.Text = "取消";
            this.btnSelectNone1.UseVisualStyleBackColor = true;
            this.btnSelectNone1.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectInvert1
            // 
            this.btnSelectInvert1.Location = new System.Drawing.Point(70, 10);
            this.btnSelectInvert1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectInvert1.Name = "btnSelectInvert1";
            this.btnSelectInvert1.Size = new System.Drawing.Size(56, 20);
            this.btnSelectInvert1.TabIndex = 16;
            this.btnSelectInvert1.Text = "反选";
            this.btnSelectInvert1.UseVisualStyleBackColor = true;
            this.btnSelectInvert1.Click += new System.EventHandler(this.btnSelectInvert_Click);
            // 
            // btnSelectAll1
            // 
            this.btnSelectAll1.Location = new System.Drawing.Point(10, 10);
            this.btnSelectAll1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll1.Name = "btnSelectAll1";
            this.btnSelectAll1.Size = new System.Drawing.Size(56, 20);
            this.btnSelectAll1.TabIndex = 15;
            this.btnSelectAll1.Text = "全选";
            this.btnSelectAll1.UseVisualStyleBackColor = true;
            this.btnSelectAll1.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // tabViews
            // 
            this.tabViews.Controls.Add(this.lvViews);
            this.tabViews.Controls.Add(this.panel3);
            this.tabViews.Location = new System.Drawing.Point(4, 22);
            this.tabViews.Margin = new System.Windows.Forms.Padding(2);
            this.tabViews.Name = "tabViews";
            this.tabViews.Padding = new System.Windows.Forms.Padding(2);
            this.tabViews.Size = new System.Drawing.Size(501, 250);
            this.tabViews.TabIndex = 1;
            this.tabViews.Text = "视图";
            this.tabViews.UseVisualStyleBackColor = true;
            // 
            // lvViews
            // 
            this.lvViews.AllowColumnReorder = true;
            this.lvViews.CheckBoxes = true;
            this.lvViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvViews.FullRowSelect = true;
            this.lvViews.GridLines = true;
            this.lvViews.Location = new System.Drawing.Point(2, 44);
            this.lvViews.Margin = new System.Windows.Forms.Padding(2);
            this.lvViews.MultiSelect = false;
            this.lvViews.Name = "lvViews";
            this.lvViews.Size = new System.Drawing.Size(497, 204);
            this.lvViews.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvViews.TabIndex = 4;
            this.lvViews.UseCompatibleStateImageBehavior = false;
            this.lvViews.View = System.Windows.Forms.View.Details;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSelectNone2);
            this.panel3.Controls.Add(this.btnSelectInvert2);
            this.panel3.Controls.Add(this.btnSelectAll2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(497, 42);
            this.panel3.TabIndex = 3;
            // 
            // btnSelectNone2
            // 
            this.btnSelectNone2.Location = new System.Drawing.Point(131, 10);
            this.btnSelectNone2.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectNone2.Name = "btnSelectNone2";
            this.btnSelectNone2.Size = new System.Drawing.Size(56, 20);
            this.btnSelectNone2.TabIndex = 17;
            this.btnSelectNone2.Text = "取消";
            this.btnSelectNone2.UseVisualStyleBackColor = true;
            this.btnSelectNone2.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectInvert2
            // 
            this.btnSelectInvert2.Location = new System.Drawing.Point(70, 10);
            this.btnSelectInvert2.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectInvert2.Name = "btnSelectInvert2";
            this.btnSelectInvert2.Size = new System.Drawing.Size(56, 20);
            this.btnSelectInvert2.TabIndex = 16;
            this.btnSelectInvert2.Text = "反选";
            this.btnSelectInvert2.UseVisualStyleBackColor = true;
            this.btnSelectInvert2.Click += new System.EventHandler(this.btnSelectInvert_Click);
            // 
            // btnSelectAll2
            // 
            this.btnSelectAll2.Location = new System.Drawing.Point(10, 10);
            this.btnSelectAll2.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll2.Name = "btnSelectAll2";
            this.btnSelectAll2.Size = new System.Drawing.Size(56, 20);
            this.btnSelectAll2.TabIndex = 15;
            this.btnSelectAll2.Text = "全选";
            this.btnSelectAll2.UseVisualStyleBackColor = true;
            this.btnSelectAll2.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // tabProcs
            // 
            this.tabProcs.Controls.Add(this.lvProcs);
            this.tabProcs.Controls.Add(this.panel4);
            this.tabProcs.Location = new System.Drawing.Point(4, 22);
            this.tabProcs.Margin = new System.Windows.Forms.Padding(2);
            this.tabProcs.Name = "tabProcs";
            this.tabProcs.Padding = new System.Windows.Forms.Padding(2);
            this.tabProcs.Size = new System.Drawing.Size(501, 250);
            this.tabProcs.TabIndex = 2;
            this.tabProcs.Text = "存储过程";
            this.tabProcs.UseVisualStyleBackColor = true;
            // 
            // lvProcs
            // 
            this.lvProcs.AllowColumnReorder = true;
            this.lvProcs.CheckBoxes = true;
            this.lvProcs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcs.FullRowSelect = true;
            this.lvProcs.GridLines = true;
            this.lvProcs.Location = new System.Drawing.Point(2, 44);
            this.lvProcs.Margin = new System.Windows.Forms.Padding(2);
            this.lvProcs.MultiSelect = false;
            this.lvProcs.Name = "lvProcs";
            this.lvProcs.Size = new System.Drawing.Size(497, 204);
            this.lvProcs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcs.TabIndex = 6;
            this.lvProcs.UseCompatibleStateImageBehavior = false;
            this.lvProcs.View = System.Windows.Forms.View.Details;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSelectNone3);
            this.panel4.Controls.Add(this.btnSelectInvert3);
            this.panel4.Controls.Add(this.btnSelectAll3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(497, 42);
            this.panel4.TabIndex = 5;
            // 
            // btnSelectNone3
            // 
            this.btnSelectNone3.Location = new System.Drawing.Point(131, 10);
            this.btnSelectNone3.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectNone3.Name = "btnSelectNone3";
            this.btnSelectNone3.Size = new System.Drawing.Size(56, 20);
            this.btnSelectNone3.TabIndex = 17;
            this.btnSelectNone3.Text = "取消";
            this.btnSelectNone3.UseVisualStyleBackColor = true;
            this.btnSelectNone3.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectInvert3
            // 
            this.btnSelectInvert3.Location = new System.Drawing.Point(70, 10);
            this.btnSelectInvert3.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectInvert3.Name = "btnSelectInvert3";
            this.btnSelectInvert3.Size = new System.Drawing.Size(56, 20);
            this.btnSelectInvert3.TabIndex = 16;
            this.btnSelectInvert3.Text = "反选";
            this.btnSelectInvert3.UseVisualStyleBackColor = true;
            this.btnSelectInvert3.Click += new System.EventHandler(this.btnSelectInvert_Click);
            // 
            // btnSelectAll3
            // 
            this.btnSelectAll3.Location = new System.Drawing.Point(10, 10);
            this.btnSelectAll3.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll3.Name = "btnSelectAll3";
            this.btnSelectAll3.Size = new System.Drawing.Size(56, 20);
            this.btnSelectAll3.TabIndex = 15;
            this.btnSelectAll3.Text = "全选";
            this.btnSelectAll3.UseVisualStyleBackColor = true;
            this.btnSelectAll3.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOutputPath);
            this.groupBox2.Controls.Add(this.txtOutputPath);
            this.groupBox2.Controls.Add(this.btnCancle);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.cbxClassName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtNamespace);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(2, 42);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(513, 116);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ORM项目设置";
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutputPath.ForeColor = System.Drawing.Color.Blue;
            this.lblOutputPath.Location = new System.Drawing.Point(134, 66);
            this.lblOutputPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(26, 12);
            this.lblOutputPath.TabIndex = 13;
            this.lblOutputPath.Text = "...";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(17, 82);
            this.txtOutputPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(213, 21);
            this.txtOutputPath.TabIndex = 12;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(302, 80);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(56, 20);
            this.btnCancle.TabIndex = 14;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 67);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "生成文件保存基路径：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(242, 80);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 20);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxClassName
            // 
            this.cbxClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClassName.FormattingEnabled = true;
            this.cbxClassName.Items.AddRange(new object[] {
            "第一个字母大写",
            "第一个字母大写并删除_"});
            this.cbxClassName.Location = new System.Drawing.Point(242, 40);
            this.cbxClassName.Margin = new System.Windows.Forms.Padding(2);
            this.cbxClassName.Name = "cbxClassName";
            this.cbxClassName.Size = new System.Drawing.Size(213, 20);
            this.cbxClassName.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(239, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "类名处理方式";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(17, 40);
            this.txtNamespace.Margin = new System.Windows.Forms.Padding(2);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(213, 21);
            this.txtNamespace.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "命名空间";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenSelect);
            this.panel1.Controls.Add(this.btnGenAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 40);
            this.panel1.TabIndex = 15;
            // 
            // btnGenSelect
            // 
            this.btnGenSelect.Location = new System.Drawing.Point(139, 10);
            this.btnGenSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenSelect.Name = "btnGenSelect";
            this.btnGenSelect.Size = new System.Drawing.Size(112, 20);
            this.btnGenSelect.TabIndex = 16;
            this.btnGenSelect.Text = "生成所选对象";
            this.btnGenSelect.UseVisualStyleBackColor = true;
            this.btnGenSelect.Click += new System.EventHandler(this.btnGenSelect_Click);
            // 
            // btnGenAll
            // 
            this.btnGenAll.Location = new System.Drawing.Point(17, 10);
            this.btnGenAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenAll.Name = "btnGenAll";
            this.btnGenAll.Size = new System.Drawing.Size(112, 20);
            this.btnGenAll.TabIndex = 15;
            this.btnGenAll.Text = "生成所有对象";
            this.btnGenAll.UseVisualStyleBackColor = true;
            this.btnGenAll.Click += new System.EventHandler(this.btnGenAll_Click);
            // 
            // tabDBInfo
            // 
            this.tabDBInfo.Controls.Add(this.splitContainer1);
            this.tabDBInfo.Location = new System.Drawing.Point(4, 22);
            this.tabDBInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tabDBInfo.Name = "tabDBInfo";
            this.tabDBInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tabDBInfo.Size = new System.Drawing.Size(517, 454);
            this.tabDBInfo.TabIndex = 0;
            this.tabDBInfo.Text = "数据库信息";
            this.tabDBInfo.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(513, 450);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtConnStr, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtDBName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtDBProvider, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 8);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(201, 434);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "数据库名称";
            // 
            // txtConnStr
            // 
            this.txtConnStr.BackColor = System.Drawing.Color.White;
            this.txtConnStr.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtConnStr.Location = new System.Drawing.Point(2, 112);
            this.txtConnStr.Margin = new System.Windows.Forms.Padding(2);
            this.txtConnStr.Multiline = true;
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.ReadOnly = true;
            this.txtConnStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnStr.Size = new System.Drawing.Size(197, 148);
            this.txtConnStr.TabIndex = 18;
            this.txtConnStr.Text = "asdfasdfaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaba1234567890sdddddddddddd" +
    "dddddddddddddddddddddddddddddddddddddddddddddddd";
            // 
            // txtDBName
            // 
            this.txtDBName.BackColor = System.Drawing.Color.White;
            this.txtDBName.Location = new System.Drawing.Point(2, 14);
            this.txtDBName.Margin = new System.Windows.Forms.Padding(2);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.ReadOnly = true;
            this.txtDBName.Size = new System.Drawing.Size(197, 21);
            this.txtDBName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 98);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "数据库连接字符串";
            // 
            // txtDBProvider
            // 
            this.txtDBProvider.BackColor = System.Drawing.Color.White;
            this.txtDBProvider.Location = new System.Drawing.Point(2, 63);
            this.txtDBProvider.Margin = new System.Windows.Forms.Padding(2);
            this.txtDBProvider.Name = "txtDBProvider";
            this.txtDBProvider.ReadOnly = true;
            this.txtDBProvider.Size = new System.Drawing.Size(197, 21);
            this.txtDBProvider.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "数据提供程序";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.propertyGrid1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(296, 450);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "属性";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.propertyGrid1.Location = new System.Drawing.Point(2, 16);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(292, 432);
            this.propertyGrid1.TabIndex = 1;
            // 
            // tabDbInit
            // 
            this.tabDbInit.Location = new System.Drawing.Point(4, 22);
            this.tabDbInit.Name = "tabDbInit";
            this.tabDbInit.Padding = new System.Windows.Forms.Padding(3);
            this.tabDbInit.Size = new System.Drawing.Size(517, 454);
            this.tabDbInit.TabIndex = 2;
            this.tabDbInit.Text = "数据库初始化";
            this.tabDbInit.UseVisualStyleBackColor = true;
            // 
            // DBInfoCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabcMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DBInfoCtl";
            this.Size = new System.Drawing.Size(525, 480);
            this.Load += new System.EventHandler(this.DBInfoCtl_Load);
            this.tabcMain.ResumeLayout(false);
            this.tabORMSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabDBObjects.ResumeLayout(false);
            this.tabTables.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabViews.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabProcs.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabDBInfo.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabcMain;
        private System.Windows.Forms.TabPage tabDBInfo;
        private System.Windows.Forms.TabPage tabORMSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxClassName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.TabControl tabDBObjects;
        private System.Windows.Forms.TabPage tabTables;
        private System.Windows.Forms.TabPage tabViews;
        private System.Windows.Forms.TabPage tabProcs;
        private System.Windows.Forms.Button btnGenSelect;
        private System.Windows.Forms.Button btnGenAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelectInvert1;
        private System.Windows.Forms.Button btnSelectAll1;
        private System.Windows.Forms.Button btnSelectNone1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSelectNone2;
        private System.Windows.Forms.Button btnSelectInvert2;
        private System.Windows.Forms.Button btnSelectAll2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSelectNone3;
        private System.Windows.Forms.Button btnSelectInvert3;
        private System.Windows.Forms.Button btnSelectAll3;
        private TablesListView lvTables;
        private ViewsListView lvViews;
        private ProcsListView lvProcs;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDBProvider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabDbInit;
    }
}
