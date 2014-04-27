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
    public partial class 摄像头配置窗体 : 配置窗体模板
    {
        private Camera camera = new Camera("");
        private 摄像头描述 page1 = new 摄像头描述();
        private 摄像头配置 page2 = new 摄像头配置();

        public 摄像头配置窗体()
        {
            this.AddPage(page1);
            this.AddPage(page2);
            this.Text = "配置摄像头";

            page1.Camera = camera;
            page2.Camera = camera;
        }

		// 获取视频提供商
		public VideoProviderCollection VideoProviders
		{
			set { page1.VideoProviders = value; }
		}

		// 获取摄像头
		public Camera Camera
		{
			get { return camera; }
			set
			{
                try 
                {
                    camera = value;
                    page1.Camera = camera;
				    page2.Camera = camera;
				    page2.Provider = camera.Provider;
                }
                catch(System.Exception )
                {
                }

			}
		}

		public CheckCameraHandler CheckCameraFunction
		{
			set { page1.CheckCameraFunction = value; }
		}
    }
}
