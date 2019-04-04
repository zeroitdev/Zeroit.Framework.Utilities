// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DrawBorders.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// A class collection for rendering control border
    /// </summary>
    public static partial class DrawRenderer
    {
        #region " DrawBorders "

        /// <summary>
        /// Draw borders
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="p1">Set Pen</param>
        /// <param name="offset">Set offset</param>
        /// <param name="rectangle">Set Rectangle</param>
        public static void DrawBorders(this System.Drawing.Graphics graphics, Pen p1, int offset, Rectangle rectangle)
        {
            DrawBorders(graphics, p1, 0, 0, rectangle.Width, rectangle.Height, offset);
        }

        /// <summary>
        /// Draw Borders
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="p1">Set Pen</param>
        /// <param name="r">Set rectangle</param>
        /// <param name="offset">Set offset</param>
        public static void DrawBorders(this System.Drawing.Graphics graphics, Pen p1, Rectangle r, int offset)
        {
            DrawBorders(graphics, p1, r.X, r.Y, r.Width, r.Height, offset);
        }

        /// <summary>
        /// Draw Borders
        /// </summary>
        /// <param name="graphics">Set graphics</param>
        /// <param name="p1">Set Pen</param>
        /// <param name="x">Set X</param>
        /// <param name="y">Set Y</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        /// <param name="offset">Set Offset</param>
        public static void DrawBorders(this System.Drawing.Graphics graphics, Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(graphics, p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        /// <summary>
        /// Draw Borders
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="p1">Set Pen</param>
        /// <param name="rectangle">Set Rectangle</param>
        /// <param name="dummy">Set dummy</param>
        public static void DrawBorders(this System.Drawing.Graphics graphics, Pen p1, Rectangle rectangle, bool dummy)
        {
            DrawBorders(graphics, p1, 0, 0, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        /// Draw Borders
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="p1">Set Pen</param>
        /// <param name="r">Set Rectangle</param>
        public static void DrawBorders(this System.Drawing.Graphics graphics,Pen p1, Rectangle r)
        {
            DrawBorders(graphics, p1, r.X, r.Y, r.Width, r.Height);
        }

        /// <summary>
        /// Draw Borders
        /// </summary>
        /// <param name="graphics">Set Graphics</param>
        /// <param name="p1">Set Pen</param>
        /// <param name="x">Set Pen</param>
        /// <param name="y">Set Y</param>
        /// <param name="width">Set Width</param>
        /// <param name="height">Set Height</param>
        public static void DrawBorders(this System.Drawing.Graphics graphics, Pen p1, int x, int y, int width, int height)
        {
            
            graphics.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion
        
    }
}
