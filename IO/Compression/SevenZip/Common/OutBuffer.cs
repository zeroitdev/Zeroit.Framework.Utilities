// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="OutBuffer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip.Buffer
{
    /// <summary>
    /// Class OutBuffer.
    /// </summary>
    public class OutBuffer
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
        /// The m buffer size
        /// </summary>
        uint m_BufferSize;
        /// <summary>
        /// The m stream
        /// </summary>
        System.IO.Stream m_Stream;
        /// <summary>
        /// The m processed size
        /// </summary>
        ulong m_ProcessedSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutBuffer"/> class.
        /// </summary>
        /// <param name="bufferSize">Size of the buffer.</param>
        public OutBuffer(uint bufferSize)
		{
			m_Buffer = new byte[bufferSize];
			m_BufferSize = bufferSize;
		}

        /// <summary>
        /// Sets the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void SetStream(System.IO.Stream stream) { m_Stream = stream; }
        /// <summary>
        /// Flushes the stream.
        /// </summary>
        public void FlushStream() { m_Stream.Flush(); }
        /// <summary>
        /// Closes the stream.
        /// </summary>
        public void CloseStream() { m_Stream.Close(); }
        /// <summary>
        /// Releases the stream.
        /// </summary>
        public void ReleaseStream() { m_Stream = null; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
		{
			m_ProcessedSize = 0;
			m_Pos = 0;
		}

        /// <summary>
        /// Writes the byte.
        /// </summary>
        /// <param name="b">The b.</param>
        public void WriteByte(byte b)
		{
			m_Buffer[m_Pos++] = b;
			if (m_Pos >= m_BufferSize)
				FlushData();
		}

        /// <summary>
        /// Flushes the data.
        /// </summary>
        public void FlushData()
		{
			if (m_Pos == 0)
				return;
			m_Stream.Write(m_Buffer, 0, (int)m_Pos);
			m_Pos = 0;
		}

        /// <summary>
        /// Gets the processed size.
        /// </summary>
        /// <returns>System.UInt64.</returns>
        public ulong GetProcessedSize() { return m_ProcessedSize + m_Pos; }
	}
}
