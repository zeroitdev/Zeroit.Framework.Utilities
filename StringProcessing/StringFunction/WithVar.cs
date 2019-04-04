// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WithVar.cs" company="Zeroit Dev Technologies">
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
using System.Reflection;
using System.Text.RegularExpressions;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //int count = 10;
        //var message = "{count} Rows Deleted!".WithVar(new { count });
        //// message : 10 Rows Deleted!

        //var message2 = "{count:00000} Rows Deleted!".WithVar(new { count });
        //// message2 : 00010 Rows Deleted!

        //var query = "select * from {TableName} where id >= {Id};".WithVar(new { TableName = "Foo", Id = 10 });
        //// query : select * from Foo where id >= 10;

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Improve readability of String.Format
        /// ex) "{a}, {a:000}, {b}".WithVar(new {a, b});
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">A composite format string (equal string.Format's format)</param>
        /// <param name="arg">class or anonymouse type</param>
        /// <returns>System.String.</returns>
        public static string WithVar<T>(this string str, T arg) where T : class
        {
            var type = typeof(T);
            foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!(member is FieldInfo || member is PropertyInfo))
                    continue;
                var pattern = @"\{" + member.Name + @"(\:.*?)?\}";
                var alreadyMatch = new HashSet<string>();
                foreach (Match m in Regex.Matches(str, pattern))
                {
                    if (alreadyMatch.Contains(m.Value)) continue; else alreadyMatch.Add(m.Value);
                    string oldValue = m.Value;
                    string newValue = null;
                    string format = "{0" + m.Groups[1].Value + "}";
                    if (member is FieldInfo)
                        newValue = format.With(((FieldInfo)member).GetValue(arg));
                    if (member is PropertyInfo)
                        newValue = format.With(((PropertyInfo)member).GetValue(arg));
                    if (newValue != null)
                        str = str.Replace(oldValue, newValue);
                }
            }
            return str;
        }

        /// <summary>
        /// Withes the specified parameter.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.String.</returns>
        public static string With(this string str, params object[] param)
        {
            return string.Format(str, param);
        }

    }
}
