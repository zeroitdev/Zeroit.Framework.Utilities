// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToPlural.cs" company="Zeroit Dev Technologies">
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

        //"goose".ToPlural(); // returns "geese"
        //"wolf".ToPlural(); // returns "wolves"

        //String.Format("{0} {1}", commentCount, "comment".ToPlural(commentCount)); // returns "1 comment" or "2 comments"

        //--------------------2nd Method-------------//
        //string person = "person";
        //string personPlural = person.ToPlural;
        //--------------------2nd Method-------------//
        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Returns the plural form of the specified word.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="count">How many of the specified word there are. A count equal to 1 will not pluralize the specified word.</param>
        /// <returns>A string that is the plural form of the input parameter.</returns>
        public static string ToPlural(this string @this, int count = 0)
        {
            return count == 1 ? @this : System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(new System.Globalization.CultureInfo("en-US")).Pluralize(@this);
        }

        /// <summary>
        /// Returns the plural of a word.
        /// </summary>
        /// <param name="singular">The singular.</param>
        /// <returns>System.String.</returns>
        public static string ToPlural(this string singular)
        {
            // Multiple words in the form A of B : Apply the plural to the first word only (A)
            int index = singular.LastIndexOf(" of ");
            if (index > 0) return (singular.Substring(0, index)) + singular.Remove(0, index).ToPlural();

            // single Word rules
            //sibilant ending rule
            if (singular.EndsWith("sh")) return singular + "es";
            if (singular.EndsWith("ch")) return singular + "es";
            if (singular.EndsWith("us")) return singular + "es";
            if (singular.EndsWith("ss")) return singular + "es";
            //-ies rule
            if (singular.EndsWith("y")) return singular.Remove(singular.Length - 1, 1) + "ies";
            // -oes rule
            if (singular.EndsWith("o")) return singular.Remove(singular.Length - 1, 1) + "oes";
            // -s suffix rule
            return singular + "s";
        }

    }
}
