// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="MemHandler.cs" company="Zeroit Dev Technologies">
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