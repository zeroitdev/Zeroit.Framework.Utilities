// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DefaultDateToOrdinalWordConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.DateToOrdinalWords
{
    /// <summary>
    /// Class DefaultDateToOrdinalWordConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.DateToOrdinalWords.IDateToOrdinalWordConverter" />
    internal class DefaultDateToOrdinalWordConverter : IDateToOrdinalWordConverter
    {

        /// <summary>
        /// Converts the date to Ordinal Words
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public virtual string Convert(DateTime date)
        {
            return date.Day.Ordinalize() + date.ToString(" MMMM yyyy");
        }

        /// <summary>
        /// Converts the date to Ordinal Words using the provided grammatical case
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="grammaticalCase">The grammatical case.</param>
        /// <returns>System.String.</returns>
        public virtual string Convert(DateTime date, GrammaticalCase grammaticalCase)
        {
            return Convert(date);
        }
        
    }
}