// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="InsertionSort.cs" company="Zeroit Dev Technologies">
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
        /// Insertion sort is a simple sorting algorithm that builds the final sorted array(or list) one item at a time.
	    /// It is much less efficient on large lists than more advanced algorithms such as quicksort, heapsort, or merge sort.
        /// </summary>
        /// <param name="inputArray">The input array.</param>
        /// <returns>System.Int32[].</returns>
        public static int[] InsertionSort(int[] inputArray)
	    {
	        for (int i = 0; i < inputArray.Length - 1; i++)
	        {
	            for (int j = i + 1; j > 0; j--)
	            {
	                if (inputArray[j - 1] > inputArray[j])
	                {
	                    int temp = inputArray[j - 1];
	                    inputArray[j - 1] = inputArray[j];
	                    inputArray[j] = temp;
	                }
	            }
	        }
	        return inputArray;
	    }
	    public static string PrintIntegerArray(int[] array)
	    {
            string returnedValues = null;
	        foreach (int i in array)
	        {
	            returnedValues = (i.ToString() + "  ");
	        }

	        return returnedValues;
	    }


        
        public static int[] InsertionSortByShift(int[] inputArray)
	    {
	        for (int i = 0; i < inputArray.Length - 1; i++)
	        {
	            int j;
	            var insertionValue = inputArray[i];
	            for (j = i; j > 0; j--)
	            {
	                if (inputArray[j - 1] > insertionValue)
	                {
	                    inputArray[j] = inputArray[j - 1];
	                }
	            }
	            inputArray[j] = insertionValue;
	        }
	        return inputArray;
	    }

    }
}
