// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-10-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-10-2019
// ***********************************************************************
// <copyright file="PathExtension.cs" company="Zeroit Dev Technologies">
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
