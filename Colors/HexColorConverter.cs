// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="HexColorConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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