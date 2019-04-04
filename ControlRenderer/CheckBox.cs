// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// A class collection for CheckBox manipulation
    /// </summary>
    public static class CheckBox
    {
        /// <summary>
        /// Draw a box of a checkbox on x, y coordinate.
        /// </summary>
        /// <param name="g">Graphics object where the box to be drawn.</param>
        /// <param name="x">X location of the box.</param>
        /// <param name="y">Y location of the box.</param>
        /// <param name="size">Size of the box.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        /// <param name="hLited">Determine whether checkbox is highlited.</param>
        public static void DrawCheckBox(this System.Drawing.Graphics g, int x, int y, int size = 14, bool enabled = true, bool hLited = false)
        {
            if (size > 0)
            {
                Rectangle rectBox = new Rectangle(x, y, size, size);
                g.FillRectangle(Brushes.White, rectBox);
                if (enabled && hLited)
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(62, 106, 170)), rectBox);
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(142, 143, 143)), rectBox);
                }
                if (enabled && size > 6)
                {
                    Rectangle innerRect = new Rectangle(x + 2, y + 2, size - 4, size - 4);
                    Rectangle brushRect = new Rectangle(x + 1, y + 1, size - 2, size - 2);
                    LinearGradientBrush borderBrush = new LinearGradientBrush(brushRect, Color.FromArgb(174, 179, 185), Color.FromArgb(233, 233, 234), 45);
                    LinearGradientBrush fillBrush = new LinearGradientBrush(brushRect, Color.Black, Color.White, 45);
                    Color[] fillColors = new Color[3];
                    float[] fillPos = new float[3];
                    ColorBlend fillBlend = new ColorBlend();
                    if (hLited)
                    {
                        fillColors[0] = Color.Yellow;
                        fillColors[1] = Color.FromArgb(232, 232, 232);
                    }
                    else
                    {
                        fillColors[0] = Color.FromArgb(203, 207, 213);
                        fillColors[1] = Color.FromArgb(232, 232, 232);
                    }
                    fillColors[2] = Color.FromArgb(246, 246, 246);
                    fillPos[0] = 0.0F;
                    fillPos[1] = 0.5F;
                    fillPos[2] = 1.0F;
                    fillBlend.Colors = fillColors;
                    fillBlend.Positions = fillPos;
                    fillBrush.InterpolationColors = fillBlend;
                    g.FillRectangle(fillBrush, innerRect);
                    g.DrawRectangle(new Pen(borderBrush), innerRect);
                    borderBrush.Dispose();
                    fillBrush.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Draw a box of a checkbox on p location.
        /// </summary>
        /// <param name="g">Graphics object where the box to be drawn.</param>
        /// <param name="p">Location of the box.</param>
        /// <param name="size">Size of the box.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        /// <param name="hLited">Determine whether checkbox is highlited.</param>
        public static void DrawCheckBox(this System.Drawing.Graphics g, Point p, int size = 14, bool enabled = true, bool hLited = false)
        {
            DrawCheckBox(g, p.X, p.Y, size, enabled, hLited);
        }
        
        /// <summary>
        /// Draw a box of a checkbox in the center of a rectangle.
        /// </summary>
        /// <param name="g">Graphics object where the box to be drawn.</param>
        /// <param name="rect">Rectangle where the box to be drawn.</param>
        /// <param name="size">Size of the box.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        /// <param name="hLited">Determine whether checkbox is highlited.</param>
        public static void DrawCheckBox(this System.Drawing.Graphics g, Rectangle rect, int size = 14, bool enabled = true, bool hLited = false)
        {
            int x = rect.X + (int)((rect.Width - size) / 2.0);
            int y = rect.Y + (int)((rect.Height - size) / 2.0);
            DrawCheckBox(g, x, y, size, enabled, hLited);
        }
        
        /// <summary>
        /// Draw a check of a checkbox on x, y coordinate.
        /// </summary>
        /// <param name="g">Graphics object where the check to be drawn.</param>
        /// <param name="x">X location of the check.</param>
        /// <param name="y">Y location of the check.</param>
        /// <param name="state">State of the check.</param>
        /// <param name="size">Size of the check.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        public static void DrawCheck(this System.Drawing.Graphics g, int x, int y, CheckState state = CheckState.Checked, int size = 8, bool enabled = true)
        {
            if (size > 4)
            {
                switch (state)
                {
                    case CheckState.Checked:
                        Point[] points = new Point[3];
                        points[0] = new Point(x + 1, y + (int)(size / 2.0));
                        points[1] = new Point(x + (int)(size / 2.0), y + size - 1);
                        points[2] = new Point(x + size - 1, y + 1);
                        if (enabled)
                        {
                            g.DrawLines(new Pen(Color.FromArgb(62, 106, 170), 2F), points);
                        }
                        else
                        {
                            g.DrawLines(new Pen(Color.DimGray, 2F), points);
                        }
                        break;
                    case CheckState.Indeterminate:
                        Rectangle innerRect = new Rectangle(x + 1, y + 1, size - 2, size - 2);
                        LinearGradientBrush brush = null;
                        if (enabled)
                        {
                            brush = new LinearGradientBrush(innerRect, Color.Chartreuse, Color.Green, 45);
                        }
                        else
                        {
                            brush = new LinearGradientBrush(innerRect, Color.Silver, Color.Gray, 45);
                        }
                        g.FillRectangle(brush, innerRect);
                        brush.Dispose();
                        break;
                }
            }
        }
        
        /// <summary>
        /// Draw a check of a checkbox on p location.
        /// </summary>
        /// <param name="g">Graphics object where the check to be drawn.</param>
        /// <param name="p">P location of the check.</param>
        /// <param name="state">State of the check.</param>
        /// <param name="size">Size of the check.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        public static void DrawCheck(this System.Drawing.Graphics g, Point p, CheckState state = CheckState.Checked, int size = 8, bool enabled = true)
        {
            DrawCheck(g, p.X, p.Y, state, size, enabled);
        }
        
        /// <summary>
        /// Draw a check of a checkbox inside a rectangle.
        /// </summary>
        /// <param name="g">Graphics object where the check to be drawn.</param>
        /// <param name="rect">Rectangle where the check to be drawn.</param>
        /// <param name="state">State of the check.</param>
        /// <param name="size">Size of the check.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        public static void DrawCheck(this System.Drawing.Graphics g, Rectangle rect, CheckState state = CheckState.Checked, int size = 8, bool enabled = true)
        {
            int x = rect.X + (int)((rect.Width - size) / 2.0);
            int y = rect.Y + (int)((rect.Y - size) / 2.0);
            DrawCheck(g, x, y, state, size, enabled);
        }
        
        /// <summary>
        /// Draw a CheckBox on x, y coordinate.
        /// </summary>
        /// <param name="g">Graphics object where the CheckBox to be drawn.</param>
        /// <param name="x">X location of the CheckBox.</param>
        /// <param name="y">Y location of the CheckBox.</param>
        /// <param name="state">CheckState of the CheckBox.</param>
        /// <param name="size">Size of the CheckBox.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        /// <param name="hLited">Determine whether checkbox is highlited.</param>
        /// <remarks>Minimum value of size is 8.</remarks>
        public static void DrawCheckBox(this System.Drawing.Graphics g, int x, int y, CheckState state = CheckState.Checked, int size = 14, bool enabled = true, bool hLited = false)
        {
            if (size > 8)
            {
                DrawCheckBox(g, x, y, size, enabled, hLited);
                DrawCheck(g, x + 2, y + 2, state, size - 4, enabled);
            }
        }
        
        /// <summary>
        /// Draw a CheckBox on p location.
        /// </summary>
        /// <param name="g">Graphics object where the CheckBox to be drawn.</param>
        /// <param name="p">Location of the CheckBox.</param>
        /// <param name="state">CheckState of the CheckBox.</param>
        /// <param name="size">Size of the CheckBox.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        /// <param name="hLited">Determine whether checkbox is highlited.</param>
        /// <remarks>Minimum value of size is 8.</remarks>
        public static void DrawCheckBox(this System.Drawing.Graphics g, Point p, CheckState state = CheckState.Checked, int size = 14, bool enabled = true, bool hLited = false)
        {
            if (size > 8)
            {
                DrawCheckBox(g, p.X, p.Y, size, enabled, hLited);
                DrawCheck(g, p.X + 2, p.Y + 2, state, size - 4, enabled);
            }
        }
        /// <summary>
        /// Draw a CheckBox inside a rectangle.
        /// </summary>
        /// <param name="g">Graphics object where the CheckBox to be drawn.</param>
        /// <param name="rect">Rectangle where the CheckBox to be drawn.</param>
        /// <param name="state">CheckState of the CheckBox.</param>
        /// <param name="size">Size of the CheckBox.</param>
        /// <param name="enabled">Determine whether checkbox is enabled.</param>
        /// <param name="hLited">Determine whether checkbox is highlited.</param>
        /// <remarks>Minimum value of size is 8.</remarks>
        public static void DrawCheckBox(this System.Drawing.Graphics g, Rectangle rect, CheckState state = CheckState.Checked, int size = 14, bool enabled = true, bool hLited = false)
        {
            if (size > 8)
            {
                int x = rect.X + (int)((rect.Width - size) / 2.0);
                int y = rect.Y + (int)((rect.Height - size) / 2.0);
                DrawCheckBox(g, x, y, size, enabled, hLited);
                DrawCheck(g, x + 2, y + 2, state, size - 4, enabled);
            }
        }
    }
}
