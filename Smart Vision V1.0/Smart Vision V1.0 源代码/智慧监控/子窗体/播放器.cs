using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace IPCamera
{
    public partial class 播放器 : Form
    {
        string Pathvideo = Application.StartupPath + @"\SmartVision\视频\";
        string Pathpicture = Application.StartupPath + @"\SmartVision\图片\";
        public static int NUM=0;
        TreeNode CountNode = new TreeNode("Smart Vision");
        ArrayList pictures;
        public 播放器()
        {
            InitializeComponent();
        }
        private void 播放器_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = false;
            TreeViewFile.Nodes.Add(CountNode);
            shutup();
        }
        ArrayList GetAll(DirectoryInfo dir)//搜索文件夹中的文件
        {
            ArrayList FileList = new ArrayList();
            FileInfo[] allFile = dir.GetFiles();
            foreach (FileInfo fi in allFile)
            {
                FileList.Add(fi.Name);
            }
            DirectoryInfo[] allDir = dir.GetDirectories();
            foreach (DirectoryInfo d in allDir)
            {
                GetAll(d);
            }
            return FileList;
        }

        private void TreeViewFile_DoubleClick(object sender, EventArgs e)
        {
            if ((this.TreeViewFile.SelectedNode.Text == "video") | (this.TreeViewFile.SelectedNode.Text == "picture") | (this.TreeViewFile.SelectedNode.Text == "Smart Vision"))
            {
                return;
            }
            if (this.TreeViewFile.SelectedNode.Parent.Text == "video")
            {
                axWindowsMediaPlayer1.Visible = true;
                pictureBox1.Visible=false;
                but_first.Visible=false;
                but_top.Visible=false;
                but_next.Visible=false;
                but_last.Visible = false;
                TreeNode node = this.TreeViewFile.SelectedNode;
                string Path = Pathvideo + node.Text;
                this.axWindowsMediaPlayer1.URL = Path;
                this.axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else 
            {
                axWindowsMediaPlayer1.Visible = false;
                pictureBox1.Visible = true;
                but_first.Visible = true;
                but_top.Visible = true;
                but_next.Visible = true;
                but_last.Visible = true;
                TreeNode node = this.TreeViewFile.SelectedNode;
                for (int i = 0; i < pictures.Count; i++)
                {
                    if (pictures[i].ToString()==node.Text)
                    {
                        NUM = i;
                    }
                }
                string Path = Pathpicture + node.Text;
                pictureBox1.Image = Image.FromFile(Path); 
            }
        }

        private void but_first_Click(object sender, EventArgs e)
        {
            if (pictures.Count <= 2)
                return;
            if (pictures[0].ToString() == "Thumbs.db")
            {
                NUM = 1;
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path);
            }
            else
            {
                NUM = 0;
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path);

            }         
        }

        private void but_top_Click(object sender, EventArgs e)
        {
            if (pictures.Count <= 2)
                return;
            if (NUM == 0)
            {
                NUM = pictures.Count - 1;
            }
            else 
            {
                NUM--;
            }
            if (pictures[NUM].ToString() == "Thumbs.db")
            {
                NUM--;
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path);
            }
            else
            {
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path);
            }
            
        }

        private void but_next_Click(object sender, EventArgs e)
        {
            if (pictures.Count <= 2)
                return;
            if (NUM == pictures.Count - 1)
            {
                NUM = 0;
            }
            else
            {
                NUM++;
            }
            if (pictures[NUM].ToString() == "Thumbs.db")
            {
                if (NUM == pictures.Count - 1)
                {
                    NUM = 0;
                }
                else
                {
                    NUM++;
                }
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path);
            }
            else 
            {
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path); 
            }

        }

        private void but_last_Click(object sender, EventArgs e)
        {
            if (pictures.Count <= 2)
                return;
            NUM = pictures.Count - 1;
            if (pictures[NUM].ToString() == "Thumbs.db")
            {
                NUM--;
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path);
            }
            else
            {
                string Path = Pathpicture + pictures[NUM].ToString();
                pictureBox1.Image = Image.FromFile(Path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SmartVision = Application.StartupPath + @"\SmartVision";
            System.Diagnostics.Process.Start("explorer.exe", SmartVision);
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            shutup();
        }
        private void shutup()
        {
            CountNode.Nodes.Clear();
            TreeNode pictureNode = new TreeNode("picture");
            CountNode.Nodes.Add(pictureNode);
            TreeNode videoNode = new TreeNode("video");
            CountNode.Nodes.Add(videoNode);
            DirectoryInfo d = new DirectoryInfo(@"" + Application.StartupPath + @"\SmartVision\图片");
            pictures = GetAll(d);
            for (int i = 0; i < pictures.Count; i++)
            {
                TreeNode aNode = new TreeNode(pictures[i].ToString());
                aNode.Tag = pictures[i].ToString();
                pictureNode.Nodes.Add(aNode);
                if (aNode.Text == "Thumbs.db")
                {
                    pictureNode.Nodes.Remove(aNode);
                }
            }
            DirectoryInfo c = new DirectoryInfo(@"" + Application.StartupPath + @"\SmartVision\视频");
            ArrayList videos = GetAll(c);
            for (int i = 0; i < videos.Count; i++)
            {
                TreeNode aNode = new TreeNode(videos[i].ToString());
                aNode.Tag = videos[i].ToString();
                videoNode.Nodes.Add(aNode);
                if (aNode.Text == "Thumbs.db")
                {
                    videoNode.Nodes.Remove(aNode);
                }
            }
            CountNode.ExpandAll();
        }
    }
}
