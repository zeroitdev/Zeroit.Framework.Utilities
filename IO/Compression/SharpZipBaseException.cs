// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="SharpZipBaseException.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression
{
    /// <summary>
    /// SharpZipBaseException is the base exception class for the SharpZipLibrary.
    /// All library exceptions are derived from this.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public class SharpZipBaseException : ApplicationException
	{
        /// <summary>
        /// Initializes a new instance of the SharpZipLibraryException class.
        /// </summary>
        public SharpZipBaseException()
		{
		}

        /// <summary>
        /// Initializes a new instance of the SharpZipLibraryException class with a specified error message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public SharpZipBaseException(string msg) : base(msg)
		{
		}

        /// <summary>
        /// Initializes a new instance of the SharpZipLibraryException class with a specified
        /// error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">Error message string</param>
        /// <param name="innerException">The inner exception</param>
        public SharpZipBaseException(string message, Exception innerException)	: base(message, innerException)
		{
		}
	}
}
