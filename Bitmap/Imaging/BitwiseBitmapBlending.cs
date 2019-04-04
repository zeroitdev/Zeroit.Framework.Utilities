// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BitwiseBitmapBlending.cs" company="Zeroit Dev Technologies">
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
    /// A class collection of Bitwise blending
    /// </summary>
    public static class BitwiseBitmapBlending
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
        /// Bitwise Blend
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="blendBitmap">Set blend Bitmap</param>
        /// <param name="blendTypeBlue">Set blue blend type</param>
        /// <param name="blendTypeGreen">Set green blend type</param>
        /// <param name="blendTypeRed">Set red blend type</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap BitwiseBlend(this System.Drawing.Bitmap sourceBitmap, System.Drawing.Bitmap blendBitmap, 
                                          BitwiseBlendType blendTypeBlue, BitwiseBlendType 
                                          blendTypeGreen, BitwiseBlendType blendTypeRed)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            BitmapData blendData = blendBitmap.LockBits(new Rectangle(0, 0,
                                    blendBitmap.Width, blendBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] blendBuffer = new byte[blendData.Stride * blendData.Height];
            Marshal.Copy(blendData.Scan0, blendBuffer, 0, blendBuffer.Length);
            blendBitmap.UnlockBits(blendData);

            int blue = 0, green = 0, red = 0;

            for (int k = 0; (k + 4 < pixelBuffer.Length) && 
                            (k + 4 < blendBuffer.Length); k += 4)
            {
                if (blendTypeBlue == BitwiseBlendType.And)
                {
                    blue = pixelBuffer[k] & blendBuffer[k];
                }
                else if (blendTypeBlue == BitwiseBlendType.Or)
                {
                    blue = pixelBuffer[k] | blendBuffer[k];
                }
                else if (blendTypeBlue == BitwiseBlendType.Xor)
                {
                    blue = pixelBuffer[k] ^ blendBuffer[k];
                }

                if (blendTypeGreen == BitwiseBlendType.And)
                {
                    green = pixelBuffer[k+1] & blendBuffer[k+1];
                }
                else if (blendTypeGreen == BitwiseBlendType.Or)
                {
                    green = pixelBuffer[k+1] | blendBuffer[k+1];
                }
                else if (blendTypeGreen == BitwiseBlendType.Xor)
                {
                    green = pixelBuffer[k+1] ^ blendBuffer[k+1];
                }

                if (blendTypeRed == BitwiseBlendType.And)
                {
                    red = pixelBuffer[k+2] & blendBuffer[k+2];
                }
                else if (blendTypeRed == BitwiseBlendType.Or)
                {
                    red = pixelBuffer[k+2] | blendBuffer[k+2];
                }
                else if (blendTypeRed == BitwiseBlendType.Xor)
                {
                    red = pixelBuffer[k+2] ^ blendBuffer[k+2];
                }

                if (blue < 0)
                { blue = 0; }
                else if (blue > 255)
                { blue = 255; }

                if (green < 0)
                { green = 0; }
                else if (green > 255)
                { green = 255; }

                if (red < 0)
                { red = 0; }
                else if (red > 255)
                { red = 255; }

                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// Bitwise Blend Type
        /// </summary>
        public enum BitwiseBlendType
        {
            None,
            Or,
            And,
            Xor
        }
    }
}
