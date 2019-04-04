// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SortClass.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;


namespace Zeroit.Framework.Utilities.Sort
{
    /// <summary>
    /// This sort class is a static class that holds exrension methods, those last ones extend
    /// the IEnumerable objects so that they use sort algorithms other than the built in one
    /// within the microsoft staff. The raison is for performance issues some algorithms are
    /// avantagous over other ones.
    /// </summary>
    public static class SortClass
    {

        #region exchange sorts

        /// <summary>
        /// This is the SortBubble algorithm method
        /// </summary>
        /// <typeparam name="T">The generic type</typeparam>
        /// <param name="items">The IEnumerable going to be sorted</param>
        /// <param name="comparer">The comparer class used to sort collection objects</param>
        /// <param name="order">The order to follow when sorting objects either ascending or descending sens</param>
        /// <returns>The sorted IEnumerable object</returns>
        /// <exception cref="ApplicationException">Order sould be precised</exception>
        static public IEnumerable<T> SortBubble<T>(this IEnumerable<T> items, IComparer<T> comparer,SortOrder order)
        {
            T[] array = Enumerable.ToArray(items);

            int count = array.Count();
            do
            {
                for (int i = 0; i < count - 1; i++)
                {
                    switch (order)
                    {
                        case SortOrder.Descending:
                            if (comparer.Compare(array[i], array[i + 1]) < 0)
                            {
                                Utility.Swap(ref array[i], ref array[i + 1]);
                            } 
                            break;
                        case SortOrder.Ascending:
                            if (comparer.Compare(array[i], array[i + 1]) > 0)
                            {
                                Utility.Swap(ref array[i], ref array[i + 1]);
                            } 
                            break;
                        default:
                            throw new ApplicationException("Order sould be precised");
                    }
                }
                count--;

            } while (count > 1);
            
            foreach (var item in array)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Sorts the cocktail.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="order">The order.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="ApplicationException">The sort order exception should be determined</exception>
        static public IEnumerable<T> SortCocktail<T>(this IEnumerable<T> items, IComparer<T> comparer, SortOrder order) 
        {
            T[] array = Enumerable.ToArray(items);
            int count = array.Count();
            bool flag = false;

            switch (order)
            {
                case SortOrder.Ascending:
                    do
                    {
                        flag = false;

                        for (int i = 0; i < count - 2; i++)
                        {
                            if (comparer.Compare(array[i], array[i + 1]) > 0)
                            {
                                Utility.Swap(ref array[i], ref array[i + 1]);
                                flag = true;
                            }
                        }
                        if (flag == false)
                        {
                            break;
                        }
                        flag = false;

                        for (int i = count - 2; i > 0; i--)
                        {
                            if (comparer.Compare(array[i], array[i + 1]) > 0)
                            {
                                Utility.Swap(ref array[i], ref array[i + 1]);
                                flag = true;
                            }
                        }

                    } while (flag == true);
                    break;
                    case SortOrder.Descending:
                    do
                    {
                        flag = false;

                        for (int i = 0; i < count - 2; i++)
                        {
                            if (comparer.Compare(array[i], array[i + 1]) < 0)
                            {
                                Utility.Swap(ref array[i], ref array[i + 1]);
                                flag = true;
                            }
                        }
                        if (flag == false)
                        {
                            break;
                        }
                        flag = false;

                        for (int i = count - 2; i > 0; i--)
                        {
                            if (comparer.Compare(array[i], array[i + 1]) < 0)
                            {
                                Utility.Swap(ref array[i], ref array[i + 1]);
                                flag = true;
                            }
                        }

                    } while (flag == true);
                    break;
                default:
                    throw new ApplicationException("The sort order exception should be determined");
            }


            foreach (var item in array)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Sorts the even odd.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="order">The order.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="ApplicationException">The sort order exception should be determined</exception>
        static public IEnumerable<T> SortEvenOdd<T>(this IEnumerable<T> items, IComparer<T> comparer, SortOrder order)
        {

            T[] array = Enumerable.ToArray(items);
            int count = array.Count();
            int Max = (count % 2 == 0) ? 2 * (count / 2) - 1 : 2 * (count - 1) / 2;

            switch (order)
            {
                case SortOrder.Ascending:
                    for (int i = 0; i < count / 2; i++)
                    {
                        for (int j = 0; j < Max; j++)
                        {
                            if (comparer.Compare(array[j], array[j + 1]) > 0)
                            {
                                Utility.Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                        for (int j = 1; j < Max; j++)
                        {
                            if (comparer.Compare(array[j], array[j + 1]) > 0)
                            {
                                Utility.Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                    break;
                case SortOrder.Descending:
                    for (int i = 0; i < count / 2; i++)
                    {
                        for (int j = 0; j < Max; j++)
                        {
                            if (comparer.Compare(array[j], array[j + 1]) < 0)
                            {
                                Utility.Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                        for (int j = 1; j < Max; j++)
                        {
                            if (comparer.Compare(array[j], array[j + 1]) < 0)
                            {
                                Utility.Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                    break;
                default:
                    throw new ApplicationException("The sort order exception should be determined");
            }
            
            
            
            for (int i = 0; i < count / 2; i++)
            {
                for (int j = 0; j < Max; j++)
                {
                    if (comparer.Compare(array[j] , array[j + 1])>0)
                    {
                        Utility.Swap(ref array[j], ref array[j + 1]);
                    }
                }
                for (int j = 1; j < Max; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Utility.Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            foreach (var item in array)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Sorts the comb.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="order">The order.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="ApplicationException">The sort order exception should be determined</exception>
        static public IEnumerable<T> SortComb<T>(this IEnumerable<T> items, IComparer<T> comparer, SortOrder order)
        {
            T[] array = Enumerable.ToArray(items);
            int count = array.Count();

            int gap = count;
            bool swapped = true;

            switch (order)
            {
                case SortOrder.Ascending:
                    while (gap > 1 || swapped)
                    {
                        if (gap > 1)
                            gap = (int)(gap / 1.247330950103979);

                        int i = 0;
                        swapped = false;
                        while (i + gap < count)
                        {
                            if (comparer.Compare(array[i], array[i + gap]) > 0)
                            {
                                Utility.Swap(ref array[i], ref  array[i + gap]);
                                swapped = true;
                            }
                            i++;
                        }
                    }
                    break;
                case SortOrder.Descending:
                    while (gap > 1 || swapped)
                    {
                        if (gap > 1)
                            gap = (int)(gap / 1.247330950103979);

                        int i = 0;
                        swapped = false;
                        while (i + gap < count)
                        {
                            if (comparer.Compare(array[i], array[i + gap]) < 0)
                            {
                                Utility.Swap(ref array[i], ref  array[i + gap]);
                                swapped = true;
                            }
                            i++;
                        }
                    }
                    break;
                default:
                    throw new ApplicationException("The sort order exception should be determined");
            }
            
            
            
            while (gap > 1 || swapped)
            {
                if (gap > 1)
                    gap = (int)(gap / 1.247330950103979);

                int i = 0;
                swapped = false;
                while (i + gap < count)
                {
                    if (comparer.Compare(array[i], array[i + gap]) > 0)
                    {
                        Utility.Swap(ref array[i], ref  array[i + gap]);
                        swapped = true;
                    }
                    i++;
                }
            }
            
            foreach (var item in array)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Sorts the genome.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="order">The order.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="ApplicationException">The sort order exception should be determined</exception>
        static public IEnumerable<T> SortGenome<T>(this IEnumerable<T> items,IComparer<T> comparer, SortOrder order)
        {

            T[] array = Enumerable.ToArray(items);
            int count = array.Count();


            int position = 0;


            switch (order)
            {
                case SortOrder.Ascending:
                    position = 0;
                    while (position < count)
                    {
                        if (position == 0 || comparer.Compare(array[position] , array[position - 1])>0)
                        {
                            position++;
                        }
                        else
                        {
                            Utility.Swap(ref array[position], ref array[position - 1]);
                            position = position - 1;
                        }
                    }
                    break;
                case SortOrder.Descending:
                    position = 0;
                    while (position < count)
                    {
                        if (position == 0 || comparer.Compare(array[position] , array[position - 1])<0)
                        {
                            position++;
                        }
                        else
                        {
                            Utility.Swap(ref array[position], ref array[position - 1]);
                            position = position - 1;
                        }
                    }
                    break;
                default:
                    throw new ApplicationException("The sort order exception should be determined");
            }
             

            
            
            foreach (var item in array)
            {
                yield return item;
            }
        }

        #endregion


        #region selection sorts
        /// <summary>
        /// Sorts the selection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="order">The order.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="ApplicationException">The sort order exception should be determined</exception>
        static public IEnumerable<T> SortSelection<T>(this IEnumerable<T> items, IComparer<T> comparer, SortOrder order)
        {
            T[] array = Enumerable.ToArray(items);
            int count = array.Count();


            int minIndex;
            T minValue;
            for (int i = 0; i < array.Length - 1; i++)
            {
                minIndex = i;
                minValue = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    //The sort order

                    switch (order)
                    {
                        case SortOrder.Descending:
                        if (comparer.Compare(array[j],minValue)>0)
                        {
                            minIndex = j;
                            minValue = array[j];
                            array[minIndex] = array[i];
                            array[i] = minValue;

                        }
                            break;
                        case SortOrder.Ascending:
                            if (comparer.Compare(array[j], minValue) <= 0)
                            {
                                minIndex = j;
                                minValue = array[j];
                                array[minIndex] = array[i];
                                array[i] = minValue;

                            }
                            break;
                        default:
                            throw new ApplicationException("The sort order exception should be determined");
                    }

                    
                }
            }

            foreach (var item in array)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Sorts the heap.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="order">The order.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        static public IEnumerable<T> SortHeap<T>(this IEnumerable<T> items, IComparer<T> comparer, SortOrder order)
         {
             
            T[] array = Enumerable.ToArray(items);

            int count = array.Length;
            for (int index = count / 2 - 1; index >= 0; index--)
                Utility.Heapify(index, array, count,comparer,order);

            while (count > 1)
            {
                count--;
                Utility.Swap(ref array[0], ref array[count]);
                Utility.Heapify(0, array, count,comparer,order);
            }

            foreach (var item in array)
            {
                yield return item;
            }
         }
         
         
        #endregion

    }
}



