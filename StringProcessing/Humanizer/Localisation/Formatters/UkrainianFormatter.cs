// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="UkrainianFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.GrammaticalNumber;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    /// <summary>
    /// Class UkrainianFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.DefaultFormatter" />
    internal class UkrainianFormatter : DefaultFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UkrainianFormatter"/> class.
        /// </summary>
        public UkrainianFormatter()
            : base("uk")
        {
        }

        /// <summary>
        /// Override this method if your locale has complex rules around multiple units; e.g. Arabic, Russian
        /// </summary>
        /// <param name="resourceKey">The resource key that's being in formatting</param>
        /// <param name="number">The number of the units being used in formatting</param>
        /// <returns>System.String.</returns>
        protected override string GetResourceKey(string resourceKey, int number)
        {
            var grammaticalNumber = RussianGrammaticalNumberDetector.Detect(number);
            var suffix = GetSuffix(grammaticalNumber);
            return resourceKey + suffix;
        }

        /// <summary>
        /// Gets the suffix.
        /// </summary>
        /// <param name="grammaticalNumber">The grammatical number.</param>
        /// <returns>System.String.</returns>
        private string GetSuffix(RussianGrammaticalNumber grammaticalNumber)
        {
            if (grammaticalNumber == RussianGrammaticalNumber.Singular)
                return "_Singular";
            if (grammaticalNumber == RussianGrammaticalNumber.Paucal)
                return "_Paucal";
            return "";
        }
    }
}