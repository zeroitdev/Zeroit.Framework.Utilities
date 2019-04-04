// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FileSizeFormat.cs" company="Zeroit Dev Technologies">
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
        //---------------------------------Implementation-----------------------------//

        //// Using another Extension Method: FileSize to get the size of the file
        //string path = @"D:\WWW\Proj\web.config";
        //Console.WriteLine("File Size is: {0}.", path.FileSize().FormatSize());

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Nicely formatted file size. This method will return file size with bytes, KB, MB and GB in it.
        /// You can use this alongside the Extension method named FileSize.
        /// </summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns>System.String.</returns>
        public static string FormatFileSize(this long fileSize)
        {
            string[] suffix = { "bytes", "KB", "MB", "GB" };
            long j = 0;

            while (fileSize > 1024 && j < 4)
            {
                fileSize = fileSize / 1024;
                j++;
            }
            return (fileSize + " " + suffix[j]);
        }
    }
}
