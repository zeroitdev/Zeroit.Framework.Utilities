// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="KeyedCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


#region Using directives

using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;

#endregion

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Class KeyedCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Zeroit.Framework.Utilities.Collections.Generic.IKeyedCollection{T}" />
    /// <seealso cref="System.Collections.IEnumerable" />
    public class KeyedCollection<T> : IKeyedCollection<T>, IEnumerable
    {
        #region Nested Types

        /// <summary>
        /// Struct Enumerator
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEnumerator{T}" />
        /// <seealso cref="System.IDisposable" />
        /// <seealso cref="System.Collections.IEnumerator" />
        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            /// <summary>
            /// The m keyed coll
            /// </summary>
            private KeyedCollection<T> m_KeyedColl;
            /// <summary>
            /// The m index
            /// </summary>
            private int m_Index;
            /// <summary>
            /// The m current
            /// </summary>
            private T m_Current;

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> struct.
            /// </summary>
            /// <param name="coll">The coll.</param>
            public Enumerator(KeyedCollection<T> coll)
            {
                this.m_KeyedColl = coll;
                this.m_Index = 0;
                m_Current = default(T);
            }

            #region IEnumerator<T> Members

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>The current.</value>
            public T Current
            {
                get { return m_Current; }
            }

            #endregion

            #region IDisposable Members

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {

            }

            #endregion

            #region IEnumerator Members

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>The current.</value>
            object System.Collections.IEnumerator.Current
            {
                get { return m_Current; }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                if (this.m_Index < this.m_KeyedColl.Count)
                {
                    this.m_Current = this.m_KeyedColl._items[this.m_Index];
                    this.m_Index++;
                    return true;
                }

                this.m_Index = this.m_KeyedColl.Count + 1;
                this.m_Current = default(T);
                return false;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                this.m_Index = 0;
                this.m_Current = default(T);
            }

            #endregion
        }

        /// <summary>
        /// Class KeyedCollectionAddEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class KeyedCollectionAddEventArgs : EventArgs
        {
            /// <summary>
            /// The m item
            /// </summary>
            private T m_Item;
            /// <summary>
            /// The m index
            /// </summary>
            private int m_Index;
            /// <summary>
            /// The m key
            /// </summary>
            private string m_Key;

            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>The item.</value>
            public T Item
            {
                get { return m_Item; }
                set { m_Item = value; }
            }

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            /// <value>The index.</value>
            public int Index
            {
                get { return m_Index; }
                set { m_Index = value; }
            }

            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            public string Key
            {
                get { return m_Key; }
                set { m_Key = value; }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="KeyedCollectionAddEventArgs"/> class.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="index">The index.</param>
            /// <param name="key">The key.</param>
            public KeyedCollectionAddEventArgs(T item, int index, string key)
            {
                m_Item = item;
                m_Index = index;
                m_Key = key;
            }


        }
        /// <summary>
        /// Class KeyedCollectionRemoveEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class KeyedCollectionRemoveEventArgs : EventArgs
        {
            /// <summary>
            /// The m item
            /// </summary>
            private T m_Item;

            /// <summary>
            /// The m key
            /// </summary>
            private string m_Key;

            /// <summary>
            /// The m index
            /// </summary>
            private int m_Index;

            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            public string Key
            {
                get { return m_Key; }
                set { m_Key = value; }
            }

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            /// <value>The index.</value>
            public int Index
            {
                get { return m_Index; }
                set { m_Index = value; }
            }

            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>The item.</value>
            public T Item
            {
                get { return m_Item; }
                set { m_Item = value; }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="KeyedCollectionRemoveEventArgs"/> class.
            /// </summary>
            /// <param name="removedItem">The removed item.</param>
            /// <param name="key">The key.</param>
            /// <param name="index">The index.</param>
            public KeyedCollectionRemoveEventArgs(T removedItem, string key, int index)
            {
                m_Item = removedItem;
                m_Key = key;
                m_Index = index;
            }
        }
        /// <summary>
        /// Class KeyedCollectionMoveEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class KeyedCollectionMoveEventArgs : EventArgs
        {
            /// <summary>
            /// The m item
            /// </summary>
            private T m_Item;
            /// <summary>
            /// The m new index
            /// </summary>
            private int m_NewIndex;
            /// <summary>
            /// The m old index
            /// </summary>
            private int m_OldIndex;
            /// <summary>
            /// The m key
            /// </summary>
            private string m_Key;

            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            public string Key
            {
                get { return m_Key; }
                set { m_Key = value; }
            }

            /// <summary>
            /// Gets or sets the old index.
            /// </summary>
            /// <value>The old index.</value>
            public int OldIndex
            {
                get { return m_OldIndex; }
                set { m_OldIndex = value; }
            }

            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>The item.</value>
            public T Item
            {
                get { return m_Item; }
                set { m_Item = value; }
            }

            /// <summary>
            /// Gets or sets the new index.
            /// </summary>
            /// <value>The new index.</value>
            public int NewIndex
            {
                get { return m_NewIndex; }
                set { m_NewIndex = value; }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="KeyedCollectionMoveEventArgs"/> class.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="newIndex">The new index.</param>
            /// <param name="oldIndex">The old index.</param>
            /// <param name="key">The key.</param>
            public KeyedCollectionMoveEventArgs(T item, int newIndex, int oldIndex, string key)
            {
                m_Item = item;
                m_NewIndex = newIndex;
                m_OldIndex = oldIndex;
                m_Key = key;
            }
        }
        /// <summary>
        /// Class KeyedCollectionAddRangeEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class KeyedCollectionAddRangeEventArgs : EventArgs
        {
            /// <summary>
            /// The m items
            /// </summary>
            private T[] m_Items;
            /// <summary>
            /// The m keys
            /// </summary>
            private string[] m_Keys;
            /// <summary>
            /// The m start index
            /// </summary>
            private int m_StartIndex;

            /// <summary>
            /// Gets or sets the start index.
            /// </summary>
            /// <value>The start index.</value>
            public int StartIndex
            {
                get { return m_StartIndex; }
                set { m_StartIndex = value; }
            }

            /// <summary>
            /// Gets or sets the keys.
            /// </summary>
            /// <value>The keys.</value>
            public string[] Keys
            {
                get { return m_Keys; }
                set { m_Keys = value; }
            }

            /// <summary>
            /// Gets or sets the items.
            /// </summary>
            /// <value>The items.</value>
            public T[] Items
            {
                get { return m_Items; }
                set { m_Items = value; }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="KeyedCollectionAddRangeEventArgs"/> class.
            /// </summary>
            /// <param name="items">The items.</param>
            /// <param name="keys">The keys.</param>
            /// <param name="startIndex">The start index.</param>
            public KeyedCollectionAddRangeEventArgs(T[] items, string[] keys, int startIndex)
            {
                m_Items = items;
                m_Keys = keys;
                m_StartIndex = startIndex;
            }
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate KeyedCollectionAddHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyedCollectionAddEventArgs"/> instance containing the event data.</param>
        public delegate void KeyedCollectionAddHandler(object sender, KeyedCollectionAddEventArgs e);
        /// <summary>
        /// Delegate KeyedCollectionRemoveHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyedCollectionRemoveEventArgs"/> instance containing the event data.</param>
        public delegate void KeyedCollectionRemoveHandler(object sender, KeyedCollectionRemoveEventArgs e);
        /// <summary>
        /// Delegate KeyedCollectionMoveHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyedCollectionMoveEventArgs"/> instance containing the event data.</param>
        public delegate void KeyedCollectionMoveHandler(object sender, KeyedCollectionMoveEventArgs e);
        /// <summary>
        /// Delegate KeyedCollectionAddRangeHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyedCollectionAddRangeEventArgs"/> instance containing the event data.</param>
        public delegate void KeyedCollectionAddRangeHandler(object sender, KeyedCollectionAddRangeEventArgs e);

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [item add].
        /// </summary>
        public event KeyedCollectionAddHandler ItemAdd;
        /// <summary>
        /// Occurs when [item remove].
        /// </summary>
        public event KeyedCollectionRemoveHandler ItemRemove;
        /// <summary>
        /// Occurs when [item move].
        /// </summary>
        public event KeyedCollectionMoveHandler ItemMove;
        /// <summary>
        /// Occurs when [item add range].
        /// </summary>
        public event KeyedCollectionAddRangeHandler ItemAddRange;
        /// <summary>
        /// Occurs when [collection clear].
        /// </summary>
        public event EventHandler CollectionClear;
        /// <summary>
        /// Occurs when [collection changed].
        /// </summary>
        public event EventHandler CollectionChanged;

        #endregion

        #region Private Fields

        /// <summary>
        /// The keys
        /// </summary>
        private LightCollection<string> _keys;
        /// <summary>
        /// The items
        /// </summary>
        private LightCollection<T> _items;
        /// <summary>
        /// The readonly coll
        /// </summary>
        private ReadOnlyKeyedCollection<T> _readonlyColl;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedCollection{T}"/> class.
        /// </summary>
        public KeyedCollection()
            : this(4)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedCollection{T}"/> class.
        /// </summary>
        /// <param name="initialSize">The initial size.</param>
        public KeyedCollection(int initialSize)
        {
            _keys = new LightCollection<string>(initialSize);
            _items = new LightCollection<T>(initialSize);
            _readonlyColl = null;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedCollection{T}"/> class.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="items">The items.</param>
        public KeyedCollection(string[] keys, T[] items)
        {
            _keys = new LightCollection<string>(keys);
            _items = new LightCollection<T>(items);
            _readonlyColl = null;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>T.</returns>
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }
        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public T this[string key]
        {
            get
            {
                return _items[_keys.IndexOf(key)];
            }
            set
            {
                _items[_keys.IndexOf(key)] = value;
            }
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>The collection.</value>
        public LightCollection<T> Collection
        {
            get
            {
                return _items;
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
                return _items.Count;
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
                return _keys.GetItems();
            }
        }
        /// <summary>
        /// Gets the read only collection.
        /// </summary>
        /// <value>The read only collection.</value>
        public virtual ReadOnlyKeyedCollection<T> ReadOnlyCollection
        {
            get
            {
                if (_readonlyColl == null) _readonlyColl = new ReadOnlyKeyedCollection<T>(this);
                return _readonlyColl;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <exception cref="System.Exception">Key already exist</exception>
        public virtual void Add(string key, T item)
        {
            if (_keys.Contains(key))
            {
                throw new Exception("Key already exist");
            }
            _keys.Add(key);
            int index = _items.Add(item);

            if (ItemAdd != null) ItemAdd(this, new KeyedCollectionAddEventArgs(_items[index], index, _keys[index]));
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public virtual void AddRange(KeyedCollection<T> items)
        {
            if (items == null) return;

            AddRange(items.Keys, items.GetItems());
        }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="items">The items.</param>
        /// <exception cref="System.Exception"></exception>
        public virtual void AddRange(string[] keys, T[] items)
        {
            if (keys.Length != items.Length)
            {
                throw new Exception(" ");
            }

            int startIndex = _items.Count;

            _keys.AddRange(keys);
            _items.AddRange(items);

            if (ItemAddRange != null) ItemAddRange(this, new KeyedCollectionAddRangeEventArgs(items, keys, startIndex));
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public virtual void Clear()
        {
            _items.Clear();
            _keys.Clear();

            if (CollectionClear != null) CollectionClear(this, new EventArgs());
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public virtual bool Contains(T item)
        {
            return _items.Contains(item);
        }
        /// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key contains key; otherwise, <c>false</c>.</returns>
        public virtual bool ContainsKey(string key)
        {
            return _keys.Contains(key);
        }
        /// <summary>
        /// Creates the free key.
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string CreateFreeKey()
        {
            string key = "";
            do
            {
                key = Guid.NewGuid().ToString().Substring(0, 8);
            }
            while (_keys.Contains(key));
            return key;
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>KeyedCollection`1.Enumerator.</returns>
        public KeyedCollection<T>.Enumerator GetEnumerator()
        {
            return new KeyedCollection<T>.Enumerator(this);
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new KeyedCollection<T>.Enumerator(this);
        //}
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>T[].</returns>
        public virtual T[] GetItems()
        {
            if (_items.Count <= 0) return new T[0];
            return _items.GetItems();
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <returns>T[].</returns>
        public virtual T[] GetItems(int startIndex)
        {
            if (_items.Count <= 0) return new T[0];
            return _items.GetItems(startIndex);
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="finalIndex">The final index.</param>
        /// <returns>T[].</returns>
        public virtual T[] GetItems(int startIndex, int finalIndex)
        {
            if (_items.Count <= 0) return new T[0];
            return _items.GetItems(startIndex, finalIndex);
        }
        /// <summary>
        /// Indexes the of key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Int32.</returns>
        public virtual int IndexOfKey(string key)
        {
            return _keys.IndexOf(key);
        }
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public virtual int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }
        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <exception cref="System.Exception">Key already exist</exception>
        public virtual void Insert(int index, string key, T item)
        {
            if (_keys.Contains(key))
            {
                throw new Exception("Key already exist");
            }
            _keys.Insert(index, key);
            _items.Insert(index, item);

            if (ItemAdd != null) ItemAdd(this, new KeyedCollectionAddEventArgs(_items[index], index, _keys[index]));
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Moves the index of the by.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="newIndex">The new index.</param>
        public virtual void MoveByIndex(int index, int newIndex)
        {
            _items.MoveByIndex(index, newIndex);
            _keys.MoveByIndex(index, newIndex);

            if (ItemMove != null) ItemMove(this, new KeyedCollectionMoveEventArgs(_items[newIndex], newIndex, index, _keys[newIndex]));
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());

        }
        /// <summary>
        /// Moves the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="newIndex">The new index.</param>
        public virtual void Move(T item, int newIndex)
        {
            int index = this.IndexOf(item);
            MoveByIndex(index, newIndex);
        }
        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">The index.</param>
        public virtual void RemoveAt(int index)
        {
            T removedItem = _items[index];
            string removedKey = _keys[index];

            _items.RemoveAt(index);
            _keys.RemoveAt(index);

            if (ItemRemove != null) ItemRemove(this, new KeyedCollectionRemoveEventArgs(removedItem, removedKey, index));
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Removes the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public virtual void RemoveByKey(string key)
        {
            int index = _keys.IndexOf(key);
            T removedItem = _items[index];
            _items.RemoveAt(index);
            _keys.RemoveAt(index);

            if (ItemRemove != null) ItemRemove(this, new KeyedCollectionRemoveEventArgs(removedItem, key, index));
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Remove(T item)
        {
            int index = _items.IndexOf(item);
            T removedItem = _items[index];
            string removedKey = _keys[index];
            _items.RemoveAt(index);
            _keys.RemoveAt(index);

            if (ItemRemove != null) ItemRemove(this, new KeyedCollectionRemoveEventArgs(removedItem, removedKey, index));
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Sorts this instance.
        /// </summary>
        public virtual void Sort()
        {
            _items.Sort(_keys.GetItems());
            _keys.Sort(_keys.GetItems());
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Swaps the index of the by.
        /// </summary>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        public virtual void SwapByIndex(int index1, int index2)
        {
            _items.SwapByIndex(index1, index2);
            _keys.SwapByIndex(index1, index2);
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Swaps the specified item1.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        public virtual void Swap(T item1, T item2)
        {
            int index1 = _items.IndexOf(item1);
            int index2 = _items.IndexOf(item2);

            this.SwapByIndex(index1, index2);
        }
        /// <summary>
        /// Reverses this instance.
        /// </summary>
        public virtual void Reverse()
        {
            _items.Reverse();
            _keys.Reverse();

            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Reverses the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        public virtual void Reverse(int index, int length)
        {
            _items.Reverse(index, length);
            _keys.Reverse(index, length);
            if (CollectionChanged != null) CollectionChanged(this, new EventArgs());
        }
        /// <summary>
        /// Trims to size.
        /// </summary>
        public virtual void TrimToSize()
        {
            _items.TrimToSize();
            _keys.TrimToSize();
        }
        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryGetItem(int index, out T item)
        {
            return _items.TryGetItem(index, out item);
        }
        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryGetItem(string key, out T item)
        {
            item = default(T);
            if (!_keys.Contains(key)) return false;
            item = this[key];
            return true;
        }

        #endregion

        #region IEnumerable Members

        //IEnumerator IKeyedCollection<T>.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}
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
