using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace dshow.Core
{
    // IPropertyBag
    //
    // The IPropertyBag interface provides an object with a property
    // bag in which the object can persistently save its properties
    //
    [ComImport,
    Guid("55272A00-42CB-11CE-8135-00AA004BB851"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyBag
    {
        // Asks the property bag to read the named property
        [PreserveSig]
        int Read(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref object pVar,
            [In] IntPtr pErrorLog);

        // Asks the property bag to save the named property
        [PreserveSig]
        int Write(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName,
            [In, MarshalAs(UnmanagedType.Struct)] ref object pVar);
    }
}
