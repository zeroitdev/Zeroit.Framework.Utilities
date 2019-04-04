// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="InterpolationSearch.cs" company="Zeroit Dev Technologies">
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

        #region Interpolation Search

        /// <summary>
        /// Interpolation search algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="searchValue">The search value.</param>
        /// <returns>System.Int32.</returns>
        public static int InterpolationSearch(ref int[] x, int searchValue)
        {
            // Returns index of searchValue in sorted input data
            // array x, or -1 if searchValue is not found
            int low = 0;
            int high = x.Length - 1;
            int mid;

            while (x[low] < searchValue && x[high] >= searchValue)
            {
                mid = low + ((searchValue - x[low]) * (high - low)) / (x[high] - x[low]);

                if (x[mid] < searchValue)
                    low = mid + 1;
                else if (x[mid] > searchValue)
                    high = mid - 1;
                else
                    return mid;
            }

            if (x[low] == searchValue)
                return low;
            else
                return -1; // Not found
        }
        #endregion
        
    }
}
