// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="KEY.cs" company="Zeroit Dev Technologies">
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
    /// Enum KEY
    /// </summary>
    public enum KEY
    {
        /// <summary>
        /// All access
        /// </summary>
        ALL_ACCESS = 0xF003F,
        /// <summary>
        /// The create link
        /// </summary>
        CREATE_LINK = 0x20,
        /// <summary>
        /// The create sub key
        /// </summary>
        CREATE_SUB_KEY = 0x4,
        /// <summary>
        /// The enumerate sub keys
        /// </summary>
        ENUMERATE_SUB_KEYS = 0x8,
        /// <summary>
        /// The execute
        /// </summary>
        EXECUTE = 0x20019,
        /// <summary>
        /// The notify
        /// </summary>
        NOTIFY = 0x10,
        /// <summary>
        /// The query value
        /// </summary>
        QUERY_VALUE = 0x1,
        /// <summary>
        /// The read
        /// </summary>
        READ = 0x20019,
        /// <summary>
        /// The set value
        /// </summary>
        SET_VALUE = 0x2,
        /// <summary>
        /// The write
        /// </summary>
        WRITE = 0x20006,
    }
}
