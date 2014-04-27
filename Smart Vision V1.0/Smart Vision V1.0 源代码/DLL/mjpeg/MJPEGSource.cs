using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;    
using System.IO;
using System.Threading;
using System.Net;
using videosource;

namespace mjpeg
{
    /// <summary>
    /// MJPEGSource - MJPEG视频流支持
    /// </summary>
    public class MJPEGSource : IVideoSource
    {
        private string source;
        private string login = null;
        private string password = null;
        private object userData = null;
        private int framesReceived;
        private int bytesReceived;
        private bool useSeparateConnectionGroup = true;

        private const int bufSize = 512 * 1024;            // 缓冲大小
        private const int readSize = 1024;         

        private Thread thread = null;
        private ManualResetEvent stopEvent = null;         //停止事件
        private ManualResetEvent reloadEvent = null;      //重新加载事件

        // 新帧事件
        public event CameraEventHandler NewFrame;

        // 用分离的链接组打开WebRequest
        public bool SeparateConnectionGroup
        {
            get { return useSeparateConnectionGroup; }
            set { useSeparateConnectionGroup = value; }
        }

        // 视频源属性
        public string VideoSource
        {
            get { return source; }
            set
            {
                source = value;
                // 重新加载
                if (thread != null)
                    reloadEvent.Set();
            }
        }

        // 用户名属性
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        // 密码属性
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        // 收到帧属性
        public int FramesReceived
        {
            get
            {
                int frames = framesReceived;
                framesReceived = 0;
                return frames;
            }
        }

        // 收到比特属性
        public int BytesReceived
        {
            get
            {
                int bytes = bytesReceived;
                bytesReceived = 0;
                return bytes;
            }
        }

        // 用户数据属性
        public object UserData
        {
            get { return userData; }
            set { userData = value; }
        }

        // 获取视频源线程的状态
        public bool Running
        {
            get
            {
                if (thread != null)
                {
                    if (thread.Join(0) == false)
                        return true;

                    // 线程没有工作，所以释放资源
                    Free();
                }
                return false;
            }
        }



        /// <summary>
        /// 方法部分
        /// </summary>
        // 开始工作
        public void Start()
        {
            if (thread == null)
            {
                framesReceived = 0;
                bytesReceived = 0;

                // 创建事件
                stopEvent = new ManualResetEvent(false);
                reloadEvent = new ManualResetEvent(false);

                // 创建和开始新线程
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.Name = source;
                thread.Start();
            }
        }

        // 通知线程停止工作
        public void SignalToStop()
        {
            // 停止线程
            if (thread != null)
            {
                // 指示停止
                stopEvent.Set();
            }
        }

        // 等待线程停止
        public void WaitForStop()
        {
            if (thread != null)
            {
                // 等待线程停止
                thread.Join();

                Free();
            }
        }

        // 终止线程
        public void Stop()
        {
            if (this.Running)
            {
                thread.Abort();
                WaitForStop();
            }
        }

        // 释放资源
        private void Free()
        {
            thread = null;

            // 释放事件
            stopEvent.Close();
            stopEvent = null;
            reloadEvent.Close();
            reloadEvent = null;
        }

