// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Bitmap.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
