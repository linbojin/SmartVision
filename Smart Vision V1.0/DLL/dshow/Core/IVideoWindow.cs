using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IVideoWindow interface
    //
    // The IVideoWindow interface sets properties on the video window.
    // Applications can use it to set the window owner, the position
    // and dimensions of the window, and other properties.
    //
    [ComImport,
    Guid("56A868B4-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IVideoWindow
    {
        // Sets the text caption on the playback window
        [PreserveSig]
        int put_Caption(
            string caption);
        // Retrieves the text caption on the playback window
        [PreserveSig]
        int get_Caption(
            [Out] out string caption);

        // Sets the playback window style
        [PreserveSig]
        int put_WindowStyle(
            int windowStyle);
        // Retrieves the window style of the video window
        [PreserveSig]
        int get_WindowStyle(
            out int windowStyle);

        // Sets the style of the control window
        [PreserveSig]
        int put_WindowStyleEx(
            int windowStyleEx);
        // Retrieves the extended style of the video window
        [PreserveSig]
        int get_WindowStyleEx(
            out int windowStyleEx);

        // Specifies if the window will be automatically shown on
        // the first state change
        [PreserveSig]
        int put_AutoShow(
            [In, MarshalAs(UnmanagedType.Bool)] bool autoShow);
        // Retrieves information about whether the window
        // will be automatically shown
        [PreserveSig]
        int get_AutoShow(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool autoShow);

        // Sets the current window state (such as visible or minimized)
        [PreserveSig]
        int put_WindowState(
            int windowState);
        // Retrieves the current window state (such as visible or minimized)
        [PreserveSig]
        int get_WindowState(
            out int windowState);

        // Informs the renderer to realize its palette in the background
        [PreserveSig]
        int put_BackgroundPalette(
            int backgroundPalette);
        // Retrieves information about whether any palette required
        // will be realized in the background
        [PreserveSig]
        int get_BackgroundPalette(
            out int backgroundPalette);

        // Sets the visibility of the window
        [PreserveSig]
        int put_Visible(
            [In, MarshalAs(UnmanagedType.Bool)] bool visible);
        // Retrieves the visibility of the window
        [PreserveSig]
        int get_Visible(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool visible);

        // Sets the x-axis coordinate for the video window
        [PreserveSig]
        int put_Left(
            int left);
        // Retrieves the x-axis coordinate for the video window
        [PreserveSig]
        int get_Left(
            out int left);

        // Sets the width of the video window
        [PreserveSig]
        int put_Width(
            int width);
        // Retrieves the width of the video window
        [PreserveSig]
        int get_Width(
            out int width);

        // Sets the y-axis coordinates for the video window
        [PreserveSig]
        int put_Top(
            int top);
        // Retrieves the y-axis coordinates for the video window
        [PreserveSig]
        int get_Top(
            out int top);

        // Sets the height of the video window
        [PreserveSig]
        int put_Height(
            int height);
        // Retrieves the height of the video window
        [PreserveSig]
        int get_Height(
            out int height);

        // Sets the owning parent window for the video playback window
        [PreserveSig]
        int put_Owner(
            IntPtr owner);
        // Retrieves the owning parent window for the video playback window
        [PreserveSig]
        int get_Owner(
            out IntPtr owner);

        // Specifies a window to which the video window will post messages
        [PreserveSig]
        int put_MessageDrain(
            IntPtr drain);
        // Retrieves the window set to receive messages from the video window
        [PreserveSig]
        int get_MessageDrain(
            out IntPtr drain);

        // Retrieves the border color for the video window
        [PreserveSig]
        int get_BorderColor(
            out int color);
        // Sets the border color for the video window
        [PreserveSig]
        int put_BorderColor(
            int color);

        // Retrieves the full-screen rendering mode of the video
        // renderer filter supporting this interface
        [PreserveSig]
        int get_FullScreenMode(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool fullScreenMode);
        // Sets the full-screen mode for the video renderer
        // filter supporting this interface
        [PreserveSig]
        int put_FullScreenMode(
            [In, MarshalAs(UnmanagedType.Bool)] bool fullScreenMode);

        // Tells the renderer filter to become the foreground window
        [PreserveSig]
        int SetWindowForeground(int focus);

        // Forwards messages that have been received by a
        // parent window to a child window owned by a filter
        [PreserveSig]
        int NotifyOwnerMessage(
            IntPtr hwnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam);

        // Sets the video window position on the display
        [PreserveSig]
        int SetWindowPosition(
            int left,
            int top,
            int width,
            int height);

        // Retrieves the video window position
        [PreserveSig]
        int GetWindowPosition(
            out int left,
            out int top,
            out int width,
            out int height);

        // Retrieves the ideal minimum image size for the
        // video image playback (client) area
        [PreserveSig]
        int GetMinIdealImageSize(
            out int width,
            out int height);

        // Retrieves the ideal maximum image size for the
        // video image playback (client) area
        [PreserveSig]
        int GetMaxIdealImageSize(
            out int width,
            out int height);

        // Retrieves the normal restored window dimensions
        [PreserveSig]
        int GetRestorePosition(
            out int left,
            out int top,
            out int width,
            out int height);

        // Hides the cursor
        [PreserveSig]
        int HideCursor(
            [In, MarshalAs(UnmanagedType.Bool)] bool hideCursor);

        // Determines if the cursor is hidden or showing
        [PreserveSig]
        int IsCursorHidden(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool hideCursor);
    }
}