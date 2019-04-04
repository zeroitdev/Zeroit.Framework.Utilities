// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StringCollection.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.Collections.Generic;

namespace Zeroit.Framework.Utilities.Collections.Specialized
{
    /// <summary>
    /// Class StringCollection.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.Collections.Generic.ILightCollection{System.String}" />
    public class StringCollection : ILightCollection<string>
    {
        /// <summary>
        /// The coll
        /// </summary>
        private LightCollection<string> _coll;

        /// <summary>
        /// Occurs when [item add].
        /// </summary>
        public event LightCollection<string>.LightCollectionAddHandler ItemAdd;
        /// <summary>
        /// Occurs when [item remove].
        /// </summary>
        public event LightCollection<string>.LightCollectionRemoveHandler ItemRemove;
        /// <summary>
        /// Occurs when [item move].
        /// </summary>
        public event LightCollection<string>.LightCollectionMoveHandler ItemMove;
        /// <summary>
        /// Occurs when [item add range].
        /// </summary>
        public event LightCollection<string>.LightCollectionAddRangeHandler ItemAddRange;
        /// <summary>
        /// Occurs when [collection clear].
        /// </summary>
        public event EventHandler CollectionClear;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StringCollection" /> class.
        /// </summary>
        public StringCollection()
        {
            _coll = new LightCollection<string>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StringCollection" /> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public StringCollection(string[] items)
        {
            _coll = new LightCollection<string>(items);
            _coll.ItemAdd += new LightCollection<string>.LightCollectionAddHandler(_coll_ItemAdd);
            _coll.ItemAddRange += new LightCollection<string>.LightCollectionAddRangeHandler(_coll_ItemAddRange);
            _coll.ItemMove += new LightCollection<string>.LightCollectionMoveHandler(_coll_ItemMove);
            _coll.ItemRemove += new LightCollection<string>.LightCollectionRemoveHandler(_coll_ItemRemove);
            _coll.CollectionClear += new EventHandler(_coll_CollectionClear);
        }

        #region Internal collection Events

        /// <summary>
        /// Handles the ItemAdd event of the _coll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LightCollection`1.LightCollectionAddEventArgs"/> instance containing the event data.</param>
        void _coll_ItemAdd(object sender, LightCollection<string>.LightCollectionAddEventArgs e)
        {
            if (ItemAdd != null)
            {
                ItemAdd(this, e);
            }
        }
        /// <summary>
        /// Handles the ItemAddRange event of the _coll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LightCollection`1.LightCollectionAddRangeEventArgs"/> instance containing the event data.</param>
        void _coll_ItemAddRange(object sender, LightCollection<string>.LightCollectionAddRangeEventArgs e)
        {
            if (ItemAddRange != null)
            {
                ItemAddRange(this, e);
            }
        }
        /// <summary>
        /// Handles the ItemMove event of the _coll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LightCollection`1.LightCollectionMoveEventArgs"/> instance containing the event data.</param>
        void _coll_ItemMove(object sender, LightCollection<string>.LightCollectionMoveEventArgs e)
        {
            if (ItemMove != null)
            {
                ItemMove(this, e);
            }
        }
        /// <summary>
        /// Handles the ItemRemove event of the _coll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LightCollection`1.LightCollectionRemoveEventArgs"/> instance containing the event data.</param>
        void _coll_ItemRemove(object sender, LightCollection<string>.LightCollectionRemoveEventArgs e)
        {
            if (ItemRemove != null)
            {
                ItemRemove(this, e);
            }
        }
        /// <summary>
        /// Handles the CollectionClear event of the _coll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void _coll_CollectionClear(object sender, EventArgs e)
        {
            if (CollectionClear != null)
            {
                CollectionClear(this, e);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StringCollection" /> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public StringCollection(ILightCollection<string> collection)
        {
            _coll = new LightCollection<string>(collection);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StringCollection" /> class.
        /// </summary>
        /// <param name="startCapacity">The start capacity.</param>
        public StringCollection(int startCapacity)
        {
            _coll = new LightCollection<string>(startCapacity);
        }

        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        public virtual int Capacity
        {
            get
            {
                return _coll.Capacity;
            }
            set
            {
                _coll.Capacity = value;
            }
        }

        #region ILightCollection<string> Members

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return _coll.Count; }
        }
        /// <summary>
        /// Gets or sets the <see cref="System.String"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.String.</returns>
        public string this[int index]
        {
            get
            {
                return _coll[index];
            }
            set
            {
                _coll[index] = value;
            }
        }
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public int Add(string item)
        {
            return _coll.Add(item);
        }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(string[] items)
        {
            _coll.AddRange(items);
        }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            _coll.Clear();
        }
        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public bool Contains(string item)
        {
            return _coll.Contains(item);
        }
        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void Insert(int index, string item)
        {
            _coll.Insert(index, item);
        }
        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Remove(string item)
        {
            return _coll.Remove(item);
        }
        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveAt(int index)
        {
            _coll.RemoveAt(index);
        }
        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public string Find(Predicate<string> match)
        {
            return _coll.Find(match);
        }
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(string item)
        {
            return _coll.IndexOf(item);
        }
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(string item, int index)
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
        public int IndexOf(string item, int index, int count)
        {
            return _coll.IndexOf(item, index, count);
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>T[].</returns>
        public string[] GetItems()
        {
            return _coll.GetItems();
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <returns>T[].</returns>
        public string[] GetItems(int startIndex)
        {
            return _coll.GetItems(startIndex);
        }
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="finalIndex">The final index.</param>
        /// <returns>T[].</returns>
        public string[] GetItems(int startIndex, int finalIndex)
        {
            return _coll.GetItems(startIndex, finalIndex);
        }
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        public void CopyTo(Array array, int index)
        {
            _coll.CopyTo(array, index);
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>LightCollection`1.Enumerator.</returns>
        public LightCollection<string>.Enumerator GetEnumerator()
        {
            return _coll.GetEnumerator();
        }
        /// <summary>
        /// Reverses this instance.
        /// </summary>
        public void Reverse()
        {
            _coll.Reverse();
        }
        /// <summary>
        /// Reverses the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        public void Reverse(int index, int length)
        {
            _coll.Reverse(index, length);
        }
        /// <summary>
        /// Moves the index of the by.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="newIndex">The new index.</param>
        public void MoveByIndex(int index, int newIndex)
        {
            _coll.MoveByIndex(index, newIndex);
        }
        /// <summary>
        /// Moves the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="newIndex">The new index.</param>
        public void Move(string item, int newIndex)
        {
            _coll.Move(item, newIndex);
        }
        /// <summary>
        /// Swaps the index of the by.
        /// </summary>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        public void SwapByIndex(int index1, int index2)
        {
            _coll.SwapByIndex(index1, index2);
        }
        /// <summary>
        /// Swaps the specified item1.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        public void Swap(string item1, string item2)
        {
            _coll.Swap(item1, item2);
        }

        #endregion

        /// <summary>
        /// Joins the specified separator.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public string Join(string separator)
        {
            string[] items = _coll.GetItems();
            return string.Join(separator, items);
        }
        /// <summary>
        /// Joins the specified separator.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.String.</returns>
        public string Join(string separator, int startIndex, int count)
        {
            string[] items = _coll.GetItems();
            return string.Join(separator, items, startIndex, count);
        }
        /// <summary>
        /// Toes the lower.
        /// </summary>
        public void ToLower()
        {
            for (int i = 0; i < _coll.Count; i++)
            {
                if (_coll[i] == null) continue;

                _coll[i] = _coll[i].ToLower();
            }
        }
        /// <summary>
        /// Toes the upper.
        /// </summary>
        public void ToUpper()
        {
            for (int i = 0; i < _coll.Count; i++)
            {
                if (_coll[i] == null) continue;

                _coll[i] = _coll[i].ToUpper();
            }
        }
        /// <summary>
        /// Reverses the strings.
        /// </summary>
        public void ReverseStrings()
        {
            for (int i = 0; i < _coll.Count; i++)
            {
                if (_coll[i] == null) continue;

                char[] chars = _coll[i].ToCharArray();
                Array.Reverse(chars);
                _coll[i] = new string(chars);
            }
        }

        #region ILightCollection<string> Members

        /// <summary>
        /// Tries the get item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryGetItem(int index, out string item)
        {
            return _coll.TryGetItem(index, out item);
        }

        #endregion

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

        #region ILightCollection<string> Members

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="sort">if set to <c>true</c> [sort].</param>
        /// <returns>System.Int32.</returns>
        public int Add(string item, bool sort)
        {
            return _coll.Add(item, sort);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(ILightCollection<string> items)
        {
            _coll.AddRange(items);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>LightCollection&lt;System.String&gt;.</returns>
        public LightCollection<string> Clone()
        {
            return _coll.Clone();
        }

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        public void InsertRange(int index, ILightCollection<string> items)
        {
            _coll.InsertRange(index, items);
        }

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        public void InsertRange(int index, string[] items)
        {
            _coll.InsertRange(index, items);
        }

        /// <summary>
        /// Gets the read only collection.
        /// </summary>
        /// <value>The read only collection.</value>
        public ReadOnlyCollection<string> ReadOnlyCollection
        {
            get {
                return _coll.ReadOnlyCollection;
            }
        }

        /// <summary>
        /// Trims to size.
        /// </summary>
        public void TrimToSize()
        {
            _coll.TrimToSize();
        }

        #endregion
    }
}
