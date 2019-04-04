// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToNameValueCollection.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Collections.Specialized;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //String a = "param1=value1;param2=value2";
        //NameValueCollection nv = a.ToNameValueCollection(';', '=');

        //---------------------------------Implementation-----------------------------//


        /// <summary>
        /// Splits a string into a NameValueCollection, where each "namevalue" is separated by
        /// the "OuterSeparator". The parameter "NameValueSeparator" sets the split between Name and Value.
        /// Example:
        /// String str = "param1=value1;param2=value2";
        /// NameValueCollection nvOut = str.ToNameValueCollection(';', '=');
        /// The result is a NameValueCollection where:
        /// key[0] is "param1" and value[0] is "value1"
        /// key[1] is "param2" and value[1] is "value2"
        /// </summary>
        /// <param name="str">String to process</param>
        /// <param name="OuterSeparator">Separator for each "NameValue"</param>
        /// <param name="NameValueSeparator">Separator for Name/Value splitting</param>
        /// <returns>NameValueCollection.</returns>
        public static NameValueCollection ToNameValueCollection(this String str, Char OuterSeparator, Char NameValueSeparator)
        {
            NameValueCollection nvText = null;
            str = str.TrimEnd(OuterSeparator);
            if (!String.IsNullOrEmpty(str))
            {
                String[] arrStrings = str.TrimEnd(OuterSeparator).Split(OuterSeparator);

                foreach (String s in arrStrings)
                {
                    Int32 posSep = s.IndexOf(NameValueSeparator);
                    String name = s.Substring(0, posSep);
                    String value = s.Substring(posSep + 1);
                    if (nvText == null)
                        nvText = new NameValueCollection();
                    nvText.Add(name, value);
                }
            }
            return nvText;
        }

    }
}
