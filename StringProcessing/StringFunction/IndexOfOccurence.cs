// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IndexOfOccurence.cs" company="Zeroit Dev Technologies">
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

        //Console.WriteLine(IndexOfOccurence("Emad Alashi found ash on his desk, he went mad, very mad", "mad", 2));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Finds the index of the nth occurrence of a string in a string .
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="stringToBeFound">The string to be found.</param>
        /// <param name="occurrence">The occurrence.</param>
        /// <returns>System.Int32.</returns>
        public static int IndexOfOccurence(this string str, string stringToBeFound, int occurrence)
        {
            int occurrenceCounter = 0;
            int indexOfPassedString = 0 - stringToBeFound.Length;

            do
            {
                indexOfPassedString = str.IndexOf(stringToBeFound, indexOfPassedString + stringToBeFound.Length);
                if (indexOfPassedString == -1)
                    break;
                occurrenceCounter++;
            }
            while (occurrenceCounter != occurrence);

            return indexOfPassedString;
        }

    }
}
