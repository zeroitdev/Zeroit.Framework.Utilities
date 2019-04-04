// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToSentence.cs" company="Zeroit Dev Technologies">
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

        //Create an extension method on a DataGrid to pretty print the column names.


        //public static void SetLabelsToSentences(
        //    this XamDataGrid xamDataGrid)
        //{
        //    foreach (
        //        Field field in xamDataGrid.FieldLayouts[0].Fields)
        //    {
        //        xamDataGrid.SetLabel(
        //            field.Name, field.Name.ToSentence());
        //    }
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Creates a sentence from a variable name.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        /// <returns>System.String.</returns>
        public static string ToSentence(this string variableName)
        {
            var builder = new StringBuilder();

            char[] chars = variableName.ToCharArray();

            foreach (char c in chars)
            {
                if (char.IsLetter(c) && char.IsUpper(c))
                {
                    builder.Append(" ");
                }

                builder.Append(c);
            }

            variableName = builder.ToString().TrimStart();

            return variableName;
        }

    }
}
