// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="CountSort.cs" company="Zeroit Dev Technologies">
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

        #region Count Sort

        /// <summary>
        /// Count sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void CountSort(ref int[] x)
        {
            try
            {
                int i = 0;
                int k = FindMax(x); //Finds max value of input array

                // output array holds the sorted output
                int[] output = new int[x.Length];

                // provides temperarory storage 
                int[] temp = new int[k + 1];
                for (i = 0; i < k + 1; i++)
                {
                    temp[i] = 0;
                }

                for (i = 0; i < x.Length; i++)
                {
                    temp[x[i]] = temp[x[i]] + 1;
                }

                for (i = 1; i < k + 1; i++)
                {
                    temp[i] = temp[i] + temp[i - 1];
                }

                for (i = x.Length - 1; i >= 0; i--)
                {
                    output[temp[x[i]] - 1] = x[i];
                    temp[x[i]] = temp[x[i]] - 1;
                }

                for (i = 0; i < x.Length; i++)
                {
                    x[i] = output[i];
                }
            }

            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        #endregion
        
    }
}
