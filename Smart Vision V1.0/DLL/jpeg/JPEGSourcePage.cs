using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using videosource;

namespace jpeg
{
	/// <summary>
	/// JPEGSourcePage 配置页面
	/// </summary>
	public partial class JPEGSourcePage : UserControl, IVideoSourcePage
	{
		private static int[] frameIntervals = new int[] {0, 100, 142, 200, 333, 1000,
						5000, 10000, 15000, 20000, 30000, 60000};
		private bool completed = false;

		// 状态改变事件
		public event EventHandler StateChanged;

        // 完成属性
        public bool Completed
        {
            get { return completed; }
        }

		// 构造函数
		public JPEGSourcePage()
		{
			InitializeComponent();
			rateCombo.SelectedIndex = 0;     // 下拉框默认选中项
		}

        // 显示页面
		public void Display()
		{
			urlBox.Focus(); 
			urlBox.SelectionStart = urlBox.TextLength;
		}

		// 应用
		public bool Apply()
		{
			return true;
		}

        // （创建Camera或修改Camera时）获得配置信息：URL，用户名，密码。
		public object GetConfiguration()
		{
			JPEGConfiguration	config = new JPEGConfiguration();
			config.source	= urlBox.Text;        // URL    
			config.login	= loginBox.Text;      // 用户名
			config.password	= passwordBox.Text;   // 密码
			config.frameInterval = frameIntervals[rateCombo.SelectedIndex];   //帧率
			return (object) config;
		}

        // （对已有Camera操作）先获取后修改配置信息：URL，用户名，密码。
		public void SetConfiguration(object config)
		{
            JPEGConfiguration cfg = (JPEGConfiguration)config;    //config为已有配置信息
			if (cfg != null)
			{
				urlBox.Text = cfg.source;
				loginBox.Text = cfg.login;
				passwordBox.Text = cfg.password;
				rateCombo.SelectedIndex = Array.IndexOf(frameIntervals, cfg.frameInterval);
			}
		}

        // URL输入框改变后的事件
		private void urlBox_TextChanged(object sender, EventArgs e)
		{
            completed = (urlBox.TextLength != 0);    //当url输入框有数据输入时，completed为true。
            // 添加事件触发
			if (StateChanged != null)  
				StateChanged(this, new EventArgs());
		}
	}
}


