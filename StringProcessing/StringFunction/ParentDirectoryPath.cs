// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ParentDirectoryPath.cs" company="Zeroit Dev Technologies">
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
