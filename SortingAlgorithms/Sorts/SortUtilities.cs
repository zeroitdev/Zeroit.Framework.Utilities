// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="SortUtilities.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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


        #region Miscellaneous Utilities

        /// <summary>
        /// Finds the maximum.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>System.Int32.</returns>
        public static int FindMax(int[] x)
        {
            int max = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > max) max = x[i];
            }
            return max;
        }

        /// <summary>
        /// Finds the minimum.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>System.Int32.</returns>
        public static int FindMin(int[] x)
        {
            int min = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] < min) min = x[i];
            }
            return min;
        }

        /// <summary>
        /// Mixes the data up.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="rdn">The RDN.</param>
        static void MixDataUp(ref int[] x, Random rdn)
        {
            for (int i = 0; i <= x.Length - 1; i++)
            {
                x[i] = (int)(rdn.NextDouble() * x.Length);
            }
        }

        /// <summary>
        /// Swaps the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        static void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        // Determines if int array is sorted from 0 -> Max
        /// <summary>
        /// Determines whether the specified arr is sorted.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns><c>true</c> if the specified arr is sorted; otherwise, <c>false</c>.</returns>
        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if string array is sorted from A -> Z
        /// <summary>
        /// Determines whether the specified arr is sorted.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns><c>true</c> if the specified arr is sorted; otherwise, <c>false</c>.</returns>
        public static bool IsSorted(string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0) // If previous is bigger, return false
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if int array is sorted from Max -> 0
        /// <summary>
        /// Determines whether [is sorted descending] [the specified arr].
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns><c>true</c> if [is sorted descending] [the specified arr]; otherwise, <c>false</c>.</returns>
        public static bool IsSortedDescending(int[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if string array is sorted from Z -> A
        /// <summary>
        /// Determines whether [is sorted descending] [the specified arr].
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns><c>true</c> if [is sorted descending] [the specified arr]; otherwise, <c>false</c>.</returns>
        public static bool IsSortedDescending(string[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i].CompareTo(arr[i + 1]) < 0) // If previous is smaller, return false
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Displays the elements.
        /// </summary>
        /// <param name="xArray">The x array.</param>
        /// <param name="status">The status.</param>
        /// <param name="sortname">The sortname.</param>
        /// <returns>System.String.</returns>
        public static string DisplayElements(ref int[] xArray, char status, string sortname)
        {
            string returnedValue = null;
            for (int i = 0; i <= xArray.Length - 1; i++)
            {
                if ((i != 0) && (i % 10 == 0))
                    returnedValue = ("\n");
                returnedValue +=(xArray[i] + " ");
            }

            return returnedValue;
        }
        #endregion
    }
}
