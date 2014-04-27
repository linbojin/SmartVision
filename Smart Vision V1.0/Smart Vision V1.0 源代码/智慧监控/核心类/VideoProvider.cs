using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using videosource;

namespace IPCamera
{
	/// <summary>
	/// VideoProvider 视频源类     
	/// </summary> 
    public class VideoProvider : IComparable    //继承IComparable接口 比较对象返回整型负数，则为小于。
	{
		private IVideoSourceDescription	sourceDesc = null;  //把videosource接口获得的数据通过此实例传递。

		// Name 名字属性
		public string Name
		{
			get { return sourceDesc.Name; }
		}

		// Description 介绍属性
		public string Description
		{
			get { return sourceDesc.Description; }
		}

		// ProviderName 提供商名字属性？？？
		public string ProviderName
		{
			get { return sourceDesc.GetType().ToString(); }
		}

        // 构造函数 根据参数建立sourceDesc
		public VideoProvider(IVideoSourceDescription sourceDesc)
		{
			this.sourceDesc = sourceDesc;
		}

		// 比较类型
		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;

			VideoProvider p = (VideoProvider) obj;
			return (this.Name.CompareTo(p.Name));
		}

		// 获取视频源配置页面
		public IVideoSourcePage GetSettingsPage()
		{
			return sourceDesc.GetSettingsPage();
		}

		// 保存配置
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			sourceDesc.SaveConfiguration(writer, config);
		}

		// 加载配置
		public object LoadConfiguration(XmlTextReader reader)
		{
			return sourceDesc.LoadConfiguration(reader);
		}

		// 创建视频源
		public IVideoSource CreateVideoSource(object config)
		{
			return sourceDesc.CreateVideoSource(config);
		}
	}
}
