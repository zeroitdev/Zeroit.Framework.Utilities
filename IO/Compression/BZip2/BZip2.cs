// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BZip2.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.IO;

namespace Zeroit.Framework.Utilities.IO.Compression.BZip2
{

    /// <summary>
    /// Does all the compress and decompress pre-operation stuff.
    /// Sets up the streams and file header characters.
    /// Uses multiply overloaded methods to call for the compress/decompress.
    /// </summary>
    public sealed class BZip2
	{
        /// <summary>
        /// Decompress <paramref name="instream">input</paramref> writing
        /// decompressed data to <paramref name="outstream">output stream</paramref>
        /// </summary>
        /// <param name="instream">The instream.</param>
        /// <param name="outstream">The outstream.</param>
        public static void Decompress(Stream instream, Stream outstream) 
		{
			System.IO.Stream bos = outstream;
			System.IO.Stream bis = instream;
			BZip2InputStream bzis = new BZip2InputStream(bis);
			int ch = bzis.ReadByte();
			while (ch != -1) {
				bos.WriteByte((byte)ch);
				ch = bzis.ReadByte();
			}
			bos.Flush();
		}

        /// <summary>
        /// Compress <paramref name="instream">input stream</paramref> sending
        /// result to <paramref name="outputstream">output stream</paramref>
        /// </summary>
        /// <param name="instream">The instream.</param>
        /// <param name="outstream">The outstream.</param>
        /// <param name="blockSize">Size of the block.</param>
        public static void Compress(Stream instream, Stream outstream, int blockSize) 
		{			
			System.IO.Stream bos = outstream;
			System.IO.Stream bis = instream;
			int ch = bis.ReadByte();
			BZip2OutputStream bzos = new BZip2OutputStream(bos, blockSize);
			while (ch != -1) {
				bzos.WriteByte((byte)ch);
				ch = bis.ReadByte();
			}
			bis.Close();
			bzos.Close();
		}
	}
}

/* derived from a file which contained this license :
 * Copyright (c) 1999-2001 Keiron Liddle, Aftex Software
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
*/
