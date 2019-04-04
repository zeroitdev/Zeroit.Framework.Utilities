// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ListViewObjects.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// A class collection for list view objects
    /// </summary>
    public class ListViewObjects
    {
        /// <summary>
        /// The type
        /// </summary>
        public string type = "Not Set";
        /// <summary>
        /// The datetime value
        /// </summary>
        public DateTime datetimeValue = DateTime.Now;
        /// <summary>
        /// The distance
        /// </summary>
        public int distance = 0;

        /// <summary>
        /// Override To String
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            string returnValue = type.PadRight(7) + "\t\t";
            returnValue += datetimeValue.ToString("yyyy/MM/dd HH:mm:ss") + "\t";
            returnValue += distance.ToString();

            return returnValue;
        }
    }
}
