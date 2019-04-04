// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToStream.cs" company="Zeroit Dev Technologies">
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

        //stream MyStream = "Fred".ToStream()

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts a String to a MemoryStream .
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <returns>System.IO.MemoryStream.</returns>
        public static System.IO.MemoryStream ToStream(this string Source)
        {
            byte[] Bytes = System.Text.Encoding.ASCII.GetBytes(Source);
            return new System.IO.MemoryStream(Bytes);
        }

    }
}
