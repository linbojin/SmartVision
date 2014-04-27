using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IBasicVideo interface
    //
    // The interface enables applications to set video properties
    // such as the bit rate, and destination and source rectangles
    //
    [ComImport,
    Guid("56A868B5-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IBasicVideo
    {
        // Retrieves the average time between successive frames
        // in 100-nanosecond units
        [PreserveSig]
        int get_AvgTimePerFrame(
            out double pAvgTimePerFrame);

        // Retrieves an approximate bit rate for the video stream
        [PreserveSig]
        int get_BitRate(
            out int pBitRate);

        // Retrieves an approximate bit error rate for the video stream
        [PreserveSig]
        int get_BitErrorRate(
            out int pBitRate);

        // Retrieves the current video width
        [PreserveSig]
        int get_VideoWidth(
            out int pVideoWidth);

        // Retrieves the current video height
        [PreserveSig]
        int get_VideoHeight(
            out int pVideoHeight);

        // Sets the x-axis coordinate for the source video rectangle
        [PreserveSig]
        int put_SourceLeft(
            int SourceLeft);
        // Retrieves the x-axis coordinate for the source video rectangle
        [PreserveSig]
        int get_SourceLeft(
            out int pSourceLeft);

        // Sets the width of the source video rectangle
        [PreserveSig]
        int put_SourceWidth(
            int SourceWidth);
        // Retrieves the width of the source video rectangle
        [PreserveSig]
        int get_SourceWidth(
            out int pSourceWidth);

        // Sets the y-axis coordinate for the source video rectangle
        [PreserveSig]
        int put_SourceTop(
            int SourceTop);
        // Retrieves the y-axis coordinate for the source video rectangle
        [PreserveSig]
        int get_SourceTop(
            out int pSourceTop);

        // Sets the height of the source video rectangle
        [PreserveSig]
        int put_SourceHeight(
            int SourceHeight);
        // Retrieves the height of the source video rectangle
        [PreserveSig]
        int get_SourceHeight(
            out int pSourceHeight);

        // Sets the x-axis coordinate for the destination video rectangle
        [PreserveSig]
        int put_DestinationLeft(
            int DestinationLeft);
        // Retrieves the x-axis coordinate for the destination video rectangle
        [PreserveSig]
        int get_DestinationLeft(
            out int pDestinationLeft);

        // Sets the width of the destination video rectangle
        [PreserveSig]
        int put_DestinationWidth(
            int DestinationWidth);
        // Retrieves the width of the destination video rectangle
        [PreserveSig]
        int get_DestinationWidth(
            out int pDestinationWidth);

        // Sets the y-axis coordinate for the destination video rectangle
        [PreserveSig]
        int put_DestinationTop(
            int DestinationTop);
        // Retrieves the y-axis coordinate for the destination video rectangle
        [PreserveSig]
        int get_DestinationTop(
            out int pDestinationTop);

        // Sets the height of the destination video rectangle
        [PreserveSig]
        int put_DestinationHeight(
            int DestinationHeight);
        // Retrieves the height of the destination video rectangle
        [PreserveSig]
        int get_DestinationHeight(
            out int pDestinationHeight);

        // Sets the source video rectangle
        [PreserveSig]
        int SetSourcePosition(
            int left,
            int top,
            int width,
            int height);

        // Retrieves the source video rectangle
        [PreserveSig]
        int GetSourcePosition(
            out int left,
            out int top,
            out int width,
            out int height);

        // Informs the renderer to use the default source rectangle
        [PreserveSig]
        int SetDefaultSourcePosition();

        // Sets the destination rectangle for the window
        [PreserveSig]
        int SetDestinationPosition(
            int left,
            int top,
            int width,
            int height);

        // Retrieves the destination video rectangle for the window
        [PreserveSig]
        int GetDestinationPosition(
            out int left,
            out int top,
            out int width,
            out int height);

        // Sets the default destination position for the window
        [PreserveSig]
        int SetDefaultDestinationPosition();

        // Retrieves the native video dimensions
        [PreserveSig]
        int GetVideoSize(
            out int pWidth,
            out int pHeight);

        // Retrieves the color palette entries required by the video
        [PreserveSig]
        int GetVideoPaletteEntries(
            int StartIndex,
            int Entries,
            out int pRetrieved,
            IntPtr pPalette);

        // Returns a copy of the current image that is waiting at the renderer
        [PreserveSig]
        int GetCurrentImage(
            ref int pBufferSize,
            IntPtr pDIBImage);

        // Determines if the renderer is using the default source rectangle
        [PreserveSig]
        int IsUsingDefaultSource();

        // Determines if the renderer is using the default destination rectangle
        [PreserveSig]
        int IsUsingDefaultDestination();

    }
}