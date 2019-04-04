// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SplitIntoParts.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string longString = "This is a very long string, which we want to split on smaller parts every max. 30 characters long."; // Length: 98

        //var partLength = 30;
        //var parts = longString.SplitIntoParts(partLength);
        //Console.WriteLine("String: " + longString);
        //Console.WriteLine("Total length: " + longString.Length);
        //Console.WriteLine("Part length: " + partLength);
        //Console.WriteLine("Total parts: " + parts.Count);
        //Console.WriteLine("Parts:");
        //foreach (var part in parts)
        //{
        //    Console.WriteLine("{0}: {1}", part.Length.ToString("D3"), part);
        //}
        //Console.ReadLine();


        //// OUTPUT:
        //// String: This is a very long string, which we want to split on smaller parts every max. 30 characters long.
        //// Total length: 98
        //// Part length: 30
        //// Total parts: 4
        //// Parts:
        //// 030: This is a very long string, wh
        //// 030: ich we want to split on smalle
        //// 030: r parts every max. 30 characte
        //// 008: rs long.

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Splits long string into smaller parts with given length.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="partLength">Length of the part.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> SplitIntoParts(this string input, int partLength)
        {
            var result = new List<string>();
            int partIndex = 0;
            int length = input.Length;
            while (length > 0)
            {
                var tempPartLength = length >= partLength ? partLength : length;
                var part = input.Substring(partIndex * partLength, tempPartLength);
                result.Add(part);
                partIndex++;
                length -= partLength;
            }
            return result;
        }

    }
}
