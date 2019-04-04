// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="BZip2OutputStream.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.IO;

using Zeroit.Framework.Utilities.IO.Compression.Checksums;

namespace Zeroit.Framework.Utilities.IO.Compression.BZip2 
{

    // TODO: Update to BZip2 1.0.1, 1.0.2

    /// <summary>
    /// An output stream that compresses into the BZip2 format
    /// including file header chars into another stream.
    /// </summary>
    /// <seealso cref="System.IO.Stream" />
    public class BZip2OutputStream : Stream
	{
        /// <summary>
        /// Gets a value indicating whether the current stream supports reading
        /// </summary>
        /// <value><c>true</c> if this instance can read; otherwise, <c>false</c>.</value>
        public override bool CanRead {
			get {
				return false;
			}
		}

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking
        /// </summary>
        /// <value><c>true</c> if this instance can seek; otherwise, <c>false</c>.</value>
        public override bool CanSeek {
			get {
				return false;
			}
		}

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing
        /// </summary>
        /// <value><c>true</c> if this instance can write; otherwise, <c>false</c>.</value>
        public override bool CanWrite {
			get {
				return baseStream.CanWrite;
			}
		}

        /// <summary>
        /// Gets the length in bytes of the stream
        /// </summary>
        /// <value>The length.</value>
        public override long Length {
			get {
				return baseStream.Length;
			}
		}

        /// <summary>
        /// Gets or sets the current position of this stream.
        /// </summary>
        /// <value>The position.</value>
        /// <exception cref="NotSupportedException">BZip2OutputStream position cannot be set</exception>
        public override long Position {
			get {
				return baseStream.Position;
			}
			set {
				throw new NotSupportedException("BZip2OutputStream position cannot be set");
			}
		}

        /// <summary>
        /// Sets the current position of this stream to the given value.
        /// </summary>
        /// <param name="offset">A byte offset relative to the <paramref name="origin" /> parameter.</param>
        /// <param name="origin">A value of type <see cref="T:System.IO.SeekOrigin" /> indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        /// <exception cref="NotSupportedException">BZip2OutputStream Seek not supported</exception>
        public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("BZip2OutputStream Seek not supported");
		}

        /// <summary>
        /// Sets the length of this stream to the given value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <exception cref="NotSupportedException">BZip2OutputStream SetLength not supported</exception>
        public override void SetLength(long val)
		{
			throw new NotSupportedException("BZip2OutputStream SetLength not supported");
		}

        /// <summary>
        /// Read a byte from the stream advancing the position.
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
        /// <exception cref="NotSupportedException">BZip2OutputStream ReadByte not supported</exception>
        public override int ReadByte()
		{
			throw new NotSupportedException("BZip2OutputStream ReadByte not supported");
		}

        /// <summary>
        /// Read a block of bytes
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="off">The off.</param>
        /// <param name="len">The length.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="NotSupportedException">BZip2OutputStream Read not supported</exception>
        public override int Read(byte[] b, int off, int len)
		{
			throw new NotSupportedException("BZip2OutputStream Read not supported");
		}

        /// <summary>
        /// Write a block of bytes to the stream
        /// </summary>
        /// <param name="buf">The buf.</param>
        /// <param name="off">The off.</param>
        /// <param name="len">The length.</param>
        public override void Write(byte[] buf, int off, int len)
		{
			for (int i = 0; i < len; ++i) {
				WriteByte(buf[off + i]);
			}
		}

        /// <summary>
        /// The setmask
        /// </summary>
        readonly static int SETMASK       = (1 << 21);
        /// <summary>
        /// The clearmask
        /// </summary>
        readonly static int CLEARMASK     = (~SETMASK);
        /// <summary>
        /// The greater icost
        /// </summary>
        readonly static int GREATER_ICOST = 15;
        /// <summary>
        /// The lesser icost
        /// </summary>
        readonly static int LESSER_ICOST  = 0;
        /// <summary>
        /// The small thresh
        /// </summary>
        readonly static int SMALL_THRESH  = 20;
        /// <summary>
        /// The depth thresh
        /// </summary>
        readonly static int DEPTH_THRESH  = 10;

        /*--
		If you are ever unlucky/improbable enough
		to get a stack overflow whilst sorting,
		increase the following constant and try
		again.  In practice I have never seen the
		stack go above 27 elems, so the following
		limit seems very generous.
		--*/
        /// <summary>
        /// The qsort stack size
        /// </summary>
        readonly static int QSORT_STACK_SIZE = 1000;

        /// <summary>
        /// Panics this instance.
        /// </summary>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.BZip2.BZip2Exception">BZip2 output stream panic</exception>
        static void Panic() 
		{
			throw new BZip2Exception("BZip2 output stream panic");
		}

        /// <summary>
        /// Makes the maps.
        /// </summary>
        void MakeMaps() 
		{
			int i;
			nInUse = 0;
			for (i = 0; i < 256; i++) {
				if (inUse[i]) {
					seqToUnseq[nInUse] = (char)i;
					unseqToSeq[i] = (char)nInUse;
					nInUse++;
				}
			}
		}

