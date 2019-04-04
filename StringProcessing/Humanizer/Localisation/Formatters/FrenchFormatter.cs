// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="FrenchFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    /// <summary>
    /// Class FrenchFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.DefaultFormatter" />
    internal class FrenchFormatter : DefaultFormatter
    {
        /// <summary>
        /// The dual postfix
        /// </summary>
        private const string DualPostfix = "_Dual";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="localeCode">Name of the culture to use.</param>
        public FrenchFormatter(string localeCode)
            : base(localeCode)
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
            if (number == 2 && (resourceKey == "DateHumanize_MultipleDaysAgo" || resourceKey == "DateHumanize_MultipleDaysFromNow"))
                return resourceKey + DualPostfix;

            return resourceKey;
        }
    }
}
