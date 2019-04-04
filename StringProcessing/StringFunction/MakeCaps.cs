// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MakeCaps.cs" company="Zeroit Dev Technologies">
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

        //string result_string = "hello world!".ToFirstAll(true);
        //MessageBox.Show(result_string);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Makes the caps for all words in a string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="switcher">if set to <c>true</c> [switcher].</param>
        /// <returns>System.String.</returns>
        public static string MakeCaps(this string input, bool switcher)
        {
            return new string(input.Split(' ').
                Select(n => switcher ? (n.ToArray().First().ToString().ToUpper() + n.Substring(1, n.Length - 1)) :
                    (n.ToArray().First().ToString().ToLower() + n.Substring(1, n.Length - 1))).
                Aggregate((a, b) => a + ' ' + b).ToArray()).TrimEnd(' ');
        }

    }
}
