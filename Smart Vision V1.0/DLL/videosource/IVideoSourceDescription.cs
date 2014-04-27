using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace videosource
{
    /// <summary>
    /// 接口 - 视频源描述
    /// </summary>
    public interface IVideoSourceDescription
    {
        // 名字属性
        string Name { get; }

        // 描述 属性
        string Description { get; }

        // 返回设置界面
        IVideoSourcePage GetSettingsPage();

        // 保存配置信息
        void SaveConfiguration(XmlTextWriter writer, object config);

        // 加载配置信息
        object LoadConfiguration(XmlTextReader reader);

        // 创建视频源对象
        IVideoSource CreateVideoSource(object config);
    }
}
