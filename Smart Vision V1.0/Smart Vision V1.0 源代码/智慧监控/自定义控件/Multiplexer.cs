using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;


namespace IPCamera
{
    /// <summary>
    /// Multiplexer 多路通道视频类
    /// </summary>
    public partial class Multiplexer : Panel
    {
        private const int MaxRows = 3;
        private const int MaxCols = 3;
        private CameraWindow[,] camWindows;

        private bool fitToWindow = true;
        private bool singleCameraMode = true;
        private bool camerasVisible = true;

        private int rows = 1;
        private int cols = 1;
        private int cellWidth = 320;
        private int cellHeight = 240;

        private CameraWindow lastClicked;
        private bool fullScreen = false;
        private Point WindowLocation = new Point(100, 50);
        private Size WindowSize = new Size(800, 600);
        private bool controlHandle = false;                     // 云台控制

        public Multiplexer()
        {
            InitializeComponent();
            lastClicked = cameraWindow1;

            camWindows = new CameraWindow[MaxRows, MaxCols];
            camWindows[0, 0] = cameraWindow1;
            camWindows[0, 1] = cameraWindow2;
            camWindows[0, 2] = cameraWindow3;
            camWindows[1, 0] = cameraWindow4;
            camWindows[1, 1] = cameraWindow5;
            camWindows[1, 2] = cameraWindow6;
            camWindows[2, 0] = cameraWindow7;
            camWindows[2, 1] = cameraWindow8;
            camWindows[2, 2] = cameraWindow9;
        }

        // 最后选中的CameraWindow
        public CameraWindow LastClicked
        {
            get { return lastClicked; }
        }

        // 自适应窗体大小 属性
        [DefaultValue(true)]
        public bool FitToWindow
        {
            get { return fitToWindow; }
            set
            {
                fitToWindow = value;

                if ((camWindows[0, 0].AutoSize = (!fitToWindow && singleCameraMode)) == true)
                {
                    camWindows[0, 0].UpdatePosition();
                }
                else
                {
                    UpdateSize();
                }
            }
        }

        // 1个页面 属性
        [DefaultValue(true)]
        public bool SingleCameraMode
        {
            get { return singleCameraMode; }
            set
            {
                singleCameraMode = value;
                if (!fitToWindow)
                    camWindows[0, 0].AutoSize = value;
            }
        }

