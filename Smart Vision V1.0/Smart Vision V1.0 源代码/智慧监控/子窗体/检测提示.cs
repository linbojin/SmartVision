using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IPCamera
{
    public partial class MainForm :System.Windows.Forms.Form
    {
        #region 声明的变量
        private System.Drawing.Rectangle Rect;//定义一个存储矩形框的数组
        private FormState InfoStyle = FormState.Hide;//定义变量为隐藏
        static private MainForm dropDownForm = new MainForm();//实例化当前窗体
        private static int AW_HIDE = 0x00010000; //该变量表示动画隐藏窗体
        private static int AW_SLIDE = 0x00040000;//该变量表示出现滑行效果的窗体
        private static int AW_VER_NEGATIVE = 0x00000008;//该变量表示从下向上开屏
        private static int AW_VER_POSITIVE = 0x00000004;//该变量表示从上向下开屏
        #endregion

        #region 该窗体的构造方法
        public MainForm()
        {
            InitializeComponent();
            //初始化工作区大小
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.GetWorkingArea(this);//实例化一个当前窗口的对象
            this.Rect = new System.Drawing.Rectangle(rect.Right - this.Width - 1,rect.Bottom - this.Height - 1,this.Width,this.Height);//为实例化的对象创建工作区域
        }
        #endregion

        #region 调用API函数显示窗体
        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion

        #region 鼠标控制图片的变化
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[1];//设定当鼠标进入PictureBox控件时PictureBox控件的图片
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0]; //设定当鼠标离开PictureBox控件时PictureBox控件的图片
        }
        #endregion

        #region 定义标识窗体移动状态的枚举值
        protected enum FormState
        {
            //隐藏窗体
            Hide=0,
            //显示窗体
            Display=1,
            //显示窗体中
            Displaying=2,
            //隐藏窗体中
            Hiding=3
        }
        #endregion

        #region 用属性标识当前状态
        protected FormState FormNowState
        {
            get { return this.InfoStyle; }   //返回窗体的当前状态
            set { this.InfoStyle = value; }  //设定窗体当前状态的值
        }
        #endregion

        #region 显示窗体
        public  void ShowForm()
        {
            switch (this.FormNowState)
            {
                case FormState.Hide:
                    if (this.Height <= this.Rect.Height - 192)//当窗体没有完全显示时
                        this.SetBounds(Rect.X, this.Top - 192, Rect.Width, this.Height + 192);//使窗体不断上移
                    else
                    {
                        this.SetBounds(Rect.X,Rect.Y,Rect.Width,Rect.Height);//设置当前窗体的边界
                    }
                    AnimateWindow(this.Handle, 800, AW_SLIDE + AW_VER_NEGATIVE);//动态显示本窗体
                    break;
            }
        }
        #endregion

        #region 关闭窗体
        public void CloseForm()
        {
            AnimateWindow(this.Handle,800,AW_SLIDE + AW_VER_POSITIVE + AW_HIDE); //动画隐藏窗体
            this.FormNowState = FormState.Hide;//设定当前窗体的状态为隐藏
        }
        #endregion

        #region 返回当前窗体的实例化对象
        static public MainForm Instance()
        {
            return dropDownForm; //返回当前窗体的实例化对象
        }
        #endregion

    }
}
