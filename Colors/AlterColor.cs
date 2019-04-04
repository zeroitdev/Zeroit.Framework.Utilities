// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="AlterColor.cs" company="Zeroit Dev Technologies">
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
    /// Class AlterRGBColor.
    /// </summary>
    public static class AlterRGBColor
    {
        /// <summary>
        /// Alters the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="original">The original.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>Color.</returns>
        public static Color AlterColor(this Color color, Color original, int amount = -20)
        {
            Color c = original;
            int a = amount;
            int r = 0;
            int g = 0;
            int b = 0;
            if (c.R + a < 0)
            {
                r = 0;
            }
            else if (c.R + a > 255)
            {
                r = 255;
            }
            else
            {
                r = c.R + a;
            }
            if (c.G + a < 0)
            {
                g = 0;
            }
            else if (c.G + a > 255)
            {
                g = 255;
            }
            else
            {
                g = c.G + a;
            }
            if (c.B + a < 0)
            {
                b = 0;
            }
            else if (c.B + a > 255)
            {
                b = 255;
            }
            else
            {
                b = c.B + a;
            }
            return Color.FromArgb(r, g, b);
        }
                
    }
}