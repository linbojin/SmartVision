using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using videosource;
using System.ComponentModel;

namespace IPCamera
{
    /// <summary>
    /// CameraCGI Cameracgi接口类
    /// </summary>
    public class CameraCGI
    {
        string source = "";     // 网址
        string login = "";      // 用户名
        string password = "";   // 密码
        private BackgroundWorker backgroundWorker1;
        private BackgroundWorker backgroundWorker2;
        private Camera concam;

        // 摄像头用于传递连接信息
        public Camera ConCam
        {
            get { return concam; }
            set { concam = value; }
        }
        // 绑定摄像头
        public void bangding()
        {
            try
            {
                source = concam.URL;
                login = concam.Login;
                password = concam.Password;
            }
            catch { }
        }


        /// <summary>
        /// 上下左右云台控制函数
        /// </summary>
        public void control_Up()
        {
            string controlURL = string.Format("{0}/decoder_control.cgi?command=0&onestep=1", source);
            try
            {
                cgiConnect(controlURL);
            }
            catch (System.Exception)
            {
            }
        }

        public void control_Down()
        {
            string controlURL = string.Format("{0}/decoder_control.cgi?command=2&onestep=1", source);
            try
            {
                cgiConnect(controlURL);
            }
            catch (System.Exception)
            {
            }
        }

        public void control_Left()
        {
            string controlURL = string.Format("{0}/decoder_control.cgi?command=4&onestep=1", source);
            try
            {
                cgiConnect(controlURL);
            }
            catch (System.Exception)
            {
            }
        }

        public void control_Right()
        {
            string controlURL = string.Format("{0}/decoder_control.cgi?command=6&onestep=1", source);
            try
            {
                cgiConnect(controlURL);
            }
            catch (System.Exception)
            {
            }
        }


        /// <summary>
        /// 图像传感器参数控制函数
        /// </summary>
        /// 
        // 亮度
        public void set_Brightness(int value)
        {
            string cgiURL = string.Format("{0}/camera_control.cgi?param=1&value={1}", source, value);
            try
            {
                cgiConnect(cgiURL);
            }
            catch (System.Exception)
            {
            }
        }

        // 对比度
        public void set_Contrast(int value)
        {
            string cgiURL = string.Format("{0}/camera_control.cgi?param=2&value={1}", source, value);
            try
            {
                cgiConnect(cgiURL);
            }
            catch (System.Exception)
            {
            }
        }

        // 分辨率
        public void set_Resolution(int value)
        {
            string cgiURL = string.Format("{0}/camera_control.cgi?param=0&value={1}", source, value);
            cgiConnect(cgiURL);
        }

        // 模式
        public void set_Model(int value)
        {
            string cgiURL = string.Format("{0}/camera_control.cgi?param=3&value={1}", source, value);
            try
            {
                cgiConnect(cgiURL);
            }
            catch (System.Exception)
            {
            }
        }


        /// <summary>
        /// 报警配置函数
        /// </summary>
        /// 
        //移动布防
        public void set_alarm(int value1, int value2, int value3, int value4, int value5, int value6, string value7, string value8, string value9)
        {
            string cgiURL = string.Format("{0}/set_alarm.cgi?motion_armed={1}&motion_sensitivity={2}&motion_compensation={3}&mail={4}&upload_interval={5}&http={6}&http_url={7}&user={8}&pwd={9}", source, value1, value2, value3, value4, value5, value6, value7, value8, value9);
            try
            {
                cgiConnect(cgiURL);
            }
            catch (System.Exception)
            {
            }
        }
        //设置邮件报警
        public void set_mail(string value1, string value2, string value3, string value4, string value5, string value6, string value7)
        {
            string cgiURL = string.Format("{0}/set_mail.cgi?svr={1}&port={2}&user={3}&pwd={4}&sender={5}&receiver1={6}&receiver2={7}&receiver3=&receiver4=&tls=1&mail_inet_ip=0&cam_user={8}&cam_pwd={9}n", source, value1, value2, value3, value4, value5, value6, value7, login , password);
            try
            {
                cgiConnect(cgiURL);
            }
            catch (System.Exception)
            {
            }
        }

        /// <summary>
        /// 拍照函数
        /// </summary>
        public void snapshot(Camera camera)
        {
            concam = camera;
            bangding();
            string controlURL = string.Format("{0}/snapshot.cgi?", source);
            cgiReturn(controlURL);
        }


        /// <summary>
        /// 网络连接函数
        /// </summary>
        /// 
        private void cgiConnect(string cgiURL)
        {
            backgroundWorker1 = new BackgroundWorker();      // 放在此处是为了防止“BackgroundWorker当前正忙,无法同时运行多个任务”的错误。
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync(cgiURL);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try 
            {
                BackgroundWorker bw = (BackgroundWorker)sender;
                string url = e.Argument.ToString();
                WebRequest req = WebRequest.Create(url);
                req.Credentials = new NetworkCredential(login, password);
                WebResponse resp = req.GetResponse();
                resp.Close();
            }catch(Exception)
            {
            }

        }

        /// <summary>
        /// 获取网页返回值
        /// </summary>
        /// 
        private void cgiReturn(string cgiURL)
        {
            backgroundWorker2 = new BackgroundWorker();      // 放在此处是为了防止“BackgroundWorker当前正忙,无法同时运行多个任务”的错误。
            backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            backgroundWorker2.RunWorkerAsync(cgiURL);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            string url = e.Argument.ToString();
            WebClient con = new WebClient();
            con.Encoding = Encoding.GetEncoding("gb2312");//Encoding.UTF8
            con.Credentials = new NetworkCredential(login, password);
            DateTime date = DateTime.Now;
            String fileName = String.Format("{0}-{1}-{2} {3}-{4}-{5}", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            con.DownloadFile(url, String.Format(".\\SmartVision\\图片\\Camera_Vision_{0}_{1}.jpg", concam.Name, fileName));
        }
    }
}
