using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IGraphBuilder interface
    //
    // The IGraphBuilder interface allows applications to call upon
    // the filter graph manager to attempt to build a complete filter
    // graph, or parts of a filter graph given only partial information,
    // such as the name of a file or the interfaces of two separate pins
    //
    [ComImport,
    Guid("56A868A9-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IGraphBuilder
    {
        // --- IFilterGraph Methods

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

        // --- IGraphBuilder methods

        // Connects the two pins, using intermediates if necessary
        [PreserveSig]
        int Connect(
            [In] IPin ppinOut,
            [In] IPin ppinIn);

        // Builds a filter graph that renders the data from this output pin
        [PreserveSig]
        int Render(
            [In] IPin ppinOut);

        // Builds a filter graph that renders the specified file
        [PreserveSig]
        int RenderFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFile,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrPlayList);

        // Adds a source filter to the filter graph for a specific file
        [PreserveSig]
        int AddSourceFilter(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFilterName,
            [Out] out IBaseFilter ppFilter);

        // Sets the file into which actions taken in attempting
        // to perform an operation are logged
        [PreserveSig]
        int SetLogFile(IntPtr hFile);

        //
        [PreserveSig]
        int Abort();

        //
        [PreserveSig]
        int ShouldOperationContinue();
    }
}
