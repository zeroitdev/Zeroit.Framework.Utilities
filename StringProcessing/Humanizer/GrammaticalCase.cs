// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="GrammaticalCase.cs" company="Zeroit Dev Technologies">
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
    /// Options for specifying the desired grammatical case for the output words
    /// </summary>
    public enum GrammaticalCase
    {
        /// <summary>
        /// Indicates the subject of a finite verb
        /// </summary>
        Nominative,
        /// <summary>
        /// Indicates the possessor of another noun
        /// </summary>
        Genitive,
        /// <summary>
        /// Indicates the indirect object of a verb
        /// </summary>
        Dative,
        /// <summary>
        /// Indicates the direct object of a verb
        /// </summary>
        Accusative,
        /// <summary>
        /// Indicates an object used in performing an action
        /// </summary>
        Instrumental,
        /// <summary>
        /// Indicates the object of a preposition
        /// </summary>
        Prepositional,
    }
}