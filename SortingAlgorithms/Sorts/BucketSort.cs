// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="BucketSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.Search
{

    /// <summary>
    /// Class SearchAlgorithm.
    /// </summary>
    public static partial class SearchAlgorithm
	{

        #region Bucket Sort

        /// <summary>
        /// Bucket sort algorithm.
        /// </summary>
        /// <param name="x">The x.</param>
        public static void BucketSort(ref int[] x)
        {
            //Verify input
            if (x == null || x.Length <= 1)
                return;

            //Find the maximum and minimum values in the array
            int maxValue = x[0];
            int minValue = x[0];

            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > maxValue)
                    maxValue = x[i];

                if (x[i] < minValue)
                    minValue = x[i];
            }

            //Create a temporary "bucket" to store the values in order
            //each value will be stored in its corresponding index
            //scooting everything over to the left as much as possible (minValue)
            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            //Move items to bucket
            for (int i = 0; i < x.Length; i++)
            {
                if (bucket[x[i] - minValue] == null)
                    bucket[x[i] - minValue] = new LinkedList<int>();

                bucket[x[i] - minValue].AddLast(x[i]);
            }

            //Move items in the bucket back to the original array in order
            int k = 0; //index for original array
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First; //start add head of linked list

                    while (node != null)
                    {
                        x[k] = node.Value; //get value of current linked node
                        node = node.Next; //move to next linked node
                        k++;
                    }
                }
            }
        }
        #endregion
        
    }
}
