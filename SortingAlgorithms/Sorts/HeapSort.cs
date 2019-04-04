// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="HeapSort.cs" company="Zeroit Dev Technologies">
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

        #region Heap Sort

        /// <summary>
        /// HeapSort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void Heapsort(ref int[] x)
        {
            int i;
            int temp;
            int n = x.Length;

            for (i = (n / 2) - 1; i >= 0; i--)
            {
                siftDown(ref x, i, n);
            }

            for (i = n - 1; i >= 1; i--)
            {
                temp = x[0];
                x[0] = x[i];
                x[i] = temp;
                siftDown(ref x, 0, i - 1);
            }
        }

        /// <summary>
        /// Sifts down.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="root">The root.</param>
        /// <param name="bottom">The bottom.</param>
        public static void siftDown(ref int[] x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            int temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (x[root * 2] > x[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (x[root] < x[maxChild])
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        #endregion
        
    }
}
