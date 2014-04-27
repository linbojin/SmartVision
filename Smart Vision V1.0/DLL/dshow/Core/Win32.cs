using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace dshow.Core
{
    /// <summary>
    /// Some Win32 API functions
    /// </summary>
    [ComVisible(false)]
    public class Win32
    {
        // memcpy - copy a block of memery
        [DllImport("ntdll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]   //手动加进去的，解决原因可能是托管的 PInvoke 签名与非托管的目标签名不匹配。请检查 PInvoke 签名的
        public static extern
            int memcpy(int dst, int src, int count);

        // Supplies a pointer to an implementation of IBindCtx
        [DllImport("ole32.dll")]
        public static extern
        int CreateBindCtx(
            int reserved,
            out UCOMIBindCtx ppbc);

        // Converts a string into a moniker that identifies
        // the object named by the string
        [DllImport("ole32.dll", CharSet = CharSet.Unicode)]
        public static extern
        int MkParseDisplayName(
            UCOMIBindCtx pbc,
            string szUserName,
            ref int pchEaten,
            out UCOMIMoniker ppmk);

        // window styles
        [Flags]
        public enum WS
        {
            CHILD = 0x40000000,
            VISIBLE = 0x10000000
        }
    }
}
