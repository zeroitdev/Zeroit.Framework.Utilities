﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EasIn.cs" company="Zeroit Dev Technologies">
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
using System;

namespace Zeroit.Framework.Utilities.Animation
{
    /// <summary>
    /// A class that is a concrete implementation of the abstract easing class
    /// providing a linear easing.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.Animation.Easing" />
    public class EaseIn : Easing
    {
        /// <summary>
        /// Calculate the current value for the given properties.
        /// </summary>
        /// <param name="frame">The current frame number.</param>
        /// <param name="frames">The total frame number.</param>
        /// <param name="start">The start value (at frame 0).</param>
        /// <param name="end">The final value (at frame total - 1).</param>
        /// <returns>The current value.</returns>
        public override double CalculateStep(int frame, int frames, double start, double end)
        {
            return start + (frame * frame * frame) * (end - start) / frames;
        }
    }

    /// <summary>
    /// Class EaseOut.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.Animation.Easing" />
    public class EaseOut : Easing
    {
        /// <summary>
        /// Calculate the current value for the given properties.
        /// </summary>
        /// <param name="frame">The current frame number.</param>
        /// <param name="frames">The total frame number.</param>
        /// <param name="start">The start value (at frame 0).</param>
        /// <param name="end">The final value (at frame total - 1).</param>
        /// <returns>The current value.</returns>
        public override double CalculateStep(int frame, int frames, double start, double end)
        {
            return start + frame * (end - start) / frames + 1 - Math.Pow((1 - frame), 3) * (end - start);
        }
    }
}
