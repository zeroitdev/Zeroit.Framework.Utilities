// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToSecureString.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //String password = "mypassword";
        //System.Security.SecureString secure = password.ToSecureString();

        //---------------------------------Implementation-----------------------------//


        /// <summary>
        /// Converts a string into a "SecureString"
        /// </summary>
        /// <param name="str">Input String</param>
        /// <returns>System.Security.SecureString.</returns>
        public static System.Security.SecureString ToSecureString(this String str)
        {
            System.Security.SecureString secureString = new System.Security.SecureString();
            foreach (Char c in str)
                secureString.AppendChar(c);

            return secureString;
        }
    }
}
