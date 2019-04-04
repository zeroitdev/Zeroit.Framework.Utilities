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

    /// <summary>
    /// Class SearchAlgorithm.
    /// </summary>
    public static partial class SearchAlgorithm
	{

        #region Insertion Sort
        /// <summary>
        /// Insertion sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void InsertionSort(ref int[] x)
        {
            int n = x.Length - 1;
            int i, j, temp;

            for (i = 1; i <= n; ++i)
            {
                temp = x[i];
                for (j = i - 1; j >= 0; --j)
                {
                    if (temp < x[j]) x[j + 1] = x[j];
                    else break;
                }
                x[j + 1] = temp;
            }
        }
        #endregion
        
    }
}
