// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageAbstractColorFilter.cs" company="Zeroit Dev Technologies">
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
    /// A class collection of Image color filters
    /// </summary>
    public static class ImageAbstractColourFilter
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
        /// Get Byte Array
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <returns></returns>
        public static byte[] GETByteArray(this System.Drawing.Bitmap sourceBitmap)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] sourceBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0,
                                       sourceBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            return sourceBuffer;
        }

        /// <summary>
        /// Color Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set matrix size</param>
        /// <param name="edgeThreshold">Set edge threshold</param>
        /// <param name="applyBlue">Apply Blue</param>
        /// <param name="applyGreen">Apply Green</param>
        /// <param name="applyRed">Apply Red</param>
        /// <param name="edgeType">Set edge type</param>
        /// <param name="shiftType">Set shift type</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap AbstractColorsFilter(this System.Drawing.Bitmap sourceBitmap,
                                                  int matrixSize,
                                                  byte edgeThreshold,
                                                  bool applyBlue = true,
                                                  bool applyGreen = true,
                                                  bool applyRed = true,
                                                  EdgeTracingType edgeType = 
                                                  EdgeTracingType.Black,
                                                  ColorShiftType shiftType =
                                                  ColorShiftType.None)
        {
            System.Drawing.Bitmap edgeBitmap = 
            sourceBitmap.GradientBasedEdgeDetectionFilter(edgeThreshold);

            System.Drawing.Bitmap colorBitmap = 
            sourceBitmap.AverageColoursFilter(matrixSize, 
                         applyBlue, applyGreen, applyRed, shiftType);

            byte[] edgeBuffer = edgeBitmap.GETByteArray();
            byte[] colorBuffer = colorBitmap.GETByteArray();
            byte[] resultBuffer = colorBitmap.GETByteArray();

            for (int k = 0; k + 4 < edgeBuffer.Length; k += 4)
            {
                if (edgeBuffer[k] == 255)
                {
                    switch (edgeType)
                    {
                        case EdgeTracingType.Black:
                            resultBuffer[k] = 0;
                            resultBuffer[k+1] = 0;
                            resultBuffer[k+2] = 0;
                            break;
                        case EdgeTracingType.White:
                            resultBuffer[k] = 255;
                            resultBuffer[k+1] = 255;
                            resultBuffer[k+2] = 255;
                            break;
                        case EdgeTracingType.HalfIntensity:
                            resultBuffer[k] = ClipByte(resultBuffer[k] * 0.5);
                            resultBuffer[k + 1] = ClipByte(resultBuffer[k + 1] * 0.5);
                            resultBuffer[k + 2] = ClipByte(resultBuffer[k + 2] * 0.5);
                            break;
                        case EdgeTracingType.DoubleIntensity:
                            resultBuffer[k] = ClipByte(resultBuffer[k] * 2);
                            resultBuffer[k + 1] = ClipByte(resultBuffer[k + 1] * 2);
                            resultBuffer[k + 2] = ClipByte(resultBuffer[k + 2] * 2);
                            break;
                        case EdgeTracingType.ColorInversion:
                            resultBuffer[k] = ClipByte(255 - resultBuffer[k]);
                            resultBuffer[k+1] = ClipByte(255 - resultBuffer[k+1]);
                            resultBuffer[k+2] = ClipByte(255 - resultBuffer[k+2]);
                            break;
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
        /// Average Color Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set matrix size</param>
        /// <param name="applyBlue">Apply Blue</param>
        /// <param name="applyGreen">Apply Green</param>
        /// <param name="applyRed">Apply Red</param>
        /// <param name="shiftType">Set shift type</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap AverageColoursFilter(this System.Drawing.Bitmap sourceBitmap, 
                                                  int matrixSize,  
                                                  bool applyBlue = true,
                                                  bool applyGreen = true,
                                                  bool applyRed = true,
                                                  ColorShiftType shiftType =
                                                  ColorShiftType.None) 
        {
            byte[] pixelBuffer = sourceBitmap.GETByteArray();
            byte[] resultBuffer = new byte[pixelBuffer.Length];

            int calcOffset = 0;
            int byteOffset = 0;
            int blue = 0; int green = 0; int red = 0;
            int filterOffset = (matrixSize - 1) / 2;

            for (int offsetY = filterOffset; offsetY < 
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < 
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY * sourceBitmap.Width*4 + 
                                 offsetX * 4;

                    blue = 0; green = 0; red = 0;

                    for (int filterY = -filterOffset; 
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + 
                            (filterX * 4) +
                            (filterY * sourceBitmap.Width * 4);

                            blue += pixelBuffer[calcOffset];
                            green += pixelBuffer[calcOffset + 1];
                            red += pixelBuffer[calcOffset + 2];
                        }
                    }

                    blue = blue / matrixSize;
                    green = green / matrixSize;
                    red = red / matrixSize;

                    if (applyBlue == false)
                    { blue = pixelBuffer[byteOffset]; }

                    if (applyGreen == false)
                    { green = pixelBuffer[byteOffset + 1]; }

                    if (applyRed == false)
                    { red = pixelBuffer[byteOffset + 2]; }

                    if (shiftType == ColorShiftType.None)
                    {
                        resultBuffer[byteOffset] = (byte)blue;
                        resultBuffer[byteOffset + 1] = (byte)green;
                        resultBuffer[byteOffset + 2] = (byte)red;
                        resultBuffer[byteOffset + 3] = 255;
                    }
                    else if (shiftType == ColorShiftType.ShiftLeft)
                    {
                        resultBuffer[byteOffset] = (byte)green;
                        resultBuffer[byteOffset + 1] = (byte)red;
                        resultBuffer[byteOffset + 2] = (byte)blue;
                        resultBuffer[byteOffset + 3] = 255;
                    }
                    else if (shiftType == ColorShiftType.ShiftRight)
                    {
                        resultBuffer[byteOffset] = (byte)red;
                        resultBuffer[byteOffset + 1] = (byte)blue;
                        resultBuffer[byteOffset + 2] = (byte)green;
                        resultBuffer[byteOffset + 3] = 255;
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
        /// Gradient Based Edge Detection Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="threshold">Set threshold</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GradientBasedEdgeDetectionFilter(
                                this System.Drawing.Bitmap sourceBitmap,
                                byte threshold = 0)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            int sourceOffset = 0, gradientValue = 0;
            bool exceedsThreshold = false;

            for (int offsetY = 1; offsetY < 
                                  sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX < 
                                      sourceBitmap.Width - 1; offsetX++)
                {
                    sourceOffset = offsetY * sourceData.Stride +
                                   offsetX * 4;
                    gradientValue = 0;
                    exceedsThreshold = true;

                    // Horizontal Gradient
                    CheckThreshold(pixelBuffer,
                                   sourceOffset - 4,
                                   sourceOffset + 4,
                                   ref gradientValue, threshold, 2);
                    // Vertical Gradient
                    exceedsThreshold =
                    CheckThreshold(pixelBuffer,
                                   sourceOffset - sourceData.Stride,
                                   sourceOffset + sourceData.Stride,
                                   ref gradientValue, threshold, 2);

                    if (exceedsThreshold == false)
                    {
                        gradientValue = 0;

                        // Horizontal Gradient
                        exceedsThreshold =
                        CheckThreshold(pixelBuffer,
                                       sourceOffset - 4,
                                       sourceOffset + 4,
                                       ref gradientValue, threshold);

                        if (exceedsThreshold == false)
                        {
                            gradientValue = 0;

                            // Vertical Gradient
                            exceedsThreshold =
                            CheckThreshold(pixelBuffer,
                                           sourceOffset - sourceData.Stride,
                                           sourceOffset + sourceData.Stride,
                                           ref gradientValue, threshold);

                            if (exceedsThreshold == false)
                            {
                                gradientValue = 0;

                                // Diagonal Gradient : NW-SE
                                CheckThreshold(pixelBuffer,
                                               sourceOffset - 4 - sourceData.Stride,
                                               sourceOffset + 4 + sourceData.Stride,
                                               ref gradientValue, threshold, 2);
                                // Diagonal Gradient : NE-SW
                                exceedsThreshold =
                                CheckThreshold(pixelBuffer,
                                               sourceOffset - sourceData.Stride + 4,
                                               sourceOffset - 4 + sourceData.Stride,
                                               ref gradientValue, threshold, 2);

                                if (exceedsThreshold == false)
                                {
                                    gradientValue = 0;

                                    // Diagonal Gradient : NW-SE
                                    exceedsThreshold =
                                    CheckThreshold(pixelBuffer,
                                                   sourceOffset - 4 - sourceData.Stride,
                                                   sourceOffset + 4 + sourceData.Stride,
                                                   ref gradientValue, threshold);

                                    if (exceedsThreshold == false)
                                    {
                                        gradientValue = 0;

                                        // Diagonal Gradient : NE-SW
                                        exceedsThreshold =
                                        CheckThreshold(pixelBuffer,
                                                       sourceOffset - sourceData.Stride + 4,
                                                       sourceOffset + sourceData.Stride - 4,
                                                       ref gradientValue, threshold);
                                    }
                                }
                            }
                        }
                    }

                    resultBuffer[sourceOffset] = (byte)(exceedsThreshold ? 255 : 0);
                    resultBuffer[sourceOffset + 1] = resultBuffer[sourceOffset];
                    resultBuffer[sourceOffset + 2] = resultBuffer[sourceOffset];
                    resultBuffer[sourceOffset + 3] = 255;
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Check Threshold
        /// </summary>
        /// <param name="pixelBuffer">Pixel Buffer</param>
        /// <param name="offset1">Offset 1 value</param>
        /// <param name="offset2">Offset 2 value</param>
        /// <param name="gradientValue">Gradient value</param>
        /// <param name="threshold">Threshold value</param>
        /// <param name="divideBy">Divide by</param>
        /// <returns></returns>
        public static bool CheckThreshold(byte[] pixelBuffer,
                                           int offset1, int offset2,
                                           ref int gradientValue,
                                           byte threshold,
                                           int divideBy = 1)
        {
            gradientValue +=
            Math.Abs(pixelBuffer[offset1] -
            pixelBuffer[offset2]) / divideBy;

            gradientValue +=
            Math.Abs(pixelBuffer[offset1 + 1] -
            pixelBuffer[offset2 + 1]) / divideBy;

            gradientValue +=
            Math.Abs(pixelBuffer[offset1 + 2] -
            pixelBuffer[offset2 + 2]) / divideBy;

            return (gradientValue >= threshold);
        }

        private static byte ClipByte(double colour)
        {
            return (byte)(colour > 255 ? 255 :
                   (colour < 0 ? 0 : colour));
        }

        /// <summary>
        /// Color Shift Type
        /// </summary>
        public enum ColorShiftType
        {
            None,
            ShiftLeft,
            ShiftRight
        }

        /// <summary>
        /// Edge Tracing Type
        /// </summary>
        public enum EdgeTracingType
        {
            Black,
            White,
            HalfIntensity,
            DoubleIntensity,
            ColorInversion
        }
    }  
}
