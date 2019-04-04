// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="REG.cs" company="Zeroit Dev Technologies">
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
    /// Enum REG
    /// </summary>
    public enum REG
    {
        /// <summary>
        /// The option non volatile
        /// </summary>
        OPTION_NON_VOLATILE = 0x0,
        /// <summary>
        /// The error ok
        /// </summary>
        ERR_OK = 0x0,
        /// <summary>
        /// The error not exist
        /// </summary>
        ERR_NOT_EXIST = 0x1,
        /// <summary>
        /// The error not string
        /// </summary>
        ERR_NOT_STRING = 0x2,
        /// <summary>
        /// The error not dword
        /// </summary>
        ERR_NOT_DWORD = 0x4,
    }
}
