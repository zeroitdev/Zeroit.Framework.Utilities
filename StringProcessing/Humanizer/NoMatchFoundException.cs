// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="NoMatchFoundException.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// This is thrown on String.DehumanizeTo enum when the provided string cannot be mapped to the target enum
    /// </summary>
    /// <seealso cref="System.Exception" />
#pragma warning disable 1591
    public class NoMatchFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoMatchFoundException"/> class.
        /// </summary>
        public NoMatchFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoMatchFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NoMatchFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoMatchFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public NoMatchFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
#pragma warning restore 1591
}