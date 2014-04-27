using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IMediaEvent interface
    //
    // The IMediaEvent interface contains methods for retrieving event
    // notifications and for overriding the filter graph's default
    // handling of events.
    //
    [ComImport,
    Guid("56A868B6-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaEvent
    {
        // Retrieves a handle to a manual-reset event that remains
        // signaled while the queue contains event notifications
        [PreserveSig]
        int GetEventHandle(
            out IntPtr hEvent);

        // Retrieves the next event notification from the event queue
        [PreserveSig]
        int GetEvent(
            out int lEventCode,
            out int lParam1,
            out int lParam2,
            int msTimeout);

        // Waits for the filter graph to render all available data
        [PreserveSig]
        int GetEvent(
            int msTimeout,
            out int pEvCode);

        // Cancels the filter graph manager's default handling of
        // a specified event
        [PreserveSig]
        int CancelDefaultHandling(
            int lEvCode);

        // Restores the filter graph manager's default handling of
        // a specified event
        [PreserveSig]
        int RestoreDefaultHandling(
            int lEvCode);

        // Frees resources associated with the parameters of an event
        [PreserveSig]
        int FreeEventParams(
            int lEventCode,
            int lParam1,
            int lParam2);
    }


    // IMediaEventEx interface
    //
    // IMediaEventEx adds methods that enable an application window
    // to receive messages when events occur
    //
    [ComImport,
    Guid("56A868C0-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaEventEx
    {
        // Retrieves a handle to a manual-reset event that remains
        // signaled while the queue contains event notifications
        [PreserveSig]
        int GetEventHandle(
            out IntPtr hEvent);

        // Retrieves the next event notification from the event queue
        [PreserveSig]
        int GetEvent(
            out int lEventCode,
            out int lParam1,
            out int lParam2,
            int msTimeout);

        // Waits for the filter graph to render all available data
        [PreserveSig]
        int WaitForCompletion(
            int msTimeout,
            out int pEvCode);

        // Cancels the filter graph manager's default handling of
        // a specified event
        [PreserveSig]
        int CancelDefaultHandling(
            int lEvCode);

        // Restores the filter graph manager's default handling of
        // a specified event
        [PreserveSig]
        int RestoreDefaultHandling(
            int lEvCode);

        // Frees resources associated with the parameters of an event
        [PreserveSig]
        int FreeEventParams(
            int lEventCode,
            int lParam1,
            int lParam2);

        // Registers a window to process event notifications
        [PreserveSig]
        int SetNotifyWindow(
            IntPtr hwnd,
            int lMsg,
            IntPtr lInstanceData);

        // Enables or disables event notifications
        // 0 - ON, 1 - OFF
        [PreserveSig]
        int SetNotifyWindow(
            int lNoNotifyFlags);

        // Determines whether event notifications are enabled
        [PreserveSig]
        int GetNotifyFlags(
            out int lNoNotifyFlags);
    }
}
