using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using videosource;

namespace EasyN
{
    public partial class EasyNCameraSetupPage : UserControl,IVideoSourcePage
    {
        private static int[] frameIntervals = new int[] {0, 100, 142, 200, 333, 1000,5000, 10000, 15000, 20000, 30000, 60000};
        private static int[] rates = new int[] { 0, 1, 3, 6, 11, 12, 13, 14, 15, 17, 19, 21, 23 };
		private static StreamType[] streamTypes = new StreamType[] {StreamType.Jpeg, StreamType.MJpeg};
		private bool completed = false;
        // 新增事件
		public event EventHandler StateChanged;

        // 完成属性 
		public bool Completed
		{
			get { return completed; }
		}

         public EasyNCameraSetupPage()
        {
            InitializeComponent();
			cbStream.SelectedIndex = 0;
			cbFrame.SelectedIndex = 0;
			cbRate.SelectedIndex = 0;
        }

		// 显示页面
		public void Display()
		{
			txtURL.Focus();
			txtURL.SelectionStart = txtURL.TextLength;
		}

        // 应用配置
		public bool Apply()
		{
			return true;
		}

        // （创建Camera或修改Camera时）获得配置信息
		public object GetConfiguration()
		{
			EasyNConfiguration	config = new EasyNConfiguration();

			config.source	= txtURL.Text;
			config.login	= txtName.Text;
			config.password	= txtPsw.Text;
			config.stremType = streamTypes[cbStream.SelectedIndex];
            config.rate = rates[cbRate.SelectedIndex];
			config.frameInterval = frameIntervals[cbFrame.SelectedIndex];

			return (object) config;
		}

        // （对已有Camera操作）先获取后修改配置信息
		public void SetConfiguration(object config)
		{
			EasyNConfiguration	cfg = (EasyNConfiguration) config;

			if (cfg != null)
			{
				txtURL.Text = cfg.source;
				txtName.Text = cfg.login;
				txtPsw.Text = cfg.password;
				cbStream.SelectedIndex = Array.IndexOf(streamTypes, cfg.stremType);
                cbRate.SelectedIndex = Array.IndexOf(rates, cfg.rate);
				cbFrame.SelectedIndex = Array.IndexOf(frameIntervals, cfg.frameInterval);
			}
		}

        // URL输入框改变后的事件
		private void txtURL_TextChanged(object sender, System.EventArgs e)
		{
            completed = (txtURL.TextLength != 0);   //当url输入框有数据输入时，completed为true。
            // 添加事件触发
			if (StateChanged != null)
				StateChanged(this, new EventArgs());
		}

		// 视频流类型改变来选择配置项
		private void cbStream_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbFrame.Enabled = (cbStream.SelectedIndex == 0);
            cbRate.Enabled = (cbStream.SelectedIndex == 1);
		}
	}
}

















