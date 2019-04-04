// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="SlovenianFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    /// <summary>
    /// Class SlovenianFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.DefaultFormatter" />
    internal class SlovenianFormatter : DefaultFormatter
    {
        /// <summary>
        /// The dual postfix
        /// </summary>
        private const string DualPostfix = "_Dual";
        /// <summary>
        /// The trial quadral postfix
        /// </summary>
        private const string TrialQuadralPostfix = "_TrialQuadral";

        /// <summary>
        /// Initializes a new instance of the <see cref="SlovenianFormatter"/> class.
        /// </summary>
        public SlovenianFormatter()
            : base("sl")
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
            if (number == 2)
                return resourceKey + DualPostfix;
            
            // When the count is three or four some some words have a different form when counting in Slovenian language
            if (number == 3 || number == 4)
                return resourceKey + TrialQuadralPostfix;

            return resourceKey;
        }
    }
}
