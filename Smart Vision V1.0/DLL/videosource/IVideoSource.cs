using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace videosource
{
    /// <summary>
    /// IVideoSource  视频源接口
    /// </summary>
    public interface IVideoSource
    {
        /// <summary>
        /// 新帧事件 - 通知上层视频新帧事件
        /// </summary>
        event CameraEventHandler NewFrame;

        /// <summary>
        /// 视频源属性
        /// </summary>
        string VideoSource { get; set; }

        /// <summary>
        /// 用户名 属性
        /// </summary>
        string Login { get; set; }

        /// <summary>
        /// 密码 属性
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// 收到帧属性 - 从url获取数帧
        /// </summary>
        int FramesReceived { get; }

        /// <summary>
        /// 收到比特属性 - 从url获取数比特
        /// </summary>
        int BytesReceived { get; }

        /// <summary>
        /// 用户数据属性 - 用对象获取用户数据
        /// </summary>
        object UserData { get; set; }

        /// <summary>
        /// 获取视频源线程的状态
        /// </summary>
        bool Running { get; }

        /// <summary>
        /// 开始接收视频帧
        /// </summary>
        void Start();

        /// <summary>
        /// 停止接收视频帧
        /// </summary>
        void SignalToStop();

        /// <summary>
        /// 等待停止
        /// </summary>
        void WaitForStop();

        /// <summary>
        /// 停止工作
        /// </summary>
        void Stop();
    }
}