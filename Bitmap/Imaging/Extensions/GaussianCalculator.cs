// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GaussianCalculator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{
    /// <summary>
    /// A Gaussian calculator class
    /// </summary>
    public static class GaussianCalculator
    {
        /// <summary>
        /// Calcultor
        /// </summary>
        /// <param name="length">Set the length</param>
        /// <param name="weight">Set the weight</param>
        /// <returns></returns>
        public static double[,] Calculate(int length, double weight)
        {
            double[,] Kernel = new double[length, length];
            double sumTotal = 0;

            int kernelRadius = length / 2;
            double distance = 0;

            double calculatedEuler = 1.0 /
            (2.0 * Math.PI * Math.Pow(weight, 2));

            for (int filterY = -kernelRadius;
                 filterY <= kernelRadius; filterY++)
            {
                for (int filterX = -kernelRadius;
                    filterX <= kernelRadius; filterX++)
                {
                    distance = ((filterX * filterX) +
                               (filterY * filterY)) /
                               (2 * (weight * weight));

                    Kernel[filterY + kernelRadius,
                           filterX + kernelRadius] =
                           calculatedEuler * Math.Exp(-distance);

                    sumTotal += Kernel[filterY + kernelRadius,
                                       filterX + kernelRadius];
                }
            }

            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    Kernel[y, x] = Kernel[y, x] *
                                   (1.0 / sumTotal);
                }
            }

            return Kernel;
        }
    }
}
