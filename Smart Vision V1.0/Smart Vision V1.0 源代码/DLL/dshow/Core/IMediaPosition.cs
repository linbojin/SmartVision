using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IMediaPosition interface
    //
    // Contains methods for seeking to a position within a stream
    //
    [ComImport,
    Guid("56A868B2-0AD4-11CE-B03A-0020AF0BA770"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaPosition
    {
        // Retrieves the duration of the stream
        [PreserveSig]
        int get_Duration(
            out double pLength);

        // Sets the current position, relative to the
        // total duration of the stream
        [PreserveSig]
        int put_CurrentPosition(
            double llTime);
        // Retrieves the current position, relative to the total
        // duration of the stream
        [PreserveSig]
        int get_CurrentPosition(
            out double pllTime);

        // Retrieves the time at which the playback will stop,
        // relative to the duration of the stream
        [PreserveSig]
        int get_StopTime(
            out double pllTime);
        // Sets the time at which the playback will stop,
        // relative to the duration of the stream
        [PreserveSig]
        int put_StopTime(
            double llTime);

        // Retrieves the amount of data that will be queued
        // before the start position
        [PreserveSig]
        int get_PrerollTime(
            out double pllTime);
        // Sets the amount of data that will be queued before
        // the start position
        [PreserveSig]
        int put_PrerollTime(
            double llTime);

        // Sets the playback rate
        [PreserveSig]
        int put_Rate(
            double dRate);
        // Retrieves the playback rate
        [PreserveSig]
        int get_Rate(
            out double pdRate);

        // Determines whether the filter graph can seek forward in the stream
        [PreserveSig]
        int CanSeekForward(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pCanSeekForward);

        // Determines whether the filter graph can seek backward in the stream
        [PreserveSig]
        int CanSeekBackward(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pCanSeekBackward);
    }
}