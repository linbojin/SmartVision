using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;  //结束所有进程

using AForge.Vision.Motion;
using AForge.Imaging;

namespace IPCamera
{
    public partial class 智慧监控 : Form
    {
        #region 成员变量

        private static string title = "Smart Vision"; 
        private Configuration config = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));
        private RunningPool runningPool = new RunningPool();
        private FinalizationPool finalizationPool = new FinalizationPool();
        
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data source=" + Application.StartupPath + @"\Location.mdb");

        CameraCGI cameraCGI = new CameraCGI();    // EasyN IP Camera接口
        private int CountCamera = 0;
        private Camera cameraToEdit;
        private Camera cameraRecording;
        private Camera cameraDetecting;

        private View SelectedView;
        private bool ViewOpened = false;
        private int openedID;
        private View View1 = new View("1个页面");
        private View View2 = new View("2个页面");
        private View View3 = new View("3个页面");
        private View View4 = new View("4个页面");
        private View View9 = new View("9个页面");

        // 监测用变量
        private bool jiance = false;          // true 打开监测功能
        private int CountVedio = 0;
        private bool zhuapai = false;         // true 打开定时抓拍功能  
        private int CountPhoto = 0;
        public static bool luzhi1 = false;    // luzhi1 == true 正在录制

        public static MotionDetector detector = null;
        public static float motionLevel = 0;
        private float motionAlarmLevel = 0.015f;    //设定监测灵敏度



        private bool windowCreate = true;     //后台运行
        private bool flag = true;
        private const int statLength = 15;
        private int statIndex = 0, statReady = 0;
        private long[] statReceived = new long[statLength];
        private int[] statCount = new int[statLength];


        摄像头信息 cameraInfo;
        地图控件 map;

        #endregion

        #region 加载关闭窗体，初始化函数

        // 构造函数
        public 智慧监控()
        {
            InitializeComponent();
        }

        //初始化5种页面
        private void ViewInit()
        {
            View1.Rows = 1;
            View1.Cols = 1;
            View2.Rows = 1;
            View2.Cols = 2;
            View3.Rows = 1;
            View3.Cols = 3;
            View4.Rows = 2;
            View4.Cols = 2;
            View9.Rows = 3;
            View9.Cols = 3;
            config.AddView(View1);
            config.AddView(View2);
            config.AddView(View3);
            config.AddView(View4);
            config.AddView(View9);
        }

        // 加载窗体
        private void 智慧监控_Load(object sender, EventArgs e)
        {
            // 创建历史数据存放文件夹，存放视频和图片
            CreatDataFiles();
            SmartVision.Visible = true;
            if (config.LoadSettings())
            {
                this.Location = config.mainWindowLocation;
                this.Size = config.mainWindowSize;
                FitToScreen(config.fitToScreen);
                if (config.fullScreen)
                FullScreen(config.fullScreen);
            }
            ViewInit();
            config.providers.Load(Path.GetDirectoryName(Application.ExecutablePath));
            finalizationPool.Start();
        }

        // 关闭窗体
        private void 智慧监控_FormClosing(object sender, FormClosingEventArgs e)
        {
            SmartVision.Visible = false;
            if (!config.fullScreen)
            {
                config.mainWindowLocation = this.Location;
                config.mainWindowSize = this.Size;
            }
            config.SaveSettings();
            multiplexer.CamerasVisible = false;
            Camera_exit();
        }

        #endregion

        #region 主菜单栏选项

        // 文件->退出
        private void tsmi退出_Click(object sender, EventArgs e)
        {
            Camera_exit();
        }
        // 文件->后台运行
        private void tsmi后台运行_Click(object sender, EventArgs e)
        {
            if (windowCreate)           //?
            {
                base.Visible = false;
                windowCreate = false;
            }
            this.Hide();
            base.OnActivated(e);   //后台仍然运行
        }

        // 视图->电视模式（多页面全屏）
        private void tsmi电视模式_Click(object sender, EventArgs e)
        {
            FullScreen(!config.fullScreen);
            this.cmenu电视模式.Checked = true;
        }
        // 视图->页面模式->页面1
        private void tsmi页面1_Click(object sender, EventArgs e)
        {
            removeform();
            SelectedView = View1;
            OpenView();
        }
        // 视图->页面模式->页面2
        private void tsmi页面2_Click(object sender, EventArgs e)
        {
            removeform();
            SelectedView = View2;
            OpenView();
        }
        // 视图->页面模式->页面3
        private void tsmi页面3_Click(object sender, EventArgs e)
        {
            removeform();
            SelectedView = View3;
            OpenView();
        }
        // 视图->页面模式->页面4
        private void tsmi页面4_Click(object sender, EventArgs e)
        {
            removeform();
            SelectedView = View4;
            OpenView();
        }
        // 视图->页面模式->页面9
        private void tsmi页面9_Click(object sender, EventArgs e)
        {
            removeform();
            SelectedView = View9;
            OpenView();
        }

        // 摄像头->添加摄像头
        private void tsmi增加摄像头_Click(object sender, EventArgs e)
        {
            removeform();
            AddCamera();
        }
        // 摄像头->配置摄像头
        private void tsmi配置摄像头_Click(object sender, EventArgs e)
        {
            removeform();
            EditCamera();
        }
        // 摄像头->移除摄像头
        private void tsmi移除摄像头_Click(object sender, EventArgs e)
        {
            removeform();
            DeleteCamera();
        }
        // 摄像头->摄像头属性
        private void tsmi摄像头属性_Click(object sender, EventArgs e)
        {
            removeform();
            LookCamera();
        }

        // 监控->拍照
        private void tsmi拍照_Click(object sender, EventArgs e)
        {
            takephoto();
        }
        // 监控->录制
        private void tsmi录制_Click(object sender, EventArgs e)
        {
            records();
        }
        // 监控->定时抓拍
        private void tsmi定时抓拍_Click(object sender, EventArgs e)
        {
            takepictures();
        }
        // 监控->异常监测
        private void tsmi异常监测_Click(object sender, EventArgs e)
        {
            detection();
        }
        // 监控->历史回放
        private void tsmi历史回放_Click(object sender, EventArgs e)
        {
            callback();
        }
        // 监控->电子地图
        private void tsmi电子地图_Click(object sender, EventArgs e)
        {
            take_map();
        }

        // 报警->移动布防
        private void tsmi移动布防_Click(object sender, EventArgs e)
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
            }
            else if ( cameraToEdit.Provider.Name == "EasyN IP Camera")
            {
                报警设置 setbao = new 报警设置();
                setbao.CamCGI.ConCam = cameraToEdit;
                setbao.CamCGI.bangding();
                setbao.Show();
                setbao.TopMost = true;
            }
            else
            {
                MessageBox.Show("此功能只对 EasyN IP Camera 开放");
            }         
        }
        // 报警->邮件报警
        private void tsmi邮件报警_Click(object sender, EventArgs e)
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
            }
            else if (cameraToEdit.Provider.Name == "EasyN IP Camera")
            {
                报警邮件 youjian = new 报警邮件();
                youjian.CamCGI.ConCam = cameraToEdit;
                youjian.CamCGI.bangding();
                youjian.Show();
                youjian.TopMost = true;
            }
            else
            {
                MessageBox.Show("此功能只对 EasyN IP Camera 开放");
            }               
        }

        // 帮助->关于我们
        private void tsmi关于我们_Click(object sender, EventArgs e)
        {
            关于我们 form = new 关于我们();
            form.Show();
            form.TopMost = true;
        }

        #endregion

        #region 工具栏选项

        // 工具栏按钮
        private void ts工具栏_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "添加摄像头":        
                    removeform();
                    AddCamera();
                    break;
                case "配置摄像头":      
                    removeform();
                    EditCamera();
                    break;
                case "视图模式":
                    break;
                case "   录制   ":
                    records();
                    break;
                case " 停止录制 ":
                    records();
                    break;
                case " 定时抓拍 ":
                    takepictures();                   
                    break;
                case " 停止抓拍 ":
                    takepictures();
                    break;
                case " 异常监测 ":
                    detection(); 
                    break;
                case " 停止监测 ":
                    detection(); 
                    break;
                case "   拍照   ":
                    takephoto();
                    break;
                case " 历史回放 ":
                    callback();
                    break;
                case " 电子地图 ":
                    take_map();
                    break;
                default:
                    return;
            }
        }

        //视图模式
        private void tsb视图模式_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            removeform();
            switch (e.ClickedItem.Text)
            {
                case "1个页面":                
                    SelectedView = View1;
                    tsmi页面1.Checked = true;
                    break;
                case "2个页面":
                    SelectedView = View2;
                    tsmi页面2.Checked = true;
                    break;
                case "3个页面":
                    SelectedView = View3;
                    tsmi页面3.Checked = true;
                    break;
                case "4个页面":
                    SelectedView = View4;
                    tsmi页面4.Checked = true;
                    break;
                case "9个页面":
                    SelectedView = View9;
                    tsmi页面9.Checked = true;
                    break;
                default:
                    return;
            }
            OpenView();
        }

        // 工具栏获取焦点，防止点击无法激活功能
        private void ts工具栏_MouseEnter(object sender, EventArgs e)
        {
            ts工具栏.Focus();
        }

        // 视图模式改变
        private void changeView()
        {
            removeform();
            if (tsmi页面1.Checked == true)
            {
                SelectedView = View2;
                tsmi页面2.Checked = true;
            }
            else if (tsmi页面2.Checked)
            {
                SelectedView = View3;
                tsmi页面3.Checked = true;
            }
            else if (tsmi页面3.Checked)
            {
                SelectedView = View4;
                tsmi页面4.Checked = true;
            }
            else if (tsmi页面4.Checked)
            {
                SelectedView = View9;
                tsmi页面9.Checked = true;
            }
            else if (tsmi页面9.Checked)
            {
                SelectedView = View1;
                tsmi页面1.Checked = true;
            }
            OpenView();
        }
        #endregion

        #region 右键菜单选项

        // 右键->电视模式
        private void cmenu电视模式_Click(object sender, EventArgs e)
        {
            FullScreen(!config.fullScreen);
        }

        // 右键->摄像头属性
        private void cmenu摄像头信息_Click(object sender, EventArgs e)
        {
            LookCamera();
        }

        // 右键->图像参数设置
        private void cmenu图像参数_Click(object sender, EventArgs e)
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
            }
            else if (cameraToEdit.Provider.Name == "EasyN IP Camera")
            {
                图像参数设置 Graph = new 图像参数设置();
                cameraToEdit = multiplexer.LastClicked.Camera;
                Graph.CamCGI.ConCam = cameraToEdit;
                Graph.CamCGI.bangding();
                Graph.Show();
            }
            else
            {
                MessageBox.Show("此功能只对 EasyN IP Camera 开放");
            }               
        }

        // 右键->打开摄像头
        private void cmenu打开摄像头_Click(object sender, EventArgs e)
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }

            cameraToEdit = multiplexer.LastClicked.Camera;
            OpenCamera();
        }

        // 右键->关闭摄像头
        private void cmenu关闭摄像头_Click(object sender, EventArgs e)
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }

            cameraToEdit = multiplexer.LastClicked.Camera;
            CloseCamera();
        }

        #endregion



        #region 摄像头Camera操作函数

        // 增加摄像头
        private void AddCamera()
        {
            摄像头新增窗体 form = new 摄像头新增窗体();
            // 设置提供商
            form.VideoProviders = config.providers;
            // 设置回调函数，用于测试摄像头
            form.CheckCameraFunction = new CheckCameraHandler(CheckCamera);

            // 显示界面
            if (form.ShowDialog() == DialogResult.OK)
            {
                CountCamera++;      //统计已经添加的摄像头数
                Camera camera = form.Camera;
                config.AddCamera(camera);
                cameraToEdit = camera;
                switch (CountCamera)
                {
                    case 1:
                        View1.SetCamera(0, 0, camera.ID);
                        View2.SetCamera(0, 0, camera.ID);
                        View3.SetCamera(0, 0, camera.ID);
                        View4.SetCamera(0, 0, camera.ID);
                        View9.SetCamera(0, 0, camera.ID);
                        SelectedView = View1;
                        break;
                    case 2:
                        View2.SetCamera(0, 1, camera.ID);
                        View3.SetCamera(0, 1, camera.ID);
                        View4.SetCamera(0, 1, camera.ID);
                        View9.SetCamera(0, 1, camera.ID);
                        SelectedView = View2;
                        break;
                    case 3:
                        View3.SetCamera(0, 2, camera.ID);
                        View4.SetCamera(1, 0, camera.ID);
                        View9.SetCamera(0, 2, camera.ID);
                        SelectedView = View3;
                        break;
                    case 4:
                        View4.SetCamera(1, 1, camera.ID);
                        View9.SetCamera(1, 0, camera.ID);
                        SelectedView = View4;
                        break;
                    case 5:
                        View9.SetCamera(1, 1, camera.ID);
                        SelectedView = View9;
                        break;
                    case 6:
                        View9.SetCamera(1, 2, camera.ID);
                        SelectedView = View9;
                        break;
                    case 7:
                        View9.SetCamera(2, 0, camera.ID);
                        SelectedView = View9;
                        break;
                    case 8:
                        View9.SetCamera(2, 1, camera.ID);
                        SelectedView = View9;
                        break;
                    case 9:
                        View9.SetCamera(2, 2, camera.ID);
                        SelectedView = View9;
                        break;
                    default: break;
                }
                OpenView();
            }
        }

        // 配置摄像头
        private void EditCamera()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }

            摄像头配置窗体 form = new 摄像头配置窗体();
            //设置提供商
            form.VideoProviders = config.providers;
            form.CheckCameraFunction = new CheckCameraHandler(CheckCamera);
            //设置摄像头
            form.Camera = cameraToEdit = multiplexer.LastClicked.Camera;

            //注册apply事件
            form.Apply += new EventHandler(editCamera_Apply);   
            if (form.ShowDialog() == DialogResult.OK)
            {
                runningPool.Remove(cameraToEdit);        //先把摄像头移除，以防前后两个同时存在。
                finalizationPool.Remove(cameraToEdit);
                cameraToEdit = form.Camera;
                OpenCamera();
            }
        }
        // btn应用_Click>>Apply(this, new EventArgs());激发事件执行此函数
        private void editCamera_Apply(object sender, EventArgs e)   
        {
            if (((配置窗体模板)sender).SelectedPageIndex == 1)     //第二配置界面
            {
                runningPool.Remove(cameraToEdit);
                finalizationPool.Remove(cameraToEdit);
                OpenCamera();             
            }
        }

        // 移除摄像头
        private void DeleteCamera()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }

            if (MessageBox.Show(this, "你确定要删除这个摄像头?", "警告",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (config.DeleteCamera(cameraToEdit))
                {
                    CloseCamera();
                    config.DeleteCamera(cameraToEdit);




                    multiplexer.LastClicked.Camera = null;
                }
                else
                {
                    MessageBox.Show(this, "删除失败~", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
        }

        // 打开摄像头
        private void OpenCamera()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }

            if (runningPool.Add(cameraToEdit))
            {
                multiplexer.CamerasVisible = true;
            }
        }

        // 关闭摄像头
        private void CloseCamera()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }

            runningPool.Remove(cameraToEdit);       
            finalizationPool.Remove(cameraToEdit);
            multiplexer.LastClicked.Visible = false;
        }

        // 查看摄像头信息
        private void LookCamera()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }

            cameraInfo = new 摄像头信息();
            cameraInfo.Camera = cameraToEdit;
            cameraInfo.TopMost = config.fullScreen;
            cameraInfo.ShowDialog();

        }
        


        #endregion

        #region 页面View操作函数

        // 打开页面
        private void OpenView()
        {
            View view = SelectedView;

            for (int i = 0; i < view.Rows; i++)
            {
                for (int j = 0; j < view.Cols; j++)
                {
                    // 获取摄像头
                    Camera camera = config.cameras.GetCamera(view.GetCamera(i, j));
                    if (camera == null)
                    {
                        continue;
                    }
                    finalizationPool.Remove(camera);
                    if (runningPool.Add(camera))
                    {
                        multiplexer.SetCamera(i, j, camera);
                    }
                }
            }
            multiplexer.Rows = view.Rows;
            multiplexer.Cols = view.Cols;
            multiplexer.SingleCameraMode = false;
            multiplexer.CamerasVisible = true;
            multiplexer.CellWidth = view.CellWidth;
            multiplexer.CellHeight = view.CellHeight;
            statIndex = 0;
            statReady = 0;
            openedID = view.ID;
            ViewOpened = true;
            timer1.Start();
        }

        // 关闭页面
        private void CloseView()
        {
            if (runningPool.Count != 0)
            {
                multiplexer.CloseAll();
                multiplexer.CamerasVisible = false;
                //停止流量统计
                timer1.Stop();
                fpsPanel.Text = "";
                bpsPanel.Text = "";
                //移除所有的摄像头
                while (runningPool.Count != 0)
                {
                    Camera camera = runningPool[0];
                    runningPool.Remove(camera);
                    finalizationPool.Add(camera);
                }
                this.Text = title;
                openedID = 0;
            }
        }

        #endregion

        #region  功能实现函数

        // 拍照功能函数
        private void takephoto()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }
            removeform();
            if (cameraToEdit.Provider.Name == "EasyN IP Camera")
            {
                cameraCGI.snapshot(cameraToEdit);
            }
            else
            {
                cameraToEdit.TakePhoto();
            }
        }

        // 定时抓拍功能函数
        private void takepictures()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null && tsmi定时抓拍.Text == "定时抓拍")
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }
            removeform();
            if (tsmi定时抓拍.Text == "定时抓拍")
            {
                zhuapai = true;
                tsb监测.Text = " 停止抓拍 ";
                tsmi定时抓拍.Text = "停止抓拍";
                tsb监测.Image = Properties.Resources.monitor7;
            }
            else
            {
                zhuapai = false;
                tsb监测.Text = " 定时抓拍 ";
                tsmi定时抓拍.Text = "定时抓拍";
                tsb监测.Image = Properties.Resources.monitor5;
                CountPhoto = 0;
            }
        }

        // 录制功能函数
        private void records()
        {
            removeform();

            cameraToEdit = multiplexer.LastClicked.Camera;
                     // 把正在录制的摄像头存入变量,关闭录制时调用
            if (cameraToEdit == null && tsmi录制.Text == "录制")  //在录制当中也有可能，cameraToEdit == null
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }
            if (tsmi录制.Text == "录制")
            {
                cameraRecording = cameraToEdit;  
                RecordOpen();       //开始录制
                tsb录制.Text = " 停止录制 ";
                tsb录制.Image = ((System.Drawing.Image)(resource.GetObject("stop.Image")));
                tsmi录制.Text = "停止录制";
            }
            else
            {
                cameraToEdit = cameraRecording;
                RecordClose();      //停止录制
                tsb录制.Text = "   录制   ";
                tsb录制.Image = ((System.Drawing.Image)(resource.GetObject("tsb录制.Image")));
                tsmi录制.Text = "录制";
            }
        }
        // 开始录像
        public void RecordOpen()
        {
            cameraToEdit.RecordOpen();
            timer3.Enabled = true;        //录制 间隔40ms 确保1秒25帧
        }
        // 关闭录像
        public void RecordClose()
        {
            timer3.Enabled = false;       //先停止计时加帧再关闭avi文件
            cameraToEdit.RecordClose();
        }



        // 异常监测功能函数    
        private void detection()
        {
            cameraToEdit = multiplexer.LastClicked.Camera;
            if (cameraToEdit == null && jiance == false)
            {
                MessageBox.Show("你当前没有选中摄像头！");
                return;
            }
            removeform();

            if (jiance == false) 
            {  
                // 开始监测
                cameraToEdit = multiplexer.LastClicked.Camera;
                cameraDetecting = cameraToEdit;                 // 存放监测的摄像头
                tsb异常监测.Image = Properties.Resources.camera7;
                detector = new MotionDetector(new TwoFramesDifferenceDetector());
                jiance = true;
                tsb异常监测.Text = " 停止监测 ";
                tsmi异常监测.Text = "停止监测";
            }
            else
            {  
                // 关闭监测
                detector = null;
                tsb异常监测.Image = Properties.Resources.camera5;
                jiance = false;
                tsb异常监测.Text = " 异常监测 ";
                tsmi异常监测.Text = "异常监测";

                if (luzhi1 == true)
                {
                    CountVedio = 0;
                    cameraToEdit = cameraDetecting;
                    RecordClose();
                    luzhi1 = false;
                    timer2.Enabled = true;
                    MainForm.Instance().ShowForm();
                }
                //  timer2.Enabled = true;
                // MainForm.Instance().ShowForm();
            }
        }

        // 历史回放功能函数
        private void callback()
        {
            CreatDataFiles();
            播放器 fram = new 播放器();
            fram.Show();
        }

        // 电子地图功能函数
        private void take_map()
        {
            map = new 地图控件();
            panel1.Controls.Add(map);
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            map.Show();
            map.BringToFront();
        }

        // 程序退出函数
        private void Camera_exit()
        {
            Process.GetCurrentProcess().Kill();     //结束程序的所有进程，防止有个别进程在后台运行。
            multiplexer.CloseAll();
            CloseView();
            finalizationPool.Stop();
            Thread.Sleep(1000);
            Application.Exit();
        }



        // 创建历史数据存放文件夹
        private void CreatDataFiles()
        {
            //创建多媒体数据存放路径
            string str = Application.StartupPath + @"\SmartVision";      //路径的正确写法 
            if (Directory.Exists(str))                                   //如果不存在就创建file文件夹 
            {
            }
            else
            {
                Directory.CreateDirectory(str);                           //创建该文件夹 
            }
            string str1 = Application.StartupPath + @"\SmartVision\视频"; //路径的正确写法 
            if (Directory.Exists(str1))                                   //如果不存在就创建file文件夹 
            {
            }
            else
            {
                Directory.CreateDirectory(str1);                          //创建该文件夹 
            }
            string str2 = Application.StartupPath + @"\SmartVision\图片"; //路径的正确写法 
            if (Directory.Exists(str2))                                   //如果不存在就创建file文件夹 
            {
            }
            else
            {
                Directory.CreateDirectory(str2);                          //创建该文件夹 
            }
        }

        // 全屏显示
        private void FullScreen(bool full)
        {
            config.fullScreen = full;
            if (full)
            {
                config.mainWindowLocation = this.Location;
                config.mainWindowSize = this.Size;
                this.FormBorderStyle = FormBorderStyle.None;
                int cx = Win32.GetSystemMetrics(Win32.SystemMetrics.CXSCREEN);
                int cy = Win32.GetSystemMetrics(Win32.SystemMetrics.CYSCREEN);
                this.Location = new Point(0, 0);
                this.Size = new Size(cx, cy);
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Location = config.mainWindowLocation;
                this.Size = config.mainWindowSize;
            }
            bool visible = !full;
            this.TopMost = full;
            this.mainMenu主菜单.Visible = visible;
            this.ts工具栏.Visible = visible;
            this.statusBar1.Visible = visible;
        }

        // 自适应窗体显示
        private void FitToScreen(bool fit)
        {
            config.fitToScreen = fit;
        }

        // 检查摄像头是否已经存在
        private bool CheckCamera(Camera camera)
        {
            return config.CheckCamera(camera);
        }

        // 移除地图界面
        private void removeform()
        {
            try
            {
                panel1.Controls.Remove(map);
            }
            catch (System.Exception)
            {
            }
        }

        // 右下角报警图标组件
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainForm.Instance().CloseForm();
            timer2.Enabled = false;
            SmartVision.Icon = Properties.Resources._1;
            if (windowCreate)
            {
                base.Visible = false;
                windowCreate = false;
            }
            this.Show();
            base.OnActivated(e);
        }

        #endregion

        #region 定时器




        // 定时器1——流量统计 
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 定时抓拍功能
            if (zhuapai == true)
            {
                CountPhoto++;
                if (CountPhoto == 6)
                {
                    takephoto();
                    CountPhoto = 0;
                }
            }

            // 异常监测功能
            if (jiance == true)
            {
                if (luzhi1 == false && motionLevel < 1 && motionLevel > motionAlarmLevel)
                {
                    luzhi1 = true;
                    motionLevel = 0;
                    RecordOpen();
                }
                if (luzhi1 == true)
                {
                    CountVedio++;
                    if (CountVedio == 20)
                    {
                        RecordClose();
                        CountVedio = 0;
                        cameraToEdit = cameraDetecting;
                        luzhi1 = false;
                        timer2.Enabled = true;
                        MainForm.Instance().ShowForm();
                    }
                }
            }
        
            if (runningPool.Count != 0)
            {
                float fps = 0, bps = 0;
                statCount[statIndex] = 0;
                statReceived[statIndex] = 0;
                foreach (Camera camera in runningPool)
                {
                    statCount[statIndex] += camera.FramesReceived;
                    statReceived[statIndex] += camera.BytesReceived;
                }

                if (++statIndex >= statLength)
                    statIndex = 0;
                if (statReady < statLength)
                    statReady++;

                // 计算平均值
                for (int i = 0; i < statReady; i++)
                {
                    fps += statCount[i];
                    bps += statReceived[i];
                }
                fps /= statReady;
                bps /= (statReady * 1024);

                statReceived[statIndex] = 0;
                statCount[statIndex] = 0;

                fpsPanel.Text = fps.ToString("F2") + " fps";
                bpsPanel.Text = bps.ToString("F2") + " Kb/s";
            }
        }

        // 定时器2——右下角图标闪烁定时
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (flag == false)
            {
                SmartVision.Icon = Properties.Resources._2;
                flag = true;
            }
            else
            {
                SmartVision.Icon = Properties.Resources._1;
                flag = false;
            }
        }

        // 定时器3——视频录制 间隔40ms 确保1秒25帧
        private void timer3_Tick(object sender, EventArgs e)
        {
            cameraToEdit.addFrame();
        }
        #endregion

        private void tsb视图模式_ButtonClick(object sender, EventArgs e)
        {
            changeView();
        }


    }
}

