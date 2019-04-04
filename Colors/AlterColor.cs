// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="AlterColor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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