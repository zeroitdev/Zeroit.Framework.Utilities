// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Mirror.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// A class collection of Mirror Functionalities
    /// </summary>
    public static class Mirror
    {

        /// <summary>
        /// Draw Mode. Either Solid, Gradient or Hatch patterns
        /// </summary>

        public enum drawMode
        {
            Solid,
            Gradient,
            Hatch
        }

        /// <summary>
        /// Draw Reflection
        /// </summary>
        /// <param name="img">Set Image</param>
        /// <param name="toBG">Set Color of Background</param>
        /// <param name="RotateFlipType">Rotation Type. Default value is Rotate180FlipX</param>
        /// <param name="LinearGradientMode">Gradient Mode. Default value is Vertical</param>
        /// <param name="Length">Length of the Mirror. Default value is 100</param>
        /// <returns></returns>
        public static Image DrawReflection(Image img, Color toBG, 
            RotateFlipType RotateFlipType = RotateFlipType.Rotate180FlipX, 
            LinearGradientMode LinearGradientMode = LinearGradientMode.Vertical,
            int Length = 100) // img is the original image.
        {
            //This is the static function that generates the reflection...
            int height = img.Height + Length; //Added height from the original height of the image.
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, height, PixelFormat.Format64bppPArgb); //A new bitmap.
            Brush brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), Color.Transparent, toBG, LinearGradientMode);//The Brush that generates the fading effect to a specific color of your background.
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution); //Sets the new bitmap's resolution.
            using (System.Drawing.Graphics grfx = System.Drawing.Graphics.FromImage(bmp)) //A graphics to be generated from an image (here, the new Bitmap we've created (bmp)).
            {
                System.Drawing.Bitmap bm = (System.Drawing.Bitmap)img; //Generates a bitmap from the original image (img).
                grfx.DrawImage(bm, 0, 0, img.Width, img.Height); //Draws the generated bitmap (bm) to the new bitmap (bmp).
                System.Drawing.Bitmap bm1 = (System.Drawing.Bitmap)img; //Generates a bitmap again from the original image (img).
                bm1.RotateFlip(RotateFlipType); //Flips and rotates the image (bm1).
                grfx.DrawImage(bm1, 0, img.Height); //Draws (bm1) below (bm) so it serves as the reflection image.
                Rectangle rt = new Rectangle(0, img.Height, img.Width, Length); //A new rectangle to paint our gradient effect.
                grfx.FillRectangle(brsh, rt); //Brushes the gradient on (rt).
            }

            return bmp; //Returns the (bmp) with the generated image.
        }

        /// <summary>
        /// Draw Reflection
        /// </summary>
        /// <param name="img">Set Image</param>
        /// <param name="toBG">Set Color of Background</param>
        /// <param name="toBG1">Set Color of Background</param>
        /// <param name="drawMode">Set the Draw Mode. Default value is Solid</param>
        /// <param name="RotateFlipType">Set Rotation. Default value is Rotate180FlipX</param>
        /// <param name="LinearGradientMode">Set Gradient Mode. Default value is Vertical</param>
        /// <param name="Length">Set the length. Default value is 100</param>
        /// <returns></returns>
        public static Image DrawReflection(Image img, Color toBG, 
            Color toBG1, drawMode drawMode = drawMode.Solid,
            RotateFlipType RotateFlipType = RotateFlipType.Rotate180FlipX,
            LinearGradientMode LinearGradientMode = LinearGradientMode.Vertical,
            int Length = 100) // img is the original image.
        {
            //This is the static function that generates the reflection...
            int height = img.Height + Length; //Added height from the original height of the image.
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, height, PixelFormat.Format64bppPArgb); //A new bitmap.


            Brush brsh = null;//The Brush that generates the fading effect to a specific color of your background.

            switch (drawMode)
            {
                case drawMode.Solid:
                    brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), Color.Transparent, toBG, LinearGradientMode);//The Brush that generates the fading effect to a specific color of your background.
                    break;
                case drawMode.Gradient:
                    brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), Color.Transparent, toBG, LinearGradientMode);//The Brush that generates the fading effect to a specific color of your background.
                    break;
                case drawMode.Hatch:
                    brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), toBG1, toBG, LinearGradientMode);//The Brush that generates the fading effect to a specific color of your background.
                    break;
                default:
                    break;
            }

            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution); //Sets the new bitmap's resolution.
            using (System.Drawing.Graphics grfx = System.Drawing.Graphics.FromImage(bmp)) //A graphics to be generated from an image (here, the new Bitmap we've created (bmp)).
            {
                System.Drawing.Bitmap bm = (System.Drawing.Bitmap)img; //Generates a bitmap from the original image (img).
                grfx.DrawImage(bm, 0, 0, img.Width, img.Height); //Draws the generated bitmap (bm) to the new bitmap (bmp).
                System.Drawing.Bitmap bm1 = (System.Drawing.Bitmap)img; //Generates a bitmap again from the original image (img).
                bm1.RotateFlip(RotateFlipType); //Flips and rotates the image (bm1).
                grfx.DrawImage(bm1, 0, img.Height); //Draws (bm1) below (bm) so it serves as the reflection image.
                Rectangle rt = new Rectangle(0, img.Height, img.Width, Length); //A new rectangle to paint our gradient effect.
                grfx.FillRectangle(brsh, rt); //Brushes the gradient on (rt).
            }

            return bmp; //Returns the (bmp) with the generated image.
        }

        /// <summary>
        /// Creates an Image with a Glass Table effect
        /// </summary>
        /// <param name="_Image">Original image</param>
        /// <param name="_BackgroundColor">New image background color</param>
        /// <param name="_Reflectivity">Reflectivity (0 to 255)</param>
        public static Image DrawReflection(Image Image, Color BackColor, int Reflectivity)
        {
            if (Reflectivity > 255)
            {
                Reflectivity = 255;
            }

            // Calculate the size of the new image
            int height = (int)(Image.Height + (Image.Height * ((float)Reflectivity / 255)));
            System.Drawing.Bitmap newImage = new System.Drawing.Bitmap(Image.Width, height, PixelFormat.Format24bppRgb);
            newImage.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);

            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(newImage))
            {
                // Initialize main graphics buffer
                graphics.Clear(BackColor);
                graphics.DrawImage(Image, new Point(0, 0));
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Rectangle destinationRectangle = new Rectangle(0, Image.Size.Height, Image.Size.Width, Image.Size.Height);

                // Prepare the reflected image
                int reflectionHeight = (Image.Height * Reflectivity) / 255;
                Image reflectedImage = new System.Drawing.Bitmap(Image.Width, reflectionHeight);

                // Draw just the reflection on a second graphics buffer
                using (System.Drawing.Graphics gReflection = System.Drawing.Graphics.FromImage(reflectedImage))
                {
                    gReflection.DrawImage(Image, new Rectangle(0, 0, reflectedImage.Width, reflectedImage.Height),
                    0, Image.Height - reflectedImage.Height, reflectedImage.Width, reflectedImage.Height, GraphicsUnit.Pixel);
                }
                reflectedImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle imageRectangle = new Rectangle(destinationRectangle.X, destinationRectangle.Y,
                    destinationRectangle.Width, (destinationRectangle.Height * Reflectivity) / 255);

                // Draw the image on the original graphics
                graphics.DrawImage(reflectedImage, imageRectangle);

                // Finish the reflection using a gradiend brush
                LinearGradientBrush brush = new LinearGradientBrush(imageRectangle,
                       Color.FromArgb(255 - Reflectivity, BackColor),
                    BackColor, 90, false);
                graphics.FillRectangle(brush, imageRectangle);
            }

            return newImage;
        }


        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="Rectangle">Set Rectangle</param>
        /// <param name="Curve">Set Curve</param>
        /// <param name="UpperLeftCurve">Set Upper Left Curve</param>
        /// <param name="UpperRightCurve">Set Upper Right Curve</param>
        /// <param name="DownLeftCurve">Set Down Left Curve</param>
        /// <param name="DownRightCurve">Set Down Right Curve</param>
        /// <returns></returns>
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve, int UpperLeftCurve, int UpperRightCurve, int DownLeftCurve, int DownRightCurve)
        {
            //Curve = curve;
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;

            int UpperLeftCorner = UpperLeftCurve * 2;
            int UpperRightCorner = UpperRightCurve * 2;
            int DownLeftCorner = DownLeftCurve * 2;
            int DownRightCorner = DownRightCurve * 2;

            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, UpperLeftCorner, UpperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - UpperRightCorner + Rectangle.X, Rectangle.Y, UpperRightCorner, UpperRightCorner), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - DownRightCorner + Rectangle.X, Rectangle.Height - DownRightCorner + Rectangle.Y, DownRightCorner, DownRightCorner), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - DownLeftCorner + Rectangle.Y, DownLeftCorner, DownLeftCorner), 90, 90);
            P.CloseAllFigures();
            return P;
        }

        #region Working rounding Reflection

        

        #endregion

    }
}
