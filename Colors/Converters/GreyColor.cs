// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GreyColor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// A class collection for Grey color manipulation
    /// </summary>
    public static class GreyColor
    {
        /// <summary>
        /// Get Grey Color
        /// </summary>
        /// <param name="G">Set grey value</param>
        /// <returns></returns>
        public static Color GetGreyColor(this Color color, int G)
        {
            return Color.FromArgb(G, G, G);
        }

        /// <summary>
        /// To Grey scale
        /// </summary>
        /// <param name="originalColor">Set original color</param>
        /// <returns></returns>
        public static Color ToGrayScale(this Color color, Color originalColor)
        {
            if (originalColor.Equals(Color.Transparent))
                return originalColor;

            int grayScale = (int)((originalColor.R * .299) + (originalColor.G * .587) + (originalColor.B * .114));
            return Color.FromArgb(grayScale, grayScale, grayScale);
        }

    }
}
