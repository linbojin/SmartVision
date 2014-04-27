using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mjpeg
{
        /// <summary>
        /// 数组处理
        /// </summary>
        internal class ByteArrayUtils
        {
            // 在数组中检验needle是否在正确的位子
            public static bool Compare(byte[] array, byte[] needle, int startIndex)
            {
                int needleLen = needle.Length;
                // 比较
                for (int i = 0, p = startIndex; i < needleLen; i++, p++)
                {
                    if (array[p] != needle[i])
                    {
                         return false;
                    }
                }
                return true;
            }

            // 在数组中找分区
            public static int Find(byte[] array, byte[] needle, int startIndex, int count)
            {
                int needleLen = needle.Length;
                int index;

                while (count >= needleLen)
                {
                    index = Array.IndexOf(array, needle[0], startIndex, count - needleLen + 1);

                    if (index == -1)
                        return -1;

                    int i, p;
                    for (i = 0, p = index; i < needleLen; i++, p++)
                    {
                        if (array[p] != needle[i])
                        {
                            break;
                        }
                    }

                    if (i == needleLen)
                    {
                        // 找到needle
                        return index;
                    }

                    count -= (index - startIndex + 1);
                    startIndex = index + 1;
                }
                return -1;
            }
        }
}


