// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SHA1Hash.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Cryptography;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //"Get the hash of this string".GetSHA1Hash()

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Calculates the SHA1 hash of the supplied string and returns a base 64 string.
        /// </summary>
        /// <param name="stringToHash">String that must be hashed.</param>
        /// <returns>The hashed string or null if hashing failed.</returns>
        /// <exception cref="System.ArgumentException">An empty string value cannot be hashed.</exception>
        /// <exception cref="ArgumentException">Occurs when stringToHash or key is null or empty.</exception>
        public static string GetSHA1Hash(this string stringToHash)
        {
            if (string.IsNullOrEmpty(stringToHash))
            {
                throw new ArgumentException("An empty string value cannot be hashed.");
            }

            Byte[] data = System.Text.Encoding.UTF8.GetBytes(stringToHash);
            Byte[] hash = new SHA1CryptoServiceProvider().ComputeHash(data);
            return Convert.ToBase64String(hash);
        }

    }
}
