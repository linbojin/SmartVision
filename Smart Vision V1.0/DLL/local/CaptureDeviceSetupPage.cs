using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using videosource;
using dshow;
using dshow.Core;

namespace local
{
    /// <summary>
    /// Summary description for CaptureDeviceSetupPage.
    /// </summary>
    public partial class CaptureDeviceSetupPage : UserControl,IVideoSourcePage
    {
        FilterCollection filters;
        private bool completed = false;

        // state changed event
        public event EventHandler StateChanged;

        public CaptureDeviceSetupPage()
        {
            InitializeComponent();

            filters = new FilterCollection(FilterCategory.VideoInputDevice);

            if (filters.Count == 0)
            {
                cbDevice.Items.Add("本地无摄像头设备");
                cbDevice.Enabled = false;
            }
            else
            {
                // add all devices to combo
                foreach (Filter filter in filters)
                {
                    cbDevice.Items.Add(filter.Name);
                }
                completed = true;
            }
            cbDevice.SelectedIndex = 0;
        }

        // Completed property
        public bool Completed
        {
            get { return completed; }
        }

        // Show the page
        public void Display()
        {
            cbDevice.Focus();
        }

        // Apply the page
        public bool Apply()
        {
            return true;
        }

        // Get configuration object
        public object GetConfiguration()
        {
            LocalConfiguration config = new LocalConfiguration();

            config.source = filters[cbDevice.SelectedIndex].MonikerString;

            return (object)config;
        }

        // Set configuration
        public void SetConfiguration(object config)
        {
            LocalConfiguration cfg = (LocalConfiguration)config;

            if (cfg != null)
            {
                for (int i = 0; i < filters.Count; i++)
                {
                    if (filters[i].MonikerString == cfg.source)
                    {
                        cbDevice.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }





















}
