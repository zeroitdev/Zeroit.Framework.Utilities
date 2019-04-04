// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="CombSort.cs" company="Zeroit Dev Technologies">
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

        #region Comb Sort
        /// <summary>
        /// ComboSort helper function.
        /// </summary>
        /// <param name="gap">The gap.</param>
        /// <returns>System.Int32.</returns>
        private static int NewGap(int gap)
        {
            gap = gap * 10 / 13;
            if (gap == 9 || gap == 10)
                gap = 11;
            if (gap < 1)
                return 1;
            return gap;
        }

        /// <summary>
        /// Combo Sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void CombSort(ref int[] x)
        {
            int gap = x.Length;
            bool swapped;
            do
            {
                swapped = false;
                gap = NewGap(gap);
                for (int i = 0; i < (x.Length - gap); i++)
                {
                    if (x[i] > x[i + gap])
                    {
                        swapped = true;
                        int temp = x[i];
                        x[i] = x[i + gap];
                        x[i + gap] = temp;
                    }
                }
            } while (gap > 1 || swapped);
        }
        #endregion
        
    }
}
