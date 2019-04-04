// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-10-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-10-2019
// ***********************************************************************
// <copyright file="PathExtension.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.Utilities.PathExtension
{
    
    /// <summary>
    /// A class for getting the path of the file.
    /// </summary>
    public static class Paths
    {

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="root">The root.</param>
        /// <returns>System.String.</returns>
        public static string GetPath(string path, string root = @"..\..\")
        {
            string rootDirectory = root;

            rootDirectory += path;

            return System.IO.Path.GetFullPath(rootDirectory);
        }

    }
}
