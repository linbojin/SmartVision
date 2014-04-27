using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace dshow.Core
{
    // IMediaControl interface
    //
    // The IMediaControl interface provides methods for controlling
    // the flow of data through the filter graph
    //
    [ComImport,
    Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaControl
    {
        // Switches the entire filter graph into running mode
        [PreserveSig]
        int Run();

        // Pauses all filters in the filter graph
        [PreserveSig]
        int Pause();

        // Switches all filters in the filter graph to a stopped state
        [PreserveSig]
        int Stop();

        // Retrieves the state of the filter graph
        [PreserveSig]
        int GetState(
            int msTimeout,
            out int pfs);

        // Adds and connects filters needed to play the specified file
        [PreserveSig]
        int RenderFile(
            string strFilename);

        // Adds to the graph the source filter that can read the given file name
        [PreserveSig]
        int AddSourceFilter(
            [In] string strFilename,
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

        //
        [PreserveSig]
        int get_FilterCollection(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

        //
        [PreserveSig]
        int get_RegFilterCollection(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

        // Waits for an operation such as Pause to complete,
        // allowing filters to queue up data, then stops the filter graph
        [PreserveSig]
        int StopWhenReady();
    }
}