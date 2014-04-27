using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using videosource;
using jpeg;

namespace EasyN
{
    /// <summary>
    /// EasyN IP Camera
    /// </summary>
    public class EasyNCamera : MultimodeVideoSource
    {
        private string server;
        private int rate = 0;
        private int frameInterval;

        // 构造函数
        public EasyNCamera()
        {
            videoSource = new JPEGSource();
            streamType = StreamType.Jpeg;
        }

        // 视频流类型属性
        public override StreamType StreamType
        {
            get { return base.StreamType; }
            set
            {
                if ((value != StreamType.Jpeg) &&
                    (value != StreamType.MJpeg))
                    throw new ArgumentException("Invalid stream type");

                base.StreamType = value;
            }
        }
        // 视频源 属性
        public override string VideoSource
        {
            get { return server; }
            set
            {
                server = value;
                UpdateVideoSource();
            }
        }
        // 质量 属性
        public int Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                UpdateVideoSource();
            }
        }
        // 帧率 属性 
        public int FrameInterval
        {
            get { return frameInterval; }
            set
            {
                frameInterval = value;

                if (streamType == StreamType.Jpeg)
                {
                    ((JPEGSource)videoSource).FrameInterval = frameInterval;
                }
            }
        }


        // 更新视频源
        protected override void UpdateVideoSource()
        {
            switch (streamType)
            {
                case StreamType.Jpeg:
                    videoSource.VideoSource =server + "/snapshot.cgi?";
                    break;
                case StreamType.MJpeg:
                    videoSource.VideoSource =server + "/videostream.cgi?&rate=" + rate;
                    break;
            }
        }
    }
}