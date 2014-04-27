using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using videosource;

namespace local
{
    /// <summary>
    /// CaptureDeviceDescription
    /// </summary>
    public class CaptureDeviceDescription : IVideoSourceDescription
    {
        // Name property
        public string Name
        {
            get { return "Local capture device"; }
        }

        // Description property
        public string Description
        {
            get { return "Captures video form local capture device attached to the computer"; }
        }

        // Return settings page
        public IVideoSourcePage GetSettingsPage()
        {
            return new CaptureDeviceSetupPage();
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            LocalConfiguration cfg = (LocalConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
            }
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            LocalConfiguration config = new LocalConfiguration();

            try
            {
                config.source = reader.GetAttribute("source");
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Create video source object
        public IVideoSource CreateVideoSource(object config)
        {
            LocalConfiguration cfg = (LocalConfiguration)config;

            if (cfg != null)
            {
                CaptureDevice source = new CaptureDevice();

                source.VideoSource = cfg.source;

                return (IVideoSource)source;
            }
            return null;
        }
    }
}
