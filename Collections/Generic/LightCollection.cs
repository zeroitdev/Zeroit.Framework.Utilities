// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LightCollection.cs" company="Zeroit Dev Technologies">
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

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Zeroit.Framework.Utilities.Collections.Generic
{

    /// <summary>
    /// Class LightCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Zeroit.Framework.Utilities.Collections.Generic.ILightCollection{T}" />
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Collections.IList" />
    public class LightCollection<T> : ILightCollection<T>, ICloneable, IList
    {
        #region Static Members

        /// <summary>
        /// Internals the get resource error.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        internal static string InternalGetResourceError(string key)
        {
            return string.Empty;
        }

        #endregion

        #region Nested Types

        /// <summary>
        /// Struct Enumerator
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEnumerator{T}" />
        /// <seealso cref="System.Collections.IEnumerator" />
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            /// <summary>
            /// The list
            /// </summary>
            private LightCollection<T> _list;
            /// <summary>
            /// The index
            /// </summary>
            private int _index;
            //private int _version;
            /// <summary>
            /// The current
            /// </summary>
            private T _current;

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> struct.
            /// </summary>
            /// <param name="list">The list.</param>
            internal Enumerator(LightCollection<T> list)
            {
                _list = list;
                _index = 0;
                _current = default(T);
            }

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>The current.</value>
            public T Current
            {
                get { return _current; }
            }
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
            }
            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>The current.</value>
            /// <exception cref="System.InvalidOperationException"></exception>
            object IEnumerator.Current
            {
                get
                {
                    if ((_index == 0) || (_index == (_list.Count + 1)))
                    {
                        throw new InvalidOperationException();
                    }
                    return this.Current;
                }
            }
            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list[_index];
                    _index++;
                    return true;
                }
                _index = _list.Count + 1;
                _current = default(T);
                return false;
            }
            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                _index = 0;
                _current = default(T);
            }
        }

        /// <summary>
        /// Class LightCollectionAddEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class LightCollectionAddEventArgs : EventArgs
        {
            /// <summary>
            /// The item
            /// </summary>
            private T _Item;
            /// <summary>
            /// The index
            /// </summary>
            private int _Index;

            /// <summary>
            /// Gets the item.
            /// </summary>
            /// <value>The item.</value>
            public T Item
            {
                get
                {
                    return _Item;
                }
            }

            /// <summary>
            /// Gets the index.
            /// </summary>
            /// <value>The index.</value>
            public int Index
            {
                get
                {
                    return _Index;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="LightCollectionAddEventArgs"/> class.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="index">The index.</param>
            public LightCollectionAddEventArgs(T item, int index)
            {
                _Item = item;
                _Index = index;
            }
        }
        /// <summary>
        /// Class LightCollectionRemoveEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class LightCollectionRemoveEventArgs : EventArgs
        {
            /// <summary>
            /// The removed item
            /// </summary>
            private T _RemovedItem;
            /// <summary>
            /// The index
            /// </summary>
            private int _Index;

            /// <summary>
            /// Gets the removed item.
            /// </summary>
            /// <value>The removed item.</value>
            public T RemovedItem
            {
                get
                {
                    return _RemovedItem;
                }
            }

            /// <summary>
            /// Gets the index.
            /// </summary>
            /// <value>The index.</value>
            public int Index
            {
                get
                {
                    return _Index;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="LightCollectionRemoveEventArgs"/> class.
            /// </summary>
            /// <param name="removedItem">The removed item.</param>
            /// <param name="index">The index.</param>
            public LightCollectionRemoveEventArgs(T removedItem, int index)
            {
                _RemovedItem = removedItem;
                _Index = index;
            }
        }
        /// <summary>
        /// Class LightCollectionMoveEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class LightCollectionMoveEventArgs : EventArgs
        {
            /// <summary>
            /// The item
            /// </summary>
            private T _Item;
            /// <summary>
            /// The new index
            /// </summary>
            private int _NewIndex;
            /// <summary>
            /// The old index
            /// </summary>
            private int _OldIndex;

            /// <summary>
            /// Gets the item.
            /// </summary>
            /// <value>The item.</value>
            public T Item
            {
                get
                {
                    return _Item;
                }
            }

            /// <summary>
            /// Gets the new index.
            /// </summary>
            /// <value>The new index.</value>
            public int NewIndex
            {
                get
                {
                    return _NewIndex;
                }
            }

            /// <summary>
            /// Gets the old index.
            /// </summary>
            /// <value>The old index.</value>
            public int OldIndex
            {
                get
                {
                    return _OldIndex;
                }
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="LightCollectionMoveEventArgs"/> class.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="newIndex">The new index.</param>
            /// <param name="oldIndex">The old index.</param>
            public LightCollectionMoveEventArgs(T item, int newIndex, int oldIndex)
            {
                _Item = item;
                _NewIndex = newIndex;
                _OldIndex = oldIndex;
            }
        }
        /// <summary>
        /// Class LightCollectionAddRangeEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class LightCollectionAddRangeEventArgs : EventArgs
        {
            /// <summary>
            /// The items
            /// </summary>
            private T[] _Items;
            /// <summary>
            /// The start index
            /// </summary>
            private int _StartIndex;

            /// <summary>
            /// Gets the items.
            /// </summary>
            /// <value>The items.</value>
            public T[] Items
            {
                get
                {
                    return _Items;
                }
            }

            /// <summary>
            /// Gets the start index.
            /// </summary>
            /// <value>The start index.</value>
            public int StartIndex
            {
                get
                {
                    return _StartIndex;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="LightCollectionAddRangeEventArgs"/> class.
            /// </summary>
            /// <param name="items">The items.</param>
            /// <param name="startIndex">The start index.</param>
            public LightCollectionAddRangeEventArgs(T[] items, int startIndex)
            {
                _Items = items;
                _StartIndex = startIndex;
            }
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate LightCollectionAddHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LightCollectionAddEventArgs"/> instance containing the event data.</param>
        public delegate void LightCollectionAddHandler(object sender, LightCollectionAddEventArgs e);
        /// <summary>
        /// Delegate LightCollectionRemoveHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LightCollectionRemoveEventArgs"/> instance containing the event data.</param>
        public delegate void LightCollectionRemoveHandler(object sender, LightCollectionRemoveEventArgs e);
        /// <summary>
        /// Delegate LightCollectionMoveHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LightCollectionMoveEventArgs"/> instance containing the event data.</param>
        public delegate void LightCollectionMoveHandler(object sender, LightCollectionMoveEventArgs e);
        /// <summary>
        /// Delegate LightCollectionAddRangeHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LightCollectionAddRangeEventArgs"/> instance containing the event data.</param>
        public delegate void LightCollectionAddRangeHandler(object sender, LightCollectionAddRangeEventArgs e);

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [item add].
        /// </summary>
        public event LightCollectionAddHandler ItemAdd;
        /// <summary>
        /// Occurs when [item remove].
        /// </summary>
        public event LightCollectionRemoveHandler ItemRemove;
        /// <summary>
        /// Occurs when [item move].
        /// </summary>
        public event LightCollectionMoveHandler ItemMove;
        /// <summary>
        /// Occurs when [item add range].
        /// </summary>
        public event LightCollectionAddRangeHandler ItemAddRange;
        /// <summary>
        /// Occurs when [collection clear].
        /// </summary>
        public event EventHandler CollectionClear;

        #endregion

        #region Fields

        /// <summary>
        /// The items
        /// </summary>
        protected T[] _items;
        /// <summary>
        /// The count
        /// </summary>
        private int _count;
        /// <summary>
        /// The readonly coll
        /// </summary>
        private ReadOnlyCollection<T> _readonlyColl;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of LightCollection
        /// </summary>
        public LightCollection()
        {
            Init(4);
        }
        /// <summary>
        /// Constructor of LightCollection with the initial capacity specified of the collection
        /// </summary>
        /// <param name="StartCapacity">The initial capacity of the collection</param>
        public LightCollection(int StartCapacity)
        {
            Init(StartCapacity);
        }
        /// <summary>
        /// Constructor of LightCollection
        /// </summary>
        /// <param name="coll">The collection from where copy items</param>
        public LightCollection(ILightCollection<T> coll)
        {
            Init(coll.Count);

            this.AddRange(coll.GetItems());
        }
        /// <summary>
        /// Constructor of LightCollection with array of T[] as argument
        /// </summary>
        /// <param name="array">Array of T[] as initial values</param>
        /// <exception cref="System.ArgumentNullException">array</exception>
        public LightCollection(T[] array)
        {

            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            _items = array;
            _count = array.Length;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Initializes the specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        private void Init(int capacity)
        {
            _items = new T[capacity];
            _count = 0;
            _readonlyColl = null;
        }
        /// <summary>
        /// Ensures the capacity.
        /// </summary>
        /// <param name="min">The minimum.</param>
        private void EnsureCapacity(int min)
        {
            if (this._items.Length < min)
            {
                int newCapacity = (this._items.Length == 0) ? 4 : (this._items.Length * 2);

                if (newCapacity < min)
                {
                    newCapacity = min;
                }
                this.SetCollCapacity(newCapacity);
            }
        }
        /// <summary>
        /// Sets the coll capacity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">value - ArgumentOutOfRange SmallCapacity</exception>
        private void SetCollCapacity(int value)
        {
            if (value != this._items.Length)
            {
                if (value < this._count)
                {
                    throw new ArgumentOutOfRangeException("value", "ArgumentOutOfRange SmallCapacity");
                }
                if (value > 0)
                {
                    T[] newArray = new T[value];

                    if (this._count > 0)
                    {
                        Array.Copy(this._items, 0, newArray, 0, this._count);
                    }

                    this._items = newArray;
                }
                else
                {
                    this._items = new T[4];
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Return a T element from the specified index
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Here is no item at index(" + index.ToString() + ")
        /// or
        /// Here is no item at index(" + index.ToString() + ")
        /// </exception>
        public virtual T this[int index]
        {
            get
            {
                try
                {
                    return _items[index];
                }
                catch
                {
                    throw new IndexOutOfRangeException("Here is no item at index(" + index.ToString() + ")");
                }
            }
            set
            {
                try
                {
                    _items[index] = value;
                }
                catch
                {
                    throw new IndexOutOfRangeException("Here is no item at index(" + index.ToString() + ")");
                }
            }
        }
        /// <summary>
        /// Return the Count  of this collection
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return _count;
            }
        }
        /// <summary>
        /// Return a read-only collection
        /// </summary>
        /// <value>The read only collection.</value>
        public virtual ReadOnlyCollection<T> ReadOnlyCollection
        {
            get
            {
                if (_readonlyColl == null) _readonlyColl = new ReadOnlyCollection<T>(this);
                return _readonlyColl;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a T item to this collection
        /// </summary>
        /// <param name="item">Item to add to this collection</param>
        /// <returns>Return the Item index on this collection</returns>
        public virtual int Add(T item)
        {
            if (this._count == this._items.Length)
            {
                this.EnsureCapacity(this._count + 1);
            }

            this._items[this._count] = item;

            _count++; // non spostare

            if (ItemAdd != null) ItemAdd(this, new LightCollectionAddEventArgs(item, this._count));

            return _count-1;
        }
        /// <summary>
        /// Add a T item to this collection
        /// </summary>
        /// <param name="item">Item to add to this collection</param>
        /// <param name="sort">set to true for sort now the collection</param>
        /// <returns>Return the Item index on this collection</returns>
        public virtual int Add(T item, bool sort)
        {
            int i = Add(item);

            if (sort)
                this.Sort();

            return i;
        }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public virtual void AddRange(ILightCollection<T> items)
        {
            InsertRange(this._count, items.GetItems());
        }
        /// <summary>
        /// Add a range of Items to this collection
        /// </summary>
        /// <param name="items">Array of T[] Items to add to this collection</param>
        public virtual void AddRange(T[] items)
        {
            InsertRange(this._count, items);
        }
        /// <summary>
        /// Get and Set the Collection Capacity
        /// </summary>
        /// <value>The capacity.</value>
        public virtual int Capacity
        {
            get
            {
                return this._items.Length;
            }
            set
            {
                this.SetCollCapacity(value);
            }
        }
        /// <summary>
        /// Empty the collection
        /// </summary>
        public virtual void Clear()
        {
            _items = new T[] { };
            _count = 0;
            if (CollectionClear != null) CollectionClear(this, new EventArgs());
        }
        /// <summary>
        /// Create a cloned colletrion
        /// </summary>
        /// <returns>A copy of collection</returns>
        public LightCollection<T> Clone()
        {
            return new LightCollection<T>(this);
        }
        /// <summary>
        /// Check if a T item is contained on this collection
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns>True if is contained otherwise False</returns>
        public virtual bool Contains(T item)
        {
            return (IndexOf(item, 0, _count) >= 0);
        }
        /// <summary>
        /// Copy collection to an array of T elements types
        /// </summary>
        /// <param name="array">An array of T elements types</param>
        /// <param name="index">Start copy index</param>
        public virtual void CopyTo(Array array, int index)
        {
            Array.Copy(_items, index, array, 0, _count);
        }
        /// <summary>
        /// Find an item of the collection using a predicate
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Boolean Result</returns>
        /// <exception cref="System.ArgumentNullException">match</exception>
        public virtual T Find(Predicate<T> match)
        {

            if (match == null)
            {
                throw new ArgumentNullException("match");
            }
            for (int i = 0; i < _count; i++)
            {
                if (match(_items[i]))
                {
                    return _items[i];
                }
            }
            T type;
            type = default(T);
            return type;
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>LightCollection`1.Enumerator.</returns>
        public virtual LightCollection<T>.Enumerator GetEnumerator()
        {
            return new LightCollection<T>.Enumerator(this);
        }
        /// <summary>
        /// Get a copy of all collection items
        /// </summary>
        /// <returns>Array of T[]</returns>
        public virtual T[] GetItems()
        {
            if (_count <= 0) return new T[0];
            return GetItems(0, _count - 1);
        }
        /// <summary>
        /// Get a copy of all collection items
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <returns>Array of T[]</returns>
        public virtual T[] GetItems(int startIndex)
        {
            if (_count <= 0) return new T[0];
            return GetItems(startIndex, _count - 1);
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="finalIndex">The final index.</param>
        /// <returns>T[].</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// finalIndex - finalIndex was out of range. Must be non-negative and less than the size of the collection.
        /// or
        /// startIndex - startIndex was out of range. Must be non-negative and less than the size of the collection.
        /// or
        /// finalIndex - finalIndex was out of range. Must be minor of the Count
        /// </exception>
        public virtual T[] GetItems(int startIndex, int finalIndex)
        {
            if (_count <= 0) return new T[0];
            if (finalIndex < startIndex)
            {
                throw new ArgumentOutOfRangeException("finalIndex", finalIndex, "finalIndex was out of range. Must be non-negative and less than the size of the collection.");
            }
            if ((startIndex < 0) || (startIndex > _count))
            {
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "startIndex was out of range. Must be non-negative and less than the size of the collection.");
            }
            if (finalIndex > _count - 1)
            {
                throw new ArgumentOutOfRangeException("finalIndex", finalIndex, "finalIndex was out of range. Must be minor of the Count");
            }
            T[] newItems = new T[finalIndex - startIndex + 1];

            Array.Copy(_items, startIndex, newItems, 0, finalIndex + 1);

            return newItems;
        }
        /// <summary>
        /// Get The Index of a item on the collection
        /// </summary>
        /// <param name="item">The item to search</param>
        /// <returns>Index of T</returns>
        public virtual int IndexOf(T item)
        {
            return IndexOf(item, 0, _count);
        }
        /// <summary>
        /// Get The Index of a item on the collection
        /// </summary>
        /// <param name="item">The item to search</param>
        /// <param name="index">The index where start search</param>
        /// <returns>Index of T</returns>
        public virtual int IndexOf(T item, int index)
        {
            return IndexOf(item, index, _count - index);
        }
        /// <summary>
        /// Get The Index of a item on the collection
        /// </summary>
        /// <param name="item">The item to search</param>
        /// <param name="index">The index where start search</param>
        /// <param name="count">Number of max search to try</param>
        /// <returns>Index of T</returns>
        public virtual int IndexOf(T item, int index, int count)
        {
            return Array.IndexOf<T>(this._items, item, index, count);
        }
        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        public virtual void InsertRange(int index, ILightCollection<T> items)
        {
            InsertRange(index, items.GetItems());
        }
        /// <summary>
        /// Insert a range of T[] elements to this collection starting from index
        /// </summary>
        /// <param name="index">The from where starting insert</param>
        /// <param name="items">T[] array of elements</param>
        /// <exception cref="System.ArgumentNullException">items - Null Array</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">index - Index out of Range</exception>
        public virtual void InsertRange(int index, T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items", "Null Array");
            }
            if ((index < 0) || (index > this._count))
            {
                throw new ArgumentOutOfRangeException("index", "Index out of Range");
            }
            int num1 = items.Length;
            if (num1 > 0)
            {
                this.EnsureCapacity(this._count + num1);

                if (index < this._count)
                {
                    Array.Copy(this._items, index, this._items, (int)(index + num1), (int)(this._count - index));
                }
                items.CopyTo(this._items, index);
                this._count += num1;
            }

            if (ItemAddRange != null) ItemAddRange(this, new LightCollectionAddRangeEventArgs(items, index));
        }
        /// <summary>
        /// Insert a T Item at index
        /// </summary>
        /// <param name="index">The index where insert the Item</param>
        /// <param name="item">The item to insert</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index - Index must be within the bounds of the List.</exception>
        public virtual void Insert(int index, T item)
        {
            if ((index < 0) || (index > this._count))
            {
                throw new ArgumentOutOfRangeException("index", "Index must be within the bounds of the List.");
            }
            if (this._count == this._items.Length)
            {
                this.EnsureCapacity(this._count + 1);
            }
            if (index < this._count)
            {
                Array.Copy(this._items, index, this._items, (int)(index + 1), (int)(this._count - index));
            }
            this._items[index] = item;
            this._count++;

            if (ItemAdd != null) ItemAdd(this, new LightCollectionAddEventArgs(item, index));
        }
        /// <summary>
        /// Move an element from an index to another
        /// </summary>
        /// <param name="index">Source index</param>
        /// <param name="newIndex">Destination index</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// index
        /// or
        /// newIndex
        /// </exception>
        public virtual void MoveByIndex(int index, int newIndex)
        {
            if (index == newIndex) return;
            if (index < 0 || index >= _items.Length) throw new ArgumentOutOfRangeException("index");
            if (newIndex < 0 || newIndex >= _items.Length) throw new ArgumentOutOfRangeException("newIndex");

            int min = Math.Min(index, newIndex);
            T[] newArray = new T[_items.Length - min];

            int cp_index = index - min;
            int cp_newIndex = newIndex - min;

            Array.Copy(_items, min, newArray, 0, newArray.Length);

            if (index > newIndex)
            {
                int pos = newIndex + 1;

                _items[newIndex] = newArray[cp_index];

                for (int i = 0; i < newArray.Length; i++)
                {
                    if (i != (cp_index))
                    {
                        _items[pos] = newArray[cp_newIndex + i];
                        pos++;
                    }
                }
            }
            else // index < newIndex
            {
                int pos = index;

                _items[newIndex] = newArray[cp_index];

                for (int i = cp_index + 1; i < newArray.Length; i++)
                {
                    if (pos == (newIndex)) pos++;

                    _items[pos] = newArray[i];
                    pos++;
                }
            }

            if(ItemMove!=null) ItemMove(this, new LightCollectionMoveEventArgs(_items[newIndex], newIndex, index));

        }
        /// <summary>
        /// Move an element to a new index position
        /// </summary>
        /// <param name="item">Element to move</param>
        /// <param name="newIndex">Destination index</param>
        public virtual void Move(T item, int newIndex)
        {
            int index = this.IndexOf(item);
            if (index < 0) return;
            if(newIndex<0 || newIndex >= _count) return;
            if (index == newIndex) return;

            MoveByIndex(index, newIndex);
        }
        /// <summary>
        /// Remove a T item
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Remove(T item)
        {
            int i = this.IndexOf(item);
            if (i >= 0)
            {
                this.RemoveAt(i);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Remove a T item at index
        /// </summary>
        /// <param name="index">The index.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index - Index was out of range. Must be non-negative and less than the size of the collection.</exception>
        public virtual void RemoveAt(int index)
        {
            if ((index < 0) || (index >= _count))
            {
                throw new ArgumentOutOfRangeException("index", index, "Index was out of range. Must be non-negative and less than the size of the collection."); // InternalGetResourceFromDefault("ArgumentOutOfRange_Index"));
            }

            T removedItem = _items[index];

            Array.Copy(_items, index + 1, _items, index, _items.Length - index - 1);


            Array.Resize<T>(ref _items, _count - 1);

            _count--;

            if (ItemRemove != null) ItemRemove(this, new LightCollectionRemoveEventArgs(removedItem, index));
        }
        /// <summary>
        /// Reverse the order of the collection content
        /// </summary>
        public virtual void Reverse()
        {
            Array.Reverse(_items, 0, _count);
        }
        /// <summary>
        /// Reverse the order of the collection content
        /// </summary>
        /// <param name="index">Start index</param>
        /// <param name="length">Number of elements</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public virtual void Reverse(int index, int length)
        {
            if ((index + length) >= _count) throw new ArgumentOutOfRangeException((index >= _count) ? "index" : "length");
            if (length <= 1) return;
            Array.Reverse(_items, index, length);
        }
        /// <summary>
        /// Sorts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        public virtual void Sort(int index, int length)
        {
            Array.Sort<T>(_items, index, length);
        }
        /// <summary>
        /// Sorts this instance.
        /// </summary>
        public virtual void Sort()
        {
            Sort(0, _count);
        }
        /// <summary>
        /// Sorts the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <exception cref="System.Exception">The Length of \"keys\" does not match with \"items\" lenght</exception>
        public virtual void Sort(Array keys)
        {
            if (keys.Length != this.Count  /*_items.Length*/)
            {
                throw new Exception("The Length of \"keys\" does not match with \"items\" lenght");
            }
            Array.Sort(keys, _items);
        }
        /// <summary>
        /// Swap two elements
        /// </summary>
        /// <param name="index1">First element index</param>
        /// <param name="index2">Second element index</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// index1
        /// or
        /// index2
        /// </exception>
        public virtual void SwapByIndex(int index1, int index2)
        {
            if (index1 == index2) return;
            if (index1 < 0 || index1 >= _items.Length) throw new ArgumentOutOfRangeException("index1");
            if (index2 < 0 || index2 >= _items.Length) throw new ArgumentOutOfRangeException("index2");


            T temp = _items[index2];
            _items[index2] = _items[index1];
            _items[index1] = temp;
        }
        /// <summary>
        /// Swap two elements
        /// </summary>
        /// <param name="item1">First element</param>
        /// <param name="item2">First element</param>
        public virtual void Swap(T item1, T item2)
        {
            if (item1.Equals(item2)) return;

            int index1 = this.IndexOf(item1);
            int index2 = this.IndexOf(item2);

            SwapByIndex(index1, index2);
        }
        /// <summary>
        /// Reduce the collection buffer to real count size
        /// </summary>
        public virtual void TrimToSize()
        {
            this.Capacity = this._count;
        }
        /// <summary>
        /// Try to get an item if exist
        /// </summary>
        /// <param name="index">Index of the item</param>
        /// <param name="item">Return the item if exist, otherwise null</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool TryGetItem(int index, out T item)
        {
            item = default(T);
            if (index < 0 || index >= _items.Length) return false;
            item = _items[index];
            return true;
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion

        #region IList Members

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.IList" />.
        /// </summary>
        /// <param name="value">The object to add to the <see cref="T:System.Collections.IList" />.</param>
        /// <returns>The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection.</returns>
        /// <exception cref="System.ArgumentException">Invalid type " + value.GetType().ToString()</exception>
        int IList.Add(object value)
        {
            if (!value.GetType().Equals(typeof(T))) throw new ArgumentException("Invalid type " + value.GetType().ToString());
            return this.Add((T)value);
        }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        void IList.Clear()
        {
            this.Clear();
        }
        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:System.Collections.IList" />.</param>
        /// <returns>true if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, false.</returns>
        /// <exception cref="System.ArgumentException">Invalid type " + value.GetType().ToString()</exception>
        bool IList.Contains(object value)
        {
            if (!value.GetType().Equals(typeof(T))) throw new ArgumentException("Invalid type " + value.GetType().ToString());
            return this.Contains((T)value);
        }
        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:System.Collections.IList" />.</param>
        /// <returns>The index of <paramref name="value" /> if found in the list; otherwise, -1.</returns>
        /// <exception cref="System.ArgumentException">Invalid type " + value.GetType().ToString()</exception>
        int IList.IndexOf(object value)
        {
            if (!value.GetType().Equals(typeof(T))) throw new ArgumentException("Invalid type " + value.GetType().ToString());
            return this.IndexOf((T)value);
        }
        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.IList" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value" /> should be inserted.</param>
        /// <param name="value">The object to insert into the <see cref="T:System.Collections.IList" />.</param>
        /// <exception cref="System.ArgumentException">Invalid type " + value.GetType().ToString()</exception>
        void IList.Insert(int index, object value)
        {
            if (!value.GetType().Equals(typeof(T))) throw new ArgumentException("Invalid type " + value.GetType().ToString());
            this.Insert(index, (T)value);
        }
        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
        /// </summary>
        /// <value><c>true</c> if this instance is fixed size; otherwise, <c>false</c>.</value>
        bool IList.IsFixedSize
        {
            get { return false; }
        }
        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        bool IList.IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.
        /// </summary>
        /// <param name="value">The object to remove from the <see cref="T:System.Collections.IList" />.</param>
        /// <exception cref="System.ArgumentException">Invalid type " + value.GetType().ToString()</exception>
        void IList.Remove(object value)
        {
            if (!value.GetType().Equals(typeof(T))) throw new ArgumentException("Invalid type " + value.GetType().ToString());
            this.Remove((T)value);
        }
        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">The index.</param>
        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }
        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.ArgumentException">Invalid type " + value.GetType().ToString()</exception>
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (!value.GetType().Equals(typeof(T))) throw new ArgumentException("Invalid type " + value.GetType().ToString());
                this[index] = (T)value;
            }
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        void ICollection.CopyTo(Array array, int index)
        {
            this.CopyTo(array, index);
        }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        int ICollection.Count
        {
            get
            {
                return this.Count;
            }
        }
        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
        /// </summary>
        /// <value><c>true</c> if this instance is synchronized; otherwise, <c>false</c>.</value>
        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
        /// </summary>
        /// <value>The synchronize root.</value>
        object ICollection.SyncRoot
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }
}
