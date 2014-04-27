using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPCamera
{


    /// <summary>
    /// 摄像头信息：视频区域右键选项，视频信息显示。
    /// </summary>
    public partial class 摄像头信息 : Form
    {
        public 摄像头信息()
        {
            InitializeComponent();
        }

        private Camera camera;

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        // 加载
        private void 摄像头信息_Load(object sender, EventArgs e)
        {
            if (camera != null)
            {
                lbtxt名字.Text = camera.Name;
                lbtxt介绍.Text = camera.Description;
                lbtxt提供商.Text = camera.Provider.Name;
            }

        }



    }
}
