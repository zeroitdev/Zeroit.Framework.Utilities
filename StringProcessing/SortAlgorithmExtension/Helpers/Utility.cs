// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Utility.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.Sort
{
    /// <summary>
    /// Class Utility.
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Swaps the specified item1.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        static internal void Swap<T>(ref T item1, ref T item2) 
        {
            T dummy = item2;
            item2 = item1;
            item1 = dummy;
        }

        /// <summary>
        /// Heapifies the specified heap index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="heapIndex">Index of the heap.</param>
        /// <param name="array">The array.</param>
        /// <param name="count">The count.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="order">The order.</param>
        /// <exception cref="ApplicationException">The sort order exception should be determined</exception>
        static internal void Heapify<T>(int heapIndex, T[] array, int count,IComparer<T>comparer,SortOrder order)
        {
            int firstdescendantIndex = 2 * heapIndex + 1;    // the first descendant 
            while (firstdescendantIndex < count)
            {

                switch (order)
                {
                    case SortOrder.Ascending:
                    if (firstdescendantIndex + 1 < count)    // check for a second descendant
                    if (comparer.Compare(array[firstdescendantIndex + 1] , array[firstdescendantIndex]) > 0) firstdescendantIndex++;


                    if (comparer.Compare(array[heapIndex] ,array[firstdescendantIndex]) >= 0) return;  // the actual is heap so the job is done
                    // otherwise
                    Swap(ref array[heapIndex], ref  array[firstdescendantIndex]);  // exchange firstdescendant and heap indexes
                    heapIndex = firstdescendantIndex;        // continue
                    firstdescendantIndex = 2 * heapIndex + 1;
                        break;
                    case SortOrder.Descending:
                        if (firstdescendantIndex + 1 < count)    // check for a second descendant
                            if (comparer.Compare(array[firstdescendantIndex + 1], array[firstdescendantIndex]) < 0) firstdescendantIndex++;


                        if (comparer.Compare(array[heapIndex], array[firstdescendantIndex]) <= 0) return;  // the actual is heap so the job is done
                        // otherwise
                        Swap(ref array[heapIndex], ref  array[firstdescendantIndex]);  // exchange firstdescendant and heap indexes
                        heapIndex = firstdescendantIndex;        // continue
                        firstdescendantIndex = 2 * heapIndex + 1;
                        break;
                        default:
                        throw new ApplicationException("The sort order exception should be determined");
                        
                }
                
                
            }
        }

    }

    

    
}
