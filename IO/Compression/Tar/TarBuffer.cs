// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TarBuffer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;

namespace Zeroit.Framework.Utilities.IO.Compression.Tar 
{

    /// <summary>
    /// The TarBuffer class implements the tar archive concept
    /// of a buffered input stream. This concept goes back to the
    /// days of blocked tape drives and special io devices. In the
    /// C# universe, the only real function that this class
    /// performs is to ensure that files have the correct "record"
    /// size, or other tars will complain.
    /// <p>
    /// You should never have a need to access this class directly.
    /// TarBuffers are created by Tar IO Streams.
    /// </p>
    /// </summary>
    public class TarBuffer
	{

        /* A quote from GNU tar man file on blocking and records
           A `tar' archive file contains a series of blocks.  Each block
        contains `BLOCKSIZE' bytes.  Although this format may be thought of as
        being on magnetic tape, other media are often used.

           Each file archived is represented by a header block which describes
        the file, followed by zero or more blocks which give the contents of
        the file.  At the end of the archive file there may be a block filled
        with binary zeros as an end-of-file marker.  A reasonable system should
        write a block of zeros at the end, but must not assume that such a
        block exists when reading an archive.

           The blocks may be "blocked" for physical I/O operations.  Each
        record of N blocks (where N is set by the `--blocking-factor=512-SIZE'
        (`-b 512-SIZE') option to `tar') is written with a single `write ()'
        operation.  On magnetic tapes, the result of such a write is a single
        record.  When writing an archive, the last record of blocks should be
        written at the full size, with blocks after the zero block containing
        all zeros.  When reading an archive, a reasonable system should
        properly handle an archive whose last record is shorter than the rest,
        or which contains garbage records after a zero block.
        */

        /// <summary>
        /// The size of a block in a tar archive in bytes.
        /// </summary>
        public const int BlockSize = 512;

        /// <summary>
        /// The number of blocks in a default record.
        /// </summary>
        public const int DefaultBlockFactor = 20;

        /// <summary>
        /// The size in bytes of a default record.
        /// </summary>
        public const int DefaultRecordSize = BlockSize * DefaultBlockFactor;

        /// <summary>
        /// The input stream
        /// </summary>
        Stream inputStream;
        /// <summary>
        /// The output stream
        /// </summary>
        Stream outputStream;

        /// <summary>
        /// The record buffer
        /// </summary>
        byte[] recordBuffer;
        /// <summary>
        /// The current block index
        /// </summary>
        int currentBlockIndex;
        /// <summary>
        /// The current record index
        /// </summary>
        int currentRecordIndex;

        /// <summary>
        /// The record size
        /// </summary>
        int recordSize = DefaultRecordSize;

        /// <summary>
        /// Get the record size for this buffer
        /// </summary>
        /// <value>The size of the record.</value>
        public int RecordSize {
			get { 
				return recordSize; 
			}
		}

        /// <summary>
        /// The block factor
        /// </summary>
        int blockFactor = DefaultBlockFactor;

        /// <summary>
        /// Get the Blocking factor for the buffer
        /// </summary>
        /// <value>The block factor.</value>
        public int BlockFactor {
			get { 
				return blockFactor; 
			}
		}


        /// <summary>
        /// Construct a default TarBuffer
        /// </summary>
        protected TarBuffer()
		{
		}

        /// <summary>
        /// Create TarBuffer for reading with default BlockFactor
        /// </summary>
        /// <param name="inputStream">Stream to buffer</param>
        /// <returns>TarBuffer</returns>
        public static TarBuffer CreateInputTarBuffer(Stream inputStream)
		{
			return CreateInputTarBuffer(inputStream, TarBuffer.DefaultBlockFactor);
		}

        /// <summary>
        /// Construct TarBuffer for reading inputStream setting BlockFactor
        /// </summary>
        /// <param name="inputStream">Stream to buffer</param>
        /// <param name="blockFactor">Blocking factor to apply</param>
        /// <returns>TarBuffer</returns>
        public static TarBuffer CreateInputTarBuffer(Stream inputStream, int blockFactor)
		{
			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.inputStream  = inputStream;
			tarBuffer.outputStream = null;
			tarBuffer.Initialize(blockFactor);
			
			return tarBuffer;
		}

        /// <summary>
        /// Construct TarBuffer for writing with default BlockFactor
        /// </summary>
        /// <param name="outputStream">output stream for buffer</param>
        /// <returns>TarBuffer</returns>
        public static TarBuffer CreateOutputTarBuffer(Stream outputStream)
		{
			return CreateOutputTarBuffer(outputStream, TarBuffer.DefaultBlockFactor);
		}

