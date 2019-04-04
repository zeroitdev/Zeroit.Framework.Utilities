// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToMd5.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Cryptography;
using System.Text;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string value = "this is a string";
        //Console.WriteLine(value.ToMd5Hash());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Convert a input string to a byte array and compute the hash.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Hexadecimal string.</returns>
        public static string ToMd5Hash(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] originalBytes = ASCIIEncoding.Default.GetBytes(value);
                byte[] encodedBytes = md5.ComputeHash(originalBytes);
                return BitConverter.ToString(encodedBytes).Replace("-", string.Empty);
            }
        }

        /// <summary>
        /// The s MD5
        /// </summary>
        static MD5CryptoServiceProvider s_md5 = null;


        /// <summary>
        /// To the m d5.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string ToMD5(this string s)
        {
            if (s_md5 == null) //creating only when needed
                s_md5 = new MD5CryptoServiceProvider();
            Byte[] newdata = Encoding.Default.GetBytes(s);
            Byte[] encrypted = s_md5.ComputeHash(newdata);
            return BitConverter.ToString(encrypted).Replace("-", "").ToLower();
        }

    }
}
