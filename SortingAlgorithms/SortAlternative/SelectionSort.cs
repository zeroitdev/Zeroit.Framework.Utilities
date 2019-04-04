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

using System;


namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
    {
        //private int[] data;
        private static Random generator = new Random();


        /// <summary>
        /// The selection sort improves on the bubble sort by
        /// making only one exchange for every pass through the list.
        /// </summary>
        /// <param name="data">The data.</param>
        public static void Sort(int[] data)
        {
            //int[] data = new int[size];
            for (int i = 0; i < /*size*/data.Length - 1; i++)
            {
                data[i] = generator.Next(20, 90);
            }
            
            int smallest;
            for (int i = 0; i < data.Length - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < data.Length; index++)
                {
                    if (data[index] < data[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(data,i, smallest);
                
            }

        }

        private static void Swap(int[] data, int first, int second)
        {
            int temporary = data[first];
            data[first] = data[second];
            data[second] = temporary;
        }

        
    }
}