        /// <summary>
        /// Hbs the make code lengths.
        /// </summary>
        /// <param name="len">The length.</param>
        /// <param name="freq">The freq.</param>
        /// <param name="alphaSize">Size of the alpha.</param>
        /// <param name="maxLen">The maximum length.</param>
        static void HbMakeCodeLengths(char[] len, int[] freq, int alphaSize, int maxLen) 
		{
			/*--
			Nodes and heap entries run from 1.  Entry 0
			for both the heap and nodes is a sentinel.
			--*/
			int nNodes, nHeap, n1, n2, j, k;
			bool  tooLong;
			
			int[] heap   = new int[BZip2Constants.MAX_ALPHA_SIZE + 2];
			int[] weight = new int[BZip2Constants.MAX_ALPHA_SIZE * 2];
			int[] parent = new int[BZip2Constants.MAX_ALPHA_SIZE * 2];
			
			for (int i = 0; i < alphaSize; ++i) {
				weight[i+1] = (freq[i] == 0 ? 1 : freq[i]) << 8;
			}
			
			while (true) {
				nNodes = alphaSize;
				nHeap = 0;
				
				heap[0] = 0;
				weight[0] = 0;
				parent[0] = -2;
				
				for (int i = 1; i <= alphaSize; ++i) {
					parent[i] = -1;
					nHeap++;
					heap[nHeap] = i;
					int zz = nHeap;
					int tmp = heap[zz];
					while (weight[tmp] < weight[heap[zz >> 1]]) {
						heap[zz] = heap[zz >> 1];
						zz >>= 1;
					}
					heap[zz] = tmp;
				}
				if (!(nHeap < (BZip2Constants.MAX_ALPHA_SIZE+2))) {
					Panic();
				}
				
				while (nHeap > 1) {
					n1 = heap[1];
					heap[1] = heap[nHeap];
					nHeap--;
					int zz = 1;
					int yy = 0;
					int tmp = heap[zz];
					while (true) {
						yy = zz << 1;
						if (yy > nHeap) {
							break;
						}
						if (yy < nHeap &&  weight[heap[yy+1]] < weight[heap[yy]]) {
							yy++;
						}
						if (weight[tmp] < weight[heap[yy]]) {
							break;
						}
						
						heap[zz] = heap[yy];
						zz = yy;
					}
					heap[zz] = tmp;
					n2 = heap[1];
					heap[1] = heap[nHeap];
					nHeap--;
					
					zz = 1;
					yy = 0;
					tmp = heap[zz];
					while (true) {
						yy = zz << 1;
						if (yy > nHeap) {
							break;
						}
						if (yy < nHeap && weight[heap[yy+1]] < weight[heap[yy]]) {
							yy++;
						}
						if (weight[tmp] < weight[heap[yy]]) {
							break;
						}
						heap[zz] = heap[yy];
						zz = yy;
					}
					heap[zz] = tmp;
					nNodes++;
					parent[n1] = parent[n2] = nNodes;
					
					weight[nNodes] = (int)((weight[n1] & 0xffffff00) + (weight[n2] & 0xffffff00)) | 
					                 (int)(1 + (((weight[n1] & 0x000000ff) > (weight[n2] & 0x000000ff)) ? (weight[n1] & 0x000000ff) : (weight[n2] & 0x000000ff)));
					
					parent[nNodes] = -1;
					nHeap++;
					heap[nHeap] = nNodes;
					
					zz  = nHeap;
					tmp = heap[zz];
					while (weight[tmp] < weight[heap[zz >> 1]]) {
						heap[zz] = heap[zz >> 1];
						zz >>= 1;
					}
					heap[zz] = tmp;
				}
				if (!(nNodes < (BZip2Constants.MAX_ALPHA_SIZE * 2))) {
					Panic();
				}
				
				tooLong = false;
				for (int i = 1; i <= alphaSize; ++i) {
					j = 0;
					k = i;
					while (parent[k] >= 0) {
						k = parent[k];
						j++;
					}
					len[i - 1] = (char)j;
					if (j > maxLen) {
						tooLong = true;
					}
				}
				
				if (!tooLong) {
					break;
				}
				
				for (int i = 1; i < alphaSize; ++i) {
					j = weight[i] >> 8;
					j = 1 + (j / 2);
					weight[i] = j << 8;
				}
			}
		}

        /*--
		index of the last char in the block, so
		the block size == last + 1.
		--*/
        /// <summary>
        /// The last
        /// </summary>
        int last;

        /*--
		index in zptr[] of original string after sorting.
		--*/
        /// <summary>
        /// The original PTR
        /// </summary>
        int origPtr;

        /*--
		always: in the range 0 .. 9.
		The current block size is 100000 * this number.
		--*/
        /// <summary>
        /// The block size100k
        /// </summary>
        int blockSize100k;

        /// <summary>
        /// The block randomised
        /// </summary>
        bool blockRandomised;

        /// <summary>
        /// The bytes out
        /// </summary>
        int bytesOut;
        /// <summary>
        /// The bs buff
        /// </summary>
        int bsBuff;
        /// <summary>
        /// The bs live
        /// </summary>
        int bsLive;
        /// <summary>
        /// The m CRC
        /// </summary>
        IChecksum mCrc = new StrangeCRC();

        /// <summary>
        /// The in use
        /// </summary>
        bool[] inUse = new bool[256];
        /// <summary>
        /// The n in use
        /// </summary>
        int nInUse;

        /// <summary>
        /// The seq to unseq
        /// </summary>
        char[] seqToUnseq = new char[256];
        /// <summary>
        /// The unseq to seq
        /// </summary>
        char[] unseqToSeq = new char[256];

        /// <summary>
        /// The selector
        /// </summary>
        char[] selector = new char[BZip2Constants.MAX_SELECTORS];
        /// <summary>
        /// The selector MTF
        /// </summary>
        char[] selectorMtf = new char[BZip2Constants.MAX_SELECTORS];

        /// <summary>
        /// The block
        /// </summary>
        byte[]  block;
        /// <summary>
        /// The quadrant
        /// </summary>
        int[]   quadrant;
        /// <summary>
        /// The ZPTR
        /// </summary>
        int[]   zptr;
        /// <summary>
        /// The SZPTR
        /// </summary>
        short[] szptr;
        /// <summary>
        /// The ftab
        /// </summary>
        int[]   ftab;

        /// <summary>
        /// The n MTF
        /// </summary>
        int nMTF;

        /// <summary>
        /// The MTF freq
        /// </summary>
        int[] mtfFreq = new int[BZip2Constants.MAX_ALPHA_SIZE];

        /*
		* Used when sorting.  If too many long comparisons
		* happen, we stop sorting, randomise the block
		* slightly, and try again.
		*/
        /// <summary>
        /// The work factor
        /// </summary>
        int workFactor;
        /// <summary>
        /// The work done
        /// </summary>
        int workDone;
        /// <summary>
        /// The work limit
        /// </summary>
        int workLimit;
        /// <summary>
        /// The first attempt
        /// </summary>
        bool firstAttempt;
        /// <summary>
        /// The n blocks randomised
        /// </summary>
        int nBlocksRandomised;

        /// <summary>
        /// The current character
        /// </summary>
        int currentChar = -1;
        /// <summary>
        /// The run length
        /// </summary>
        int runLength = 0;

        /// <summary>
        /// Construct a default output stream with maximum block size
        /// </summary>
        /// <param name="stream">The stream to write BZip data onto.</param>
        public BZip2OutputStream(Stream stream) : this(stream, 9)
		{
		}

        /// <summary>
        /// Initialise a new instance of the <see cref="BZip2OutputStream"></see>
        /// for the specified stream, using the given blocksize.
        /// </summary>
        /// <param name="stream">The stream to write compressed data to.</param>
        /// <param name="blockSize">The block size to use.</param>
        /// <remarks>Valid block sizes are in the range 1..9, with 1 giving
        /// the lowest compression and 9 the highest.</remarks>
        public BZip2OutputStream(Stream stream, int blockSize)
		{
			block    = null;
			quadrant = null;
			zptr     = null;
			ftab     = null;
			
			BsSetStream(stream);
			
			workFactor = 50;
			if (blockSize > 9) {
				blockSize = 9;
			}
			if (blockSize < 1) {
				blockSize = 1;
			}
			blockSize100k = blockSize;
			AllocateCompressStructures();
			Initialize();
			InitBlock();
		}

