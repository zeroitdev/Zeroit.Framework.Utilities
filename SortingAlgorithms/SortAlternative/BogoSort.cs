// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="BogoSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
	{



        /// <summary>
        /// In computer science, bogosor is a particularly ineffective
	    /// sorting algorithm based on the generate and test paradigm.
	    /// The algorithm successively generates permutations of its
	    /// input until it finds one that is sorted.
	    /// It is not useful for sorting, but may be used for educational
	    /// purposes, to contrast it with other more realistic algorithms..
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="announce">if set to <c>true</c> [announce].</param>
        /// <param name="delay">The delay.</param>
        public static void BogoSort(List<int> list, bool announce, int delay)
	    {
	        int iteration = 0;
	        while (!IsSorted(list))
	        {
	            if (announce)
	            {
	                Print_Iteration(list, iteration);
	            }
	            if (delay != 0)
	            {
	                System.Threading.Thread.Sleep(Math.Abs(delay));
	            }
	            list = Remap(list);
	            iteration++;
	        }

	        Print_Iteration(list, iteration);

            
	    }

	    private static string Print_Iteration(List<int> list, int iteration)
	    {
            string returnedValue = null;
	        for (int i = 0; i < list.Count; i++)
	        {
	            returnedValue = (list[i].ToString());
	            if (i < list.Count)
	            {
	                returnedValue += (" ");
	            }
	        }

	        return returnedValue;
	    }
	    private static bool IsSorted(List<int> list)
	    {
	        for (int i = 0; i < list.Count - 1; i++)
	        {
	            if (list[i] > list[i + 1])
	            {
	                return false;
	            }
	        }

	        return true;
	    }
        private static List<int> Remap(List<int> list)
	    {
	        int temp;
	        List<int> newList = new List<int>();
	        Random r = new Random();

	        while (list.Count > 0)
	        {
	            temp = (int)r.Next(list.Count);
	            newList.Add(list[temp]);
	            list.RemoveAt(temp);
	        }
	        return newList;
	    }
    }
}
