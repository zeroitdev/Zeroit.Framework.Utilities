// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ETOKEN_PRIVILEGES.cs" company="Zeroit Dev Technologies">
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
    /// Enum ETOKEN_PRIVILEGES
    /// </summary>
    public enum ETOKEN_PRIVILEGES : uint
    {
        /// <summary>
        /// The assign primary
        /// </summary>
        ASSIGN_PRIMARY = 0x1,
        /// <summary>
        /// The token duplicate
        /// </summary>
        TOKEN_DUPLICATE = 0x2,
        /// <summary>
        /// The token impersonate
        /// </summary>
        TOKEN_IMPERSONATE = 0x4,
        /// <summary>
        /// The token query
        /// </summary>
        TOKEN_QUERY = 0x8,
        /// <summary>
        /// The token query source
        /// </summary>
        TOKEN_QUERY_SOURCE = 0x10,
        /// <summary>
        /// The token adjust privileges
        /// </summary>
        TOKEN_ADJUST_PRIVILEGES = 0x20,
        /// <summary>
        /// The token adjust groups
        /// </summary>
        TOKEN_ADJUST_GROUPS = 0x40,
        /// <summary>
        /// The token adjust default
        /// </summary>
        TOKEN_ADJUST_DEFAULT = 0x80,
        /// <summary>
        /// The token adjust sessionid
        /// </summary>
        TOKEN_ADJUST_SESSIONID = 0x100
    }
}
