// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BITMAPINFOHEADER.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
