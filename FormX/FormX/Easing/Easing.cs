// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Easing.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
