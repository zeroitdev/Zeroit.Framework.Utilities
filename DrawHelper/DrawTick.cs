// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DrawTick.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
