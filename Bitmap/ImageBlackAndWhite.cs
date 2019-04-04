// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageBlackAndWhite.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// A class for implementing black and white filter on images
    /// </summary>
    public class ImageBlackAndWhite
    {

        /// <summary>
        /// Black and White filter function
        /// </summary>
        /// <param name="image">Set bitmap</param>
        /// <param name="rectangle">Set client rectangle</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap BlackAndWhite(System.Drawing.Bitmap image, Rectangle rectangle)
        {
            System.Drawing.Bitmap blackAndWhite = new System.Drawing.Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(blackAndWhite))
                graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // for every pixel in the rectangle region
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < image.Width; xx++)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < image.Height; yy++)
                {
                    // average the red, green and blue of the pixel to get a gray value
                    Color pixel = blackAndWhite.GetPixel(xx, yy);
                    Int32 avg = (pixel.R + pixel.G + pixel.B) / 3;

                    blackAndWhite.SetPixel(xx, yy, Color.FromArgb(0, avg, avg, avg));
                }
            }

            return blackAndWhite;
        }

        // from http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale

        /// <summary>
        /// Gray Scale functionality
        /// </summary>
        /// <param name="original">Original image</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap MakeGrayscale3(System.Drawing.Bitmap original)
        {
            //create a blank bitmap the same size as original
            System.Drawing.Bitmap newBitmap = new System.Drawing.Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }


        /// <summary>
        /// Black and White filter on image
        /// </summary>
        /// <param name="image">Set image</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap BlackAndWhite(System.Drawing.Bitmap image)
        {
            return BlackAndWhite(image, new Rectangle(0, 0, image.Width, image.Height));
        }
    }
}
