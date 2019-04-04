// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BITMAPINFOHEADER.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct BITMAPINFOHEADER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        /// <summary>
        /// The bi size
        /// </summary>
        public int biSize;
        /// <summary>
        /// The bi width
        /// </summary>
        public int biWidth;
        /// <summary>
        /// The bi height
        /// </summary>
        public int biHeight;
        /// <summary>
        /// The bi planes
        /// </summary>
        public short biPlanes;
        /// <summary>
        /// The bi bit count
        /// </summary>
        public short biBitCount;
        /// <summary>
        /// The bi compression
        /// </summary>
        public int biCompression;
        /// <summary>
        /// The bi size image
        /// </summary>
        public int biSizeImage;
        /// <summary>
        /// The bi x pels per meter
        /// </summary>
        public int biXPelsPerMeter;
        /// <summary>
        /// The bi y pels per meter
        /// </summary>
        public int biYPelsPerMeter;
        /// <summary>
        /// The bi color used
        /// </summary>
        public int biClrUsed;
        /// <summary>
        /// The bi color important
        /// </summary>
        public int biClrImportant;
    }
}
