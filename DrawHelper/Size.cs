// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Size.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// Class Sizes.
    /// </summary>
    public static class Sizes
    {
        /// <summary>
        /// Compares the specified s1.
        /// </summary>
        /// <param name="S1">The s1.</param>
        /// <param name="S2">The s2.</param>
        /// <returns>CompareOutputTypes.</returns>
        public static CompareOutputTypes Compare(Size S1, Size S2)
        {
            if (S1.Height == S2.Height && S1.Width == S2.Width)
                return CompareOutputTypes.Equal;
            if (S1.Height <= S2.Height && S1.Width <= S2.Width)
                return CompareOutputTypes.Smaller;
            if (S1.Height <= S2.Height && S1.Width >= S2.Width)
                return CompareOutputTypes.Unknown;
            return CompareOutputTypes.Larger;

        }
        /// <summary>
        /// Enum CompareOutputTypes
        /// </summary>
        public enum CompareOutputTypes { Smaller, Equal, Larger,Unknown };
    }
    
}
