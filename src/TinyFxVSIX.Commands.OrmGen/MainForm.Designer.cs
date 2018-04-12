namespace TinyFxVSIX.Commands.OrmGen
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义数据库连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从TinyFx配置文件获取连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.全部保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对象资源管理器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对象资源管理器详细信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外部工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssMain
            // 
            this.ssMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssMain.Location = new System.Drawing.Point(0, 542);
            this.ssMain.Name = "ssMain";
            this.ssMain.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.ssMain.Size = new System.Drawing.Size(736, 22);
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.视图VToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(736, 25);
            this.msMain.TabIndex = 2;
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义数据库连接ToolStripMenuItem,
            this.从TinyFx配置文件获取连接ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.刷新连接ToolStripMenuItem,
            this.断开连接ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.全部保存ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.退出ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            this.文件FToolStripMenuItem.DropDownOpening += new System.EventHandler(this.文件FToolStripMenuItem_DropDownOpening);
            // 
            // 自定义数据库连接ToolStripMenuItem
            // 
            this.自定义数据库连接ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources.db1;
            this.自定义数据库连接ToolStripMenuItem.Name = "自定义数据库连接ToolStripMenuItem";
            this.自定义数据库连接ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.自定义数据库连接ToolStripMenuItem.Text = "自定义数据库连接...";
            this.自定义数据库连接ToolStripMenuItem.Click += new System.EventHandler(this.自定义数据库连接ToolStripMenuItem_Click);
            // 
            // 从TinyFx配置文件获取连接ToolStripMenuItem
            // 
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._00037;
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Name = "从TinyFx配置文件获取连接ToolStripMenuItem";
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Text = "从TinyFx配置文件获取连接...";
            this.从TinyFx配置文件获取连接ToolStripMenuItem.Click += new System.EventHandler(this.从TinyFx配置文件获取连接ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // 刷新连接ToolStripMenuItem
            // 
            this.刷新连接ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01964;
            this.刷新连接ToolStripMenuItem.Name = "刷新连接ToolStripMenuItem";
            this.刷新连接ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.刷新连接ToolStripMenuItem.Text = "刷新连接";
            this.刷新连接ToolStripMenuItem.Click += new System.EventHandler(this.刷新连接ToolStripMenuItem_Click);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._00048;
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 6);
            // 
            // 全部保存ToolStripMenuItem
            // 
            this.全部保存ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01347;
            this.全部保存ToolStripMenuItem.Name = "全部保存ToolStripMenuItem";
            this.全部保存ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.全部保存ToolStripMenuItem.Text = "全部保存";
            this.全部保存ToolStripMenuItem.Click += new System.EventHandler(this.全部保存ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources.exit;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.退出ToolStripMenuItem.Text = "退出(&X)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 视图VToolStripMenuItem
            // 
            this.视图VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.对象资源管理器ToolStripMenuItem,
            this.对象资源管理器详细信息ToolStripMenuItem});
            this.视图VToolStripMenuItem.Name = "视图VToolStripMenuItem";
            this.视图VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.视图VToolStripMenuItem.Text = "视图(&V)";
            // 
            // 对象资源管理器ToolStripMenuItem
            // 
            this.对象资源管理器ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01912;
            this.对象资源管理器ToolStripMenuItem.Name = "对象资源管理器ToolStripMenuItem";
            this.对象资源管理器ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.对象资源管理器ToolStripMenuItem.Text = "对象资源管理器";
            this.对象资源管理器ToolStripMenuItem.Click += new System.EventHandler(this.对象资源管理器ToolStripMenuItem_Click);
            // 
            // 对象资源管理器详细信息ToolStripMenuItem
            // 
            this.对象资源管理器详细信息ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01936;
            this.对象资源管理器详细信息ToolStripMenuItem.Name = "对象资源管理器详细信息ToolStripMenuItem";
            this.对象资源管理器详细信息ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.对象资源管理器详细信息ToolStripMenuItem.Text = "对象资源管理器详细信息";
            this.对象资源管理器详细信息ToolStripMenuItem.Click += new System.EventHandler(this.对象资源管理器详细信息ToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.外部工具ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.选项ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 外部工具ToolStripMenuItem
            // 
            this.外部工具ToolStripMenuItem.Name = "外部工具ToolStripMenuItem";
            this.外部工具ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.外部工具ToolStripMenuItem.Text = "外部工具";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(121, 6);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._00746;
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.选项ToolStripMenuItem.Text = "选项(&O)";
            this.选项ToolStripMenuItem.Click += new System.EventHandler(this.选项ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01335;
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.关于ToolStripMenuItem.Text = "关于(&A)...";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.toolStripButton5});
            this.tsMain.Location = new System.Drawing.Point(0, 25);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(736, 31);
            this.tsMain.TabIndex = 6;
            this.tsMain.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01912;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "对象资源管理器";
            this.toolStripButton1.Click += new System.EventHandler(this.对象资源管理器ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01936;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "对象资源管理器详细信息";
            this.toolStripButton2.Click += new System.EventHandler(this.对象资源管理器详细信息ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._00746;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "选项";
            this.toolStripButton3.Click += new System.EventHandler(this.选项ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources._01335;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::TinyFxVSIX.Commands.OrmGen.Properties.Resources.exit;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.Location = new System.Drawing.Point(69, 99);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(597, 398);
            this.dockPanel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 564);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(679, 568);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ORM代码生成";
            this.Load += new System.EventHandler(this.OrmGenForm_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 自定义数据库连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从TinyFx配置文件获取连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 全部保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对象资源管理器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对象资源管理器详细信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外部工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}