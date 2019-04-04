// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StringBuilderExtension.cs" company="Zeroit Dev Technologies">
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
using System.Text;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//



        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Substrings the specified start index.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string Substring(this StringBuilder sb, int startIndex, int length)
        {
            return sb.ToString(startIndex, length);
        }

        /// <summary>
        /// Removes the specified ch.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="ch">The ch.</param>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder Remove(this StringBuilder sb, char ch)
        {
            for (int i = 0; i < sb.Length;)
            {
                if (sb[i] == ch)
                    sb.Remove(i, 1);
                else
                    i++;
            }
            return sb;
        }

        /// <summary>
        /// Removes from end.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="num">The number.</param>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder RemoveFromEnd(this StringBuilder sb, int num)
        {
            return sb.Remove(sb.Length - num, num);
        }

        /// <summary>
        /// Clears the specified sb.
        /// </summary>
        /// <param name="sb">The sb.</param>
        public static void Clear(this StringBuilder sb)
        {
            sb.Length = 0;
        }

        /// <summary>
        /// Trim left spaces of string
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder LTrim(this StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                int length = 0;
                int num2 = sb.Length;
                while ((sb[length] == ' ') && (length < num2))
                {
                    length++;
                }
                if (length > 0)
                {
                    sb.Remove(0, length);
                }
            }
            return sb;
        }

        /// <summary>
        /// Trim right spaces of string
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder RTrim(this StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                int length = sb.Length;
                int num2 = length - 1;
                while ((sb[num2] == ' ') && (num2 > -1))
                {
                    num2--;
                }
                if (num2 < (length - 1))
                {
                    sb.Remove(num2 + 1, (length - num2) - 1);
                }
            }
            return sb;
        }

        /// <summary>
        /// Trim spaces around string
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <returns>StringBuilder.</returns>
        public static StringBuilder Trim(this StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                int length = 0;
                int num2 = sb.Length;
                while ((sb[length] == ' ') && (length < num2))
                {
                    length++;
                }
                if (length > 0)
                {
                    sb.Remove(0, length);
                    num2 = sb.Length;
                }
                length = num2 - 1;
                while ((sb[length] == ' ') && (length > -1))
                {
                    length--;
                }
                if (length < (num2 - 1))
                {
                    sb.Remove(length + 1, (num2 - length) - 1);
                }
            }
            return sb;
        }

        /// <summary>
        /// Get index of a char
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int IndexOf(this StringBuilder sb, char value)
        {
            return IndexOf(sb, value, 0);
        }

        /// <summary>
        /// Get index of a char starting from a given index
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int32.</returns>
        public static int IndexOf(this StringBuilder sb, char value, int startIndex)
        {
            for (int i = startIndex; i < sb.Length; i++)
            {
                if (sb[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Get index of a string
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int IndexOf(this StringBuilder sb, string value)
        {
            return IndexOf(sb, value, 0, false);
        }

        /// <summary>
        /// Get index of a string from a given index
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int32.</returns>
        public static int IndexOf(this StringBuilder sb, string value, int startIndex)
        {
            return IndexOf(sb, value, startIndex, false);
        }

        /// <summary>
        /// Get index of a string with case option
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>System.Int32.</returns>
        public static int IndexOf(this StringBuilder sb, string value, bool ignoreCase)
        {
            return IndexOf(sb, value, 0, ignoreCase);
        }

        /// <summary>
        /// Get index of a string from a given index with case option
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>System.Int32.</returns>
        public static int IndexOf(this StringBuilder sb, string value, int startIndex, bool ignoreCase)
        {
            int num3;
            int length = value.Length;
            int num2 = (sb.Length - length) + 1;
            if (ignoreCase == false)
            {
                for (int i = startIndex; i < num2; i++)
                {
                    if (sb[i] == value[0])
                    {
                        num3 = 1;
                        while ((num3 < length) && (sb[i + num3] == value[num3]))
                        {
                            num3++;
                        }
                        if (num3 == length)
                        {
                            return i;
                        }
                    }
                }
            }
            else
            {
                for (int j = startIndex; j < num2; j++)
                {
                    if (char.ToLower(sb[j]) == char.ToLower(value[0]))
                    {
                        num3 = 1;
                        while ((num3 < length) && (char.ToLower(sb[j + num3]) == char.ToLower(value[num3])))
                        {
                            num3++;
                        }
                        if (num3 == length)
                        {
                            return j;
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Determine whether a string starts with a given text
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool StartsWith(this StringBuilder sb, string value)
        {
            return StartsWith(sb, value, 0, false);
        }

        /// <summary>
        /// Determine whether a string starts with a given text (with case option)
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool StartsWith(this StringBuilder sb, string value, bool ignoreCase)
        {
            return StartsWith(sb, value, 0, ignoreCase);
        }

        /// <summary>
        /// Determine whether a string is begin with a given text
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool StartsWith(this StringBuilder sb, string value, int startIndex, bool ignoreCase)
        {
            int length = value.Length;
            int num2 = startIndex + length;
            if (ignoreCase == false)
            {
                for (int i = startIndex; i < num2; i++)
                {
                    if (sb[i] != value[i - startIndex])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = startIndex; j < num2; j++)
                {
                    if (char.ToLower(sb[j]) != char.ToLower(value[j - startIndex]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
