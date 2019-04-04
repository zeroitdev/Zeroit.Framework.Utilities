// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="Hex.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Class HexConverter.
    /// </summary>
    public static class HexConverter
    {
        /// <summary>
        /// Froms the hexadecimal.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns>Color.</returns>
        public static Color FromHex(this Color color, string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }
    }
}