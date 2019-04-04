// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FILE_ATTRIBUTE.cs" company="Zeroit Dev Technologies">
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
    /// Enum FILE_ATTRIBUTE
    /// </summary>
    public enum FILE_ATTRIBUTE
    {
        /// <summary>
        /// The readonly
        /// </summary>
        READONLY = 0x00000001,
        /// <summary>
        /// The hidden
        /// </summary>
        HIDDEN = 0x00000002,
        /// <summary>
        /// The system
        /// </summary>
        SYSTEM = 0x00000004,
        /// <summary>
        /// The archive
        /// </summary>
        ARCHIVE = 0x00000020,
        /// <summary>
        /// The encrypted
        /// </summary>
        ENCRYPTED = 0x00000040,
        /// <summary>
        /// The normal
        /// </summary>
        NORMAL = 0x00000080,
        /// <summary>
        /// The temporary
        /// </summary>
        TEMPORARY = 0x00000100,
        /// <summary>
        /// The sparse file
        /// </summary>
        SPARSE_FILE = 0x00000200,
        /// <summary>
        /// The reparse point
        /// </summary>
        REPARSE_POINT = 0x00000400,
        /// <summary>
        /// The compressed
        /// </summary>
        COMPRESSED = 0x00000800,
        /// <summary>
        /// The offline
        /// </summary>
        OFFLINE = 0x00001000,
        /// <summary>
        /// The directory
        /// </summary>
        DIRECTORY = 0x00000010,
    }
}