        // 线程入口
        public void WorkerThread()
        {
            byte[] buffer = new byte[bufSize];                // buffer 用于读取流

            while (true)
            {
                // 重置reload事件
                reloadEvent.Reset();

                HttpWebRequest req = null;
                WebResponse resp = null;
                Stream stream = null;
                byte[] delimiter = null;
                byte[] delimiter2 = null;
                byte[] boundary = null;
                int boundaryLen, delimiterLen = 0, delimiter2Len = 0;
                int read, todo = 0, total = 0, pos = 0, align = 1;
                int start = 0, stop = 0;

                // 排序
                //  1 = 查询图片的开始
                //  2 = 查询图片的结束
                try
                {
                    // 创建请求
                    req = (HttpWebRequest)WebRequest.Create(source);
                    // 设置用户名和密码
                    if ((login != null) && (password != null) && (login != ""))
                        req.Credentials = new NetworkCredential(login, password);
                    // 设置连接组名
                    if (useSeparateConnectionGroup)
                        req.ConnectionGroupName = GetHashCode().ToString();
                    // 获取响应
                    resp = req.GetResponse();

                    // 检查内容类型
                    string ct = resp.ContentType;
                    if (ct.IndexOf("multipart/x-mixed-replace") == -1)
                        throw new ApplicationException("Invalid URL");

                    // 获取分界
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    boundary = encoding.GetBytes(ct.Substring(ct.IndexOf("boundary=", 0) + 9));
                    boundaryLen = boundary.Length;

                    // 获取响应流
                    stream = resp.GetResponseStream();

                    // 循环
                    while ((!stopEvent.WaitOne(0, true)) && (!reloadEvent.WaitOne(0, true)))
                    {
                        if (total > bufSize - readSize)
                        {
                            total = pos = todo = 0;
                        }

                        // 读取流的下一部分
                        if ((read = stream.Read(buffer, total, readSize)) == 0)
                            throw new ApplicationException();

                        total += read;
                        todo += read;

                        // increment received bytes counter
                        bytesReceived += read;

                        if (delimiter == null)
                        {
                            // 找到边界
                            pos = ByteArrayUtils.Find(buffer, boundary, pos, todo);

                            if (pos == -1)
                            {
                                // 没有找到
                                todo = boundaryLen - 1;
                                pos = total - todo;
                                continue;
                            }

                            todo = total - pos;

                            if (todo < 2)
                                continue;

                            if (buffer[pos + boundaryLen] == 10)
                            {
                                delimiterLen = 2;
                                delimiter = new byte[2] { 10, 10 };
                                delimiter2Len = 1;
                                delimiter2 = new byte[1] { 10 };
                            }
                            else
                            {
                                delimiterLen = 4;
                                delimiter = new byte[4] { 13, 10, 13, 10 };
                                delimiter2Len = 2;
                                delimiter2 = new byte[2] { 13, 10 };
                            }

                            pos += boundaryLen + delimiter2Len;
                            todo = total - pos;
                        }

                        // 查询图片头
                        if (align == 1)
                        {
                            start = ByteArrayUtils.Find(buffer, delimiter, pos, todo);
                            if (start != -1)
                            {
                                // 找到delimiter
                                start += delimiterLen;
                                pos = start;
                                todo = total - pos;
                                align = 2;
                            }
                            else
                            {
                                // delimiter没有找到
                                todo = delimiterLen - 1;
                                pos = total - todo;
                            }
                        }

                        // 查询图片尾
                        while ((align == 2) && (todo >= boundaryLen))
                        {
                            stop = ByteArrayUtils.Find(buffer, boundary, pos, todo);
                            if (stop != -1)
                            {
                                pos = stop;
                                todo = total - pos;

                                // 帧计数器增加
                                framesReceived++;

                                // 产生新帧事件
                                if (NewFrame != null)
                                {
                                    Bitmap bmp = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, start, stop - start));
                                    // 通知上层，新帧事件
                                    NewFrame(this, new CameraEventArgs(bmp));
                                    // 释放图片
                                    bmp.Dispose();
                                    bmp = null;
                                }

                                // 转移数组
                                pos = stop + boundaryLen;
                                todo = total - pos;
                                Array.Copy(buffer, pos, buffer, 0, todo);

                                total = todo;
                                pos = 0;
                                align = 1;
                            }
                            else
                            {
                                // delimiter没有找到
                                todo = boundaryLen - 1;
                                pos = total - todo;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                    // 等待再一次尝试
                    Thread.Sleep(250);
                }
                catch (ApplicationException ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                    // 等待再一次尝试
                    Thread.Sleep(250);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                }
                finally
                {
                    // 终止请求
                    if (req != null)
                    {
                        req.Abort();
                        req = null;
                    }
                    // 关闭响应流
                    if (stream != null)
                    {
                        stream.Close();
                        stream = null;
                    }
                    // 关闭响应
                    if (resp != null)
                    {
                        resp.Close();
                        resp = null;
                    }
                }

                if (stopEvent.WaitOne(0, true))
                    break;
            }
        }
    }
}

