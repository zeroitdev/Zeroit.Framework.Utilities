// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="Truncator.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Gets a ITruncator
    /// </summary>
    public static class Truncator
    {
        /// <summary>
        /// Fixed length truncator
        /// </summary>
        /// <value>The length of the fixed.</value>
        public static ITruncator FixedLength
        {
            get
            {
                return new FixedLengthTruncator();
            }
        }

        /// <summary>
        /// Fixed number of characters truncator
        /// </summary>
        /// <value>The fixed number of characters.</value>
        public static ITruncator FixedNumberOfCharacters
        {
            get
            {
                return new FixedNumberOfCharactersTruncator();
            }
        }

        /// <summary>
        /// Fixed number of words truncator
        /// </summary>
        /// <value>The fixed number of words.</value>
        public static ITruncator FixedNumberOfWords
        {
            get
            {
                return new FixedNumberOfWordsTruncator();
            }
        }
    }
}
