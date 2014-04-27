namespace IPCamera
{
    partial class 欢迎
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(欢迎));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.welcomePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // welcomePictureBox
            // 
            this.welcomePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.welcomePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.welcomePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.welcomePictureBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.welcomePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("welcomePictureBox.Image")));
            this.welcomePictureBox.Location = new System.Drawing.Point(0, 0);
            this.welcomePictureBox.Name = "welcomePictureBox";
            this.welcomePictureBox.Size = new System.Drawing.Size(660, 377);
            this.welcomePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.welcomePictureBox.TabIndex = 1;
            this.welcomePictureBox.TabStop = false;
            // 
            // 欢迎
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 377);
            this.Controls.Add(this.welcomePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "欢迎";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.welcomePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox welcomePictureBox;
        private System.Windows.Forms.Timer timer1;
    }
}