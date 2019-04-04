// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BZip2Exception.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.BZip2
{
    /// <summary>
    /// BZip2Exception represents exceptions specific to Bzip2 algorithm
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SharpZipBaseException" />
    public class BZip2Exception : SharpZipBaseException
	{
        /// <summary>
        /// Initialise a new instance of BZip2Exception.
        /// </summary>
        public BZip2Exception()
		{
		}

        /// <summary>
        /// Initialise a new instance of BZip2Exception with its message set to message.
        /// </summary>
        /// <param name="message">The message describing the error.</param>
        public BZip2Exception(string message) : base(message)
		{
		}
		
	}
}
