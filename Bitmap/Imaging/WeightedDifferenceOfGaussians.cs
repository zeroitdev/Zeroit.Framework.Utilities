// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WeightedDifferenceOfGaussians.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for Weighted Difference of Gaussians
    /// </summary>
    public static class WeightedDifferenceOfGaussians
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
        /// Difference Of Gaussian Filter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="matrixSize">Set matrix size</param>
        /// <param name="weight1">Set weight 1</param>
        /// <param name="weight2">Set weight 2</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap DifferenceOfGaussianFilter(this System.Drawing.Bitmap sourceBitmap, 
                                                        int matrixSize, double weight1,
                                                        double weight2)
        {
            double[,] kernel1 = 
            GaussianCalculator.Calculate(matrixSize, 
            (weight1 > weight2 ? weight1 : weight2));

            double[,] kernel2 = 
            GaussianCalculator.Calculate(matrixSize, 
            (weight1 > weight2 ? weight2 : weight1));

            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] grayscaleBuffer = new byte[sourceData.Width * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            double rgb = 0;

            for (int source = 0, dst = 0; 
                 source < pixelBuffer.Length && dst < grayscaleBuffer.Length; 
                 source += 4, dst++)
            {
                rgb = pixelBuffer[source] * 0.11f;
                rgb += pixelBuffer[source + 1] * 0.59f;
                rgb += pixelBuffer[source + 2] * 0.3f;

                grayscaleBuffer[dst] = (byte)rgb;
            }

            double color1 = 0.0;
            double color2 = 0.0;

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            for (int source = 0, dst = 0; 
                 source < grayscaleBuffer.Length && dst + 4 < resultBuffer.Length; 
                 source++, dst += 4)
            {
                color1 = 0;
                color2 = 0;
                
                for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                {
                    for (int filterX = -filterOffset;
                        filterX <= filterOffset; filterX++)
                    {

                        calcOffset = source + (filterX) +
                                     (filterY * sourceBitmap.Width);

                        calcOffset = (calcOffset < 0 ? 0 : 
                                     (calcOffset >= grayscaleBuffer.Length ? 
                                     grayscaleBuffer.Length - 1 : calcOffset));

                        color1 += (grayscaleBuffer[calcOffset]) *
                                   kernel1[filterY + filterOffset,
                                   filterX + filterOffset];

                        color2 += (grayscaleBuffer[calcOffset]) *
                                   kernel2[filterY + filterOffset,
                                   filterX + filterOffset];
                    }
                }

                color1 = color1 - color2;
                color1 = (color1 >= weight1 - weight2 ? 255 : 0);

                resultBuffer[dst] = (byte)color1;
                resultBuffer[dst + 1] = (byte)color1;
                resultBuffer[dst + 2] = (byte)color1;
                resultBuffer[dst + 3] = 255;
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
    }  
}
