// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageTransformShear.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Image Transformation Shear
    /// </summary>
    public static class ImageTransformShear
    {
        /// <summary>
        /// Copy to canvas
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="canvasWidthLenght">Set canvas Width and Length</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap CopyToSquareCanvas(this System.Drawing.Bitmap sourceBitmap, int canvasWidthLenght)
        {
            float ratio = 1.0f;
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                          sourceBitmap.Width : sourceBitmap.Height;

            ratio = (float)maxSide / (float)canvasWidthLenght;

            System.Drawing.Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                    new System.Drawing.Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                    : new System.Drawing.Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

            using (System.Drawing.Graphics graphicsResult = System.Drawing.Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(sourceBitmap,
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }

        /// <summary>
        /// X and Y Rotate
        /// </summary>
        /// <param name="source">Set source Bitmap</param>
        /// <param name="degrees">Set degrees</param>
        /// <param name="offsetX">Set X offset</param>
        /// <param name="offsetY">Set Y offset</param>
        /// <returns></returns>
        public static Point Rotate_XY(this Point source, double degrees, 
                                              int offsetX, int offsetY)
        {
            Point result = new Point();

            result.X = (int)(Math.Round((source.X - offsetX) *
                       Math.Cos(degrees) - (source.Y - offsetY) *
                       Math.Sin(degrees))) + offsetX;

            result.Y = (int)(Math.Round((source.X - offsetX) *
                       Math.Sin(degrees) + (source.Y - offsetY) * 
                       Math.Cos(degrees))) + offsetY;

            return result;
        }

        /// <summary>
        /// X and Y Shear
        /// </summary>
        /// <param name="source">Set source Bitmap</param>
        /// <param name="shearX">Set X shear</param>
        /// <param name="shearY">Set Y shear</param>
        /// <param name="offsetX">Set X offset</param>
        /// <param name="offsetY">Set Y offset</param>
        /// <returns></returns>
        public static Point ShearXY(this Point source, double shearX,
                                                       double shearY,
                                                       int offsetX, 
                                                       int offsetY)
        {
            Point result = new Point();

            result.X = (int)(Math.Round(source.X + shearX * source.Y));
            result.X -= offsetX;

            result.Y = (int)(Math.Round(source.Y + shearY * source.X));
            result.Y -= offsetY;

            return result;
        }

        /// <summary>
        /// Shear Image
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="shearX">Set X shear</param>
        /// <param name="shearY">Set Y shear</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ShearImage(this System.Drawing.Bitmap sourceBitmap,
                                       double shearX,
                                       double shearY)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            int xOffset = (int)Math.Round(sourceBitmap.Width * 
                                                shearX / 2.0);

            int yOffset = (int)Math.Round(sourceBitmap.Height * 
                                                  shearY / 2.0);

            int sourceXY = 0;
            int resultXY = 0;

            Point sourcePoint = new Point();
            Point resultPoint = new Point();

            Rectangle imageBounds = new Rectangle(0, 0,
                                    sourceBitmap.Width,
                                   sourceBitmap.Height);

            for (int row = 0; row < sourceBitmap.Height; row++)
            {
                for (int col = 0; col < sourceBitmap.Width; col++)
                {
                    sourceXY = row * sourceData.Stride + col * 4;

                    sourcePoint.X = col;
                    sourcePoint.Y = row;

                    if (sourceXY >= 0 && 
                        sourceXY + 3 < pixelBuffer.Length)
                    {
                        resultPoint = sourcePoint.ShearXY(shearX, 
                                        shearY, xOffset, yOffset);

                        resultXY = resultPoint.Y * sourceData.Stride +
                                   resultPoint.X * 4;

                        if (imageBounds.Contains(resultPoint) &&
                                              resultXY >= 0)
                        {
                            if (resultXY + 6 <= resultBuffer.Length)
                            {
                                resultBuffer[resultXY + 4] =
                                     pixelBuffer[sourceXY];

                                resultBuffer[resultXY + 5] =
                                     pixelBuffer[sourceXY + 1];

                                resultBuffer[resultXY + 6] =
                                     pixelBuffer[sourceXY + 2];

                                resultBuffer[resultXY + 7] = 255;
                            }

                            if (resultXY - 3 >= 0)
                            {
                                resultBuffer[resultXY - 4] =
                                     pixelBuffer[sourceXY];

                                resultBuffer[resultXY - 3] =
                                     pixelBuffer[sourceXY + 1];

                                resultBuffer[resultXY - 2] =
                                     pixelBuffer[sourceXY + 2];

                                resultBuffer[resultXY - 1] = 255;
                            }

                            if (resultXY + 3 < resultBuffer.Length)
                            {
                                resultBuffer[resultXY] =
                                 pixelBuffer[sourceXY];

                                resultBuffer[resultXY + 1] =
                                 pixelBuffer[sourceXY + 1];

                                resultBuffer[resultXY + 2] =
                                 pixelBuffer[sourceXY + 2];

                                resultBuffer[resultXY + 3] = 255;
                            }
                        }
                    }
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Rotate Image
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="degreesBlue">Set blue degrees</param>
        /// <param name="degreesGreen">Set green degrees</param>
        /// <param name="degreesRed">Set red degrees</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap RotateImage(this System.Drawing.Bitmap sourceBitmap, 
                                               double degreesBlue,
                                              double degreesGreen,
                                                double degreesRed)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            //Convert to Radians
            degreesBlue = degreesBlue * Math.PI / 180.0;
            degreesGreen = degreesGreen * Math.PI / 180.0;
            degreesRed = degreesRed * Math.PI / 180.0;

            //Calculate Offset in order to rotate on image middle
            int xOffset = (int)(sourceBitmap.Width / 2.0);
            int yOffset = (int)(sourceBitmap.Height / 2.0);

            int sourceXY = 0;
            int resultXY = 0;

            Point sourcePoint = new Point();
            Point resultPoint = new Point();

            Rectangle imageBounds = new Rectangle(0, 0, 
                                    sourceBitmap.Width, 
                                   sourceBitmap.Height);

            for (int row = 0; row < sourceBitmap.Height; row++)
            {
                for (int col = 0; col < sourceBitmap.Width; col++)
                {
                    sourceXY = row * sourceData.Stride + col * 4;

                    sourcePoint.X = col;
                    sourcePoint.Y = row;

                    if (sourceXY >= 0 && sourceXY + 3 < pixelBuffer.Length)
                    {
                        //Calculate Blue Rotation
                
                        resultPoint = sourcePoint.Rotate_XY(degreesBlue, 
                                                     xOffset, yOffset);

                        resultXY = (int)(Math.Round(
                              (resultPoint.Y * sourceData.Stride) + 
                              (resultPoint.X * 4.0)));

                        if (imageBounds.Contains(resultPoint) && 
                                              resultXY >= 0)
                        {
                            if (resultXY + 6 < resultBuffer.Length)
                            {
                                resultBuffer[resultXY + 4] = 
                                     pixelBuffer[sourceXY];

                                resultBuffer[resultXY + 7] = 255;
                            }

                            if (resultXY + 3 < resultBuffer.Length)
                            {
                                resultBuffer[resultXY] = 
                                 pixelBuffer[sourceXY];

                                resultBuffer[resultXY + 3] = 255;
                            }
                        }

                        //Calculate Green Rotation

                        resultPoint = sourcePoint.Rotate_XY(degreesGreen,
                                                     xOffset, yOffset);

                        resultXY = (int)(Math.Round(
                              (resultPoint.Y * sourceData.Stride) +
                              (resultPoint.X * 4.0)));

                        if (imageBounds.Contains(resultPoint) && resultXY >= 0)
                        {
                            if (resultXY + 6 < resultBuffer.Length)
                            {
                                resultBuffer[resultXY + 5] = 
                                 pixelBuffer[sourceXY + 1];

                                resultBuffer[resultXY + 7] = 255;
                            }

                            if (resultXY + 3 < resultBuffer.Length)
                            {
                                resultBuffer[resultXY + 1] = 
                                 pixelBuffer[sourceXY + 1];

                                resultBuffer[resultXY + 3] = 255;
                            }
                        }

                        //Calculate Red Rotation

                        resultPoint = sourcePoint.Rotate_XY(degreesRed,
                                                     xOffset, yOffset);

                        resultXY = (int)(Math.Round(
                              (resultPoint.Y * sourceData.Stride) +
                              (resultPoint.X * 4.0)));

                        if (imageBounds.Contains(resultPoint) && resultXY >= 0)
                        {
                            if (resultXY + 6 < resultBuffer.Length)
                            {
                                resultBuffer[resultXY + 6] = 
                                 pixelBuffer[sourceXY + 2];

                                resultBuffer[resultXY + 7] = 255;
                            }

                            if (resultXY + 3 < resultBuffer.Length)
                            {
                                resultBuffer[resultXY + 2] = 
                                 pixelBuffer[sourceXY + 2];

                                resultBuffer[resultXY + 3] = 255;
                            }
                        }
                    }
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
    }  
}