        /// <summary>
        /// Construct TarBuffer for writing Tar output to streams.
        /// </summary>
        /// <param name="outputStream">Output stream to write to.</param>
        /// <param name="blockFactor">Blocking factor to apply</param>
        /// <returns>TarBuffer</returns>
        public static TarBuffer CreateOutputTarBuffer(Stream outputStream, int blockFactor)
		{
			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.inputStream  = null;
			tarBuffer.outputStream = outputStream;
			tarBuffer.Initialize(blockFactor);
			
			return tarBuffer;
		}

        /// <summary>
        /// Initialization common to all constructors.
        /// </summary>
        /// <param name="blockFactor">The block factor.</param>
        void Initialize(int blockFactor)
		{
			this.blockFactor  = blockFactor;
			this.recordSize   = blockFactor * BlockSize;

			this.recordBuffer  = new byte[RecordSize];
			
			if (inputStream != null) {
				this.currentRecordIndex = -1;
				this.currentBlockIndex = BlockFactor;
			} else {
				this.currentRecordIndex = 0;
				this.currentBlockIndex = 0;
			}
		}

        /// <summary>
        /// Get the TAR Buffer's block factor
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetBlockFactor()
		{
			return this.blockFactor;
		}

        /// <summary>
        /// Get the TAR Buffer's record size.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetRecordSize()
		{
			return this.recordSize;
		}

        /// <summary>
        /// Determine if an archive block indicates End of Archive. End of
        /// archive is indicated by a block that consists entirely of null bytes.
        /// All remaining blocks for the record should also be null's
        /// However some older tars only do a couple of null blocks (Old GNU tar for one)
        /// and also partial records
        /// </summary>
        /// <param name="block">The data block to check.</param>
        /// <returns><c>true</c> if [is EOF block] [the specified block]; otherwise, <c>false</c>.</returns>
        public bool IsEOFBlock(byte[] block)
		{
			for (int i = 0, sz = BlockSize; i < sz; ++i) {
				if (block[i] != 0) {
					return false;
				}
			}
			
			return true;
		}

        /// <summary>
        /// Skip over a block on the input stream.
        /// </summary>
        /// <exception cref="TarException">no input stream defined</exception>
        public void SkipBlock()
		{
			if (this.inputStream == null) {
				throw new TarException("no input stream defined");
			}
			
			if (this.currentBlockIndex >= this.BlockFactor) {
				if (!this.ReadRecord()) {
					return;
				}
			}
			
			this.currentBlockIndex++;
		}

        /// <summary>
        /// Read a block from the input stream.
        /// </summary>
        /// <returns>The block of data read.</returns>
        /// <exception cref="TarException">TarBuffer.ReadBlock - no input stream defined</exception>
        public byte[] ReadBlock()
		{
			if (this.inputStream == null) {
				throw new TarException("TarBuffer.ReadBlock - no input stream defined");
			}
			
			if (this.currentBlockIndex >= this.BlockFactor) {
				if (!this.ReadRecord()) {
					return null;
				}
			}
			
			byte[] result = new byte[BlockSize];
			
			Array.Copy(this.recordBuffer, (this.currentBlockIndex * BlockSize), result, 0, BlockSize );
			this.currentBlockIndex++;
			return result;
		}

        /// <summary>
        /// Read a record from data stream.
        /// </summary>
        /// <returns>false if End-Of-File, else true.</returns>
        /// <exception cref="TarException">no input stream stream defined</exception>
        bool ReadRecord()
		{
			if (this.inputStream == null) {
				throw new TarException("no input stream stream defined");
			}
						
			this.currentBlockIndex = 0;
			
			int offset = 0;
			int bytesNeeded = RecordSize;

			while (bytesNeeded > 0) {
				long numBytes = this.inputStream.Read(this.recordBuffer, offset, bytesNeeded);
				
				//
				// NOTE
				// We have found EOF, and the record is not full!
				//
				// This is a broken archive. It does not follow the standard
				// blocking algorithm. However, because we are generous, and
				// it requires little effort, we will simply ignore the error
				// and continue as if the entire record were read. This does
				// not appear to break anything upstream. We used to return
				// false in this case.
				//
				// Thanks to 'Yohann.Roussel@alcatel.fr' for this fix.
				//
				if (numBytes <= 0) {
					break;
				}
				
				offset      += (int)numBytes;
				bytesNeeded -= (int)numBytes;
			}
			
			this.currentRecordIndex++;
			return true;
		}

