// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 12-01-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Statistics.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.Maths
{
    /// <summary>
    /// Class Statistic.
    /// </summary>
    public static partial class Statistic
    {
        // http://geeks.netindonesia.net/blogs/anwarminarso/archive/2008/01/13/normsinv-function-in-c-inverse-cumulative-standard-normal-distribution-function.aspx
        // http://home.online.no/~pjacklam/notes/invnorm/impl/misra/normsinv.html

        /// <summary>
        /// Means the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Double.</returns>
        public static double Mean(double[] values)
        {
            double tot = 0;
            foreach (double val in values)
                tot += val;

            return (tot / values.Length);
        }

        /// <summary>
        /// Standards the deviation.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Double.</returns>
        public static double StandardDeviation(double[] values)
        {
            return System.Math.Sqrt(Variance(values));
        }

        /// <summary>
        /// Variances the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Double.</returns>
        public static double Variance(double[] values)
        {
            double m = Mean(values);
            double result = 0;
            foreach (double d in values)
                result += System.Math.Pow((d - m), 2);

            return (result / values.Length);
        }

        //
        // Lower tail quantile for standard normal distribution function.
        //
        // This function returns an approximation of the inverse cumulative
        // standard normal distribution function.  I.e., given P, it returns
        // an approximation to the X satisfying P = Pr{Z <= X} where Z is a
        // random variable from the standard normal distribution.
        //
        // The algorithm uses a minimax approximation by rational functions
        // and the result has a relative error whose absolute value is less
        // than 1.15e-9.
        // An algorithm with a relative error less than 1.15*10-9 in the entire region.

        /// <summary>
        /// Normsinvs the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>System.Double.</returns>
        public static double NORMSINV(double p)
        {
            // Coefficients in rational approximations
            double[] a = {-3.969683028665376e+01,  2.209460984245205e+02,
                -2.759285104469687e+02,  1.383577518672690e+02,
                -3.066479806614716e+01,  2.506628277459239e+00};

            double[] b = {-5.447609879822406e+01,  1.615858368580409e+02,
                -1.556989798598866e+02,  6.680131188771972e+01,
                -1.328068155288572e+01 };

            double[] c = {-7.784894002430293e-03, -3.223964580411365e-01,
                -2.400758277161838e+00, -2.549732539343734e+00,
                4.374664141464968e+00,  2.938163982698783e+00};

            double[] d = { 7.784695709041462e-03,  3.224671290700398e-01,
                2.445134137142996e+00,  3.754408661907416e+00};

            // Define break-points.
            double plow = 0.02425;
            double phigh = 1 - plow;

            // Rational approximation for lower region:
            if (p < plow)
            {
                double q = System.Math.Sqrt(-2 * System.Math.Log(p));
                return (((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                    ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }

            // Rational approximation for upper region:
            if (phigh < p)
            {
                double q = System.Math.Sqrt(-2 * System.Math.Log(1 - p));
                return -(((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                    ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }

            // Rational approximation for central region:
            {
                double q = p - 0.5;
                double r = q * q;
                return (((((a[0] * r + a[1]) * r + a[2]) * r + a[3]) * r + a[4]) * r + a[5]) * q /
                    (((((b[0] * r + b[1]) * r + b[2]) * r + b[3]) * r + b[4]) * r + 1);
            }
        }


        /// <summary>
        /// Norminvs the specified probability.
        /// </summary>
        /// <param name="probability">The probability.</param>
        /// <param name="mean">The mean.</param>
        /// <param name="standard_deviation">The standard deviation.</param>
        /// <returns>System.Double.</returns>
        public static double NORMINV(double probability, double mean, double standard_deviation)
        {
            return (NORMSINV(probability) * standard_deviation + mean);
        }

        /// <summary>
        /// Norminvs the specified probability.
        /// </summary>
        /// <param name="probability">The probability.</param>
        /// <param name="values">The values.</param>
        /// <returns>System.Double.</returns>
        public static double NORMINV(double probability, double[] values)
        {
            return NORMINV(probability, Mean(values), StandardDeviation(values));
        }
    }
}
