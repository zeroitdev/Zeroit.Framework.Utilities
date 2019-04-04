// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageUnsharpMask.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Image Unsharp Mask
    /// </summary>
    public static class ImageUnsharpMask
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
        /// Convolution Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="filterMatrix">Set Filter Matrix</param>
        /// <param name="factor">Set Factor</param>
        /// <param name="bias">Set Bias</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ConvolutionFilter(System.Drawing.Bitmap sourceBitmap, 
                                             double[,] filterMatrix, 
                                                  double factor = 1, 
                                                       int bias = 0, 
                                             bool grayscale = false) 
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly, 
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth-1) / 2;
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

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

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
        /// Subtract and Add Factor to Image
        /// </summary>
        /// <param name="subtractFrom">Subtract from</param>
        /// <param name="subtractValue">Subtract value</param>
        /// <param name="factor">Set factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap SubtractAddFactorImage(
                                      this System.Drawing.Bitmap subtractFrom,
                                          System.Drawing.Bitmap subtractValue,
                                          float factor = 1.0f)
        {
            BitmapData sourceData = 
                       subtractFrom.LockBits(new Rectangle(0, 0,
                       subtractFrom.Width, subtractFrom.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] sourceBuffer = new byte[sourceData.Stride * 
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, 
                                        sourceBuffer.Length);

            byte[] resultBuffer = new byte[sourceData.Stride * 
                                           sourceData.Height];


            BitmapData subtractData = 
                       subtractValue.LockBits(new Rectangle(0, 0,
                       subtractValue.Width, subtractValue.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] subtractBuffer = new byte[subtractData.Stride *
                                             subtractData.Height];

            Marshal.Copy(subtractData.Scan0, subtractBuffer, 0,
                                         subtractBuffer.Length);

            subtractFrom.UnlockBits(sourceData);
            subtractValue.UnlockBits(subtractData);

            double blue = 0;
            double green = 0;
            double red = 0;

            for (int k = 0; k < resultBuffer.Length &&
                           k < subtractBuffer.Length; k += 4)
            {
                blue = sourceBuffer[k] + 
                      (sourceBuffer[k] -
                       subtractBuffer[k]) * factor;

                green = sourceBuffer[k + 1] + 
                       (sourceBuffer[k + 1] -
                        subtractBuffer[k + 1]) * factor;

                red = sourceBuffer[k + 2] + 
                     (sourceBuffer[k + 2] -
                      subtractBuffer[k + 2]) * factor;


                blue = (blue < 0 ? 0 : (blue > 255 ? 255 : blue));
                green = (green < 0 ? 0 : (green > 255 ? 255 : green));
                red = (red < 0 ? 0 : (red > 255 ? 255 : red));

                resultBuffer[k] = (byte)blue;
                resultBuffer[k + 1] = (byte)green;
                resultBuffer[k + 2] = (byte)red;
                resultBuffer[k + 3] = 255;
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(subtractFrom.Width, 
                                             subtractFrom.Height);

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
        /// Unsharp Gaussian 3x3
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="factor">Set factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap UnsharpGaussian3x3(
                                         this System.Drawing.Bitmap sourceBitmap, 
                                         float factor = 1.0f)
        {
            System.Drawing.Bitmap blurBitmap = ConvolutionFilter(
                                          sourceBitmap, 
                                          Matrix.Gaussian3x3, 
                                          1.0 / 16.0);

            System.Drawing.Bitmap resultBitmap = 
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);

            return resultBitmap;
        }

        /// <summary>
        /// Unsharp Gaussian 5x5
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="factor">Set factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap UnsharpGaussian5x5(
                                         this System.Drawing.Bitmap sourceBitmap,
                                         float factor = 1.0f)
        {
            System.Drawing.Bitmap blurBitmap = ConvolutionFilter(
                                          sourceBitmap, 
                                          Matrix.Gaussian5x5Type1, 
                                          1.0 / 159.0);

            System.Drawing.Bitmap resultBitmap =
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);

            return resultBitmap;
        }

        /// <summary>
        /// Unsharp Mean 3x3
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="factor">Set factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap UnsharpMean3x3(
                                         this System.Drawing.Bitmap sourceBitmap,
                                         float factor = 1.0f)
        {
            System.Drawing.Bitmap blurBitmap = ConvolutionFilter(
                                          sourceBitmap, 
                                          Matrix.Mean3x3, 
                                          1.0 / 9.0);

            System.Drawing.Bitmap resultBitmap =
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);

            return resultBitmap;
        }

        /// <summary>
        /// Unsharp Mean 5x5
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="factor">Set factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap UnsharpMean5x5(
                                         this System.Drawing.Bitmap sourceBitmap,
                                         float factor = 1.0f)
        {
            System.Drawing.Bitmap blurBitmap = ConvolutionFilter(
                                          sourceBitmap, 
                                          Matrix.Mean5x5, 
                                          1.0 / 25.0);

            System.Drawing.Bitmap resultBitmap =
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);

            return resultBitmap;
        }
    }  
}
