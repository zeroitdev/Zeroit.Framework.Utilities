// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="PkzipClassic.cs" company="Zeroit Dev Technologies">
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
using System.Security.Cryptography;

using Zeroit.Framework.Utilities.IO.Compression.Checksums;

namespace Zeroit.Framework.Utilities.IO.Compression.Encryption
{
    /// <summary>
    /// PkzipClassic embodies the classic or original encryption facilities used in Pkzip archives.
    /// While it has been superceded by more recent and more powerful algorithms, its still in use and
    /// is viable for preventing casual snooping
    /// </summary>
    /// <seealso cref="System.Security.Cryptography.SymmetricAlgorithm" />
    public abstract class PkzipClassic  : SymmetricAlgorithm
	{
        /// <summary>
        /// Generates new encryption keys based on given seed
        /// </summary>
        /// <param name="seed">The seed.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ArgumentNullException">seed</exception>
        /// <exception cref="ArgumentException">seed</exception>
        static public byte[] GenerateKeys(byte[] seed)
		{
			if ( seed == null ) 
			{
				throw new ArgumentNullException("seed");
			}

			if ( seed.Length == 0 )
			{
				throw new ArgumentException("seed");
			}

			uint[] newKeys = new uint[] {
			                            0x12345678,
			                            0x23456789,
			                            0x34567890
			                         };
			
			for (int i = 0; i < seed.Length; ++i) 
			{
				newKeys[0] = Crc32.ComputeCrc32(newKeys[0], seed[i]);
				newKeys[1] = newKeys[1] + (byte)newKeys[0];
				newKeys[1] = newKeys[1] * 134775813 + 1;
				newKeys[2] = Crc32.ComputeCrc32(newKeys[2], (byte)(newKeys[1] >> 24));
			}

			byte[] result = new byte[12];
			result[0] = (byte)(newKeys[0] & 0xff);
			result[1] = (byte)((newKeys[0] >> 8) & 0xff);
			result[2] = (byte)((newKeys[0] >> 16) & 0xff);
			result[3] = (byte)((newKeys[0] >> 24) & 0xff);
			result[4] = (byte)(newKeys[1] & 0xff);
			result[5] = (byte)((newKeys[1] >> 8) & 0xff);
			result[6] = (byte)((newKeys[1] >> 16) & 0xff);
			result[7] = (byte)((newKeys[1] >> 24) & 0xff);
			result[8] = (byte)(newKeys[2] & 0xff);
			result[9] = (byte)((newKeys[2] >> 8) & 0xff);
			result[10] = (byte)((newKeys[2] >> 16) & 0xff);
			result[11] = (byte)((newKeys[2] >> 24) & 0xff);
			return result;
		}
	}

    /// <summary>
    /// PkzipClassicCryptoBase provides the low level facilities for encryption
    /// and decryption using the PkzipClassic algorithm.
    /// </summary>
    class PkzipClassicCryptoBase
	{
        /// <summary>
        /// The keys
        /// </summary>
        uint[] keys     = null;

        /// <summary>
        /// Transform a single byte
        /// </summary>
        /// <returns>The transformed value</returns>
        protected byte TransformByte()
		{
			uint temp = ((keys[2] & 0xFFFF) | 2);
			return (byte)((temp * (temp ^ 1)) >> 8);
		}

        /// <summary>
        /// Sets the keys.
        /// </summary>
        /// <param name="keyData">The key data.</param>
        /// <exception cref="ArgumentNullException">keyData</exception>
        /// <exception cref="InvalidOperationException">Keys not valid</exception>
        protected void SetKeys(byte[] keyData)
		{
			if ( keyData == null ) {
				throw new ArgumentNullException("keyData");
			}
		
			if ( keyData.Length != 12 ) {
				throw new InvalidOperationException("Keys not valid");
			}
			
			keys = new uint[3];
			keys[0] = (uint)((keyData[3] << 24) | (keyData[2] << 16) | (keyData[1] << 8) | keyData[0]);
			keys[1] = (uint)((keyData[7] << 24) | (keyData[6] << 16) | (keyData[5] << 8) | keyData[4]);
			keys[2] = (uint)((keyData[11] << 24) | (keyData[10] << 16) | (keyData[9] << 8) | keyData[8]);
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

        /// <summary>
        /// Reset the internal state.
        /// </summary>
        protected void Reset()
		{
			keys[0] = 0;
			keys[1] = 0;
			keys[2] = 0;
		}
	}

