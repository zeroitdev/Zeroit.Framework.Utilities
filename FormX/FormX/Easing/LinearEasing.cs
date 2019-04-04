// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LinearEasing.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.Animation
{
    /// <summary>
    /// A class that is a concrete implementation of the abstract easing class
    /// providing a linear easing.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.Animation.Easing" />
    public class LinearEasing : Easing
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
            return start + frame * (end - start) / frames;
        }
    }
}
