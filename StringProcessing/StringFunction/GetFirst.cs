// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetFirst.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string number = "123456789".GetFirst(5); //12345

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Get fist n charactor in string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="tailLength">Length of the tail.</param>
        /// <returns>System.String.</returns>
        public static string GetFirst(this string source, int tailLength)
        {

            if (source == null || tailLength >= source.Length)
                return source;
            return source.Substring(source.Length - tailLength);
        }


        //---------------------------------Implementation-----------------------------//

        //string name = "mehrdad";
        //Response.Write("Name is : " + name);
        //Response.Write("<br />");
        //Response.Write("Frist Char : "+name.FristChar());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Select Firs character in string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string FirstChar(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length >= 1)
                {
                    return input.Substring(0, 1);
                }
                else
                {
                    return input;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
