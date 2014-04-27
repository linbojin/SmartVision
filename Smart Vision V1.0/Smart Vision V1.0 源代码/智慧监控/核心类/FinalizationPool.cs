using System;
using System.Collections;
using System.Threading
;
namespace IPCamera
{
	/// <summary>
	/// FinalizationPool
	/// </summary>
	public class FinalizationPool : CollectionBase
	{
		private Thread	thread;
		private ManualResetEvent stopEvent = null;

		// 空构造函数
		public FinalizationPool()
		{
		}

		// 开始线程
		public void Start()
		{
			// 创建事件
            stopEvent = new ManualResetEvent(false);    //如果为 true，则将初始状态设置为终止；如果为 false，则将初始状态设置为非终止。
				
			// 创建和开始新线程
			thread = new Thread(new ThreadStart(WorkerThread));
			thread.Start();
		}

		// 停止线程
		public void Stop()
		{
			if (thread != null)
			{
				// 给出停止信号
				stopEvent.Set();      //将事件状态设置为终止状态
				// 等待线程终止
				thread.Join();

				thread = null;

				// 释放事件
				stopEvent.Close();
				stopEvent = null;
			}
		}

		// 线程进入点
		private void WorkerThread()
		{
			while (!stopEvent.WaitOne(0, true))
			{
				Monitor.Enter(this);

                int n = InnerList.Count;

				// 查询每一个摄像头
				for (int i = 0; i < n; i++)
				{
					Camera camera = (Camera) InnerList[i];

					if (!camera.Running)
					{
						camera.CloseVideoSource();
						InnerList.RemoveAt(i);
						i--;
						n--;
					}
				}
				Monitor.Exit(this);

                //等待
				Thread.Sleep(300);
			}

            //关闭摄像头
			foreach (Camera camera in InnerList)
			{
				camera.Stop();
			}
		}

		// 增加新摄像头
		public void Add(Camera camera)
		{
			Monitor.Enter(this);
			InnerList.Add(camera);
			Monitor.Exit(this);
		}

		// 移除摄像头
		public void Remove(Camera camera)
		{
			Monitor.Enter(this);

			int n = InnerList.Count;
			for (int i = 0; i < n; i++)
			{
				if (InnerList[i] == camera)
				{
					if (camera.Running)
						camera.Stop();
					camera.CloseVideoSource();
					InnerList.RemoveAt(i);
					break;
				}
			}

			Monitor.Exit(this);
		}
	}
}
