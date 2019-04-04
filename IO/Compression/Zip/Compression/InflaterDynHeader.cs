// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="InflaterDynHeader.cs" company="Zeroit Dev Technologies">
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

using Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams;

namespace Zeroit.Framework.Utilities.IO.Compression.Zip.Compression 
{

    /// <summary>
    /// Class InflaterDynHeader.
    /// </summary>
    class InflaterDynHeader
	{
        /// <summary>
        /// The lnum
        /// </summary>
        const int LNUM   = 0;
        /// <summary>
        /// The dnum
        /// </summary>
        const int DNUM   = 1;
        /// <summary>
        /// The blnum
        /// </summary>
        const int BLNUM  = 2;
        /// <summary>
        /// The bllens
        /// </summary>
        const int BLLENS = 3;
        /// <summary>
        /// The lens
        /// </summary>
        const int LENS   = 4;
        /// <summary>
        /// The reps
        /// </summary>
        const int REPS   = 5;

        /// <summary>
        /// The rep minimum
        /// </summary>
        static readonly int[] repMin  = { 3, 3, 11 };
        /// <summary>
        /// The rep bits
        /// </summary>
        static readonly int[] repBits = { 2, 3,  7 };

        /// <summary>
        /// The bl lens
        /// </summary>
        byte[] blLens;
        /// <summary>
        /// The litdist lens
        /// </summary>
        byte[] litdistLens;

        /// <summary>
        /// The bl tree
        /// </summary>
        InflaterHuffmanTree blTree;

        /// <summary>
        /// The mode
        /// </summary>
        int mode;
        /// <summary>
        /// The lnum
        /// </summary>
        int lnum, dnum, blnum, num;
        /// <summary>
        /// The rep symbol
        /// </summary>
        int repSymbol;
        /// <summary>
        /// The last length
        /// </summary>
        byte lastLen;
        /// <summary>
        /// The PTR
        /// </summary>
        int ptr;

        /// <summary>
        /// The bl order
        /// </summary>
        static readonly int[] BL_ORDER = 
		{ 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };

        /// <summary>
        /// Initializes a new instance of the <see cref="InflaterDynHeader"/> class.
        /// </summary>
        public InflaterDynHeader()
		{
		}

        /// <summary>
        /// Decodes the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="SharpZipBaseException">
        /// </exception>
        public bool Decode(StreamManipulator input)
		{
			decode_loop:
				for (;;) {
					switch (mode) {
						case LNUM:
							lnum = input.PeekBits(5);
							if (lnum < 0) {
								return false;
							}
							lnum += 257;
							input.DropBits(5);
							//  	    System.err.println("LNUM: "+lnum);
							mode = DNUM;
							goto case DNUM; // fall through
						case DNUM:
							dnum = input.PeekBits(5);
							if (dnum < 0) {
								return false;
							}
							dnum++;
							input.DropBits(5);
							//  	    System.err.println("DNUM: "+dnum);
							num = lnum+dnum;
							litdistLens = new byte[num];
							mode = BLNUM;
							goto case BLNUM; // fall through
						case BLNUM:
							blnum = input.PeekBits(4);
							if (blnum < 0) {
								return false;
							}
							blnum += 4;
							input.DropBits(4);
							blLens = new byte[19];
							ptr = 0;
							//  	    System.err.println("BLNUM: "+blnum);
							mode = BLLENS;
							goto case BLLENS; // fall through
						case BLLENS:
							while (ptr < blnum) {
								int len = input.PeekBits(3);
								if (len < 0) {
									return false;
								}
								input.DropBits(3);
								//  		System.err.println("blLens["+BL_ORDER[ptr]+"]: "+len);
								blLens[BL_ORDER[ptr]] = (byte) len;
								ptr++;
							}
							blTree = new InflaterHuffmanTree(blLens);
							blLens = null;
							ptr = 0;
							mode = LENS;
							goto case LENS; // fall through
						case LENS: 
						{
							int symbol;
							while (((symbol = blTree.GetSymbol(input)) & ~15) == 0) {
								/* Normal case: symbol in [0..15] */
							
								//  		  System.err.println("litdistLens["+ptr+"]: "+symbol);
								litdistLens[ptr++] = lastLen = (byte)symbol;
							
								if (ptr == num) {
									/* Finished */
									return true;
								}
							}
						
							/* need more input ? */
							if (symbol < 0) {
								return false;
							}
						
							/* otherwise repeat code */
							if (symbol >= 17) {
								/* repeat zero */
								//  		  System.err.println("repeating zero");
								lastLen = 0;
							} else {
								if (ptr == 0) {
									throw new SharpZipBaseException();
								}
							}
							repSymbol = symbol-16;
						}
							mode = REPS;
							goto case REPS; // fall through
						case REPS:
						{
							int bits = repBits[repSymbol];
							int count = input.PeekBits(bits);
							if (count < 0) {
								return false;
							}
							input.DropBits(bits);
							count += repMin[repSymbol];
							//  	      System.err.println("litdistLens repeated: "+count);
							
							if (ptr + count > num) {
								throw new SharpZipBaseException();
							}
							while (count-- > 0) {
								litdistLens[ptr++] = lastLen;
							}
							
							if (ptr == num) {
								/* Finished */
								return true;
							}
						}
							mode = LENS;
							goto decode_loop;
					}
				}
		}

        /// <summary>
        /// Builds the lit length tree.
        /// </summary>
        /// <returns>InflaterHuffmanTree.</returns>
        public InflaterHuffmanTree BuildLitLenTree()
		{
			byte[] litlenLens = new byte[lnum];
			Array.Copy(litdistLens, 0, litlenLens, 0, lnum);
			return new InflaterHuffmanTree(litlenLens);
		}

        /// <summary>
        /// Builds the dist tree.
        /// </summary>
        /// <returns>InflaterHuffmanTree.</returns>
        public InflaterHuffmanTree BuildDistTree()
		{
			byte[] distLens = new byte[dnum];
			Array.Copy(litdistLens, lnum, distLens, 0, dnum);
			return new InflaterHuffmanTree(distLens);
		}
	}
}
