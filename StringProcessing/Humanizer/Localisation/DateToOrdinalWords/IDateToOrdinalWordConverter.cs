// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="IDateToOrdinalWordConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.DateToOrdinalWords
{
    /// <summary>
    /// The interface used to localise the ToOrdinalWords method.
    /// </summary>
    public interface IDateToOrdinalWordConverter
    {
        /// <summary>
        /// Converts the date to Ordinal Words
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        string Convert(DateTime date);

        /// <summary>
        /// Converts the date to Ordinal Words using the provided grammatical case
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="grammaticalCase">The grammatical case.</param>
        /// <returns>System.String.</returns>
        string Convert(DateTime date, GrammaticalCase grammaticalCase);
    }
}
