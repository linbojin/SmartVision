namespace IPCamera
{
    partial class 摄像头描述
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
            this.lb名字 = new System.Windows.Forms.Label();
            this.txt名字 = new System.Windows.Forms.TextBox();
            this.lb描述 = new System.Windows.Forms.Label();
            this.txt描述 = new System.Windows.Forms.TextBox();
            this.lb视频源 = new System.Windows.Forms.Label();
            this.cb视频源 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lb名字
            // 
            this.lb名字.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb名字.Location = new System.Drawing.Point(19, 16);
            this.lb名字.Name = "lb名字";
            this.lb名字.Size = new System.Drawing.Size(63, 23);
            this.lb名字.TabIndex = 0;
            this.lb名字.Text = "名字：";
            // 
            // txt名字
            // 
            this.txt名字.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt名字.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt名字.Location = new System.Drawing.Point(85, 10);
            this.txt名字.Name = "txt名字";
            this.txt名字.Size = new System.Drawing.Size(224, 21);
            this.txt名字.TabIndex = 1;
            this.txt名字.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // lb描述
            // 
            this.lb描述.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb描述.Location = new System.Drawing.Point(17, 39);
            this.lb描述.Name = "lb描述";
            this.lb描述.Size = new System.Drawing.Size(62, 23);
            this.lb描述.TabIndex = 2;
            this.lb描述.Text = "描述：";
            // 
            // txt描述
            // 
            this.txt描述.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt描述.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt描述.Location = new System.Drawing.Point(20, 55);
            this.txt描述.Multiline = true;
            this.txt描述.Name = "txt描述";
            this.txt描述.Size = new System.Drawing.Size(290, 85);
            this.txt描述.TabIndex = 3;
            // 
            // lb视频源
            // 
            this.lb视频源.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb视频源.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb视频源.Location = new System.Drawing.Point(18, 149);
            this.lb视频源.Name = "lb视频源";
            this.lb视频源.Size = new System.Drawing.Size(87, 23);
            this.lb视频源.TabIndex = 4;
            this.lb视频源.Text = "视频源：";
            // 
            // cb视频源
            // 
            this.cb视频源.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb视频源.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb视频源.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb视频源.FormattingEnabled = true;
            this.cb视频源.Location = new System.Drawing.Point(85, 145);
            this.cb视频源.Name = "cb视频源";
            this.cb视频源.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cb视频源.Size = new System.Drawing.Size(224, 20);
            this.cb视频源.TabIndex = 5;
            this.cb视频源.SelectedIndexChanged += new System.EventHandler(this.videoSourceCombo_SelectedIndexChanged);
            // 
            // 摄像头描述
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cb视频源);
            this.Controls.Add(this.lb视频源);
            this.Controls.Add(this.txt描述);
            this.Controls.Add(this.lb描述);
            this.Controls.Add(this.txt名字);
            this.Controls.Add(this.lb名字);
            this.Name = "摄像头描述";
            this.Size = new System.Drawing.Size(329, 178);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb名字;
        private System.Windows.Forms.TextBox txt名字;
        private System.Windows.Forms.Label lb描述;
        private System.Windows.Forms.TextBox txt描述;
        private System.Windows.Forms.Label lb视频源;
        private System.Windows.Forms.ComboBox cb视频源;
    }
}
