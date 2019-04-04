// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="BinarySearch.cs" company="Zeroit Dev Technologies">
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
