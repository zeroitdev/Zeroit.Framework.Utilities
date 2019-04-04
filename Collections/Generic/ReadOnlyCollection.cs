// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ReadOnlyCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Class ReadOnlyCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadOnlyCollection<T>
    {
        /// <summary>
        /// The coll
        /// </summary>
        private LightCollection<T> _coll;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyCollection{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        public ReadOnlyCollection(T[] array)
        {
            _coll = new LightCollection<T>(array);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyCollection{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public ReadOnlyCollection(ILightCollection<T> collection)
        {
            _coll = (LightCollection<T>)collection; // new LightCollection<T>(collection);
        }

        /// <summary>
        /// Gets the internal collection.
        /// </summary>
        /// <value>The internal collection.</value>
        internal LightCollection<T> InternalCollection
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
        /// Gets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        public virtual int Capacity
        {
            get
            {
                return _coll.Capacity;
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
        /// Clones this instance.
        /// </summary>
        /// <returns>ReadOnlyCollection&lt;T&gt;.</returns>
        public virtual ReadOnlyCollection<T> Clone()
        {
            return new ReadOnlyCollection<T>(_coll.GetItems());
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
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        public virtual void CopyTo(Array array, int index)
        {
            _coll.CopyTo(array, index);
        }
        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public virtual T Find(Predicate<T> match)
        {
            return _coll.Find(match);
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>LightCollection`1.Enumerator.</returns>
        public virtual LightCollection<T>.Enumerator GetEnumerator()
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
            return _coll.IndexOf(item, index);
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
            return _coll.IndexOf(item, index, count);
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
        /// Sorts the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        public virtual void Sort(Array keys)
        {
            _coll.Sort(keys);
        }
        /// <summary>
        /// Sorts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        public virtual void Sort(int index, int length)
        {
            _coll.Sort(index, length);
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
    }
}
