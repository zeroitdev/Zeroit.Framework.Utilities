// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="IOrdinalizer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers
{
    /// <summary>
    /// The interface used to localise the Ordinalize method
    /// </summary>
    public interface IOrdinalizer
    {
        /// <summary>
        /// Ordinalizes the number
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numberString">The number string.</param>
        /// <returns>System.String.</returns>
        string Convert(int number, string numberString);

        /// <summary>
        /// Ordinalizes the number using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numberString">The number string.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        string Convert(int number, string numberString, GrammaticalGender gender);
    }
}
