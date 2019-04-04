// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="CountingSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
	{


        /// <summary>
	    ///In computer science, counting sort is an algorithm for sorting a
	    ///collection of objects according to keys that are small integers;
	    ///that is, it is an integer sorting algorithm.
	    ///It operates by counting
	    ///the number of objects that have each distinct key value, and using
	    ///arithmetic on those counts to determine the positions of each key
	    ///value in the output sequence.
	    ///Its running time is linear in the number
	    ///of items and the difference between the maximum and minimum key values,
	    ///so it is only suitable for direct use in situations where the variation
	    ///in keys is not significantly greater than the number of items.
	    ///However, it is often used as a subroutine in another sorting algorithm,
	    ///radix sort, that can handle larger keys more efficiently
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>System.Int32[].</returns>
        public static int[] CountingSort(int[] array)
        {
            
            int[] sortedArray = new int[array.Length];

            // find smallest and largest value
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }

            return sortedArray;
        }
    }
}
