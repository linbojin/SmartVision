namespace EasyN
{
    partial class EasyNCameraSetupPage
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
            this.lbURL = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPsw = new System.Windows.Forms.Label();
            this.lbStream = new System.Windows.Forms.Label();
            this.lbRate = new System.Windows.Forms.Label();
            this.lbFrame = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.cbStream = new System.Windows.Forms.ComboBox();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.cbFrame = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbURL
            // 
            this.lbURL.Location = new System.Drawing.Point(17, 14);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(43, 16);
            this.lbURL.TabIndex = 0;
            this.lbURL.Text = "URL：";
            this.lbURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbName
            // 
            this.lbName.Location = new System.Drawing.Point(17, 44);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 17);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "用户名：";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPsw
            // 
            this.lbPsw.Location = new System.Drawing.Point(17, 74);
            this.lbPsw.Name = "lbPsw";
            this.lbPsw.Size = new System.Drawing.Size(43, 15);
            this.lbPsw.TabIndex = 2;
            this.lbPsw.Text = "密码：";
            this.lbPsw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStream
            // 
            this.lbStream.Location = new System.Drawing.Point(17, 99);
            this.lbStream.Name = "lbStream";
            this.lbStream.Size = new System.Drawing.Size(59, 23);
            this.lbStream.TabIndex = 4;
            this.lbStream.Text = "源类型：";
            this.lbStream.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRate
            // 
            this.lbRate.Location = new System.Drawing.Point(17, 158);
            this.lbRate.Name = "lbRate";
            this.lbRate.Size = new System.Drawing.Size(55, 23);
            this.lbRate.TabIndex = 5;
            this.lbRate.Text = "流速率：";
            this.lbRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFrame
            // 
            this.lbFrame.Location = new System.Drawing.Point(17, 129);
            this.lbFrame.Name = "lbFrame";
            this.lbFrame.Size = new System.Drawing.Size(41, 23);
            this.lbFrame.TabIndex = 6;
            this.lbFrame.Text = "帧率：";
            this.lbFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(79, 13);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(275, 21);
            this.txtURL.TabIndex = 7;
            this.txtURL.Text = "http://192.168.2.91:91";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(79, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(275, 21);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "admin";
            // 
            // txtPsw
            // 
            this.txtPsw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPsw.Location = new System.Drawing.Point(79, 72);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(275, 21);
            this.txtPsw.TabIndex = 9;
            this.txtPsw.Text = "admin";
            // 
            // cbStream
            // 
            this.cbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStream.FormattingEnabled = true;
            this.cbStream.Items.AddRange(new object[] {
            "Jpeg",
            "MJpeg"});
            this.cbStream.Location = new System.Drawing.Point(79, 101);
            this.cbStream.Name = "cbStream";
            this.cbStream.Size = new System.Drawing.Size(55, 20);
            this.cbStream.TabIndex = 11;
            this.cbStream.SelectedIndexChanged += new System.EventHandler(this.cbStream_SelectedIndexChanged);
            // 
            // cbRate
            // 
            this.cbRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Items.AddRange(new object[] {
            "全速",
            "20 fps ",
            "15 fps ",
            "10 fps ",
            " 5 fps ",
            " 4 fps ",
            " 3 fps ",
            " 2 fps ",
            " 1 fps ",
            " 1 fp/2s ",
            " 1 fp/3s ",
            " 1 fp/4s ",
            " 1 fp/5s"});
            this.cbRate.Location = new System.Drawing.Point(79, 160);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(275, 20);
            this.cbRate.TabIndex = 12;
            // 
            // cbFrame
            // 
            this.cbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrame.FormattingEnabled = true;
            this.cbFrame.Items.AddRange(new object[] {
            "Uncontrolled",
            "10 frames per second",
            "7 frames per second",
            "5 frames per second",
            "3 frames per second",
            "1 frame per second",
            "12 frames per minute",
            "6 frames per minute",
            "4 frames per minute",
            "3 frames per minute",
            "2 frames per minute",
            "1 frame per minute"});
            this.cbFrame.Location = new System.Drawing.Point(79, 131);
            this.cbFrame.Name = "cbFrame";
            this.cbFrame.Size = new System.Drawing.Size(275, 20);
            this.cbFrame.TabIndex = 13;
            // 
            // EasyNCameraSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbFrame);
            this.Controls.Add(this.cbRate);
            this.Controls.Add(this.cbStream);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lbFrame);
            this.Controls.Add(this.lbRate);
            this.Controls.Add(this.lbStream);
            this.Controls.Add(this.lbPsw);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbURL);
            this.Name = "EasyNCameraSetupPage";
            this.Size = new System.Drawing.Size(366, 199);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPsw;
        private System.Windows.Forms.Label lbStream;
        private System.Windows.Forms.Label lbRate;
        private System.Windows.Forms.Label lbFrame;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.ComboBox cbStream;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.ComboBox cbFrame;
    }
}
