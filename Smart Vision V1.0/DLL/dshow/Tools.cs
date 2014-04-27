using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using dshow.Core;

namespace dshow
{
    /// <summary>
    /// Tools class
    /// </summary>
    public class DSTools
    {
        // Get pin of the filter
        public static IPin GetPin(IBaseFilter filter, PinDirection dir, int num)
        {
            IPin[] pin = new IPin[1];

            IEnumPins pinsEnum = null;

            // enum filter pins
            if (filter.EnumPins(out pinsEnum) == 0)
            {
                PinDirection pinDir;
                int n;

                // get next pin
                while (pinsEnum.Next(1, pin, out n) == 0)
                {
                    // query pin`s direction
                    pin[0].QueryDirection(out pinDir);

                    if (pinDir == dir)
                    {
                        if (num == 0)
                            return pin[0];
                        num--;
                    }

                    Marshal.ReleaseComObject(pin[0]);
                    pin[0] = null;
                }
            }
            return null;
        }

        // Get input pin of the filter
        public static IPin GetInPin(IBaseFilter filter, int num)
        {
            return GetPin(filter, PinDirection.Input, num);
        }

        // Get output pin of the filter
        public static IPin GetOutPin(IBaseFilter filter, int num)
        {
            return GetPin(filter, PinDirection.Output, num);
        }
    }
}
