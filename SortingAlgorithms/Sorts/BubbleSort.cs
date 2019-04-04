// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="BubbleSort.cs" company="Zeroit Dev Technologies">
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
        #region Bubble Sorts

        /// <summary>
        /// Bubble sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void BubbleSort1(ref int[] x)
        {
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < x.Length - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        // Exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        exchanges = true;
                    }
                }
            } while (exchanges);
        }

	    /// <summary>
	    /// Bubble sort algorithm.
	    /// </summary>
	    /// <param name="x">The x.</param>
        public static void BubbleSort2(ref int[] x)
        {
            for (int pass = 1; pass < x.Length - 1; pass++)
            {
                // Count how many times this next looop
                // becomes shorter and shorter
                for (int i = 0; i < x.Length - pass; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        // Exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                    }
                }
            }
        }

	    /// <summary>
	    /// Bubble sort algorithm.
	    /// </summary>
	    /// <param name="x">The x.</param>
        public static void BubbleSort3(ref int[] x)
        {
            bool exchanges;
            int n = x.Length;
            do
            {
                n--; // Make loop smaller each time.
                     // and assume this is last pass over array
                exchanges = false;
                for (int i = 0; i < x.Length - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        // Exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        exchanges = true;
                    }
                }
            } while (exchanges);
        }

	    /// <summary>
	    /// Bubble sort range algorithm.
	    /// </summary>
	    /// <param name="x">The x.</param>
        public static void BubbleSortRange(ref int[] x)
        {
            int lowerBound = 0; // First position to compare.
            int upperBound = x.Length - 1; // First position NOT to compare.
            int n = x.Length - 1;

            // Continue making passes while there is a potential exchange.
            while (lowerBound <= upperBound)
            {
                int firstExchange = n;  // assume impossibly high index for low end.
                int lastExchange = -1; // assume impossibly low index for high end.

                // Make a pass over the appropriate range.
                for (int i = lowerBound; i < upperBound; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        // Exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        // Remember first and last exchange indexes.
                        if (i < firstExchange)
                        {   // True only for first exchange.
                            firstExchange = i;
                        }
                        lastExchange = i;
                    }
                }

                //--- Prepare limits for next pass.
                lowerBound = firstExchange - 1;
                if (lowerBound < 0)
                {
                    lowerBound = 0;
                }
                upperBound = lastExchange;
            }
        }
        #endregion
        
    }
}
