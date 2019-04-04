// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WIN32_FIND_DATAA.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Struct WIN32_FIND_DATAA
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATAA
    {
        /// <summary>
        /// The dw file attributes
        /// </summary>
        public Int32 dwFileAttributes;
        /// <summary>
        /// The ft creation time
        /// </summary>
        public FILETIME ftCreationTime;
        /// <summary>
        /// The ft last access time
        /// </summary>
        public FILETIME ftLastAccessTime;
        /// <summary>
        /// The ft last write time
        /// </summary>
        public FILETIME ftLastWriteTime;
        /// <summary>
        /// The n file size high
        /// </summary>
        public Int32 nFileSizeHigh;
        /// <summary>
        /// The n file size low
        /// </summary>
        public Int32 nFileSizeLow;
        /// <summary>
        /// The dw reserved0
        /// </summary>
        public Int32 dwReserved0;
        /// <summary>
        /// The dw reserved1
        /// </summary>
        public Int32 dwReserved1;
        /// <summary>
        /// The c file name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)MAX.PATH)]
        public string cFileName;
        /// <summary>
        /// The c alternate
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)MAX.ALTERNATE)]
        public string cAlternate;
    }
}
