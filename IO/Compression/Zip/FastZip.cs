// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="FastZip.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using Zeroit.Framework.Utilities.IO.Compression.Core;

namespace Zeroit.Framework.Utilities.IO.Compression.Zip
{
    /// <summary>
    /// FastZipEvents supports all events applicable to <see cref="FastZip">FastZip</see> operations.
    /// </summary>
    public class FastZipEvents
	{
        /// <summary>
        /// Delegate to invoke when processing directories.
        /// </summary>
        public ProcessDirectoryDelegate ProcessDirectory;

        /// <summary>
        /// Delegate to invoke when processing files.
        /// </summary>
        public ProcessFileDelegate ProcessFile;

        /// <summary>
        /// Delegate to invoke when processing directory failures.
        /// </summary>
        public DirectoryFailureDelegate DirectoryFailure;

        /// <summary>
        /// Delegate to invoke when processing file failures.
        /// </summary>
        public FileFailureDelegate FileFailure;

        /// <summary>
        /// Raise the directory failure event.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="e">The exception for this event.</param>
        public void OnDirectoryFailure(string directory, Exception e)
		{
			if ( DirectoryFailure != null ) {
				ScanFailureEventArgs args = new ScanFailureEventArgs(directory, e);
				DirectoryFailure(this, args);
			}
		}

        /// <summary>
        /// Raises the file failure event.
        /// </summary>
        /// <param name="file">The file for this event.</param>
        /// <param name="e">The exception for this event.</param>
        public void OnFileFailure(string file, Exception e)
		{
			if ( FileFailure != null ) {
				ScanFailureEventArgs args = new ScanFailureEventArgs(file, e);
				FileFailure(this, args);
			}
		}

        /// <summary>
        /// Raises the ProcessFileEvent.
        /// </summary>
        /// <param name="file">The file for this event.</param>
        public void OnProcessFile(string file)
		{
			if ( ProcessFile != null ) {
				ScanEventArgs args = new ScanEventArgs(file);
				ProcessFile(this, args);
			}
		}