    /// <summary>
    /// PkzipClassic CryptoTransform for encryption.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Encryption.PkzipClassicCryptoBase" />
    /// <seealso cref="System.Security.Cryptography.ICryptoTransform" />
    class PkzipClassicEncryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform
	{
        /// <summary>
        /// Initialise a new instance of <see cref="PkzipClassicEncryptCryptoTransform"></see>
        /// </summary>
        /// <param name="keyBlock">The key block to use.</param>
        internal PkzipClassicEncryptCryptoTransform(byte[] keyBlock)
		{
			SetKeys(keyBlock);
		}

        #region ICryptoTransform Members

        /// <summary>
        /// Transforms the specified region of the specified byte array.
        /// </summary>
        /// <param name="inputBuffer">The input for which to compute the transform.</param>
        /// <param name="inputOffset">The offset into the byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the byte array to use as data.</param>
        /// <returns>The computed transform.</returns>
        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] result = new byte[inputCount];
			TransformBlock(inputBuffer, inputOffset, inputCount, result, 0);
			return result;
		}

        /// <summary>
        /// Transforms the specified region of the input byte array and copies
        /// the resulting transform to the specified region of the output byte array.
        /// </summary>
        /// <param name="inputBuffer">The input for which to compute the transform.</param>
        /// <param name="inputOffset">The offset into the input byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the input byte array to use as data.</param>
        /// <param name="outputBuffer">The output to which to write the transform.</param>
        /// <param name="outputOffset">The offset into the output byte array from which to begin writing data.</param>
        /// <returns>The number of bytes written.</returns>
        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; ++i) {
				byte oldbyte = inputBuffer[i];
				outputBuffer[outputOffset++] = (byte)(inputBuffer[i] ^ TransformByte());
				UpdateKeys(oldbyte);
			}
			return inputCount;
		}

        /// <summary>
        /// Gets a value indicating whether the current transform can be reused.
        /// </summary>
        /// <value><c>true</c> if this instance can reuse transform; otherwise, <c>false</c>.</value>
        public bool CanReuseTransform
		{
			get {
				return true;
			}
		}

        /// <summary>
        /// Gets the size of the input data blocks in bytes.
        /// </summary>
        /// <value>The size of the input block.</value>
        public int InputBlockSize
		{
			get {
				return 1;
			}
		}

        /// <summary>
        /// Gets the size of the output data blocks in bytes.
        /// </summary>
        /// <value>The size of the output block.</value>
        public int OutputBlockSize
		{
			get {
				return 1;
			}
		}

        /// <summary>
        /// Gets a value indicating whether multiple blocks can be transformed.
        /// </summary>
        /// <value><c>true</c> if this instance can transform multiple blocks; otherwise, <c>false</c>.</value>
        public bool CanTransformMultipleBlocks
		{
			get {
				return true;
			}
		}

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Cleanup internal state.
        /// </summary>
        public void Dispose()
		{
			Reset();
		}

		#endregion
	}


    /// <summary>
    /// PkzipClassic CryptoTransform for decryption.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Encryption.PkzipClassicCryptoBase" />
    /// <seealso cref="System.Security.Cryptography.ICryptoTransform" />
    class PkzipClassicDecryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform
	{
        /// <summary>
        /// Initialise a new instance of <see cref="PkzipClassicDecryptCryptoTransform"></see>.
        /// </summary>
        /// <param name="keyBlock">The key block to decrypt with.</param>
        internal PkzipClassicDecryptCryptoTransform(byte[] keyBlock)
		{
			SetKeys(keyBlock);
		}

        #region ICryptoTransform Members

        /// <summary>
        /// Transforms the specified region of the specified byte array.
        /// </summary>
        /// <param name="inputBuffer">The input for which to compute the transform.</param>
        /// <param name="inputOffset">The offset into the byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the byte array to use as data.</param>
        /// <returns>The computed transform.</returns>
        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] result = new byte[inputCount];
			TransformBlock(inputBuffer, inputOffset, inputCount, result, 0);
			return result;
		}

        /// <summary>
        /// Transforms the specified region of the input byte array and copies
        /// the resulting transform to the specified region of the output byte array.
        /// </summary>
        /// <param name="inputBuffer">The input for which to compute the transform.</param>
        /// <param name="inputOffset">The offset into the input byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the input byte array to use as data.</param>
        /// <param name="outputBuffer">The output to which to write the transform.</param>
        /// <param name="outputOffset">The offset into the output byte array from which to begin writing data.</param>
        /// <returns>The number of bytes written.</returns>
        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; ++i) {
				byte newByte = (byte)(inputBuffer[i] ^ TransformByte());
				outputBuffer[outputOffset++] = newByte;
				UpdateKeys(newByte);
			}
			return inputCount;
		}

        /// <summary>
        /// Gets a value indicating whether the current transform can be reused.
        /// </summary>
        /// <value><c>true</c> if this instance can reuse transform; otherwise, <c>false</c>.</value>
        public bool CanReuseTransform
		{
			get {
				return true;
			}
		}

        /// <summary>
        /// Gets the size of the input data blocks in bytes.
        /// </summary>
        /// <value>The size of the input block.</value>
        public int InputBlockSize
		{
			get {
				return 1;
			}
		}

        /// <summary>
        /// Gets the size of the output data blocks in bytes.
        /// </summary>
        /// <value>The size of the output block.</value>
        public int OutputBlockSize
		{
			get {
				return 1;
			}
		}

        /// <summary>
        /// Gets a value indicating whether multiple blocks can be transformed.
        /// </summary>
        /// <value><c>true</c> if this instance can transform multiple blocks; otherwise, <c>false</c>.</value>
        public bool CanTransformMultipleBlocks
		{
			get {
				return true;
			}
		}

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Cleanup internal state.
        /// </summary>
        public void Dispose()
		{
			Reset();
		}

		#endregion
	}

    /// <summary>
    /// Defines a wrapper object to access the Pkzip algorithm.
    /// This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Encryption.PkzipClassic" />
    public sealed class PkzipClassicManaged : PkzipClassic
	{
        /// <summary>
        /// Get / set the applicable block size.
        /// </summary>
        /// <value>The size of the block.</value>
        /// <exception cref="CryptographicException"></exception>
        /// <remarks>The only valid block size is 8.</remarks>
        public override int BlockSize 
		{
			get { return 8; }
			set {
				if (value != 8)
					throw new CryptographicException();
			}
		}

        /// <summary>
        /// Get an array of legal <see cref="KeySizes">key sizes.</see>
        /// </summary>
        /// <value>The legal key sizes.</value>
        public override KeySizes[] LegalKeySizes
		{
			get {
				KeySizes[] keySizes = new KeySizes[1];
				keySizes[0] = new KeySizes(12 * 8, 12 * 8, 0);
				return keySizes; 
			}
		}

        /// <summary>
        /// Generate an initial vector.
        /// </summary>
        public override void GenerateIV()
		{
			// Do nothing.
		}

        /// <summary>
        /// Get an array of legal <see cref="KeySizes">block sizes</see>.
        /// </summary>
        /// <value>The legal block sizes.</value>
        public override KeySizes[] LegalBlockSizes
		{
			get {
				KeySizes[] keySizes = new KeySizes[1];
				keySizes[0] = new KeySizes(1 * 8, 1 * 8, 0);
				return keySizes; 
			}
		}

        /// <summary>
        /// The key
        /// </summary>
        byte[] key;

        /// <summary>
        /// Get / set the key value applicable.
        /// </summary>
        /// <value>The key.</value>
        public override byte[] Key
		{
			get {
				return key;
			}
		
			set {
				key = value;
			}
		}

        /// <summary>
        /// Generate a new random key.
        /// </summary>
        public override void GenerateKey()
		{
			key = new byte[12];
			Random rnd = new Random();
			rnd.NextBytes(key);
		}

        /// <summary>
        /// Create an encryptor.
        /// </summary>
        /// <param name="rgbKey">The key to use for this encryptor.</param>
        /// <param name="rgbIV">Initialisation vector for the new encryptor.</param>
        /// <returns>Returns a new PkzipClassic encryptor</returns>
        public override ICryptoTransform CreateEncryptor(
			byte[] rgbKey,
			byte[] rgbIV
		)
		{
			return new PkzipClassicEncryptCryptoTransform(rgbKey);
		}

        /// <summary>
        /// Create a decryptor.
        /// </summary>
        /// <param name="rgbKey">Keys to use for this new decryptor.</param>
        /// <param name="rgbIV">Initialisation vector for the new decryptor.</param>
        /// <returns>Returns a new decryptor.</returns>
        public override ICryptoTransform CreateDecryptor(
			byte[] rgbKey,
			byte[] rgbIV
		)
		{
			return new PkzipClassicDecryptCryptoTransform(rgbKey);
		}
	}
}
