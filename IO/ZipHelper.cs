// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipHelper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;
using Zeroit.Framework.Utilities.IO.Compression.Zip;
using Zeroit.Framework.Utilities.Collections.Specialized;
using System.IO;

namespace Zeroit.Framework.Utilities.IO
{
    /// <summary>
    /// Class ZipHelper.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ZipHelper : IDisposable
    {
        /// <summary>
        /// The filename
        /// </summary>
        private string _filename;
        /// <summary>
        /// The zip
        /// </summary>
        private ZipFile _zip;
        /// <summary>
        /// The curr dir
        /// </summary>
        private ZipHelperDir _currDir;
        /// <summary>
        /// The curr path
        /// </summary>
        private string _currPath;
        /// <summary>
        /// The is open
        /// </summary>
        private bool _isOpen;
        /// <summary>
        /// The dirs
        /// </summary>
        private StringCollection _dirs;
        /// <summary>
        /// The files
        /// </summary>
        private StringCollection _files;

        // ------------------------------------------------------------------- //

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipHelper"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public ZipHelper(string filename)
        {
            _filename = filename;
            _currDir = new ZipHelperDir(this, "/");
            _currPath = _currDir.Path;
            _isOpen = false;
        }

        // ------------------------------------------------------------------- //

        /// <summary>
        /// Finalizes an instance of the <see cref="ZipHelper"/> class.
        /// </summary>
        ~ZipHelper()
        {
            this.Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_isOpen) this.Close();
        }

        // ------------------------------------------------------------------- //

        /// <summary>
        /// Gets the current dir.
        /// </summary>
        /// <value>The current dir.</value>
        public ZipHelperDir CurrentDir
        {
            get
            {
                return _currDir;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
        }
        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename
        {
            get
            {
                return _filename;
            }
        }

        // ------------------------------------------------------------------- //

        /// <summary>
        /// Opens this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Open()
        {
            _zip = new ZipFile(_filename);
            if (_zip == null)
            {
                _isOpen = false;
                return false;
            }

            ReadZip();
            _isOpen = true;
            return true;
        }
        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            if (_isOpen)
            {
                _zip.Close();
            }
            _isOpen = false;
        }
        /// <summary>
        /// Moves up.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveUp()
        {
            if (_currPath == "/")
            {
                return false;
            }
            return SetCurrentDir(UpperPath(_currPath));
        }
        /// <summary>
        /// Moves to.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveTo(string path)
        {
            if (!IsValidPath(path)) return false;
            return SetCurrentDir(path);
        }
        /// <summary>
        /// Gets all dirs.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetAllDirs()
        {
            //StringCollection sc = new StringCollection();
            //sc.Add("/");
            //foreach (ZipEntry ze in _zip)
            //{
            //    if (ze.IsDirectory)
            //    {
            //        sc.Add("/" + ze.Name);
            //    }
            //}
            //sc.Sort();
            //return sc.GetItems();

            return _dirs.GetItems();
        }
        /// <summary>
        /// Gets all files.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetAllFiles()
        {
            //StringCollection sc = new StringCollection();
            //foreach (ZipEntry ze in _zip)
            //{
            //    if (ze.IsFile)
            //    {
            //        sc.Add("/" + ze.Name);
            //    }
            //}
            //sc.Sort();
            //return sc.GetItems();

            return _files.GetItems();
        }
        /// <summary>
        /// Gets the dir.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ZipHelperDir.</returns>
        public ZipHelperDir GetDir(string path)
        {
            if (!IsValidPath(path)) return null;

            return new ZipHelperDir(this, path);
        }
        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ZipHelperFile.</returns>
        public ZipHelperFile GetFile(string path)
        {
            if (!IsValidPath(path)) return null;

            return new ZipHelperFile(this, path);
        }
        /// <summary>
        /// Gets the dirs.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetDirs()
        {
            return GetDirs("/");
        }
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetFiles()
        {
            return GetFiles("/");
        }
        /// <summary>
        /// Gets the dirs.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String[].</returns>
        public string[] GetDirs(string path)
        {
            if (!IsValidPath(path)) return new string[0];

            int pathsCount = path.Split('/').Length;
            if (path == "/") pathsCount = 1;

            StringCollection result = new StringCollection();
            for (int i = 0; i < _dirs.Count; i++)
            {
                if (_dirs[i].StartsWith(path) && (_dirs[i].Split('/').Length == (pathsCount + 1)) && (_dirs[i] != "/"))
                {
                    result.Add(_dirs[i]);
                }
            }
            return result.GetItems();
        }
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String[].</returns>
        public string[] GetFiles(string path)
        {
            if (!IsValidPath(path)) return new string[0];

            int pathsCount = path.Split('/').Length;
            if (path == "/") pathsCount = 1;

            StringCollection result = new StringCollection();
            for (int i = 0; i < _files.Count; i++)
            {
                if (_files[i].StartsWith(path) && _files[i].Split('/').Length == (pathsCount + 1))
                {
                    result.Add(_files[i]);
                }
            }
            return result.GetItems();
        }
        /// <summary>
        /// Extracts the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Extract(string path)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(_filename));
            ZipEntry ze;

