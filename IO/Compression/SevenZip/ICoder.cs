// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="ICoder.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip
{
    /// <summary>
    /// The exception that is thrown when an error in input stream occurs during decoding.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    class DataErrorException : ApplicationException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="DataErrorException"/> class.
        /// </summary>
        public DataErrorException(): base("Data Error") { }
	}

    /// <summary>
    /// The exception that is thrown when the value of an argument is outside the allowable range.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    class InvalidParamException : ApplicationException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidParamException"/> class.
        /// </summary>
        public InvalidParamException(): base("Invalid Parameter") { }
	}

    /// <summary>
    /// Interface ICodeProgress
    /// </summary>
    public interface ICodeProgress
	{
        /// <summary>
        /// Callback progress.
        /// </summary>
        /// <param name="inSize">input size. -1 if unknown.</param>
        /// <param name="outSize">output size. -1 if unknown.</param>
        void SetProgress(Int64 inSize, Int64 outSize);
	};

    /// <summary>
    /// Interface ICoder
    /// </summary>
    public interface ICoder
	{
        /// <summary>
        /// Codes streams.
        /// </summary>
        /// <param name="inStream">input Stream.</param>
        /// <param name="outStream">output Stream.</param>
        /// <param name="inSize">input Size. -1 if unknown.</param>
        /// <param name="outSize">output Size. -1 if unknown.</param>
        /// <param name="progress">callback progress reference.</param>
        /// <exception cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.DataErrorException">if input stream is not valid</exception>
        void Code(System.IO.Stream inStream, System.IO.Stream outStream,
			Int64 inSize, Int64 outSize, ICodeProgress progress);
	};

    /*
	public interface ICoder2
	{
		 void Code(ISequentialInStream []inStreams,
				const UInt64 []inSizes, 
				ISequentialOutStream []outStreams, 
				UInt64 []outSizes,
				ICodeProgress progress);
	};
  */

    /// <summary>
    /// Provides the fields that represent properties idenitifiers for compressing.
    /// </summary>
    public enum CoderPropID
	{
        /// <summary>
        /// Specifies size of dictionary.
        /// </summary>
        DictionarySize = 0x400,
        /// <summary>
        /// Specifies size of memory for PPM*.
        /// </summary>
        UsedMemorySize,
        /// <summary>
        /// Specifies order for PPM methods.
        /// </summary>
        Order,
        /// <summary>
        /// The position state bits
        /// </summary>
        PosStateBits = 0x440,
        /// <summary>
        /// The lit context bits
        /// </summary>
        LitContextBits,
        /// <summary>
        /// The lit position bits
        /// </summary>
        LitPosBits,
        /// <summary>
        /// Specifies number of fast bytes for LZ*.
        /// </summary>
        NumFastBytes = 0x450,
        /// <summary>
        /// Specifies match finder. LZMA: "BT2", "BT4" or "BT4B".
        /// </summary>
        MatchFinder,
        /// <summary>
        /// Specifies number of passes.
        /// </summary>
        NumPasses = 0x460,
        /// <summary>
        /// Specifies number of algorithm.
        /// </summary>
        Algorithm = 0x470,
        /// <summary>
        /// Specifies multithread mode.
        /// </summary>
        MultiThread = 0x480,
        /// <summary>
        /// Specifies mode with end marker.
        /// </summary>
        EndMarker = 0x490
	};


    /// <summary>
    /// Interface ISetCoderProperties
    /// </summary>
    public interface ISetCoderProperties
	{
        /// <summary>
        /// Sets the coder properties.
        /// </summary>
        /// <param name="propIDs">The property i ds.</param>
        /// <param name="properties">The properties.</param>
        void SetCoderProperties(CoderPropID[] propIDs, object[] properties);
	};

    /// <summary>
    /// Interface IWriteCoderProperties
    /// </summary>
    public interface IWriteCoderProperties
	{
        /// <summary>
        /// Writes the coder properties.
        /// </summary>
        /// <param name="outStream">The out stream.</param>
        void WriteCoderProperties(System.IO.Stream outStream);
	}

    /// <summary>
    /// Interface ISetDecoderProperties
    /// </summary>
    public interface ISetDecoderProperties
	{
        /// <summary>
        /// Sets the decoder properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        void SetDecoderProperties(byte[] properties);
	}
}