        /// <summary>
        /// Write a byte to the stream.
        /// </summary>
        /// <param name="bv">The bv.</param>
        public override void WriteByte(byte bv)
		{
			int b = (256 + bv) % 256;
			if (currentChar != -1) {
				if (currentChar == b) {
					runLength++;
					if (runLength > 254) {
						WriteRun();
						currentChar = -1;
						runLength = 0;
					}
				} else {
					WriteRun();
					runLength = 1;
					currentChar = b;
				}
			} else {
				currentChar = b;
				runLength++;
			}
		}

        /// <summary>
        /// Writes the run.
        /// </summary>
        void WriteRun()
		{
			if (last < allowableBlockSize) {
				inUse[currentChar] = true;
				for (int i = 0; i < runLength; i++) {
					mCrc.Update(currentChar);
				}
				
				switch (runLength) {
					case 1:
						last++;
						block[last + 1] = (byte)currentChar;
						break;
					case 2:
						last++;
						block[last + 1] = (byte)currentChar;
						last++;
						block[last + 1] = (byte)currentChar;
						break;
					case 3:
						last++;
						block[last + 1] = (byte)currentChar;
						last++;
						block[last + 1] = (byte)currentChar;
						last++;
						block[last + 1] = (byte)currentChar;
						break;
					default:
						inUse[runLength - 4] = true;
						last++;
						block[last + 1] = (byte)currentChar;
						last++;
						block[last + 1] = (byte)currentChar;
						last++;
						block[last + 1] = (byte)currentChar;
						last++;
						block[last + 1] = (byte)currentChar;
						last++;
						block[last + 1] = (byte)(runLength - 4);
						break;
				}
			} else {
				EndBlock();
				InitBlock();
				WriteRun();
			}
		}

        /// <summary>
        /// The closed
        /// </summary>
        bool closed = false;

        /// <summary>
        /// Free any resources and other cleanup before garbage collection reclaims memory
        /// </summary>
        ~BZip2OutputStream()
		{
			Close();
		}

        /// <summary>
        /// End the current block and end compression.
        /// Close the stream and free any resources
        /// </summary>
        public override void Close()
		{
			if (!closed) {
				closed = true;
			
				if (runLength > 0) {
					WriteRun();
				}
			
				currentChar = -1;
				EndBlock();
				EndCompression();
				Flush();
				baseStream.Close();
			}
		}

        /// <summary>
        /// Flush output buffers
        /// </summary>
        public override void Flush()
		{
			baseStream.Flush();
		}

        /// <summary>
        /// The block CRC
        /// </summary>
        uint blockCRC, combinedCRC;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize()
		{
			bytesOut = 0;
			nBlocksRandomised = 0;
			
			/*--- Write `magic' bytes h indicating file-format == huffmanised,
			followed by a digit indicating blockSize100k.
			---*/
			
			// TODO  adding header here should be optional?
			BsPutUChar('B');
			BsPutUChar('Z');
			
			BsPutUChar('h');
			BsPutUChar('0' + blockSize100k);
			
			combinedCRC = 0;
		}

        /// <summary>
        /// The allowable block size
        /// </summary>
        int allowableBlockSize;

        /// <summary>
        /// Initializes the block.
        /// </summary>
        void InitBlock() 
		{
			//		blockNo++;
			mCrc.Reset();
			last = -1;
			//		ch = 0;
			
			for (int i = 0; i < 256; i++) {
				inUse[i] = false;
			}
			
			/*--- 20 is just a paranoia constant ---*/
			allowableBlockSize = BZip2Constants.baseBlockSize * blockSize100k - 20;
		}

        /// <summary>
        /// Ends the block.
        /// </summary>
        void EndBlock()
		{
			if (last < 0) {       // dont do anything for empty files, (makes empty files compatible with original Bzip)
				return;
			}
			
			blockCRC = (uint)mCrc.Value;
			combinedCRC = (combinedCRC << 1) | (combinedCRC >> 31);
			combinedCRC ^= blockCRC;
			
			/*-- sort the block and establish posn of original string --*/
			DoReversibleTransformation();
			
			/*--
			A 6-byte block header, the value chosen arbitrarily
			as 0x314159265359 :-).  A 32 bit value does not really
			give a strong enough guarantee that the value will not
			appear by chance in the compressed datastream.  Worst-case
			probability of this event, for a 900k block, is about
			2.0e-3 for 32 bits, 1.0e-5 for 40 bits and 4.0e-8 for 48 bits.
			For a compressed file of size 100Gb -- about 100000 blocks --
			only a 48-bit marker will do.  NB: normal compression/
			decompression do *not* rely on these statistical properties.
			They are only important when trying to recover blocks from
			damaged files.
			--*/
			BsPutUChar(0x31);
			BsPutUChar(0x41);
			BsPutUChar(0x59);
			BsPutUChar(0x26);
			BsPutUChar(0x53);
			BsPutUChar(0x59);
			
			/*-- Now the block's CRC, so it is in a known place. --*/
			BsPutint((int)blockCRC);
			
			/*-- Now a single bit indicating randomisation. --*/
			if (blockRandomised) {
				BsW(1,1);
				nBlocksRandomised++;
			} else {
				BsW(1,0);
			}
			
			/*-- Finally, block's contents proper. --*/
			MoveToFrontCodeAndSend();
		}

        /// <summary>
        /// Ends the compression.
        /// </summary>
        void EndCompression()
		{
			/*--
			Now another magic 48-bit number, 0x177245385090, to
			indicate the end of the last block.  (sqrt(pi), if
			you want to know.  I did want to use e, but it contains
			too much repetition -- 27 18 28 18 28 46 -- for me
			to feel statistically comfortable.  Call me paranoid.)
			--*/
			BsPutUChar(0x17);
			BsPutUChar(0x72);
			BsPutUChar(0x45);
			BsPutUChar(0x38);
			BsPutUChar(0x50);
			BsPutUChar(0x90);
			
			BsPutint((int)combinedCRC);
			
			BsFinishedWithStream();
		}

