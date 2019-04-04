// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="ShellSort.cs" company="Zeroit Dev Technologies">
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

        #region Shell Sort

        /// <summary>
        /// Shell sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void ShellSort(ref int[] x)
        {
            int i, j, temp;
            int increment = 3;

            while (increment > 0)
            {
                for (i = 0; i < x.Length; i++)
                {
                    j = i;
                    temp = x[i];

                    while ((j >= increment) && (x[j - increment] > temp))
                    {
                        x[j] = x[j - increment];
                        j = j - increment;
                    }

                    x[j] = temp;
                }

                if (increment / 2 != 0)
                {
                    increment = increment / 2;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }
        }
        #endregion
        
    }
}
