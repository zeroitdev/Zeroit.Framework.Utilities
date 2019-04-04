// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="MthSmallest.cs" company="Zeroit Dev Technologies">
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


        #region Mth Smallest

        /// <summary>
        /// MTH smallest algorithm.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="m">The m.</param>
        /// <returns>System.Int32.</returns>
        public static int MthSmallest1(int[] array, int m)
        {
            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            //Sort the array
            QuickSort(ref tempArray);
            //Return the m-th smallest value in the sorted array
            return tempArray[m - 1];
        }

        /// <summary>
        /// MTH smallest algorithm.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="m">The m.</param>
        /// <returns>System.Int32.</returns>
        public static int MthSmallest2(int[] array, int m)
        {
            int minIndex;
            int minValue;

            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            for (int i = 0; i < m; i++)
            {
                minIndex = i;      // index of minimum element
                minValue = tempArray[i];// assume minimum is the first array element
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (tempArray[j] < minValue)
                    {   // capture it
                        minIndex = j;
                        minValue = tempArray[j];
                    }
                }
                Swap(ref tempArray[i], ref tempArray[minIndex]);
            }
            return tempArray[m - 1];
        }
        #endregion
        
    }
}
