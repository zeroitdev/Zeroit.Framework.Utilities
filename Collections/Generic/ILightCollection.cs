// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ILightCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Interface ILightCollection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILightCollection<T>
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="sort">if set to <c>true</c> [sort].</param>
        /// <returns>System.Int32.</returns>
        int Add(T item, bool sort);
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        int Add(T item);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        void AddRange(ILightCollection<T> items);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        void AddRange(T[] items);
        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        int Capacity { get; set; }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();
        //LightCollection<T> Clone();
        /// <summary>
        /// Occurs when [collection clear].
        /// </summary>
        event EventHandler CollectionClear;
        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        bool Contains(T item);
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        void CopyTo(Array array, int index);
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        int Count { get; }
        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        T Find(Predicate<T> match);
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>LightCollection`1.Enumerator.</returns>
        LightCollection<T>.Enumerator GetEnumerator();
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="finalIndex">The final index.</param>
        /// <returns>T[].</returns>
        T[] GetItems(int startIndex, int finalIndex);
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <returns>T[].</returns>
        T[] GetItems(int startIndex);
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>T[].</returns>
        T[] GetItems();
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        int IndexOf(T item, int index, int count);
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        int IndexOf(T item, int index);
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        int IndexOf(T item);
        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        void Insert(int index, T item);
        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        void InsertRange(int index, ILightCollection<T> items);
        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        void InsertRange(int index, T[] items);
        /// <summary>
        /// Occurs when [item add].
        /// </summary>
        event LightCollection<T>.LightCollectionAddHandler ItemAdd;
        /// <summary>
        /// Occurs when [item add range].
        /// </summary>
        event LightCollection<T>.LightCollectionAddRangeHandler ItemAddRange;
        /// <summary>
        /// Occurs when [item move].
        /// </summary>
        event LightCollection<T>.LightCollectionMoveHandler ItemMove;
        /// <summary>
        /// Occurs when [item remove].
        /// </summary>
        event LightCollection<T>.LightCollectionRemoveHandler ItemRemove;
        /// <summary>
        /// Moves the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="newIndex">The new index.</param>
        void Move(T item, int newIndex);
        /// <summary>
        /// Moves the index of the by.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="newIndex">The new index.</param>
        void MoveByIndex(int index, int newIndex);
        /// <summary>
        /// Gets the read only collection.
        /// </summary>
        /// <value>The read only collection.</value>
        ReadOnlyCollection<T> ReadOnlyCollection { get; }
        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Remove(T item);
        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">The index.</param>
        void RemoveAt(int index);
        /// <summary>
        /// Reverses the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        void Reverse(int index, int length);
        /// <summary>
        /// Reverses this instance.
        /// </summary>
        void Reverse();
        /// <summary>
        /// Sorts this instance.
        /// </summary>
        void Sort();
        //void Sort(int index, int length);
        //void Sort(Array keys);
        /// <summary>
        /// Swaps the specified item1.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        void Swap(T item1, T item2);
        /// <summary>
        /// Swaps the index of the by.
        /// </summary>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        void SwapByIndex(int index1, int index2);
        /// <summary>
        /// Gets or sets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>T.</returns>
        T this[int index] { get; set; }
        /// <summary>
        /// Trims to size.
        /// </summary>
        void TrimToSize();
        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TryGetItem(int index, out T item);
    }
}
