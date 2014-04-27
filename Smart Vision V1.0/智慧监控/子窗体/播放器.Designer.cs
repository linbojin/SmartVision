namespace IPCamera
{
    partial class 播放器
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(播放器));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.TreeViewFile = new System.Windows.Forms.TreeView();
            this.but_last = new System.Windows.Forms.Button();
            this.but_next = new System.Windows.Forms.Button();
            this.but_top = new System.Windows.Forms.Button();
            this.but_first = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.but_open = new System.Windows.Forms.Button();
            this.but_new = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(254, -4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(583, 562);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // TreeViewFile
            // 
            this.TreeViewFile.Location = new System.Drawing.Point(1, -1);
            this.TreeViewFile.Name = "TreeViewFile";
            this.TreeViewFile.Size = new System.Drawing.Size(252, 526);
            this.TreeViewFile.TabIndex = 1;
            this.TreeViewFile.DoubleClick += new System.EventHandler(this.TreeViewFile_DoubleClick);
            // 
            // but_last
            // 
            this.but_last.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_last.Location = new System.Drawing.Point(706, 531);
            this.but_last.Name = "but_last";
            this.but_last.Size = new System.Drawing.Size(75, 23);
            this.but_last.TabIndex = 12;
            this.but_last.Text = "最后一张";
            this.but_last.UseVisualStyleBackColor = true;
            this.but_last.Click += new System.EventHandler(this.but_last_Click);
            // 
            // but_next
            // 
            this.but_next.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_next.Location = new System.Drawing.Point(565, 531);
            this.but_next.Name = "but_next";
            this.but_next.Size = new System.Drawing.Size(75, 23);
            this.but_next.TabIndex = 11;
            this.but_next.Text = "下一张";
            this.but_next.UseVisualStyleBackColor = true;
            this.but_next.Click += new System.EventHandler(this.but_next_Click);
            // 
            // but_top
            // 
            this.but_top.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_top.Location = new System.Drawing.Point(428, 531);
            this.but_top.Name = "but_top";
            this.but_top.Size = new System.Drawing.Size(75, 23);
            this.but_top.TabIndex = 10;
            this.but_top.Text = "上一张";
            this.but_top.UseVisualStyleBackColor = true;
            this.but_top.Click += new System.EventHandler(this.but_top_Click);
            // 
            // but_first
            // 
            this.but_first.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_first.Location = new System.Drawing.Point(297, 531);
            this.but_first.Name = "but_first";
            this.but_first.Size = new System.Drawing.Size(75, 23);
            this.but_first.TabIndex = 9;
            this.but_first.Text = "第一张";
            this.but_first.UseVisualStyleBackColor = true;
            this.but_first.Click += new System.EventHandler(this.but_first_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(254, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 526);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(254, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 562);
            this.panel1.TabIndex = 13;
            // 
            // but_open
            // 
            this.but_open.Location = new System.Drawing.Point(24, 531);
            this.but_open.Name = "but_open";
            this.but_open.Size = new System.Drawing.Size(75, 23);
            this.but_open.TabIndex = 14;
            this.but_open.Text = "打开文件夹";
            this.but_open.UseVisualStyleBackColor = true;
            this.but_open.Click += new System.EventHandler(this.button1_Click);
            // 
            // but_new
            // 
            this.but_new.Location = new System.Drawing.Point(141, 531);
            this.but_new.Name = "but_new";
            this.but_new.Size = new System.Drawing.Size(75, 23);
            this.but_new.TabIndex = 15;
            this.but_new.Text = "刷新";
            this.but_new.UseVisualStyleBackColor = true;
            this.but_new.Click += new System.EventHandler(this.but_new_Click);
            // 
            // 播放器
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 560);
            this.Controls.Add(this.but_new);
            this.Controls.Add(this.but_open);
            this.Controls.Add(this.but_last);
            this.Controls.Add(this.but_next);
            this.Controls.Add(this.but_top);
            this.Controls.Add(this.but_first);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TreeViewFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(845, 594);
            this.MinimumSize = new System.Drawing.Size(845, 594);
            this.Name = "播放器";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放器";
            this.Load += new System.EventHandler(this.播放器_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TreeView TreeViewFile;
        private System.Windows.Forms.Button but_last;
        private System.Windows.Forms.Button but_next;
        private System.Windows.Forms.Button but_top;
        private System.Windows.Forms.Button but_first;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button but_open;
        private System.Windows.Forms.Button but_new;
    }
}