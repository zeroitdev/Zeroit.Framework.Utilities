// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="PermutationSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
