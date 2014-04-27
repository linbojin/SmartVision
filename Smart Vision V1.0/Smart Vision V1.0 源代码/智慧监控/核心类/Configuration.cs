using System;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Text;
using videosource;
using System.Data.OleDb;
using System.Data;


namespace IPCamera
{
	/// <summary>
    /// Configuration 应用程序配置
	/// </summary>
	public class Configuration
	{
		// 配置文件名字
		private string settingsFile;
		private string camerasFile;
		private string viewsFile;

        private string ConStr = "Provider=Microsoft.jet.OLEDB.4.0;Data source=" + System.Windows.Forms.Application.StartupPath + "\\Location.mdb";
        OleDbConnection con;
        OleDbCommand objcmd;
		// 主窗体位置和大小
		public Point	mainWindowLocation = new Point(100, 50);
		public Size		mainWindowSize = new Size(800, 600);

		//适应窗体和全屏
		public bool		fitToScreen = true;
		public bool		fullScreen = false;

		// 编号
		private int		nextCameraID = 1;
		private int		nextViewID = 1;

        // 集合
		public readonly VideoProviderCollection providers = new VideoProviderCollection();
		public readonly CameraCollection cameras = new CameraCollection();
		public readonly ViewCollection views = new ViewCollection();

		// 构造函数
		public Configuration(string path)
		{
			settingsFile = Path.Combine(path, "app.config");        
			camerasFile = Path.Combine(path, "cameras.config");
			viewsFile = Path.Combine(path, "views.config");
            con = new OleDbConnection(ConStr);
		}

		// 新增摄像头
		public void AddCamera(Camera camera)
		{
			camera.ID = nextCameraID++;
			cameras.Add(camera);
			SaveCameras();
		}

		// 匹配摄像头
		public bool CheckCamera(Camera camera)
		{
			foreach (Camera c in cameras)
			{
				if ((camera.Name == c.Name) && ((camera.ID == 0) || (camera.ID != c.ID)))
					return false;
			}
			return true;
		}

		// 删除摄像头
		public bool DeleteCamera(Camera camera)
		{
			cameras.Remove(camera);
			SaveCameras();
			return true;
		}

		// 新增页面
		public void AddView(View view)
		{
			view.ID = nextViewID++;
			views.Add(view);
			SaveViews();
		}

        // 检查是否已经存在页面，无则为true.
		public bool CheckView(View view)
		{
			foreach (View v in views)
			{
				if ((view.Name == v.Name) && ((view.ID == 0) || (view.ID != v.ID)))
					return false;
			}
			return true;
		}

		// 删除页面
		public bool DeleteView(View view)
		{
			views.Remove(view);
			SaveViews();
			return true;
		}

        /// <summary>
        /// 从XML文件中保存和加载摄像头页面配置信息
        /// </summary>

        // 把应用程序信息加载到app.config中
        public void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create);
            XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

            // 增加伸缩可读性
            xmlOut.Formatting = Formatting.Indented;

            // 开始写入
            xmlOut.WriteStartDocument();
            xmlOut.WriteComment("智慧监控系统配置文件");

            // 根目录
            xmlOut.WriteStartElement("智慧监控");

            // 主窗体目录
            xmlOut.WriteStartElement("MainWindow");
            xmlOut.WriteAttributeString("x", mainWindowLocation.X.ToString());
            xmlOut.WriteAttributeString("y", mainWindowLocation.Y.ToString());
            xmlOut.WriteAttributeString("宽度", mainWindowSize.Width.ToString());
            xmlOut.WriteAttributeString("高度", mainWindowSize.Height.ToString());
            xmlOut.WriteEndElement();

