// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToBytes.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //var bytes = @"C:\Temp\Products.pdf".ToBytes();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts a file on a given path to a byte array.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public static byte[] ToBytes(this string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName);

            return File.ReadAllBytes(fileName);
        }

    }
}
