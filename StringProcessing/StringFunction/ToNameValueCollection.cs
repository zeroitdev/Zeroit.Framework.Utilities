// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToNameValueCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
