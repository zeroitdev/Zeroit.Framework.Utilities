// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Bitmap.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
/*
 This class is a wrap around the original bitmap so the rest of the code is independant of the C# Bitmap
 This is a simple class in this C# implementation but if the code is ported then this would become an important class.
 * 
 */
namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class BitmapWorker.
    /// </summary>
    public class BitmapWorker
    {
        /// <summary>
        /// The holder
        /// </summary>
        LockBitmap holder;
        /// <summary>
        /// The bitmaplock
        /// </summary>
        bool bitmaplock =false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapWorker"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public BitmapWorker(String filename)
        {
            holder = new LockBitmap(new System.Drawing.Bitmap(filename));
            if (!bitmaplock) { holder.LockBits(); bitmaplock = true; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapWorker"/> class.
        /// </summary>
        /// <param name="a">a.</param>
        BitmapWorker(System.Drawing.Bitmap a)
        {
            holder = new LockBitmap(a);
            if (!bitmaplock) { holder.LockBits(); bitmaplock = true; }
        }

        /// <summary>
        /// Sets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="color">The color.</param>
        public void SetPixel(int x, int y, Color color)
        {
            if (!bitmaplock) { holder.LockBits(); bitmaplock = true; }
            holder.SetPixel(x, y, color);
        }

        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Color.</returns>
        public Color GetPixel(int x, int y)
        {
            return holder.GetPixel(x, y);
        }

        /// <summary>
        /// Widthes this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Width()
        {
            return holder.Width;
        }

        /// <summary>
        /// Heights this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Height()
        {
            return holder.Height;
        }
        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <returns>System.Drawing.Bitmap.</returns>
        public System.Drawing.Bitmap GetBitmap()
        {
            if (bitmaplock) { holder.UnlockBits(); bitmaplock = false; }
            return holder.GetBitmap();
        }
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>BitmapWorker.</returns>
        public BitmapWorker Clone()
        {
            if (bitmaplock) { holder.UnlockBits(); bitmaplock = false; }
            return new BitmapWorker((System.Drawing.Bitmap)holder.GetBitmap().Clone());
        }

    }
}
