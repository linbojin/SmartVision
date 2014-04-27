using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Net;

namespace IPCamera
{
    public partial class 摄像头地理信息 : Form
    {
        string ConStr = "Provider=Microsoft.jet.OLEDB.4.0;Data source=" + Application.StartupPath + "\\Location.mdb";
        string sql;
        OleDbConnection con;
        OleDbDataAdapter thisAdapter;
        OleDbCommandBuilder thisBuilder;
        DataSet thisDataSet;
        OleDbCommand objcmd;

        public 摄像头地理信息()
        {
            InitializeComponent();
            con = new OleDbConnection(ConStr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 摄像头地理信息_Load(object sender, EventArgs e)
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sql = "select * from Location where 经度 is null";
                thisAdapter = new OleDbDataAdapter(sql, con);
                thisBuilder = new OleDbCommandBuilder(thisAdapter);
                thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "Location");
                for (int i = 0; i < thisDataSet.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        comboBox1.Text = thisDataSet.Tables[0].Rows[i][5].ToString();
                    }
                    comboBox1.Items.Add(thisDataSet.Tables[0].Rows[i][5].ToString());
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text != "") && (textBox1.Text != "") && (textBox2.Text != ""))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    sql = "update [Location] set[名字]= '" + comboBox1.Text + " ',[地点]=  '" + textBox3.Text + " ',[所属区域]=  '" + textBox4.Text + "',[经度]='" + textBox1.Text + "',[纬度]='" + textBox2.Text + "' where [名称]='" + comboBox1.Text + "'";
                    objcmd = new OleDbCommand(sql, con);
                    objcmd.ExecuteNonQuery();
                }
                con.Close();
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.LastIndexOf('.') != -1)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.LastIndexOf('.') != -1)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}