        /// <summary>
        /// Hbs the assign codes.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="length">The length.</param>
        /// <param name="minLen">The minimum length.</param>
        /// <param name="maxLen">The maximum length.</param>
        /// <param name="alphaSize">Size of the alpha.</param>
        void HbAssignCodes (int[] code, char[] length, int minLen, int maxLen, int alphaSize) 
		{
			int vec = 0;
			for (int n = minLen; n <= maxLen; ++n) {
				for (int i = 0; i < alphaSize; ++i) {
					if (length[i] == n) {
						code[i] = vec;
						++vec;
					}
				}
				vec <<= 1;
			}
		}

        /// <summary>
        /// Bses the set stream.
        /// </summary>
        /// <param name="f">The f.</param>
        void BsSetStream(Stream f) 
		{
			baseStream = f;
			bsLive = 0;
			bsBuff = 0;
			bytesOut = 0;
		}

        /// <summary>
        /// Bses the finished with stream.
        /// </summary>
        void BsFinishedWithStream()
		{
			while (bsLive > 0) 
			{
				int ch = (bsBuff >> 24);
				baseStream.WriteByte((byte)ch); // write 8-bit
				bsBuff <<= 8;
				bsLive -= 8;
				bytesOut++;
			}
		}

        /// <summary>
        /// Bses the w.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="v">The v.</param>
        void BsW(int n, int v)
		{
			while (bsLive >= 8) {
				int ch = (bsBuff >> 24);
				baseStream.WriteByte((byte)ch); // write 8-bit
				bsBuff <<= 8;
				bsLive -= 8;
				++bytesOut;
			}
			bsBuff |= (v << (32 - bsLive - n));
			bsLive += n;
		}

        /// <summary>
        /// Bses the put u character.
        /// </summary>
        /// <param name="c">The c.</param>
        void BsPutUChar(int c)
		{
			BsW(8, c);
		}

        /// <summary>
        /// Bses the putint.
        /// </summary>
        /// <param name="u">The u.</param>
        void BsPutint(int u)
		{
			BsW(8, (u >> 24) & 0xFF);
			BsW(8, (u >> 16) & 0xFF);
			BsW(8, (u >>  8) & 0xFF);
			BsW(8,  u        & 0xFF);
		}

        /// <summary>
        /// Bses the put int vs.
        /// </summary>
        /// <param name="numBits">The number bits.</param>
        /// <param name="c">The c.</param>
        void BsPutIntVS(int numBits, int c)
		{
			BsW(numBits, c);
		}

