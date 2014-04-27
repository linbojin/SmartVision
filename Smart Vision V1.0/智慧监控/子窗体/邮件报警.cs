using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace IPCamera
{
    public partial class 报警邮件 : Form
    {
        private CameraCGI camCGI = new CameraCGI();

        public 报警邮件()
        {
            InitializeComponent();
        }


        // CGI接口，用于连接摄像头
        public CameraCGI CamCGI
        {
            get { return camCGI; }
            set { camCGI = value; }
        }


        private void btn_apply_Click(object sender, EventArgs e)
        {
            string port="465";
            string user = tbx_user.Text;
            string pwd = txb_pwd.Text;
            string senders = tbx_sender.Text;
            string receiver1 = txb_receiver1.Text;
            string receiver2=txb_receiver2.Text;
            string svr;
            try { 
            string[] ss = senders.Split('@');
            svr = "smtp." + ss[1];
            }
            catch(Exception)
            {
                MessageBox.Show("你输入的邮箱有误，请重新输入！");
                return;


            }
            
            if ((senders == "") | (user == "") | (pwd=="")|(receiver1==""))
            {
                MessageBox.Show("请将信息填写完整！");
                return;
            }
            camCGI.set_mail(svr, port, user, pwd, senders, receiver1,receiver2);
            this.Close();
        }

        private void but_delet_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
