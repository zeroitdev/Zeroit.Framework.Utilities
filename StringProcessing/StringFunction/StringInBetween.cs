// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="StringInBetween.cs" company="Zeroit Dev Technologies">
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

        //string TestGetStringInBetween = "<h1>Hello Narender</h1>";
        //string[] result;
        //result=TestGetStringInBetween.GetStringInBetween("<h1>", "</h1>", false, false);
        //Response.Write("<br /><br />StringInBetween is :" + result[0]);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Gets the string in between.
        /// </summary>
        /// <param name="strSource">The string source.</param>
        /// <param name="strBegin">The string begin.</param>
        /// <param name="strEnd">The string end.</param>
        /// <param name="includeBegin">if set to <c>true</c> [include begin].</param>
        /// <param name="includeEnd">if set to <c>true</c> [include end].</param>
        /// <returns>System.String[].</returns>
        public static string[] GetStringInBetween(this string strSource, string strBegin, string strEnd, bool includeBegin, bool includeEnd)
        {

            string[] result = { "", "" };

            int iIndexOfBegin = strSource.IndexOf(strBegin);

            if (iIndexOfBegin != -1)
            {

                // include the Begin string if desired

                if (includeBegin)

                    iIndexOfBegin -= strBegin.Length;

                strSource = strSource.Substring(iIndexOfBegin

                                                + strBegin.Length);

                int iEnd = strSource.IndexOf(strEnd);

                if (iEnd != -1)
                {

                    // include the End string if desired

                    if (includeEnd)

                        iEnd += strEnd.Length;

                    result[0] = strSource.Substring(0, iEnd);

                    // advance beyond this segment

                    if (iEnd + strEnd.Length < strSource.Length)

                        result[1] = strSource.Substring(iEnd

                                                        + strEnd.Length);

                }

            }

            else

                // stay where we are

                result[1] = strSource;

            return result;

        }
    }


}
