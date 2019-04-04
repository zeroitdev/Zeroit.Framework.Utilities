// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="OxfordStyleCollectionFormatter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.CollectionFormatters
{
    /// <summary>
    /// Class OxfordStyleCollectionFormatter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.CollectionFormatters.DefaultCollectionFormatter" />
    internal class OxfordStyleCollectionFormatter : DefaultCollectionFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OxfordStyleCollectionFormatter"/> class.
        /// </summary>
        /// <param name="defaultSeparator">The default separator.</param>
        public OxfordStyleCollectionFormatter(string defaultSeparator)
            : base(defaultSeparator ?? "and")
        {
        }

        /// <summary>
        /// Gets the conjunction format string.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        /// <returns>System.String.</returns>
        protected override string GetConjunctionFormatString(int itemCount) => itemCount > 2 ? "{0}, {1} {2}" : "{0} {1} {2}";
    }
}