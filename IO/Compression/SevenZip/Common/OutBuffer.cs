// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="OutBuffer.cs" company="Zeroit Dev Technologies">
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
