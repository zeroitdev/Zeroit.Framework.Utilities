// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DeleteChars.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string Text = "#Hello world.  This is a [test]";
        //string cleanText1 = Text.DeleteChars('#', '[', ']');  //return Hello world.  This is a test 
        //string cleanText2 = Text.DeleteChars('#');
        ////return Hello world.  This is a [test]

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Remove from the given string, all characters provided in a params array of chars.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="chars">The chars.</param>
        /// <returns>System.String.</returns>
        public static string DeleteChars(this string input, params char[] chars)
        {
            return new string(input.Where((ch) => !chars.Contains(ch)).ToArray());
        }

    }
}
