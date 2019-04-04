// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.Zip 
{

    /// <summary>
    /// Represents errors specific to Zip file handling
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SharpZipBaseException" />
    public class ZipException : SharpZipBaseException
	{
        /// <summary>
        /// Initializes a new instance of the ZipException class.
        /// </summary>
        public ZipException()
		{
		}

        /// <summary>
        /// Initializes a new instance of the ZipException class with a specified error message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public ZipException(string msg) : base(msg)
		{
		}
	}
}
