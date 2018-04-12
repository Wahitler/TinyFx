namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    partial class DbInitCtl
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
            this.txtCreateSql = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataFile = new System.Windows.Forms.TextBox();
            this.btnSqlBrowser = new System.Windows.Forms.Button();
            this.btnSqlExec = new System.Windows.Forms.Button();
            this.btnDataImport = new System.Windows.Forms.Button();
            this.btnDataBrowser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnSelectInvert = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDataOpen = new System.Windows.Forms.Button();
            this.btnDataExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ofdBrowser = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxExportMode = new System.Windows.Forms.ComboBox();
            this.lvTables = new TinyFxVSIX.Commands.OrmGen.Forms.Controls.TablesListView(this.components);
            this.btnSqlOpen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCreateSql
            // 
            this.txtCreateSql.Location = new System.Drawing.Point(20, 46);
            this.txtCreateSql.Name = "txtCreateSql";
            this.txtCreateSql.ReadOnly = true;
            this.txtCreateSql.Size = new System.Drawing.Size(377, 21);
            this.txtCreateSql.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "创建数据库对象脚本";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "初始数据文件";
            // 
            // txtDataFile
            // 
            this.txtDataFile.Location = new System.Drawing.Point(17, 30);
            this.txtDataFile.Name = "txtDataFile";
            this.txtDataFile.ReadOnly = true;
            this.txtDataFile.Size = new System.Drawing.Size(377, 21);
            this.txtDataFile.TabIndex = 3;
            // 
            // btnSqlBrowser
            // 
            this.btnSqlBrowser.Location = new System.Drawing.Point(403, 46);
            this.btnSqlBrowser.Name = "btnSqlBrowser";
            this.btnSqlBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnSqlBrowser.TabIndex = 4;
            this.btnSqlBrowser.Text = "选择...";
            this.btnSqlBrowser.UseVisualStyleBackColor = true;
            this.btnSqlBrowser.Click += new System.EventHandler(this.btnSqlBrowser_Click);
            // 
            // btnSqlExec
            // 
            this.btnSqlExec.Location = new System.Drawing.Point(565, 46);
            this.btnSqlExec.Name = "btnSqlExec";
            this.btnSqlExec.Size = new System.Drawing.Size(75, 23);
            this.btnSqlExec.TabIndex = 5;
            this.btnSqlExec.Text = "执行SQL";
            this.btnSqlExec.UseVisualStyleBackColor = true;
            this.btnSqlExec.Click += new System.EventHandler(this.btnSqlExec_Click);
            // 
            // btnDataImport
            // 
            this.btnDataImport.Location = new System.Drawing.Point(562, 30);
            this.btnDataImport.Name = "btnDataImport";
            this.btnDataImport.Size = new System.Drawing.Size(75, 23);
            this.btnDataImport.TabIndex = 7;
            this.btnDataImport.Text = "导入数据";
            this.btnDataImport.UseVisualStyleBackColor = true;
            this.btnDataImport.Click += new System.EventHandler(this.btnDataImport_Click);
            // 
            // btnDataBrowser
            // 
            this.btnDataBrowser.Location = new System.Drawing.Point(400, 30);
            this.btnDataBrowser.Name = "btnDataBrowser";
            this.btnDataBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnDataBrowser.TabIndex = 6;
            this.btnDataBrowser.Text = "选择...";
            this.btnDataBrowser.UseVisualStyleBackColor = true;
            this.btnDataBrowser.Click += new System.EventHandler(this.btnDataBrowser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 434);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据初始化";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lvTables);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(762, 344);
            this.panel4.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbxExportMode);
            this.panel5.Controls.Add(this.btnDataExport);
            this.panel5.Controls.Add(this.btnSelectNone);
            this.panel5.Controls.Add(this.btnSelectInvert);
            this.panel5.Controls.Add(this.btnSelectAll);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(762, 42);
            this.panel5.TabIndex = 3;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(131, 10);
            this.btnSelectNone.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(56, 20);
            this.btnSelectNone.TabIndex = 17;
            this.btnSelectNone.Text = "取消";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectInvert
            // 
            this.btnSelectInvert.Location = new System.Drawing.Point(70, 10);
            this.btnSelectInvert.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectInvert.Name = "btnSelectInvert";
            this.btnSelectInvert.Size = new System.Drawing.Size(56, 20);
            this.btnSelectInvert.TabIndex = 16;
            this.btnSelectInvert.Text = "反选";
            this.btnSelectInvert.UseVisualStyleBackColor = true;
            this.btnSelectInvert.Click += new System.EventHandler(this.btnSelectInvert_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(10, 10);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(56, 20);
            this.btnSelectAll.TabIndex = 15;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDataOpen);
            this.panel3.Controls.Add(this.btnDataBrowser);
            this.panel3.Controls.Add(this.txtDataFile);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnDataImport);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(762, 70);
            this.panel3.TabIndex = 8;
            // 
            // btnDataOpen
            // 
            this.btnDataOpen.Location = new System.Drawing.Point(481, 30);
            this.btnDataOpen.Name = "btnDataOpen";
            this.btnDataOpen.Size = new System.Drawing.Size(75, 23);
            this.btnDataOpen.TabIndex = 9;
            this.btnDataOpen.Text = "打开文件";
            this.btnDataOpen.UseVisualStyleBackColor = true;
            this.btnDataOpen.Click += new System.EventHandler(this.btnDataOpen_Click);
            // 
            // btnDataExport
            // 
            this.btnDataExport.Location = new System.Drawing.Point(400, 9);
            this.btnDataExport.Name = "btnDataExport";
            this.btnDataExport.Size = new System.Drawing.Size(75, 23);
            this.btnDataExport.TabIndex = 8;
            this.btnDataExport.Text = "导出数据";
            this.btnDataExport.UseVisualStyleBackColor = true;
            this.btnDataExport.Click += new System.EventHandler(this.btnDataExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSqlOpen);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCreateSql);
            this.groupBox2.Controls.Add(this.btnSqlBrowser);
            this.groupBox2.Controls.Add(this.btnSqlExec);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 118);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "创建数据库对象";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 118);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 434);
            this.panel2.TabIndex = 12;
            // 
            // ofdBrowser
            // 
            this.ofdBrowser.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(329, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "注意：选择的文件将自动添加到当前项目中并覆盖现有文件。";
            // 
            // cbxExportMode
            // 
            this.cbxExportMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExportMode.FormattingEnabled = true;
            this.cbxExportMode.Items.AddRange(new object[] {
            "创建新文件",
            "更新或新增",
            "仅更新",
            "仅新增"});
            this.cbxExportMode.Location = new System.Drawing.Point(273, 11);
            this.cbxExportMode.Name = "cbxExportMode";
            this.cbxExportMode.Size = new System.Drawing.Size(121, 20);
            this.cbxExportMode.TabIndex = 18;
            // 
            // lvTables
            // 
            this.lvTables.AllowColumnReorder = true;
            this.lvTables.CheckBoxes = true;
            this.lvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTables.FullRowSelect = true;
            this.lvTables.GridLines = true;
            this.lvTables.Location = new System.Drawing.Point(0, 42);
            this.lvTables.Margin = new System.Windows.Forms.Padding(2);
            this.lvTables.MultiSelect = false;
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(762, 302);
            this.lvTables.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTables.TabIndex = 4;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            // 
            // btnSqlOpen
            // 
            this.btnSqlOpen.Location = new System.Drawing.Point(484, 46);
            this.btnSqlOpen.Name = "btnSqlOpen";
            this.btnSqlOpen.Size = new System.Drawing.Size(75, 23);
            this.btnSqlOpen.TabIndex = 7;
            this.btnSqlOpen.Text = "打开文件";
            this.btnSqlOpen.UseVisualStyleBackColor = true;
            this.btnSqlOpen.Click += new System.EventHandler(this.btnSqlOpen_Click);
            // 
            // DbInitCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DbInitCtl";
            this.Size = new System.Drawing.Size(768, 552);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCreateSql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataFile;
        private System.Windows.Forms.Button btnSqlBrowser;
        private System.Windows.Forms.Button btnSqlExec;
        private System.Windows.Forms.Button btnDataImport;
        private System.Windows.Forms.Button btnDataBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private TablesListView lvTables;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnSelectInvert;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDataExport;
        private System.Windows.Forms.Button btnDataOpen;
        private System.Windows.Forms.OpenFileDialog ofdBrowser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxExportMode;
        private System.Windows.Forms.Button btnSqlOpen;
    }
}
