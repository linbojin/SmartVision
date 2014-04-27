using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace IPCamera
{
    public partial class 登入界面 : Form
    {
        #region  初始化界面
        public 登入界面()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void 登入界面_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; //设置窗体无边框   f.ShowInTaskbar = false;
            this.TransparencyKey = this.BackColor; //让窗体透明  
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent; 
        }

        private void 登入界面_Activated(object sender, EventArgs e)
        {
            textName.Focus();
        }
        #endregion

        #region  单击按钮事件
        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {

            string reportPath = Application.StartupPath;
            reportPath += @"\Location.mdb";
            string ConStr = "Provider=Microsoft.jet.OLEDB.4.0;Data source=" + reportPath;
            OleDbConnection con = new OleDbConnection(ConStr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                if (textName.Text == "" | textPass.Text == "")
                {
                    MessageBox.Show("用户名或密码不能为空", "警告");
                }
                else
                {   //进行身份认证
                    string tx = "select count(*) FROM [Login] where user_id='" + this.textName.Text + "' and user_pwd='" + this.textPass.Text + "'";
                    OleDbCommand cmd = new OleDbCommand(tx, con);
                    Int32 id_e = (Int32)cmd.ExecuteScalar();
                    if (id_e > 0)
                    {
                        Program.Login = true;
                        this.Close();
                        con.Close();
                        cmd.Dispose();

                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不正确！", "请重新登录");
                    }
                }
            }
            else
            {
                MessageBox.Show("数据库链接失败！", "链接");
            }
        }
        #endregion

        #region  光标设置
        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                textPass.Focus();
        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                butLogin.Focus();
        }
        #endregion
    }
}
