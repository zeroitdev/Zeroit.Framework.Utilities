// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="HasMultipleInstancesOf.cs" company="Zeroit Dev Technologies">
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

        //string myStr1 = "Hello.World.txt";
        //string myStr2 = "Hello World";

        //bool hasMultPeriods = myStr1.HasMultipleInstancesOf('.'); //returns true
        //bool hasMultSpaces = myStr2.HasMultipleInstancesOf(' '); //returns false

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Determines whether a string has multiple occurrences of a particular character.
        /// May be helpful when parsing file names, or ensuring a particular string has already contains a given character.
        /// This may be extended to use strings, rather than a char.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="charToFind">The character to find.</param>
        /// <returns><c>true</c> if [has multiple instances of] [the specified character to find]; otherwise, <c>false</c>.</returns>
        public static bool HasMultipleInstancesOf(this string input, char charToFind)
        {

            if ((string.IsNullOrEmpty(input)) || (input.Length == 0) || (input.IndexOf(charToFind) == 0))
                return false;

            if (input.IndexOf(charToFind) != input.LastIndexOf(charToFind))
                return true;

            return false;
        }


    }
}
