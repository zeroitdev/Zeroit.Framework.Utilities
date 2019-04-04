// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="MemHandler.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Summary description for MemHandler.
    /// </summary>
    public class MemHandler
	{
        /// <summary>
        /// The m heap
        /// </summary>
        private static ArrayList mHeap = new ArrayList();

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void Add(GDIObject item)
		{
			mHeap.Add(item);
		}

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void Remove(GDIObject item)
		{
			if (mHeap.Contains(item))
			{
				mHeap.Remove(item);
			}
		}

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public static GDIObject[] Items
		{
			get
			{
				ArrayList al = new ArrayList();

				foreach (GDIObject go in mHeap)
				{
					if (go != null)
						al.Add(go);
				}

				GDIObject[] gos = new GDIObject[al.Count];
				al.CopyTo(0, gos, 0, al.Count);
				return gos;
			}
		}

        /// <summary>
        /// Destroys all.
        /// </summary>
        public static void DestroyAll()
		{
			foreach (GDIObject go in Items)
			{
				go.Dispose();
			}
		}
	}
}