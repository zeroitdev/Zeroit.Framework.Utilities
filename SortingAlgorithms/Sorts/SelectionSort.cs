// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="SelectionSort.cs" company="Zeroit Dev Technologies">
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

        #region Selection Sort

        /// <summary>
        /// Selection sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void SelectionSort(ref int[] x)
        {
            int i, j;
            int min, temp;

            for (i = 0; i < x.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < x.Length; j++)
                {
                    if (x[j] < x[min])
                    {
                        min = j;
                    }
                }
                temp = x[i];
                x[i] = x[min];
                x[min] = temp;
            }
        }
        #endregion
        
    }
}
