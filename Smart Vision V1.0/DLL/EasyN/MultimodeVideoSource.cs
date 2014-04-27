using System;
using System.Collections;
using videosource;
using jpeg;
using mjpeg;

namespace EasyN
{
	/// <summary>
	/// MultimodeVideoSource类 - 支持多种模式的视频源
	/// </summary>
	public abstract class MultimodeVideoSource : IVideoSource
	{
		protected IVideoSource	videoSource;
		protected StreamType	streamType;
		private ArrayList		delegates = new ArrayList();

		// 新帧事件
		public event CameraEventHandler NewFrame
		{
			add
			{
				videoSource.NewFrame += value;
				delegates.Add((object) value);
			}
			remove
			{
				videoSource.NewFrame -= value;
				delegates.Remove((object) value);
			}
		}

		// 构造函数
		public MultimodeVideoSource()
		{
		}

		// 视频流类属性
		public virtual StreamType StreamType
		{
			get { return streamType; }
			set
			{
				// 如果视频源不工作改变流类型
				if ((streamType != value) && (!videoSource.Running))
				{
					streamType = value;
					
					// 保存数据
					object	userData = videoSource.UserData;
					string	login = videoSource.Login;
					string	password = videoSource.Password;

					// 创建新视频源
					switch (streamType)
					{
						case StreamType.Jpeg:
							videoSource = new JPEGSource();
							break;
						case StreamType.MJpeg:
							videoSource = new MJPEGSource();
							break;
					}

					// 加载数据
					videoSource.Login		= login;
					videoSource.Password	= password;
					videoSource.UserData	= userData;

					// 绑定新帧事件和委托
					foreach (object handler in delegates)
						videoSource.NewFrame += (CameraEventHandler) handler;

					UpdateVideoSource();
				}
			}
		}

        // 视频源属性
		public abstract string VideoSource
		{
			get;
			set;
		}

        // 用户名属性
		public string Login
		{
			get { return videoSource.Login; }
			set { videoSource.Login = value; }
		}

        // 密码属性
		public string Password
		{
			get { return videoSource.Password; }
			set { videoSource.Password = value; }
		}

        // 收到帧属性
		public int FramesReceived
		{
			get { return videoSource.FramesReceived; }
		}

        // 收到比特属性
		public int BytesReceived
		{
			get { return videoSource.BytesReceived; }
		}

        // 用户数据属性
		public object UserData
		{
			get { return videoSource.UserData; }
			set { videoSource.UserData = value; }
		}

        // 获取视频源线程的状态
		public bool Running
		{
			get { return videoSource.Running; }
		}

		// 开始接收视频帧
		public void Start()
		{
			videoSource.Start();
		}

		// 停止接收视频帧
		public void SignalToStop()
		{
			videoSource.SignalToStop();
		}

		// 等待停止
		public void WaitForStop()
		{
			videoSource.WaitForStop();
		}

		// 停止工作
		public void Stop()
		{
			videoSource.Stop();
		}

		// 更新视频源
		protected abstract void UpdateVideoSource();
	}
}
