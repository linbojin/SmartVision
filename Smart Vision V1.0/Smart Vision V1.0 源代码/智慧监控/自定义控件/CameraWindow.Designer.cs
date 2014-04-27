namespace IPCamera
{
    partial class CameraWindow
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Control_Handle = new IPCamera.云台控制();
            this.SuspendLayout();
            // 
            // Control_Handle
            // 
            this.Control_Handle.AutoSize = true;
            this.Control_Handle.BackColor = System.Drawing.Color.Transparent;
            this.Control_Handle.Location = new System.Drawing.Point(0, 0);
            this.Control_Handle.Name = "Control_Handle";
            this.Control_Handle.Size = new System.Drawing.Size(96, 96);
            this.Control_Handle.TabIndex = 0;
            this.Control_Handle.Visible = false;
            // 
            // CameraWindow
            // 
            this.Controls.Add(this.Control_Handle);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public 云台控制 Control_Handle;
    }
}
