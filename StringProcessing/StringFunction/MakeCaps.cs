// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MakeCaps.cs" company="Zeroit Dev Technologies">
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
