// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DrawTick.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// A class collection for rendering controls
    /// </summary>
    public static partial class DrawRenderer
    {
        /// <summary>
        /// Draw Tick
        /// </summary>
        /// <param name="g">Set Graphics</param>
        /// <param name="r">Set Rectangle</param>
        /// <param name="c">Set Color</param>
        /// <param name="thickness">Set thickness</param>
        public static void DrawTick(System.Drawing.Graphics g, Rectangle r, Color c, int thickness = 2)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (Pen pen = new Pen(c, thickness))
            {
                Point point = new Point(checked(r.X + 3), checked(r.Y + 6));
                Point point1 = new Point(checked(r.X + 4), checked(r.Y + 10));
                g.DrawLine(pen, point, point1);
                point1 = new Point(checked(r.X + 4), checked(r.Y + 10));
                point = new Point(checked(r.X + 5), checked(r.Y + 10));
                g.DrawLine(pen, point1, point);
                point1 = new Point(checked(r.X + 5), checked(r.Y + 10));
                point = new Point(checked(r.X + 10), checked(r.Y + 3));
                g.DrawLine(pen, point1, point);
            }
        }
    }
}
