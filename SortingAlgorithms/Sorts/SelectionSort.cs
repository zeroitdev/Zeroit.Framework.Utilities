// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="SelectionSort.cs" company="Zeroit Dev Technologies">
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
