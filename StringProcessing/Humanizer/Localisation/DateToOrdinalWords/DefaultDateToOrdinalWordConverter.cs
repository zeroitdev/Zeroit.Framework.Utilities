// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="DefaultDateToOrdinalWordConverter.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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