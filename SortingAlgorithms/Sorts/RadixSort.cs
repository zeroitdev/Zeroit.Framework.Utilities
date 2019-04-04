// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="RadixSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SearchAlgorithm
	{


        #region Radix Sort


        /// <summary>
        /// RadixSort takes an array and the number of bits used as 
	    /// the key in each iteration.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="bits">The bits.</param>
        public static void RadixSort(ref int[] x, int bits)
        {
            //Use an array of the same size as the original array 
            //to store the result of each iteration.
            int[] b = new int[x.Length];
            int[] b_orig = b;

            //Mask is the bitmask used to extract the sort key. 
            //We start with the bits least significant bits and
            //left-shift it the same amount at each iteration. 
            //When all the bits are shifted out of the word, we are done.
            int rshift = 0;
            for (int mask = ~(-1 << bits); mask != 0; mask <<= bits, rshift += bits)
            {
                //An array is needed to store the count for each key value.
                int[] cntarray = new int[1 << bits];

                //Count each key value
                for (int p = 0; p < x.Length; ++p)
                {
                    int key = (x[p] & mask) >> rshift;
                    ++cntarray[key];
                }

                //Sum up how many elements there are with lower 
                //key values, for each key.
                for (int i = 1; i < cntarray.Length; ++i)
                    cntarray[i] += cntarray[i - 1];

                //The values in cntarray are used as indexes 
                //for storing the values in b. b will then be
                //completely sorted on this iteration's key. 
                //Elements with the same key value are stored 
                //in their original internal order.
                for (int p = x.Length - 1; p >= 0; --p)
                {
                    int key = (x[p] & mask) >> rshift;
                    --cntarray[key];
                    b[cntarray[key]] = x[p];
                }

                //Swap the a and b references, so that the 
                //next iteration works on the current b, 
                //which is now partially sorted.
                int[] temp = b; b = x; x = temp;
            }
        }

        #endregion
        
    }
}
