using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using videosource;

namespace jpeg
{
    /// <summary>
    /// JPEGSourceDescription：JPEG视频源 描述类
    /// </summary>
    public class JPEGSourceDescription : IVideoSourceDescription
    {
        // 名字属性
        public string Name
        {
            get { return "JPEG stream"; }
        }

        // 描述属性
        public string Description
        {
            get { return "通过网址，从特定的IPCamera上下载JPEG文件"; }
        }


        // 返回设置界面
        public IVideoSourcePage GetSettingsPage()
        {
            return new JPEGSourcePage();
        }

        // 保存配置信息
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            JPEGConfiguration cfg = (JPEGConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("login", cfg.login);
                writer.WriteAttributeString("password", cfg.password);
                writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
            }
        }

        // 加载配置信息
        public object LoadConfiguration(XmlTextReader reader)
        {
            JPEGConfiguration config = new JPEGConfiguration();

            try
            {
                config.source = reader.GetAttribute("source");
                config.login = reader.GetAttribute("login");
                config.password = reader.GetAttribute("password");
                config.frameInterval = int.Parse(reader.GetAttribute("interval"));
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // 创建视频源对象
        public IVideoSource CreateVideoSource(object config)
        {
            JPEGConfiguration cfg = (JPEGConfiguration)config;

            if (cfg != null)
            {
                JPEGSource source = new JPEGSource();

                source.VideoSource = cfg.source;
                source.Login = cfg.login;
                source.Password = cfg.password;
                source.FrameInterval = cfg.frameInterval;

                return (IVideoSource)source;
            }
            return null;
        }
    }
}
