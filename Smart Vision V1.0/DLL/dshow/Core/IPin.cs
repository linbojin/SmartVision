using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IPin interface
    //
    // The IPin interface represents a single, unidirectional
    // connection point on a filter
    //
    [ComImport,
    Guid("56A86891-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPin
    {
        // Connects the pin to another pin
        [PreserveSig]
        int Connect(
            [In] IPin pReceivePin,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        // Accepts a connection from another pin
        [PreserveSig]
        int ReceiveConnection(
            [In] IPin pReceivePin,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        // Breaks the current pin connection
        [PreserveSig]
        int Disconnect();

        // Retrieves the pin connected to this pin
        [PreserveSig]
        int ConnectedTo(
            [Out] out IPin ppPin);

        // Retrieves the media type for the current pin connection
        [PreserveSig]
        int ConnectionMediaType(
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        // Retrieves information about the pin, such as the name,
        // the owning filter, and the direction
        [PreserveSig]
        int QueryPinInfo(
            [Out, MarshalAs(UnmanagedType.LPStruct)] PinInfo pInfo);

        // Retrieves the direction of the pin (input or output)
        [PreserveSig]
        int QueryDirection(
            out PinDirection pPinDir);

        // Retrieves the pin identifier
        [PreserveSig]
        int QueryId(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string Id);

        // Determines whether the pin accepts a specified media type
        [PreserveSig]
        int QueryAccept(
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        // Enumerates the pin's preferred media types
        [PreserveSig]
        int EnumMediaTypes(
            IntPtr ppEnum);

        // Retrieves the pins that are connected
        // internally to this pin (within the filter)
        [PreserveSig]
        int QueryInternalConnections(
            IntPtr apPin,
            [In, Out] ref int nPin);

        // Notifies the pin that no additional data is expected
        [PreserveSig]
        int EndOfStream();

        // Begins a flush operation
        [PreserveSig]
        int BeginFlush();

        // Ends a flush operation
        [PreserveSig]
        int EndFlush();

        // Notifies the pin that media samples received after
        // this call are grouped as a segment
        [PreserveSig]
        int NewSegment(
            long tStart,
            long tStop,
            double dRate);
    }
}
