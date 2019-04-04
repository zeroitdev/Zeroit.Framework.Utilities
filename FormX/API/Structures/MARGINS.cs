// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MARGINS.cs" company="Zeroit Dev Technologies">
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
