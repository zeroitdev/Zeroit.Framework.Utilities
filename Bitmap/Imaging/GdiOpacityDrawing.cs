// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GdiOpacityDrawing.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/

using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class of Form Opacity Drawing
    /// </summary>
    public class GdiOpacityDrawing
    {
        //private byte foreColorAlphaValue = 100;
        //private string textToDisplay = "http://softwarebydefault.com";
        
        /// <summary>
        /// Form Paint
        /// </summary>
        /// <param name="e">Paint event arguments</param>
        /// <param name="form">Set Form</param>
        /// <param name="foreColorAlphaValue">Set forecolor alpha value</param>
        /// <param name="textToDisplay">Set text to display</param>
        public static void MainFormPaint(PaintEventArgs e, Form form, byte foreColorAlphaValue, string textToDisplay)
        {
            Color alphaForeColor = Color.FromArgb(foreColorAlphaValue, form.ForeColor);
            Pen rectanglePen = new Pen(alphaForeColor, 2.0f);
            SolidBrush textBrush = new SolidBrush(alphaForeColor);

            float x = form.ClientRectangle.Width / 2.0f;
            x -= e.Graphics.MeasureString(textToDisplay, form.Font).Width / 2.0f;

            float y = form.ClientRectangle.Height / 2.0f;
            y -= e.Graphics.MeasureString(textToDisplay, form.Font).Height / 2.0f;

            e.Graphics.DrawString(textToDisplay, form.Font, textBrush, new PointF(x, y));

            e.Graphics.DrawRectangle(rectanglePen, 25, 25,
                form.ClientRectangle.Width - 50, form.ClientRectangle.Height - 50);
        }
    }
}
