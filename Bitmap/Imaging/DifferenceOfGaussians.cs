// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DifferenceOfGaussians.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    /// A class collection of Difference of Gaussians
    /// </summary>
    public static class DifferenceOfGaussians
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
        /// <param name="grayscale">Set Grayscale</param>
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
        /// Subtract Image
        /// </summary>
        /// <param name="subtractFrom">Set Bitmap to subtract from</param>
        /// <param name="subtractValue">Set subtraction value</param>
        /// <param name="invert">Set invert</param>
        /// <param name="bias">Set bias</param>
        public static void SubtractImage(this System.Drawing.Bitmap subtractFrom, 
                                          System.Drawing.Bitmap subtractValue, 
                                          bool invert = false, int bias = 0)
        {
            BitmapData sourceData = subtractFrom.LockBits(new Rectangle(0, 0,
                                     subtractFrom.Width, subtractFrom.Height),
                                                      ImageLockMode.ReadWrite,
                                                 PixelFormat.Format32bppArgb);

            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, resultBuffer, 0, resultBuffer.Length);


            BitmapData subtractData = subtractValue.LockBits(new Rectangle(0, 0,
                                     subtractValue.Width, subtractValue.Height),
                                                         ImageLockMode.ReadOnly,
                                                   PixelFormat.Format32bppArgb);

            byte[] subtractBuffer = new byte[subtractData.Stride * 
                                             subtractData.Height];

            Marshal.Copy(subtractData.Scan0, subtractBuffer, 0, 
                                         subtractBuffer.Length);

            subtractValue.UnlockBits(subtractData);

            int blue = 0;
            int green = 0;
            int red = 0;

            for(int k = 0; k < resultBuffer.Length && 
                           k < subtractBuffer.Length; k += 4)
            {
                if (invert == true)
                {
                    blue = 255 - resultBuffer[k] - 
                           subtractBuffer[k] + bias;

                    green = 255 - resultBuffer[k + 1] - 
                            subtractBuffer[k + 1] + bias;

                    red = 255 - resultBuffer[k + 2] - 
                          subtractBuffer[k + 2] + bias;
                }
                else
                {
                    blue = resultBuffer[k] - 
                           subtractBuffer[k] + bias;

                    green = resultBuffer[k + 1] - 
                            subtractBuffer[k + 1] + bias;

                    red = resultBuffer[k + 2] - 
                          subtractBuffer[k + 2] + bias;
                }

                blue = (blue < 0 ? 0 : (blue > 255 ? 255 : blue));
                green = (green < 0 ? 0 : (green > 255 ? 255 : green));
                red = (red < 0 ? 0 : (red > 255 ? 255 : red));

                resultBuffer[k] = (byte)blue;
                resultBuffer[k + 1] = (byte)green;
                resultBuffer[k + 2] = (byte)red;
                resultBuffer[k + 3] = 255;
            }

            Marshal.Copy(resultBuffer, 0, sourceData.Scan0, 
                                       resultBuffer.Length);

            subtractFrom.UnlockBits(sourceData);
        }

        /// <summary>
        /// Difference of Gaussians 3x5 Type 1
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <param name="invert">Set invert</param>
        /// <param name="bias">Set bias</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap DifferenceOfGaussians3x5Type1(this System.Drawing.Bitmap sourceBitmap, 
                                                           bool grayscale = false,
                                                           bool invert = false,
                                                           int bias = 0)
        {
            System.Drawing.Bitmap bitmap3x3 = ConvolutionFilter(sourceBitmap,
                               Matrix.Gaussian3x3, 1.0 / 16.0, 0, grayscale);

            System.Drawing.Bitmap bitmap5x5 = ConvolutionFilter(sourceBitmap,
                               Matrix.Gaussian5x5Type1, 1.0 / 159.0, 0, grayscale);

            bitmap3x3.SubtractImage(bitmap5x5, invert, bias);

            return bitmap3x3;
        }
        /// <summary>
        /// Difference of Gaussians 3x5 Type 2
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="grayscale">Set grayscale</param>
        /// <param name="invert">Set invert</param>
        /// <param name="bias">Set bias</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap DifferenceOfGaussians3x5Type2(this System.Drawing.Bitmap sourceBitmap, 
                                                           bool grayscale = false, 
                                                           bool invert = false, 
                                                           int bias = 0)
        {
            System.Drawing.Bitmap bitmap3x3 = ConvolutionFilter(sourceBitmap,
                               Matrix.Gaussian3x3, 1.0 / 16.0, 0, true);

            System.Drawing.Bitmap bitmap5x5 = ConvolutionFilter(sourceBitmap,
                               Matrix.Gaussian5x5Type2, 1.0 / 256.0, 0, true);

            bitmap3x3.SubtractImage(bitmap5x5, invert, bias);

            return bitmap3x3;
        }
    }  
}
