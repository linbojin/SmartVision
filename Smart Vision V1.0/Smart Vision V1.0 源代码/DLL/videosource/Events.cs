using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace videosource
{
    // NewFrame 委托
    public delegate void CameraEventHandler(object sender, CameraEventArgs e);

    /// <summary>
    /// 视频事件参数
    /// </summary>
    public class CameraEventArgs : EventArgs
    {
        private Bitmap bmp;

        // 构造函数
        public CameraEventArgs(Bitmap bmp)
        {
            this.bmp = bmp;
        }

        // 位图属性
        public Bitmap Bitmap
        {
            get { return bmp; }
        }
    }
}