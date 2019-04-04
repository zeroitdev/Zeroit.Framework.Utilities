// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="LzOutWindow.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip.Compression.LZ
{
    /// <summary>
    /// Class OutWindow.
    /// </summary>
    public class OutWindow
	{
        /// <summary>
        /// The buffer
        /// </summary>
        byte[] _buffer = null;
        /// <summary>
        /// The position
        /// </summary>
        uint _pos;
        /// <summary>
        /// The window size
        /// </summary>
        uint _windowSize = 0;
        /// <summary>
        /// The stream position
        /// </summary>
        uint _streamPos;
        /// <summary>
        /// The stream
        /// </summary>
        System.IO.Stream _stream;

        /// <summary>
        /// Creates the specified window size.
        /// </summary>
        /// <param name="windowSize">Size of the window.</param>
        public void Create(uint windowSize)
		{
			if (_windowSize != windowSize)
			{
				// System.GC.Collect();
				_buffer = new byte[windowSize];
			}
			_windowSize = windowSize;
			_pos = 0;
			_streamPos = 0;
		}

        /// <summary>
        /// Initializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="solid">if set to <c>true</c> [solid].</param>
        public void Init(System.IO.Stream stream, bool solid)
		{
			ReleaseStream();
			_stream = stream;
			if (!solid)
			{
				_streamPos = 0;
				_pos = 0;
			}
		}

        /// <summary>
        /// Initializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Init(System.IO.Stream stream) { Init(stream, false); }

        /// <summary>
        /// Releases the stream.
        /// </summary>
        public void ReleaseStream()
		{
			Flush();
			_stream = null;
		}

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        public void Flush()
		{
			uint size = _pos - _streamPos;
			if (size == 0)
				return;
			_stream.Write(_buffer, (int)_streamPos, (int)size);
			if (_pos >= _windowSize)
				_pos = 0;
			_streamPos = _pos;
		}

        /// <summary>
        /// Copies the block.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="len">The length.</param>
        public void CopyBlock(uint distance, uint len)
		{
			uint pos = _pos - distance - 1;
			if (pos >= _windowSize)
				pos += _windowSize;
			for (; len > 0; len--)
			{
				if (pos >= _windowSize)
					pos = 0;
				_buffer[_pos++] = _buffer[pos++];
				if (_pos >= _windowSize)
					Flush();
			}
		}

        /// <summary>
        /// Puts the byte.
        /// </summary>
        /// <param name="b">The b.</param>
        public void PutByte(byte b)
		{
			_buffer[_pos++] = b;
			if (_pos >= _windowSize)
				Flush();
		}

        /// <summary>
        /// Gets the byte.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <returns>System.Byte.</returns>
        public byte GetByte(uint distance)
		{
			uint pos = _pos - distance - 1;
			if (pos >= _windowSize)
				pos += _windowSize;
			return _buffer[pos];
		}
	}
}
