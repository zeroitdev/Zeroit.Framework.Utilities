// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="RGBQUAD.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct RGBQUAD
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RGBQUAD
    {
        /// <summary>
        /// The RGB blue
        /// </summary>
        public byte rgbBlue;
        /// <summary>
        /// The RGB green
        /// </summary>
        public byte rgbGreen;
        /// <summary>
        /// The RGB red
        /// </summary>
        public byte rgbRed;
        /// <summary>
        /// The RGB reserved
        /// </summary>
        public byte rgbReserved;
    }
}
