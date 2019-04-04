// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FileSystemScanner.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************



using System;

namespace Zeroit.Framework.Utilities.IO.Compression.Core
{
    /// <summary>
    /// Event arguments for scanning.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ScanEventArgs : EventArgs
	{
        /// <summary>
        /// Initialise a new instance of <see cref="ScanEventArgs" />
        /// </summary>
        /// <param name="name">The name.</param>
        public ScanEventArgs(string name)
		{
			this.name = name;
			ContinueRunning = true;
		}

        /// <summary>
        /// The name
        /// </summary>
        string name;

        /// <summary>
        /// The name for this event.
        /// </summary>
        /// <value>The name.</value>
        public string Name
		{
			get { return name; }
		}

        /// <summary>
        /// The continue running
        /// </summary>
        bool continueRunning;

        /// <summary>
        /// Get set a value indicating if scanning should continue or not.
        /// </summary>
        /// <value><c>true</c> if [continue running]; otherwise, <c>false</c>.</value>
        public bool ContinueRunning
		{
			get { return continueRunning; }
			set { continueRunning = value; }
		}
	}

    /// <summary>
    /// Event arguments for directories.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Core.ScanEventArgs" />
    public class DirectoryEventArgs : ScanEventArgs
	{
        /// <summary>
        /// Initialize an instance of <see cref="DirectoryEventArgs"></see>.
        /// </summary>
        /// <param name="name">The name for this directory.</param>
        /// <param name="hasMatchingFiles">Flag value indicating if any matching files are contained in this directory.</param>
        public DirectoryEventArgs(string name, bool hasMatchingFiles)
			: base (name)
		{
			this.hasMatchingFiles = hasMatchingFiles;
		}

        /// <summary>
        /// Get a value indicating if the directory contains any matching files or not.
        /// </summary>
        /// <value><c>true</c> if this instance has matching files; otherwise, <c>false</c>.</value>
        public bool HasMatchingFiles
		{
			get { return hasMatchingFiles; }
		}

        /// <summary>
        /// The has matching files
        /// </summary>
        bool hasMatchingFiles;
	}

    /// <summary>
    /// Arguments passed when scan failures are detected.
    /// </summary>
    public class ScanFailureEventArgs
	{
        /// <summary>
        /// Initialise a new instance of <see cref="ScanFailureEventArgs"></see>
        /// </summary>
        /// <param name="name">The name to apply.</param>
        /// <param name="e">The exception to use.</param>
        public ScanFailureEventArgs(string name, Exception e)
		{
			this.name = name;
			this.exception = e;
			continueRunning = true;
		}

        /// <summary>
        /// The name
        /// </summary>
        string name;

        /// <summary>
        /// The applicable name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
		{
			get { return name; }
		}

        /// <summary>
        /// The exception
        /// </summary>
        Exception exception;

        /// <summary>
        /// The applicable exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception
		{
			get { return exception; }
		}

        /// <summary>
        /// The continue running
        /// </summary>
        bool continueRunning;

        /// <summary>
        /// Get / set a value indicating wether scanning should continue.
        /// </summary>
        /// <value><c>true</c> if [continue running]; otherwise, <c>false</c>.</value>
        public bool ContinueRunning
		{
			get { return continueRunning; }
			set { continueRunning = value; }
		}
	}

    /// <summary>
    /// Delegate invokked when a directory is processed.
    /// </summary>
    /// <param name="Sender">The sender.</param>
    /// <param name="e">The <see cref="DirectoryEventArgs"/> instance containing the event data.</param>
    public delegate void ProcessDirectoryDelegate(object Sender, DirectoryEventArgs e);

    /// <summary>
    /// Delegate invoked when a file is processed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ScanEventArgs"/> instance containing the event data.</param>
    public delegate void ProcessFileDelegate(object sender, ScanEventArgs e);

    /// <summary>
    /// Delegate invoked when a directory failure is detected.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ScanFailureEventArgs"/> instance containing the event data.</param>
    public delegate void DirectoryFailureDelegate(object sender, ScanFailureEventArgs e);

    /// <summary>
    /// Delegate invoked when a file failure is detected.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ScanFailureEventArgs"/> instance containing the event data.</param>
    public delegate void FileFailureDelegate(object sender, ScanFailureEventArgs e);

    /// <summary>
    /// FileSystemScanner provides facilities scanning of files and directories.
    /// </summary>
    public class FileSystemScanner
	{
        /// <summary>
        /// Initialise a new instance of <see cref="FileSystemScanner"></see>
        /// </summary>
        /// <param name="filter">The file filter to apply when scanning.</param>
        public FileSystemScanner(string filter)
		{
			fileFilter = new PathFilter(filter);
		}

        /// <summary>
        /// Initialise a new instance of <see cref="FileSystemScanner"></see>
        /// </summary>
        /// <param name="fileFilter">The file <see cref="NameFilter"></see>filter to apply.</param>
        /// <param name="directoryFilter">The directory <see cref="NameFilter"></see>filter to apply.</param>
        public FileSystemScanner(string fileFilter, string directoryFilter)
		{
			this.fileFilter = new PathFilter(fileFilter);
			this.directoryFilter = new PathFilter(directoryFilter);
		}

