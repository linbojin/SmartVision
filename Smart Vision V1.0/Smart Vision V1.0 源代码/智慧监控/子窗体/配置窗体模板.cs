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
    public partial class 配置窗体模板 : Form
    {
        private Control currentControl = null;

        public 配置窗体模板()
        {
            InitializeComponent();
        }

        private void 配置窗体模板_Load(object sender, EventArgs e)
        {
            // set current page to the first
            SetCurrentPage(0);
        }

        // SelectedPageIndex property
        public int SelectedPageIndex
        {
            get { return tabControl.SelectedIndex; }
        }

        // Apply event
        public event EventHandler Apply;

        // Add page
        public void AddPage(IWizardPage page)
        {
            Control ctrl = (Control)page;

            // add new tab
            TabPage tabPage = new TabPage();
            tabPage.TabIndex = tabControl.TabCount;
            tabPage.Text = page.PageName;
            tabControl.Controls.Add(tabPage);

            // add page to tab
            tabPage.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

            page.StateChanged += new EventHandler(page_StateChanged);
        }

        // Update control buttons state
        private void UpdateControlButtons()
        {
            // "Apply" button
            btn应用.Enabled = ((currentControl != null) && (((IWizardPage)currentControl).Completed));
            // "Ok" button
            btn确定.Enabled = true;
            foreach (Control ctrl in tabControl.Controls)
            {
                if (!((IWizardPage)ctrl.Controls[0]).Completed)
                {
                    btn确定.Enabled = false;
                    break;
                }
            }
        }

        // Set current page
        private void SetCurrentPage(int n)
        {
            // get current page
            currentControl = tabControl.Controls[n].Controls[0];
            IWizardPage page = (IWizardPage)currentControl;

            // notify the page
            page.Display();

            // update conrol buttons
            UpdateControlButtons();
        }

        // Selection changed in tab control
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentPage(tabControl.SelectedIndex);
        }

        // On "Apply" button click
        private void btn应用_Click(object sender, EventArgs e)
        {
            if ((((IWizardPage)currentControl).Apply() == true) && (Apply != null))
            {
                Apply(this, new EventArgs());   //激发此事件
            }
        }

        // On "Ok" button click
        private void btn确定_Click(object sender, EventArgs e)
        {
            // apply all pages
            foreach (Control ctrl in tabControl.Controls)
            {
                if (!((IWizardPage)ctrl.Controls[0]).Apply())
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // On page state changed
        private void page_StateChanged(object sender, EventArgs e)
        {
            // update conrol buttons
            UpdateControlButtons();
        }
    }
}