        /// <summary>
        /// Get the current block number, within the current record, zero based.
        /// </summary>
        /// <returns>The current zero based block number.</returns>
        /// <remarks>The absolute block number = (<see cref="GetCurrentRecordNum">record number</see> * <see cref="BlockFactor">block factor</see>) + <see cref="GetCurrentBlockNum">block number</see>.</remarks>
        public int GetCurrentBlockNum()
		{
			return this.currentBlockIndex;
		}

        /// <summary>
        /// Get the current record number.
        /// </summary>
        /// <returns>The current zero based record number.</returns>
        public int GetCurrentRecordNum()
		{
			return this.currentRecordIndex;
		}

        /// <summary>
        /// Write a block of data to the archive.
        /// </summary>
        /// <param name="block">The data to write to the archive.</param>
        /// <exception cref="TarException">
        /// TarBuffer.WriteBlock - no output stream defined
        /// or
        /// TarBuffer.WriteBlock - block to write has length '" + block.Length + "' which is not the block size of '" + BlockSize + "'
        /// </exception>
        public void WriteBlock(byte[] block)
		{
			if (this.outputStream == null) {
				throw new TarException("TarBuffer.WriteBlock - no output stream defined");
			}
						
			if (block.Length != BlockSize) {
				throw new TarException("TarBuffer.WriteBlock - block to write has length '" + block.Length + "' which is not the block size of '" + BlockSize + "'" );
			}
			
			if (this.currentBlockIndex >= BlockFactor) {
				this.WriteRecord();
			}

			Array.Copy(block, 0, this.recordBuffer, (this.currentBlockIndex * BlockSize), BlockSize);
			this.currentBlockIndex++;
		}

        /// <summary>
        /// Write an archive record to the archive, where the record may be
        /// inside of a larger array buffer. The buffer must be "offset plus
        /// record size" long.
        /// </summary>
        /// <param name="buf">The buffer containing the record data to write.</param>
        /// <param name="offset">The offset of the record data within buf.</param>
        /// <exception cref="TarException">
        /// TarBuffer.WriteBlock - no output stream stream defined
        /// or
        /// TarBuffer.WriteBlock - record has length '" + buf.Length + "' with offset '" + offset + "' which is less than the record size of '" + this.recordSize + "'
        /// </exception>
        public void WriteBlock(byte[] buf, int offset)
		{
			if (this.outputStream == null) {
				throw new TarException("TarBuffer.WriteBlock - no output stream stream defined");
			}
						
			if ((offset + BlockSize) > buf.Length) {
				throw new TarException("TarBuffer.WriteBlock - record has length '" + buf.Length + "' with offset '" + offset + "' which is less than the record size of '" + this.recordSize + "'" );
			}
			
			if (this.currentBlockIndex >= this.BlockFactor) {
				this.WriteRecord();
			}
			
			Array.Copy(buf, offset, this.recordBuffer, (this.currentBlockIndex * BlockSize), BlockSize);
			
			this.currentBlockIndex++;
		}

        /// <summary>
        /// Write a TarBuffer record to the archive.
        /// </summary>
        /// <exception cref="TarException">TarBuffer.WriteRecord no output stream defined</exception>
        void WriteRecord()
		{
			if (this.outputStream == null)
			{
				throw new TarException("TarBuffer.WriteRecord no output stream defined");
			}
			
			this.outputStream.Write(this.recordBuffer, 0, RecordSize);
			this.outputStream.Flush();
			
			this.currentBlockIndex = 0;
			this.currentRecordIndex++;
		}

        /// <summary>
        /// Flush the current data block if it has any data in it.
        /// </summary>
        /// <exception cref="TarException">TarBuffer.Flush no output stream defined</exception>
        void Flush()
		{
			if (this.outputStream == null) 
			{
				throw new TarException("TarBuffer.Flush no output stream defined");
			}
			
			if (this.currentBlockIndex > 0) 
			{
				this.WriteRecord();
			}
			outputStream.Flush();
		}

        /// <summary>
        /// Close the TarBuffer. If this is an output buffer, also flush the
        /// current block before closing.
        /// </summary>
        public void Close()
		{
			if (outputStream != null)
			{
				Flush();
	
				outputStream.Close();
				outputStream = null;
			}
			else if (inputStream != null)
			{
				inputStream.Close();
				inputStream = null;
			}
		}
	}
}

/* The original Java file had this header:
	*
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
