// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="TextIO.cs" company="Zeroit Dev Technologies">
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
