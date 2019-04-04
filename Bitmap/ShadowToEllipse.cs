// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ShadowToEllipse.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// A class collection of shadow on ellipse controls
    /// </summary>
    public static class ShadowToEllipse
    {
        /// <summary>
        /// Ellipse shadow Hypothetically.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Paint Event Arguments</param>
        /// <param name="control">Control for implementation</param>
        public static void DrawCircularShadow(this System.Drawing.Graphics g, Color color, Color shadowColor, Control control)
        {
            
            //Color color = Color.Blue;
            //Color shadow = Color.FromArgb(255, 16, 16, 16);

            for (int i = 0; i < 8; i++)
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, shadowColor)))
                {
                    g.FillEllipse(brush, control.ClientRectangle.X + i * 2,
                        control.ClientRectangle.Y + i, 60, 60);
                }

            using (SolidBrush brush = new SolidBrush(color))
                g.FillEllipse(brush, control.ClientRectangle.X, control.ClientRectangle.Y, 60, 60);

            // move to the right to use the same coordinates again for the drawn shape
            g.TranslateTransform(80, 0);

            for (int i = 0; i < 8; i++)
                using (Pen pen = new Pen(Color.FromArgb(80 - i * 10, shadowColor), 2.5f))
                {
                    g.DrawEllipse(pen, control.ClientRectangle.X + i * 1.25f,
                        control.ClientRectangle.Y + i, 60, 60);
                }
            using (Pen pen = new Pen(color))
                g.DrawEllipse(pen, control.ClientRectangle.X, control.ClientRectangle.Y, 60, 60);

        }


        /// <summary>
        /// Ellipse shadow Hypothetically.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Paint Event Arguments</param>
        /// <param name="control">Control for implementation</param>
        public static void DrawCircularShadow(this System.Drawing.Graphics g, Color color, Color shadowColor, Rectangle rectangle)
        {

            //Color color = Color.Blue;
            //Color shadow = Color.FromArgb(255, 16, 16, 16);

            for (int i = 0; i < 8; i++)
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, shadowColor)))
                {
                    g.FillEllipse(brush, rectangle.X + i * 2,
                        rectangle.Y + i, 60, 60);
                }

            using (SolidBrush brush = new SolidBrush(color))
                g.FillEllipse(brush, rectangle.X, rectangle.Y, 60, 60);

            // move to the right to use the same coordinates again for the drawn shape
            g.TranslateTransform(80, 0);

            for (int i = 0; i < 8; i++)
                using (Pen pen = new Pen(Color.FromArgb(80 - i * 10, shadowColor), 2.5f))
                {
                    g.DrawEllipse(pen, rectangle.X + i * 1.25f,
                        rectangle.Y + i, 60, 60);
                }
            using (Pen pen = new Pen(color))
                g.DrawEllipse(pen, rectangle.X, rectangle.Y, 60, 60);

        }

        /// <summary>
        /// Ellipse shadow Hypothetically.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Paint Event Arguments</param>
        /// <param name="control">Control for implementation</param>
        public static void DrawRectangularShadow(this System.Drawing.Graphics g, Color color, Color shadowColor, Rectangle rectangle)
        {

            //Color color = Color.Blue;
            //Color shadow = Color.FromArgb(255, 16, 16, 16);

            for (int i = 0; i < 8; i++)
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, shadowColor)))
                {
                    g.FillRectangle(brush, rectangle.X + i * 2,
                        rectangle.Y + i, 60, 60);
                }

            using (SolidBrush brush = new SolidBrush(color))
                g.FillRectangle(brush, rectangle.X, rectangle.Y, 60, 60);

            // move to the right to use the same coordinates again for the drawn shape
            g.TranslateTransform(80, 0);

            for (int i = 0; i < 8; i++)
                using (Pen pen = new Pen(Color.FromArgb(80 - i * 10, shadowColor), 2.5f))
                {
                    g.DrawRectangle(pen, rectangle.X + i * 1.25f,
                        rectangle.Y + i, 60, 60);
                }
            using (Pen pen = new Pen(color))
                g.DrawRectangle(pen, rectangle.X, rectangle.Y, 60, 60);

        }


    }
}
