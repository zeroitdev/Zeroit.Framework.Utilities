// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Portion.cs" company="Zeroit Dev Technologies">
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
        /// <summary>
        /// Lefts the side.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string LeftSide(string Source, int Length)
        {
            if (Length >= Source.Length)
                return Source;
            return Source.Substring(0, Length);
        }
        /// <summary>
        /// Rights the side.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string RightSide(string Source, int Length)
        {
            if (Length >= Source.Length)
                return Source;
            return Source.Substring(Source.Length - Length);
        }
        /// <summary>
        /// Mids the specified source.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="LeftSide">The left side.</param>
        /// <param name="RightSide">The right side.</param>
        /// <returns>System.String.</returns>
        public static string Mid(string Source, int LeftSide, int RightSide)
        {
            return Source.Substring(LeftSide, Source.Length - RightSide);
        }

        /// <summary>
        /// Lefts to character.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string LeftToChar(string Source, char Search)
        {
            int Index = Source.IndexOf(Search);
            if (Index < 0)
                return "";
            return LeftSide(Source, Index);
        }
        /// <summary>
        /// Rights from character.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string RightFromChar(string Source, char Search)
        {
            int Index = Source.IndexOf(Search);
            if (Index < 0)
                return "";
            return Source.Substring(Index + 1);
        }
        /// <summary>
        /// Lefts to string.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string LeftToString(string Source, string Search)
        {
            int Index = Source.IndexOf(Search);
            if (Index < 0)
                return "";
            return LeftSide(Source, Index);
        }
        /// <summary>
        /// Rights from string.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string RightFromString(string Source, string Search)
        {
            int Index = Source.IndexOf(Search);
            if (Index < 0)
                return "";
            return Source.Substring(Index + Search.Length);
        }

        /// <summary>
        /// Trimmeds the left.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string TrimmedLeft(string Source, int Length)
        {
            return LeftSide(Source, Length).Trim();
        }
        /// <summary>
        /// Trimmeds the right.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public static string TrimmedRight(string Source, int Length)
        {
            return RightSide(Source, Length).Trim();
        }

        /// <summary>
        /// Trimmeds the left to character.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string TrimmedLeftToChar(string Source, char Search)
        {
            return LeftToChar(Source, Search).Trim();
        }
        /// <summary>
        /// Trimmeds the right from character.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string TrimmedRightFromChar(string Source, char Search)
        {
            return RightFromChar(Source, Search).Trim();
        }
        /// <summary>
        /// Trimmeds the left to string.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string TrimmedLeftToString(string Source, string Search)
        {
            return LeftToString(Source, Search).Trim();
        }
        /// <summary>
        /// Trimmeds the right from string.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Search">The search.</param>
        /// <returns>System.String.</returns>
        public static string TrimmedRightFromString(string Source, string Search)
        {
            return RightFromString(Source, Search).Trim();
        }


    }
}
