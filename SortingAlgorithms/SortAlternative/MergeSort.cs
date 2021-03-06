// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="MergeSort.cs" company="Zeroit Dev Technologies">
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

using System.Collections.Generic;
using System.Linq;


namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
	{
        /// <summary>
        /// Merge sort(also commonly spelled mergesort) is an O(n log n) comparison-based sorting algorithm.
	    /// Most implementations produce a stable sort, which means that the implementation preserves the input
	    /// order of equal elements in the sorted output.        
        /// </summary>
        /// <param name="unsorted">The unsorted.</param>
        /// <returns>List&lt;System.Int32&gt;.</returns>
        public static List<int> MergeSort(List<int> unsorted)
	    {
	        if (unsorted.Count <= 1)
	            return unsorted;

	        List<int> left = new List<int>();
	        List<int> right = new List<int>();

	        int middle = unsorted.Count / 2;
	        for (int i = 0; i < middle; i++)  //Dividing the unsorted list
	        {
	            left.Add(unsorted[i]);
	        }
	        for (int i = middle; i < unsorted.Count; i++)
	        {
	            right.Add(unsorted[i]);
	        }

	        left = MergeSort(left);
	        right = MergeSort(right);
	        return Merge(left, right);
	    }

	    private static List<int> Merge(List<int> left, List<int> right)
	    {
	        List<int> result = new List<int>();

	        while (left.Count > 0 || right.Count > 0)
	        {
	            if (left.Count > 0 && right.Count > 0)
	            {
	                if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
	                {
	                    result.Add(left.First());
	                    left.Remove(left.First());      //Rest of the list minus the first element
	                }
	                else
	                {
	                    result.Add(right.First());
	                    right.Remove(right.First());
	                }
	            }
	            else if (left.Count > 0)
	            {
	                result.Add(left.First());
	                left.Remove(left.First());
	            }
	            else if (right.Count > 0)
	            {
	                result.Add(right.First());

	                right.Remove(right.First());
	            }
	        }
	        return result;
	    }

    }
}
