// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MathsFunctions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities
{

    /// <summary>
    /// A class collection for Math Functions
    /// </summary>
    public static class MathsFunctions
    {

        /// <summary>
        /// Converts Degrees to Radians
        /// </summary>
        /// <param name="degrees">Degrees</param>
        /// <returns>System.Double.</returns>
        public static double ConvertDegreesToRadians(int degrees)
        {
            return ((Math.PI / (double)180) * degrees);
        }

        /// <summary>
        /// Converts Double to Float
        /// </summary>
        /// <param name="dValue">Set double value</param>
        /// <returns>System.Single.</returns>
        public static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }

        /// <summary>
        /// Gets Radian
        /// </summary>
        /// <param name="val">Set value in float</param>
        /// <returns>System.Single.</returns>
        public static float GetRadian(float val)
        {
            return (float)(val * Math.PI / 180);
        }

    }

}
