// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LineToHtmlBreak.cs" company="Zeroit Dev Technologies">
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

        //string s = "line1\r\n\line2";
        //string r = s.Nl2Br(); \\ "line1<br />line2"

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Convert a NewLine to a Html break .
        /// </summary>
        /// <param name="s">The input text.</param>
        /// <returns>System.String.</returns>
        public static string NewLineToHtmlBreak(this string s)
        {
            return s.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        /// <summary>
        /// Removes the HTML break tags.
        /// </summary>
        /// <param name="theString">The string.</param>
        /// <returns>System.String.</returns>
        public static string RemoveHtmlBreakTags(this string theString)
        {
            return theString.Replace(@"<br \>", "");
        }

    }
}
