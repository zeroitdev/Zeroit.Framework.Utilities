// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Remove.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        /// <summary>
        /// Removes from left.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string RemoveFromLeft(string Source, int Length)
        {
            if (Length >= Source.Length)
                return string.Empty;
            return Source.Substring(Length, Source.Length - Length);
        }
        /// <summary>
        /// Removes from right.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string RemoveFromRight(string Source, int Length)
        {
            if (Length >= Source.Length)
                return string.Empty;
            return Source.Substring(0, Source.Length - Length);
        }

    }
}
