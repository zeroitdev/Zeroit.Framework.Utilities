// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Contains.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        // This example is based on the example from http://msdn.microsoft.com/en-us/library/ms224425.aspx

        //using System;

        //class Sample
        //    {
        //        public static void Main()
        //        {
        //            // Define a string to search for.
        //            // U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
        //            string CapitalAWithRing = "\u00c5";

        //            // Define a string to search. 
        //            // The result of combining the characters LATIN SMALL LETTER A and COMBINING 
        //            // RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character 
        //            // LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
        //            string cat = "A Cheshire c" + "\u0061\u030a" + "t";

        //            StringComparison[] scValues = {
        //            StringComparison.CurrentCulture,
        //            StringComparison.CurrentCultureIgnoreCase,
        //            StringComparison.InvariantCulture,
        //            StringComparison.InvariantCultureIgnoreCase,
        //            StringComparison.Ordinal,
        //            StringComparison.OrdinalIgnoreCase };

        //            // Display the current culture because culture affects the result. For example, 
        //            // try this code example with the "sv-SE" (Swedish-Sweden) culture.
        //            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        //            Console.WriteLine("The current culture is \"{0}\" - {1}.",
        //                            Thread.CurrentThread.CurrentCulture.Name,
        //                            Thread.CurrentThread.CurrentCulture.DisplayName);

        //            // Display the string to search for and the string to search.
        //            Console.WriteLine("Search for the string \"{0}\" in the string \"{1}\"",
        //                            CapitalAWithRing, cat);
        //            Console.WriteLine();


        //            foreach (StringComparison sc in scValues)
        //            {
        //                var isInString = cat.Contains(CapitalAWithRing, sc);
        //                Console.WriteLine("Comparison: {0,-28} Is In String?: {1}", sc, isInString);
        //            }
        //        }
        //    }

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns a value indicating whether the specified <see cref="string" /> object occurs within the <paramref name="this" /> string.
        /// A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <param name="this">The string to search in</param>
        /// <param name="value">The string to seek</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns><c>true</c> if the <paramref name="value" /> parameter occurs within the <paramref name="this" /> parameter,
        /// or if <paramref name="value" /> is the empty string (<c>""</c>);
        /// otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> or <paramref name="value" /> is <c>null</c></exception>
        /// <exception cref="ArgumentException"><paramref name="this" /> or <paramref name="value" /> is <c>null</c></exception>
        /// <remarks>The <paramref name="comparisonType" /> parameter specifies to search for the value parameter using the current or invariant culture,
        /// using a case-sensitive or case-insensitive search, and using word or ordinal comparison rules.</remarks>
        public static bool Contains(this string @this, string value, StringComparison comparisonType)
    {
        if (@this == null)
        {
            throw new ArgumentNullException("this");
        }

        return @this.IndexOf(value, comparisonType) >= 0;
    }


        //---------------------------------Implementation-----------------------------//

        //string title = "STRING";
        //bool contains = title.Contains("string", StringComparison.OrdinalIgnoreCase);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// a case-insensitive version of String.Contains().
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="toCheck">To check.</param>
        /// <param name="comp">The comp.</param>
        /// <param name="doConversion">if set to <c>true</c> [do conversion].</param>
        /// <returns><c>true</c> if [contains] [the specified to check]; otherwise, <c>false</c>.</returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp, bool doConversion)
        {
            return source.IndexOf(toCheck, comp) >= 0;

        }



    }



}
