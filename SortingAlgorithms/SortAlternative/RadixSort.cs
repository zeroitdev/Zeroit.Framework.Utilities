
using System;


namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
    {


        /// <summary>
        /// Radix sort is a non-comparative integer sorting algorithm
        /// that sorts data with integer keys by grouping keys by the
        /// individual digits which share the same significant position and value.
        /// </summary>
        /// <param name="arr">The arr.</param>
        public static void RadixSort(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
        }
    }
}
