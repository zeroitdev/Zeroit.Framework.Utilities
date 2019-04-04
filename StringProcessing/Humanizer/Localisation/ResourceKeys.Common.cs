// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ResourceKeys.Common.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation
{
    /// <summary>
    /// Class ResourceKeys.
    /// </summary>
    public partial class ResourceKeys
    {
        /// <summary>
        /// The single
        /// </summary>
        private const string Single = "Single";
        /// <summary>
        /// The multiple
        /// </summary>
        private const string Multiple = "Multiple";

        /// <summary>
        /// Validates the range.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <exception cref="ArgumentOutOfRangeException">count</exception>
        private static void ValidateRange(int count)
        {
            if (count < 0) 
                throw new ArgumentOutOfRangeException(nameof(count));
        }
    }
}
