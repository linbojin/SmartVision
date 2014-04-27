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
    public partial class 报警设置 : Form
    {
        int motion_armed = 1;
        int motion_sensitivity = 4;
        int motion_compensation = 1;
        int mail = 1;
        int upload_interval = 20;
        int http = 1;
        string http_url = "www.baidu.com";
        string user = "admin";
        string pwd = "admin";
        CameraCGI camCGI = new CameraCGI();


        public 报警设置()
        {
            InitializeComponent();
        }

        // CGI接口，用于连接摄像头
        public CameraCGI CamCGI
        {
            get { return camCGI; }
            set { camCGI = value; }
        }

        private void but_Del_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Ok_Click(object sender, EventArgs e)
        {
            if (ckb_Ydbf.Checked == true)
            {
                motion_armed = 1;
            }
            else
            {
                motion_armed = 0;
            }
            if (cbx_Nmd.Text == "")
            {
                motion_sensitivity = 0;
            }
            else
            {
                motion_sensitivity = System.Int32.Parse(cbx_Nmd.Text);       //cbx_Nmd.Text;
            }
            if (ckb_mail.Checked == true)
            {
                mail = 1;
            }
            else
            {
                mail = 0;
            }
            if (tbx_Time.Text == "")
            {
                upload_interval = 0;
            }
            else
            {
                upload_interval = System.Int32.Parse(tbx_Time.Text);       //cbx_Nmd.Text;
            }
            if (ckb_message.Checked == true)
            {
                http = 1;
            }
            else
            {
                http = 0;
            }
            http_url = txb_Url.Text;
            camCGI.set_alarm(motion_armed, motion_sensitivity, motion_compensation, mail, upload_interval, http, http_url, user, pwd);
            this.Close();
        }

        private void 报警设置_Load(object sender, EventArgs e)
        {
            but_Ok.Enabled = false;
            if (ckb_Ydbf.Checked == true)
            {
                cbx_Nmd.Enabled = true;
                cbx_Nmd.Text = "1";
            }
            else 
            {
                cbx_Nmd.Enabled = false;
            }

            if (ckb_mail.Checked==true)
            {
                tbx_Time.Enabled = true;
                tbx_Time.Text = "10";
            }
            else
            {
                tbx_Time.Enabled = false;
            }
            if (ckb_message.Checked == true)
            {
                txb_Url.Enabled = true;
            }
            else
            {
                txb_Url.Enabled = false;
            }
        }

        private void ckb_Ydbf_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Ydbf.Checked == true)
            {
                but_Ok.Enabled = true;
            }
            else if ((ckb_mail.Checked == false) & (ckb_message.Checked==false))
            {
                but_Ok.Enabled = false;
            }
            if (ckb_Ydbf.Checked == true)
            {
                cbx_Nmd.Enabled = true;
                cbx_Nmd.Text = "1";
            }
            else
            {
                cbx_Nmd.Enabled = false;
            }
        }

        private void ckb_mail_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_mail.Checked == true)
            {
                but_Ok.Enabled = true;
            }
            else if ((ckb_Ydbf.Checked == false) & (ckb_message.Checked == false))
            {
                but_Ok.Enabled = false;
            }
            if (ckb_mail.Checked == true)
            {
                tbx_Time.Enabled = true;
            }
            else
            {
                tbx_Time.Enabled = false;
            }
        }

        private void ckb_message_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_message.Checked == true)
            {
                but_Ok.Enabled = true;
            }
            else if ((ckb_Ydbf.Checked == false) & (ckb_mail.Checked == false))
            {
                but_Ok.Enabled = false;
            }
            if (ckb_message.Checked == true)
            {
                txb_Url.Enabled = true;
            }
            else
            {
                txb_Url.Enabled = false;
            }
        }
        private void tbx_Time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }

    }
}
