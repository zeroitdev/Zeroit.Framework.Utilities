// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="QuickSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
    {

        /// <summary>
        /// Quick sort is a comparison sort, meaning that it can sort items
        /// of any type for which a "less-than" relation(formally, a total order)
        /// is defined.
        /// </summary>
        /// <example>
        /// <code>
        /// Quick_Sort(arr, 0, arr.Length-1);
        /// </code>
        /// </example>
        /// <param name="arr">The arr.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public static void Quick_Sort(int[] arr, int left, int right)
	    {
	        if (left < right)
	        {
	            int pivot = Partition(arr, left, right);

	            if (pivot > 1)
	            {
	                Quick_Sort(arr, left, pivot - 1);
	            }
	            if (pivot + 1 < right)
	            {
	                Quick_Sort(arr, pivot + 1, right);
	            }
	        }

	    }

	    private static int Partition(int[] arr, int left, int right)
	    {
	        int pivot = arr[left];
	        while (true)
	        {

	            while (arr[left] < pivot)
	            {
	                left++;
	            }

	            while (arr[right] > pivot)
	            {
	                right--;
	            }

	            if (left < right)
	            {
	                if (arr[left] == arr[right]) return right;

	                int temp = arr[left];
	                arr[left] = arr[right];
	                arr[right] = temp;


	            }
	            else
	            {
	                return right;
	            }
	        }
	    }

    }
}
