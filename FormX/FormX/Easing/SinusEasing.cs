// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SinusEasing.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.Animation
{
    /// <summary>
    /// A class providing a more sophisticated implemenation of the abstract
    /// Easing class.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.Animation.Easing" />
    public class SinusEasing : Easing
    {
        /// <summary>
        /// Gets or sets the amplitude of the sinus wave.
        /// </summary>
        /// <value>The amplitude.</value>
        public double Amplitude { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the sinus wave.
        /// </summary>
        /// <value>The frequency.</value>
        public double Frequency { get; set; }

        /// <summary>
        /// Creates an object of the sinus easing.
        /// </summary>
        /// <param name="amplitude">The amplitude of the sinus wave.</param>
        /// <param name="frequency">The frequency of the sinus wave.</param>
        public SinusEasing(double amplitude = 0.2, double frequency = 2.0)
        {
            Amplitude = amplitude;
            Frequency = frequency;
        }

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
            return start + frame * (end - start) / frames + Math.Sin(frame * Frequency * 2 * Math.PI / frames) * (end - start) * Amplitude;
        }
    }
}