        /// <summary>
        /// Sends the MTF values.
        /// </summary>
        void SendMTFValues()
		{
			char[][] len = new char[BZip2Constants.N_GROUPS][];
			for (int i = 0; i < BZip2Constants.N_GROUPS; ++i) {
				len[i] = new char[BZip2Constants.MAX_ALPHA_SIZE];
			}
			
			int gs, ge, totc, bt, bc, iter;
			int nSelectors = 0, alphaSize, minLen, maxLen, selCtr;
			int nGroups, nBytes;
			
			alphaSize = nInUse + 2;
			for (int t = 0; t < BZip2Constants.N_GROUPS; t++) {
				for (int v = 0; v < alphaSize; v++) {
					len[t][v] = (char)GREATER_ICOST;
				}
			}
			
			/*--- Decide how many coding tables to use ---*/
			if (nMTF <= 0) {
				Panic();
			}
			
			if (nMTF < 200) {
				nGroups = 2;
			} else if (nMTF < 600) {
				nGroups = 3;
			} else if (nMTF < 1200) {
				nGroups = 4;
			} else if (nMTF < 2400) {
				nGroups = 5;
			} else {
				nGroups = 6;
			}
			
			/*--- Generate an initial set of coding tables ---*/ 
			int nPart = nGroups;
			int remF  = nMTF;
			gs = 0;
			while (nPart > 0) {
				int tFreq = remF / nPart;
				int aFreq = 0;
				ge = gs - 1;
				while (aFreq < tFreq && ge < alphaSize - 1) {
					ge++;
					aFreq += mtfFreq[ge];
				}
				
				if (ge > gs && nPart != nGroups && nPart != 1 && ((nGroups - nPart) % 2 == 1)) {
					aFreq -= mtfFreq[ge];
					ge--;
				}
				
				for (int v = 0; v < alphaSize; v++) {
					if (v >= gs && v <= ge) {
						len[nPart - 1][v] = (char)LESSER_ICOST;
					} else {
						len[nPart - 1][v] = (char)GREATER_ICOST;
					}
				}
				
				nPart--;
				gs = ge + 1;
				remF -= aFreq;
			}
			
			int[][] rfreq = new int[BZip2Constants.N_GROUPS][];
			for (int i = 0; i < BZip2Constants.N_GROUPS; ++i) {
				rfreq[i] = new int[BZip2Constants.MAX_ALPHA_SIZE];
			}
			
			int[]   fave = new int[BZip2Constants.N_GROUPS];
			short[] cost = new short[BZip2Constants.N_GROUPS];
			/*---
			Iterate up to N_ITERS times to improve the tables.
			---*/
			for (iter = 0; iter < BZip2Constants.N_ITERS; ++iter) {
				for (int t = 0; t < nGroups; ++t) {
					fave[t] = 0;
				}
				
				for (int t = 0; t < nGroups; ++t) {
					for (int v = 0; v < alphaSize; ++v) {
						rfreq[t][v] = 0;
					}
				}
				
				nSelectors = 0;
				totc = 0;
				gs   = 0;
				while (true) {
					/*--- Set group start & end marks. --*/
					if (gs >= nMTF) {
						break;
					}
					ge = gs + BZip2Constants.G_SIZE - 1;
					if (ge >= nMTF) {
						ge = nMTF - 1;
					}
					
					/*--
					Calculate the cost of this group as coded
					by each of the coding tables.
					--*/
					for (int t = 0; t < nGroups; t++) {
						cost[t] = 0;
					}
					
					if (nGroups == 6) {
						short cost0, cost1, cost2, cost3, cost4, cost5;
						cost0 = cost1 = cost2 = cost3 = cost4 = cost5 = 0;
						for (int i = gs; i <= ge; ++i) {
							short icv = szptr[i];
							cost0 += (short)len[0][icv];
							cost1 += (short)len[1][icv];
							cost2 += (short)len[2][icv];
							cost3 += (short)len[3][icv];
							cost4 += (short)len[4][icv];
							cost5 += (short)len[5][icv];
						}
						cost[0] = cost0;
						cost[1] = cost1;
						cost[2] = cost2;
						cost[3] = cost3;
						cost[4] = cost4;
						cost[5] = cost5;
					} else {
						for (int i = gs; i <= ge; ++i) {
							short icv = szptr[i];
							for (int t = 0; t < nGroups; t++) {
								cost[t] += (short)len[t][icv];
							}
						}
					}
					
					/*--
					Find the coding table which is best for this group,
					and record its identity in the selector table.
					--*/
					bc = 999999999;
					bt = -1;
					for (int t = 0; t < nGroups; ++t) {
						if (cost[t] < bc) {
							bc = cost[t];
							bt = t;
						}
					}
					totc += bc;
					fave[bt]++;
					selector[nSelectors] = (char)bt;
					nSelectors++;
					
					/*--
					Increment the symbol frequencies for the selected table.
					--*/
					for (int i = gs; i <= ge; ++i) {
						++rfreq[bt][szptr[i]];
					}
					
					gs = ge+1;
				}
				
				/*--
				Recompute the tables based on the accumulated frequencies.
				--*/
				for (int t = 0; t < nGroups; ++t) {
					HbMakeCodeLengths(len[t], rfreq[t], alphaSize, 20);
				}
			}
			
			rfreq = null;
			fave = null;
			cost = null;
			
			if (!(nGroups < 8)) {
				Panic();
			}
			if (!(nSelectors < 32768 && nSelectors <= (2 + (900000 / BZip2Constants.G_SIZE)))) {
				Panic();
			}
			
			/*--- Compute MTF values for the selectors. ---*/
			char[] pos = new char[BZip2Constants.N_GROUPS];
			char ll_i, tmp2, tmp;
			for (int i = 0; i < nGroups; i++) {
				pos[i] = (char)i;
			}
			for (int i = 0; i < nSelectors; i++) {
				ll_i = selector[i];
				int j = 0;
				tmp = pos[j];
				while (ll_i != tmp) {
					j++;
					tmp2 = tmp;
					tmp = pos[j];
					pos[j] = tmp2;
				}
				pos[0] = tmp;
				selectorMtf[i] = (char)j;
			}
			
			int[][] code = new int[BZip2Constants.N_GROUPS][];
			
			for (int i = 0; i < BZip2Constants.N_GROUPS; ++i) {
				code[i] = new int[BZip2Constants.MAX_ALPHA_SIZE];
			}
			
			/*--- Assign actual codes for the tables. --*/
			for (int t = 0; t < nGroups; t++) {
				minLen = 32;
				maxLen = 0;
				for (int i = 0; i < alphaSize; i++) {
					if (len[t][i] > maxLen) {
						maxLen = len[t][i];
					}
					if (len[t][i] < minLen) {
						minLen = len[t][i];
					}
				}
				if (maxLen > 20) {
					Panic();
				}
				if (minLen < 1) {
					Panic();
				}
				HbAssignCodes(code[t], len[t], minLen, maxLen, alphaSize);
			}
			
			/*--- Transmit the mapping table. ---*/
			bool[] inUse16 = new bool[16];
			for (int i = 0; i < 16; ++i) {
				inUse16[i] = false;
				for (int j = 0; j < 16; ++j) {
					if (inUse[i * 16 + j]) {
						inUse16[i] = true; 
					}
				}
			}
			
			nBytes = bytesOut;
			for (int i = 0; i < 16; ++i) {
				if (inUse16[i]) {
					BsW(1,1);
				} else {
					BsW(1,0);
				}
			}
			
			for (int i = 0; i < 16; ++i) {
				if (inUse16[i]) {
					for (int j = 0; j < 16; ++j) {
						if (inUse[i * 16 + j]) {
							BsW(1,1);
						} else {
							BsW(1,0);
						}
					}
				}
			}
			
			/*--- Now the selectors. ---*/
			nBytes = bytesOut;
			BsW(3, nGroups);
			BsW(15, nSelectors);
			for (int i = 0; i < nSelectors; ++i) {
				for (int j = 0; j < selectorMtf[i]; ++j) {
					BsW(1,1);
				}
				BsW(1,0);
			}
			
			/*--- Now the coding tables. ---*/
			nBytes = bytesOut;
			
			for (int t = 0; t < nGroups; ++t) {
				int curr = len[t][0];
				BsW(5, curr);
				for (int i = 0; i < alphaSize; ++i) {
					while (curr < len[t][i]) {
						BsW(2, 2);
						curr++; /* 10 */
					}
					while (curr > len[t][i]) {
						BsW(2, 3);
						curr--; /* 11 */
					}
					BsW (1, 0);
				}
			}
			
			/*--- And finally, the block data proper ---*/
			nBytes = bytesOut;
			selCtr = 0;
			gs = 0;
			while (true) {
				if (gs >= nMTF) {
					break;
				}
				ge = gs + BZip2Constants.G_SIZE - 1;
				if (ge >= nMTF) {
					ge = nMTF - 1;
				}
				
				for (int i = gs; i <= ge; i++) {
					BsW(len[selector[selCtr]][szptr[i]], code[selector[selCtr]][szptr[i]]);
				}
				
				gs = ge + 1;
				++selCtr;
			}
			if (!(selCtr == nSelectors)) {
				Panic();
			}
		}

        /// <summary>
        /// Moves to front code and send.
        /// </summary>
        void MoveToFrontCodeAndSend () 
		{
			BsPutIntVS(24, origPtr);
			GenerateMTFValues();
			SendMTFValues();
		}

        /// <summary>
        /// The base stream
        /// </summary>
        Stream baseStream;

        /// <summary>
        /// Simples the sort.
        /// </summary>
        /// <param name="lo">The lo.</param>
        /// <param name="hi">The hi.</param>
        /// <param name="d">The d.</param>
        void SimpleSort(int lo, int hi, int d) 
		{
			int i, j, h, bigN, hp;
			int v;
			
			bigN = hi - lo + 1;
			if (bigN < 2) {
				return;
			}
			
			hp = 0;
			while (incs[hp] < bigN) {
				hp++;
			}
			hp--;
			
			for (; hp >= 0; hp--) {
				h = incs[hp];
				
				i = lo + h;
				while (true) {
					/*-- copy 1 --*/
					if (i > hi)
						break;
					v = zptr[i];
					j = i;
					while (FullGtU(zptr[j-h]+d, v+d)) {
						zptr[j] = zptr[j-h];
						j = j - h;
						if (j <= (lo + h - 1))
							break;
					}
					zptr[j] = v;
					i++;
					
					/*-- copy 2 --*/
					if (i > hi) {
						break;
					}
					v = zptr[i];
					j = i;
					while (FullGtU ( zptr[j-h]+d, v+d )) {
						zptr[j] = zptr[j-h];
						j = j - h;
						if (j <= (lo + h - 1)) {
							break;
						}
					}
					zptr[j] = v;
					i++;
					
					/*-- copy 3 --*/
					if (i > hi) {
						break;
					}
					v = zptr[i];
					j = i;
					while (FullGtU ( zptr[j-h]+d, v+d)) {
						zptr[j] = zptr[j-h];
						j = j - h;
						if (j <= (lo + h - 1)) {
							break;
						}
					}
					zptr[j] = v;
					i++;
					
					if (workDone > workLimit && firstAttempt) {
						return;
					}
				}
			}
		}

