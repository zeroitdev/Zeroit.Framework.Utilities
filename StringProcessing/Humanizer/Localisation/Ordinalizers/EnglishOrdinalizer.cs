// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="EnglishOrdinalizer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers
{
    /// <summary>
    /// Class EnglishOrdinalizer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Ordinalizers.DefaultOrdinalizer" />
    internal class EnglishOrdinalizer : DefaultOrdinalizer
    {
        /// <summary>
        /// Ordinalizes the number
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numberString">The number string.</param>
        /// <returns>System.String.</returns>
        public override string Convert(int number, string numberString)
        {
            var nMod100 = number % 100;

            if (nMod100 >= 11 && nMod100 <= 13)
                return numberString + "th";

            switch (number % 10)
            {
                case 1:
                    return numberString + "st";

                case 2:
                    return numberString + "nd";

                case 3:
                    return numberString + "rd";

                default:
                    return numberString + "th";
            }
        }
    }
}