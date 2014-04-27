using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace dshow.Core
{
    // IBaseFilter interface
    //
    // The IBaseFilter interface provides methods for controlling a filter
    //
    [ComImport,
    Guid("56A86895-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBaseFilter
    {
        // --- IPersist Methods

        // Retrieves the class identifier (CLSID) of an object
        [PreserveSig]
        int GetClassID(
            [Out] out Guid pClassID);

        // --- IMediaFilter Methods

        // Informs the filter to transition to the new state
        [PreserveSig]
        int Stop();

        // Informs the filter to transition to the new (paused) state
        [PreserveSig]
        int Pause();

        // Informs the filter to transition to the new (running) state
        [PreserveSig]
        int Run(
            long tStart);

        // Determines the state of the filter
        [PreserveSig]
        int GetState(
            int dwMilliSecsTimeout,
            [Out] out int filtState);

        // Identifies the reference clock to which the
        // filter should synchronize activity
        [PreserveSig]
        //		int SetSyncSource(
        //			[In] IReferenceClock pClock);
        int SetSyncSource(
            [In] IntPtr pClock);

        // Retrieves the current reference clock in use by this filter
        [PreserveSig]
        //		int GetSyncSource(
        //			[Out] out IReferenceClock pClock);
        int GetSyncSource(
            [Out] out IntPtr pClock);

        // --- IBaseFilter Methods

        // Enumerates the pins on this filter
        [PreserveSig]
        int EnumPins(
            [Out] out IEnumPins ppEnum);

        // Retrieves the pin with the specified identifier
        [PreserveSig]
        int FindPin(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Id,
            [Out] out IPin ppPin);

        // Retrieves information about the filter
        [PreserveSig]
        int QueryFilterInfo(
            [Out] FilterInfo pInfo);

        // Notifies the filter that it has joined or left the filter graph
        [PreserveSig]
        int JoinFilterGraph(
            [In] IFilterGraph pGraph,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName);

        // Retrieves a string containing vendor information
        [PreserveSig]
        int QueryVendorInfo(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out	string pVendorInfo);
    }
}

