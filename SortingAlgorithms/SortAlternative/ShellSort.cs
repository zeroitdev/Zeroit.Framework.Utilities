// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="ShellSort.cs" company="Zeroit Dev Technologies">
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
