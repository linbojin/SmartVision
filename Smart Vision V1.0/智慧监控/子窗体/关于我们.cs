using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPCamera
{
    public partial class 关于我们 : Form
    {
        public 关于我们()
        {
            InitializeComponent();
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "mailto:rainbow203@126.com");  //不知道干嘛的，之后查资料补上。
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)   //点击超链接，连接。
        {
            try
            {
                linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            }
            catch (Exception )
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void button1_Click(object sender, EventArgs e)     //关闭窗口
        {
            Close();
        }

        private void 关于我们_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 220);
        }
    }
}
