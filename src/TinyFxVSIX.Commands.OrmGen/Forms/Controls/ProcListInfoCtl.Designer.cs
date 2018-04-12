namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    partial class ProcListInfoCtl
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
            this.lvProcs = new TinyFxVSIX.Commands.OrmGen.Forms.Controls.ProcsListView(this.components);
            this.SuspendLayout();
            // 
            // lvProcs
            // 
            this.lvProcs.AllowColumnReorder = true;
            this.lvProcs.CheckBoxes = true;
            this.lvProcs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcs.FullRowSelect = true;
            this.lvProcs.GridLines = true;
            this.lvProcs.Location = new System.Drawing.Point(0, 0);
            this.lvProcs.MultiSelect = false;
            this.lvProcs.Name = "lvProcs";
            this.lvProcs.Size = new System.Drawing.Size(641, 555);
            this.lvProcs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcs.TabIndex = 0;
            this.lvProcs.UseCompatibleStateImageBehavior = false;
            this.lvProcs.View = System.Windows.Forms.View.Details;
            // 
            // ProcListInfoCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvProcs);
            this.Name = "ProcListInfoCtl";
            this.Size = new System.Drawing.Size(641, 555);
            this.ResumeLayout(false);

        }

        #endregion

        private ProcsListView lvProcs;
    }
}
