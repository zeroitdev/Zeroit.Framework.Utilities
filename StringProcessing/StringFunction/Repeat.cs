// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Repeat.cs" company="Zeroit Dev Technologies">
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
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string name = "mehrdad";
        //Response.Write("Name is : " + name);
        //Response.Write("<br />");
        //Response.Write(name.Repeat(20,"-"));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Repeat String .
        /// </summary>
        /// <param name="input">String</param>
        /// <param name="number">Count Repeat</param>
        /// <param name="RepeatChar">The repeat character.</param>
        /// <returns>System.String.</returns>
        public static string Repeat(this string input, int number, string RepeatChar)
        {
            if (!string.IsNullOrEmpty(input))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= number; i++)
                {
                    sb.AppendFormat("{0}{1}", input, RepeatChar);
                }
                return sb.Remove(sb.Length - 1, 1).ToString();
            }
            else
            {
                return null;
            }
        }

    }
}
