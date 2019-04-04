// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="QuickSort.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
