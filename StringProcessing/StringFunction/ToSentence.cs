// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToSentence.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
