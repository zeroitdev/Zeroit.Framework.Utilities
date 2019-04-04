// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DeflaterOutputStream.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using Zeroit.Framework.Utilities.IO.Compression.Checksums;

namespace Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.Streams 
{

    /// <summary>
    /// A special stream deflating or compressing the bytes that are
    /// written to it.  It uses a Deflater to perform actual deflating.<br />
    /// Authors of the original java version : Tom Tromey, Jochen Hoenicke
    /// </summary>
    /// <seealso cref="System.IO.Stream" />
    public class DeflaterOutputStream : Stream
	{
        /// <summary>
        /// This buffer is used temporarily to retrieve the bytes from the
        /// deflater and write them to the underlying output stream.
        /// </summary>
        protected byte[] buf;

        /// <summary>
        /// The deflater which is used to deflate the stream.
        /// </summary>
        protected Deflater def;

        /// <summary>
        /// Base stream the deflater depends on.
        /// </summary>
        protected Stream baseOutputStream;

        /// <summary>
        /// The is closed
        /// </summary>
        bool isClosed = false;
        /// <summary>
        /// The is stream owner
        /// </summary>
        bool isStreamOwner = true;

        /// <summary>
        /// Get/set flag indicating ownership of underlying stream.
        /// When the flag is true <see cref="Close"></see> will close the underlying stream also.
        /// </summary>
        /// <value><c>true</c> if this instance is stream owner; otherwise, <c>false</c>.</value>
        public bool IsStreamOwner
		{
			get { return isStreamOwner; }
			set { isStreamOwner = value; }
		}

        /// <summary>
        /// Allows client to determine if an entry can be patched after its added
        /// </summary>
        /// <value><c>true</c> if this instance can patch entries; otherwise, <c>false</c>.</value>
        public bool CanPatchEntries {
			get { 
				return baseOutputStream.CanSeek; 
			}
		}

        /// <summary>
        /// Gets value indicating stream can be read from
        /// </summary>
        /// <value><c>true</c> if this instance can read; otherwise, <c>false</c>.</value>
        public override bool CanRead {
			get {
				return baseOutputStream.CanRead;
			}
		}

        /// <summary>
        /// Gets a value indicating if seeking is supported for this stream
        /// This property always returns false
        /// </summary>
        /// <value><c>true</c> if this instance can seek; otherwise, <c>false</c>.</value>
        public override bool CanSeek {
			get {
				return false;
			}
		}

        /// <summary>
        /// Get value indicating if this stream supports writing
        /// </summary>
        /// <value><c>true</c> if this instance can write; otherwise, <c>false</c>.</value>
        public override bool CanWrite {
			get {
				return baseOutputStream.CanWrite;
			}
		}

        /// <summary>
        /// Get current length of stream
        /// </summary>
        /// <value>The length.</value>
        public override long Length {
			get {
				return baseOutputStream.Length;
			}
		}

        /// <summary>
        /// The current position within the stream.
        /// Always throws a NotSupportedExceptionNotSupportedException
        /// </summary>
        /// <value>The position.</value>
        /// <exception cref="NotSupportedException">Any attempt to set position</exception>
        public override long Position {
			get {
				return baseOutputStream.Position;
			}
			set {
				throw new NotSupportedException("DefalterOutputStream Position not supported");
			}
		}

        /// <summary>
        /// Sets the current position of this stream to the given value. Not supported by this class!
        /// </summary>
        /// <param name="offset">A byte offset relative to the <paramref name="origin" /> parameter.</param>
        /// <param name="origin">A value of type <see cref="T:System.IO.SeekOrigin" /> indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("DeflaterOutputStream Seek not supported");
		}

        /// <summary>
        /// Sets the length of this stream to the given value. Not supported by this class!
        /// </summary>
        /// <param name="val">The value.</param>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override void SetLength(long val)
		{
			throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
		}

        /// <summary>
        /// Read a byte from stream advancing position by one
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override int ReadByte()
		{
			throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
		}

