// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-25-2018
// ***********************************************************************
// <copyright file="_StringFunctions.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Contains a collection of static string functions not found in the .NET Framework
    /// </summary>
    public static partial class StringFunctions
    {

        /// <summary>
        /// Returns a string representation of an array. Each element is written on a new line.
        /// String processing functions that use the primitive data type string.
        /// Effective for small-to-medium strings.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="dummy">The dummy.</param>
        /// <returns>System.String.</returns>
        public static string ArrayToString(this IList array, int dummy = 0)
        {
            //Validate input
            if (array == null || array.Count == 0)
                return string.Empty;

            string output = string.Empty;

            for (int i = 0; i < array.Count; i++)
            {
                output += array[i].ToString();

                if (i != array.Count - 1) //don't add separator at the end of the list
                    output += Environment.NewLine;
            }

            return output;
        }

        /// <summary>
        /// Returns a string representation of an array. Each element is separated by the specified string.
        /// String processing functions that use the primitive data type string. Effective for small-to-medium strings.
        /// </summary>
        /// <param name="array">The collection of objects.</param>
        /// <param name="separator">The string sequence to separate each element in the collection</param>
        /// <param name="dummy">The dummy.</param>
        /// <returns>System.String.</returns>
        public static string ArrayToString(this IList array, string separator, int dummy = 0)
        {
            //Validate input
            if (array == null || array.Count == 0)
                return string.Empty;

            string output = string.Empty;

            for (int i = 0; i < array.Count; i++)
            {
                output += array[i].ToString();

                if (i != array.Count - 1) //don't add separator at the end of the list
                    output += separator;
            }

            return output;
        }

        /// <summary>
        /// Returns a string representation of an array. Each element is written on a new line.
        /// String processing functions that use the the StringBuilder class. Effective for large strings.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>System.String.</returns>
        public static string ArrayToString(this IList array)
        {
            //Validate input
            if (array == null || array.Count == 0)
                return string.Empty;

            StringBuilder output = new StringBuilder(array.Count * 2);

            for (int i = 0; i < array.Count; i++)
            {
                output.Append(array[i].ToString());

                if (i != array.Count - 1) //don't add separator at the end of the list
                    output.Append(Environment.NewLine);
            }

            return output.ToString();
        }

        /// <summary>
        /// Returns a string representation of an array. Each element is separated by the specified string.
        /// String processing functions that use the the StringBuilder class. Effective for large strings.
        /// </summary>
        /// <param name="array">The collection of objects.</param>
        /// <param name="separator">The string sequence to separate each element in the collection</param>
        /// <returns>System.String.</returns>
        public static string ArrayToString(this IList array, string separator)
        {
            //Validate input
            if (array == null || array.Count == 0)
                return string.Empty;

            StringBuilder output = new StringBuilder(array.Count * 2);

            for (int i = 0; i < array.Count; i++)
            {
                output.Append(array[i].ToString());

                if (i != array.Count - 1) //don't add separator at the end of the list
                    output.Append(separator);
            }

            return output.ToString();
        }

        /// <summary>
        /// Returns a string with characters in reverse order.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string Reverse(this string input)
        {
            //Validate input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] outputChars = input.ToCharArray();

            //Reverse
            Array.Reverse(outputChars);

            //build a string from the processed characters and return it
            return new string(outputChars);
        }

        /// <summary>
        /// Returns a string with a given seperator inserted after every character.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="separator">The separator to insert.</param>
        /// <returns>System.String.</returns>
        public static string InsertSeparator(this string input, string separator)
        {
            //Validate string
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            List<char> outputChars = new List<char>(input.ToCharArray());
            char[] separatorChars = separator.ToCharArray();

            int i = 1;
            while (i < outputChars.Count)
            {
                if (i != outputChars.Count) //don't add separator to the end of string
                    outputChars.InsertRange(i, separatorChars);

                i += 1 + separator.Length; //go up the interval amount plus separator
            }

            return new string(outputChars.ToArray());
        }

        /// <summary>
        /// Returns a string with a given seperator inserted after a specified interval of characters.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="separator">The separator to insert.</param>
        /// <param name="interval">The number of characters between separators.</param>
        /// <returns>System.String.</returns>
        public static string InsertSeparator(this string input, string separator, int interval)
        {
            //Validate string
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            List<char> outputChars = new List<char>(input.ToCharArray());
            char[] separatorChars = separator.ToCharArray();

            int i = interval;
            while (i < outputChars.Count)
            {
                if (i != outputChars.Count) //don't add separator to the end of string
                    outputChars.InsertRange(i, separatorChars);

                i += interval + separator.Length; //go up the interval amount plus separator
            }

            return new string(outputChars.ToArray());
        }

        /// <summary>
        /// Returns a string with any vowel character removed.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string RemoveVowels(this string input)
        {
            //Validate input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            List<char> outputChars = new List<char>(input.ToCharArray());

            //Iterate backwards to avoid problems from removing characters
            for (int i = outputChars.Count - 1; i >= 0; i--)
            {
                if (outputChars[i] == 'a' || outputChars[i] == 'A' ||
                    outputChars[i] == 'e' || outputChars[i] == 'E' ||
                    outputChars[i] == 'i' || outputChars[i] == 'I' ||
                    outputChars[i] == 'o' || outputChars[i] == 'O' ||
                    outputChars[i] == 'u' || outputChars[i] == 'U')
                    //not a vowel, remove it
                    outputChars.RemoveAt(i);
            }

            return new string(outputChars.ToArray());
        }

        /// <summary>
        /// Returns a string with only the vowel characters.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string KeepVowels(this string input)
        {
            //Validate input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            List<char> outputChars = new List<char>(input.ToCharArray());

            //Iterate backwards to avoid problems from removing characters
            for (int i = outputChars.Count - 1; i >= 0; i--)
            {
                if (!(outputChars[i] == 'a' || outputChars[i] == 'A' ||
                      outputChars[i] == 'e' || outputChars[i] == 'E' ||
                      outputChars[i] == 'i' || outputChars[i] == 'I' ||
                      outputChars[i] == 'o' || outputChars[i] == 'O' ||
                      outputChars[i] == 'u' || outputChars[i] == 'U'))
                    //a vowel, remove it
                    outputChars.RemoveAt(i);
            }

            return new string(outputChars.ToArray());
        }

        /// <summary>
        /// Returns a string with alternated letter casing (upper/lower). First character of the string stays the same.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string AlternateCases(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length == 1) return input; //Nothing to alternate

            char[] inputChars = input.ToCharArray(); //character array representing the string
            bool toUpper = !char.IsUpper(inputChars[0]);

            for (int i = 1; i < inputChars.Length; i++) //start with the section character
            {
                if (toUpper)
                    inputChars[i] = char.ToUpper(inputChars[i]);
                else
                    inputChars[i] = char.ToLower(inputChars[i]);

                toUpper = !toUpper; //alternate
            }

            return new string(inputChars);
        }

        /// <summary>
        /// Returns a string with the opposite letter casing for each character.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string SwapCases(this string input)
        {
            //Validate input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] inputChars = input.ToCharArray();

            for (int i = 0; i < inputChars.Length; i++)
            {
                //Apply the opposite letter casing
                if (char.IsUpper(inputChars[i]))
                    inputChars[i] = char.ToLower(inputChars[i]);
                else
                    inputChars[i] = char.ToUpper(inputChars[i]);
            }

            return new string(inputChars);
        }

        /// <summary>
        /// Capitalizes the first character in a string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length == 1) return input.ToUpper();

            return input[0].ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// Capitalises the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string Capitalise(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Returns the initials of each word in a string. Words must be separated with spaces.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="capitalizeInitials">True to capitalize each initial in the output string.</param>
        /// <param name="preserveSpaces">True to preserver the spaces between initials in the output string.</param>
        /// <param name="includePeriod">True to include a '.' after each intiali</param>
        /// <returns>System.String.</returns>
        public static string GetInitials(this string input, bool capitalizeInitials, bool preserveSpaces, bool includePeriod)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    if (capitalizeInitials)
                        words[i] = char.ToUpper(words[i][0]).ToString(); //only keep the first letter
                    else
                        words[i] = words[i][0].ToString(); //only keep the first letter

                    if (includePeriod)
                        words[i] += ".";
                }
            }

            if (preserveSpaces)
                return string.Join(" ", words);
            else
                return string.Join("", words);
        }

        /// <summary>
        /// Returns the initials of each word in a string. Words are separated according to the sepecified string sequence.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="separator">The string sequence that separates words.</param>
        /// <param name="capitalizeInitials">True to capitalize each initial in the output string.</param>
        /// <param name="preserveSeparator">True to preserver the spaces between initials in the output string.</param>
        /// <param name="includePeriod">if set to <c>true</c> [include period].</param>
        /// <returns>System.String.</returns>
        public static string GetInitials(this string input, string separator, bool capitalizeInitials, bool preserveSeparator, bool includePeriod)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string[] words = input.Split(separator.ToCharArray());

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    if (capitalizeInitials)
                        words[i] = char.ToUpper(words[i][0]).ToString(); //only keep the first letter
                    else
                        words[i] = words[i][0].ToString(); //only keep the first letter

                    if (includePeriod)
                        words[i] += ".";
                }
            }

            if (preserveSeparator)
                return string.Join(separator, words);
            else
                return string.Join("", words);
        }

        /// <summary>
        /// Returns a string with each word's first character capitalized. Words must be separated by spaces.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string GetTitle(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                //Capitalize each word
                if (words[i].Length > 0)
                    words[i] = char.ToUpper(words[i][0]).ToString() + words[i].Substring(1);
            }

            return string.Join(" ", words);
        }

        /// <summary>
        /// Returns a string with each word's first character capitalized. Words are separated according to the sepecified string sequence.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="separator">The string sequence that separates words.</param>
        /// <returns>System.String.</returns>
        public static string GetTitle(this string input, string separator)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string[] words = input.Split(separator.ToCharArray());

            for (int i = 0; i < words.Length; i++)
            {
                //Capitalize each word
                if (words[i].Length > 0)
                    words[i] = char.ToUpper(words[i][0]).ToString() + words[i].Substring(1);
            }

            return string.Join(separator, words);
        }

        /// <summary>
        /// Returns a segment of a string, marked by the start and end index (exclusive).
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="start">The start index position.</param>
        /// <param name="end">The end index position. (exclusive)</param>
        /// <returns>System.String.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// start index cannot be less than zero.
        /// or
        /// start index cannot be greater than the length of the string.
        /// or
        /// end index cannot be less than zero.
        /// or
        /// end index cannot be greater than the length of the string.
        /// or
        /// start index cannot be greater than the end index.
        /// </exception>
        public static string SubstringEnd(this string input, int start, int end)
        {
            //Verify input
            if (string.IsNullOrEmpty(input) || start == end)
                return string.Empty;

            if (start == 0 && end == input.Length)
                return input; //entire string

            if (start < 0)
                throw new IndexOutOfRangeException("start index cannot be less than zero.");

            if (start > input.Length)
                throw new IndexOutOfRangeException("start index cannot be greater than the length of the string.");

            if (end < 0)
                throw new IndexOutOfRangeException("end index cannot be less than zero.");

            if (end > input.Length)
                throw new IndexOutOfRangeException("end index cannot be greater than the length of the string.");

            if (start > end)
                throw new IndexOutOfRangeException("start index cannot be greater than the end index.");

            return input.Substring(start, end - start);
        }

        /// <summary>
        /// Returns the character in a string at a given index counting from the right.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="index">The starting position from the right. (Index 0 = last character)</param>
        /// <returns>System.Char.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Index cannot be less than zero.
        /// or
        /// Index cannot be larger than the length of the string
        /// </exception>
        public static char CharRight(this string input, int index)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return new char();

            if (input.Length - index - 1 >= input.Length)
                throw new IndexOutOfRangeException("Index cannot be less than zero.");

            if (input.Length - index - 1 < 0)
                throw new IndexOutOfRangeException("Index cannot be larger than the length of the string");

            return input[input.Length - index - 1];
        }

        /// <summary>
        /// Returns the character at a position given by the startingIndex plus the given count.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="startingIndex">The starting index position.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Char.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// startingIndex cannot be less than zero.
        /// or
        /// startingIndex cannot be greater than the length of the string.
        /// or
        /// startingIndex + count cannot be less than zero.
        /// or
        /// startingIndex + count cannot be greater than the length of the string.
        /// </exception>
        public static char CharMid(this string input, int startingIndex, int count)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return new char();

            if (startingIndex < 0)
                throw new IndexOutOfRangeException("startingIndex cannot be less than zero.");

            if (startingIndex >= input.Length)
                throw new IndexOutOfRangeException("startingIndex cannot be greater than the length of the string.");

            if (startingIndex + count < 0)
                throw new IndexOutOfRangeException("startingIndex + count cannot be less than zero.");

            if (startingIndex + count >= input.Length)
                throw new IndexOutOfRangeException("startingIndex + count cannot be greater than the length of the string.");

            return input[startingIndex + count];
        }

        /// <summary>
        /// Returns the total number of times a given sequence appears in a string.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="sequence">The string sequence to count.</param>
        /// <param name="ignoreCase">True, to ignore the difference in case between the sequence and the original string.</param>
        /// <returns>System.Int32.</returns>
        public static int CountString(this string input, string sequence, bool ignoreCase)
        {
            //Verify input
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(sequence))
                return 0;

            int count = 0;
            string inputSegment = null; //holds the current segment being compared

            for (int i = 0; i < input.Length; i++)
            {
                if (i + sequence.Length > input.Length)
                    break; //sequence doesn't fit anymore

                inputSegment = input.Substring(i, sequence.Length);

                if (string.Compare(inputSegment, sequence, ignoreCase) == 0)
                    count++; //another match found
            }
            return count;
        }

        /// <summary>
        /// Returns an array of every index where a sequence is found on the specified string. Note: Overlaps will be counted.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="sequence">The string sequence to seek.</param>
        /// <param name="ignoreCase">True, to ignore the difference in case between the sequence and the original string.</param>
        /// <returns>System.Int32[].</returns>
        public static int[] IndexOfAll(this string input, string sequence, bool ignoreCase)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return new int[0]; //empty array

            List<int> indices = new List<int>();

            string inputSegment = null; //holds the current segment being compared

            for (int i = 0; i < input.Length; i++)
            {
                if (i + sequence.Length > input.Length)
                    break; //sequence doesn't fit anymore

                inputSegment = input.Substring(i, sequence.Length);

                if (string.Compare(inputSegment, sequence, ignoreCase) == 0)
                    indices.Add(i);
            }

            //Copy entries over to an array
            int[] output = indices.ToArray();
            indices.Clear();

            return output;
        }

        /// <summary>
        /// Returns an array of every index where a sequence is found on the specified string. Note: Overlaps will be counted.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="sequence">The string sequence to seek.</param>
        /// <param name="startIndex">Index from which to start seeking.</param>
        /// <param name="ignoreCase">True, to ignore the difference in case between the sequence and the original string.</param>
        /// <returns>System.Int32[].</returns>
        public static int[] IndexOfAll(this string input, string sequence, int startIndex, bool ignoreCase)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return new int[0]; //empty array

            List<int> indices = new List<int>();

            string inputSegment = null; //holds the current segment being compared

            for (int i = startIndex; i < input.Length; i++)
            {
                if (i + sequence.Length > input.Length)
                    break; //sequence doesn't fit anymore

                inputSegment = input.Substring(i, sequence.Length);

                if (string.Compare(inputSegment, sequence, ignoreCase) == 0)
                    indices.Add(i);
            }

            //Copy entries over to an array
            int[] output = indices.ToArray();
            indices.Clear();

            return output;
        }

        /// <summary>
        /// Returns whether the letter casing in a string is alternating.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is alternate cases] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsAlternateCases(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input) || input.Length == 1) return false;

            bool isLastUpper = char.IsUpper(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (isLastUpper)
                {
                    if (char.IsUpper(input[i]))
                        return false; //two upper-cases in a row
                }
                else
                {
                    if (char.IsLower(input[i]))
                        return false; //two lower-cases in a row
                }

                isLastUpper = !isLastUpper; //alternate
            }

            return true;
        }

        /// <summary>
        /// Returns true if the first character in a string is upper case.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input is capitalized; otherwise, <c>false</c>.</returns>
        public static bool IsCapitalized(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input)) return false;

            return char.IsUpper(input[0]);
        }

        /// <summary>
        /// Returns whether a string is in all lower case.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is lower case] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsLowerCase(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input)) return false;

            for (int i = 0; i < input.Length; i++)
            {
                //A single non-lower case character makes function false,
                //unless it is a chracter other than a letter
                if (!char.IsLower(input[i]) && char.IsLetter(input[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns whether a string is in all upper case.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is upper case] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsUpperCase(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input)) return false;

            for (int i = 0; i < input.Length; i++)
            {
                //A single non-upper case character makes function false,
                //unless it is a chracter other than a letter
                if (!char.IsUpper(input[i]) && char.IsLetter(input[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns whether a string contains any vowel letters
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input has vowels; otherwise, <c>false</c>.</returns>
        public static bool HasVowels(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input)) return false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'A' ||
                    input[i] == 'e' || input[i] == 'E' ||
                    input[i] == 'i' || input[i] == 'I' ||
                    input[i] == 'o' || input[i] == 'O' ||
                    input[i] == 'u' || input[i] == 'U')
                    return true; //a single vowel makes function true
            }

            return false;
        }

        /// <summary>
        /// Returns whether a string is all empty spaces
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input is spaces; otherwise, <c>false</c>.</returns>
        public static bool IsSpaces(this string input)
        {
            return string.IsNullOrEmpty(input) || input.Replace(" ", "").Length == 0;
        }

        /// <summary>
        /// Returns whether a string is composed of only a single character.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is repeated character] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsRepeatedChar(this string input)
        {
            return string.IsNullOrEmpty(input) || input.Replace(input[0].ToString(), "").Length == 0;
        }

        /// <summary>
        /// Returns whether a string is composed of only numeric characters.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input is numeric; otherwise, <c>false</c>.</returns>
        public static bool IsNumeric(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return false;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsNumber(input[i]))
                    return false; //single non-numeric integer makes function false
            }
            return true;
        }

        /// <summary>
        /// Returns whether a string contains any numberic characters.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input has numeric; otherwise, <c>false</c>.</returns>
        public static bool HasNumeric(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return false;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsNumber(input[i]))
                    return true; //single numeric integer makes function true
            }
            return false;
        }

        /// <summary>
        /// Returns whether a string is composed of only letter and number characters.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is alpha numeric] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsAlphaNumeric(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input)) return false;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]) && !char.IsNumber(input[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns whether a string is composed of all letter characters.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input is letters; otherwise, <c>false</c>.</returns>
        public static bool IsLetters(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input)) return false;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns whether a string is formatted like a title, ie the first chracter of each word is capitalized.
        /// Words must be separated by spaces.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input is title; otherwise, <c>false</c>.</returns>
        public static bool IsTitle(this string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return false;

            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    if (!char.IsUpper(words[i][0]))
                        return false;
            }
            return true;
        }

        /// <summary>
        /// Returns whether a string is formatted like a title, ie the first chracter of each word is capitalized.
        /// Words are separated according to the sepecified string sequence.
        /// </summary>
        /// <param name="input">The original string.</param>
        /// <param name="separator">The string sequence that separates words.</param>
        /// <returns><c>true</c> if the specified separator is title; otherwise, <c>false</c>.</returns>
        public static bool IsTitle(this string input, string separator)
        {
            //Verify input
            if (string.IsNullOrEmpty(input))
                return false;

            string[] words = input.Split(separator.ToCharArray());

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    if (!char.IsUpper(words[i][0]))
                        return false;
            }
            return true;
        }

        /// <summary>
        /// Returns whether a string is in a valid email address format.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if [is email address] [the specified input]; otherwise, <c>false</c>.</returns>
        public static bool IsEmailAddress(this string input)
        {
            //Validate input
            if (string.IsNullOrEmpty(input))
                return false;

            if (input.IndexOf('@') != -1 &&
                input.Length >= 5) //any email address will be at least 5 characters (a@a.a)
            {
                int indexOfDot = input.LastIndexOf('.');
                if (indexOfDot > input.IndexOf('@')) //last period must be after the @ 
                    return true;
            }

            return false;
        }

        /// <summary>
        /// To the keywords.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>String.</returns>
        public static String ToKeywords(this String str)
        {
            //return String.Join(",", Regex.Replace(Regex.Replace(Regex.Replace(str, @"[\W]{1,}", " "), @"\b[\w]{0,3}\b", String.Empty).Trim(), @"[\W]{1,}", " ").Split(' '));
            return Regex.Replace(Regex.Replace(Regex.Replace(str, @"[\W]{1,}", " "), @"\b[\w]{0,3}\b", String.Empty).Trim(), @"[\W]{1,}", ",");
        }

        
    }
}
