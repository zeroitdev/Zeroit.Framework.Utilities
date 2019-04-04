// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MARGINS.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct MARGINS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        /// <summary>
        /// The cx left width
        /// </summary>
        public int cxLeftWidth;
        /// <summary>
        /// The cx right width
        /// </summary>
        public int cxRightWidth;
        /// <summary>
        /// The cy top height
        /// </summary>
        public int cyTopHeight;
        /// <summary>
        /// The cy bottom height
        /// </summary>
        public int cyBottomHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="MARGINS"/> struct.
        /// </summary>
        /// <param name="Left">The left.</param>
        /// <param name="Right">The right.</param>
        /// <param name="Top">The top.</param>
        /// <param name="Bottom">The bottom.</param>
        public MARGINS(int Left, int Right, int Top, int Bottom)
        {
            this.cxLeftWidth = Left;
            this.cxRightWidth = Right;
            this.cyTopHeight = Top;
            this.cyBottomHeight = Bottom;
        }
    } 
}
