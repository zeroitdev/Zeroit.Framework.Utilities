// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ColorCalculator.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A class collection for Calculating Color
    /// </summary>
    public static class ColorCalculator
    {
        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="color1">Color 1 in byte</param>
        /// <param name="color2">Color 2 in byte</param>
        /// <param name="calculationType">Type of calculation</param>
        /// <returns></returns>
        public static byte Calculate(byte color1, byte color2, 
                         ColorCalculationType calculationType)
        {
            byte resultValue = 0;
            int intResult = 0;

            if (calculationType == ColorCalculationType.Add)
            {
                intResult = color1 + color2;
            }
            else if (calculationType == ColorCalculationType.Average)
            {
                intResult = (color1 + color2) / 2;
            }
            else if (calculationType == ColorCalculationType.SubtractLeft)
            {
                intResult = color1 - color2;
            }
            else if (calculationType == ColorCalculationType.SubtractRight)
            {
                intResult = color2 - color1;
            }
            else if (calculationType == ColorCalculationType.Difference)
            {
                intResult = Math.Abs(color1 - color2);
            }
            else if (calculationType == ColorCalculationType.Multiply)
            {
                intResult = (int)((color1 / 255.0 * color2 / 255.0) * 255.0);
            }
            else if (calculationType == ColorCalculationType.Min)
            {
                intResult = (color1 < color2 ? color1 : color2);
            }
            else if (calculationType == ColorCalculationType.Max)
            {
                intResult = (color1 > color2 ? color1 : color2);
            }
            else if (calculationType == ColorCalculationType.Amplitude)
            {
                intResult = (int)(Math.Sqrt(color1 * color1 + color2 * color2)
                                                             / Math.Sqrt(2.0));
            }

            if (intResult < 0)
            { 
                resultValue = 0; 
            }
            else if (intResult > 255)
            {
                resultValue = 255; 
            }
            else
            { 
                resultValue = (byte)intResult; 
            }

            return resultValue;
        }

        public enum ColorCalculationType
        {
            Average,
            Add,
            SubtractLeft,
            SubtractRight,
            Difference,
            Multiply,
            Min,
            Max,
            Amplitude
        }
    }
}
