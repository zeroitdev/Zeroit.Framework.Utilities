// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageToIcon.cs" company="Zeroit Dev Technologies">
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
