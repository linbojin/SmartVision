using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;    
using videosource;

namespace mjpeg
{
    /// <summary>
    /// MJPEGSourceDescription
    /// </summary>
    public class MJPEGSourceDescription : IVideoSourceDescription
    {
        // 名字属性
        public string Name
        {
            get { return "MJPEG stream"; }
        }

        // 描述属性
        public string Description
        {
            get { return "通过网址，从特定的IPCamera上下载MJPEG流文件"; }
        }

        // 返回设置界面
        public IVideoSourcePage GetSettingsPage()
        {
            return new MJPEGSourcePage();
        }

        // 保存配置信息
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            MJPEGConfiguration cfg = (MJPEGConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("URL", cfg.source);
                writer.WriteAttributeString("用户名", cfg.loginname);
                writer.WriteAttributeString("密码", cfg.password);
            }
        }

        // 加载配置信息
        public object LoadConfiguration(XmlTextReader reader)
        {
            MJPEGConfiguration config = new MJPEGConfiguration();

            try
            {
                config.source = reader.GetAttribute("URL");
                config.loginname = reader.GetAttribute("用户名");
                config.password = reader.GetAttribute("密码");
            }
            catch (Exception)
            {
            }

            return (object)config;
        }

        // 创建视频源对象
        public IVideoSource CreateVideoSource(object config)
        {
            MJPEGConfiguration cfg = (MJPEGConfiguration)config;

            if (cfg != null)
            {
                MJPEGSource source = new MJPEGSource();

                source.VideoSource = cfg.source;
                source.Login = cfg.loginname;
                source.Password = cfg.password;

                return (IVideoSource)source;
            }
            return null;
        }
    }
}

