// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageBlurFilters.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Image Blur
    /// </summary>
    public static class ImageBlurFilters
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
        /// Image Blur Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="blurType">Set blur Type</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ImageBlurFilter(this System.Drawing.Bitmap sourceBitmap, 
                                                    BlurType blurType)
        {
            System.Drawing.Bitmap resultBitmap = null;
    
            switch (blurType)
            {
                case BlurType.Mean3x3:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                                       Matrix.Mean3x3, 1.0 / 9.0, 0);
                    }break;
                case BlurType.Mean5x5:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                                       Matrix.Mean5x5, 1.0 / 25.0, 0);
                    }break;
                case BlurType.Mean7x7:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                                       Matrix.Mean7x7, 1.0 / 49.0, 0);
                    }break;
                case BlurType.Mean9x9:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                                       Matrix.Mean9x9, 1.0 / 81.0, 0);
                    }break;
                case BlurType.GaussianBlur3x3:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                                Matrix.GaussianBlur3x3, 1.0 / 16.0, 0);
                    }break;
                case BlurType.GaussianBlur5x5:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                               Matrix.GaussianBlur5x5, 1.0 / 159.0, 0);
                    }break;
                case BlurType.MotionBlur5x5:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                                   Matrix.MotionBlur5x5, 1.0 / 10.0, 0);
                    }break;
                case BlurType.MotionBlur5x5At45Degrees:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur5x5At45Degrees, 1.0 / 5.0, 0);
                    }break;
                case BlurType.MotionBlur5x5At135Degrees:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur5x5At135Degrees, 1.0 / 5.0, 0);
                    }break;
                case BlurType.MotionBlur7x7:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur7x7, 1.0 / 14.0, 0);
                    }break;
                case BlurType.MotionBlur7x7At45Degrees:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur7x7At45Degrees, 1.0 / 7.0, 0);
                    }break;
                case BlurType.MotionBlur7x7At135Degrees:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur7x7At135Degrees, 1.0 / 7.0, 0);
                    }break;
                case BlurType.MotionBlur9x9:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur9x9, 1.0 / 18.0, 0);
                    }break;
                case BlurType.MotionBlur9x9At45Degrees:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur9x9At45Degrees, 1.0 / 9.0, 0);
                    }break;
                case BlurType.MotionBlur9x9At135Degrees:
                    {
                        resultBitmap = sourceBitmap.ConvolutionFiltter(
                        Matrix.MotionBlur9x9At135Degrees, 1.0 / 9.0, 0);
                    }break;
                case BlurType.Median3x3:
                    {
                        resultBitmap = sourceBitmap.MedianFilter(3);
                    }break;
                case BlurType.Median5x5:
                    {
                        resultBitmap = sourceBitmap.MedianFilter(5);
                    }break;
                case BlurType.Median7x7:
                    {
                        resultBitmap = sourceBitmap.MedianFilter(7);
                    }break;
                case BlurType.Median9x9:
                    {
                        resultBitmap = sourceBitmap.MedianFilter(9);
                    }break;
                case BlurType.Median11x11:
                    {
                        resultBitmap = sourceBitmap.MedianFilter(11);
                    }break;
            }

            return resultBitmap;
        }

        /// <summary>
        /// Convolution Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="filterMatrix">Set Filter Matrix</param>
        /// <param name="factor">Set Factor</param>
        /// <param name="bias">Set Bias</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ConvolutionFiltter(this System.Drawing.Bitmap sourceBitmap,
                                                  double[,] filterMatrix,
                                                       double factor = 1,
                                                            int bias = 0)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    blue = (blue > 255 ? 255 :
                           (blue < 0 ? 0 :
                            blue));

                    green = (green > 255 ? 255 :
                            (green < 0 ? 0 :
                             green));

                    red = (red > 255 ? 255 :
                          (red < 0 ? 0 :
                           red));

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Blur Type
        /// </summary>
        public enum BlurType
        {
            Mean3x3,
            Mean5x5,
            Mean7x7,
            Mean9x9,
            GaussianBlur3x3,
            GaussianBlur5x5,
            MotionBlur5x5,
            MotionBlur5x5At45Degrees,
            MotionBlur5x5At135Degrees,
            MotionBlur7x7,
            MotionBlur7x7At45Degrees,
            MotionBlur7x7At135Degrees,
            MotionBlur9x9,
            MotionBlur9x9At45Degrees,
            MotionBlur9x9At135Degrees,
            Median3x3,
            Median5x5,
            Median7x7,
            Median9x9,
            Median11x11
        }

        /// <summary>
        /// Median Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set Matrix size</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap MedianFilter(this System.Drawing.Bitmap sourceBitmap,
                                                    int matrixSize)
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

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            neighbourPixels.Add(BitConverter.ToInt32(
                                             pixelBuffer, calcOffset));
                        }
                    }

                    neighbourPixels.Sort();

                    middlePixel = BitConverter.GetBytes(
                                       neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
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