        /// <summary>
        /// Raises the ProcessDirectoryEvent.
        /// </summary>
        /// <param name="directory">The directory for this event.</param>
        /// <param name="hasMatchingFiles">Flag indicating if directory has matching files as determined by the current filter.</param>
        public void OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
			if ( ProcessDirectory != null ) {
				DirectoryEventArgs args = new DirectoryEventArgs(directory, hasMatchingFiles);
				ProcessDirectory(this, args);
			}
		}
		
	}

    /// <summary>
    /// FastZip provides facilities for creating and extracting zip files.
    /// Only relative paths are supported.
    /// </summary>
    public class FastZip
	{
        /// <summary>
        /// Initialize a default instance of FastZip.
        /// </summary>
        public FastZip()
		{
			this.events = null;
		}

        /// <summary>
        /// Initialise a new instance of <see cref="FastZip" />
        /// </summary>
        /// <param name="events">The events.</param>
        public FastZip(FastZipEvents events)
		{
			this.events = events;
		}

        /// <summary>
        /// Defines the desired handling when overwriting files.
        /// </summary>
        public enum Overwrite {
            /// <summary>
            /// Prompt the user to confirm overwriting
            /// </summary>
            Prompt,
            /// <summary>
            /// Never overwrite files.
            /// </summary>
            Never,
            /// <summary>
            /// Always overwrite files.
            /// </summary>
            Always
        }

        /// <summary>
        /// Get/set a value indicating wether empty directories should be created.
        /// </summary>
        /// <value><c>true</c> if [create empty directories]; otherwise, <c>false</c>.</value>
        public bool CreateEmptyDirectories
		{
			get { return createEmptyDirectories; }
			set { createEmptyDirectories = value; }
		}

        /// <summary>
        /// Delegate called when confirming overwriting of files.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public delegate bool ConfirmOverwriteDelegate(string fileName);

        /// <summary>
        /// Create a zip file.
        /// </summary>
        /// <param name="zipFileName">The name of the zip file to create.</param>
        /// <param name="sourceDirectory">The directory to source files from.</param>
        /// <param name="recurse">True to recurse directories, false for no recursion.</param>
        /// <param name="fileFilter">The file filter to apply.</param>
        /// <param name="directoryFilter">The directory filter to apply.</param>
        public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
		{
			NameTransform = new ZipNameTransform(true, sourceDirectory);
			this.sourceDirectory = sourceDirectory;
			
			outputStream = new ZipOutputStream(File.Create(zipFileName));
			try {
				FileSystemScanner scanner = new FileSystemScanner(fileFilter, directoryFilter);
				scanner.ProcessFile += new ProcessFileDelegate(ProcessFile);
				if ( this.CreateEmptyDirectories ) {
					scanner.ProcessDirectory += new ProcessDirectoryDelegate(ProcessDirectory);
				}
				scanner.Scan(sourceDirectory, recurse);
			}
			finally {
				outputStream.Close();
			}
		}

        /// <summary>
        /// Create a zip file/archive.
        /// </summary>
        /// <param name="zipFileName">The name of the zip file to create.</param>
        /// <param name="sourceDirectory">The directory to obtain files and directories from.</param>
        /// <param name="recurse">True to recurse directories, false for no recursion.</param>
        /// <param name="fileFilter">The file filter to apply.</param>
        public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter)
		{
			CreateZip(zipFileName, sourceDirectory, recurse, fileFilter, null);
		}

        /// <summary>
        /// Extract the contents of a zip file.
        /// </summary>
        /// <param name="zipFileName">The zip file to extract from.</param>
        /// <param name="targetDirectory">The directory to save extracted information in.</param>
        /// <param name="fileFilter">A filter to apply to files.</param>
        public void ExtractZip(string zipFileName, string targetDirectory, string fileFilter) 
		{
			ExtractZip(zipFileName, targetDirectory, Overwrite.Always, null, fileFilter, null);
		}

        /// <summary>
        /// Exatract the contents of a zip file.
        /// </summary>
        /// <param name="zipFileName">The zip file to extract from.</param>
        /// <param name="targetDirectory">The directory to save extracted information in.</param>
        /// <param name="overwrite">The style of <see cref="Overwrite">overwriting</see> to apply.</param>
        /// <param name="confirmDelegate">A delegate to invoke when confirming overwriting.</param>
        /// <param name="fileFilter">A filter to apply to files.</param>
        /// <param name="directoryFilter">A filter to apply to directories.</param>
        /// <exception cref="ArgumentNullException">confirmDelegate</exception>
        public void ExtractZip(string zipFileName, string targetDirectory, 
		                       Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate, 
		                       string fileFilter, string directoryFilter)
		{
			if ((overwrite == Overwrite.Prompt) && (confirmDelegate == null)) {
				throw new ArgumentNullException("confirmDelegate");
			}
			this.overwrite = overwrite;
			this.confirmDelegate = confirmDelegate;
			this.targetDirectory = targetDirectory;
			this.fileFilter = new NameFilter(fileFilter);
			this.directoryFilter = new NameFilter(directoryFilter);
			
			inputStream = new ZipInputStream(File.OpenRead(zipFileName));
			
			try {
				
				if (password != null) {
					inputStream.Password = password;
				}

				ZipEntry entry;
				while ( (entry = inputStream.GetNextEntry()) != null ) {
					if ( this.directoryFilter.IsMatch(Path.GetDirectoryName(entry.Name)) && this.fileFilter.IsMatch(entry.Name) ) {
						ExtractEntry(entry);
					}
				}
			}
			finally {
				inputStream.Close();
			}
		}

        /// <summary>
        /// Processes the directory.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DirectoryEventArgs"/> instance containing the event data.</param>
        void ProcessDirectory(object sender, DirectoryEventArgs e)
		{
			if ( !e.HasMatchingFiles && createEmptyDirectories ) {
				if ( events != null ) {
					events.OnProcessDirectory(e.Name, e.HasMatchingFiles);
				}
				
				if (e.Name != sourceDirectory) {
					string cleanedName = nameTransform.TransformDirectory(e.Name);
					ZipEntry entry = new ZipEntry(cleanedName);
					outputStream.PutNextEntry(entry);
				}
			}
		}

        /// <summary>
        /// Processes the file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ScanEventArgs"/> instance containing the event data.</param>
        void ProcessFile(object sender, ScanEventArgs e)
		{
			if ( events != null ) {
				events.OnProcessFile(e.Name);
			}
			string cleanedName = nameTransform.TransformFile(e.Name);
			ZipEntry entry = new ZipEntry(cleanedName);
			outputStream.PutNextEntry(entry);
			AddFileContents(e.Name);
		}

        /// <summary>
        /// Adds the file contents.
        /// </summary>
        /// <param name="name">The name.</param>
        void AddFileContents(string name)
		{
			if ( buffer == null ) {
				buffer = new byte[4096];
			}

			FileStream stream = File.OpenRead(name);
			try {
				int length;
				do {
					length = stream.Read(buffer, 0, buffer.Length);
					outputStream.Write(buffer, 0, length);
				} while ( length > 0 );
			}
			finally {
				stream.Close();
			}
		}

        /// <summary>
        /// Extracts the file entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="targetName">Name of the target.</param>
        void ExtractFileEntry(ZipEntry entry, string targetName)
		{
			bool proceed = true;
			if ((overwrite == Overwrite.Prompt) && (confirmDelegate != null)) {
				if (File.Exists(targetName) == true) {
					proceed = confirmDelegate(targetName);
				}
			}

			if ( proceed ) {
				
				if ( events != null ) {
					events.OnProcessFile(entry.Name);
				}
			
				FileStream streamWriter = File.Create(targetName);
			
				try {
					if ( buffer == null ) {
						buffer = new byte[4096];
					}
					
					int size;
		
					do {
						size = inputStream.Read(buffer, 0, buffer.Length);
						streamWriter.Write(buffer, 0, size);
					} while (size > 0);
				}
				finally {
					streamWriter.Close();
				}
	
				if (restoreDateTime) {
					File.SetLastWriteTime(targetName, entry.DateTime);
				}
			}
		}

        /// <summary>
        /// Names the is valid.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool NameIsValid(string name)
		{
			return name != null && name.Length > 0 && name.IndexOfAny(Path.GetInvalidPathChars()) < 0;
		}

        /// <summary>
        /// Extracts the entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        void ExtractEntry(ZipEntry entry)
		{
			bool doExtraction = NameIsValid(entry.Name);
			
			string dirName = null;
			string targetName = null;
			
			if ( doExtraction ) {
				string entryFileName;
				if (Path.IsPathRooted(entry.Name)) {
					string workName = Path.GetPathRoot(entry.Name);
					workName = entry.Name.Substring(workName.Length);
					entryFileName = Path.Combine(Path.GetDirectoryName(workName), Path.GetFileName(entry.Name));
				} else {
					entryFileName = entry.Name;
				}
				
				targetName = Path.Combine(targetDirectory, entryFileName);
				dirName = Path.GetDirectoryName(Path.GetFullPath(targetName));
	
				doExtraction = doExtraction && (entryFileName.Length > 0);
			}
			
			if ( doExtraction && !Directory.Exists(dirName) )
			{
				if ( !entry.IsDirectory || this.CreateEmptyDirectories ) {
					try {
						Directory.CreateDirectory(dirName);
					}
					catch {
						doExtraction = false;
					}
				}
			}
			
			if ( doExtraction && entry.IsFile ) {
				ExtractFileEntry(entry, targetName);
			}
		}

        /// <summary>
        /// Get or set the <see cref="ZipNameTransform"> active when creating Zip files.</see>
        /// </summary>
        /// <value>The name transform.</value>
        public ZipNameTransform NameTransform
		{
			get { return nameTransform; }
			set {
				if ( value == null ) {
					nameTransform = new ZipNameTransform();
				}
				else {
					nameTransform = value;
				}
			}
		}

        #region Instance Fields
        /// <summary>
        /// The buffer
        /// </summary>
        byte[] buffer;
        /// <summary>
        /// The output stream
        /// </summary>
        ZipOutputStream outputStream;
        /// <summary>
        /// The input stream
        /// </summary>
        ZipInputStream inputStream;
        /// <summary>
        /// The password
        /// </summary>
        string password = null;
        /// <summary>
        /// The target directory
        /// </summary>
        string targetDirectory;
        /// <summary>
        /// The source directory
        /// </summary>
        string sourceDirectory;
        /// <summary>
        /// The file filter
        /// </summary>
        NameFilter fileFilter;
        /// <summary>
        /// The directory filter
        /// </summary>
        NameFilter directoryFilter;
        /// <summary>
        /// The overwrite
        /// </summary>
        Overwrite overwrite;
        /// <summary>
        /// The confirm delegate
        /// </summary>
        ConfirmOverwriteDelegate confirmDelegate;
        /// <summary>
        /// The restore date time
        /// </summary>
        bool restoreDateTime = false;
        /// <summary>
        /// The create empty directories
        /// </summary>
        bool createEmptyDirectories = false;
        /// <summary>
        /// The events
        /// </summary>
        FastZipEvents events;
        /// <summary>
        /// The name transform
        /// </summary>
        ZipNameTransform nameTransform;
		#endregion
	}
}
