// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImagePixelate.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    /// <summary>
    /// A class collection Image Pixelate Functions
    /// </summary>
    public class ImagePixelate
    {
        /// <summary>
        /// Image Pixelate
        /// </summary>
        /// <param name="image">Set Bitmap</param>
        /// <param name="rectangle">Set rectangle</param>
        /// <param name="pixelateSize">Size of pixelation</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Pixelate(System.Drawing.Bitmap image, Rectangle rectangle, Int32 pixelateSize)
        {
            System.Drawing.Bitmap pixelated = new System.Drawing.Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(pixelated))
                graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // look at every pixel in the rectangle while making sure we're within the image bounds
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < image.Width; xx += pixelateSize)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < image.Height; yy += pixelateSize)
                {
                    Int32 offsetX = pixelateSize / 2;
                    Int32 offsetY = pixelateSize / 2;

                    // make sure that the offset is within the boundry of the image
                    while (xx + offsetX >= image.Width) offsetX--;
                    while (yy + offsetY >= image.Height) offsetY--;

                    // get the pixel color in the center of the soon to be pixelated area
                    Color pixel = pixelated.GetPixel(xx + offsetX, yy + offsetY);

                    // for each pixel in the pixelate size, set it to the center color
                    for (Int32 x = xx; x < xx + pixelateSize && x < image.Width; x++)
                    for (Int32 y = yy; y < yy + pixelateSize && y < image.Height; y++)
                        pixelated.SetPixel(x, y, pixel);
                }
            }

            return pixelated;
        }

        /// <summary>
        /// Image Pixelate
        /// </summary>
        /// <param name="image">Set Bitmap</param>
        /// <param name="blurSize">Blur size</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap Pixelate(System.Drawing.Bitmap image, Int32 blurSize)
        {
            return Pixelate(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
        }
    }
}