            xmlOut.WriteEndElement();
            xmlOut.Close();
        }

        // 从app.config中加载应用程序配置信息
        public bool LoadSettings()
        {
            bool ret = false;
            if (File.Exists(settingsFile))
            {
                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // 打开文件
                    fs = new FileStream(settingsFile, FileMode.Open);
                    // 创建XMLreader
                    xmlIn = new XmlTextReader(fs);
                    // 忽略空内容节点
                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent();

                    // 匹配根目录
                    if (xmlIn.Name != "智慧监控")
                        throw new ApplicationException("");

                    // 匹配下一节点
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    // 匹配主窗体节点
                    if (xmlIn.Name != "MainWindow")
                        throw new ApplicationException("");

                    // 主窗体信息
                    int x = Convert.ToInt32(xmlIn.GetAttribute("x"));
                    int y = Convert.ToInt32(xmlIn.GetAttribute("y"));
                    int width = Convert.ToInt32(xmlIn.GetAttribute("宽度"));
                    int height = Convert.ToInt32(xmlIn.GetAttribute("高度"));

                    // 查询下一节点
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    mainWindowLocation = new Point(x, y);
                    mainWindowSize = new Size(width, height);

                    ret = true;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (xmlIn != null)
                        xmlIn.Close();
                }
            }
            return ret;
        }


        // 把整个摄像头目录保存到xml中
		public void SaveCameras()
		{
			// 打开或创建文件
			FileStream		fs = new FileStream(camerasFile, FileMode.Create);
			// 创建XmlWriter
			XmlTextWriter	xmlOut = new XmlTextWriter(fs, Encoding.UTF8);
        	
            // 自动缩进适合阅读
			xmlOut.Formatting = Formatting.Indented;
			// 开始写入
			xmlOut.WriteStartDocument();
		
            // 根目录开始
			xmlOut.WriteStartElement("Cameras");
			// 保存所有的摄像头
			SaveCameras(xmlOut);
			// 根目录结束
			xmlOut.WriteEndElement();           
		
            // 关闭文件
			xmlOut.Close();
		}
		// 把单个摄像头节点信息保存进Xml文档
		private void SaveCameras(XmlTextWriter writer)
		{
            con.Open();
            string sql1 = "delete * from Location";
            objcmd = new OleDbCommand(sql1, con);
            objcmd.ExecuteNonQuery();
            con.Close();      
			foreach (Camera camera in cameras)
			{
					// 新建 "Camera" 节点
					writer.WriteStartElement("Camera");
					// 写入节点信息
					writer.WriteAttributeString("id", camera.ID.ToString());
					writer.WriteAttributeString("name", camera.Name);
					writer.WriteAttributeString("desc", camera.Description);

   				    if (camera.Provider != null)
					{
						// 写入视频源名字
						writer.WriteAttributeString("视频源", camera.Provider.ProviderName);

						if (camera.Configuration != null)
						{
                            // 写入视频配置信息
							camera.Provider.SaveConfiguration(writer, camera.Configuration);
						}
					}
					// 关闭 "Camera" 节点
					writer.WriteEndElement();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        string sql = "select count(*) FROM [Location] where 名称='" + camera.Name + "' ";        
                        objcmd = new OleDbCommand(sql, con);
                        Int32 id_e = (Int32)objcmd.ExecuteScalar();
                        if (id_e > 0)
                        {
                        }
                        else
                        {
                            try 
                            {
                                switch (camera.Name)
                                {
                                    case "美国华盛顿街市摄像头":
                                        sql = "insert into Location(名称,名字,视频源,纬度,经度,地点) values('" + camera.Name + "','" + camera.Name + "','" + camera.Provider.ProviderName + "','37.300275','-91.05468','美国')";
                                        objcmd = new OleDbCommand(sql, con);
                                        objcmd.ExecuteNonQuery();
                                        break;
                                    case "西班牙加那利天体物理大学摄像头":
                                        sql = "insert into Location(名称,名字,视频源,纬度,经度,地点) values('" + camera.Name + "','" + camera.Name + "','" + camera.Provider.ProviderName + "','40.463667','-3.74922','西班牙加那利天体物理大学')";
                                        objcmd = new OleDbCommand(sql, con);
                                        objcmd.ExecuteNonQuery();
                                        break;
                                    case "上海大学D楼摄像头":
                                        sql = "insert into Location(名称,名字,视频源,纬度,经度,地点) values('" + camera.Name + "','" + camera.Name + "','" + camera.Provider.ProviderName + "','31.314928','121.395085','上海市宝山区上海大学')";
                                        objcmd = new OleDbCommand(sql, con);
                                        objcmd.ExecuteNonQuery();
                                        break;
                                    default:
                                        sql = "insert into Location(名称,名字,视频源) values('" + camera.Name + "','" + camera.Name + "','" + camera.Provider.ProviderName + "')";
                                        objcmd = new OleDbCommand(sql, con);
                                        objcmd.ExecuteNonQuery();
                                        break;
                                }
                            }catch(SystemException)
                            {
                            }       
                        }
                    }
                    con.Close();
			}
		}

		// 从Xml中加载整个摄像头目录
		public void LoadCameras()
		{
			// 检查文件是否存在
			if (File.Exists(camerasFile))
			{
				FileStream		fs = null;
				XmlTextReader	xmlIn = null;

				try
				{
					// 打开文件
					fs = new FileStream(camerasFile, FileMode.Open);
					// 创建XMLreader
					xmlIn = new XmlTextReader(fs);
                    // 跳过空白内容继续
					xmlIn.WhitespaceHandling = WhitespaceHandling.None;
					xmlIn.MoveToContent();
					// 检查根目录
                    if (xmlIn.Name != "Cameras")
						throw new ApplicationException("");
					// 查询下一个子节点
					xmlIn.Read();
					if (xmlIn.NodeType == XmlNodeType.EndElement)
						xmlIn.Read();

					// 加载摄像头
					LoadCameras(xmlIn);
				}
				catch (Exception)
				{
				}
				finally
				{
					if (xmlIn != null)
						xmlIn.Close();
				}
			}
		}

        // 从Xml中加载单个摄像头节点信息
        private void LoadCameras(XmlTextReader reader)
        {
            // 加载所有的摄像头信息节点
            while (reader.Name == "Camera")
            {
                int	depth = reader.Depth;

                // 创建新摄像头
                Camera camera = new Camera(reader.GetAttribute("name"));
                camera.ID			= int.Parse(reader.GetAttribute("id"));
                camera.Description	= reader.GetAttribute("desc");
                camera.Provider		= providers.GetProviderByName(reader.GetAttribute("视频源"));

                // 加载配置信息
                if (camera.Provider != null)
                {
                    camera.Configuration = camera.Provider.LoadConfiguration(reader);
                }

                // 把摄像头加到集合中
                cameras.Add(camera);

                if (camera.ID >= nextCameraID)
                {
                    nextCameraID = camera.ID + 1;
                }

                // 查询下一子节点
                reader.Read();

                // 移动到下一个节点
                while (reader.NodeType == XmlNodeType.EndElement)
                    reader.Read();
                if (reader.Depth < depth)
                    return;
            }
        }


        // 把整个页面目录保存到xml中
		public void SaveViews()
		{
			FileStream		fs = new FileStream(viewsFile, FileMode.Create);
			XmlTextWriter	xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

			xmlOut.Formatting = Formatting.Indented;
			xmlOut.WriteStartDocument();
			xmlOut.WriteStartElement("Views");
			SaveViews(xmlOut);
			xmlOut.WriteEndElement();
			xmlOut.Close();
		}

        // 把单个页面节点信息保存进Xml文档
        private void SaveViews(XmlTextWriter writer)
        {
            foreach (View view in views)
            {
                    writer.WriteStartElement("View");
                    writer.WriteAttributeString("id", view.ID.ToString());
                    writer.WriteAttributeString("name", view.Name);
                    writer.WriteAttributeString("desc", view.Description);
                    writer.WriteAttributeString("rows", view.Rows.ToString());
                    writer.WriteAttributeString("cols", view.Cols.ToString());
                    writer.WriteAttributeString("width", view.CellWidth.ToString());
                    writer.WriteAttributeString("height", view.CellHeight.ToString());

                    // 写入摄像头
                    string[] strIDs = new string[View.MaxRows * View.MaxCols];
                    for (int i = 0, k = 0; i < View.MaxRows; i++)
                    {
                        for (int j = 0; j < View.MaxCols; j++, k++)
                        {
                            strIDs[k] = view.GetCamera(i, j).ToString();
                        }
                    }
                    writer.WriteAttributeString("cameras", string.Join(",", strIDs));

                    writer.WriteEndElement();
                }
        }

        // 从Xml中加载整个页面目录
		public void LoadViews()
		{
			if (File.Exists(viewsFile))
			{
				FileStream		fs = null;
				XmlTextReader	xmlIn = null;

				try
				{
					fs = new FileStream(viewsFile, FileMode.Open);
					xmlIn = new XmlTextReader(fs);

					xmlIn.WhitespaceHandling = WhitespaceHandling.None;
					xmlIn.MoveToContent();

					if (xmlIn.Name != "Views")
						throw new ApplicationException("");

					xmlIn.Read();
					if (xmlIn.NodeType == XmlNodeType.EndElement)
						xmlIn.Read();

		         LoadViews(xmlIn);
				}
				catch (Exception)
				{
				}
				finally
				{
					if (xmlIn != null)
						xmlIn.Close();
				}
			}
		}

        // 从Xml中加载单个页面节点信息
        private void LoadViews(XmlTextReader reader)
        {
            while (reader.Name == "View")
            {
                int	depth = reader.Depth;

                View view = new View(reader.GetAttribute("name"));
                view.ID				= int.Parse(reader.GetAttribute("id"));
                view.Description	= reader.GetAttribute("desc");
                view.Rows			= short.Parse(reader.GetAttribute("rows"));
                view.Cols			= short.Parse(reader.GetAttribute("cols"));
                view.CellWidth		= short.Parse(reader.GetAttribute("width"));
                view.CellHeight		= short.Parse(reader.GetAttribute("height"));

                string[] strIDs = reader.GetAttribute("cameras").Split(',');
                for (int i = 0, k = 0; i < View.MaxRows; i++)
                {
                    for (int j = 0; j < View.MaxCols; j++, k++)
                    {
                        view.SetCamera(i, j, int.Parse(strIDs[k]));
                    }
                }

                views.Add(view);

                if (view.ID >= nextViewID)
                    nextViewID = view.ID + 1;

                // 读取下一节点
                reader.Read();
                while (reader.NodeType == XmlNodeType.EndElement)
                    reader.Read();
                if (reader.Depth < depth)
                    return;
            }
        }

	}
}
