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
    public partial class 摄像头新增窗体 : 新增向导模板
    {
        private Camera camera = new Camera("");
        private 摄像头描述 page1 = new 摄像头描述();
        private 摄像头配置 page2 = new 摄像头配置();

        public 摄像头新增窗体()
        {
            this.AddPage(page1);
            this.AddPage(page2);
            this.Text = "摄像头添加向导";

            page1.Camera = camera;
            page2.Camera = camera;
        }

        // 视频提供商 属性
        public VideoProviderCollection VideoProviders
        {
            set { page1.VideoProviders = value; }
        }

        // 视频 属性
        public Camera Camera
        {
            get { return camera; }
            set
            {
                camera = value;

                page1.Camera = camera;
                page2.Camera = camera;
            }
        }

        // CheckCameraFunction property
        public CheckCameraHandler CheckCameraFunction
        {
            set { page1.CheckCameraFunction = value; }
        }

        // On page changing
        protected override void OnPageChanging(int page)
        {
            if (page == 1)
            {
                // switching to camera settings
                page2.Provider = page1.VideoProviders[page1.SelectedProviderIndex];
            }
            base.OnPageChanging(page);
        }

        // Reset event ocuren on page
        protected override void OnResetOnPage(int page)
        {
            if (page == 1)
            {
                page2.Provider = null;
            }
        }

        //// On finish
        //protected override void OnFinish()
        //{
        //}
    }
}
