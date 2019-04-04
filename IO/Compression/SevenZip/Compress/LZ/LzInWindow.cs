// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="LzInWindow.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.IO.Compression.SevenZip.Compression.LZ
{
    /// <summary>
    /// Class InWindow.
    /// </summary>
    public class InWindow
	{
        /// <summary>
        /// The buffer base
        /// </summary>
        public Byte[] _bufferBase = null; // pointer to buffer with data
                                          /// <summary>
                                          /// The stream
                                          /// </summary>
        System.IO.Stream _stream;
        /// <summary>
        /// The position limit
        /// </summary>
        UInt32 _posLimit; // offset (from _buffer) of first byte when new block reading must be done
                          /// <summary>
                          /// The stream end was reached
                          /// </summary>
        bool _streamEndWasReached; // if (true) then _streamPos shows real end of stream

        /// <summary>
        /// The pointer to last safe position
        /// </summary>
        UInt32 _pointerToLastSafePosition;

        /// <summary>
        /// The buffer offset
        /// </summary>
        public UInt32 _bufferOffset;

        /// <summary>
        /// The block size
        /// </summary>
        public UInt32 _blockSize; // Size of Allocated memory block
                                  /// <summary>
                                  /// The position
                                  /// </summary>
        public UInt32 _pos; // offset (from _buffer) of curent byte
                            /// <summary>
                            /// The keep size before
                            /// </summary>
        UInt32 _keepSizeBefore; // how many BYTEs must be kept in buffer before _pos
                                /// <summary>
                                /// The keep size after
                                /// </summary>
        UInt32 _keepSizeAfter; // how many BYTEs must be kept buffer after _pos
                               /// <summary>
                               /// The stream position
                               /// </summary>
        public UInt32 _streamPos; // offset (from _buffer) of first not read byte from Stream

        /// <summary>
        /// Moves the block.
        /// </summary>
        public void MoveBlock()
		{
			UInt32 offset = (UInt32)(_bufferOffset) + _pos - _keepSizeBefore;
			// we need one additional byte, since MovePos moves on 1 byte.
			if (offset > 0)
				offset--;
			
			UInt32 numBytes = (UInt32)(_bufferOffset) + _streamPos - offset;

			// check negative offset ????
			for (UInt32 i = 0; i < numBytes; i++)
				_bufferBase[i] = _bufferBase[offset + i];
			_bufferOffset -= offset;
		}

        /// <summary>
        /// Reads the block.
        /// </summary>
        public virtual void ReadBlock()
		{
			if (_streamEndWasReached)
				return;
			while (true)
			{
				int size = (int)((0 - _bufferOffset) + _blockSize - _streamPos);
				if (size == 0)
					return;
				int numReadBytes = _stream.Read(_bufferBase, (int)(_bufferOffset + _streamPos), size);
				if (numReadBytes == 0)
				{
					_posLimit = _streamPos;
					UInt32 pointerToPostion = _bufferOffset + _posLimit;
					if (pointerToPostion > _pointerToLastSafePosition)
						_posLimit = (UInt32)(_pointerToLastSafePosition - _bufferOffset);

					_streamEndWasReached = true;
					return;
				}
				_streamPos += (UInt32)numReadBytes;
				if (_streamPos >= _pos + _keepSizeAfter)
					_posLimit = _streamPos - _keepSizeAfter;
			}
		}

        /// <summary>
        /// Frees this instance.
        /// </summary>
        void Free() { _bufferBase = null; }

        /// <summary>
        /// Creates the specified keep size before.
        /// </summary>
        /// <param name="keepSizeBefore">The keep size before.</param>
        /// <param name="keepSizeAfter">The keep size after.</param>
        /// <param name="keepSizeReserv">The keep size reserv.</param>
        public void Create(UInt32 keepSizeBefore, UInt32 keepSizeAfter, UInt32 keepSizeReserv)
		{
			_keepSizeBefore = keepSizeBefore;
			_keepSizeAfter = keepSizeAfter;
			UInt32 blockSize = keepSizeBefore + keepSizeAfter + keepSizeReserv;
			if (_bufferBase == null || _blockSize != blockSize)
			{
				Free();
				_blockSize = blockSize;
				_bufferBase = new Byte[_blockSize];
			}
			_pointerToLastSafePosition = _blockSize - keepSizeAfter;
		}

        /// <summary>
        /// Sets the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void SetStream(System.IO.Stream stream) { _stream = stream; }
        /// <summary>
        /// Releases the stream.
        /// </summary>
        public void ReleaseStream() { _stream = null; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
		{
			_bufferOffset = 0;
			_pos = 0;
			_streamPos = 0;
			_streamEndWasReached = false;
			ReadBlock();
		}

        /// <summary>
        /// Moves the position.
        /// </summary>
        public void MovePos()
		{
			_pos++;
			if (_pos > _posLimit)
			{
				UInt32 pointerToPostion = _bufferOffset + _pos;
				if (pointerToPostion > _pointerToLastSafePosition)
					MoveBlock();
				ReadBlock();
			}
		}

        /// <summary>
        /// Gets the index byte.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Byte.</returns>
        public Byte GetIndexByte(Int32 index) { return _bufferBase[_bufferOffset + _pos + index]; }

        // index + limit have not to exceed _keepSizeAfter;
        /// <summary>
        /// Gets the length of the match.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>UInt32.</returns>
        public UInt32 GetMatchLen(Int32 index, UInt32 distance, UInt32 limit)
		{
			if (_streamEndWasReached)
				if ((_pos + index) + limit > _streamPos)
					limit = _streamPos - (UInt32)(_pos + index);
			distance++;
			// Byte *pby = _buffer + (size_t)_pos + index;
			UInt32 pby = _bufferOffset + _pos + (UInt32)index;

			UInt32 i;
			for (i = 0; i < limit && _bufferBase[pby + i] == _bufferBase[pby + i - distance]; i++);
			return i;
		}

        /// <summary>
        /// Gets the number available bytes.
        /// </summary>
        /// <returns>UInt32.</returns>
        public UInt32 GetNumAvailableBytes() { return _streamPos - _pos; }

        /// <summary>
        /// Reduces the offsets.
        /// </summary>
        /// <param name="subValue">The sub value.</param>
        public void ReduceOffsets(Int32 subValue)
		{
			_bufferOffset += (UInt32)subValue;
			_posLimit -= (UInt32)subValue;
			_pos -= (UInt32)subValue;
			_streamPos -= (UInt32)subValue;
		}
	}
}
