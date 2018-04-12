namespace TinyFxVSIX.Commands.WebApiClientGen
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFonlow = new System.Windows.Forms.Button();
            this.btnTinyFx = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFonlow
            // 
            this.btnFonlow.Location = new System.Drawing.Point(32, 37);
            this.btnFonlow.Name = "btnFonlow";
            this.btnFonlow.Size = new System.Drawing.Size(251, 80);
            this.btnFonlow.TabIndex = 0;
            this.btnFonlow.Text = "Fonlow生成WebApi客户端代码";
            this.btnFonlow.UseVisualStyleBackColor = true;
            this.btnFonlow.Click += new System.EventHandler(this.btnFonlow_Click);
            // 
            // btnTinyFx
            // 
            this.btnTinyFx.Location = new System.Drawing.Point(32, 132);
            this.btnTinyFx.Name = "btnTinyFx";
            this.btnTinyFx.Size = new System.Drawing.Size(251, 80);
            this.btnTinyFx.TabIndex = 1;
            this.btnTinyFx.Text = "TinyFx生成WebApi客户端代码";
            this.btnTinyFx.UseVisualStyleBackColor = true;
            this.btnTinyFx.Click += new System.EventHandler(this.btnTinyFx_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 257);
            this.Controls.Add(this.btnTinyFx);
            this.Controls.Add(this.btnFonlow);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebApi客户端代码生成";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFonlow;
        private System.Windows.Forms.Button btnTinyFx;
    }
}

