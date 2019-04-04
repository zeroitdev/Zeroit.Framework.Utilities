// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="InvalidHeaderException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.Tar {

    /// <summary>
    /// This exception is used to indicate that there is a problem
    /// with a TAR archive header.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Tar.TarException" />
    public class InvalidHeaderException : TarException
	{
        /// <summary>
        /// Initialise a new instance of the InvalidHeaderException class.
        /// </summary>
        public InvalidHeaderException()
		{
		}

        /// <summary>
        /// Initialises a new instance of the InvalidHeaderException class with a specified message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public InvalidHeaderException(string msg) : base(msg)
		{
		}
	}
}

/* The original Java file had this header:
** Authored by Timothy Gerard Endres
** <mailto:time@gjt.org>  <http://www.trustice.com>
** 
** This work has been placed into the public domain.
** You may use this work in any way and for any purpose you wish.
**
** THIS SOFTWARE IS PROVIDED AS-IS WITHOUT WARRANTY OF ANY KIND,
** NOT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY. THE AUTHOR
** OF THIS SOFTWARE, ASSUMES _NO_ RESPONSIBILITY FOR ANY
** CONSEQUENCE RESULTING FROM THE USE, MODIFICATION, OR
** REDISTRIBUTION OF THIS SOFTWARE. 
** 
*/

