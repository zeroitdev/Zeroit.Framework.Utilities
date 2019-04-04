// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="HeapSort.cs" company="Zeroit Dev Technologies">
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
using System;

namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
	{


        /// <summary>
        /// Heapsort can be thought of as an improved selection sort: like that algorithm,
	    /// it divides its input into a sorted and an unsorted region, and it interactively
	    /// shrinks the unsorted region by extracting the largest element and moving that to
	    /// the sorted region.
	    /// The improvement consists of the use of a heap data structure
	    /// rather than a linear-time search to find the maximum.
	    /// Although somewhat slower in practice on most machines than a well-implemented
	    /// quicksort, it has the advantage of a more favorable worst-case O(n log n) runtime.
	    /// Heapsort is an in-place algorithm, but it is not a stable sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        public static void HeapSort<T>(T[] array) where T : IComparable<T>
	    {
	        int heapSize = array.Length;

	        BuildMaxHeap(array);

	        for (int i = heapSize - 1; i >= 1; i--)
	        {
	            Swap(array, i, 0);
	            heapSize--;
	            Sink(array, heapSize, 0);
	        }
	    }

	    private static void BuildMaxHeap<T>(T[] array) where T : IComparable<T>
	    {
	        int heapSize = array.Length;

	        for (int i = (heapSize / 2) - 1; i >= 0; i--)
	        {
	            Sink(array, heapSize, i);
	        }
	    }

	    private static void Sink<T>(T[] array, int heapSize, int toSinkPos) where T : IComparable<T>
	    {
	        if (GetLeftKidPos(toSinkPos) >= heapSize)
	        {
	            // No left kid => no kid at all
	            return;
	        }


	        int largestKidPos;
	        bool leftIsLargest;

	        if (GetRightKidPos(toSinkPos) >= heapSize || array[GetRightKidPos(toSinkPos)].CompareTo(array[GetLeftKidPos(toSinkPos)]) < 0)
	        {
	            largestKidPos = GetLeftKidPos(toSinkPos);
	            leftIsLargest = true;
	        }
	        else
	        {
	            largestKidPos = GetRightKidPos(toSinkPos);
	            leftIsLargest = false;
	        }



	        if (array[largestKidPos].CompareTo(array[toSinkPos]) > 0)
	        {
	            Swap(array, toSinkPos, largestKidPos);

	            if (leftIsLargest)
	            {
	                Sink(array, heapSize, GetLeftKidPos(toSinkPos));

	            }
	            else
	            {
	                Sink(array, heapSize, GetRightKidPos(toSinkPos));
	            }
	        }

	    }

	    private static void Swap<T>(T[] array, int pos0, int pos1)
	    {
	        T tmpVal = array[pos0];
	        array[pos0] = array[pos1];
	        array[pos1] = tmpVal;
	    }

	    private static int GetLeftKidPos(int parentPos)
	    {
	        return (2 * (parentPos + 1)) - 1;
	    }

	    private static int GetRightKidPos(int parentPos)
	    {
	        return 2 * (parentPos + 1);
	    }

	    public static string HeapSortArrayToString<T>(T[] array)
	    {
            string returnedValues = null;
	        foreach (T t in array)
	        {
	            returnedValues = ' ' + t.ToString() + ' ';
	        }

	        return returnedValues;

	    }

    }
}
