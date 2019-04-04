// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CSVQuoted.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //"this".CSVQuoted()  ==>  "this"
        //"pots and pans".CSVQuoted() ==> "\"pots and pans\""
        //"blue,red".CSVQuoted() ==> "\"blue,red\""
        //"embedded\"quote".CSVQuoted() ==> "\"embedded\"\"quote\""
        //" goodbye! ".CSVQuoted() ==> "\" goodbye! \""

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// If a string contains a space or a comma or a newline, quotes it, suitable for a field in a CSV file.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string CSVQuoted(this string s)
        {
            if (s.IndexOfAny(" ,\n".ToCharArray()) < 0 && s.Trim() == s)
                return s;

            StringBuilder sb = new StringBuilder();
            sb.Append('"');
            foreach (char c in s)
            {
                sb.Append(c);
                if (c == '"')
                    sb.Append(c);
            }
            sb.Append('"');
            return sb.ToString();
        }

    }
}
