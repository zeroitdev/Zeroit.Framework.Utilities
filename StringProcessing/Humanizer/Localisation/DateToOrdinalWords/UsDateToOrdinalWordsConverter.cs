// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="UsDateToOrdinalWordsConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.DateToOrdinalWords
{
    /// <summary>
    /// Class UsDateToOrdinalWordsConverter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.DateToOrdinalWords.DefaultDateToOrdinalWordConverter" />
    internal class UsDateToOrdinalWordsConverter : DefaultDateToOrdinalWordConverter
    {
        /// <summary>
        /// Converts the date to Ordinal Words
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public override string Convert(DateTime date)
        {
            return date.ToString("MMMM ") + date.Day.Ordinalize() + date.ToString(", yyyy");
        }
    }
}