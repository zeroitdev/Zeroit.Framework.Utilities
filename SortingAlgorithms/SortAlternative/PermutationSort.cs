// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="PermutationSort.cs" company="Zeroit Dev Technologies">
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
        /// Permutation sort, proceeds by generating the possible permutations
	    /// of the input array/list until discovering the sorted one.
        /// </summary>
        /// <param name="list">The list.</param>
        public static void PermutationSort(char[] list)
	    {
	        int x = list.Length - 1;
	        GetPer(list, 0, x);
	    }

	    private static void Swap(ref char a, ref char b)
	    {
	        if (a == b) return;

	        a ^= b;
	        b ^= a;
	        a ^= b;
	    }

        private static void GetPer(char[] list, int k, int m)
	    {
	        
	        if (k != m)
	        {
	            for (int i = k; i <= m; i++)
	            {
	                Swap(ref list[k], ref list[i]);
	                GetPer(list, k + 1, m);
	                Swap(ref list[k], ref list[i]);
	            }
            }
	            
	    }
    }
}
