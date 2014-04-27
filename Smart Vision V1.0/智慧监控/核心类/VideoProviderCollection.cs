using System;
using System.Collections;
using System.IO;
using System.Reflection;
using videosource;
//@梦之缘工作坊

namespace IPCamera
{
	/// <summary>
	/// VideoProviderCollection class - 收集视频提供商
	/// </summary>
    public class VideoProviderCollection : CollectionBase   //继承类，有InnerList属性
	{
		// 构造函数
		public VideoProviderCollection()
		{
		}

		// 根据序号获取视频源
		public VideoProvider this[int index]
		{
			get
			{
				return ((VideoProvider) InnerList[index]);
			}
		}

		// 根据名字获得提供商
		public VideoProvider GetProviderByName(string name)
		{
			foreach (VideoProvider provider in InnerList)
			{
				if (provider.ProviderName == name)
				{
					return provider;
				}
			}
			return null;
		}

		// ！！！！！加载所有视频提供商，通过DLL！！！！
		public void Load(string path)
		{
            // 实例化DirectoryInfo类
			DirectoryInfo dir = new DirectoryInfo(path);

			// 获取path下所以dll文件
			FileInfo[] files = dir.GetFiles("*.dll");

			// 历遍所有dll文件
			foreach (FileInfo f in files)
			{
				LoadAssembly(Path.Combine(path, f.Name));   //合并路径，
			}

            // 对提供商继承IComparable，进行排序。
			InnerList.Sort();      
		}

		// 加载程序集
		private void LoadAssembly(string fname)
		{
			Type typeVideoSourceDesc = typeof(IVideoSourceDescription);
			Assembly asm = null;

			try
			{
				// 加载assembly程序集
				asm = Assembly.LoadFrom(fname);

				// 获取程序集type
				Type[] types = asm.GetTypes();

				// 检验各种类型
				foreach (Type type in types)
				{
					// 获取接口
					Type[] interfaces = type.GetInterfaces();

					// 检查type是否继承 IVideoSourceDescription
                    if (Array.IndexOf(interfaces, typeVideoSourceDesc) != -1)    //在interfaces中匹配typeVideoSourceDesc类型
					{
						IVideoSourceDescription	desc = null;

						try
						{
							// 创建此type的实例
							desc = (IVideoSourceDescription) Activator.CreateInstance(type);
							// 创建提供商对象
							InnerList.Add(new VideoProvider(desc));
						}
						catch (Exception)
						{
							
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
