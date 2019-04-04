// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Last.cs" company="Zeroit Dev Technologies">
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

        //string name = "mehrdad";
        //Response.Write("Name is : " + name);
        //Response.Write("<br />");
        //Response.Write("Last Char : "+name.LastChar());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Gets the Last character in string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string LastChar(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length >= 1)
                {
                    return input.Substring(input.Length - 1, 1);
                }
                else
                {
                    return input;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
