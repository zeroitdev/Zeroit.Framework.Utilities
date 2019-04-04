// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="ShellSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
	{
        
	    /// <summary>
	    ///The method starts by sorting pairs of elements far apart from each other,
	    ///then progressively reducing the gap between elements to be compared.
	    ///Starting with far apart elements can move some out-of-place elements into
	    ///position faster than a simple nearest neighbor exchange.        
	    /// </summary>
	    /// <param name="arr">The arr.</param>
	    /// <param name="array_size">Size of the array.</param>
	    public static void ShellSort(int[] arr, int arraySize)
	    {
	        int i, j, inc, temp;
	        inc = 3;
	        while (inc > 0)
	        {
	            for (i = 0; i < arraySize; i++)
	            {
	                j = i;
	                temp = arr[i];
	                while ((j >= inc) && (arr[j - inc] > temp))
	                {
	                    arr[j] = arr[j - inc];
	                    j = j - inc;
	                }
	                arr[j] = temp;
	            }
	            if (inc / 2 != 0)
	                inc = inc / 2;
	            else if (inc == 1)
	                inc = 0;
	            else
	                inc = 1;
	        }

	        
	    }

        public static string ShowArrowElements(int[] arr)
	    {
	        string returnedValues = null;

	        foreach (var element in arr)
	        {
	            returnedValues =  element.ToString() + "\n";
	        }
            
	        return returnedValues;
	    }
        

    }
}
