// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TreeItemEnumerator.cs" company="Zeroit Dev Technologies">
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

using System.Collections;
using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Class TreeItemEnumerator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerator{Zeroit.Framework.Utilities.Collections.Generic.TreeItem{T}}" />
    public class TreeItemEnumerator<T>:IEnumerator<TreeItem<T>>
	{
        /// <summary>
        /// The current
        /// </summary>
        private TreeItem<T> _current;
        /// <summary>
        /// The global collection
        /// </summary>
        private KeyedCollection<TreeItem<T>> _globalCollection;
        /// <summary>
        /// The root items
        /// </summary>
        private LightCollection<string> _rootItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeItemEnumerator{T}"/> class.
        /// </summary>
        /// <param name="globalCollection">The global collection.</param>
        /// <param name="rootItems">The root items.</param>
        internal TreeItemEnumerator(ref KeyedCollection<TreeItem<T>> globalCollection,LightCollection<string> rootItems)
		{
			_globalCollection = globalCollection;
			_rootItems = rootItems;
		}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
		{
			_current = null;
			_globalCollection.Clear();
			_rootItems.Clear();
		}

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>The current.</value>
        public TreeItem<T> Current
		{
			get { return _current; }
		}
        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>The current.</value>
        object IEnumerator.Current
		{
			get { return _current; }
		}

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
		{
			_current = null;
		}

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
		{
			if (_current == null)
			{
				_current = _globalCollection[_rootItems[0]];
				return true;
			}

			TreeItem<T> current = _current.Next;

			if (current != null)
			{
				_current = current;
				return true;
			}

			while (current == null)
			{
				current = _current.Parent;

				if (current == null) return false;

				current = current.Next;
			}

			_current = current;
			return true;

		}
        /// <summary>
        /// Moves the previus.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MovePrevius()
		{
			if (_current == null)
			{
				return false;
			}

			TreeItem<T> current = _current.Previus;

			if (current != null)
			{
				_current = current;
				return true;
			}

			while (current == null)
			{
				current = _current.Parent;

				if (current == null) return false;

				current = current.Next;
			}

			_current = current;
			return true;

		}
        /// <summary>
        /// Moves the next sibiling.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveNextSibiling()
		{
			if (_current == null)
			{
				_current = _globalCollection[_rootItems[0]];
				return true;
			}

			TreeItem<T> current = _current.Next;

			if (current != null)
			{
				_current = current;
				return true;
			}
			return false;
		}
        /// <summary>
        /// Moves the previus sibiling.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MovePreviusSibiling()
		{
			if (_current == null) return false;

			TreeItem<T> current = _current.Previus;

			if (current != null)
			{
				_current = current;
				return true;
			}
			return false;
		}
        /// <summary>
        /// Moves the parent.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveParent()
		{
			if (_current == null) return false;

			TreeItem<T> current = _current.Parent;

			if (current != null)
			{
				_current = current;
				return true;
			}
			return false;
		}
        /// <summary>
        /// Moves the first sibiling.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveFirstSibiling()
		{
			if (_current == null)
			{
				_current = _globalCollection[_rootItems[0]];
				return true;
			}

			if (_current.Previus == null) return false;

			TreeItem<T> newCurrent = _current.Previus;
			while (newCurrent != null)
			{
				_current = newCurrent;
				newCurrent = _current.Previus;
			}
			return true;
		}
        /// <summary>
        /// Moves the last sibiling.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveLastSibiling()
		{
			if (_current == null)
			{
				_current = _globalCollection[_rootItems[_rootItems.Count - 1]];
				return true;
			}

			if (_current.Next == null) return false;

			TreeItem<T> newCurrent = _current.Next;
			while (newCurrent != null)
			{
				_current = newCurrent;
				newCurrent = _current.Next;
			}
			return true;
		}
        /// <summary>
        /// Moves the first child.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveFirstChild()
		{
			if (_current == null)
			{
				_current = _globalCollection[_rootItems[0]];
				return true;
			}

			if (_current.Subitems.Count == 0) return false;

			_current = _current.Subitems[0];
			return true;
		}
        /// <summary>
        /// Moves the last child.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveLastChild()
		{
			if (_current == null)
			{
				_current = _globalCollection[_rootItems[_rootItems.Count-1]];
				return true;
			}

			if (_current.Subitems.Count == 0) return false;

			_current = _current.Subitems[_current.Subitems.Count-1];
			return true;
		}
	}
}
