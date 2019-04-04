// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DeleteFiles.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {

        //---------------------------------Implementation-----------------------------//

        //string path = @"C:\Temp\test\Sharp";
        //path.DeleteFiles("cs"); // Deletes all files with a CS extension

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Delete all files found on the specified folder with a given file extension.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="ext">The ext.</param>
        public static void DeleteFiles(this string folderPath, string ext)
        {
            string mask = "*." + ext;

            try
            {
                string[] fileList = Directory.GetFiles(folderPath, mask);

                foreach (string file in fileList)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    fileInfo.Delete();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error Deleting file. Reason: {0}", ex.Message);
            }
        }

    }
}
