namespace IPCamera
{
    partial class 摄像头信息
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
            this.lb名字 = new System.Windows.Forms.Label();
            this.lb提供商 = new System.Windows.Forms.Label();
            this.lbtxt介绍 = new System.Windows.Forms.Label();
            this.lb介绍 = new System.Windows.Forms.Label();
            this.lbtxt提供商 = new System.Windows.Forms.Label();
            this.lbtxt名字 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb名字
            // 
            this.lb名字.AutoSize = true;
            this.lb名字.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb名字.Location = new System.Drawing.Point(29, 20);
            this.lb名字.Name = "lb名字";
            this.lb名字.Size = new System.Drawing.Size(41, 12);
            this.lb名字.TabIndex = 0;
            this.lb名字.Text = "名称：";
            // 
            // lb提供商
            // 
            this.lb提供商.AutoSize = true;
            this.lb提供商.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb提供商.Location = new System.Drawing.Point(29, 277);
            this.lb提供商.Name = "lb提供商";
            this.lb提供商.Size = new System.Drawing.Size(53, 12);
            this.lb提供商.TabIndex = 4;
            this.lb提供商.Text = "提供商：";
            // 
            // lbtxt介绍
            // 
            this.lbtxt介绍.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbtxt介绍.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbtxt介绍.Location = new System.Drawing.Point(31, 81);
            this.lbtxt介绍.Name = "lbtxt介绍";
            this.lbtxt介绍.Size = new System.Drawing.Size(275, 178);
            this.lbtxt介绍.TabIndex = 6;
            // 
            // lb介绍
            // 
            this.lb介绍.AutoSize = true;
            this.lb介绍.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb介绍.Location = new System.Drawing.Point(29, 53);
            this.lb介绍.Name = "lb介绍";
            this.lb介绍.Size = new System.Drawing.Size(41, 12);
            this.lb介绍.TabIndex = 2;
            this.lb介绍.Text = "简介：";
            // 
            // lbtxt提供商
            // 
            this.lbtxt提供商.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbtxt提供商.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbtxt提供商.Location = new System.Drawing.Point(91, 272);
            this.lbtxt提供商.Name = "lbtxt提供商";
            this.lbtxt提供商.Size = new System.Drawing.Size(215, 18);
            this.lbtxt提供商.TabIndex = 7;
            this.lbtxt提供商.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtxt名字
            // 
            this.lbtxt名字.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbtxt名字.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbtxt名字.Location = new System.Drawing.Point(91, 17);
            this.lbtxt名字.Name = "lbtxt名字";
            this.lbtxt名字.Size = new System.Drawing.Size(215, 18);
            this.lbtxt名字.TabIndex = 5;
            this.lbtxt名字.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 摄像头信息
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(339, 306);
            this.Controls.Add(this.lbtxt名字);
            this.Controls.Add(this.lb名字);
            this.Controls.Add(this.lbtxt提供商);
            this.Controls.Add(this.lb介绍);
            this.Controls.Add(this.lbtxt介绍);
            this.Controls.Add(this.lb提供商);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "摄像头信息";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "摄像头信息";
            this.Load += new System.EventHandler(this.摄像头信息_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb名字;
        private System.Windows.Forms.Label lb提供商;
        private System.Windows.Forms.Label lbtxt介绍;
        private System.Windows.Forms.Label lb介绍;
        private System.Windows.Forms.Label lbtxt提供商;
        private System.Windows.Forms.Label lbtxt名字;
    }
}