namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    partial class ViewListInfoCtl
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
            this.lvViews = new TinyFxVSIX.Commands.OrmGen.Forms.Controls.ViewsListView(this.components);
            this.SuspendLayout();
            // 
            // lvViews
            // 
            this.lvViews.AllowColumnReorder = true;
            this.lvViews.CheckBoxes = true;
            this.lvViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvViews.FullRowSelect = true;
            this.lvViews.GridLines = true;
            this.lvViews.Location = new System.Drawing.Point(0, 0);
            this.lvViews.MultiSelect = false;
            this.lvViews.Name = "lvViews";
            this.lvViews.Size = new System.Drawing.Size(651, 617);
            this.lvViews.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvViews.TabIndex = 0;
            this.lvViews.UseCompatibleStateImageBehavior = false;
            this.lvViews.View = System.Windows.Forms.View.Details;
            // 
            // ViewListInfoCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvViews);
            this.Name = "ViewListInfoCtl";
            this.Size = new System.Drawing.Size(651, 617);
            this.ResumeLayout(false);

        }

        #endregion

        private ViewsListView lvViews;
    }
}
