// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="NthLargest.cs" company="Zeroit Dev Technologies">
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



        #region Nth Largest

        /// <summary>
        /// NTH Largest algorithm.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="n">The n.</param>
        /// <returns>System.Int32.</returns>
        public static int NthLargest1(int[] array, int n)
        {
            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            //Sort the array
            QuickSort(ref tempArray);
            //Return the n-th largest value in the sorted array
            return tempArray[tempArray.Length - n];
        }

        /// <summary>
        /// NTH Largest algorithm.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="k">The k.</param>
        /// <returns>System.Int32.</returns>
        public static int NthLargest2(int[] array, int k)
        {
            int maxIndex;
            int maxValue;

            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            for (int i = 0; i < k; i++)
            {
                maxIndex = i;       // index of minimum element
                maxValue = tempArray[i];// assume minimum is the first array element
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    // if we've located a higher value
                    if (tempArray[j] > maxValue)
                    {   // capture it
                        maxIndex = j;
                        maxValue = tempArray[j];
                    }
                }
                Swap(ref tempArray[i], ref tempArray[maxIndex]);
            }
            return tempArray[k - 1];
        }
        #endregion
        
    }
}
