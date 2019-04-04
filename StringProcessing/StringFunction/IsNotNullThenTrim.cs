// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IsNotNullThenTrim.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string n = null;
        //Assert.IsNull(n.IsNotNullThenTrim());

        //string s = "test ";
        //Assert.IsNotNull(s.IsNotNullThenTrim());
        //Assert.AreEqual("test", s.IsNotNullThenTrim());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Perform a Trim() when the string is not null. If the string is null the method will return null.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string IsNotNullThenTrim(this string s)
        {
            if (!string.IsNullOrEmpty(s))
                return s.Trim();
            else
                return s;
        }

    }
}
