// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageASCIIArt.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Image ASCII Art
    /// </summary>
    public static class ImageASCIIArt
    {
        /// <summary>
        /// ASCIIFilter
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="pixelBlockSize">Set Pixel block size</param>
        /// <param name="colorCount">Set Color count</param>
        /// <returns></returns>
        public static string ASCIIFilter(this System.Drawing.Bitmap sourceBitmap, int pixelBlockSize, 
                                                                   int colorCount = 0)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                                      ImageLockMode.ReadOnly,
                                                PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            StringBuilder asciiArt = new StringBuilder();

            int avgBlue = 0;
            int avgGreen = 0;
            int avgRed = 0;
            int offset = 0;

            int rows = sourceBitmap.Height / pixelBlockSize;
            int columns = sourceBitmap.Width / pixelBlockSize;

            if (colorCount > 0)
            {
                colorCharacters = GenerateRandomString(colorCount);
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    avgBlue = 0;
                    avgGreen = 0;
                    avgRed = 0;

                    for (int pY = 0; pY < pixelBlockSize; pY++)
                    {
                        for (int pX = 0; pX < pixelBlockSize; pX++)
                        {
                            offset = y * pixelBlockSize * sourceData.Stride + 
                                     x * pixelBlockSize * 4;

                            offset += pY * sourceData.Stride;
                            offset += pX * 4;

                            avgBlue += pixelBuffer[offset];
                            avgGreen += pixelBuffer[offset + 1];
                            avgRed += pixelBuffer[offset + 2];
                        }
                    }

                    avgBlue = avgBlue / (pixelBlockSize * pixelBlockSize);
                    avgGreen = avgGreen / (pixelBlockSize * pixelBlockSize);
                    avgRed = avgRed / (pixelBlockSize * pixelBlockSize);

                    asciiArt.Append(GetColorCharacter(avgBlue, avgGreen, avgRed));
                }

                asciiArt.Append("\r\n");
            }

            return asciiArt.ToString();
        }

        /// <summary>
        /// Generate Random String
        /// </summary>
        /// <param name="maxSize">Set maximum size</param>
        /// <returns></returns>
        public static string GenerateRandomString(int maxSize)
        {
            StringBuilder stringBuilder = new StringBuilder(maxSize);
            Random randomChar = new Random();

            char charValue;

            for (int k = 0; k < maxSize; k++)
            {
                charValue = (char)(Math.Floor(255 * randomChar.NextDouble() * 4));

                if (stringBuilder.ToString().IndexOf(charValue) != -1)
                {
                    charValue = (char)(Math.Floor((byte)charValue * 
                                            randomChar.NextDouble()));
                }

                if (Char.IsControl(charValue) == false && 
                    Char.IsPunctuation(charValue) == false && 
                    stringBuilder.ToString().IndexOf(charValue) == -1)
                {
                    stringBuilder.Append(charValue);

                    randomChar = new Random((int)((byte)charValue * 
                                     (k + 1) + DateTime.Now.Ticks));
                }
                else
                {
                    randomChar = new Random((int)((byte)charValue * 
                                     (k + 1) + DateTime.UtcNow.Ticks));
                    k -= 1;
                }
            }

            return stringBuilder.ToString().RandomStringSort();
        }

        /// <summary>
        /// Random String Sort
        /// </summary>
        /// <param name="stringValue">Set string value</param>
        /// <returns></returns>
        public static string RandomStringSort(this string stringValue)
        {
            char[] charArray = stringValue.ToCharArray();

            Random randomIndex = new Random((byte)charArray[0]);
            int iterator = charArray.Length;

            while (iterator > 1)
            {
                iterator -= 1;

                int nextIndex = randomIndex.Next(iterator + 1);

                char nextValue = charArray[nextIndex];
                charArray[nextIndex] = charArray[iterator];
                charArray[iterator] = nextValue;
            }

            return new string(charArray);
        }

        private static string colorCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Get Color Character
        /// </summary>
        /// <param name="blue">Set blue</param>
        /// <param name="green">Set green</param>
        /// <param name="red">Set red</param>
        /// <returns></returns>
        public static string GetColorCharacter(int blue, int green, int red)
        {
            string colorChar = String.Empty;
            int intensity = (blue + green + red) / 3 * 
                            (colorCharacters.Length - 1) / 255;

            colorChar = colorCharacters.Substring(intensity, 1).ToUpper();
            colorChar += colorChar.ToLower();

            return colorChar;
        }

        /// <summary>
        /// Text to Image
        /// </summary>
        /// <param name="text">Set text</param>
        /// <param name="font">Set font</param>
        /// <param name="factor">Set factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap TextToImage(this string text, Font font, 
                                                        float factor)
        {
            System.Drawing.Bitmap textBitmap = new System.Drawing.Bitmap(1, 1);

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(textBitmap);

            int width = (int)Math.Ceiling(
                        graphics.MeasureString(text, font).Width * 
                        factor);

            int height = (int)Math.Ceiling(
                         graphics.MeasureString(text, font).Height * 
                         factor);

            graphics.Dispose();

            textBitmap = new System.Drawing.Bitmap(width, height, 
                                    PixelFormat.Format32bppArgb);

            graphics = System.Drawing.Graphics.FromImage(textBitmap);
            graphics.Clear(Color.Black);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            graphics.ScaleTransform(factor, factor);
            graphics.DrawString(text, font, Brushes.White, new PointF(0, 0));

            graphics.Flush();
            graphics.Dispose();

            return textBitmap;
        }

        /// <summary>
        /// Scale Bitmap
        /// </summary>
        /// <param name="sourceBitmap">Set source Bitmap</param>
        /// <param name="factor">Set factor</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap ScaleBitmap(this System.Drawing.Bitmap sourceBitmap, float factor)
        {
            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap((int)(sourceBitmap.Width * factor), 
                                             (int)(sourceBitmap.Height * factor), 
                                             PixelFormat.Format32bppArgb);

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(resultBitmap);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            graphics.DrawImage(sourceBitmap, 
                new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), 
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), 
                                                         GraphicsUnit.Pixel);

            return resultBitmap;
        }
    }  
}
