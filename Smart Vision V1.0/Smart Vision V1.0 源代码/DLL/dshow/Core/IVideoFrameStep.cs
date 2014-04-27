using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    // IVideoFrameStep interface
    //
    [ComImport,
    Guid("E46A9787-2B71-444D-A4B5-1FAB7B708D6A"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVideoFrameStep
    {
        // Causes the filter graph to step forward by the
        // specified number of frames
        [PreserveSig]
        int Step(
            int dwFrames,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pStepObject);

        // Determines the stepping capabilities of the specified filter
        [PreserveSig]
        int CanStep(
            int bMultiple,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pStepObject);

        // Cancels the previous step operation
        [PreserveSig]
        int CancelStep();
    }
}