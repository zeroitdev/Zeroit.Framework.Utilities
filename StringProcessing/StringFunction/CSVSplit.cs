// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CSVSplit.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Text;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //"this,\"that, those\",\"the other\", "embedded\"\"quote\"" =>

        //string[] {
        //    "this",
        //    "that, those",
        //    "the other",
        //    "embedded\"quote"
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Enum CSVSplitState
        /// </summary>
        private enum CSVSplitState
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal,
            /// <summary>
            /// The in quotes
            /// </summary>
            InQuotes,
            /// <summary>
            /// The in quotes found quote
            /// </summary>
            InQuotesFoundQuote
        }

        /// <summary>
        /// Given a line from a CSV-encoded file, split it into fields.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> CSVSplit(this string s)
        {
            CSVSplitState state = CSVSplitState.Normal;
            StringBuilder token = new StringBuilder();
            foreach (char c in s)
            {
                switch (state)
                {
                    case CSVSplitState.Normal:
                        if (c == ',')
                        {
                            yield return token.ToString();
                            token = new StringBuilder();
                        }
                        else if (c == '"')
                            state = CSVSplitState.InQuotes;
                        else
                            token.Append(c);
                        break;

                    case CSVSplitState.InQuotes:
                        if (c == '"')
                            state = CSVSplitState.InQuotesFoundQuote;
                        else
                            token.Append(c);
                        break;

                    case CSVSplitState.InQuotesFoundQuote:
                        if (c == '"')
                        {
                            token.Append(c);
                            state = CSVSplitState.InQuotes;
                        }
                        else
                        {
                            state = CSVSplitState.Normal;
                            goto case CSVSplitState.Normal;
                        }
                        break;
                }
            }
            yield return token.ToString();
        }

    }
}
