// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="UkrainianOrdinalizer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers
{
    /// <summary>
    /// Class UkrainianOrdinalizer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers.DefaultOrdinalizer" />
    internal class UkrainianOrdinalizer : DefaultOrdinalizer
    {
        /// <summary>
        /// Ordinalizes the number
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numberString">The number string.</param>
        /// <returns>System.String.</returns>
        public override string Convert(int number, string numberString)
        {
            return Convert(number, numberString, GrammaticalGender.Masculine);
        }

        /// <summary>
        /// Ordinalizes the number using the provided grammatical gender
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numberString">The number string.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>System.String.</returns>
        public override string Convert(int number, string numberString, GrammaticalGender gender)
        {

            if (gender == GrammaticalGender.Masculine)
                return numberString + "-й";

            if (gender == GrammaticalGender.Feminine)
            {
                if (number % 10 == 3)
                    return numberString + "-я";
                return numberString + "-а";
            }

            if (gender == GrammaticalGender.Neuter)
                if (number % 10 == 3)
                    return numberString + "-є";

            return numberString + "-е";
        }
    }
}
