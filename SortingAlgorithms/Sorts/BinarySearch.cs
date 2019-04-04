// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="BinarySearch.cs" company="Zeroit Dev Technologies">
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

        #region Binary Search

        /// <summary>
        /// Binary search algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="searchValue">The search value.</param>
        /// <returns>System.Int32.</returns>
        public static int BinarySearch(ref int[] x, int searchValue)
        {
            // Returns index of searchValue in sorted array x, or -1 if not found
            int left = 0;
            int right = x.Length;
            return BinarySearch(ref x, searchValue, left, right);
        }

        /// <summary>
        /// Binary search helper function.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>System.Int32.</returns>
        private static int BinarySearch(ref int[] x, int searchValue, int left, int right)
        {
            if (right < left)
            {
                return -1;
            }
            int mid = (left + right) >> 1;
            if (searchValue > x[mid])
            {
                return BinarySearch(ref x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid])
            {
                return BinarySearch(ref x, searchValue, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }
        #endregion
        
    }
}