        /// <summary>
        /// Vswaps the specified p1.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="n">The n.</param>
        void Vswap(int p1, int p2, int n ) 
		{
			int temp = 0;
			while (n > 0) {
				temp = zptr[p1];
				zptr[p1] = zptr[p2];
				zptr[p2] = temp;
				p1++;
				p2++;
				n--;
			}
		}

        /// <summary>
        /// Med3s the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <returns>System.Byte.</returns>
        byte Med3(byte a, byte b, byte c ) 
		{
			byte t;
			if (a > b) {
				t = a;
				a = b;
				b = t;
			}
			if (b > c) {
				t = b;
				b = c;
				c = t;
			}
			if (a > b) {
				b = a;
			}
			return b;
		}

        /// <summary>
        /// Class StackElem.
        /// </summary>
        class StackElem 
		{
            /// <summary>
            /// The ll
            /// </summary>
            public int ll;
            /// <summary>
            /// The hh
            /// </summary>
            public int hh;
            /// <summary>
            /// The dd
            /// </summary>
            public int dd;
		}

        /// <summary>
        /// qs the sort3.
        /// </summary>
        /// <param name="loSt">The lo st.</param>
        /// <param name="hiSt">The hi st.</param>
        /// <param name="dSt">The d st.</param>
        void QSort3(int loSt, int hiSt, int dSt) 
		{
			int unLo, unHi, ltLo, gtHi, med, n, m;
			int sp, lo, hi, d;
			StackElem[] stack = new StackElem[QSORT_STACK_SIZE];
			for (int count = 0; count < QSORT_STACK_SIZE; count++) {
				stack[count] = new StackElem();
			}
			
			sp = 0;
			
			stack[sp].ll = loSt;
			stack[sp].hh = hiSt;
			stack[sp].dd = dSt;
			sp++;
			
			while (sp > 0) {
				if (sp >= QSORT_STACK_SIZE) {
					Panic();
				}
				
				sp--;
				lo = stack[sp].ll;
				hi = stack[sp].hh;
				d = stack[sp].dd;
				
				if (hi - lo < SMALL_THRESH || d > DEPTH_THRESH) {
					SimpleSort(lo, hi, d);
					if (workDone > workLimit && firstAttempt) {
						return;
					}
					continue;
				}
				
				med = Med3(block[zptr[lo] + d + 1],
				           block[zptr[hi            ] + d  + 1],
				           block[zptr[(lo + hi) >> 1] + d + 1]);
				
				unLo = ltLo = lo;
				unHi = gtHi = hi;
				
				while (true) {
					while (true) {
						if (unLo > unHi) {
							break;
						}
						n = ((int)block[zptr[unLo]+d + 1]) - med;
						if (n == 0) {
							int temp = 0;
							temp = zptr[unLo];
							zptr[unLo] = zptr[ltLo];
							zptr[ltLo] = temp;
							ltLo++;
							unLo++;
							continue;
						}
						if (n >  0) {
							break;
						}
						unLo++;
					}
					while (true) {
						if (unLo > unHi) {
							break;
						}
						n = ((int)block[zptr[unHi]+d + 1]) - med;
						if (n == 0) {
							int temp = 0;
							temp = zptr[unHi];
							zptr[unHi] = zptr[gtHi];
							zptr[gtHi] = temp;
							gtHi--;
							unHi--;
							continue;
						}
						if (n <  0) {
							break;
						}
						unHi--;
					}
					if (unLo > unHi) {
						break;
					}
					{
						int temp = zptr[unLo];
						zptr[unLo] = zptr[unHi];
						zptr[unHi] = temp;
						unLo++;
						unHi--;
					}
				}
				
				if (gtHi < ltLo) {
					stack[sp].ll = lo;
					stack[sp].hh = hi;
					stack[sp].dd = d+1;
					sp++;
					continue;
				}
				
				n = ((ltLo-lo) < (unLo-ltLo)) ? (ltLo-lo) : (unLo-ltLo);
				Vswap(lo, unLo-n, n);
				m = ((hi-gtHi) < (gtHi-unHi)) ? (hi-gtHi) : (gtHi-unHi);
				Vswap(unLo, hi-m+1, m);
				
				n = lo + unLo - ltLo - 1;
				m = hi - (gtHi - unHi) + 1;
				
				stack[sp].ll = lo;
				stack[sp].hh = n;
				stack[sp].dd = d;
				sp++;
				
				stack[sp].ll = n + 1;
				stack[sp].hh = m - 1;
				stack[sp].dd = d+1;
				sp++;
				
				stack[sp].ll = m;
				stack[sp].hh = hi;
				stack[sp].dd = d;
				sp++;
			}
		}

