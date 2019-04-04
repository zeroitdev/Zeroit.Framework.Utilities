// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Strip.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string s = "abcde";
        //s = s.Strip("cd");   // s becomes "abe"
        //s = s.Strip("c");    // s becomes "abde"
        //s = s.Strip('a', 'e'); // s becomes "bcd"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Strip a string of the specified character.
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="character">The character.</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// string s = "abcde";
        /// s = s.Strip('b');  //s becomes 'acde;
        /// </example>
        public static string Strip(this string s, char character)
        {
            s = s.Replace(character.ToString(), "");

            return s;
        }

        /// <summary>
        /// Strip a string of the specified characters.
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="chars">list of characters to remove from the string</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// string s = "abcde";
        /// s = s.Strip('a', 'd');  //s becomes 'bce;
        /// </example>
        public static string Strip(this string s, params char[] chars)
        {
            foreach (char c in chars)
            {
                s = s.Replace(c.ToString(), "");
            }

            return s;
        }
        /// <summary>
        /// Strip a string of the specified substring.
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="subString">substring to remove</param>
        /// <returns>System.String.</returns>
        /// <example>
        /// string s = "abcde";
        /// s = s.Strip("bcd");  //s becomes 'ae;
        /// </example>
        public static string Strip(this string s, string subString)
        {
            s = s.Replace(subString, "");

            return s;
        }

        //---------------------------------Implementation-----------------------------//

        //string testString = "alpha129";
        //Console.WriteLine("Numeric Only: " + testString.Strip(@"[\D]"); // returns 129
        //Console.WriteLine("Alphabet Only: " + testString.Strip(@"[\d]"); // returns alpha

        //---------------------------------Implementation-----------------------------//


        /// <summary>
        /// Strip unwanted characters and replace them with empty string
        /// </summary>
        /// <param name="data">the string to strip characters from.</param>
        /// <param name="textToStrip">Characters to strip. Can contain Regular expressions</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns>The stripped text if there are matching string.</returns>
        /// <remarks>If error occurred, original text will be the output.</remarks>
        public static string Strip(this string data, string textToStrip, bool doConversion = true)
        {
            var stripText = data;

            if (string.IsNullOrEmpty(data)) return stripText;

            try
            {
                stripText = Regex.Replace(data, textToStrip, string.Empty);
            }
            catch
            {
            }
            return stripText;
        }

        /// <summary>
        /// Strips unwanted characters on the specified string
        /// </summary>
        /// <param name="data">the string to strip characters from.</param>
        /// <param name="textToStrip">Characters to strip. Can contain Regular expressions</param>
        /// <param name="textToReplace">the characters to replace the stripped text</param>
        /// <returns>The stripped text if there are matching string.</returns>
        /// <remarks>If error occurred, original text will be the output.</remarks>
        public static string Strip(this string data, string textToStrip, string textToReplace)
        {
            var stripText = data;

            if (string.IsNullOrEmpty(data)) return stripText;

            try
            {
                stripText = Regex.Replace(data, textToStrip, textToReplace);
            }
            catch
            {
            }
            return stripText;
        }

    }
}
