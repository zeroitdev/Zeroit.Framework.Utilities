// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetMD5.cs" company="Zeroit Dev Technologies">
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
using System.Security.Cryptography;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string file = @"C:\Temp\filename.txt";
        //Console.WriteLine("MD5 Hash is: {0}.", file.GetMD5());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Read and get MD5 hash value of any given filename.
        /// </summary>
        /// <param name="filename">full path and filename</param>
        /// <returns>lowercase MD5 hash value</returns>
        public static string GetMD5(this string filename)
        {
            string result = string.Empty;
            string hashData;

            FileStream fileStream;
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();

            try
            {
                fileStream = GetFileStream(filename);
                byte[] arrByteHashValue = md5Provider.ComputeHash(fileStream);
                fileStream.Close();

                hashData = BitConverter.ToString(arrByteHashValue).Replace("-", "");
                result = hashData;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }

            return (result.ToLower());
        }

        /// <summary>
        /// Gets the file stream.
        /// </summary>
        /// <param name="pathName">Name of the path.</param>
        /// <returns>FileStream.</returns>
        private static FileStream GetFileStream(string pathName)
        {
            return (new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        }

    }
}
