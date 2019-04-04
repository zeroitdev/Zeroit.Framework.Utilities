// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Maths.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.Maths
{
    /// <summary>
    /// Class Math.
    /// </summary>
    public static partial class Math
    {
        /// <summary>
        /// Percents the specified range.
        /// </summary>
        /// <param name="Range">The range.</param>
        /// <param name="Percent">The percent.</param>
        /// <returns>System.Double.</returns>
        public static double Percent(float Range, float Percent)
        {
            return System.Math.Ceiling(Range *Percent / 100);
        }
        /// <summary>
        /// Percents the specified range.
        /// </summary>
        /// <param name="Range">The range.</param>
        /// <param name="Percent">The percent.</param>
        /// <returns>System.Int32.</returns>
        public static int Percent(int Range, int Percent)
        {
            return (int)Math.Percent((float)Range,(float)Percent);
        }

        /// <summary>
        /// Sums the specified sum.
        /// </summary>
        /// <param name="sum">The sum.</param>
        /// <returns>System.Single.</returns>
        public static float Sum(params float[] sum)
        {
            float addition = 0;

            for (int i = 0; i < sum.Length; i++)
            {
                addition += sum[i];
            }
            return addition;
        }
    }
}
