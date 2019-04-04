// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FastQueue.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Class FastQueue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FastQueue<T>
    {
        /// <summary>
        /// The items
        /// </summary>
        internal T[] _items;
        /// <summary>
        /// The count
        /// </summary>
        private int _count = 0;
        /// <summary>
        /// The capacity
        /// </summary>
        private int _capacity = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FastQueue&lt;T&gt;" /> class.
        /// </summary>
        public FastQueue()
        {
            _items = new T[4];
        }

        /// <summary>
        /// Gets the count.
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
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Enqueue(T item)
        {
            _count++;
            EnsureCapacity(_count);
            _items[_count - 1] = item;
        }
        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns>T.</returns>
        /// <exception cref="System.InvalidOperationException">Empty Queue</exception>
        public virtual T Peek()
        {
            if (this._capacity == 0)
            {
                throw new InvalidOperationException("Empty Queue");
            }
            return this._items[_count - 1];
        }
        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns>T.</returns>
        public virtual T Dequeue()
        {
            T item = this._items[_count - 1];

            T[] items = new T[_capacity];

            Array.Copy(_items, items, _count - 1);

            _items = items;

            return item;
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

                _capacity = newCapacity;

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
                        Array.Copy(this._items, 0, newArray, 0, this._count-1);
                    }

                    this._items = newArray;
                }
                else
                {
                    this._items = new T[4];
                }
            }
        }
    }
}
