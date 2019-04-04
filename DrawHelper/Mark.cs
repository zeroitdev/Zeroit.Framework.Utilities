// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Mark.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    #region Mark


    /// <summary>
    /// Class Mark.
    /// </summary>
    public static class Mark
    {
        /// <summary>
        /// Files the not find.
        /// </summary>
        /// <param name="image">The image.</param>
        [Obsolete("改用 FileNotFind(Size size)")]
        public static void FileNotFind(Image image)
        {
            if (image == null)
            {
                Debug.Assert(false, "image = null");
                return;
            }

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawRectangle(Pens.Red, 0, 0, image.Width - 1, image.Height - 1);
            g.DrawLine(Pens.Red, 0, 0, image.Width, image.Height);
            g.DrawLine(Pens.Red, image.Width, 0, 0, image.Height);
            g.Dispose();
        }

        /// <summary>
        /// Files the not found.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>Image.</returns>
        public static Image FileNotFind(Size size)
        {
            Image image = new System.Drawing.Bitmap(size.Width, size.Height);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Red, 0, 0, image.Width - 1, image.Height - 1);
            g.DrawLine(Pens.Red, 0, 0, image.Width, image.Height);
            g.DrawLine(Pens.Red, image.Width, 0, 0, image.Height);
            g.Dispose();

            return image;
        }

        /// <summary>
        /// Files the can not read.
        /// </summary>
        /// <param name="image">The image.</param>
        [Obsolete("改用 FileCanNotRead(Size size)")]
        public static void FileCanNotRead(Image image)
        {
            if (image == null)
            {
                Debug.Assert(false, "image = null");
                return;
            }

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawRectangle(Pens.Red, 0, 0, image.Width - 1, image.Height - 1);
            g.DrawLine(Pens.Red, 0, 0, image.Width, image.Height);
            g.DrawLine(Pens.Red, image.Width, 0, 0, image.Height);
            g.Dispose();
        }

        /// <summary>
        /// Files the can not read.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>Image.</returns>
        public static Image FileCanNotRead(Size size)
        {
            Image image = new System.Drawing.Bitmap(size.Width, size.Height);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Red, 0, 0, image.Width - 1, image.Height - 1);
            g.DrawLine(Pens.Red, 0, 0, image.Width, image.Height);
            g.DrawLine(Pens.Red, image.Width, 0, 0, image.Height);
            g.Dispose();

            return image;
        }
    }

    #endregion
}
