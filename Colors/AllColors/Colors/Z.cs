// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="Z.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Class WebColor.
    /// </summary>
    public static partial class WebColor
    {

        /// <summary>
        /// Gets the zaffre.
        /// </summary>
        /// <value>The zaffre.</value>
        public static Color Zaffre
        {
            get { return zaffre; }
        }

        /// <summary>
        /// Gets the zinnwaldite brown.
        /// </summary>
        /// <value>The zinnwaldite brown.</value>
        public static Color ZinnwalditeBrown
        {
            get { return zinnwalditeBrown; }
            
        }

        /// <summary>
        /// Gets the zomp.
        /// </summary>
        /// <value>The zomp.</value>
        public static Color Zomp
        {
            get { return zomp; }
        }



        /// <summary>
        /// The zaffre
        /// </summary>
        private static Color zaffre = Color.FromArgb(0, 20, 168);
        /// <summary>
        /// The zinnwaldite brown
        /// </summary>
        private static Color zinnwalditeBrown = Color.FromArgb(44, 22, 8);
        /// <summary>
        /// The zomp
        /// </summary>
        private static Color zomp = Color.FromArgb(57, 167, 142);
    }
}