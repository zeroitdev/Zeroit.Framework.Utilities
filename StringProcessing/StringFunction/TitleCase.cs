// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TitleCase.cs" company="Zeroit Dev Technologies">
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

        //string s = "tHiS is a sTring TesT";
        //Console.WriteLine("Title Case: {0}", s.ToProperCase());

        //// Output: This Is A String Test

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts string to a title case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string ToTitleCase(this string text)
        {
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);
        }

    }
}
