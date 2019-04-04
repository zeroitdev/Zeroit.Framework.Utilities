// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="IKeyedCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Interface IKeyedCollection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IKeyedCollection<T>
    {
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        void Add(string key, T item);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="items">The items.</param>
        void AddRange(string[] keys, T[] items);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        void AddRange(KeyedCollection<T> items);
        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();
        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>The collection.</value>
        LightCollection<T> Collection { get; }
        /// <summary>
        /// Occurs when [collection changed].
        /// </summary>
        event EventHandler CollectionChanged;
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
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key contains key; otherwise, <c>false</c>.</returns>
        bool ContainsKey(string key);
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        int Count { get; }
        /// <summary>
        /// Creates the free key.
        /// </summary>
        /// <returns>System.String.</returns>
        string CreateFreeKey();
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>KeyedCollection`1.Enumerator.</returns>
        KeyedCollection<T>.Enumerator GetEnumerator();
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
        /// <returns>System.Int32.</returns>
        int IndexOf(T item);
        /// <summary>
        /// Indexes the of key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Int32.</returns>
        int IndexOfKey(string key);
        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        void Insert(int index, string key, T item);
        /// <summary>
        /// Occurs when [item add].
        /// </summary>
        event KeyedCollection<T>.KeyedCollectionAddHandler ItemAdd;
        /// <summary>
        /// Occurs when [item add range].
        /// </summary>
        event KeyedCollection<T>.KeyedCollectionAddRangeHandler ItemAddRange;
        /// <summary>
        /// Occurs when [item move].
        /// </summary>
        event KeyedCollection<T>.KeyedCollectionMoveHandler ItemMove;
        /// <summary>
        /// Occurs when [item remove].
        /// </summary>
        event KeyedCollection<T>.KeyedCollectionRemoveHandler ItemRemove;
        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>The keys.</value>
        string[] Keys { get; }
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
        ReadOnlyKeyedCollection<T> ReadOnlyCollection { get; }
        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Remove(T item);
        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">The index.</param>
        void RemoveAt(int index);
        /// <summary>
        /// Removes the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        void RemoveByKey(string key);
        /// <summary>
        /// Reverses this instance.
        /// </summary>
        void Reverse();
        /// <summary>
        /// Reverses the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        void Reverse(int index, int length);
        /// <summary>
        /// Sorts this instance.
        /// </summary>
        void Sort();
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
        /// Gets or sets the <see cref="T"/> with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        T this[string key] { get; set; }
        /// <summary>
        /// Trims to size.
        /// </summary>
        void TrimToSize();
        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TryGetItem(string key, out T item);
        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TryGetItem(int index, out T item);
    }
}
