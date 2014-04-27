namespace IPCamera
{
    partial class 报警设置
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(报警设置));
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Nmd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Time = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckb_Ydbf = new System.Windows.Forms.CheckBox();
            this.ckb_mail = new System.Windows.Forms.CheckBox();
            this.ckb_message = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_Url = new System.Windows.Forms.TextBox();
            this.but_Ok = new System.Windows.Forms.Button();
            this.but_Del = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "灵敏度（递减）：";
            // 
            // cbx_Nmd
            // 
            this.cbx_Nmd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_Nmd.FormattingEnabled = true;
            this.cbx_Nmd.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbx_Nmd.Location = new System.Drawing.Point(158, 55);
            this.cbx_Nmd.Name = "cbx_Nmd";
            this.cbx_Nmd.Size = new System.Drawing.Size(121, 22);
            this.cbx_Nmd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(33, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "上传图片间隔：";
            // 
            // tbx_Time
            // 
            this.tbx_Time.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_Time.Location = new System.Drawing.Point(138, 133);
            this.tbx_Time.Name = "tbx_Time";
            this.tbx_Time.Size = new System.Drawing.Size(73, 23);
            this.tbx_Time.TabIndex = 3;
            this.tbx_Time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Time_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(217, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "秒";
            // 
            // ckb_Ydbf
            // 
            this.ckb_Ydbf.AutoSize = true;
            this.ckb_Ydbf.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_Ydbf.Location = new System.Drawing.Point(33, 36);
            this.ckb_Ydbf.Name = "ckb_Ydbf";
            this.ckb_Ydbf.Size = new System.Drawing.Size(95, 20);
            this.ckb_Ydbf.TabIndex = 5;
            this.ckb_Ydbf.Text = "移动布防";
            this.ckb_Ydbf.UseVisualStyleBackColor = true;
            this.ckb_Ydbf.CheckedChanged += new System.EventHandler(this.ckb_Ydbf_CheckedChanged);
            // 
            // ckb_mail
            // 
            this.ckb_mail.AutoSize = true;
            this.ckb_mail.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_mail.Location = new System.Drawing.Point(14, 98);
            this.ckb_mail.Name = "ckb_mail";
            this.ckb_mail.Size = new System.Drawing.Size(129, 20);
            this.ckb_mail.TabIndex = 6;
            this.ckb_mail.Text = "报警邮件通知";
            this.ckb_mail.UseVisualStyleBackColor = true;
            this.ckb_mail.CheckedChanged += new System.EventHandler(this.ckb_mail_CheckedChanged);
            // 
            // ckb_message
            // 
            this.ckb_message.AutoSize = true;
            this.ckb_message.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_message.Location = new System.Drawing.Point(16, 174);
            this.ckb_message.Name = "ckb_message";
            this.ckb_message.Size = new System.Drawing.Size(165, 20);
            this.ckb_message.TabIndex = 7;
            this.ckb_message.Text = "报警http访问通知";
            this.ckb_message.UseVisualStyleBackColor = true;
            this.ckb_message.CheckedChanged += new System.EventHandler(this.ckb_message_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(33, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "报警url：";
            // 
            // txb_Url
            // 
            this.txb_Url.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_Url.Location = new System.Drawing.Point(98, 205);
            this.txb_Url.Name = "txb_Url";
            this.txb_Url.Size = new System.Drawing.Size(181, 23);
            this.txb_Url.TabIndex = 9;
            // 
            // but_Ok
            // 
            this.but_Ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Ok.Location = new System.Drawing.Point(68, 270);
            this.but_Ok.Name = "but_Ok";
            this.but_Ok.Size = new System.Drawing.Size(75, 23);
            this.but_Ok.TabIndex = 10;
            this.but_Ok.Text = "确定";
            this.but_Ok.UseVisualStyleBackColor = true;
            this.but_Ok.Click += new System.EventHandler(this.but_Ok_Click);
            // 
            // but_Del
            // 
            this.but_Del.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Del.Location = new System.Drawing.Point(197, 270);
            this.but_Del.Name = "but_Del";
            this.but_Del.Size = new System.Drawing.Size(75, 23);
            this.but_Del.TabIndex = 11;
            this.but_Del.Text = "取消";
            this.but_Del.UseVisualStyleBackColor = true;
            this.but_Del.Click += new System.EventHandler(this.but_Del_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckb_mail);
            this.groupBox1.Controls.Add(this.txb_Url);
            this.groupBox1.Controls.Add(this.cbx_Nmd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbx_Time);
            this.groupBox1.Controls.Add(this.ckb_message);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(19, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 257);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "报警";
            // 
            // 报警设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 305);
            this.Controls.Add(this.but_Del);
            this.Controls.Add(this.but_Ok);
            this.Controls.Add(this.ckb_Ydbf);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "报警设置";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "移动布防";
            this.Load += new System.EventHandler(this.报警设置_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Nmd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckb_Ydbf;
        private System.Windows.Forms.CheckBox ckb_mail;
        private System.Windows.Forms.CheckBox ckb_message;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_Url;
        private System.Windows.Forms.Button but_Ok;
        private System.Windows.Forms.Button but_Del;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}