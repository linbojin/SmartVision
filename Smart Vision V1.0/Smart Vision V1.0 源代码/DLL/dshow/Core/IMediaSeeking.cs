using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IMediaSeeking interface
    //
    // Contains methods for seeking to a position within a stream,
    // and for setting the playback rate
    //
    [ComImport,
    Guid("36B73880-C2C8-11CF-8B46-00805F6CEF60"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMediaSeeking
    {
        // Retrieves all the seeking capabilities of the stream
        [PreserveSig]
        int GetCapabilities(
            out SeekingCapabilities pCapabilities);

        // Queries whether a stream has specified seeking capabilities
        [PreserveSig]
        int CheckCapabilities(
            [In, Out] ref SeekingCapabilities pCapabilities);

        // Determines whether a specified time format is supported
        [PreserveSig]
        int IsFormatSupported(
            [In] ref Guid pFormat);

        // Retrieves the preferred time format for the stream
        [PreserveSig]
        int QueryPreferredFormat(
            [Out] out Guid pFormat);

        // Retrieves the current time format
        [PreserveSig]
        int GetTimeFormat(
            [Out] out Guid pFormat);

        // Determines whether a specified time format
        // is the format currently in use
        [PreserveSig]
        int IsUsingTimeFormat(
            [In] ref Guid pFormat);

        // Sets the time format
        [PreserveSig]
        int SetTimeFormat(
            [In] ref Guid pFormat);

        // Retrieves the duration of the stream
        [PreserveSig]
        int GetDuration(
            out long pDuration);

        // Retrieves the time at which the playback will stop,
        // relative to the duration of the stream
        [PreserveSig]
        int GetStopPosition(
            out long pStop);

        // Retrieves the current position, relative to the
        // total duration of the stream
        [PreserveSig]
        int GetCurrentPosition(
            out long pCurrent);

        // Converts from one time format to another
        [PreserveSig]
        int ConvertTimeFormat(
            out long pTarget,
            [In] ref Guid pTargetFormat,
            long Source,
            [In] ref Guid pSourceFormat);

        // Sets the current position and the stop position
        [PreserveSig]
        int SetPositions(
            [In, Out] ref long pCurrent,
            SeekingFlags dwCurrentFlags,
            [In, Out] ref long pStop,
            SeekingFlags dwStopFlags);

        // Retrieves the current position and the stop position,
        // relative to the total duration of the stream
        [PreserveSig]
        int GetPositions(
            out long pCurrent,
            out long pStop);

        // Retrieves the range of times in which seeking is efficient
        [PreserveSig]
        int GetAvailable(
            out long pEarliest,
            out long pLatest);

        // Sets the playback rate
        [PreserveSig]
        int SetRate(
            double dRate);

        // Retrieves the playback rate
        [PreserveSig]
        int GetRate(
            out double pdRate);

        // Retrieves the amount of data that will be queued before
        // the start position
        [PreserveSig]
        int GetPreroll(
            out long pllPreroll);
    }
}