        /// <summary>
        /// Read a block of bytes from stream
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="off">The off.</param>
        /// <param name="len">The length.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override int Read(byte[] b, int off, int len)
		{
			throw new NotSupportedException("DeflaterOutputStream Read not supported");
		}

        /// <summary>
        /// Asynchronous reads are not supported a NotSupportedException is always thrown
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in <paramref name="buffer" /> at which to begin writing data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the read is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>An <see cref="T:System.IAsyncResult" /> that represents the asynchronous read, which could still be pending.</returns>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("DeflaterOutputStream BeginRead not currently supported");
		}

        /// <summary>
        /// Asynchronous writes arent supported, a NotSupportedException is always thrown
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The byte offset in <paramref name="buffer" /> from which to begin writing.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the write is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous write request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous write, which could still be pending.</returns>
        /// <exception cref="NotSupportedException">Any access</exception>
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("DeflaterOutputStream BeginWrite not currently supported");
		}

        /// <summary>
        /// Deflates everything in the input buffers.  This will call
        /// <code>def.deflate()</code> until all bytes from the input buffers
        /// are processed.
        /// </summary>
        /// <exception cref="SharpZipBaseException">DeflaterOutputStream can't deflate all input?</exception>
        protected void Deflate()
		{
			while (!def.IsNeedingInput) {
				int len = def.Deflate(buf, 0, buf.Length);
				
				if (len <= 0) {
					break;
				}
				
				if (this.keys != null) {
					this.EncryptBlock(buf, 0, len);
				}
				
				baseOutputStream.Write(buf, 0, len);
			}
			
			if (!def.IsNeedingInput) {
				throw new SharpZipBaseException("DeflaterOutputStream can't deflate all input?");
			}
		}

        /// <summary>
        /// Creates a new DeflaterOutputStream with a default Deflater and default buffer size.
        /// </summary>
        /// <param name="baseOutputStream">the output stream where deflated output should be written.</param>
        public DeflaterOutputStream(Stream baseOutputStream) : this(baseOutputStream, new Deflater(), 512)
		{
		}

        /// <summary>
        /// Creates a new DeflaterOutputStream with the given Deflater and
        /// default buffer size.
        /// </summary>
        /// <param name="baseOutputStream">the output stream where deflated output should be written.</param>
        /// <param name="defl">the underlying deflater.</param>
        public DeflaterOutputStream(Stream baseOutputStream, Deflater defl) : this(baseOutputStream, defl, 512)
		{
		}

        /// <summary>
        /// Creates a new DeflaterOutputStream with the given Deflater and
        /// buffer size.
        /// </summary>
        /// <param name="baseOutputStream">The output stream where deflated output is written.</param>
        /// <param name="deflater">The underlying deflater to use</param>
        /// <param name="bufsize">The buffer size to use when deflating</param>
        /// <exception cref="ArgumentException">baseOutputStream does not support writing</exception>
        /// <exception cref="ArgumentNullException">deflater instance is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">bufsize is less than or equal to zero.</exception>
        public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater, int bufsize)
		{
			if (baseOutputStream.CanWrite == false) {
				throw new ArgumentException("baseOutputStream", "must support writing");
			}

			if (deflater == null) {
				throw new ArgumentNullException("deflater");
			}
			
			if (bufsize <= 0) {
				throw new ArgumentOutOfRangeException("bufsize");
			}
			
			this.baseOutputStream = baseOutputStream;
			buf = new byte[bufsize];
			def = deflater;
		}

        /// <summary>
        /// Flushes the stream by calling flush() on the deflater and then
        /// on the underlying stream.  This ensures that all bytes are
        /// flushed.
        /// </summary>
        public override void Flush()
		{
			def.Flush();
			Deflate();
			baseOutputStream.Flush();
		}

        /// <summary>
        /// Finishes the stream by calling finish() on the deflater.
        /// </summary>
        /// <exception cref="SharpZipBaseException">Not all input is deflated</exception>
        public virtual void Finish()
		{
			def.Finish();
			while (!def.IsFinished)  {
				int len = def.Deflate(buf, 0, buf.Length);
				if (len <= 0) {
					break;
				}
				
				if (this.keys != null) {
					this.EncryptBlock(buf, 0, len);
				}
				
				baseOutputStream.Write(buf, 0, len);
			}
			if (!def.IsFinished) {
				throw new SharpZipBaseException("Can't deflate all input?");
			}
			baseOutputStream.Flush();
			keys = null;
		}

        /// <summary>
        /// Calls finish() and closes the underlying
        /// stream when <see cref="IsStreamOwner"></see> is true.
        /// </summary>
        public override void Close()
		{
			if ( !isClosed ) {
				isClosed = true;
				Finish();
				if ( isStreamOwner ) {
					baseOutputStream.Close();
				}
			}
		}

        /// <summary>
        /// Writes a single byte to the compressed output stream.
        /// </summary>
        /// <param name="bval">The byte value.</param>
        public override void WriteByte(byte bval)
		{
			byte[] b = new byte[1];
			b[0] = bval;
			Write(b, 0, 1);
		}

        /// <summary>
        /// Writes bytes from an array to the compressed stream.
        /// </summary>
        /// <param name="buf">The byte array</param>
        /// <param name="off">The offset into the byte array where to start.</param>
        /// <param name="len">The number of bytes to write.</param>
        public override void Write(byte[] buf, int off, int len)
		{
			def.SetInput(buf, off, len);
			Deflate();
		}

        #region Encryption

        // TODO:  Refactor this code.  The presence of Zip specific code in this low level class is wrong
        /// <summary>
        /// The password
        /// </summary>
        string password = null;
        /// <summary>
        /// The keys
        /// </summary>
        uint[] keys     = null;

        /// <summary>
        /// Get/set the password used for encryption.  When null no encryption is performed
        /// </summary>
        /// <value>The password.</value>
        public string Password {
			get { 
				return password; 
			}
			set {
				if ( value != null && value.Length == 0 ) {
					password = null;
				} else {
					password = value; 
				}
			}
		}


        /// <summary>
        /// Encrypt a single byte
        /// </summary>
        /// <returns>The encrypted value</returns>
        protected byte EncryptByte()
		{
			uint temp = ((keys[2] & 0xFFFF) | 2);
			return (byte)((temp * (temp ^ 1)) >> 8);
		}


        /// <summary>
        /// Encrypt a block of data
        /// </summary>
        /// <param name="buffer">Data to encrypt.  NOTE the original contents of the buffer are lost</param>
        /// <param name="offset">Offset of first byte in buffer to encrypt</param>
        /// <param name="length">Number of bytes in buffer to encrypt</param>
        protected void EncryptBlock(byte[] buffer, int offset, int length)
		{
			// TODO: refactor to use crypto transform
			for (int i = offset; i < offset + length; ++i) {
				byte oldbyte = buffer[i];
				buffer[i] ^= EncryptByte();
				UpdateKeys(oldbyte);
			}
		}

        /// <summary>
        /// Initializes encryption keys based on given password
        /// </summary>
        /// <param name="password">The password.</param>
        protected void InitializePassword(string password) {
			keys = new uint[] {
				0x12345678,
				0x23456789,
				0x34567890
			};
			
			for (int i = 0; i < password.Length; ++i) {
				UpdateKeys((byte)password[i]);
			}
		}

        /// <summary>
        /// Update encryption keys
        /// </summary>
        /// <param name="ch">The ch.</param>
        protected void UpdateKeys(byte ch)
		{
			keys[0] = Crc32.ComputeCrc32(keys[0], ch);
			keys[1] = keys[1] + (byte)keys[0];
			keys[1] = keys[1] * 134775813 + 1;
			keys[2] = Crc32.ComputeCrc32(keys[2], (byte)(keys[1] >> 24));
		}
		#endregion
	}
}
