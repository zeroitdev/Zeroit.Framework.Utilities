// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageToIcon.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// A class collection for rendering Triangle
    /// </summary>
    public static partial class BitmapManipulation
    {
        #region ImageToIcon

        /// <summary>
        /// Images to icon.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>Icon.</returns>
        public static Icon ImageToIcon(this Image image)
        {
            return ImageToIcon(image, ImageFormat.Png);
        }

        /// <summary>
        /// Images to icon.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="format">The format.</param>
        /// <returns>Icon.</returns>
        public static Icon ImageToIcon(this Image image, ImageFormat format)
        {
            System.IO.Stream ms = new MemoryStream();
            image.Save(ms, format);
            Icon icon = Icon.FromHandle(new System.Drawing.Bitmap(ms).GetHicon());
            ms.Close();
            return icon;
        }

        #endregion
    }
}
