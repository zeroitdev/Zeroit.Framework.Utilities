// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Maths.cs" company="Zeroit Dev Technologies">
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
