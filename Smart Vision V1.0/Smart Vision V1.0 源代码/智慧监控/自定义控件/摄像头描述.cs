using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;  //IList

namespace IPCamera
{
    // Check camera delegate
    public delegate bool CheckCameraHandler(Camera camera);

    public partial class 摄像头描述 : UserControl, IWizardPage
    {
        private VideoProviderCollection providers = null;
		private Camera camera = null;
		private bool completed = false;

		// 状态改变事件
		public event EventHandler StateChanged;
		// 复位事件
		public event EventHandler Reset;
     
        public 摄像头描述()
        {
            InitializeComponent();
            BuildSourceCombo();
        }
        
		// 视频提供商 属性
		public VideoProviderCollection VideoProviders
		{
			get { return providers; }
			set
			{
				providers = value;
				BuildSourceCombo();
			}
		}

		// 背选视频源属性
		public int SelectedProviderIndex
		{
			get { return cb视频源.SelectedIndex-1; }
		}
		// 摄像头属性
		public Camera Camera
		{
			get { return camera; }
			set
			{
				if (value != null)
				{
					camera = value;

					txt名字.Text = camera.Name;
					txt描述.Text = camera.Description;

					// provider index
					if (providers != null)
                        cb视频源.SelectedIndex = ((IList)providers).IndexOf(camera.Provider) + 1;

					     cb视频源.Enabled = (camera.ID == 0);
				}
			}
		}

		// Check camera function
		private CheckCameraHandler checkCameraFunction;

		// CheckCameraFunction property
		public CheckCameraHandler CheckCameraFunction
		{
			set { checkCameraFunction = value; }
		}

        // PageName property
        public string PageName
        {
            get { return "基本信息"; }
        }

        // PageDescription property
        public string PageDescription
        {
            get { return "摄像头基本信息"; }
        }

        // Completed property
        public bool Completed
        {
            get { return completed; }
        }

        // Show the page
        public void Display()
        {
            txt名字.Focus();
            txt名字.SelectionStart = txt名字.TextLength;
        }

        // Apply the page
        public bool Apply()
        {
            string name = txt名字.Text.Replace('\\', ' ');

            if (checkCameraFunction != null)
            {
                Camera tmpCamera = new Camera(name);

                tmpCamera.ID = camera.ID;

                // check camera
                if (checkCameraFunction(tmpCamera) == false)
                {
                    Color tmp = this.txt名字.BackColor;

                    // highligh name edit box
                    this.txt名字.BackColor = Color.LightCoral;
                    // error message
                    MessageBox.Show(this, "此名字已被使用，请重新输入！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // restore & focus name edit box
                    this.txt名字.BackColor = tmp;
                    this.txt名字.Focus();

                    return false;
                }
            }

            // update camera name and description
            camera.Name = name;
            camera.Description = txt描述.Text;
            camera.Provider = providers[cb视频源.SelectedIndex - 1];

            return true;
        }

        // 构建视频源Combo
        private void BuildSourceCombo()
        {
            // 清空combo
            cb视频源.Items.Clear();

            // 添加默认项
            cb视频源.Items.Add("--请选择合适的视频源--");
            cb视频源.SelectedIndex = 0;

            if (providers != null)
            {
                // 添加视频源
                foreach (VideoProvider p in providers)
                {
                    cb视频源.Items.Add(p.Name);
                }
            }
        }

        // On Name edit box changed
        private void nameBox_TextChanged(object sender, System.EventArgs e)
        {
            UpdateState();
        }

        // On Video Source combo selection changed
        private void videoSourceCombo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateState();

            if (Reset != null)
                Reset(this, new EventArgs());
        }

        // Update state
        private void UpdateState()
        {
            completed = ((txt名字.TextLength != 0) && (cb视频源.SelectedIndex != 0));

            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }
    }
}

