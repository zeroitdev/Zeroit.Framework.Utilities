// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TreeItemCollection.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Class TreeItemCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeItemCollection<T>
	{
        /// <summary>
        /// The parent
        /// </summary>
        private string _parent;
        /// <summary>
        /// The items
        /// </summary>
        private LightCollection<string> _items;
        /// <summary>
        /// The owner collection
        /// </summary>
        private TreeCollection<T> _ownerCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeItemCollection{T}"/> class.
        /// </summary>
        /// <param name="ownerCollection">The owner collection.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="items">The items.</param>
        internal TreeItemCollection(ref TreeCollection<T> ownerCollection, string parent, LightCollection<string> items)
		{
			_parent = parent;
			_items = new LightCollection<string>(items);
			_ownerCollection = ownerCollection;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeItemCollection{T}"/> class.
        /// </summary>
        /// <param name="ownerCollection">The owner collection.</param>
        /// <param name="parent">The parent.</param>
        internal TreeItemCollection(ref TreeCollection<T> ownerCollection , string parent)
			: this(ref ownerCollection, parent, new LightCollection<string>())
		{
		}

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>TreeItem&lt;T&gt;.</returns>
        public TreeItem<T> Add(T value)
		{
			string key = _ownerCollection.GlobalCollection.CreateFreeKey();
			return Add(key, value);
		}
        /// <summary>
        /// Adds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TreeItem&lt;T&gt;.</returns>
        public TreeItem<T> Add(string id)
		{
			return Add(id, default(T));
		}
        /// <summary>
        /// Adds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>TreeItem&lt;T&gt;.</returns>
        /// <exception cref="System.Exception">key \""+id+"\" already exist</exception>
        public TreeItem<T> Add(string id, T value)
		{
			if(_ownerCollection.GlobalCollection.ContainsKey(id))
				throw new Exception("key \""+id+"\" already exist");

			TreeItem<T> treeItem = new TreeItem<T>(id, _parent, ref _ownerCollection);
			_ownerCollection.Global_AddItem(id, treeItem);

			_items.Add(id);
			return treeItem;

		}
        /// <summary>
        /// Tries the add.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>TreeItem&lt;T&gt;.</returns>
        public TreeItem<T> TryAdd(string id, T value)
		{
			if (_ownerCollection.GlobalCollection.ContainsKey(id))
				return null;
			return Add(id, value);
		}

        /// <summary>
        /// Removes the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        public void Remove(int index)
		{
			
		}

        /// <summary>
        /// Gets the <see cref="TreeItem{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>TreeItem&lt;T&gt;.</returns>
        public TreeItem<T> this[int index]
		{
			get
			{
				return _ownerCollection.GlobalCollection[_items[index]];
			}
		}
        /// <summary>
        /// Gets the <see cref="TreeItem{T}"/> with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TreeItem&lt;T&gt;.</returns>
        public TreeItem<T> this[string id]
		{
			get
			{
				return _ownerCollection.GlobalCollection[id];
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
        /// Gets the items identifier.
        /// </summary>
        /// <value>The items identifier.</value>
        internal LightCollection<string> ItemsId
		{
			get
			{
				return _items;
			}
		}

	}
}
