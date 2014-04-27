using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Net;
using videosource;

namespace jpeg
{
	/// <summary>
    /// JPEGSource： JPEG视频源 数据源类
	/// </summary>
	public class JPEGSource : IVideoSource
	{
		private string	source;
		private string	login = null;
		private string	password = null;
		private object	userData = null;
		private int		framesReceived;
		private int		bytesReceived;
		private bool	useSeparateConnectionGroup = false;
		private bool	preventCaching = false;
		private int		frameInterval = 0;		// 帧间隔 毫秒

		private const int	bufSize = 512 * 1024;	
		private const int	readSize = 1024;		

		private Thread	thread = null;
		private ManualResetEvent stopEvent = null;

		// 新帧事件
		public event CameraEventHandler NewFrame;

        // 用分离的链接组打开WebRequest
		public bool	SeparateConnectionGroup
		{
			get { return useSeparateConnectionGroup; }
			set { useSeparateConnectionGroup = value; }
		}
		
		public bool	PreventCaching
		{
			get { return preventCaching; }
			set { preventCaching = value; }
		}
		
		public int FrameInterval
		{
			get { return frameInterval; }
			set { frameInterval = value; }
		}

		public virtual string VideoSource
		{
			get { return source; }
			set { source = value; }
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
				stopEvent	= new ManualResetEvent(false);
				
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
		}

		// 线程入口
		public void WorkerThread()
		{
			byte[]			buffer = new byte[bufSize];	// buffer 用于读取流
			HttpWebRequest	req = null;
			WebResponse		resp = null;
			Stream			stream = null;
			Random			rnd = new Random((int) DateTime.Now.Ticks);
			DateTime		start;
			TimeSpan		span;

			while (true)
			{
				int	read, total = 0;

				try
				{
					start = DateTime.Now;

					// 创建请求
					if (!preventCaching)
					{
						req = (HttpWebRequest) WebRequest.Create(source);
					}
					else
					{
						req = (HttpWebRequest) WebRequest.Create(source + ((source.IndexOf('?') == -1) ? '?' : '&') + "fake=" + rnd.Next().ToString());
					}
					// 设置用户名和密码
					if ((login != null) && (password != null) && (login != ""))
						req.Credentials = new NetworkCredential(login, password);
					// 设置连接组名
					if (useSeparateConnectionGroup)
						req.ConnectionGroupName = GetHashCode().ToString();
                    // 获取响应
					resp = req.GetResponse();
					// 获取响应流
					stream = resp.GetResponseStream();
					// 循环
					while (!stopEvent.WaitOne(0, true))
					{
						if (total > bufSize - readSize)
						{
							total = 0;
						}

						// 读取流的下一部分
						if ((read = stream.Read(buffer, total, readSize)) == 0)
							break;

						total += read;

						// 增加收到比特，计数器
						bytesReceived += read;
					}

					if (!stopEvent.WaitOne(0, true))
					{
						// 帧计数器增加
						framesReceived++;

						// 产生新帧事件
						if (NewFrame != null)
						{
							Bitmap	bmp = (Bitmap) Bitmap.FromStream(new MemoryStream(buffer, 0, total));
							// 通知上层，新增事件
							NewFrame(this, new CameraEventArgs(bmp));
							// 释放图片
							bmp.Dispose();
							bmp = null;
						}
					}

					if (frameInterval > 0)
					{
						// 时间跨度
						span = DateTime.Now.Subtract(start);
						// 休眠数毫秒
						int msec = frameInterval - (int) span.TotalMilliseconds;

						while ((msec > 0) && (stopEvent.WaitOne(0, true) == false))
						{
							// 休眠
							Thread.Sleep((msec < 100) ? msec : 100);
							msec -= 100;
						}
					}
				}
				catch (WebException ex)
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
