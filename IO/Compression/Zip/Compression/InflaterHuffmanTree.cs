// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="InflaterHuffmanTree.cs" company="Zeroit Dev Technologies">
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
    /// Huffman tree used for inflation
    /// </summary>
    public class InflaterHuffmanTree 
	{
        /// <summary>
        /// The maximum bitlen
        /// </summary>
        static int MAX_BITLEN = 15;
        /// <summary>
        /// The tree
        /// </summary>
        short[] tree;

        /// <summary>
        /// Literal length tree
        /// </summary>
        public static InflaterHuffmanTree defLitLenTree;

        /// <summary>
        /// Distance tree
        /// </summary>
        public static InflaterHuffmanTree defDistTree;

        /// <summary>
        /// Initializes static members of the <see cref="InflaterHuffmanTree"/> class.
        /// </summary>
        /// <exception cref="SharpZipBaseException">InflaterHuffmanTree: static tree length illegal</exception>
        static InflaterHuffmanTree()
		{
			try {
				byte[] codeLengths = new byte[288];
				int i = 0;
				while (i < 144) {
					codeLengths[i++] = 8;
				}
				while (i < 256) {
					codeLengths[i++] = 9;
				}
				while (i < 280) {
					codeLengths[i++] = 7;
				}
				while (i < 288) {
					codeLengths[i++] = 8;
				}
				defLitLenTree = new InflaterHuffmanTree(codeLengths);
				
				codeLengths = new byte[32];
				i = 0;
				while (i < 32) {
					codeLengths[i++] = 5;
				}
				defDistTree = new InflaterHuffmanTree(codeLengths);
			} catch (Exception) {
				throw new SharpZipBaseException("InflaterHuffmanTree: static tree length illegal");
			}
		}

        /// <summary>
        /// Constructs a Huffman tree from the array of code lengths.
        /// </summary>
        /// <param name="codeLengths">the array of code lengths</param>
        public InflaterHuffmanTree(byte[] codeLengths)
		{
			BuildTree(codeLengths);
		}

        /// <summary>
        /// Builds the tree.
        /// </summary>
        /// <param name="codeLengths">The code lengths.</param>
        void BuildTree(byte[] codeLengths)
		{
			int[] blCount  = new int[MAX_BITLEN + 1];
			int[] nextCode = new int[MAX_BITLEN + 1];
			
			for (int i = 0; i < codeLengths.Length; i++) {
				int bits = codeLengths[i];
				if (bits > 0) {
					blCount[bits]++;
				}
			}
			
			int code = 0;
			int treeSize = 512;
			for (int bits = 1; bits <= MAX_BITLEN; bits++) {
				nextCode[bits] = code;
				code += blCount[bits] << (16 - bits);
				if (bits >= 10) {
					/* We need an extra table for bit lengths >= 10. */
					int start = nextCode[bits] & 0x1ff80;
					int end   = code & 0x1ff80;
					treeSize += (end - start) >> (16 - bits);
				}
			}
			
/* -jr comment this out! doesnt work for dynamic trees and pkzip 2.04g
			if (code != 65536) 
			{
				throw new SharpZipBaseException("Code lengths don't add up properly.");
			}
*/
			/* Now create and fill the extra tables from longest to shortest
			* bit len.  This way the sub trees will be aligned.
			*/
			tree = new short[treeSize];
			int treePtr = 512;
			for (int bits = MAX_BITLEN; bits >= 10; bits--) {
				int end   = code & 0x1ff80;
				code -= blCount[bits] << (16 - bits);
				int start = code & 0x1ff80;
				for (int i = start; i < end; i += 1 << 7) {
					tree[DeflaterHuffman.BitReverse(i)] = (short) ((-treePtr << 4) | bits);
					treePtr += 1 << (bits-9);
				}
			}
			
			for (int i = 0; i < codeLengths.Length; i++) {
				int bits = codeLengths[i];
				if (bits == 0) {
					continue;
				}
				code = nextCode[bits];
				int revcode = DeflaterHuffman.BitReverse(code);
				if (bits <= 9) {
					do {
						tree[revcode] = (short) ((i << 4) | bits);
						revcode += 1 << bits;
					} while (revcode < 512);
				} else {
					int subTree = tree[revcode & 511];
					int treeLen = 1 << (subTree & 15);
					subTree = -(subTree >> 4);
					do {
						tree[subTree | (revcode >> 9)] = (short) ((i << 4) | bits);
						revcode += 1 << bits;
					} while (revcode < treeLen);
				}
				nextCode[bits] = code + (1 << (16 - bits));
			}
			
		}

        /// <summary>
        /// Reads the next symbol from input.  The symbol is encoded using the
        /// huffman tree.
        /// </summary>
        /// <param name="input">input the input source.</param>
        /// <returns>the next symbol, or -1 if not enough input is available.</returns>
        public int GetSymbol(StreamManipulator input)
		{
			int lookahead, symbol;
			if ((lookahead = input.PeekBits(9)) >= 0) {
				if ((symbol = tree[lookahead]) >= 0) {
					input.DropBits(symbol & 15);
					return symbol >> 4;
				}
				int subtree = -(symbol >> 4);
				int bitlen = symbol & 15;
				if ((lookahead = input.PeekBits(bitlen)) >= 0) {
					symbol = tree[subtree | (lookahead >> 9)];
					input.DropBits(symbol & 15);
					return symbol >> 4;
				} else {
					int bits = input.AvailableBits;
					lookahead = input.PeekBits(bits);
					symbol = tree[subtree | (lookahead >> 9)];
					if ((symbol & 15) <= bits) {
						input.DropBits(symbol & 15);
						return symbol >> 4;
					} else {
						return -1;
					}
				}
			} else {
				int bits = input.AvailableBits;
				lookahead = input.PeekBits(bits);
				symbol = tree[lookahead];
				if (symbol >= 0 && (symbol & 15) <= bits) {
					input.DropBits(symbol & 15);
					return symbol >> 4;
				} else {
					return -1;
				}
			}
		}
	}
}

