// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="CocktailSort.cs" company="Zeroit Dev Technologies">
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

        #region Cocktail Sort
        /// <summary>
        /// Cocktail sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void CocktailSort(ref int[] x)
        {
            for (int k = x.Length - 1; k > 0; k--)
            {
                bool swapped = false;
                for (int i = k; i > 0; i--)
                    if (x[i] < x[i - 1])
                    {
                        // swap
                        int temp = x[i];
                        x[i] = x[i - 1];
                        x[i - 1] = temp;
                        swapped = true;
                    }

                for (int i = 0; i < k; i++)
                    if (x[i] > x[i + 1])
                    {
                        // swap
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        swapped = true;
                    }

                if (!swapped)
                    break;
            }
        }
        #endregion
        
    }
}
