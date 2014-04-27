using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using videosource;
using Tiger.Video.VFW;

namespace IPCamera
{
    /// <summary>
    /// Camera 视频类
    /// </summary>
    public class Camera
    {
        private int id = 0;         //编号，名字，介绍，组别，设置，视频提供商，视频资源，最后一帧
        private string name;
        private string description = "";
        private object configuration = null;
        private VideoProvider provider = null;
        private IVideoSource videoSource = null;
        private bool photoing = false;

        private Bitmap lastFrame = null;
        private Bitmap recordFrame = null;
        private int width = -1, height = -1;      //长宽

        AVIWriter aviWriter = new AVIWriter();    //avi视频录制

        // 新帧事件
        public event EventHandler NewFrame;

        // URL属性
        public string URL
        {
            get { return videoSource.VideoSource; }
        }

        // 用户名属性
        public string Login
        {
            get { return videoSource.Login; }
        }

        // 密码属性
        public string Password
        {
            get { return videoSource.Password; }
        }

        // 编号属性
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        // 名字属性
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // 描述属性
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // 配置属性
        public object Configuration
        {
            get { return configuration; }
            set { configuration = value; }
        }

        // 视频源属性
        public VideoProvider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        // 最后一帧
        public Bitmap LastFrame
        {
            get { return lastFrame; }
        }

        // 宽度属性
        public int Width
        {
            get { return width; }
        }

        // 高度属性
        public int Height
        {
            get { return height; }
        }

        // 帧收到属性
        public int FramesReceived
        {
            get { return (videoSource == null) ? 0 : videoSource.FramesReceived; }
        }

        // 比特收到属性
        public int BytesReceived
        {
            get { return (videoSource == null) ? 0 : videoSource.BytesReceived; }
        }

        // 线程状态属性
        public bool Running
        {
            get { return (videoSource == null) ? false : videoSource.Running; }
        }

        /// <summary>
        /// 方法部分
        /// </summary>
        // 构造函数
        public Camera(string name)
        {
            this.name = name;
        }

        // 创建视频源
        public bool CreateVideoSource()
        {
            if ((provider != null) && ((videoSource = provider.CreateVideoSource(configuration)) != null))
            {
                // 把video_NewFrame注册到NewFrame事件中
                videoSource.NewFrame += new CameraEventHandler(video_NewFrame);
                return true;
            }
            return false;
        }

        // 关闭视频源
        public void CloseVideoSource()
        {
            if (videoSource != null)
            {
                videoSource = null;
            }
            // 释放最后一帧占用的资源
            if (lastFrame != null)
            {
                lastFrame.Dispose();
                lastFrame = null;
            }
            width = -1;
            height = -1;
        }

        // 开始视频源
        public void Start()
        {
            if (videoSource != null)
            {
                videoSource.Start();
            }
        }

        // 通知视频源停止
        public void SignalToStop()
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop();
            }
        }

        // 等待视频源终止
        public void WaitForStop()
        {
            Monitor.Enter(this);
            if (videoSource != null)
            {
                videoSource.WaitForStop();
            }
            Monitor.Exit(this);
        }

        // 终止视频
        public void Stop()
        {
            Monitor.Enter(this);
            if (videoSource != null)
            {
                videoSource.Stop();
            }
            Monitor.Exit(this);
        }

        // 加锁
        public void Lock()
        {
            Monitor.Enter(this);
        }

        // 解锁
        public void Unlock()
        {
            Monitor.Exit(this);
        }

        // NewFrame事件激发此函数
        private void video_NewFrame(object sender, CameraEventArgs e)
        {
            // 线程加锁
            Monitor.Enter(this);
            // 清理旧帧
            if (lastFrame != null)
            {
                lastFrame.Dispose();
            }
            // 复制图片
            lastFrame = (Bitmap)e.Bitmap.Clone();
            recordFrame = lastFrame;
            width = lastFrame.Width;
            height = lastFrame.Height;

            if (智慧监控.detector != null && 智慧监控.luzhi1 == false)
            {
                智慧监控.motionLevel = 智慧监控.detector.ProcessFrame(lastFrame);
            }

            if (photoing == true)
            {
                photoing = false;
                DateTime date = DateTime.Now;
                String fileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
                recordFrame.Save(String.Format(".\\SmartVision\\图片\\Camera_Vision_{0}_{1}.jpg", name, fileName), ImageFormat.Jpeg);
            }

            // 解锁
            Monitor.Exit(this);

            // 通知客户端  camera自己的新帧事件
            if (NewFrame != null)
            {
                NewFrame(this, new EventArgs());
            }
        }

        //视频录制函数
        public void RecordOpen()
        {
            DateTime date = DateTime.Now;
            String fileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            aviWriter.Open(String.Format(".\\SmartVision\\视频\\Camera_Vision_{0}_{1}.avi", name, fileName), width, height);
            aviWriter.FrameRate = 25;
            aviWriter.Quality = 100;
        }

        //向视频中添加新帧
        public void addFrame()
        {
            Monitor.Enter(this);
            aviWriter.AddFrame(recordFrame);
            Monitor.Exit(this);
        }

        //关闭录制
        public void RecordClose()
        {
            Thread.Sleep(500);   // 防止在关闭时，aviWriter.AddFrame(lastFrame);报错
            aviWriter.Close();
            aviWriter.Dispose();
        }

        //拍照
        public void TakePhoto()
        {
            photoing = true;
        }

    }
}
