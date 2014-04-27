using System;
using System.Collections;
//@梦之缘工作坊

namespace IPCamera
{
	/// <summary>
	/// RunningPool
	/// </summary>
	public class RunningPool : CollectionBase
	{
		// 空构造函数
		public RunningPool()
		{
		}

		// 获取摄像头
		public Camera this[int index]
		{
			get
			{
				return ((Camera) InnerList[index]);
			}
		}

        // 新增camera，开始跑视频
		public bool Add(Camera camera)
		{
			// 创建视频源
			if (camera.CreateVideoSource())
			{
				// 增加到pool中
				InnerList.Add(camera);
				camera.Start();
				return true;
			}
			return false;
		}

		// 从集中移除Camera，信号关闭。
		public void Remove(Camera camera)
		{
            try                          //页面视频个数及位置需要从新排列
            { 
                camera.SignalToStop();
            }
            catch (Exception )
            {
            
            }
            
			InnerList.Remove(camera);

            // 信号关闭
			
		}
	}
}
