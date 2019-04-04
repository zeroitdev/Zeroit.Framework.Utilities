// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetScaledImage.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class BitmapManipulation.
    /// </summary>
    public static partial class BitmapManipulation
    {
        #region GetScaleImage

        /// <summary>
        /// Gets the automatic scale thumbnail image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="containerWidth">Width of the container.</param>
        /// <param name="containerHeight">Height of the container.</param>
        /// <returns>Image.</returns>
        public static Image GetAutoScaleThumbnailImage(this Image image, int containerWidth, int containerHeight)
        {
            if (image.Size.Width > containerWidth ||
                image.Size.Height > containerHeight)
            {
                double height = containerHeight;
                double width = containerWidth;

                double new_height;
                double new_width;
                double scale;
                new_height = height;
                new_width = width;
                if ((image.Width > width) || (image.Height > height))
                {
                    if (image.Width > width)
                    {
                        scale = image.Width / width;
                        new_width = image.Width / scale;
                        new_height = image.Height / scale;
                    }
                    else
                    {
                        scale = image.Height / height;
                        new_width = image.Width / scale;
                        new_height = image.Height / scale;
                    }
                }

                return image.GetThumbnailImage(Convert.ToInt32(new_width), Convert.ToInt32(new_height),
                   thumbnailCallback, IntPtr.Zero);

            }
            else
            {
                return image;
            }

        }

        /// <summary>
        /// The thumbnail callback
        /// </summary>
        static Image.GetThumbnailImageAbort thumbnailCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
        /// <summary>
        /// Thumbnails the callback.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>
        /// Gets the scaled image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="size">The size.</param>
        /// <returns>Image.</returns>
        public static Image GetScaledImage(this Image image, Size size)
        {
            if (image.Size.Width > size.Width ||
                image.Size.Height > size.Height)
            {
                double width = size.Width;
                double height = size.Height;

                double new_width;
                double new_height;
                double scale;
                new_height = height;
                new_width = width;
                if ((image.Width > width) || (image.Height > height))
                {
                    if (image.Width > width)
                    {
                        scale = image.Width / width;
                        new_width = image.Width / scale;
                        new_height = image.Height / scale;
                    }
                    else
                    {
                        scale = image.Height / height;
                        new_width = image.Width / scale;
                        new_height = image.Height / scale;
                    }
                }

                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(Convert.ToInt32(new_width), Convert.ToInt32(new_height));

                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

                g.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);

                return bitmap;
            }
            else
            {
                return image;
            }
        }

        /// <summary>
        /// Gets the scaled image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="containerWidth">Width of the container.</param>
        /// <param name="containerHeight">Height of the container.</param>
        /// <returns>Image.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Image GetScaledImage(this Image image, int containerWidth, int containerHeight)
        {
            if (containerWidth == null || containerHeight == null)
            {
                Debug.Assert(false, "containerWidth 或 containerHeight为空");
                throw new ArgumentNullException();
            }

            return GetScaledImage(image, new Size(containerWidth, containerHeight));
        }

        #endregion
    }
}
