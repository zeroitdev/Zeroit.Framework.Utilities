// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CSVQuoted.cs" company="Zeroit Dev Technologies">
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
