// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="BestContrast.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Class BestContrast.
    /// </summary>
    public static class BestContrast
    {
        /// <summary>
        /// Gets the best contrast.
        /// </summary>
        /// <param name="BackColor">Color of the back.</param>
        /// <returns>System.Drawing.Color.</returns>
        public static System.Drawing.Color GetBestContrast(System.Drawing.Color BackColor)
        {

            int nThreshold = 105;

            int bgDelta = Convert.ToInt32((BackColor.R * 0.299) + (BackColor.G * 0.587) + (BackColor.B * 0.114));

            System.Drawing.Color color = (255 - bgDelta < nThreshold) ? System.Drawing.Color.Black : System.Drawing.Color.White;

            return color;

        }

    }
}
