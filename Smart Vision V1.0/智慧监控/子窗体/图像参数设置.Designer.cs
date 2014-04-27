namespace IPCamera
{
    partial class 图像参数设置
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(图像参数设置));
            this.lb对比度 = new System.Windows.Forms.Label();
            this.lb分辨率 = new System.Windows.Forms.Label();
            this.lb亮度 = new System.Windows.Forms.Label();
            this.cb分辨率 = new System.Windows.Forms.ComboBox();
            this.lb模式 = new System.Windows.Forms.Label();
            this.tb对比度 = new System.Windows.Forms.TrackBar();
            this.cb模式 = new System.Windows.Forms.ComboBox();
            this.tb亮度 = new System.Windows.Forms.TrackBar();
            this.but_Ok = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb对比度)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb亮度)).BeginInit();
            this.SuspendLayout();
            // 
            // lb对比度
            // 
            this.lb对比度.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb对比度.Location = new System.Drawing.Point(42, 86);
            this.lb对比度.Name = "lb对比度";
            this.lb对比度.Size = new System.Drawing.Size(81, 23);
            this.lb对比度.TabIndex = 10;
            this.lb对比度.Text = "对比度：";
            this.lb对比度.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb分辨率
            // 
            this.lb分辨率.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb分辨率.Location = new System.Drawing.Point(42, 145);
            this.lb分辨率.Name = "lb分辨率";
            this.lb分辨率.Size = new System.Drawing.Size(86, 23);
            this.lb分辨率.TabIndex = 11;
            this.lb分辨率.Text = "分辨率：";
            this.lb分辨率.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb亮度
            // 
            this.lb亮度.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb亮度.Location = new System.Drawing.Point(42, 27);
            this.lb亮度.Name = "lb亮度";
            this.lb亮度.Size = new System.Drawing.Size(81, 23);
            this.lb亮度.TabIndex = 9;
            this.lb亮度.Text = "亮  度：";
            this.lb亮度.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb分辨率
            // 
            this.cb分辨率.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb分辨率.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb分辨率.FormattingEnabled = true;
            this.cb分辨率.Items.AddRange(new object[] {
            "vga",
            "qvga",
            "qqvga"});
            this.cb分辨率.Location = new System.Drawing.Point(129, 141);
            this.cb分辨率.Name = "cb分辨率";
            this.cb分辨率.Size = new System.Drawing.Size(129, 22);
            this.cb分辨率.TabIndex = 5;
            this.cb分辨率.SelectedIndexChanged += new System.EventHandler(this.cb分辨率_SelectedIndexChanged);
            // 
            // lb模式
            // 
            this.lb模式.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb模式.Location = new System.Drawing.Point(41, 192);
            this.lb模式.Name = "lb模式";
            this.lb模式.Size = new System.Drawing.Size(79, 23);
            this.lb模式.TabIndex = 12;
            this.lb模式.Text = "模  式：";
            this.lb模式.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb对比度
            // 
            this.tb对比度.AutoSize = false;
            this.tb对比度.BackColor = System.Drawing.Color.Cyan;
            this.tb对比度.LargeChange = 1;
            this.tb对比度.Location = new System.Drawing.Point(129, 80);
            this.tb对比度.Maximum = 6;
            this.tb对比度.Name = "tb对比度";
            this.tb对比度.Size = new System.Drawing.Size(129, 29);
            this.tb对比度.TabIndex = 6;
            this.tb对比度.Scroll += new System.EventHandler(this.tb对比度_Scroll);
            // 
            // cb模式
            // 
            this.cb模式.BackColor = System.Drawing.SystemColors.Window;
            this.cb模式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb模式.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb模式.FormattingEnabled = true;
            this.cb模式.Items.AddRange(new object[] {
            "60Hz",
            "50Hz",
            "室外"});
            this.cb模式.Location = new System.Drawing.Point(129, 188);
            this.cb模式.Name = "cb模式";
            this.cb模式.Size = new System.Drawing.Size(129, 22);
            this.cb模式.TabIndex = 8;
            this.cb模式.SelectedIndexChanged += new System.EventHandler(this.cb模式_SelectedIndexChanged);
            // 
            // tb亮度
            // 
            this.tb亮度.AutoSize = false;
            this.tb亮度.BackColor = System.Drawing.Color.Cyan;
            this.tb亮度.LargeChange = 1;
            this.tb亮度.Location = new System.Drawing.Point(129, 22);
            this.tb亮度.Maximum = 15;
            this.tb亮度.Name = "tb亮度";
            this.tb亮度.Size = new System.Drawing.Size(129, 28);
            this.tb亮度.TabIndex = 7;
            this.tb亮度.Value = 10;
            this.tb亮度.Scroll += new System.EventHandler(this.tb亮度_Scroll);
            // 
            // but_Ok
            // 
            this.but_Ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Ok.Location = new System.Drawing.Point(67, 240);
            this.but_Ok.Name = "but_Ok";
            this.but_Ok.Size = new System.Drawing.Size(75, 23);
            this.but_Ok.TabIndex = 13;
            this.but_Ok.Text = "确定";
            this.but_Ok.UseVisualStyleBackColor = true;
            this.but_Ok.Click += new System.EventHandler(this.but_Ok_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(179, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // 图像参数设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 290);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.but_Ok);
            this.Controls.Add(this.lb对比度);
            this.Controls.Add(this.tb亮度);
            this.Controls.Add(this.lb分辨率);
            this.Controls.Add(this.cb模式);
            this.Controls.Add(this.lb亮度);
            this.Controls.Add(this.tb对比度);
            this.Controls.Add(this.cb分辨率);
            this.Controls.Add(this.lb模式);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "图像参数设置";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像参数";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.tb对比度)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb亮度)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb对比度;
        private System.Windows.Forms.Label lb分辨率;
        private System.Windows.Forms.Label lb亮度;
        private System.Windows.Forms.ComboBox cb分辨率;
        private System.Windows.Forms.Label lb模式;
        private System.Windows.Forms.TrackBar tb对比度;
        private System.Windows.Forms.ComboBox cb模式;
        private System.Windows.Forms.TrackBar tb亮度;
        private System.Windows.Forms.Button but_Ok;
        private System.Windows.Forms.Button button1;



    }
}

