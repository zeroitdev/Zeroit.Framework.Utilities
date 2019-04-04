﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ImageArgbSwapping.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection of Image ARGB Swapping
    /// </summary>
    public static class ImageArgbSwapping
    {
        /// <summary>
        /// Swap Colors
        /// </summary>
        /// <param name="originalImage">Set source Bitmap</param>
        /// <param name="swapFilterData">Image Color Swap Filter</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap SwapColorsCopy(this System.Drawing.Bitmap originalImage, ImageColorSwapFilter swapFilterData)
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
                    case ImageColorSwapFilter.ImageColorSwapType.ShiftRight:
                        {
                            resultBlue = sourceGreen;
                            resultRed = sourceBlue;
                            resultGreen = sourceRed;
                            
                            break;
                        }
                    case ImageColorSwapFilter.ImageColorSwapType.ShiftLeft:
                        {
                            resultBlue = sourceRed;
                            resultRed = sourceGreen;
                            resultGreen = sourceBlue;
                            
                            break;
                        }
                    case ImageColorSwapFilter.ImageColorSwapType.SwapBlueAndRed:
                        {
                            resultBlue = sourceRed;
                            resultRed = sourceBlue;

                            break;
                        }
                    case ImageColorSwapFilter.ImageColorSwapType.SwapBlueAndGreen:
                        {
                            resultBlue = sourceGreen;
                            resultGreen = sourceBlue;

                            break;
                        }
                    case ImageColorSwapFilter.ImageColorSwapType.SwapRedAndGreen:
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

    /// <summary>
    /// Image Color Swap Filter
    /// </summary>
    public class ImageColorSwapFilter
    {
        private ImageColorSwapType swapType = ImageColorSwapType.ShiftRight;

        /// <summary>
        /// Swap Type
        /// </summary>
        public ImageColorSwapType SwapType
        {
            get { return swapType; }
            set { swapType = value; }
        }

        private bool swapHalfColorValues = false;

        /// <summary>
        /// Swap Half Color Values
        /// </summary>
        public bool SwapHalfColorValues
        {
            get { return swapHalfColorValues; }
            set { swapHalfColorValues = value; }
        }

        private bool invertColorsWhenSwapping = false;

        /// <summary>
        /// Invert Color When Swapping
        /// </summary>
        public bool InvertColorsWhenSwapping
        {
            get { return invertColorsWhenSwapping; }
            set { invertColorsWhenSwapping = value; }
        }
        
        /// <summary>
        /// Image Color Swap Type
        /// </summary>
        public enum ImageColorSwapType
        {
            ShiftRight,
            ShiftLeft,
            SwapBlueAndRed,
            SwapBlueAndGreen,
            SwapRedAndGreen,
        }
    }
}