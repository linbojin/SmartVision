using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using dshow.Core;

namespace dshow
{
    /// <summary>
    /// Summary description for Filter.
    /// </summary>
    public class Filter : IComparable
    {
        // Device name
        public readonly string Name;

        // Moniker string
        public readonly string MonikerString;

        // Create new filter from moneker`s string
        public Filter(string monikerString)
        {
            MonikerString = monikerString;
            Name = GetName(monikerString);
        }

        // Create new filter from it's Moniker
        internal Filter(UCOMIMoniker moniker)
        {
            MonikerString = GetMonikerString(moniker);
            Name = GetName(moniker);
        }


        // Get moniker string of the moniker
        private string GetMonikerString(UCOMIMoniker moniker)
        {
            string str;
            moniker.GetDisplayName(null, null, out str);
            return str;
        }

        // Get filter name represented by the moniker
        private string GetName(UCOMIMoniker moniker)
        {
            Object bagObj = null;
            IPropertyBag bag = null;

            try
            {
                Guid bagId = typeof(IPropertyBag).GUID;
                // get property bag of the moniker
                moniker.BindToStorage(null, null, ref bagId, out bagObj);
                bag = (IPropertyBag)bagObj;

                // read FriendlyName
                object val = "";
                int hr = bag.Read("FriendlyName", ref val, IntPtr.Zero);
                if (hr != 0)
                    Marshal.ThrowExceptionForHR(hr);

                // get it as string
                string ret = val as string;
                if ((ret == null) || (ret.Length < 1))
                    throw new ApplicationException();

                return ret;
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                // release all COM objects
                bag = null;
                if (bagObj != null)
                {
                    Marshal.ReleaseComObject(bagObj);
                    bagObj = null;
                }
            }
        }

        // Get filter name represented by the moniker string
        private string GetName(string monikerString)
        {
            UCOMIBindCtx bindCtx = null;
            UCOMIMoniker moniker = null;
            String name = "";
            int n = 0;

            // create bind context
            if (Win32.CreateBindCtx(0, out bindCtx) == 0)
            {
                // convert moniker`s string to a moniker
                if (Win32.MkParseDisplayName(bindCtx, monikerString, ref n, out moniker) == 0)
                {
                    // get device name
                    name = GetName(moniker);

                    Marshal.ReleaseComObject(moniker);
                    moniker = null;
                }
                Marshal.ReleaseComObject(bindCtx);
                bindCtx = null;
            }
            return name;
        }

        // Compares objects of the type
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Filter f = (Filter)obj;
            return (this.Name.CompareTo(f.Name));
        }
    }
}

