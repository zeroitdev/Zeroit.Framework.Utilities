// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ByteSizeExtensions.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.HumanizerBytes;

// ReSharper disable once CheckNamespace
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Provides extension methods for ByteSize
    /// </summary>
    public static class ByteSizeExtensions
    {
        /// <summary>
        /// Considers input as bits
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bits(this byte input)
        {
            return ByteSize.FromBits(input);
        }

        /// <summary>
        /// Considers input as bits
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bits(this sbyte input)
        {
            return ByteSize.FromBits(input);
        }

        /// <summary>
        /// Considers input as bits
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bits(this short input)
        {
            return ByteSize.FromBits(input);
        }

        /// <summary>
        /// Considers input as bits
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bits(this ushort input)
        {
            return ByteSize.FromBits(input);
        }

        /// <summary>
        /// Considers input as bits
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bits(this int input)
        {
            return ByteSize.FromBits(input);
        }

        /// <summary>
        /// Considers input as bits
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bits(this uint input)
        {
            return ByteSize.FromBits(input);
        }

        /// <summary>
        /// Considers input as bits
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bits(this long input)
        {
            return ByteSize.FromBits(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this byte input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this sbyte input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this short input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this ushort input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this int input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this uint input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this double input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as bytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Bytes(this long input)
        {
            return ByteSize.FromBytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this byte input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this sbyte input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this short input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this ushort input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this int input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this uint input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this double input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as kilobytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Kilobytes(this long input)
        {
            return ByteSize.FromKilobytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this byte input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this sbyte input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this short input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this ushort input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this int input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this uint input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this double input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as megabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Megabytes(this long input)
        {
            return ByteSize.FromMegabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this byte input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this sbyte input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this short input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this ushort input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this int input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this uint input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this double input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as gigabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Gigabytes(this long input)
        {
            return ByteSize.FromGigabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this byte input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this sbyte input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this short input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this ushort input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this int input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this uint input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this double input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Considers input as terabytes
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize Terabytes(this long input)
        {
            return ByteSize.FromTerabytes(input);
        }

        /// <summary>
        /// Turns a byte quantity into human readable form, eg 2 GB
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="format">The string format to use</param>
        /// <returns>System.String.</returns>
        public static string Humanize(this ByteSize input, string format = null)
        {
            return string.IsNullOrWhiteSpace(format) ? input.ToString() : input.ToString(format);
        }

        /// <summary>
        /// Turns a quantity of bytes in a given interval into a rate that can be manipulated
        /// </summary>
        /// <param name="size">Quantity of bytes</param>
        /// <param name="interval">Interval to create rate for</param>
        /// <returns>ByteRate.</returns>
        public static ByteRate Per(this ByteSize size, TimeSpan interval)
        {
            return new ByteRate(size, interval);
        }
    }
}
