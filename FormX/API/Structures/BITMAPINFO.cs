// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BITMAPINFO.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct BITMAPINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO
    {
        /// <summary>
        /// The bmi header
        /// </summary>
        public BITMAPINFOHEADER bmiHeader;
        /// <summary>
        /// The bmi colors
        /// </summary>
        public RGBQUAD bmiColors;
    }
}
