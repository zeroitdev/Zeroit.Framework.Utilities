// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Easing.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.Animation
{
    /// <summary>
    /// Inherit from this class in order to implement your own easing feature
    /// </summary>
    public abstract class Easing
    {
        /// <summary>
        /// Calculate the current value for the given properties.
        /// </summary>
        /// <param name="frame">The current frame number.</param>
        /// <param name="frames">The total frame number.</param>
        /// <param name="start">The start value (at frame 0).</param>
        /// <param name="end">The final value (at frame total - 1).</param>
        /// <returns>The current value.</returns>
        public abstract double CalculateStep(int frame, int frames, double start, double end);

        /// <summary>
        /// The linear
        /// </summary>
        static Easing linear;
        /// <summary>
        /// The sinus
        /// </summary>
        static Easing sinus;

        /// <summary>
        /// Gets an instance of the provided linear easing.
        /// </summary>
        /// <value>The linear.</value>
        public static Easing Linear
        {
            get
            {
                if (linear == null)
                    linear = new LinearEasing();

                return linear;
            }
        }

        /// <summary>
        /// Gets an instance of the provided sinus easing.
        /// </summary>
        /// <value>The sinus.</value>
        public static Easing Sinus
        {
            get
            {
                if (sinus == null)
                    sinus = new SinusEasing();

                return sinus;
            }
        }
    }
}
