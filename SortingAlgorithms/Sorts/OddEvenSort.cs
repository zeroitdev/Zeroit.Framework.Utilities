// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="OddEvenSort.cs" company="Zeroit Dev Technologies">
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

        #region Odd Even Sort
        /// <summary>
        /// Even Sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void OddEvenSort(ref int[] x)
        {
            int temp;
            for (int i = 0; i < x.Length / 2; ++i)
            {
                for (int j = 0; j < x.Length - 1; j += 2)
                {
                    if (x[j] > x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }

                for (int j = 1; j < x.Length - 1; j += 2)
                {
                    if (x[j] > x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }
            }
        }
        
	    #endregion
        
    }
}
