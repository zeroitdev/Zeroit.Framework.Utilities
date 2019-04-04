// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="InBuffer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip.Buffer
{
    /// <summary>
    /// Class InBuffer.
    /// </summary>
    public class InBuffer
	{
        /// <summary>
        /// The m buffer
        /// </summary>
        byte[] m_Buffer;
        /// <summary>
        /// The m position
        /// </summary>
        uint m_Pos;
        /// <summary>
        /// The m limit
        /// </summary>
        uint m_Limit;
        /// <summary>
        /// The m buffer size
        /// </summary>
        uint m_BufferSize;
        /// <summary>
        /// The m stream
        /// </summary>
        System.IO.Stream m_Stream;
        /// <summary>
        /// The m stream was exhausted
        /// </summary>
        bool m_StreamWasExhausted;
        /// <summary>
        /// The m processed size
        /// </summary>
        ulong m_ProcessedSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="InBuffer"/> class.
        /// </summary>
        /// <param name="bufferSize">Size of the buffer.</param>
        public InBuffer(uint bufferSize)
		{
			m_Buffer = new byte[bufferSize];
			m_BufferSize = bufferSize;
		}

        /// <summary>
        /// Initializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Init(System.IO.Stream stream)
		{
			m_Stream = stream;
			m_ProcessedSize = 0;
			m_Limit = 0;
			m_Pos = 0;
			m_StreamWasExhausted = false;
		}

        /// <summary>
        /// Reads the block.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ReadBlock()
		{
			if (m_StreamWasExhausted)
				return false;
			m_ProcessedSize += m_Pos;
			int aNumProcessedBytes = m_Stream.Read(m_Buffer, 0, (int)m_BufferSize);
			m_Pos = 0;
			m_Limit = (uint)aNumProcessedBytes;
			m_StreamWasExhausted = (aNumProcessedBytes == 0);
			return (!m_StreamWasExhausted);
		}


        /// <summary>
        /// Releases the stream.
        /// </summary>
        public void ReleaseStream()
		{
			// m_Stream.Close(); 
			m_Stream = null;
		}

        /// <summary>
        /// Reads the byte.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ReadByte(byte b) // check it
		{
			if (m_Pos >= m_Limit)
				if (!ReadBlock())
					return false;
			b = m_Buffer[m_Pos++];
			return true;
		}

        /// <summary>
        /// Reads the byte.
        /// </summary>
        /// <returns>System.Byte.</returns>
        public byte ReadByte()
		{
			// return (byte)m_Stream.ReadByte();
			if (m_Pos >= m_Limit)
				if (!ReadBlock())
					return 0xFF;
			return m_Buffer[m_Pos++];
		}

        /// <summary>
        /// Gets the processed size.
        /// </summary>
        /// <returns>System.UInt64.</returns>
        public ulong GetProcessedSize()
		{
			return m_ProcessedSize + m_Pos;
		}
	}
}
