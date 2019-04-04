// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ROOT_KEY.cs" company="Zeroit Dev Technologies">
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
    /// Enum ROOT_KEY
    /// </summary>
    public enum ROOT_KEY : uint
    {
        /// <summary>
        /// The hkey classes root
        /// </summary>
        HKEY_CLASSES_ROOT = 0x80000000,
        /// <summary>
        /// The hkey current user
        /// </summary>
        HKEY_CURRENT_USER = 0x80000001,
        /// <summary>
        /// The hkey local machine
        /// </summary>
        HKEY_LOCAL_MACHINE = 0x80000002,
        /// <summary>
        /// The hkey users
        /// </summary>
        HKEY_USERS = 0x80000003,
        /// <summary>
        /// The hkey performance data
        /// </summary>
        HKEY_PERFORMANCE_DATA = 0x80000004,
        /// <summary>
        /// The hkey current configuration
        /// </summary>
        HKEY_CURRENT_CONFIG = 0x80000005,
        /// <summary>
        /// The hkey dyn data
        /// </summary>
        HKEY_DYN_DATA = 0x80000006
    }
}
