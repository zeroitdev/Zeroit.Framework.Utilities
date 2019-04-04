// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="MergeSort.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.Search
{

    /// <summary>
    /// Class SearchAlgorithm.
    /// </summary>
    public static partial class SearchAlgorithm
	{


        #region Merge Sort

        /// <summary>
        /// MergeSort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public static void MergeSort(ref int[] x, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(ref x, left, middle);
                MergeSort(ref x, middle + 1, right);
                Merge(ref x, left, middle, middle + 1, right);
            }
        }

        /// <summary>
        /// Merges the specified array.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="left">The left.</param>
        /// <param name="middle">The middle.</param>
        /// <param name="middle1">The middle1.</param>
        /// <param name="right">The right.</param>
        private static void Merge(ref int[] x, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            int[] temp = new int[size];
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (x[left] <= x[middle1])
                    temp[i++] = x[left++];
                else
                    temp[i++] = x[middle1++];
            }
            if (left > middle)
                for (int j = middle1; j <= right; j++)
                    temp[i++] = x[middle1++];
            else
                for (int j = left; j <= middle; j++)
                    temp[i++] = x[left++];
            Array.Copy(temp, 0, x, oldPosition, size);
        }
        #endregion
        
    }
}
