// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ResourceKeys.TimeSpanHumanize.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation
{
    /// <summary>
    /// Class ResourceKeys.
    /// </summary>
    public partial class ResourceKeys
    {
        /// <summary>
        /// Encapsulates the logic required to get the resource keys for TimeSpan.Humanize
        /// </summary>
        public static class TimeSpanHumanize
        {
            /// <summary>
            /// Examples: TimeSpanHumanize_SingleMinute, TimeSpanHumanize_MultipleHours.
            /// Note: "s" for plural served separately by third part.
            /// </summary>
            private const string TimeSpanFormat = "TimeSpanHumanize_{0}{1}{2}";
            /// <summary>
            /// The zero
            /// </summary>
            private const string Zero = "TimeSpanHumanize_Zero";

            /// <summary>
            /// Generates Resource Keys according to convention.
            /// </summary>
            /// <param name="unit">Time unit, <see cref="TimeUnit" />.</param>
            /// <param name="count">Number of units, default is One.</param>
            /// <returns>Resource key, like TimeSpanHumanize_SingleMinute</returns>
            public static string GetResourceKey(TimeUnit unit, int count = 1)
            {
                ValidateRange(count);

                if (count == 0) 
                    return Zero;

                return TimeSpanFormat.FormatWith(count == 1 ? Single : Multiple, unit, count == 1 ? "" : "s");
            }
        }
    }
}
