namespace IPCamera
{
    partial class 配置窗体模板
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(配置窗体模板));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btn应用 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.btn取消 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(0, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(313, 304);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // btn应用
            // 
            this.btn应用.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn应用.Location = new System.Drawing.Point(22, 322);
            this.btn应用.Name = "btn应用";
            this.btn应用.Size = new System.Drawing.Size(75, 23);
            this.btn应用.TabIndex = 1;
            this.btn应用.Text = "应用";
            this.btn应用.UseVisualStyleBackColor = true;
            this.btn应用.Click += new System.EventHandler(this.btn应用_Click);
            // 
            // btn确定
            // 
            this.btn确定.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn确定.Location = new System.Drawing.Point(116, 322);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(75, 23);
            this.btn确定.TabIndex = 2;
            this.btn确定.Text = "确定";
            this.btn确定.UseVisualStyleBackColor = true;
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // btn取消
            // 
            this.btn取消.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn取消.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn取消.Location = new System.Drawing.Point(211, 322);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 3;
            this.btn取消.Text = "取消";
            this.btn取消.UseVisualStyleBackColor = true;
            // 
            // 配置窗体模板
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn取消;
            this.ClientSize = new System.Drawing.Size(311, 357);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.btn确定);
            this.Controls.Add(this.btn应用);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "配置窗体模板";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置窗体";
            this.Load += new System.EventHandler(this.配置窗体模板_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btn应用;
        private System.Windows.Forms.Button btn确定;
        private System.Windows.Forms.Button btn取消;
    }
}