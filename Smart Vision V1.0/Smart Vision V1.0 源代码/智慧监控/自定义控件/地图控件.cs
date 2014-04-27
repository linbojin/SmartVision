using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Net;


namespace IPCamera
{
    public partial class 地图控件 : UserControl
    {
        #region 变量定义
        object[] arg = new object[4];
        string ConStr = "Provider=Microsoft.jet.OLEDB.4.0;Data source=" + Application.StartupPath + "\\Location.mdb";
        string sql;
        OleDbConnection con;
        OleDbDataAdapter thisAdapter;
        OleDbCommandBuilder thisBuilder;
        DataSet thisDataSet;
        #endregion

        #region 初始化窗体
        public 地图控件()
        {
            InitializeComponent();
            con = new OleDbConnection(ConStr);
            timer1.Interval = 10000;
            timer1.Start();
            gettree();
        }
        private void wfGMap_Load(object sender, EventArgs e)
        {
            string stPath = Application.StartupPath.ToString() + "\\Worldmap.html";
            wbGMap.Navigate(stPath);
            wbGMap.Document.MouseUp += new HtmlElementEventHandler(Document_MouseUp);
        }

        private void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Right)
            {
                摄像头地理信息 a = new 摄像头地理信息();
                a.ShowDialog();
            }

        }
        #endregion

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            gettree();
        }

        private void gettree()
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                treeView1.Nodes.Clear();
                sql = "select * from Location where 经度 is not null";
                thisAdapter = new OleDbDataAdapter(sql, con);
                thisBuilder = new OleDbCommandBuilder(thisAdapter);
                thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "Location");
                for (int i = 0; i < thisDataSet.Tables[0].Rows.Count; i++)
                {
                    TreeNode CountNode = new TreeNode(thisDataSet.Tables[0].Rows[i][5].ToString());
                    treeView1.Nodes.Add(CountNode);
                }
            }
            con.Close();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.treeView1.SelectedNode.Text == "")
                {
                    return;
                }
            }
            catch (SystemException)
            { 
                return;
            }               
            string[] strGPS = new string[4];
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sql = "select * from Location where 名称 ='" + this.treeView1.SelectedNode.Text + "'";
                thisAdapter = new OleDbDataAdapter(sql, con);
                thisBuilder = new OleDbCommandBuilder(thisAdapter);
                thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "Location");
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        strGPS[j] = thisDataSet.Tables[0].Rows[i][j].ToString();
                    }
                    arg[0] = (object)strGPS[0];
                    arg[1] = (object)strGPS[1];
                    arg[2] = (object)strGPS[2];
                    arg[3] = (object)strGPS[3];
                    wbGMap.Document.InvokeScript("movemarker", arg);
                }
            }
            con.Close();
        }

    }
}
