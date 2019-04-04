// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="RussianGrammaticalNumberDetector.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.GrammaticalNumber
{
    /// <summary>
    /// Class RussianGrammaticalNumberDetector.
    /// </summary>
    internal static class RussianGrammaticalNumberDetector
    {
        /// <summary>
        /// Detects the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>RussianGrammaticalNumber.</returns>
        public static RussianGrammaticalNumber Detect(int number)
        {
            var tens = number % 100 / 10;
            if (tens != 1)
            {
                var unity = number % 10;

                if (unity == 1) // 1, 21, 31, 41 ... 91, 101, 121 ...
                    return RussianGrammaticalNumber.Singular;

                if (unity > 1 && unity < 5) // 2, 3, 4, 22, 23, 24 ...
                    return RussianGrammaticalNumber.Paucal;
            }

            return RussianGrammaticalNumber.Plural;
        }
    }
}