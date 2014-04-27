namespace IPCamera
{
    partial class 报警邮件
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(报警邮件));
            this.lb_user = new System.Windows.Forms.Label();
            this.lb_pass = new System.Windows.Forms.Label();
            this.lb_sent = new System.Windows.Forms.Label();
            this.lb_recevie1 = new System.Windows.Forms.Label();
            this.lb_receice2 = new System.Windows.Forms.Label();
            this.txb_receiver2 = new System.Windows.Forms.TextBox();
            this.txb_receiver1 = new System.Windows.Forms.TextBox();
            this.tbx_sender = new System.Windows.Forms.TextBox();
            this.txb_pwd = new System.Windows.Forms.TextBox();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.btn_apply = new System.Windows.Forms.Button();
            this.but_delet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_user
            // 
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(46, 66);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(77, 12);
            this.lb_user.TabIndex = 2;
            this.lb_user.Text = "用  户  名：";
            // 
            // lb_pass
            // 
            this.lb_pass.AutoSize = true;
            this.lb_pass.Location = new System.Drawing.Point(46, 102);
            this.lb_pass.Name = "lb_pass";
            this.lb_pass.Size = new System.Drawing.Size(71, 12);
            this.lb_pass.TabIndex = 3;
            this.lb_pass.Text = "密      码:";
            // 
            // lb_sent
            // 
            this.lb_sent.AutoSize = true;
            this.lb_sent.Location = new System.Drawing.Point(46, 32);
            this.lb_sent.Name = "lb_sent";
            this.lb_sent.Size = new System.Drawing.Size(77, 12);
            this.lb_sent.TabIndex = 4;
            this.lb_sent.Text = "发送者邮箱：";
            // 
            // lb_recevie1
            // 
            this.lb_recevie1.AutoSize = true;
            this.lb_recevie1.Location = new System.Drawing.Point(40, 137);
            this.lb_recevie1.Name = "lb_recevie1";
            this.lb_recevie1.Size = new System.Drawing.Size(83, 12);
            this.lb_recevie1.TabIndex = 5;
            this.lb_recevie1.Text = "接收者1邮箱：";
            // 
            // lb_receice2
            // 
            this.lb_receice2.AutoSize = true;
            this.lb_receice2.Location = new System.Drawing.Point(40, 168);
            this.lb_receice2.Name = "lb_receice2";
            this.lb_receice2.Size = new System.Drawing.Size(83, 12);
            this.lb_receice2.TabIndex = 6;
            this.lb_receice2.Text = "接收者2邮箱：";
            // 
            // txb_receiver2
            // 
            this.txb_receiver2.Location = new System.Drawing.Point(139, 165);
            this.txb_receiver2.Name = "txb_receiver2";
            this.txb_receiver2.Size = new System.Drawing.Size(138, 21);
            this.txb_receiver2.TabIndex = 5;
            // 
            // txb_receiver1
            // 
            this.txb_receiver1.Location = new System.Drawing.Point(139, 128);
            this.txb_receiver1.Name = "txb_receiver1";
            this.txb_receiver1.Size = new System.Drawing.Size(138, 21);
            this.txb_receiver1.TabIndex = 4;
            this.txb_receiver1.Text = "Cameravision@126.com";
            // 
            // tbx_sender
            // 
            this.tbx_sender.Location = new System.Drawing.Point(139, 24);
            this.tbx_sender.Name = "tbx_sender";
            this.tbx_sender.Size = new System.Drawing.Size(138, 21);
            this.tbx_sender.TabIndex = 1;
            this.tbx_sender.Text = "1175571461@qq.com";
            // 
            // txb_pwd
            // 
            this.txb_pwd.Location = new System.Drawing.Point(139, 93);
            this.txb_pwd.Name = "txb_pwd";
            this.txb_pwd.PasswordChar = '*';
            this.txb_pwd.Size = new System.Drawing.Size(138, 21);
            this.txb_pwd.TabIndex = 3;
            this.txb_pwd.Text = "ybbiissguoshuili";
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(139, 57);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(138, 21);
            this.tbx_user.TabIndex = 2;
            this.tbx_user.Text = "1175571461@qq.com";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(48, 207);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_apply.TabIndex = 6;
            this.btn_apply.Text = "应用";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // but_delet
            // 
            this.but_delet.Location = new System.Drawing.Point(164, 207);
            this.but_delet.Name = "but_delet";
            this.but_delet.Size = new System.Drawing.Size(75, 23);
            this.but_delet.TabIndex = 7;
            this.but_delet.Text = "取消";
            this.but_delet.UseVisualStyleBackColor = true;
            this.but_delet.Click += new System.EventHandler(this.but_delet_Click);
            // 
            // 报警邮件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 262);
            this.Controls.Add(this.but_delet);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.tbx_user);
            this.Controls.Add(this.txb_pwd);
            this.Controls.Add(this.tbx_sender);
            this.Controls.Add(this.txb_receiver1);
            this.Controls.Add(this.txb_receiver2);
            this.Controls.Add(this.lb_receice2);
            this.Controls.Add(this.lb_recevie1);
            this.Controls.Add(this.lb_sent);
            this.Controls.Add(this.lb_pass);
            this.Controls.Add(this.lb_user);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "报警邮件";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件报警";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.Label lb_pass;
        private System.Windows.Forms.Label lb_sent;
        private System.Windows.Forms.Label lb_recevie1;
        private System.Windows.Forms.Label lb_receice2;
        private System.Windows.Forms.TextBox txb_receiver2;
        private System.Windows.Forms.TextBox txb_receiver1;
        private System.Windows.Forms.TextBox tbx_sender;
        private System.Windows.Forms.TextBox txb_pwd;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button but_delet;
    }
}