        /// <summary>
        /// Mains the sort.
        /// </summary>
        void MainSort() 
		{
			int i, j, ss, sb;
			int[] runningOrder = new int[256];
			int[] copy = new int[256];
			bool[] bigDone = new bool[256];
			int c1, c2;
			int numQSorted;
			
			/*--
			In the various block-sized structures, live data runs
			from 0 to last+NUM_OVERSHOOT_BYTES inclusive.  First,
			set up the overshoot area for block.
			--*/
			
			//   if (verbosity >= 4) fprintf ( stderr, "        sort initialise ...\n" );
			for (i = 0; i < BZip2Constants.NUM_OVERSHOOT_BYTES; i++) {
				block[last + i + 2] = block[(i % (last + 1)) + 1];
			}
			for (i = 0; i <= last + BZip2Constants.NUM_OVERSHOOT_BYTES; i++) {
				quadrant[i] = 0;
			}
			
			block[0] = (byte)(block[last + 1]);
			
			if (last < 4000) {
				/*--
				Use simpleSort(), since the full sorting mechanism
				has quite a large constant overhead.
				--*/
				for (i = 0; i <= last; i++) {
					zptr[i] = i;
				}
				firstAttempt = false;
				workDone = workLimit = 0;
				SimpleSort(0, last, 0);
			} else {
				numQSorted = 0;
				for (i = 0; i <= 255; i++) {
					bigDone[i] = false;
				}
				for (i = 0; i <= 65536; i++) {
					ftab[i] = 0;
				}
				
				c1 = block[0];
				for (i = 0; i <= last; i++) {
					c2 = block[i + 1];
					ftab[(c1 << 8) + c2]++;
					c1 = c2;
				}
				
				for (i = 1; i <= 65536; i++) {
					ftab[i] += ftab[i - 1];
				}
				
				c1 = block[1];
				for (i = 0; i < last; i++) {
					c2 = block[i + 2];
					j = (c1 << 8) + c2;
					c1 = c2;
					ftab[j]--;
					zptr[ftab[j]] = i;
				}
				
				j = ((block[last + 1]) << 8) + (block[1]);
				ftab[j]--;
				zptr[ftab[j]] = last;
				
				/*--
				Now ftab contains the first loc of every small bucket.
				Calculate the running order, from smallest to largest
				big bucket.
				--*/
				
				for (i = 0; i <= 255; i++) {
					runningOrder[i] = i;
				}
				
				int vv;
				int h = 1;
				do {
					h = 3 * h + 1;
				} while (h <= 256);
				do {
					h = h / 3;
					for (i = h; i <= 255; i++) {
						vv = runningOrder[i];
						j = i;
						while ((ftab[((runningOrder[j-h])+1) << 8] - ftab[(runningOrder[j-h]) << 8]) > (ftab[((vv)+1) << 8] - ftab[(vv) << 8])) {
							runningOrder[j] = runningOrder[j-h];
							j = j - h;
							if (j <= (h - 1)) {
								break;
							}
						}
						runningOrder[j] = vv;
					}
				} while (h != 1);
				
				/*--
				The main sorting loop.
				--*/
				for (i = 0; i <= 255; i++) {
					
					/*--
					Process big buckets, starting with the least full.
					--*/
					ss = runningOrder[i];
					
					/*--
					Complete the big bucket [ss] by quicksorting
					any unsorted small buckets [ss, j].  Hopefully
					previous pointer-scanning phases have already
					completed many of the small buckets [ss, j], so
					we don't have to sort them at all.
					--*/
					for (j = 0; j <= 255; j++) {
						sb = (ss << 8) + j;
						if(!((ftab[sb] & SETMASK) == SETMASK)) {
							int lo = ftab[sb] & CLEARMASK;
							int hi = (ftab[sb+1] & CLEARMASK) - 1;
							if (hi > lo) {
								QSort3(lo, hi, 2);
								numQSorted += (hi - lo + 1);
								if (workDone > workLimit && firstAttempt) {
									return;
								}
							}
							ftab[sb] |= SETMASK;
						}
					}
					
					/*--
					The ss big bucket is now done.  Record this fact,
					and update the quadrant descriptors.  Remember to
					update quadrants in the overshoot area too, if
					necessary.  The "if (i < 255)" test merely skips
					this updating for the last bucket processed, since
					updating for the last bucket is pointless.
					--*/
					bigDone[ss] = true;
					
					if (i < 255) {
						int bbStart  = ftab[ss << 8] & CLEARMASK;
						int bbSize   = (ftab[(ss+1) << 8] & CLEARMASK) - bbStart;
						int shifts   = 0;
						
						while ((bbSize >> shifts) > 65534) {
							shifts++;
						}
						
						for (j = 0; j < bbSize; j++) {
							int a2update = zptr[bbStart + j];
							int qVal = (j >> shifts);
							quadrant[a2update] = qVal;
							if (a2update < BZip2Constants.NUM_OVERSHOOT_BYTES) {
								quadrant[a2update + last + 1] = qVal;
							}
						}
						
						if (!(((bbSize-1) >> shifts) <= 65535)) {
							Panic();
						}
					}
					
					/*--
					Now scan this big bucket so as to synthesise the
					sorted order for small buckets [t, ss] for all t != ss.
					--*/
					for (j = 0; j <= 255; j++) {
						copy[j] = ftab[(j << 8) + ss] & CLEARMASK;
					}
					
					for (j = ftab[ss << 8] & CLEARMASK; j < (ftab[(ss+1) << 8] & CLEARMASK); j++) {
						c1 = block[zptr[j]];
						if (!bigDone[c1]) {
							zptr[copy[c1]] = zptr[j] == 0 ? last : zptr[j] - 1;
							copy[c1] ++;
						}
					}
					
					for (j = 0; j <= 255; j++) {
						ftab[(j << 8) + ss] |= SETMASK;
					}
				}
			}
		}

        /// <summary>
        /// Randomises the block.
        /// </summary>
        void RandomiseBlock() 
		{
			int i;
			int rNToGo = 0;
			int rTPos  = 0;
			for (i = 0; i < 256; i++) {
				inUse[i] = false;
			}
			
			for (i = 0; i <= last; i++) {
				if (rNToGo == 0) {
					rNToGo = (int)BZip2Constants.rNums[rTPos];
					rTPos++;
					if (rTPos == 512) {
						rTPos = 0;
					}
				}
				rNToGo--;
				block[i + 1] ^= (byte)((rNToGo == 1) ? 1 : 0);
				// handle 16 bit signed numbers
				block[i + 1] &= 0xFF;
				
				inUse[block[i + 1]] = true;
			}
		}

        /// <summary>
        /// Does the reversible transformation.
        /// </summary>
        void DoReversibleTransformation() 
		{
			workLimit = workFactor * last;
			workDone = 0;
			blockRandomised = false;
			firstAttempt = true;
			
			MainSort();
			
			if (workDone > workLimit && firstAttempt) {
				RandomiseBlock();
				workLimit = workDone = 0;
				blockRandomised = true;
				firstAttempt = false;
				MainSort();
			}
			
			origPtr = -1;
			for (int i = 0; i <= last; i++) {
				if (zptr[i] == 0) {
					origPtr = i;
					break;
				}
			}
			
			if (origPtr == -1) {
				Panic();
			}
		}

        /// <summary>
        /// Fulls the gt u.
        /// </summary>
        /// <param name="i1">The i1.</param>
        /// <param name="i2">The i2.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool FullGtU(int i1, int i2) 
		{
			int k;
			byte c1, c2;
			int s1, s2;
			
			c1 = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c1 != c2) {
				return c1 > c2;
			}
			i1++;
			i2++;
			
