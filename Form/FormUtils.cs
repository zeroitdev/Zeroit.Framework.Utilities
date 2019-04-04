// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FormUtils.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// A class collection for manipulating Form components
    /// </summary>
    public static partial class FormUtils
    {

        /// <summary>
        /// Position form so that it is centered beneath a control, adjusted to that it
        /// is entirely on the screen if possible.
        /// </summary>
        /// <param name="f">Form to position.</param>
        /// <param name="c">Control under which to position the form.</param>
        public static void SetStartPositionBelowControl(this System.Windows.Forms.Form f, Control c)
        {
            // Get location so that f is on screen just below the center of c
            Point middleBottom = c.PointToScreen(new Point(c.Size.Width / 2, c.Size.Height));
            SetStartPosition(f, middleBottom);
        }

        /// <summary>
        /// Position form such that the center of the top edge is at a particular point,
        /// adjusted so that it is entirely on the screen if possible.
        /// </summary>
        /// <param name="f">Form to position.</param>
        /// <param name="p">Point at which to center the top edge of the form.</param>
        public static void SetStartPosition(this System.Windows.Forms.Form f, Point p)
        {
            Screen screen = Screen.FromPoint(p);

            int left = p.X - f.Width / 2;
            int right = left + f.Width;
            int top = p.Y;
            int bottom = p.Y + f.Height;

            // Adjust right then left, so that left edge is always on screen.
            if (right > screen.WorkingArea.Right)
            {
                left -= (right - screen.WorkingArea.Right - 1);
            }
            if (left < screen.WorkingArea.Left)
            {
                left = screen.WorkingArea.Left;
            }

            // Adjust bottom then top, so that top edge is always on screen
            if (bottom > screen.WorkingArea.Bottom)
            {
                top -= (bottom - screen.WorkingArea.Bottom - 1);
            }
            if (top < screen.WorkingArea.Top)
            {
                top = screen.WorkingArea.Top;
            }

            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(left, top);
        }


        /// <summary>
        /// Converts the range.
        /// </summary>
        /// <param name="originalStart">The original start.</param>
        /// <param name="originalEnd">The original end.</param>
        /// <param name="newStart">The new start.</param>
        /// <param name="newEnd">The new end.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        private static int ConvertRange(int originalStart, int originalEnd, int newStart, int newEnd, int value)
        {
            var scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (int)(newStart + ((value - originalStart) * scale));
        }

        
    }

}
