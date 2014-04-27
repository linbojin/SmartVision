using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using videosource;

namespace EasyN
{
    /// <summary>
    /// EasyNSourceDescription
    /// </summary>
    public class EasyNSourceDescription : IVideoSourceDescription
    {
        // 名字属性
        public string Name
        {
            get { return "EasyN IP Camera"; }
        }

        // 描述属性
        public string Description
        {
            get { return "从EasyN IPCamera获取视频"; }
        }

        // 返回设置界面
        public IVideoSourcePage GetSettingsPage()
        {
            return new EasyNCameraSetupPage();
        }

        // 保存配置信息
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            EasyNConfiguration cfg = (EasyNConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("login", cfg.login);
                writer.WriteAttributeString("password", cfg.password);
                writer.WriteAttributeString("stype", ((int)cfg.stremType).ToString());
                writer.WriteAttributeString("rate", cfg.rate.ToString());
                writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
            }
        }

        // 加载配置信息
        public object LoadConfiguration(XmlTextReader reader)
        {
            EasyNConfiguration config = new EasyNConfiguration();

            try
            {
                config.source = reader.GetAttribute("source");
                config.login = reader.GetAttribute("login");
                config.password = reader.GetAttribute("password");
                config.stremType = (StreamType)(int.Parse(reader.GetAttribute("stype")));
                config.rate = int.Parse(reader.GetAttribute("rate")); ;
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
            EasyNConfiguration cfg = (EasyNConfiguration)config;

            if (cfg != null)
            {
                EasyNCamera source = new EasyNCamera();

                source.StreamType = cfg.stremType;
                source.VideoSource = cfg.source;
                source.Login = cfg.login;
                source.Password = cfg.password;
                source.Rate = cfg.rate;
                source.FrameInterval = cfg.frameInterval;

                return (IVideoSource)source;
            }
            return null;
        }
    }
}