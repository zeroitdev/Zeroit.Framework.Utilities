// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="BogoSort.cs" company="Zeroit Dev Technologies">
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