			c1 = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c1 != c2) {
				return c1 > c2;
			}
			i1++;
			i2++;
			
			c1 = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c1 != c2) {
				return c1 > c2;
			}
			i1++;
			i2++;
			
			c1 = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c1 != c2) {
				return c1 > c2;
			}
			i1++;
			i2++;
			
			c1 = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c1 != c2) {
				return c1 > c2;
			}
			i1++;
			i2++;
			
			c1 = block[i1 + 1];
			c2 = block[i2 + 1];
			if (c1 != c2) {
				return c1 > c2;
			}
			i1++;
			i2++;
			
			k = last + 1;
			
			do {
				c1 = block[i1 + 1];
				c2 = block[i2 + 1];
				if (c1 != c2) {
					return c1 > c2;
				}
				s1 = quadrant[i1];
				s2 = quadrant[i2];
				if (s1 != s2) {
					return s1 > s2;
				}
				i1++;
				i2++;
				
				c1 = block[i1 + 1];
				c2 = block[i2 + 1];
				if (c1 != c2) {
					return c1 > c2;
				}
				s1 = quadrant[i1];
				s2 = quadrant[i2];
				if (s1 != s2) {
					return s1 > s2;
				}
				i1++;
				i2++;
				
				c1 = block[i1 + 1];
				c2 = block[i2 + 1];
				if (c1 != c2) {
					return c1 > c2;
				}
				s1 = quadrant[i1];
				s2 = quadrant[i2];
				if (s1 != s2) {
					return s1 > s2;
				}
				i1++;
				i2++;
				
				c1 = block[i1 + 1];
				c2 = block[i2 + 1];
				if (c1 != c2) {
					return c1 > c2;
				}
				s1 = quadrant[i1];
				s2 = quadrant[i2];
				if (s1 != s2) {
					return s1 > s2;
				}
				i1++;
				i2++;
				
				if (i1 > last) {
					i1 -= last;
					i1--;
				}
				if (i2 > last) {
					i2 -= last;
					i2--;
				}
				
				k -= 4;
				++workDone;
			} while (k >= 0);
			
			return false;
		}

        /*--
		Knuth's increments seem to work better
		than Incerpi-Sedgewick here.  Possibly
		because the number of elems to sort is
		usually small, typically <= 20.
		--*/
        /// <summary>
        /// The incs
        /// </summary>
        readonly int[] incs = new int[] { 
			1, 4, 13, 40, 121, 364, 1093, 3280,
			9841, 29524, 88573, 265720,
			797161, 2391484 
		};

        /// <summary>
        /// Allocates the compress structures.
        /// </summary>
        void AllocateCompressStructures() 
		{
			int n = BZip2Constants.baseBlockSize * blockSize100k;
			block = new byte[(n + 1 + BZip2Constants.NUM_OVERSHOOT_BYTES)];
			quadrant = new int[(n + BZip2Constants.NUM_OVERSHOOT_BYTES)];
			zptr = new int[n];
			ftab = new int[65537];
			
			if (block == null || quadrant == null || zptr == null  || ftab == null) {
				//		int totalDraw = (n + 1 + NUM_OVERSHOOT_BYTES) + (n + NUM_OVERSHOOT_BYTES) + n + 65537;
				//		compressOutOfMemory ( totalDraw, n );
			}
			
			/*
			The back end needs a place to store the MTF values
			whilst it calculates the coding tables.  We could
			put them in the zptr array.  However, these values
			will fit in a short, so we overlay szptr at the
			start of zptr, in the hope of reducing the number
			of cache misses induced by the multiple traversals
			of the MTF values when calculating coding tables.
			Seems to improve compression speed by about 1%.
			*/
			//	szptr = zptr;
			
			
			szptr = new short[2 * n];
		}

        /// <summary>
        /// Generates the MTF values.
        /// </summary>
        void GenerateMTFValues() 
		{
			char[] yy = new char[256];
			int  i, j;
			char tmp;
			char tmp2;
			int zPend;
			int wr;
			int EOB;
			
			MakeMaps();
			EOB = nInUse+1;
			
			for (i = 0; i <= EOB; i++) {
				mtfFreq[i] = 0;
			}
			
			wr = 0;
			zPend = 0;
			for (i = 0; i < nInUse; i++) {
				yy[i] = (char) i;
			}
			
			
			for (i = 0; i <= last; i++) {
				char ll_i;
				
				ll_i = unseqToSeq[block[zptr[i]]];
				
				j = 0;
				tmp = yy[j];
				while (ll_i != tmp) {
					j++;
					tmp2 = tmp;
					tmp = yy[j];
					yy[j] = tmp2;
				}
				yy[0] = tmp;
				
				if (j == 0) {
					zPend++;
				} else {
					if (zPend > 0) {
						zPend--;
						while (true) {
							switch (zPend % 2) {
								case 0:
									szptr[wr] = (short)BZip2Constants.RUNA;
									wr++;
									mtfFreq[BZip2Constants.RUNA]++;
									break;
								case 1:
									szptr[wr] = (short)BZip2Constants.RUNB;
									wr++;
									mtfFreq[BZip2Constants.RUNB]++;
									break;
							}
							if (zPend < 2) {
								break;
							}
							zPend = (zPend - 2) / 2;
						}
						zPend = 0;
					}
					szptr[wr] = (short)(j + 1);
					wr++;
					mtfFreq[j + 1]++;
				}
			}
			
			if (zPend > 0) {
				zPend--;
				while (true) {
					switch (zPend % 2) {
						case 0:
							szptr[wr] = (short)BZip2Constants.RUNA;
							wr++;
							mtfFreq[BZip2Constants.RUNA]++;
							break;
						case 1:
							szptr[wr] = (short)BZip2Constants.RUNB;
							wr++;
							mtfFreq[BZip2Constants.RUNB]++;
							break;
					}
					if (zPend < 2) {
						break;
					}
					zPend = (zPend - 2) / 2;
				}
			}
			
			szptr[wr] = (short)EOB;
			wr++;
			mtfFreq[EOB]++;
			
			nMTF = wr;
		}
	}
}

/* This file was derived from a file containing under this license:
 * 
 * This file is a part of bzip2 and/or libbzip2, a program and
 * library for lossless, block-sorting data compression.
 * 
 * Copyright (C) 1996-1998 Julian R Seward.  All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 * 1. Redistributions of source code must retain the above copyright
 * notice, this list of conditions and the following disclaimer.
 * 
 * 2. The origin of this software must not be misrepresented; you must 
 * not claim that you wrote the original software.  If you use this 
 * software in a product, an acknowledgment in the product 
 * documentation would be appreciated but is not required.
 * 
 * 3. Altered source versions must be plainly marked as such, and must
 * not be misrepresented as being the original software.
 * 
 * 4. The name of the author may not be used to endorse or promote 
 * products derived from this software without specific prior written 
 * permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS
 * OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE
 * GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * Java version ported by Keiron Liddle, Aftex Software <keiron@aftexsw.com> 1999-2001
 */