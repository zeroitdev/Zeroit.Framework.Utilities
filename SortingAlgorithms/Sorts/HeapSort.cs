// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="HeapSort.cs" company="Zeroit Dev Technologies">
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

        #region Heap Sort

        /// <summary>
        /// HeapSort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void Heapsort(ref int[] x)
        {
            int i;
            int temp;
            int n = x.Length;

            for (i = (n / 2) - 1; i >= 0; i--)
            {
                siftDown(ref x, i, n);
            }

            for (i = n - 1; i >= 1; i--)
            {
                temp = x[0];
                x[0] = x[i];
                x[i] = temp;
                siftDown(ref x, 0, i - 1);
            }
        }

        /// <summary>
        /// Sifts down.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="root">The root.</param>
        /// <param name="bottom">The bottom.</param>
        public static void siftDown(ref int[] x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            int temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (x[root * 2] > x[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (x[root] < x[maxChild])
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        #endregion
        
    }
}
