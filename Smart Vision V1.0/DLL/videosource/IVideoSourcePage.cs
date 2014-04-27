using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace videosource
{

    /// <summary>
    /// IVideoSourcePage interface
    /// </summary>
    public interface IVideoSourcePage
    {
        /// <summary>
        /// 状态改变事件 - 页面完成通知上层
        /// </summary>
        event EventHandler StateChanged;

        /// <summary>
        /// 完成属性
        /// true, 页面完成，导向导窗体可以进入下一页
        /// </summary>
        bool Completed { get; }

        /// <summary>
        /// 显示页面
        /// 向导窗体调用该方法显示
        /// </summary>
        void Display();

        /// <summary>
        /// 检查和更新配置
        /// </summary>
        bool Apply();

        /// <summary>
        /// （创建Camera或修改Camera时）获得配置信息：URL，用户名，密码。
        /// </summary>
        object GetConfiguration();

        /// <summary>
        /// （对已有Camera操作）先获取后修改配置信息：URL，用户名，密码。
        /// </summary>
        void SetConfiguration(object config);
    }
}
