using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using videosource;

namespace IPCamera
{
    /// <summary>
    /// 新增摄像头时，配置界面的内嵌控件
    /// </summary>
    public partial class 摄像头配置 : UserControl,IWizardPage
    {
        private bool completed = false;
		private Camera camera = null;
		private VideoProvider provider = null;
		private IVideoSourcePage sourcePage;
        
        // 状态改变事件
		public event EventHandler StateChanged;
		// 复位事件
		//public event EventHandler Reset;

        public 摄像头配置()
        {
            InitializeComponent();
        }

		// 摄像头属性
		public Camera Camera
		{
			get { return camera; }
			set
			{
				if (value != null)
				{
					camera = value;

					// set configuration
					if (sourcePage != null)
					{
						sourcePage.SetConfiguration(camera.Configuration);

						// completed
						completed = sourcePage.Completed;
					}
				}
			}
		}

		// 提供商属性
		public VideoProvider Provider
		{
			get { return provider; }
			set
			{
				if ((provider == null) || (provider != value))
				{
					if (sourcePage != null)
					{
						// remove old page
						Controls.Remove((Control) sourcePage);
					}

					completed = false;
					provider = value;

					if (provider != null)
					{
						sourcePage = provider.GetSettingsPage();

						if (sourcePage != null)
						{
							Control	control = (Control) sourcePage;

							// add control
							control.Dock = DockStyle.Fill;
							Controls.Add(control);

							// events
							sourcePage.StateChanged += new EventHandler(page_StateChanged);

							// set configuration
							sourcePage.SetConfiguration(camera.Configuration);

							// completed
							completed = sourcePage.Completed;
						}
					}
				}
			}
		}

        // PageName property
		public string PageName
		{
            get { return "配置"; }
		}

		// PageDescription property
		public string PageDescription
		{
			get
			{
				string str = "摄像头配置";
				if (provider != null)
				{
					str += " : " + provider.Name;
				}
				return str;
			}
		}

		// Completed property
		public bool Completed
		{
			get { return completed; }
		}

		// Show the page
		public void Display()
		{
			if (sourcePage != null)
			{
				// show control
				((Control) sourcePage).Show();
				// notify page
				sourcePage.Display();
			}
		}

		// Apply the page
		public bool Apply()
		{
			bool	ret = false;

			if (sourcePage != null)
			{
				if ((ret = sourcePage.Apply()) == true)
				{
					camera.Configuration = sourcePage.GetConfiguration();
				}
			}

			return ret;
		}

		// On source page state changed
		private void page_StateChanged(object sender, System.EventArgs e)
		{
			completed = sourcePage.Completed;

			// notify wizard
			if (StateChanged != null)
				StateChanged(this, new EventArgs());
		}

    }
}
