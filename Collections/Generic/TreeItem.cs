// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TreeItem.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.Collections.Generic
{
    /// <summary>
    /// Class TreeItem.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeItem<T>
	{
        /// <summary>
        /// The identifier
        /// </summary>
        private string _id;

        /// <summary>
        /// The parent
        /// </summary>
        private string _parent;
        /// <summary>
        /// The next
        /// </summary>
        private string _next;
        /// <summary>
        /// The previus
        /// </summary>
        private string _previus;
        //private string _fullPath;

        /// <summary>
        /// The owner collection
        /// </summary>
        private TreeCollection<T> _ownerCollection;

        /// <summary>
        /// The subitems
        /// </summary>
        private LightCollection<string> _subitems;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeItem{T}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="ownerCollection">The owner collection.</param>
        internal TreeItem(string id, string parent, ref TreeCollection<T> ownerCollection)
		{
			_id = id;
			_parent = parent;
			_ownerCollection = ownerCollection;
			_subitems = new LightCollection<string>();
		}

        /// <summary>
        /// Sets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        internal void SetId(string id)
		{
			_id=id;
		}
        /// <summary>
        /// Sets the parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal void SetParent(string parent)
		{
			_parent = parent;
		}
        /*internal void SetGlobalCollectionRef(ref KeyedCollection<TreeItemInternal<T>> globalCollection)
		{
			_globalCollection = globalCollection;
		}*/
        /// <summary>
        /// Sets the next.
        /// </summary>
        /// <param name="next">The next.</param>
        internal void SetNext(string next)
		{
			_next = next;
		}
        /// <summary>
        /// Sets the previus.
        /// </summary>
        /// <param name="previus">The previus.</param>
        internal void SetPrevius(string previus)
		{
			_previus = previus;
		}

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id
		{
			get
			{
				return _id;
			}
		}
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value
		{
			get
			{
				return _ownerCollection.GlobalValues[_id];
			}
			set
			{
				_ownerCollection.GlobalValues[_id] = value;
			}
		}

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>The level.</value>
        public int Level
		{
			get
			{
				string[] strs = GetFullPath().Split('/');
				return strs.Length-1;
			}
		}

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public TreeItem<T> Parent
		{
			get
			{
				return _ownerCollection.GlobalCollection[_parent];
			}
		}
        /// <summary>
        /// Gets the next.
        /// </summary>
        /// <value>The next.</value>
        public TreeItem<T> Next
		{
			get
			{
				return _ownerCollection.GlobalCollection[_next];
			}
		}
        /// <summary>
        /// Gets the previus.
        /// </summary>
        /// <value>The previus.</value>
        public TreeItem<T> Previus
		{
			get
			{
				return _ownerCollection.GlobalCollection[_previus];
			}
		}

        /// <summary>
        /// Gets the subitems.
        /// </summary>
        /// <value>The subitems.</value>
        public TreeItemCollection<T> Subitems
		{
			get
			{
				return new TreeItemCollection<T>(ref _ownerCollection,_id,_subitems);
			}
		}

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetFullPath()
		{
			LightCollection<string> paths=new LightCollection<string>();
			paths.Add(_id);
			TreeItem<T> parent = this.Parent;
			while (parent != null)
			{
				paths.Add(parent.Id);
				parent = parent.Parent;
			}
			paths.Reverse();
			string fullPath = string.Join("/", paths.GetItems());
			return fullPath;
		}
	}
}


