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
    public partial class 新增向导模板 : Form
    {
        private string title;
        private int currentPage;
        private Control currentControl = null;

        public 新增向导模板()
        {
            InitializeComponent();
        }


        // Add page
        public void AddPage(IWizardPage page)
        {
            Control ctrl = (Control)page;

            panel主体.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

            page.StateChanged += new EventHandler(page_StateChanged);
            //page.Reset += new EventHandler(page_Reset);
        }

        // On form load
        private void 新增向导模板_Load(object sender, EventArgs e)
        {
            // save original title
            title = this.Text;

            // set current page to the first
            SetCurrentPage(0);
        }

        // Update control buttons state
        private void UpdateControlButtons()
        {
            // "Back" button
            btn返回.Enabled = (currentPage != 0);
            // "Next" button
            btn下一步.Enabled = ((currentPage < panel主体.Controls.Count - 1) && (currentControl != null) && (((IWizardPage)currentControl).Completed));
            // "Finish" button
            btn完成.Enabled = true;
            foreach (IWizardPage page in panel主体.Controls)
            {
                if (!page.Completed)
                {
                    btn完成.Enabled = false;
                    break;
                }
            }
        }

        // Set current page
        private void SetCurrentPage(int n)
        {
            OnPageChanging(n);

            // hide previous page
            if (currentControl != null)
            {
                currentControl.Hide();
            }

            //
            currentPage = n;

            // update dialog text
            //this.Text = title + " - Page " + ((int)(n + 1)).ToString() + " of " + panel主体.Controls.Count.ToString();

            // show new page
            currentControl = panel主体.Controls[currentPage];
            IWizardPage page = (IWizardPage)currentControl;

            currentControl.Show();

            // description
            lb介绍.Text = page.PageDescription;

            // notify the page
            page.Display();

            // update conrol buttons
            UpdateControlButtons();
        }

        // On "Next" button click
        private void btn下一步_Click(object sender, EventArgs e)
        {
            if (((IWizardPage)currentControl).Apply() == true)
            {
                if (currentPage < panel主体.Controls.Count - 1)
                {
                    SetCurrentPage(currentPage + 1);
                }
            }
        }

        // On "Back" button click
        private void btn返回_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                SetCurrentPage(currentPage - 1);
            }
        }

        // On "Finish" button click
        private void btn完成_Click(object sender, EventArgs e)
        {
            if (((IWizardPage)currentControl).Apply() == true)
            {
                OnFinish();

                // close the dialog
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // On page state changed
        private void page_StateChanged(object sender, EventArgs e)
        {
            // update conrol buttons
            UpdateControlButtons();
        }

        // Reset on page
        private void page_Reset(object sender, EventArgs e)
        {
            OnResetOnPage(panel主体.Controls.GetChildIndex((Control)sender));

            // update conrol buttons
            UpdateControlButtons();
        }

        // Before page changing
        protected virtual void OnPageChanging(int page)
        {
        }

        // Reset event ocuren on page
        protected virtual void OnResetOnPage(int page)
        {
        }

        // On dialog finish
        protected virtual void OnFinish()
        {
        }
    }
}
