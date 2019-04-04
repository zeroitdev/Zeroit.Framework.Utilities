// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MaginfierGlass.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// Class PolyEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PolyEditorDialog
    {


        /// <summary>
        /// The magnifier zoom
        /// </summary>
        int magnifierZoom = 1; // Variable for magnifierZoom value
        /// <summary>
        /// The printscreen
        /// </summary>
        private System.Drawing.Bitmap printscreen;
        /// <summary>
        /// The timer
        /// </summary>
        Timer timer = new Timer(); // Have a timer for frequent update


        /// <summary>
        /// Magnifiers the constructor.
        /// </summary>
        private void MagnifierConstructor()

        {
            
            timer.Interval = 100; // Set the interval for the timer

            timer.Tick += timer_Tick; // Hool the event to perform desire action

            timer.Start(); //Start the timer

            printscreen = new System.Drawing.Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Have a bitmap to store the image of the screen         

        }


        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)

        {

            var graphics = System.Drawing.Graphics.FromImage(printscreen as Image); // Get the image of the captured screen

            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size); // Get the copy of screen

            var position = Cursor.Position; // Get the position of cursor

            var lensbmp = new System.Drawing.Bitmap(50, 50); // Have a bitmap for lens

            var i = 0; // Variable for row count

            var j = 0; // Variable for column count

            for (int row = position.X - 25; row < position.X + 25; row++) // Indicates row number

            {

                j = 0; // Set column value '0' for new column

                for (int column = position.Y - 25; column < position.Y + 25; column++) // Indicate column number

                {

                    lensbmp.SetPixel(i, j, printscreen.GetPixel(row, column)); // Place current region pixel to lens bitmap

                    j++; // Increase row count

                }

                i++; // Increase column count

            }

            this.magnifierScreen.Image = new System.Drawing.Bitmap(lensbmp, lensbmp.Width * magnifierZoom, lensbmp.Height * magnifierZoom); // Assign lens bitmap with magnifierZoom level to the picture box

            Size = magnifierScreen.Image.Size; // Assign optimal value to the form

            Left = position.X + 20; // Place form nearer to cursor X value

            Top = position.Y + 20; // Place form nearer to cursor Y value

            TopMost = true; // Keep the form top level

            lensbmp.Dispose();
            graphics.Dispose();

        }

        // Override OnKeyDown for magnifierZoom in and magnifierZoom out actions

        /// <summary>
        /// Pics the canvas on key down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void picCanvasOnKeyDown(object sender, KeyEventArgs e)

        {
            
            if (e.KeyValue == 73) // Set "i" as the key for Zoom In.

                magnifierZoom++; // Increase magnifierZoom by 1 item greater

            else if (e.KeyValue == 79) // Set "o" as the key for Zoom Out

                magnifierZoom--; // Decrease magnifierZoom by 1 item smaller

            else if (e.KeyValue == 27) // Set "Esc" to close the magnifier

            {

                Close(); // Close the form

                Dispose(); // Dispose the form

            }

            base.OnKeyDown(e);

        }


        /// <summary>
        /// The zoom in out
        /// </summary>
        float zoomInOut = 1f;
        /// <summary>
        /// The constant zoom
        /// </summary>
        private const float constantZoom = 2f;
        /// <summary>
        /// Magnifiers the second constructor.
        /// </summary>
        private void MagnifierSecondConstructor()
        {

            timer.Interval = 50; // Set the interval for the timer

            timer.Tick += Timer1_Tick; // Hool the event to perform desire action

            timer.Start(); //Start the timer
            
        }

        /// <summary>
        /// Handles the Tick event of the Timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {

            #region Working Code
            //Bitmap bmp = new Bitmap(250, 200);
            //Graphics g = Graphics.FromImage(bmp);
            //g.CopyFromScreen(MousePosition.X - 100, MousePosition.Y - 10,
            //    0, 0, new Size(300, 300));
            ////magnifierScreen.Image = bmp; 
            #endregion

            if (zoomCheckBox.Checked)
            {

                try
                {

                    printscreen = new System.Drawing.Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Have a bitmap to store the image of the screen         

                    var graphics = System.Drawing.Graphics.FromImage(printscreen as Image); // Get the image of the captured screen

                    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);


                    var position = Cursor.Position;

                    System.Drawing.Bitmap lensbmp;

                    if (zoomInOut < constantZoom)
                    {
                        lensbmp = new System.Drawing.Bitmap(200, 200); // Have a bitmap for lens

                        var i = 0; // Variable for row count

                        var j = 0; // Variable for column count

                        for (int row = position.X - 100; row < position.X + 100; row++) // Indicates row number

                        {

                            j = 0; // Set column value '0' for new column

                            for (int column = position.Y - 100; column < position.Y + 100; column++) // Indicate column number

                            {

                                lensbmp.SetPixel(i, j, printscreen.GetPixel(row, column)); // Place current region pixel to lens bitmap

                                j++; // Increase row count

                            }

                            i++; // Increase column count

                        }

                        magnifierScreen.Image = new System.Drawing.Bitmap(lensbmp, lensbmp.Width * (int)zoomInOut, lensbmp.Height * (int)zoomInOut); // Assign lens bitmap with magnifierZoom level to the picture box

                    }

                    if (zoomInOut == constantZoom)
                    {
                        lensbmp = new System.Drawing.Bitmap(100, 100); // Have a bitmap for lens

                        var i = 0; // Variable for row count

                        var j = 0; // Variable for column count

                        for (int row = position.X - 50; row < position.X + 50; row++) // Indicates row number

                        {

                            j = 0; // Set column value '0' for new column

                            for (int column = position.Y - 50; column < position.Y + 50; column++) // Indicate column number

                            {

                                lensbmp.SetPixel(i, j, printscreen.GetPixel(row, column)); // Place current region pixel to lens bitmap

                                j++; // Increase row count

                            }

                            i++; // Increase column count

                        }

                        magnifierScreen.Image = new System.Drawing.Bitmap(lensbmp, lensbmp.Width * (int)zoomInOut, lensbmp.Height * (int)zoomInOut); // Assign lens bitmap with magnifierZoom level to the picture box

                    }



                }
                catch (Exception exception)
                {

                }
            }
            
            
        }

    }
}
