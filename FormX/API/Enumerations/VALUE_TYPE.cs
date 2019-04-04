// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="VALUE_TYPE.cs" company="Zeroit Dev Technologies">
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
    /// Enum VALUE_TYPE
    /// </summary>
    public enum VALUE_TYPE : uint
    {
        /// <summary>
        /// The reg none
        /// </summary>
        REG_NONE,
        /// <summary>
        /// The reg sz
        /// </summary>
        REG_SZ = 1,
        /// <summary>
        /// The reg expand sz
        /// </summary>
        REG_EXPAND_SZ = 2,
        /// <summary>
        /// The reg binary
        /// </summary>
        REG_BINARY = 3,
        /// <summary>
        /// The reg dword
        /// </summary>
        REG_DWORD = 4,
        /// <summary>
        /// The reg dword little endian
        /// </summary>
        REG_DWORD_LITTLE_ENDIAN = 4,
        /// <summary>
        /// The reg dword big endian
        /// </summary>
        REG_DWORD_BIG_ENDIAN = 5,
        /// <summary>
        /// The reg link
        /// </summary>
        REG_LINK = 6,
        /// <summary>
        /// The reg multi sz
        /// </summary>
        REG_MULTI_SZ = 7,
        /// <summary>
        /// The reg resource list
        /// </summary>
        REG_RESOURCE_LIST = 8,
        /// <summary>
        /// The reg full resource descriptor
        /// </summary>
        REG_FULL_RESOURCE_DESCRIPTOR = 9,
        /// <summary>
        /// The reg resource requirements list
        /// </summary>
        REG_RESOURCE_REQUIREMENTS_LIST = 10,
        /// <summary>
        /// The reg qword little endian
        /// </summary>
        REG_QWORD_LITTLE_ENDIAN = 11
    }
}