        /// <summary>
        /// Initialise a new instance of <see cref="FileSystemScanner"></see>
        /// </summary>
        /// <param name="fileFilter">The file <see cref="NameFilter"></see>filter to apply.</param>
        public FileSystemScanner(IScanFilter fileFilter)
		{
			this.fileFilter = fileFilter;
		}

        /// <summary>
        /// Initialise a new instance of <see cref="FileSystemScanner"></see>
        /// </summary>
        /// <param name="fileFilter">The file <see cref="IScanFilter"></see>filter to apply.</param>
        /// <param name="directoryFilter">The directory <see cref="IScanFilter"></see>filter to apply.</param>
        public FileSystemScanner(IScanFilter fileFilter, IScanFilter directoryFilter)
		{
			this.fileFilter = fileFilter;
			this.directoryFilter = directoryFilter;
		}

        /// <summary>
        /// Delegate to invoke when a directory is processed.
        /// </summary>
        public ProcessDirectoryDelegate ProcessDirectory;

        /// <summary>
        /// Delegate to invoke when a file is processed.
        /// </summary>
        public ProcessFileDelegate ProcessFile;

        /// <summary>
        /// Delegate to invoke when a directory failure is detected.
        /// </summary>
        public DirectoryFailureDelegate DirectoryFailure;

        /// <summary>
        /// Delegate to invoke when a file failure is detected.
        /// </summary>
        public FileFailureDelegate FileFailure;

        /// <summary>
        /// Raise the DirectoryFailure event.
        /// </summary>
        /// <param name="directory">Rhe directory name.</param>
        /// <param name="e">The exception detected.</param>
        public void OnDirectoryFailure(string directory, Exception e)
		{
			if ( DirectoryFailure == null ) {
				alive = false;
			} else {
				ScanFailureEventArgs args = new ScanFailureEventArgs(directory, e);
				DirectoryFailure(this, args);
				alive = args.ContinueRunning;
			}
		}

        /// <summary>
        /// Raise the FileFailure event.
        /// </summary>
        /// <param name="file">The file name.</param>
        /// <param name="e">The exception detected.</param>
        public void OnFileFailure(string file, Exception e)
		{
			if ( FileFailure == null ) {
				alive = false;
			} else {
				ScanFailureEventArgs args = new ScanFailureEventArgs(file, e);
				FileFailure(this, args);
				alive = args.ContinueRunning;
			}
		}

        /// <summary>
        /// Raise the ProcessFile event.
        /// </summary>
        /// <param name="file">The file name.</param>
        public void OnProcessFile(string file)
		{
			if ( ProcessFile != null ) {
				ScanEventArgs args = new ScanEventArgs(file);
				ProcessFile(this, args);
				alive = args.ContinueRunning;
			}
		}

        /// <summary>
        /// Raise the ProcessDirectory event.
        /// </summary>
        /// <param name="directory">The directory name.</param>
        /// <param name="hasMatchingFiles">Flag indicating if the directory has matching files.</param>
        public void OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
			if ( ProcessDirectory != null ) {
				DirectoryEventArgs args = new DirectoryEventArgs(directory, hasMatchingFiles);
				ProcessDirectory(this, args);
				alive = args.ContinueRunning;
			}
		}

        /// <summary>
        /// Scan a directory.
        /// </summary>
        /// <param name="directory">The base directory to scan.</param>
        /// <param name="recurse">True to recurse subdirectories, false to do a single directory.</param>
        public void Scan(string directory, bool recurse)
		{
			alive = true;
			ScanDir(directory, recurse);
		}

        /// <summary>
        /// Scans the dir.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="recurse">if set to <c>true</c> [recurse].</param>
        void ScanDir(string directory, bool recurse)
		{

			try {
				string[] names = System.IO.Directory.GetFiles(directory);
				bool hasMatch = false;
				for (int fileIndex = 0; fileIndex < names.Length; ++fileIndex) {
					if ( !fileFilter.IsMatch(names[fileIndex]) ) {
						names[fileIndex] = null;
					} else {
						hasMatch = true;
					}
				}
				
				OnProcessDirectory(directory, hasMatch);
				
				if ( alive && hasMatch ) {
					foreach (string fileName in names) {
						try {
							if ( fileName != null ) {
								OnProcessFile(fileName);
								if ( !alive ) {
									break;
								}
							}
						}
						catch (Exception e)
						{
							OnFileFailure(fileName, e);
						}
					}
				}
			}
			catch (Exception e) {
				OnDirectoryFailure(directory, e);
			}

			if ( alive && recurse ) {
				try {
					string[] names = System.IO.Directory.GetDirectories(directory);
					foreach (string fulldir in names) {
						if ((directoryFilter == null) || (directoryFilter.IsMatch(fulldir))) {
							ScanDir(fulldir, true);
							if ( !alive ) {
								break;
							}
						}
					}
				}
				catch (Exception e) {
					OnDirectoryFailure(directory, e);
				}
			}
		}

        #region Instance Fields
        /// <summary>
        /// The file filter currently in use.
        /// </summary>
        IScanFilter fileFilter;
        /// <summary>
        /// The directory filter currently in use.
        /// </summary>
        IScanFilter directoryFilter;
        /// <summary>
        /// Falg indicating if scanning is still alive.  Used to cancel a scan.
        /// </summary>
        bool alive;
		#endregion
	}
}
