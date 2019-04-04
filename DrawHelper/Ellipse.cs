// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Ellipse.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// A class collection for Ellipse manipulation
    /// </summary>
    public static class Ellipse
    {
        /// <summary>
        /// Apply to Form
        /// </summary>
        /// <param name="Form">Set form</param>
        /// <param name="_Elipse">Set ellipse value</param>
        public static void ApplyEllipseToForm(this System.Windows.Forms.Form Form, int _Elipse)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                Form.FormBorderStyle = FormBorderStyle.None;
                Form.Region = Region.FromHrgn(Ellipse.CreateRoundRectRgn(0, 0, Form.Width, Form.Height, _Elipse, _Elipse));
            }
            catch (Exception exception)
            {
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        /// <summary>
        /// Apply Ellipse to control
        /// </summary>
        /// <param name="ctrl">Set control</param>
        /// <param name="Elipse">Set ellipse value</param>
        public static void ApplyEllipseToControl(this Control ctrl, int Elipse)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, Elipse, Elipse));
            }
            catch (Exception exception)
            {
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        /// <summary>
        /// Creates the round rect RGN.
        /// </summary>
        /// <param name="nLeftRect">The n left rect.</param>
        /// <param name="nTopRect">The n top rect.</param>
        /// <param name="nRightRect">The n right rect.</param>
        /// <param name="nBottomRect">The n bottom rect.</param>
        /// <param name="nWidthEllipse">The n width ellipse.</param>
        /// <param name="nHeightEllipse">The n height ellipse.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("Gdi32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
