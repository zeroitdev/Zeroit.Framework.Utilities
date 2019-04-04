// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BitmapArgbSwapping.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class for RGB Swapping
    /// </summary>
    public static class BitmapArgbSwapping
    {
        /// <summary>
        /// Swap Colors
        /// </summary>
        /// <param name="originalImage">Set original Bitmap</param>
        /// <param name="swapFilterData">Set Color Swap Filter</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap SwapColorsCopy(this System.Drawing.Bitmap originalImage, ColorSwapFilter swapFilterData)
        {
            BitmapData sourceData = originalImage.LockBits
                                    (new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, resultBuffer, 0, resultBuffer.Length);
            originalImage.UnlockBits(sourceData);

            byte sourceBlue = 0, resultBlue = 0, 
                 sourceGreen = 0, resultGreen = 0, 
                 sourceRed = 0, resultRed = 0;
            byte byte2 = 2, maxValue = 255;

            for (int k = 0; k < resultBuffer.Length; k += 4)
            {
                sourceBlue = resultBuffer[k];
                sourceGreen = resultBuffer[k + 1];
                sourceRed = resultBuffer[k + 2];

                if (swapFilterData.InvertColorsWhenSwapping == true)
                {
                    sourceBlue = (byte)(maxValue - sourceBlue);
                    sourceGreen = (byte)(maxValue - sourceGreen);
                    sourceRed = (byte)(maxValue - sourceRed);
                }

                if (swapFilterData.SwapHalfColorValues == true)
                {
                    sourceBlue = (byte)(sourceBlue / byte2);
                    sourceGreen = (byte)(sourceGreen / byte2);
                    sourceRed = (byte)(sourceRed / byte2);
                }

                switch (swapFilterData.SwapType)
                {
                    case ColorSwapFilter.ColorSwapType.ShiftRight:
                        {
                            resultBlue = sourceGreen;
                            resultRed = sourceBlue;
                            resultGreen = sourceRed;
                            
                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.ShiftLeft:
                        {
                            resultBlue = sourceRed;
                            resultRed = sourceGreen;
                            resultGreen = sourceBlue;
                            
                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.SwapBlueAndRed:
                        {
                            resultBlue = sourceRed;
                            resultRed = sourceBlue;

                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.SwapBlueAndGreen:
                        {
                            resultBlue = sourceGreen;
                            resultGreen = sourceBlue;

                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.SwapRedAndGreen:
                        {
                            resultRed = sourceGreen;
                            resultGreen = sourceGreen;

                            break;
                        }
                }

                resultBuffer[k] = resultBlue;
                resultBuffer[k + 1] = resultGreen;
                resultBuffer[k + 2] = resultRed;
            }

            System.Drawing.Bitmap resultBitmap = new System.Drawing.Bitmap(originalImage.Width, originalImage.Height, 
                                             PixelFormat.Format32bppArgb);

            BitmapData resultData = resultBitmap.LockBits
                                    (new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
    }

    public class ColorSwapFilter
    {
        private ColorSwapType swapType = ColorSwapType.ShiftRight;

        /// <summary>
        /// Property for Getting and Setting SwapType
        /// </summary>
        public ColorSwapType SwapType
        {
            get { return swapType; }
            set { swapType = value; }
        }

        private bool swapHalfColorValues = false;

        /// <summary>
        /// Property for Swapping Half Color Values
        /// </summary>
        public bool SwapHalfColorValues
        {
            get { return swapHalfColorValues; }
            set { swapHalfColorValues = value; }
        }

        private bool invertColorsWhenSwapping = false;

        /// <summary>
        /// Invert Colors When Swapping
        /// </summary>
        public bool InvertColorsWhenSwapping
        {
            get { return invertColorsWhenSwapping; }
            set { invertColorsWhenSwapping = value; }
        }
        
        /// <summary>
        /// Color Swap Type
        /// </summary>
        public enum ColorSwapType
        {
            ShiftRight,
            ShiftLeft,
            SwapBlueAndRed,
            SwapBlueAndGreen,
            SwapRedAndGreen,
        }
    }
}