        // 摄像头可见 属性
        [DefaultValue(true)]
        public bool CamerasVisible
        {
            get { return camerasVisible; }
            set
            {
                camerasVisible = value;

                // 显示和隐藏所有camera
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        camWindows[i, j].Visible = value;
                    }
                }
            }
        }

        // 行属性
        [DefaultValue(1)]
        public int Rows
        {
            get { return rows; }
            set
            {
                rows = Math.Max(1, Math.Min(MaxRows, value));
                UpdateVisiblity();
                UpdateSize();
            }
        }

        // 列属性
        [DefaultValue(1)]
        public int Cols
        {
            get { return cols; }
            set
            {
                cols = Math.Max(1, Math.Min(MaxCols, value));
                UpdateVisiblity();
                UpdateSize();
            }
        }

        // 子页面宽度
        [DefaultValue(320)]
        public int CellWidth
        {
            get { return cellWidth; }
            set
            {
                cellWidth = Math.Max(50, Math.Min(800, value));
                UpdateSize();
            }
        }

        // 子页面高度
        [DefaultValue(240)]
        public int CellHeight
        {
            get { return cellHeight; }
            set
            {
                cellHeight = Math.Max(50, Math.Min(800, value));
                UpdateSize();
            }
        }

        // 视频窗体上下文菜单
        [DefaultValue(null)]
        public ContextMenu CamerasContextMenu
        {
            get { return camWindows[0, 0].ContextMenu; }
            set
            {
                for (int i = 0; i < MaxRows; i++)
                {
                    for (int j = 0; j < MaxCols; j++)
                    {
                        camWindows[i, j].ContextMenu = value;
                    }
                }
            }
        }

        //// 最后选中的摄像头，是否应该显示在右键菜单中
        //[Browsable(false)]
        //public Camera ContextCamera
        //{
        //    get { return (lastClicked == null) ? null : lastClicked.Camera; }
        //}

        // 关闭所有camWindows中的摄像头
        public void CloseAll()
        {
            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxCols; j++)
                {
                    camWindows[i, j].Camera = null;
                }
            }
        }

        // 设置摄像头在面板中位置
        public void SetCamera(int row, int col, Camera camera)
        {
            if ((row >= 0) && (col >= 0) && (row < MaxRows) && (col < MaxCols))
            {
                camWindows[row, col].Camera = camera;
            }
        }

        // 设置面板尺寸
        public void SetSize(int rows, int cols, int cellWidth, int cellHeight)
        {
            this.rows = rows;
            this.cols = cols;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;
            UpdateSize();
        }

        // 更新摄像头可见性
        private void UpdateVisiblity()
        {
            if (camerasVisible)
            {
                for (int i = 0; i < MaxRows; i++)
                {
                    for (int j = 0; j < MaxCols; j++)
                    {
                        camWindows[i, j].Visible = ((i < rows) && (j < cols));
                    }
                }
            }
        }

        // 更新摄像头大小和位子
        private void UpdateSize()
        {
            int width, height;

            if (!fitToWindow)
            {
                // 原始宽度和高度
                width = cellWidth;
                height = cellHeight;
            }
            else
            {
                // 计算适应窗体的宽高
                width = (ClientRectangle.Width / cols) - 4;
                height = (ClientRectangle.Height / rows) - 4;
            }

            // 定位，子页面
            int startX = (ClientRectangle.Width - cols * (width + 4)) / 2;
            int startY = (ClientRectangle.Height - rows * (height + 4)) / 2;

            this.SuspendLayout();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    camWindows[i, j].Location = new Point(startX + (width + 4) * j + 1, startY + (height + 4) * i + 1);
                    camWindows[i, j].Size = new Size(width + 2, height + 2);
                }
            }

            this.ResumeLayout(false);
        }

        // 窗体大小改变
        private void Multiplexer_Resize(object sender, EventArgs e)
        {
            UpdateSize();
        }

        // 鼠标选中，确定最后选中的摄像头
        private void cameraWindow_MouseDown(object sender, MouseEventArgs e)
        {
            controlHandle = false;
            lastClicked.Control_Handle.Visible = controlHandle;
            lastClicked = (CameraWindow)sender;
            lastClicked.Focus();
        }

        // 鼠标选中，确定最后选中的摄像头
        private void cameraWindow_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(!fullScreen);
        }

        // 空格键关闭打开云台控制键
        private void cameraWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && lastClicked.Camera != null && lastClicked.Camera.Provider.Name == "EasyN IP Camera")    //e.KeyChar == 32 空格键
            {
                controlHandle = !controlHandle;
                lastClicked.Control_Handle.Visible = controlHandle;
                lastClicked.Control_Handle.CamCGI.ConCam = lastClicked.Camera;   // 最后选中的摄像头绑定云台控制器
                lastClicked.Control_Handle.CamCGI.bangding();
            }
        }

        private Configuration config = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));

        // 全屏
        private void FullScreen(bool full)
        {
            fullScreen = full;
            if (full)
            {
                // 保存当前窗体位子和大小信息
                WindowLocation = lastClicked.Location;
                WindowSize = lastClicked.Size;

                lastClicked.Location = this.Location;
                lastClicked.Size = this.Size;
                lastClicked.BringToFront();
            }
            else
            {
                // 恢复窗体大小和位子
                lastClicked.Location = WindowLocation;
                lastClicked.Size = WindowSize;
            }
        }


    }
}
