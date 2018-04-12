namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    partial class DBOBaseListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBOBaseListView));
            this.imglMain = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imglMain
            // 
            this.imglMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglMain.ImageStream")));
            this.imglMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imglMain.Images.SetKeyName(0, "table.png");
            this.imglMain.Images.SetKeyName(1, "view.png");
            this.imglMain.Images.SetKeyName(2, "sp.png");
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imglMain;
    }
}
