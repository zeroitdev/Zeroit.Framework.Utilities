// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DeleteFiles.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
