using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IFilterGraph interface
    //
    // The IFilterGraph interface is an abstraction representing
    // a graph of filters
    //
    [ComImport,
    Guid("56A8689F-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFilterGraph
    {
        // Adds a filter to the graph and names it
        // by using the pName parameter
        [PreserveSig]
        int AddFilter(
            [In] IBaseFilter pFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName);

        // Removes a filter from the graph
        [PreserveSig]
        int RemoveFilter(
            [In] IBaseFilter pFilter);

        // Provides an enumerator for all filters in the graph
        [PreserveSig]
        //		int EnumFilters(
        //			[Out] out IEnumFilters ppEnum);
        int EnumFilters(
            [Out] out IntPtr ppEnum);

        // Finds a filter that was added
        // to the filter graph with a specific name
        [PreserveSig]
        int FindFilterByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName,
            [Out] out IBaseFilter ppFilter);

        // Connects the two pins directly
        [PreserveSig]
        int ConnectDirect(
            [In] IPin ppinOut,
            [In] IPin ppinIn,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        // Disconnects this and the pin to which it connects and
        // then reconnects it to the same pin
        [PreserveSig]
        int Reconnect(
            [In] IPin ppin);

        // Disconnects this pin
        [PreserveSig]
        int Disconnect(
            [In] IPin ppin);

        // Sets the default source of synchronization
        [PreserveSig]
        int SetDefaultSyncSource();
    }
}
