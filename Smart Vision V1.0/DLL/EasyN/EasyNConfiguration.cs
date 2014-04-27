using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using videosource;

namespace EasyN
{
    /// <summary>
    /// EasyNConfiguration
    /// </summary>
    public class EasyNConfiguration
    {
        public string source;
        public string login;
        public string password;
        public int frameInterval = 0;
        public StreamType stremType = StreamType.Jpeg;
        public int rate;
    }
}