// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Repeat.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
