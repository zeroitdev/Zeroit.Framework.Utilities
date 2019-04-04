// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="IFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    /// <summary>
    /// Implement this interface if your language has complex rules around dealing with numbers.
    /// For example in Romanian "5 days" is "5 zile", while "24 days" is "24 de zile" and
    /// in Arabic 2 days is يومين not 2 يوم
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Now
        /// </summary>
        /// <returns>Returns Now</returns>
        string DateHumanize_Now();

        /// <summary>
        /// Never
        /// </summary>
        /// <returns>Returns Never</returns>
        string DateHumanize_Never();

        /// <summary>
        /// Returns the string representation of the provided DateTime
        /// </summary>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="timeUnitTense">The time unit tense.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>System.String.</returns>
        string DateHumanize(TimeUnit timeUnit, Tense timeUnitTense, int unit);

        /// <summary>
        /// 0 seconds
        /// </summary>
        /// <returns>Returns 0 seconds as the string representation of Zero TimeSpan</returns>
        string TimeSpanHumanize_Zero();

        /// <summary>
        /// Returns the string representation of the provided TimeSpan
        /// </summary>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="toWords">if set to <c>true</c> [to words].</param>
        /// <returns>System.String.</returns>
        string TimeSpanHumanize(TimeUnit timeUnit, int unit, bool toWords = false);
    }
}
