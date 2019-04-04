// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="HebrewFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    /// <summary>
    /// Class HebrewFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.DefaultFormatter" />
    internal class HebrewFormatter : DefaultFormatter
    {
        /// <summary>
        /// The dual postfix
        /// </summary>
        private const string DualPostfix = "_Dual";
        /// <summary>
        /// The plural postfix
        /// </summary>
        private const string PluralPostfix = "_Plural";

        /// <summary>
        /// Initializes a new instance of the <see cref="HebrewFormatter"/> class.
        /// </summary>
        public HebrewFormatter()
            : base("he")
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
            //In Hebrew pluralization 2 entities gets a different word.
            if (number == 2)
                return resourceKey + DualPostfix;

            //In Hebrew pluralization entities where the count is between 3 and 10 gets a different word.
            //See http://lib.cet.ac.il/pages/item.asp?item=21585 for explanation
            if (number >= 3 && number <= 10)
                return resourceKey + PluralPostfix;

            return resourceKey;
        }
    }
}