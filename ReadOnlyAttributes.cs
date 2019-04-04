// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ReadOnlyAttributes.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
