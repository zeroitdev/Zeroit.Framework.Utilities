// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="Array.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
