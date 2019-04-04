// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ParentDirectoryPath.cs" company="Zeroit Dev Technologies">
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
using System.IO;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //MessageBox.Show(Application.ExecutablePath.GetDirectoryPath().GetParentDirectoryPath());
        //MessageBox.Show(Application.ExecutablePath.GetDirectoryPath().GetParentDirectoryPath(2));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Gets the parent directory path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="levels">The levels.</param>
        /// <returns>System.String.</returns>
        public static string GetParentDirectoryPath(this string folderPath, int levels)
        {
            string result = folderPath;
            for (int i = 0; i < levels; i++)
            {
                if (Directory.GetParent(result) != null)
                {
                    result = Directory.GetParent(result).FullName;
                }
                else
                {
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the parent directory path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <returns>System.String.</returns>
        public static string GetParentDirectoryPath(this string folderPath)
        {
            return GetParentDirectoryPath(folderPath, 1);
        }

        /// <summary>
        /// 取得路徑的目錄路徑
        /// </summary>
        /// <param name="filePath">路徑</param>
        /// <returns>System.String.</returns>
        public static string GetDirectoryPath(this string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }

    }
}
