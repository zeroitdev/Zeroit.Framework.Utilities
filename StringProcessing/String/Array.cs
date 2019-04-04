// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="Array.cs" company="Zeroit Dev Technologies">
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
using System;
namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        /// <summary>
        /// Inserts at startup.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Insertion">The insertion.</param>
        /// <returns>System.String[].</returns>
        public static string[] InsertAtStartup(string[] Source,string[] Insertion)
        {
            if (Source == null)
                return Insertion;
            int SourceLength = Source.Length;
            int InsertionLength = Insertion.Length;
            int Total = SourceLength + InsertionLength;
            string[] New = new string[Total];
            for (int i = 0; i < InsertionLength; i++)
            {
                New[i] = Insertion[i];
            }
            for (int i = 0; i < SourceLength; i++)
            {
                New[i + InsertionLength] = Source[i];
            }
            return New;
        }

        /// <summary>
        /// Inserts the string at start.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Prefix">The prefix.</param>
        /// <returns>System.String[].</returns>
        public static string[] InsertStringAtStart(string[] Source, string Prefix)
        {
            string[] Output = new string[Source.Length];
            for (int i = 0; i < Source.Length; i++)
                Output[i] = Prefix + Source[i];
            return Output;
        }

        /// <summary>
        /// Splits the specified source.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Split">The split.</param>
        /// <returns>System.String[].</returns>
        public static string[] Split(string Source, string Split)
        {
            return Source.Split(new string[] { Split }, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
