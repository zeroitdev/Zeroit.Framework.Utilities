// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GradientBasedEdgeDetection.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class for Gradient Based Edge Detection
    /// </summary>
    public static class GradientBasedEdgeDetection
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
        /// Gradient Based Edge Detection Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="filterType">Set Filter Type</param>
        /// <param name="derivativeLevel">Set Derivative level</param>
        /// <param name="redFactor">Set red factor</param>
        /// <param name="greenFactor">Set green factor</param>
        /// <param name="blueFactor">Set blue factor</param>
        /// <param name="threshold">Set threshold</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GradientBasedEdgeDetectionFilter(
                                        this System.Drawing.Bitmap sourceBitmap,
                                        EdgeFilterType filterType,
                                        DerivativeLevel derivativeLevel, 
                                        float redFactor = 1.0f,
                                        float greenFactor = 1.0f,
                                        float blueFactor = 1.0f,
                                        byte threshold = 0)
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

            int derivative = (int)derivativeLevel;
            int byteOffset = 0;
            int blueGradient, greenGradient, redGradient = 0;
            double blue = 0, green = 0, red = 0;

            bool exceedsThreshold = false;

            for (int offsetY = 1; offsetY < sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX <
                    sourceBitmap.Width - 1; offsetX++)
                {
                    byteOffset = offsetY * sourceData.Stride +
                                 offsetX * 4;

                    blueGradient = 
                    Math.Abs(pixelBuffer[byteOffset - 4] -
                    pixelBuffer[byteOffset + 4]) / derivative;

                    blueGradient += 
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] - 
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;
                    
                    byteOffset++;

                    greenGradient = 
                    Math.Abs(pixelBuffer[byteOffset - 4] - 
                    pixelBuffer[byteOffset + 4]) / derivative;

                    greenGradient += 
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] - 
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;

                    byteOffset++;

                    redGradient = 
                    Math.Abs(pixelBuffer[byteOffset - 4] - 
                    pixelBuffer[byteOffset + 4]) / derivative;

                    redGradient += 
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] - 
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;
                    
                    if (blueGradient + greenGradient + redGradient > threshold)
                    { exceedsThreshold = true; }
                    else
                    {
                        byteOffset -= 2;

                        blueGradient = Math.Abs(pixelBuffer[byteOffset - 4] - 
                                                pixelBuffer[byteOffset + 4]);
                        byteOffset++;

                        greenGradient = Math.Abs(pixelBuffer[byteOffset - 4] - 
                                                 pixelBuffer[byteOffset + 4]);
                        byteOffset++;

                        redGradient = Math.Abs(pixelBuffer[byteOffset - 4] - 
                                               pixelBuffer[byteOffset + 4]);

                        if (blueGradient + greenGradient + redGradient > threshold)
                        { exceedsThreshold = true; }
                        else
                        {
                            byteOffset -= 2;

                            blueGradient = 
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] - 
                            pixelBuffer[byteOffset + sourceData.Stride]);

                            byteOffset++;

                            greenGradient = 
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] - 
                            pixelBuffer[byteOffset + sourceData.Stride]);

                            byteOffset++;

                            redGradient = 
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] - 
                            pixelBuffer[byteOffset + sourceData.Stride]);

                            if (blueGradient + greenGradient + 
                                      redGradient > threshold)
                            { exceedsThreshold = true; }
                            else
                            {
                                byteOffset -= 2;

                                blueGradient = 
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] - 
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;

                                blueGradient += 
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] - 
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;

                                byteOffset++;

                                greenGradient = 
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] - 
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;

                                greenGradient += 
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] - 
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;

                                byteOffset++;

                                redGradient = 
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] - 
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;

                                redGradient +=
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] - 
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;

                                if (blueGradient + greenGradient + redGradient > threshold)
                                { exceedsThreshold = true; }
                                else
                                { exceedsThreshold = false; }
                            }
                        }
                    }

                    byteOffset -= 2;

                    if (exceedsThreshold)
                    {
                        if (filterType == EdgeFilterType.EdgeDetectMono)
                        {
                            blue = green = red = 255;
                        }
                        else if (filterType == EdgeFilterType.EdgeDetectGradient)
                        {
                            blue = blueGradient * blueFactor;
                            green = greenGradient * greenFactor;
                            red = redGradient * redFactor;
                        }
                        else if (filterType == EdgeFilterType.Sharpen)
                        {
                            blue = pixelBuffer[byteOffset] * blueFactor;
                            green = pixelBuffer[byteOffset + 1] * greenFactor;
                            red = pixelBuffer[byteOffset + 2] * redFactor;
                        }
                        else if (filterType == EdgeFilterType.SharpenGradient)
                        {
                            blue = pixelBuffer[byteOffset] + blueGradient * blueFactor;
                            green = pixelBuffer[byteOffset + 1] + greenGradient * greenFactor;
                            red = pixelBuffer[byteOffset + 2] + redGradient * redFactor;
                        }
                    }
                    else
                    {
                        if (filterType == EdgeFilterType.EdgeDetectMono || 
                            filterType == EdgeFilterType.EdgeDetectGradient)
                        {
                            blue = green = red = 0;
                        }
                        else if (filterType == EdgeFilterType.Sharpen || 
                                 filterType == EdgeFilterType.SharpenGradient)
                        {
                            blue = pixelBuffer[byteOffset];
                            green = pixelBuffer[byteOffset + 1];
                            red = pixelBuffer[byteOffset + 2];
                        }
                    }

                    blue = (blue > 255 ? 255 :
                           (blue < 0 ? 0 :
                            blue));

                    green = (green > 255 ? 255 :
                            (green < 0 ? 0 :
                             green));

                    red = (red > 255 ? 255 :
                          (red < 0 ? 0 :
                           red)); 

                    resultBuffer[byteOffset] = (byte)blue;
                    resultBuffer[byteOffset + 1] = (byte)green;
                    resultBuffer[byteOffset + 2] = (byte)red;
                    resultBuffer[byteOffset + 3] = 255;  
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
        /// Edge Filter Type
        /// </summary>
        public enum EdgeFilterType
        {
            None,
            EdgeDetectMono,
            EdgeDetectGradient,
            Sharpen,
            SharpenGradient,
        }

        /// <summary>
        /// Derivative Level
        /// </summary>
        public enum DerivativeLevel
        {
            First = 1,
            Second = 2
        }
    }  
}
