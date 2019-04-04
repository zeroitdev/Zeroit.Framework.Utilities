// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="HexColorConverter.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for converting hex color to RGB and from RGB to hex.
    /// </summary>
    public static class HexColorConverter
    {
        /// <summary>
        /// Hexadecimals to red.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="HexString">The hexadecimal string.</param>
        /// <returns>System.Int32.</returns>
        public static int HexToRed(this int value, string HexString)
        {
            return HexToColor(Color.Transparent,HexString).R;
        }
        /// <summary>
        /// Hexadecimals to green.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="HexString">The hexadecimal string.</param>
        /// <returns>System.Int32.</returns>
        public static int HexToGreen(this int value, string HexString)
        {
            return HexToColor(Color.Transparent, HexString).G;
        }
        /// <summary>
        /// Hexadecimals to blue.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="HexString">The hexadecimal string.</param>
        /// <returns>System.Int32.</returns>
        public static int HexToBlue(this int value, string HexString)
        {
            return HexToColor(Color.Transparent, HexString).B;
        }
        /// <summary>
        /// Colors to hexadecimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="Color">The color.</param>
        /// <returns>System.String.</returns>
        public static string ColorToHex(this string value, Color Color)
        {
            return string.Format("#{0}{1}{2}", Color.R.ToString("X2"), Color.G.ToString("X2"), Color.B.ToString("X2"));
        }
        /// <summary>
        /// Hexadecimals to RGB.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="HexString">The hexadecimal string.</param>
        /// <returns>System.String[].</returns>
        public static string[] HexToRGB(this string [] value, string HexString)
        {
            Color tmpColor = ColorTranslator.FromHtml(HexString);
            string[] rgbArray = new string[4];
            rgbArray[0] = tmpColor.R.ToString();
            rgbArray[1] = tmpColor.G.ToString();
            rgbArray[2] = tmpColor.B.ToString();
            return rgbArray;
        }

        /// <summary>
        /// Hexadecimals to color.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="HexString">The hexadecimal string.</param>
        /// <returns>Color.</returns>
        public static Color HexToColor(this Color value, string HexString)
        {
            return ColorTranslator.FromHtml(HexString);
        }
    }
}