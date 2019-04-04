// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="GrayScale.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Class ColorToGray.
    /// </summary>
    public static class ColorToGray
    {

        /// <summary>
        /// Grays the scale.
        /// </summary>
        /// <param name="cr">The cr.</param>
        /// <returns>Color.</returns>
        public static Color GrayScale(Color cr)
        {
            return Color.FromArgb(cr.A, (int)(cr.R * .3 + cr.G * .59 + cr.B * 0.11),
                (int)(cr.R * .3 + cr.G * .59 + cr.B * 0.11),
                (int)(cr.R * .3 + cr.G * .59 + cr.B * 0.11));
        }
    }
}