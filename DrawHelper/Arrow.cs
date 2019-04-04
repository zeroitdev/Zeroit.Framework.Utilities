// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Arrow.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// A class collection for rendering Arrow
    /// </summary>
    public static partial class DrawRenderer
    {
        /// <summary>
        /// Get Arrow Path
        /// </summary>
        /// <param name="x">Set X</param>
        /// <param name="y">Set Y</param>
        /// <param name="flip">Flip</param>
        /// <returns></returns>
        public static GraphicsPath GetArrowPath(this GraphicsPath path, int x, int y, bool flip)
        {
            GraphicsPath GP = new GraphicsPath();

            int W = 12;
            int H = 6;

            if (flip)
            {
                GP.AddLine(x + 1, y, x + W + 1, y);
                GP.AddLine(x + W, y, x + H, y + H - 1);
            }
            else
            {
                GP.AddLine(x, y + H, x + W, y + H);
                GP.AddLine(x + W, y + H, x + H, y);
            }

            GP.CloseFigure();
            return GP;
        }


    }

}
