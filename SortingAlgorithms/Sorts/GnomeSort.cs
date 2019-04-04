// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="GnomeSort.cs" company="Zeroit Dev Technologies">
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

        #region Gnome Sort
        /// <summary>
        /// Gnome sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void GnomeSort(ref int[] x)
        {
            int i = 0;
            while (i < x.Length)
            {
                if (i == 0 || x[i - 1] <= x[i]) i++;
                else
                {
                    int temp = x[i];
                    x[i] = x[i - 1];
                    x[--i] = temp;
                }
            }
        }
        #endregion
        
    }
}
