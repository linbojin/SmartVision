using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace IPCamera
{
    partial class 智慧监控
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
        System.ComponentModel.ComponentResourceManager resource = new System.ComponentModel.ComponentResourceManager(typeof(智慧监控));
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(智慧监控));
            this.ts工具栏 = new System.Windows.Forms.ToolStrip();
            this.tsb添加摄像头 = new System.Windows.Forms.ToolStripButton();
            this.tsb配置摄像头 = new System.Windows.Forms.ToolStripButton();
            this.tsb视图模式 = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiVeiw1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVeiw2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVeiw3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVeiw4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVeiw9 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb对讲 = new System.Windows.Forms.ToolStripButton();
            this.tsb录制 = new System.Windows.Forms.ToolStripButton();
            this.tsb监测 = new System.Windows.Forms.ToolStripButton();
            this.tsb异常监测 = new System.Windows.Forms.ToolStripButton();
            this.tsb回放 = new System.Windows.Forms.ToolStripButton();
            this.tsb地图 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi后台运行 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi退出 = new System.Windows.Forms.ToolStripMenuItem();
            this.页面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi视图模式 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi页面1 = new IPCamera.ToolStripRadioButtonMenuItem();
            this.tsmi页面2 = new IPCamera.ToolStripRadioButtonMenuItem();
            this.tsmi页面3 = new IPCamera.ToolStripRadioButtonMenuItem();
            this.tsmi页面4 = new IPCamera.ToolStripRadioButtonMenuItem();
            this.tsmi页面9 = new IPCamera.ToolStripRadioButtonMenuItem();
            this.tsmi电视模式 = new System.Windows.Forms.ToolStripMenuItem();
            this.摄像头ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi增加摄像头 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi配置摄像头 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi移除摄像头 = new System.Windows.Forms.ToolStripMenuItem();
            this.摄像头属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi拍照 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi录制 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi定时抓拍 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi异常监测 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi历史回放 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi电子地图 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi关于我们 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu主菜单 = new System.Windows.Forms.MenuStrip();
            this.报警ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi移动布防 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi邮件报警 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Timers.Timer();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.infoPanel = new System.Windows.Forms.StatusBarPanel();
            this.bpsPanel = new System.Windows.Forms.StatusBarPanel();
            this.fpsPanel = new System.Windows.Forms.StatusBarPanel();
            this.cmenu屏幕 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenu电视模式 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu摄像头信息 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu图像参数 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu打开摄像头 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu关闭摄像头 = new System.Windows.Forms.ToolStripMenuItem();
            this.SmartVision = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.stop = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multiplexer = new IPCamera.Multiplexer();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.ts工具栏.SuspendLayout();
            this.mainMenu主菜单.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpsPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPanel)).BeginInit();
            this.cmenu屏幕.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts工具栏
            // 
            this.ts工具栏.AutoSize = false;
            this.ts工具栏.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts工具栏.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb添加摄像头,
            this.tsb配置摄像头,
            this.tsb视图模式,
            this.tsb对讲,
            this.tsb录制,
            this.tsb监测,
            this.tsb异常监测,
            this.tsb回放,
            this.tsb地图});
            this.ts工具栏.Location = new System.Drawing.Point(0, 35);
            this.ts工具栏.Name = "ts工具栏";
            this.ts工具栏.Size = new System.Drawing.Size(868, 67);
            this.ts工具栏.TabIndex = 1;
            this.ts工具栏.Text = "toolStrip1";
            this.ts工具栏.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ts工具栏_ItemClicked);
            this.ts工具栏.MouseEnter += new System.EventHandler(this.ts工具栏_MouseEnter);
            // 
            // tsb添加摄像头
            // 
            this.tsb添加摄像头.AutoToolTip = false;
            this.tsb添加摄像头.Image = ((System.Drawing.Image)(resources.GetObject("tsb添加摄像头.Image")));
            this.tsb添加摄像头.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb添加摄像头.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb添加摄像头.Name = "tsb添加摄像头";
            this.tsb添加摄像头.Size = new System.Drawing.Size(69, 64);
            this.tsb添加摄像头.Text = "添加摄像头";
            this.tsb添加摄像头.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb添加摄像头.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb配置摄像头
            // 
            this.tsb配置摄像头.AutoToolTip = false;
            this.tsb配置摄像头.Image = ((System.Drawing.Image)(resources.GetObject("tsb配置摄像头.Image")));
            this.tsb配置摄像头.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb配置摄像头.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb配置摄像头.Name = "tsb配置摄像头";
            this.tsb配置摄像头.Size = new System.Drawing.Size(69, 64);
            this.tsb配置摄像头.Text = "配置摄像头";
            this.tsb配置摄像头.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb配置摄像头.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb视图模式
            // 
            this.tsb视图模式.AutoToolTip = false;
            this.tsb视图模式.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVeiw1,
            this.tsmiVeiw2,
            this.tsmiVeiw3,
            this.tsmiVeiw4,
            this.tsmiVeiw9});
            this.tsb视图模式.Image = ((System.Drawing.Image)(resources.GetObject("tsb视图模式.Image")));
            this.tsb视图模式.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb视图模式.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb视图模式.Name = "tsb视图模式";
            this.tsb视图模式.Size = new System.Drawing.Size(69, 64);
            this.tsb视图模式.Text = "视图模式";
            this.tsb视图模式.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb视图模式.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb视图模式.ButtonClick += new System.EventHandler(this.tsb视图模式_ButtonClick);
            this.tsb视图模式.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsb视图模式_DropDownItemClicked);
            // 
            // tsmiVeiw1
            // 
            this.tsmiVeiw1.Image = ((System.Drawing.Image)(resources.GetObject("tsmiVeiw1.Image")));
            this.tsmiVeiw1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiVeiw1.Name = "tsmiVeiw1";
            this.tsmiVeiw1.Size = new System.Drawing.Size(167, 38);
            this.tsmiVeiw1.Text = "1个页面";
            // 
            // tsmiVeiw2
            // 
            this.tsmiVeiw2.Image = ((System.Drawing.Image)(resources.GetObject("tsmiVeiw2.Image")));
            this.tsmiVeiw2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiVeiw2.Name = "tsmiVeiw2";
            this.tsmiVeiw2.Size = new System.Drawing.Size(167, 38);
            this.tsmiVeiw2.Text = "2个页面";
            // 
            // tsmiVeiw3
            // 
            this.tsmiVeiw3.Image = ((System.Drawing.Image)(resources.GetObject("tsmiVeiw3.Image")));
            this.tsmiVeiw3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiVeiw3.Name = "tsmiVeiw3";
            this.tsmiVeiw3.Size = new System.Drawing.Size(167, 38);
            this.tsmiVeiw3.Text = "3个页面";
            // 
            // tsmiVeiw4
            // 
            this.tsmiVeiw4.Image = ((System.Drawing.Image)(resources.GetObject("tsmiVeiw4.Image")));
            this.tsmiVeiw4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiVeiw4.Name = "tsmiVeiw4";
            this.tsmiVeiw4.Size = new System.Drawing.Size(167, 38);
            this.tsmiVeiw4.Text = "4个页面";
            // 
            // tsmiVeiw9
            // 
            this.tsmiVeiw9.Image = ((System.Drawing.Image)(resources.GetObject("tsmiVeiw9.Image")));
            this.tsmiVeiw9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiVeiw9.Name = "tsmiVeiw9";
            this.tsmiVeiw9.Size = new System.Drawing.Size(167, 38);
            this.tsmiVeiw9.Text = "9个页面";
            // 
            // tsb对讲
            // 
            this.tsb对讲.AutoToolTip = false;
            this.tsb对讲.Image = ((System.Drawing.Image)(resources.GetObject("tsb对讲.Image")));
            this.tsb对讲.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb对讲.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb对讲.Name = "tsb对讲";
            this.tsb对讲.Size = new System.Drawing.Size(69, 64);
            this.tsb对讲.Text = "   拍照   ";
            this.tsb对讲.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb对讲.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb录制
            // 
            this.tsb录制.AutoToolTip = false;
            this.tsb录制.Image = ((System.Drawing.Image)(resources.GetObject("tsb录制.Image")));
            this.tsb录制.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb录制.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb录制.Name = "tsb录制";
            this.tsb录制.Size = new System.Drawing.Size(69, 64);
            this.tsb录制.Text = "   录制   ";
            this.tsb录制.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb录制.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb监测
            // 
            this.tsb监测.AutoToolTip = false;
            this.tsb监测.Image = ((System.Drawing.Image)(resources.GetObject("tsb监测.Image")));
            this.tsb监测.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb监测.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb监测.Name = "tsb监测";
            this.tsb监测.Size = new System.Drawing.Size(69, 64);
            this.tsb监测.Text = " 定时抓拍 ";
            this.tsb监测.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb监测.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb异常监测
            // 
            this.tsb异常监测.AutoToolTip = false;
            this.tsb异常监测.Image = global::IPCamera.Properties.Resources.camera5;
            this.tsb异常监测.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb异常监测.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb异常监测.Name = "tsb异常监测";
            this.tsb异常监测.Size = new System.Drawing.Size(69, 64);
            this.tsb异常监测.Text = " 异常监测 ";
            this.tsb异常监测.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb异常监测.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb回放
            // 
            this.tsb回放.AutoToolTip = false;
            this.tsb回放.Image = ((System.Drawing.Image)(resources.GetObject("tsb回放.Image")));
            this.tsb回放.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb回放.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb回放.Name = "tsb回放";
            this.tsb回放.Size = new System.Drawing.Size(69, 64);
            this.tsb回放.Text = " 历史回放 ";
            this.tsb回放.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb回放.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsb地图
            // 
            this.tsb地图.AutoToolTip = false;
            this.tsb地图.Image = ((System.Drawing.Image)(resources.GetObject("tsb地图.Image")));
            this.tsb地图.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb地图.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb地图.Name = "tsb地图";
            this.tsb地图.Size = new System.Drawing.Size(69, 64);
            this.tsb地图.Text = " 电子地图 ";
            this.tsb地图.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsb地图.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb地图.ToolTipText = "地图";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 64);
            this.toolStripButton1.Text = "添加摄像头";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi后台运行,
            this.tsmi退出});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 31);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // tsmi后台运行
            // 
            this.tsmi后台运行.Name = "tsmi后台运行";
            this.tsmi后台运行.Size = new System.Drawing.Size(118, 22);
            this.tsmi后台运行.Text = "后台运行";
            this.tsmi后台运行.Click += new System.EventHandler(this.tsmi后台运行_Click);
            // 
            // tsmi退出
            // 
            this.tsmi退出.Name = "tsmi退出";
            this.tsmi退出.Size = new System.Drawing.Size(118, 22);
            this.tsmi退出.Text = "退出";
            this.tsmi退出.Click += new System.EventHandler(this.tsmi退出_Click);
            // 
            // 页面ToolStripMenuItem
            // 
            this.页面ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi视图模式,
            this.tsmi电视模式});
            this.页面ToolStripMenuItem.Name = "页面ToolStripMenuItem";
            this.页面ToolStripMenuItem.Size = new System.Drawing.Size(41, 31);
            this.页面ToolStripMenuItem.Text = "视图";
            // 
            // tsmi视图模式
            // 
            this.tsmi视图模式.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi页面1,
            this.tsmi页面2,
            this.tsmi页面3,
            this.tsmi页面4,
            this.tsmi页面9});
            this.tsmi视图模式.Name = "tsmi视图模式";
            this.tsmi视图模式.Size = new System.Drawing.Size(118, 22);
            this.tsmi视图模式.Text = "视图模式";
            // 
            // tsmi页面1
            // 
            this.tsmi页面1.Checked = true;
            this.tsmi页面1.CheckOnClick = true;
            this.tsmi页面1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmi页面1.Name = "tsmi页面1";
            this.tsmi页面1.Size = new System.Drawing.Size(112, 22);
            this.tsmi页面1.Text = "1个页面";
            this.tsmi页面1.Click += new System.EventHandler(this.tsmi页面1_Click);
            // 
            // tsmi页面2
            // 
            this.tsmi页面2.CheckOnClick = true;
            this.tsmi页面2.Name = "tsmi页面2";
            this.tsmi页面2.Size = new System.Drawing.Size(112, 22);
            this.tsmi页面2.Text = "2个页面";
            this.tsmi页面2.Click += new System.EventHandler(this.tsmi页面2_Click);
            // 
            // tsmi页面3
            // 
            this.tsmi页面3.CheckOnClick = true;
            this.tsmi页面3.Name = "tsmi页面3";
            this.tsmi页面3.Size = new System.Drawing.Size(112, 22);
            this.tsmi页面3.Text = "3个页面";
            this.tsmi页面3.Click += new System.EventHandler(this.tsmi页面3_Click);
            // 
            // tsmi页面4
            // 
            this.tsmi页面4.CheckOnClick = true;
            this.tsmi页面4.Name = "tsmi页面4";
            this.tsmi页面4.Size = new System.Drawing.Size(112, 22);
            this.tsmi页面4.Text = "4个页面";
            this.tsmi页面4.Click += new System.EventHandler(this.tsmi页面4_Click);
            // 
            // tsmi页面9
            // 
            this.tsmi页面9.CheckOnClick = true;
            this.tsmi页面9.Name = "tsmi页面9";
            this.tsmi页面9.Size = new System.Drawing.Size(112, 22);
            this.tsmi页面9.Text = "9个页面";
            this.tsmi页面9.Click += new System.EventHandler(this.tsmi页面9_Click);
            // 
            // tsmi电视模式
            // 
            this.tsmi电视模式.Name = "tsmi电视模式";
            this.tsmi电视模式.Size = new System.Drawing.Size(118, 22);
            this.tsmi电视模式.Text = "电视模式";
            this.tsmi电视模式.Click += new System.EventHandler(this.tsmi电视模式_Click);
            // 
            // 摄像头ToolStripMenuItem
            // 
            this.摄像头ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi增加摄像头,
            this.tsmi配置摄像头,
            this.tsmi移除摄像头,
            this.摄像头属性ToolStripMenuItem});
            this.摄像头ToolStripMenuItem.Name = "摄像头ToolStripMenuItem";
            this.摄像头ToolStripMenuItem.Size = new System.Drawing.Size(53, 31);
            this.摄像头ToolStripMenuItem.Text = "摄像头";
            // 
            // tsmi增加摄像头
            // 
            this.tsmi增加摄像头.Name = "tsmi增加摄像头";
            this.tsmi增加摄像头.Size = new System.Drawing.Size(130, 22);
            this.tsmi增加摄像头.Text = "增加摄像头";
            this.tsmi增加摄像头.Click += new System.EventHandler(this.tsmi增加摄像头_Click);
            // 
            // tsmi配置摄像头
            // 
            this.tsmi配置摄像头.Name = "tsmi配置摄像头";
            this.tsmi配置摄像头.Size = new System.Drawing.Size(130, 22);
            this.tsmi配置摄像头.Text = "配置摄像头";
            this.tsmi配置摄像头.Click += new System.EventHandler(this.tsmi配置摄像头_Click);
            // 
            // tsmi移除摄像头
            // 
            this.tsmi移除摄像头.Name = "tsmi移除摄像头";
            this.tsmi移除摄像头.Size = new System.Drawing.Size(130, 22);
            this.tsmi移除摄像头.Text = "删除摄像头";
            this.tsmi移除摄像头.Click += new System.EventHandler(this.tsmi移除摄像头_Click);
            // 
            // 摄像头属性ToolStripMenuItem
            // 
            this.摄像头属性ToolStripMenuItem.Name = "摄像头属性ToolStripMenuItem";
            this.摄像头属性ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.摄像头属性ToolStripMenuItem.Text = "摄像头属性";
            this.摄像头属性ToolStripMenuItem.Click += new System.EventHandler(this.tsmi摄像头属性_Click);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi拍照,
            this.tsmi录制,
            this.tsmi定时抓拍,
            this.tsmi异常监测,
            this.tsmi历史回放,
            this.tsmi电子地图});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(41, 31);
            this.选项ToolStripMenuItem.Text = "监控";
            // 
            // tsmi拍照
            // 
            this.tsmi拍照.Name = "tsmi拍照";
            this.tsmi拍照.Size = new System.Drawing.Size(118, 22);
            this.tsmi拍照.Text = "拍照";
            this.tsmi拍照.Click += new System.EventHandler(this.tsmi拍照_Click);
            // 
            // tsmi录制
            // 
            this.tsmi录制.Name = "tsmi录制";
            this.tsmi录制.Size = new System.Drawing.Size(118, 22);
            this.tsmi录制.Text = "录制";
            this.tsmi录制.Click += new System.EventHandler(this.tsmi录制_Click);
            // 
            // tsmi定时抓拍
            // 
            this.tsmi定时抓拍.Name = "tsmi定时抓拍";
            this.tsmi定时抓拍.Size = new System.Drawing.Size(118, 22);
            this.tsmi定时抓拍.Text = "定时抓拍";
            this.tsmi定时抓拍.Click += new System.EventHandler(this.tsmi定时抓拍_Click);
            // 
            // tsmi异常监测
            // 
            this.tsmi异常监测.Name = "tsmi异常监测";
            this.tsmi异常监测.Size = new System.Drawing.Size(118, 22);
            this.tsmi异常监测.Text = "异常监测";
            this.tsmi异常监测.Click += new System.EventHandler(this.tsmi异常监测_Click);
            // 
            // tsmi历史回放
            // 
            this.tsmi历史回放.Name = "tsmi历史回放";
            this.tsmi历史回放.Size = new System.Drawing.Size(118, 22);
            this.tsmi历史回放.Text = "历史回放";
            this.tsmi历史回放.Click += new System.EventHandler(this.tsmi历史回放_Click);
            // 
            // tsmi电子地图
            // 
            this.tsmi电子地图.Name = "tsmi电子地图";
            this.tsmi电子地图.Size = new System.Drawing.Size(118, 22);
            this.tsmi电子地图.Text = "电子地图";
            this.tsmi电子地图.Click += new System.EventHandler(this.tsmi电子地图_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi关于我们});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 31);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // tsmi关于我们
            // 
            this.tsmi关于我们.Name = "tsmi关于我们";
            this.tsmi关于我们.Size = new System.Drawing.Size(118, 22);
            this.tsmi关于我们.Text = "关于我们";
            this.tsmi关于我们.Click += new System.EventHandler(this.tsmi关于我们_Click);
            // 
            // mainMenu主菜单
            // 
            this.mainMenu主菜单.AutoSize = false;
            this.mainMenu主菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.页面ToolStripMenuItem,
            this.摄像头ToolStripMenuItem,
            this.选项ToolStripMenuItem,
            this.报警ToolStripMenuItem1,
            this.帮助ToolStripMenuItem});
            this.mainMenu主菜单.Location = new System.Drawing.Point(0, 0);
            this.mainMenu主菜单.Name = "mainMenu主菜单";
            this.mainMenu主菜单.Size = new System.Drawing.Size(868, 35);
            this.mainMenu主菜单.TabIndex = 0;
            this.mainMenu主菜单.Text = "menuStrip1";
            // 
            // 报警ToolStripMenuItem1
            // 
            this.报警ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi移动布防,
            this.tsmi邮件报警});
            this.报警ToolStripMenuItem1.Name = "报警ToolStripMenuItem1";
            this.报警ToolStripMenuItem1.Size = new System.Drawing.Size(41, 31);
            this.报警ToolStripMenuItem1.Text = "报警";
            // 
            // tsmi移动布防
            // 
            this.tsmi移动布防.Name = "tsmi移动布防";
            this.tsmi移动布防.Size = new System.Drawing.Size(118, 22);
            this.tsmi移动布防.Text = "移动布防";
            this.tsmi移动布防.Click += new System.EventHandler(this.tsmi移动布防_Click);
            // 
            // tsmi邮件报警
            // 
            this.tsmi邮件报警.Name = "tsmi邮件报警";
            this.tsmi邮件报警.Size = new System.Drawing.Size(118, 22);
            this.tsmi邮件报警.Text = "邮件报警";
            this.tsmi邮件报警.Click += new System.EventHandler(this.tsmi邮件报警_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.报警ToolStripMenuItem,
            this.录制ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(41, 31);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 报警ToolStripMenuItem
            // 
            this.报警ToolStripMenuItem.Name = "报警ToolStripMenuItem";
            this.报警ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.报警ToolStripMenuItem.Text = "报警设置";
            // 
            // 录制ToolStripMenuItem
            // 
            this.录制ToolStripMenuItem.Name = "录制ToolStripMenuItem";
            this.录制ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.录制ToolStripMenuItem.Text = "系统设置";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000D;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 538);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.infoPanel,
            this.bpsPanel,
            this.fpsPanel});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(868, 22);
            this.statusBar1.TabIndex = 5;
            this.statusBar1.Text = "statusBar1";
            // 
            // infoPanel
            // 
            this.infoPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Width = 711;
            // 
            // bpsPanel
            // 
            this.bpsPanel.Name = "bpsPanel";
            this.bpsPanel.Width = 70;
            // 
            // fpsPanel
            // 
            this.fpsPanel.Name = "fpsPanel";
            this.fpsPanel.Width = 70;
            // 
            // cmenu屏幕
            // 
            this.cmenu屏幕.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenu电视模式,
            this.cmenu摄像头信息,
            this.cmenu图像参数,
            this.cmenu打开摄像头,
            this.cmenu关闭摄像头});
            this.cmenu屏幕.Name = "cmenu屏幕";
            this.cmenu屏幕.Size = new System.Drawing.Size(143, 114);
            // 
            // cmenu电视模式
            // 
            this.cmenu电视模式.CheckOnClick = true;
            this.cmenu电视模式.Name = "cmenu电视模式";
            this.cmenu电视模式.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.cmenu电视模式.Size = new System.Drawing.Size(142, 22);
            this.cmenu电视模式.Text = "电视模式";
            this.cmenu电视模式.Click += new System.EventHandler(this.cmenu电视模式_Click);
            // 
            // cmenu摄像头信息
            // 
            this.cmenu摄像头信息.Name = "cmenu摄像头信息";
            this.cmenu摄像头信息.Size = new System.Drawing.Size(142, 22);
            this.cmenu摄像头信息.Text = "摄像头信息";
            this.cmenu摄像头信息.Click += new System.EventHandler(this.cmenu摄像头信息_Click);
            // 
            // cmenu图像参数
            // 
            this.cmenu图像参数.Name = "cmenu图像参数";
            this.cmenu图像参数.Size = new System.Drawing.Size(142, 22);
            this.cmenu图像参数.Text = "图像参数设置";
            this.cmenu图像参数.Click += new System.EventHandler(this.cmenu图像参数_Click);
            // 
            // cmenu打开摄像头
            // 
            this.cmenu打开摄像头.Name = "cmenu打开摄像头";
            this.cmenu打开摄像头.Size = new System.Drawing.Size(142, 22);
            this.cmenu打开摄像头.Text = "打开摄像头";
            this.cmenu打开摄像头.Click += new System.EventHandler(this.cmenu打开摄像头_Click);
            // 
            // cmenu关闭摄像头
            // 
            this.cmenu关闭摄像头.Name = "cmenu关闭摄像头";
            this.cmenu关闭摄像头.Size = new System.Drawing.Size(142, 22);
            this.cmenu关闭摄像头.Text = "关闭摄像头";
            this.cmenu关闭摄像头.Click += new System.EventHandler(this.cmenu关闭摄像头_Click);
            // 
            // SmartVision
            // 
            this.SmartVision.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.SmartVision.Icon = ((System.Drawing.Icon)(resources.GetObject("SmartVision.Icon")));
            this.SmartVision.Text = "notifyIcon1";
            this.SmartVision.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // stop
            // 
            this.stop.AutoSize = false;
            this.stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stop.Image = ((System.Drawing.Image)(resources.GetObject("stop.Image")));
            this.stop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(39, 64);
            this.stop.Text = "停止录制";
            this.stop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.multiplexer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 436);
            this.panel1.TabIndex = 6;
            // 
            // multiplexer
            // 
            this.multiplexer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.multiplexer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.multiplexer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiplexer.Location = new System.Drawing.Point(0, 0);
            this.multiplexer.Name = "multiplexer";
            this.multiplexer.Size = new System.Drawing.Size(868, 436);
            this.multiplexer.TabIndex = 4;
            // 
            // timer3
            // 
            this.timer3.Interval = 40;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // 智慧监控
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 560);
            this.ContextMenuStrip = this.cmenu屏幕;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.ts工具栏);
            this.Controls.Add(this.mainMenu主菜单);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu主菜单;
            this.Name = "智慧监控";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Vision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.智慧监控_FormClosing);
            this.Load += new System.EventHandler(this.智慧监控_Load);
            this.ts工具栏.ResumeLayout(false);
            this.ts工具栏.PerformLayout();
            this.mainMenu主菜单.ResumeLayout(false);
            this.mainMenu主菜单.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpsPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPanel)).EndInit();
            this.cmenu屏幕.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts工具栏;
        private System.Windows.Forms.ToolStripButton tsb添加摄像头;
        private System.Windows.Forms.ToolStripButton tsb配置摄像头;
        private System.Windows.Forms.ToolStripSplitButton tsb视图模式;
        private System.Windows.Forms.ToolStripMenuItem tsmiVeiw1;
        private System.Windows.Forms.ToolStripMenuItem tsmiVeiw2;
        private System.Windows.Forms.ToolStripMenuItem tsmiVeiw3;
        private System.Windows.Forms.ToolStripMenuItem tsmiVeiw4;
        private ToolStripButton tsb录制;
        private ToolStripButton tsb监测;
        private ToolStripButton tsb对讲;
        private ToolStripButton tsb回放;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem tsmi后台运行;
        private ToolStripMenuItem tsmi退出;
        private ToolStripMenuItem 页面ToolStripMenuItem;
        private ToolStripMenuItem tsmi视图模式;
        private ToolStripRadioButtonMenuItem tsmi页面1;
        private ToolStripRadioButtonMenuItem tsmi页面2;
        private ToolStripRadioButtonMenuItem tsmi页面3;
        private ToolStripRadioButtonMenuItem tsmi页面4;
        private ToolStripRadioButtonMenuItem tsmi页面9;
        private ToolStripMenuItem tsmi电视模式;
        private ToolStripMenuItem 摄像头ToolStripMenuItem;
        private ToolStripMenuItem tsmi增加摄像头;
        private ToolStripMenuItem tsmi配置摄像头;
        private ToolStripMenuItem tsmi移除摄像头;
        private ToolStripMenuItem 摄像头属性ToolStripMenuItem;
        private ToolStripMenuItem 选项ToolStripMenuItem;
        private ToolStripMenuItem tsmi定时抓拍;
        private ToolStripMenuItem tsmi拍照;
        private ToolStripMenuItem 帮助ToolStripMenuItem;
        private ToolStripMenuItem tsmi关于我们;
        private MenuStrip mainMenu主菜单;
        private System.Timers.Timer timer1;
        private StatusBar statusBar1;
        private StatusBarPanel infoPanel;
        private StatusBarPanel bpsPanel;
        private StatusBarPanel fpsPanel;
        private ContextMenuStrip cmenu屏幕;
        private ToolStripMenuItem cmenu电视模式;
        private ToolStripMenuItem cmenu摄像头信息;
        private ToolStripButton tsb地图;
        private ToolStripMenuItem tsmiVeiw9;
        private ToolStripMenuItem cmenu图像参数;
        private NotifyIcon SmartVision;
        private System.Windows.Forms.Timer timer2;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 报警ToolStripMenuItem;
        private ToolStripMenuItem 录制ToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripButton stop;
        private ToolStripMenuItem 报警ToolStripMenuItem1;
        private ToolStripMenuItem tsmi移动布防;
        private Panel panel1;
        private Multiplexer multiplexer;
        private ToolStripMenuItem tsmi邮件报警;
        private ToolStripMenuItem tsmi历史回放;
        private ToolStripMenuItem cmenu打开摄像头;
        private ToolStripMenuItem cmenu关闭摄像头;
        private ToolStripMenuItem tsmi录制;
        private ToolStripMenuItem tsmi电子地图;
        private System.Windows.Forms.Timer timer3;
        private ToolStripButton tsb异常监测;
        private ToolStripMenuItem tsmi异常监测;

    }
}