            while ((ze = s.GetNextEntry()) != null)
            {
                string dirName = Path.GetDirectoryName(ze.Name);
                string fileName = Path.GetFileName(ze.Name);

                if (ze.IsFile)
                {
                    if (!Directory.Exists(path + "\\" + dirName))
                    {
                        Directory.CreateDirectory(path + "\\" + dirName);
                    }

                    FileStream streamWriter = File.Create(path + "\\" + dirName + "\\" + fileName);

                    if (ze.Size > 0)
                    {
                        int size = 2048;
                        byte[] data = new byte[size];

                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    streamWriter.Close();
                }
            }

            s.Close();
        }

        // ------------------------------------------------------------------- //

        /// <summary>
        /// Reads the zip.
        /// </summary>
        private void ReadZip()
        {
            _dirs = new StringCollection();
            _dirs.Add("/");

            _files = new StringCollection();

            foreach(ZipEntry ze in _zip)
            {
                if (ze.IsDirectory)
                {
                    _dirs.Add("/" + ze.Name.TrimEnd('/'));
                }
                else if (ze.IsFile)
                {
                    _files.Add("/" + ze.Name.TrimEnd('/'));
                }
            }

            _dirs.Sort();
            _files.Sort();
        }
        /// <summary>
        /// Formats to internal path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string FormatToInternalPath(string path)
        {
            path = path.Replace('\\', '/');
            path = path.TrimStart('/');
            path = path.TrimEnd('/');
            return path;
        }

        // ------------------------------------------------------------------- //

        /// <summary>
        /// Uppers the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        internal string UpperPath(string path)
        {
            path = path.Replace("\\", "/");
            path = path.TrimEnd('/');
            string[] names = path.Split('/');
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < names.Length - 1; i++)
            {
                sb.Append("/");
                sb.Append(names[i]);
            }

            if (sb.Length == 0) sb.Append("/");
            return sb.ToString();
        }
        /// <summary>
        /// Determines whether [is valid path] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is valid path] [the specified path]; otherwise, <c>false</c>.</returns>
        internal bool IsValidPath(string path)
        {
            return _dirs.Contains(path) || _files.Contains(path);
        }
        /// <summary>
        /// Extracts the name.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        internal string ExtractName(string path)
        {
            path = path.Replace("\\", "/");
            if (path == "/") return string.Empty;
            path = path.TrimEnd('/');
            string[] names = path.Split('/');
            return names[names.Length - 1];
        }
        /// <summary>
        /// Sets the current dir.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal bool SetCurrentDir(string path)
        {
            _currPath = path;
            _currDir = new ZipHelperDir(this, _currPath);
            return true;
        }
        /// <summary>
        /// Gets the zip entry.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ZipEntry.</returns>
        internal ZipEntry GetZipEntry(string path)
        {
            path = FormatToInternalPath(path);
            if (path == "" || path == "/") return null;
            return _zip.GetEntry(path);
        }

        // ------------------------------------------------------------------- //

        //public bool MoveNext()
        //{
        //    throw new NotImplementedException();
        //}
        //public bool MoveToFirstChildDir()
        //{
        //    throw new NotImplementedException();
        //}
        //public bool MakeDir(string name)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
