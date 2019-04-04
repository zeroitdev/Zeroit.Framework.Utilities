// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ResizeDirection.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.ControlUtils
{
    /// <summary>
    /// Enumeration for resize direction cursors
    /// </summary>
    public enum ResizeDirection
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The left
        /// </summary>
        Left = 1,
        /// <summary>
        /// The top left
        /// </summary>
        TopLeft = 2,
        /// <summary>
        /// The top
        /// </summary>
        Top = 4,
        /// <summary>
        /// The top right
        /// </summary>
        TopRight = 8,
        /// <summary>
        /// The right
        /// </summary>
        Right = 16,
        /// <summary>
        /// The bottom right
        /// </summary>
        BottomRight = 32,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom = 64,
        /// <summary>
        /// The bottom left
        /// </summary>
        BottomLeft = 128
    }
}
