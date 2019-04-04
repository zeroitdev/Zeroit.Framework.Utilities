// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="QuickSort.cs" company="Zeroit Dev Technologies">
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

        #region Quick Sort

        /// <summary>
        /// Quick sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void QuickSort(ref int[] x)
        {
            qs(x, 0, x.Length - 1);
        }

        /// <summary>
        /// Quick sort helper function.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        private static void qs(int[] x, int left, int right)
        {
            int i, j;
            int pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }

        #endregion
        
    }
}
