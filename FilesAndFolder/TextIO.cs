// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="TextIO.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Text;

namespace Zeroit.Framework.Utilities.Files
{
    /// <summary>
    /// Class TextIO.
    /// </summary>
    public static class TextIO
    {
        /// <summary>
        /// Files to string.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns>System.String.</returns>
        public static string FileToString(string FileName)
        {
            TextReader xReader = new StreamReader(FileName,Encoding.Default);
            string Temp = xReader.ReadToEnd();
            xReader.Close();
            return Temp;
        }
        /// <summary>
        /// Strings to file.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="Data">The data.</param>
        public static void StringToFile(string FileName, string Data)
        {
            TextWriter xWriter = new StreamWriter(FileName, false);
            xWriter.Write(Data);
            xWriter.Close();
        }
        /// <summary>
        /// Files to string array.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="Split">The split.</param>
        /// <returns>System.String[].</returns>
        public static string[] FileToStringArray(string FileName,string Split)
        {
            string Text = TextIO.FileToString(FileName);
            return Text.Split(new string[] { Split },StringSplitOptions.RemoveEmptyEntries);
        }
        /// <summary>
        /// Files to string array.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns>System.String[].</returns>
        public static string[] FileToStringArray(string FileName)
        {
            string Text = TextIO.FileToString(FileName);
            if (Text.IndexOf(Environment.NewLine) < 0)
                return Split(Text, "\n");
            return Split(Text, Environment.NewLine);
        }



        /// <summary>
        /// Splits the specified source.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Split">The split.</param>
        /// <returns>System.String[].</returns>
        private static string[] Split(string Source, string Split)
        {
            return Source.Split(new string[] { Split }, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
