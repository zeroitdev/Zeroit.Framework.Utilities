// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ReadOnlyAttributes.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.IO;

namespace Zeroit.Framework.Utilities.FileSystemOperations
{
    /// <summary>
    /// A class collection for Read Only Implementation
    /// </summary>
    public class ReadOnlyFiles
    {
        /// <summary>
        /// The file information
        /// </summary>
        public FileInfo fileInfo;

        /// <summary>
        /// Create an instance of the class
        /// </summary>
        /// <param name="fileToGetInformation">Set source file</param>
        /// <param name="fileExtension">Set file extension</param>
        public ReadOnlyFiles(string fileToGetInformation,string fileExtension)
        {
            fileInfo = new FileInfo(fileToGetInformation + "." + fileExtension);
                        
        }

        /// <summary>
        /// Create File.
        /// This is used for creating a file with a particular extension
        /// </summary>
        /// <param name="fileToCreate">Set file to create</param>
        /// <param name="fileExtension">Set file extension</param>
        public void CreateFile(string fileToCreate, string fileExtension)
        {
            Console.WriteLine("Creating new file...");

            if (File.Exists(fileToCreate + "." + fileExtension))
            {
                Console.WriteLine("File Already Exists");

            }
            else
            {
                StreamWriter streamWriter = File.CreateText(fileToCreate + "." + fileExtension);
                streamWriter.WriteLine("This is a code sample from http://softwarebydefault.com");
                streamWriter.Close();
                Console.WriteLine("File Created.");
            }

        }

        /// <summary>
        /// Check File Status
        /// </summary>
        public void CheckFileStatus()
        {
            DisplayFileStatus(fileInfo);
            Console.WriteLine();
        }

        /// <summary>
        /// Set Read Only Attribute
        /// </summary>
        public void SetReadOnyAttribute()
        {
            Console.WriteLine("Attempting to set read only: method 1");
            fileInfo.IsReadOnly = true;
            DisplayFileStatus(fileInfo);
            Console.WriteLine();
        }

        /// <summary>
        /// Remove Read Only Attribute
        /// </summary>
        public void RemoveReadOnlyAttribute()
        {
            Console.WriteLine("Attempting to undo read only: method 1");
            fileInfo.IsReadOnly = false;
            DisplayFileStatus(fileInfo);
            Console.WriteLine();

        }

        /// <summary>
        /// Set Read Only Attribute
        /// </summary>
        public void SetReadOnlyAttributeMethod2()
        {
            Console.WriteLine("Attempting to set read only: method 2");
            File.SetAttributes("ReadOnlyFile.txt", FileAttributes.ReadOnly);
            DisplayFileStatus(fileInfo);
            Console.WriteLine();
        }

        /// <summary>
        /// Remove Read only attribute
        /// </summary>
        public void RemoveReadOnlyAttributeMethod2()
        {
            Console.WriteLine("Attempting to undo read only method 2");
            File.SetAttributes("ReadOnlyFile.txt", ~FileAttributes.ReadOnly);
            DisplayFileStatus(fileInfo);
            Console.WriteLine();
        }

        /// <summary>
        /// Set Read only attribute
        /// </summary>
        public void SetReadOnlyAttributeMethod3()
        {
            Console.WriteLine("Attempting to set read only: method 3");
            fileInfo.Attributes = fileInfo.Attributes | FileAttributes.ReadOnly;
            DisplayFileStatus(fileInfo);
            Console.WriteLine();
        }

        /// <summary>
        /// Remove Read only attribute
        /// </summary>
        public void RemoveReadOnlyAttributeMethod3()
        {
            Console.WriteLine("Attempting to undo read only: method 3");
            fileInfo.Attributes = fileInfo.Attributes & ~FileAttributes.ReadOnly;
            DisplayFileStatus(fileInfo);
            Console.WriteLine();
        }

        /// <summary>
        /// Delete File
        /// </summary>
        /// <param name="fileToCreate">Set file to create</param>
        /// <param name="fileExtension">Set file extension</param>
        public void DeleteFile(string fileToCreate, string fileExtension)
        {
            File.Delete(fileToCreate + "." + fileExtension);
        }

        /// <summary>
        /// Display File status
        /// </summary>
        /// <param name="fileInfo">Get file info</param>
        private static void DisplayFileStatus(FileInfo fileInfo)
        {
            fileInfo.Refresh();

            Console.WriteLine("File read only: " +
                (fileInfo.IsReadOnly ? "Yes" : "No"));
        }
    }
}
