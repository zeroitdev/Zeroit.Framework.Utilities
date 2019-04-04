// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GZipException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.GZip
{
    /// <summary>
    /// GZipException represents a Gzip specific exception
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SharpZipBaseException" />
    public class GZipException : SharpZipBaseException
	{
        /// <summary>
        /// Initialise a new instance of GZipException
        /// </summary>
        public GZipException()
		{
		}

        /// <summary>
        /// Initialise a new instance of GZipException with its message string.
        /// </summary>
        /// <param name="message">A <see cref="string"></see>string that describes the error.</param>
        public GZipException(string message) : base(message)
		{
		}
	}
}
