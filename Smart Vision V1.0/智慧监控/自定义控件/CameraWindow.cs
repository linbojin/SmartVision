using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using AForge.Vision.Motion;
using AForge.Imaging;

namespace IPCamera
{
    /// <summary>
    /// CameraWindow 视频窗体自定义控件
    /// </summary>
    public partial class CameraWindow : Control
    {
        private Camera camera = null;          //视频窗中的摄像头
        private bool autosize = false;
        private bool needSizeUpdate = false;
        private bool firstFrame = true;

        // 自适应窗体
        [DefaultValue(false)]
        public override bool AutoSize
        {
            get { return autosize; }
            set
            {
                autosize = value;
                UpdatePosition();
            }
        }

        // 摄像头属性
        [Browsable(false)]
        public Camera Camera
        {
            get { return camera; }
            set
            {
                // 线程加锁
                Monitor.Enter(this);

                // 删除事件
                if (camera != null)
                {
                    camera.NewFrame -= new EventHandler(camera_NewFrame);
                }

                camera = value;
                needSizeUpdate = true;
                firstFrame = true;

                // 注册事件
                if (camera != null)
                {
                    camera.NewFrame += new EventHandler(camera_NewFrame);    //摄像头有新帧便激发camera_NewFrame，重绘视频窗
                }

                // 解锁
                Monitor.Exit(this);
            }
        }

        /// <summary>
        /// 方法部分
        /// </summary>
        // 构造函数
        public CameraWindow()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
                 ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            InitializeComponent();
        }

        // 绘制视窗大小
        protected override void OnPaint(PaintEventArgs pe)
        {
            if ((needSizeUpdate) || (firstFrame))
            {
                UpdatePosition();
                needSizeUpdate = false;
            }

            Monitor.Enter(this);

            Graphics g = pe.Graphics;
            Rectangle rc = this.ClientRectangle;
            Pen pen = new Pen(Color.Black, 1);

            // 画长方形
            g.DrawRectangle(pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);

            if (camera != null)
            {
                camera.Lock();

                // 绘制帧
                if (camera.LastFrame != null)
                {
                        g.DrawImage(camera.LastFrame, rc.X + 1, rc.Y + 1, rc.Width - 2, rc.Height - 2);
                        firstFrame = false;
                }
                else
                {
                    // 创建等待提醒
                    Font drawFont = new Font("Arial", 12);
                    SolidBrush drawBrush = new SolidBrush(Color.White);

                    g.DrawString("梦之缘正在努力O(∩_∩)O。。。。。", drawFont, drawBrush, new PointF(5, 5));

                    drawBrush.Dispose();
                    drawFont.Dispose();
                }

                camera.Unlock();
            }

            pen.Dispose();

            Monitor.Exit(this);

            base.OnPaint(pe);
        }

        // 更新空间的尺寸和位子
        public void UpdatePosition()
        {
            Monitor.Enter(this);

            if (autosize)
            {
                Rectangle rc = this.Parent.ClientRectangle;
                int width = 320;
                int height = 240;

                if (camera != null)
                {
                    camera.Lock();

                    // 获取帧大小
                    if (camera.LastFrame != null)
                    {
                        width = camera.LastFrame.Width;
                        height = camera.LastFrame.Height;
                    }
                    camera.Unlock();
                }

                this.SuspendLayout();
                this.Location = new Point((rc.Width - width - 2) / 2, (rc.Height - height - 2) / 2);
                this.Size = new Size(width + 2, height + 2);
                this.ResumeLayout();
            }

            Monitor.Exit(this);
        }

        // Camera新帧激发此函数重绘视频窗
        private void camera_NewFrame(object sender, System.EventArgs e)
        {
            Invalidate();    //重绘视频窗
        }


    }
}
