// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="IMatchFinder.cs" company="Zeroit Dev Technologies">
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
    /// Interface IInWindowStream
    /// </summary>
    interface IInWindowStream
	{
        /// <summary>
        /// Sets the stream.
        /// </summary>
        /// <param name="inStream">The in stream.</param>
        void SetStream(System.IO.Stream inStream);
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Init();
        /// <summary>
        /// Releases the stream.
        /// </summary>
        void ReleaseStream();
        /// <summary>
        /// Gets the index byte.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Byte.</returns>
        Byte GetIndexByte(Int32 index);
        /// <summary>
        /// Gets the length of the match.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>UInt32.</returns>
        UInt32 GetMatchLen(Int32 index, UInt32 distance, UInt32 limit);
        /// <summary>
        /// Gets the number available bytes.
        /// </summary>
        /// <returns>UInt32.</returns>
        UInt32 GetNumAvailableBytes();
	}

    /// <summary>
    /// Interface IMatchFinder
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.SevenZip.Compression.LZ.IInWindowStream" />
    interface IMatchFinder : IInWindowStream
	{
        /// <summary>
        /// Creates the specified history size.
        /// </summary>
        /// <param name="historySize">Size of the history.</param>
        /// <param name="keepAddBufferBefore">The keep add buffer before.</param>
        /// <param name="matchMaxLen">Maximum length of the match.</param>
        /// <param name="keepAddBufferAfter">The keep add buffer after.</param>
        void Create(UInt32 historySize, UInt32 keepAddBufferBefore,
				UInt32 matchMaxLen, UInt32 keepAddBufferAfter);
        /// <summary>
        /// Gets the matches.
        /// </summary>
        /// <param name="distances">The distances.</param>
        /// <returns>UInt32.</returns>
        UInt32 GetMatches(UInt32[] distances);
        /// <summary>
        /// Skips the specified number.
        /// </summary>
        /// <param name="num">The number.</param>
        void Skip(UInt32 num);
	}
}
