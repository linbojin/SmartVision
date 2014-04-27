using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // ISampleGrabber interface
    //
    // This interface provides methods for retrieving individual
    // media samples as they move through the filter graph
    //
    [ComImport,
    Guid("6B652FFF-11FE-4FCE-92AD-0266B5D7C78F"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISampleGrabber
    {
        // Specifies whether the filter should stop the graph
        // after receiving one sample
        [PreserveSig]
        int SetOneShot(
            [In, MarshalAs(UnmanagedType.Bool)] bool OneShot);

        // Specifies the media type for the connection on
        // the Sample Grabber's input pin
        [PreserveSig]
        int SetMediaType(
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        // Retrieves the media type for the connection on
        // the Sample Grabber's input pin
        [PreserveSig]
        int GetConnectedMediaType(
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        // Specifies whether to copy sample data into a buffer
        // as it goes through the filter
        [PreserveSig]
        int SetBufferSamples(
            [In, MarshalAs(UnmanagedType.Bool)] bool BufferThem);

        // Retrieves a copy of the sample that
        // the filter received most recently
        [PreserveSig]
        int GetCurrentBuffer(
            ref int pBufferSize,
            IntPtr pBuffer);

        //
        [PreserveSig]
        int GetCurrentSample(
            IntPtr ppSample);

        // Specifies a callback method to call on incoming samples
        [PreserveSig]
        int SetCallback(
            ISampleGrabberCB pCallback,
            int WhichMethodToCallback);
    }


    // ISampleGrabberCB interface
    //
    // This interface provides callback methods for the
    // ISampleGrabber::SetCallback method
    //
    [ComImport,
    Guid("0579154A-2B53-4994-B0D0-E773148EFF85"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISampleGrabberCB
    {
        // Callback method that receives a pointer to the media sample
        [PreserveSig]
        //		int SampleCB(
        //			double SampleTime,
        //			IMediaSample pSample);
        int SampleCB(
            double SampleTime,
            IntPtr pSample);

        // Callback method that receives a pointer to the sample buffer
        [PreserveSig]
        int BufferCB(
            double SampleTime,
            IntPtr pBuffer,
            int BufferLen);
    }
}