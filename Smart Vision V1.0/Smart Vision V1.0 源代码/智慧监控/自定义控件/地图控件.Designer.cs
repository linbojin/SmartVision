namespace IPCamera
{
    partial class 地图控件
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
            this.components = new System.ComponentModel.Container();
            this.SmartVision = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Timers.Timer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.wbGMap = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SmartVision
            // 
            this.SmartVision.Text = "notifyIcon1";
            this.SmartVision.Visible = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000D;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(211, 493);
            this.treeView1.TabIndex = 6;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // wbGMap
            // 
            this.wbGMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbGMap.Location = new System.Drawing.Point(0, 0);
            this.wbGMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGMap.Name = "wbGMap";
            this.wbGMap.ScrollBarsEnabled = false;
            this.wbGMap.Size = new System.Drawing.Size(680, 493);
            this.wbGMap.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 493);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.wbGMap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(211, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 493);
            this.panel2.TabIndex = 8;
            // 
            // 地图控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "地图控件";
            this.Size = new System.Drawing.Size(891, 493);
            this.Load += new System.EventHandler(this.wfGMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.NotifyIcon SmartVision;
        private System.Timers.Timer timer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser wbGMap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;

    }
}
