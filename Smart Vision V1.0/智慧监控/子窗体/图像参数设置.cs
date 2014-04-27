using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace IPCamera
{
    public partial class 图像参数设置 : Form
    {
        private CameraCGI camCGI = new CameraCGI();

        public 图像参数设置()
        {
            InitializeComponent();
            cb分辨率.SelectedIndex = 2;
            cb模式.SelectedIndex = 0;
        }

        // CGI接口，用于连接摄像头
        public CameraCGI CamCGI
        {
            get { return camCGI; }
            set { camCGI = value; }
        }

        // 对比度
        private void tb对比度_Scroll(object sender, EventArgs e)
        {
            camCGI.set_Contrast(tb对比度.Value);
        }

        // 亮度
        private void tb亮度_Scroll(object sender, EventArgs e)
        {
            camCGI.set_Brightness(tb亮度.Value * 17);
        }

        // 分辨率
        private void cb分辨率_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = 32;
            switch (cb分辨率.SelectedIndex)
            {
                case 0:
                    value = 2;
                    break;
                case 1:
                    value = 8;
                    break;
                case 2:
                    value = 32;
                    break;
                default:
                    MessageBox.Show("错误");
                    break;
            }
            camCGI.set_Resolution(value);
        }

        // 模式
        private void cb模式_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = 1;
            switch (cb模式.SelectedIndex)
            {
                case 0:
                    value = 1;
                    break;
                case 1:
                    value = 0;
                    break;
                case 2:
                    value = 2;
                    break;
                default:
                    MessageBox.Show("错误");
                    break;
            }
            camCGI.set_Model(value);
        }

        private void but_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Det_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
