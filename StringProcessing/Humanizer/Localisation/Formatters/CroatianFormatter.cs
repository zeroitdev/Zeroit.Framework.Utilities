// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="CroatianFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters
{
    /// <summary>
    /// Class CroatianFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.Formatters.DefaultFormatter" />
    internal class CroatianFormatter : DefaultFormatter
    {
        /// <summary>
        /// The dual trial quadral postfix
        /// </summary>
        private const string DualTrialQuadralPostfix = "_DualTrialQuadral";

        /// <summary>
        /// Initializes a new instance of the <see cref="CroatianFormatter"/> class.
        /// </summary>
        public CroatianFormatter()
            : base("hr")
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
            if ((number % 10 == 2 || number % 10 == 3 || number % 10 == 4) && number != 12 && number != 13 && number != 14)
                return resourceKey + DualTrialQuadralPostfix;

            return resourceKey;
        }
    }
}
