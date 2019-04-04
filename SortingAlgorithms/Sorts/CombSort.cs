// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="CombSort.cs" company="Zeroit Dev Technologies">
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
