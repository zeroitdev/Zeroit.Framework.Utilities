// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="ByteSize.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerBytes
{
    /// <summary>
    /// Represents a byte size value.
    /// </summary>
    /// <seealso cref="System.IComparable{Zeroit.Framework.Utilities.StringProcessing.HumanizerBytes.ByteSize}" />
    /// <seealso cref="System.IEquatable{Zeroit.Framework.Utilities.StringProcessing.HumanizerBytes.ByteSize}" />
    /// <seealso cref="System.IComparable" />
#pragma warning disable 1591
    public struct ByteSize : IComparable<ByteSize>, IEquatable<ByteSize>, IComparable
    {
        /// <summary>
        /// The minimum value
        /// </summary>
        public static readonly ByteSize MinValue = FromBits(long.MinValue);
        /// <summary>
        /// The maximum value
        /// </summary>
        public static readonly ByteSize MaxValue = FromBits(long.MaxValue);

        /// <summary>
        /// The bits in byte
        /// </summary>
        public const long BitsInByte = 8;
        /// <summary>
        /// The bytes in kilobyte
        /// </summary>
        public const long BytesInKilobyte = 1024;
        /// <summary>
        /// The bytes in megabyte
        /// </summary>
        public const long BytesInMegabyte = 1048576;
        /// <summary>
        /// The bytes in gigabyte
        /// </summary>
        public const long BytesInGigabyte = 1073741824;
        /// <summary>
        /// The bytes in terabyte
        /// </summary>
        public const long BytesInTerabyte = 1099511627776;

        /// <summary>
        /// The bit symbol
        /// </summary>
        public const string BitSymbol = "b";
        /// <summary>
        /// The byte symbol
        /// </summary>
        public const string ByteSymbol = "B";
        /// <summary>
        /// The kilobyte symbol
        /// </summary>
        public const string KilobyteSymbol = "KB";
        /// <summary>
        /// The megabyte symbol
        /// </summary>
        public const string MegabyteSymbol = "MB";
        /// <summary>
        /// The gigabyte symbol
        /// </summary>
        public const string GigabyteSymbol = "GB";
        /// <summary>
        /// The terabyte symbol
        /// </summary>
        public const string TerabyteSymbol = "TB";

        /// <summary>
        /// Gets the bits.
        /// </summary>
        /// <value>The bits.</value>
        public long Bits { get; private set; }
        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <value>The bytes.</value>
        public double Bytes { get; private set; }
        /// <summary>
        /// Gets the kilobytes.
        /// </summary>
        /// <value>The kilobytes.</value>
        public double Kilobytes { get; private set; }
        /// <summary>
        /// Gets the megabytes.
        /// </summary>
        /// <value>The megabytes.</value>
        public double Megabytes { get; private set; }
        /// <summary>
        /// Gets the gigabytes.
        /// </summary>
        /// <value>The gigabytes.</value>
        public double Gigabytes { get; private set; }
        /// <summary>
        /// Gets the terabytes.
        /// </summary>
        /// <value>The terabytes.</value>
        public double Terabytes { get; private set; }

        /// <summary>
        /// Gets the largest whole number symbol.
        /// </summary>
        /// <value>The largest whole number symbol.</value>
        public string LargestWholeNumberSymbol
        {
            get
            {
                // Absolute value is used to deal with negative values
                if (Math.Abs(Terabytes) >= 1)
                    return TerabyteSymbol;

                if (Math.Abs(Gigabytes) >= 1)
                    return GigabyteSymbol;

                if (Math.Abs(Megabytes) >= 1)
                    return MegabyteSymbol;

                if (Math.Abs(Kilobytes) >= 1)
                    return KilobyteSymbol;

                if (Math.Abs(Bytes) >= 1)
                    return ByteSymbol;

                return BitSymbol;
            }
        }
        /// <summary>
        /// Gets the largest whole number value.
        /// </summary>
        /// <value>The largest whole number value.</value>
        public double LargestWholeNumberValue
        {
            get
            {
                // Absolute value is used to deal with negative values
                if (Math.Abs(Terabytes) >= 1)
                    return Terabytes;

                if (Math.Abs(Gigabytes) >= 1)
                    return Gigabytes;

                if (Math.Abs(Megabytes) >= 1)
                    return Megabytes;

                if (Math.Abs(Kilobytes) >= 1)
                    return Kilobytes;

                if (Math.Abs(Bytes) >= 1)
                    return Bytes;

                return Bits;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ByteSize"/> struct.
        /// </summary>
        /// <param name="byteSize">Size of the byte.</param>
        public ByteSize(double byteSize)
            : this()
        {
            // Get ceiling because bis are whole units
            Bits = (long)Math.Ceiling(byteSize * BitsInByte);

            Bytes = byteSize;
            Kilobytes = byteSize / BytesInKilobyte;
            Megabytes = byteSize / BytesInMegabyte;
            Gigabytes = byteSize / BytesInGigabyte;
            Terabytes = byteSize / BytesInTerabyte;
        }

        /// <summary>
        /// Froms the bits.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize FromBits(long value)
        {
            return new ByteSize(value / (double)BitsInByte);
        }

        /// <summary>
        /// Froms the bytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize FromBytes(double value)
        {
            return new ByteSize(value);
        }

        /// <summary>
        /// Froms the kilobytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize FromKilobytes(double value)
        {
            return new ByteSize(value * BytesInKilobyte);
        }

        /// <summary>
        /// Froms the megabytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize FromMegabytes(double value)
        {
            return new ByteSize(value * BytesInMegabyte);
        }

        /// <summary>
        /// Froms the gigabytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize FromGigabytes(double value)
        {
            return new ByteSize(value * BytesInGigabyte);
        }

        /// <summary>
        /// Froms the terabytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public static ByteSize FromTerabytes(double value)
        {
            return new ByteSize(value * BytesInTerabyte);
        }

        /// <summary>
        /// Converts the value of the current ByteSize object to a string.
        /// The metric prefix symbol (bit, byte, kilo, mega, giga, tera) used is
        /// the largest metric prefix such that the corresponding value is greater
        /// than or equal to one.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", LargestWholeNumberValue, LargestWholeNumberSymbol);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string ToString(string format)
        {
            if (!format.Contains("#") && !format.Contains("0"))
                format = "0.## " + format;

            bool has(string s) => format.IndexOf(s, StringComparison.CurrentCultureIgnoreCase) != -1;
            string output(double n) => n.ToString(format);

            if (has(TerabyteSymbol))
                return output(Terabytes);
            if (has(GigabyteSymbol))
                return output(Gigabytes);
            if (has(MegabyteSymbol))
                return output(Megabytes);
            if (has(KilobyteSymbol))
                return output(Kilobytes);

            // Byte and Bit symbol look must be case-sensitive
            if (format.IndexOf(ByteSymbol, StringComparison.Ordinal) != -1)
                return output(Bytes);

            if (format.IndexOf(BitSymbol, StringComparison.Ordinal) != -1)
                return output(Bits);

            var formattedLargeWholeNumberValue = LargestWholeNumberValue.ToString(format);

            formattedLargeWholeNumberValue = formattedLargeWholeNumberValue.Equals(string.Empty)
                                              ? "0"
                                              : formattedLargeWholeNumberValue;

            return string.Format("{0} {1}", formattedLargeWholeNumberValue, LargestWholeNumberSymbol);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="value">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            ByteSize other;
            if (value is ByteSize)
                other = (ByteSize)value;
            else
                return false;

            return Equals(other);
        }

        /// <summary>
        /// Equalses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(ByteSize value)
        {
            return Bits == value.Bits;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return Bits.GetHashCode();
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.</returns>
        /// <exception cref="ArgumentException">Object is not a ByteSize</exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (!(obj is ByteSize))
                throw new ArgumentException("Object is not a ByteSize");

            return CompareTo((ByteSize) obj);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.</returns>
        public int CompareTo(ByteSize other)
        {
            return Bits.CompareTo(other.Bits);
        }

        /// <summary>
        /// Adds the specified bs.
        /// </summary>
        /// <param name="bs">The bs.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize Add(ByteSize bs)
        {
            return new ByteSize(Bytes + bs.Bytes);
        }

        /// <summary>
        /// Adds the bits.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize AddBits(long value)
        {
            return this + FromBits(value);
        }

        /// <summary>
        /// Adds the bytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize AddBytes(double value)
        {
            return this + FromBytes(value);
        }

        /// <summary>
        /// Adds the kilobytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize AddKilobytes(double value)
        {
            return this + FromKilobytes(value);
        }

        /// <summary>
        /// Adds the megabytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize AddMegabytes(double value)
        {
            return this + FromMegabytes(value);
        }

        /// <summary>
        /// Adds the gigabytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize AddGigabytes(double value)
        {
            return this + FromGigabytes(value);
        }

        /// <summary>
        /// Adds the terabytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize AddTerabytes(double value)
        {
            return this + FromTerabytes(value);
        }

        /// <summary>
        /// Subtracts the specified bs.
        /// </summary>
        /// <param name="bs">The bs.</param>
        /// <returns>ByteSize.</returns>
        public ByteSize Subtract(ByteSize bs)
        {
            return new ByteSize(Bytes - bs.Bytes);
        }

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The result of the operator.</returns>
        public static ByteSize operator +(ByteSize b1, ByteSize b2)
        {
            return new ByteSize(b1.Bytes + b2.Bytes);
        }

        /// <summary>
        /// Implements the ++ operator.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static ByteSize operator ++(ByteSize b)
        {
            return new ByteSize(b.Bytes + 1);
        }

        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static ByteSize operator -(ByteSize b)
        {
            return new ByteSize(-b.Bytes);
        }

        /// <summary>
        /// Implements the -- operator.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static ByteSize operator --(ByteSize b)
        {
            return new ByteSize(b.Bytes - 1);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ByteSize b1, ByteSize b2)
        {
            return b1.Bits == b2.Bits;
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ByteSize b1, ByteSize b2)
        {
            return b1.Bits != b2.Bits;
        }

        /// <summary>
        /// Implements the &lt; operator.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(ByteSize b1, ByteSize b2)
        {
            return b1.Bits < b2.Bits;
        }

        /// <summary>
        /// Implements the &lt;= operator.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(ByteSize b1, ByteSize b2)
        {
            return b1.Bits <= b2.Bits;
        }

        /// <summary>
        /// Implements the &gt; operator.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(ByteSize b1, ByteSize b2)
        {
            return b1.Bits > b2.Bits;
        }

        /// <summary>
        /// Implements the &gt;= operator.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(ByteSize b1, ByteSize b2)
        {
            return b1.Bits >= b2.Bits;
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException">s - String is null or whitespace</exception>
        public static bool TryParse(string s, out ByteSize result)
        {
            // Arg checking
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentNullException(nameof(s), "String is null or whitespace");

            // Setup the result
            result = new ByteSize();

            // Get the index of the first non-digit character
            s = s.TrimStart(); // Protect against leading spaces

            int num;
            var found = false;

            // Acquiring culture specific decimal separator
			var decSep = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                
            // Pick first non-digit number
            for (num = 0; num < s.Length; num++)
                if (!(char.IsDigit(s[num]) || s[num] == decSep))
                {
                    found = true;
                    break;
                }

            if (found == false)
                return false;

            var lastNumber = num;

            // Cut the input string in half
            var numberPart = s.Substring(0, lastNumber).Trim();
            var sizePart = s.Substring(lastNumber, s.Length - lastNumber).Trim();

            // Get the numeric part
            if (!double.TryParse(numberPart, out var number))
                return false;

            // Get the magnitude part
            switch (sizePart.ToUpper())
            {
                case ByteSymbol:
                    if (sizePart == BitSymbol)
                    { // Bits
                        if (number % 1 != 0) // Can't have partial bits
                            return false;

                        result = FromBits((long)number);
                    }
                    else
                    { // Bytes
                        result = FromBytes(number);
                    }
                    break;

                case KilobyteSymbol:
                    result = FromKilobytes(number);
                    break;

                case MegabyteSymbol:
                    result = FromMegabytes(number);
                    break;

                case GigabyteSymbol:
                    result = FromGigabytes(number);
                    break;

                case TerabyteSymbol:
                    result = FromTerabytes(number);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Parses the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>ByteSize.</returns>
        /// <exception cref="FormatException">Value is not in the correct format</exception>
        public static ByteSize Parse(string s)
        {
            if (TryParse(s, out var result))
                return result;

            throw new FormatException("Value is not in the correct format");
        }
    }
}
#pragma warning restore 1591
