// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ERROR.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum ERROR
    /// </summary>
    public enum ERROR
    {
        /// <summary>
        /// The none
        /// </summary>
        NONE = 0x0,
        /// <summary>
        /// The baddb
        /// </summary>
        BADDB = 0x1,
        /// <summary>
        /// The badkey
        /// </summary>
        BADKEY = 0x2,
        /// <summary>
        /// The cantopen
        /// </summary>
        CANTOPEN = 0x3,
        /// <summary>
        /// The cantread
        /// </summary>
        CANTREAD = 0x4,
        /// <summary>
        /// The cantwrite
        /// </summary>
        CANTWRITE = 0x5,
        /// <summary>
        /// The outofmemory
        /// </summary>
        OUTOFMEMORY = 0x6,
        /// <summary>
        /// The arena trashed
        /// </summary>
        ARENA_TRASHED = 0x7,
        /// <summary>
        /// The access denied
        /// </summary>
        ACCESS_DENIED = 0x8,
        /// <summary>
        /// The invalid parameters
        /// </summary>
        INVALID_PARAMETERS = 0x57,
        /// <summary>
        /// The more data
        /// </summary>
        MORE_DATA = 0xEA,
        /// <summary>
        /// The no more items
        /// </summary>
        NO_MORE_ITEMS = 0x103,
    }
}
