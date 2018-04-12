namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    partial class ConnFromConfigForm
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
            this.btnConfigBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDBProvider = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxConnStrName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dlgConfigBrowser = new System.Windows.Forms.OpenFileDialog();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.txtConfigPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfigBrowser
            // 
            this.btnConfigBrowser.Location = new System.Drawing.Point(15, 16);
            this.btnConfigBrowser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfigBrowser.Name = "btnConfigBrowser";
            this.btnConfigBrowser.Size = new System.Drawing.Size(135, 22);
            this.btnConfigBrowser.TabIndex = 3;
            this.btnConfigBrowser.Text = "选择TinyFx配置文件...";
            this.btnConfigBrowser.UseVisualStyleBackColor = true;
            this.btnConfigBrowser.Click += new System.EventHandler(this.btnConfigBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件路径：";
            // 
            // cbxDBProvider
            // 
            this.cbxDBProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDBProvider.FormattingEnabled = true;
            this.cbxDBProvider.Items.AddRange(new object[] {
            "Unknown",
            "SqlClient",
            "OracleClient",
            "OleDb",
            "Odbc",
            "SqlServerCe",
            "Odac",
            "MySqlClient"});
            this.cbxDBProvider.Location = new System.Drawing.Point(154, 124);
            this.cbxDBProvider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxDBProvider.Name = "cbxDBProvider";
            this.cbxDBProvider.Size = new System.Drawing.Size(136, 20);
            this.cbxDBProvider.TabIndex = 17;
            this.cbxDBProvider.SelectedIndexChanged += new System.EventHandler(this.cbxDBProvider_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "数据提供程序";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "数据库连接字符串";
            // 
            // cbxConnStrName
            // 
            this.cbxConnStrName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConnStrName.FormattingEnabled = true;
            this.cbxConnStrName.Location = new System.Drawing.Point(15, 124);
            this.cbxConnStrName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxConnStrName.Name = "cbxConnStrName";
            this.cbxConnStrName.Size = new System.Drawing.Size(136, 20);
            this.cbxConnStrName.TabIndex = 13;
            this.cbxConnStrName.SelectedIndexChanged += new System.EventHandler(this.cbxConnStrName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "数据库连接名";
            // 
            // dlgConfigBrowser
            // 
            this.dlgConfigBrowser.Filter = "TinyFx配置文件|*.config|所有文件|*.*";
            this.dlgConfigBrowser.Title = "选择TinyFx.config文件";
            // 
            // btnConnect
            // 
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConnect.Location = new System.Drawing.Point(15, 230);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 22);
            this.btnConnect.TabIndex = 21;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(94, 230);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtConnStr
            // 
            this.txtConnStr.BackColor = System.Drawing.Color.White;
            this.txtConnStr.Location = new System.Drawing.Point(15, 164);
            this.txtConnStr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConnStr.Multiline = true;
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.ReadOnly = true;
            this.txtConnStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnStr.Size = new System.Drawing.Size(414, 57);
            this.txtConnStr.TabIndex = 23;
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtConfigPath.Location = new System.Drawing.Point(15, 61);
            this.txtConfigPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConfigPath.Multiline = true;
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.ReadOnly = true;
            this.txtConfigPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfigPath.Size = new System.Drawing.Size(414, 42);
            this.txtConfigPath.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(284, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "目前只支持MySQL数据库！";
            // 
            // ConnFromConfigForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(439, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtConfigPath);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbxDBProvider);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxConnStrName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfigBrowser);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnFromConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "从TinyFx.config获取数据库连接";
            this.Load += new System.EventHandler(this.ConnFromConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfigBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDBProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxConnStrName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog dlgConfigBrowser;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.TextBox txtConfigPath;
        private System.Windows.Forms.Label label5;
    }
}