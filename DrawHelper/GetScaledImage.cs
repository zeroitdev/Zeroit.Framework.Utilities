// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetScaledImage.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
