namespace TinyFxVSIX.Commands.WebApiClientGen.Fonlow
{
    partial class FonlowGenForm
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
            this.cbxClientGenMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCherryPickingMethods = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxCamelCase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContentType = new System.Windows.Forms.TextBox();
            this.lstAssemblyFiles = new System.Windows.Forms.ListBox();
            this.lstControllerName = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddAssemblyFiles = new System.Windows.Forms.Button();
            this.btnRemoveAssemblyFiles = new System.Windows.Forms.Button();
            this.btnRemoveControllerName = new System.Windows.Forms.Button();
            this.btnAddControllerName = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtAssemblyFolder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAssemblyFolder = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.dlgOpenSettings = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cbxClientGenMode
            // 
            this.cbxClientGenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClientGenMode.FormattingEnabled = true;
            this.cbxClientGenMode.Items.AddRange(new object[] {
            "CSharp",
            "JQuery",
            "Angular"});
            this.cbxClientGenMode.Location = new System.Drawing.Point(20, 32);
            this.cbxClientGenMode.Name = "cbxClientGenMode";
            this.cbxClientGenMode.Size = new System.Drawing.Size(175, 20);
            this.cbxClientGenMode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "生成代码类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "生成POCO类的方法";
            // 
            // cbxCherryPickingMethods
            // 
            this.cbxCherryPickingMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCherryPickingMethods.FormattingEnabled = true;
            this.cbxCherryPickingMethods.Items.AddRange(new object[] {
            "All",
            "DataContract",
            "NewtonsoftJson",
            "Serializable",
            "AspNet"});
            this.cbxCherryPickingMethods.Location = new System.Drawing.Point(201, 32);
            this.cbxCherryPickingMethods.Name = "cbxCherryPickingMethods";
            this.cbxCherryPickingMethods.Size = new System.Drawing.Size(175, 20);
            this.cbxCherryPickingMethods.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "大小写";
            // 
            // cbxCamelCase
            // 
            this.cbxCamelCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCamelCase.FormattingEnabled = true;
            this.cbxCamelCase.Items.AddRange(new object[] {
            "CamelCase",
            "PascalCase"});
            this.cbxCamelCase.Location = new System.Drawing.Point(382, 32);
            this.cbxCamelCase.Name = "cbxCamelCase";
            this.cbxCamelCase.Size = new System.Drawing.Size(175, 20);
            this.cbxCamelCase.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "ContentType";
            // 
            // txtContentType
            // 
            this.txtContentType.Location = new System.Drawing.Point(20, 75);
            this.txtContentType.Name = "txtContentType";
            this.txtContentType.Size = new System.Drawing.Size(537, 21);
            this.txtContentType.TabIndex = 7;
            // 
            // lstAssemblyFiles
            // 
            this.lstAssemblyFiles.FormattingEnabled = true;
            this.lstAssemblyFiles.ItemHeight = 12;
            this.lstAssemblyFiles.Location = new System.Drawing.Point(20, 164);
            this.lstAssemblyFiles.Name = "lstAssemblyFiles";
            this.lstAssemblyFiles.Size = new System.Drawing.Size(456, 112);
            this.lstAssemblyFiles.TabIndex = 8;
            this.lstAssemblyFiles.SelectedIndexChanged += new System.EventHandler(this.lstAssemblyFiles_SelectedIndexChanged);
            // 
            // lstControllerName
            // 
            this.lstControllerName.FormattingEnabled = true;
            this.lstControllerName.ItemHeight = 12;
            this.lstControllerName.Location = new System.Drawing.Point(20, 302);
            this.lstControllerName.Name = "lstControllerName";
            this.lstControllerName.Size = new System.Drawing.Size(456, 136);
            this.lstControllerName.TabIndex = 9;
            this.lstControllerName.SelectedIndexChanged += new System.EventHandler(this.lstControllerName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "包含的应用程序集";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "排除的控制器名称";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(272, 504);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(120, 23);
            this.btnGen.TabIndex = 12;
            this.btnGen.Text = "生成代码";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 465);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(456, 21);
            this.txtOutput.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "生成路径";
            // 
            // btnAddAssemblyFiles
            // 
            this.btnAddAssemblyFiles.Location = new System.Drawing.Point(482, 164);
            this.btnAddAssemblyFiles.Name = "btnAddAssemblyFiles";
            this.btnAddAssemblyFiles.Size = new System.Drawing.Size(75, 23);
            this.btnAddAssemblyFiles.TabIndex = 15;
            this.btnAddAssemblyFiles.Text = "添加";
            this.btnAddAssemblyFiles.UseVisualStyleBackColor = true;
            this.btnAddAssemblyFiles.Click += new System.EventHandler(this.btnAddAssemblyFiles_Click);
            // 
            // btnRemoveAssemblyFiles
            // 
            this.btnRemoveAssemblyFiles.Location = new System.Drawing.Point(482, 193);
            this.btnRemoveAssemblyFiles.Name = "btnRemoveAssemblyFiles";
            this.btnRemoveAssemblyFiles.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAssemblyFiles.TabIndex = 16;
            this.btnRemoveAssemblyFiles.Text = "移除";
            this.btnRemoveAssemblyFiles.UseVisualStyleBackColor = true;
            this.btnRemoveAssemblyFiles.Click += new System.EventHandler(this.btnRemoveAssemblyFiles_Click);
            // 
            // btnRemoveControllerName
            // 
            this.btnRemoveControllerName.Location = new System.Drawing.Point(482, 331);
            this.btnRemoveControllerName.Name = "btnRemoveControllerName";
            this.btnRemoveControllerName.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveControllerName.TabIndex = 18;
            this.btnRemoveControllerName.Text = "移除";
            this.btnRemoveControllerName.UseVisualStyleBackColor = true;
            this.btnRemoveControllerName.Click += new System.EventHandler(this.btnRemoveControllerName_Click);
            // 
            // btnAddControllerName
            // 
            this.btnAddControllerName.Location = new System.Drawing.Point(482, 302);
            this.btnAddControllerName.Name = "btnAddControllerName";
            this.btnAddControllerName.Size = new System.Drawing.Size(75, 23);
            this.btnAddControllerName.TabIndex = 17;
            this.btnAddControllerName.Text = "添加";
            this.btnAddControllerName.UseVisualStyleBackColor = true;
            this.btnAddControllerName.Click += new System.EventHandler(this.btnAddControllerName_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(398, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 23);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(20, 504);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(120, 23);
            this.btnSaveSettings.TabIndex = 20;
            this.btnSaveSettings.Text = "保存配置";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtAssemblyFolder
            // 
            this.txtAssemblyFolder.Location = new System.Drawing.Point(20, 118);
            this.txtAssemblyFolder.Name = "txtAssemblyFolder";
            this.txtAssemblyFolder.Size = new System.Drawing.Size(456, 21);
            this.txtAssemblyFolder.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "WebApi的bin所在目录";
            // 
            // btnAssemblyFolder
            // 
            this.btnAssemblyFolder.Location = new System.Drawing.Point(482, 118);
            this.btnAssemblyFolder.Name = "btnAssemblyFolder";
            this.btnAssemblyFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAssemblyFolder.TabIndex = 23;
            this.btnAssemblyFolder.Text = "浏览...";
            this.btnAssemblyFolder.UseVisualStyleBackColor = true;
            this.btnAssemblyFolder.Click += new System.EventHandler(this.btnAssemblyFolder_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(482, 463);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 24;
            this.btnOutput.Text = "浏览...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Location = new System.Drawing.Point(146, 504);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(120, 23);
            this.btnLoadSettings.TabIndex = 25;
            this.btnLoadSettings.Text = "加载配置";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // dlgOpenSettings
            // 
            this.dlgOpenSettings.FileName = "openFileDialog1";
            // 
            // FonlowGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(577, 544);
            this.Controls.Add(this.btnLoadSettings);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnAssemblyFolder);
            this.Controls.Add(this.txtAssemblyFolder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveControllerName);
            this.Controls.Add(this.btnAddControllerName);
            this.Controls.Add(this.btnRemoveAssemblyFiles);
            this.Controls.Add(this.btnAddAssemblyFiles);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstControllerName);
            this.Controls.Add(this.lstAssemblyFiles);
            this.Controls.Add(this.txtContentType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxCamelCase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCherryPickingMethods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxClientGenMode);
            this.Name = "FonlowGenForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FonlowGenForm";
            this.Load += new System.EventHandler(this.FonlowGenForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxClientGenMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCherryPickingMethods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxCamelCase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContentType;
        private System.Windows.Forms.ListBox lstAssemblyFiles;
        private System.Windows.Forms.ListBox lstControllerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddAssemblyFiles;
        private System.Windows.Forms.Button btnRemoveAssemblyFiles;
        private System.Windows.Forms.Button btnRemoveControllerName;
        private System.Windows.Forms.Button btnAddControllerName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtAssemblyFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAssemblyFolder;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.OpenFileDialog dlgOpenSettings;
    }
}