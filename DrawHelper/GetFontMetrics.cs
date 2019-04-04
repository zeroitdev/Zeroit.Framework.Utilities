// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetFontMetrics.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// Class GetFontMetrics.
    /// </summary>
    public static class GetFontMetrics
    {
        /// <summary>
        /// Gets the font metric.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns>FontMetrics.</returns>
        public static FontMetrics GetFontMetric(
            this System.Drawing.Graphics graphics,
            Font font)
        {
            return FontMetricsImpl.GetFontMetrics(graphics, font);
        }
    }
        

}
