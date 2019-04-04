// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="SharpZipBaseException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
