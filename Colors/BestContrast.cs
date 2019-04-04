// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="BestContrast.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
