// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ReadOnlyKeyedCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Class ReadOnlyKeyedCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadOnlyKeyedCollection<T>
    {

        /// <summary>
        /// The coll
        /// </summary>
        private KeyedCollection<T> _coll;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyKeyedCollection{T}"/> class.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="array">The array.</param>
        public ReadOnlyKeyedCollection(string[] keys, T[] array)
        {
            _coll = new KeyedCollection<T>(keys, array);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyKeyedCollection{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public ReadOnlyKeyedCollection(ILightCollection<T> collection)
        {
            string[] keys = CreateFreeKeys(collection.Count);
            _coll = new KeyedCollection<T>(keys, collection.GetItems());
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyKeyedCollection{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public ReadOnlyKeyedCollection(IKeyedCollection<T> collection)
        {
            _coll = (KeyedCollection<T>)collection;//new KeyedCollection<T>(collection.Keys, collection.GetItems());
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyKeyedCollection{T}"/> class.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="items">The items.</param>
        public ReadOnlyKeyedCollection(string[] keys, ILightCollection<T> items)
        {
            _coll = new KeyedCollection<T>(keys, items.GetItems());
        }

        /// <summary>
        /// Creates the free keys.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>System.String[].</returns>
        private string[] CreateFreeKeys(int count)
        {
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = _coll.CreateFreeKey();
            }

            return result;
        }

        /// <summary>
        /// Gets the internal collection.
        /// </summary>
        /// <value>The internal collection.</value>
        internal KeyedCollection<T> InternalCollection
        {
            get
            {
                return _coll;
            }
        }

        /// <summary>
        /// Gets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>T.</returns>
        public virtual T this[int index]
        {
            get
            {
                return _coll[index];
            }
        }
        /// <summary>
        /// Gets the <see cref="T"/> with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public virtual T this[string key]
        {
            get
            {
                return _coll[key];
            }
        }
        /// <summary>
        /// Gets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        public virtual int Capacity
        {
            get
            {
                return _coll.Collection.Capacity;
            }
        }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return _coll.Count;
            }
        }
        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public string[] Keys
        {
            get
            {
                return _coll.Keys;
            }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>ReadOnlyKeyedCollection&lt;T&gt;.</returns>
        public virtual ReadOnlyKeyedCollection<T> Clone()
        {
            return new ReadOnlyKeyedCollection<T>(_coll.Keys, _coll.GetItems());
        }
        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public virtual bool Contains(T item)
        {
            return _coll.Contains(item);
        }
        /// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key contains key; otherwise, <c>false</c>.</returns>
        public virtual bool ContainsKey(string key)
        {
            return _coll.ContainsKey(key);
        }
        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public virtual T Find(Predicate<T> match)
        {
            return _coll.Collection.Find(match);
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>KeyedCollection`1.Enumerator.</returns>
        public virtual KeyedCollection<T>.Enumerator GetEnumerator()
        {
            return _coll.GetEnumerator();
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>T[].</returns>
        public virtual T[] GetItems()
        {
            return _coll.GetItems();
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <returns>T[].</returns>
        public virtual T[] GetItems(int startIndex)
        {
            return _coll.GetItems(startIndex);
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="finalIndex">The final index.</param>
        /// <returns>T[].</returns>
        public virtual T[] GetItems(int startIndex, int finalIndex)
        {
            return _coll.GetItems(startIndex,finalIndex);
        }
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public virtual int IndexOf(T item)
        {
            return _coll.IndexOf(item);
        }
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        public virtual int IndexOf(T item, int index)
        {
            return _coll.Collection.IndexOf(item, index);
        }
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        public virtual int IndexOf(T item, int index, int count)
        {
            return _coll.Collection.IndexOf(item, index, count);
        }
        /// <summary>
        /// Indexes the of key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Int32.</returns>
        public virtual int IndexOfKey(string key)
        {
            return _coll.IndexOfKey(key);
        }
        /// <summary>
        /// Reverses this instance.
        /// </summary>
        public virtual void Reverse()
        {
            _coll.Reverse();
        }
        /// <summary>
        /// Reverses the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        public virtual void Reverse(int index, int length)
        {
            _coll.Reverse(index, length);
        }
        /// <summary>
        /// Sorts this instance.
        /// </summary>
        public virtual void Sort()
        {
            _coll.Sort();
        }
        /// <summary>
        /// Swaps the specified item1.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        public virtual void Swap(T item1, T item2)
        {
            _coll.Swap(item1, item2);
        }
        /// <summary>
        /// Swaps the index of the by.
        /// </summary>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        public virtual void SwapByIndex(int index1, int index2)
        {
            _coll.SwapByIndex(index1, index2);
        }
        /// <summary>
        /// Trims to size.
        /// </summary>
        public virtual void TrimToSize()
        {
            _coll.TrimToSize();
        }
        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool TryGetItem(int index, out T item)
        {
            return _coll.TryGetItem(index, out item);
        }
        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool TryGetItem(string key, out T item)
        {
            return _coll.TryGetItem(key, out item);
        }
    }
}
