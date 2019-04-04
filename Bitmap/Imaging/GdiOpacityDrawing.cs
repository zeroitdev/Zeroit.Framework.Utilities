// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GdiOpacityDrawing.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
