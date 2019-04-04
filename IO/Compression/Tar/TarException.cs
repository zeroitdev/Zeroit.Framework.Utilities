// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TarException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.Tar {

    /// <summary>
    /// TarExceptions are used for exceptions specific to tar classes and code.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SharpZipBaseException" />
    public class TarException : SharpZipBaseException
	{
        /// <summary>
        /// Initialises a new instance of the TarException class.
        /// </summary>
        public TarException()
		{
		}

        /// <summary>
        /// Initialises a new instance of the TarException class with a specified message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TarException(string message) : base(message)
		{
		}
	}
}
