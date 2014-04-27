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

namespace mjpeg
{
    /// <summary>
    /// MJPEGSourcePage 配置页面
    /// </summary>
    public partial class MJPEGSourcePage : UserControl, IVideoSourcePage       //继承了两类
    {
        // 新帧事件
        public event EventHandler StateChanged;

        // 完成属性
        public bool Completed
        {
            get { return completed; }
        }

        // 构造函数
        public MJPEGSourcePage()
        {
            InitializeComponent();
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
            MJPEGConfiguration config = new MJPEGConfiguration();
            config.source = urlBox.Text;           // URL 
            config.loginname = loginBox.Text;      // 用户名
            config.password = passwordBox.Text;    // 密码
            return (object)config;
        }

        // （对已有Camera操作）先获取后修改配置信息：URL，用户名，密码。
        public void SetConfiguration(object config)
        {
            MJPEGConfiguration cfg = (MJPEGConfiguration)config;    //config为已有配置信息
            if (cfg != null)
            {
                urlBox.Text = cfg.source;
                loginBox.Text = cfg.loginname;
                passwordBox.Text = cfg.password;
            }
        }

        // URL输入框改变后的事件
        private void urlBox_TextChanged(object sender, System.EventArgs e)
        {
            completed = (urlBox.TextLength != 0);   //当url输入框有数据输入时，completed为true。
            // 添加事件触发
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

    }
}
