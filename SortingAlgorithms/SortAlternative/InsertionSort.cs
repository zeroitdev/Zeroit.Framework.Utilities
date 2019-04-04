// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="InsertionSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
