using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

/*
 * DirectShow structures and enumerations
 */
namespace dshow.Core
{
    // Indicates a pin's direction
    //
    [ComVisible(false)]
    public enum PinDirection	// PIN_DIRECTION
    {
        Input,
        Output
    }

    // The AM_MEDIA_TYPE structure describes the format of a media sample
    //
    [ComVisible(false),
    StructLayout(LayoutKind.Sequential)]
    public class AMMediaType : IDisposable	// AM_MEDIA_TYPE
    {
        public Guid majorType;
        public Guid subType;

        [MarshalAs(UnmanagedType.Bool)]
        public bool fixedSizeSamples = true;

        [MarshalAs(UnmanagedType.Bool)]
        public bool temporalCompression;

        public int sampleSize = 1;
        public Guid formatType;
        public IntPtr unkPtr;
        public int formatSize;
        public IntPtr formatPtr;

        // dispose
        public void Dispose()
        {
            if (formatSize != 0)
                Marshal.FreeCoTaskMem(formatPtr);
            if (unkPtr != IntPtr.Zero)
                Marshal.Release(unkPtr);
        }
    }

    // The PIN_INFO structure contains information about a pin
    // Used with the IPin::QueryPinInfo method
    //
    [ComVisible(false),
    StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public class PinInfo		// PIN_INFO
    {
        public IBaseFilter filter;
        public PinDirection dir;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string name;
    }

    // The FILTER_INFO structure contains information about a filter
    //
    [ComVisible(false),
    StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class FilterInfo		//  FILTER_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string achName;

        [MarshalAs(UnmanagedType.IUnknown)]
        public object pUnk;
    }

    // The VIDEOINFOHEADER structure describes the bitmap
    // and color information for a video image
    //
    [ComVisible(false),
    StructLayout(LayoutKind.Sequential)]
    public struct VideoInfoHeader	// VIDEOINFOHEADER
    {
        public RECT SrcRect;
        public RECT TargetRect;
        public int BitRate;
        public int BitErrorRate;
        public long AvgTimePerFrame;
        public BitmapInfoHeader BmiHeader;
    }

    // The BITMAPINFOHEADER structure contains information about
    // the dimensions and color format of a DIB
    //
    [ComVisible(false),
    StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct BitmapInfoHeader	// BITMAPINFOHEADER
    {
        public int Size;
        public int Width;
        public int Height;
        public short Planes;
        public short BitCount;
        public int Compression;
        public int ImageSize;
        public int XPelsPerMeter;
        public int YPelsPerMeter;
        public int ClrUsed;
        public int ClrImportant;
    }

    // The RECT structure defines the coordinates of the
    // upper-left and lower-right corners of a rectangle
    //
    [ComVisible(false),
    StructLayout(LayoutKind.Sequential)]
    public struct RECT		// RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    // event notification codes
    //
    [ComVisible(false)]
    public enum EventCode
    {
        Complete = 0x01,
        UserAbort = 0x02,
        ErrorAabort = 0x03,
        Time = 0x04,
        Repaint = 0x05,
        StreamErrorStopped = 0x06,
        StreamErrorStillplaying = 0x07,

        ClockChanged = 0x0D,
        Paused = 0x0E,
        BufferingData = 0x11,

        StepComplete = 0x24
    }

    // Specifies the seeking capabilities of a media stream
    //
    [ComVisible(false), Flags]
    public enum SeekingCapabilities		// AM_SEEKING_SEEKING_CAPABILITIES
    {
        CanSeekAbsolute = 0x001,
        CanSeekForwards = 0x002,
        CanSeekBackwards = 0x004,
        CanGetCurrentPos = 0x008,
        CanGetStopPos = 0x010,
        CanGetDuration = 0x020,
        CanPlayBackwards = 0x040,
        CanDoSegments = 0x080,
        Source = 0x100
    }

    // Positioning and Modifier Flags
    //
    [ComVisible(false), Flags]
    public enum SeekingFlags
    {
        NoPositioning = 0x00,	// No change in position
        AbsolutePositioning = 0x01,	// The specified position is absolute
        RelativePositioning = 0x02,	// The specified position is relative to the previous value
        IncrementalPositioning = 0x03,	// The stop position is relative to the current position
        SeekToKeyFrame = 0x04,	// Seek to the nearest key frame. This might be faster, but less accurate.
        ReturnTime = 0x08,	// Return the equivalent reference times
        Segment = 0x10,	// Use segment seeking
        NoFlush = 0x20	// Do not flush
    }
}