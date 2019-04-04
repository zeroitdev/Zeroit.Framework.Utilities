// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="FilesCache.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;

using Zeroit.Framework.Utilities.Collections.Generic;


namespace Zeroit.Framework.Utilities.IO
{
    /// <summary>
    /// Class FilesCache.
    /// </summary>
    public class FilesCache
    {
        /// <summary>
        /// The files
        /// </summary>
        private KeyedCollection<Stream> _files;
        /// <summary>
        /// The free files
        /// </summary>
        private LightCollection<string> _freeFiles;

        /// <summary>
        /// The maximum buffer size
        /// </summary>
        private long _maxBufferSize;
        /// <summary>
        /// The current buffer size
        /// </summary>
        private long _currentBufferSize;
        /// <summary>
        /// The maximum override size
        /// </summary>
        private long _maxOverrideSize;
        /// <summary>
        /// The is on quota override
        /// </summary>
        private bool _isOnQuotaOverride;

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            if(_files!=null)
                _files.Clear();
            if(_freeFiles!=null)
                _freeFiles.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesCache"/> class.
        /// </summary>
        public FilesCache():this(52428800,20971520) // 50 MB, 20 MB
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FilesCache"/> class.
        /// </summary>
        /// <param name="maxBufferSize">Maximum size of the buffer.</param>
        public FilesCache(long maxBufferSize):this(maxBufferSize,20971520)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FilesCache"/> class.
        /// </summary>
        /// <param name="maxBufferSize">Maximum size of the buffer.</param>
        /// <param name="maxOverrideSize">Maximum size of the override.</param>
        public FilesCache(long maxBufferSize,long maxOverrideSize)
        {
            _maxBufferSize = maxBufferSize;
            _maxOverrideSize = maxOverrideSize;
            _files = new KeyedCollection<Stream>();
            _freeFiles = new LightCollection<string>();
            _isOnQuotaOverride = false;
        }

        /// <summary>
        /// Gets or sets the maximum size of the buffer.
        /// </summary>
        /// <value>The maximum size of the buffer.</value>
        public long MaxBufferSize
        {
            get
            {
                if (_isOnQuotaOverride)
                {
                    return _maxBufferSize + _maxOverrideSize;
                }
                return _maxBufferSize;
            }
            set
            {
                _maxBufferSize = value;
            }
        }
        /// <summary>
        /// Gets or sets the maximum size of the override.
        /// </summary>
        /// <value>The maximum size of the override.</value>
        public long MaxOverrideSize
        {
            get
            {
                return _maxOverrideSize;
            }
            set
            {
                _maxOverrideSize = value;
            }
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>Stream.</returns>
        public Stream OpenFile(string filename)
        {
            return OpenFile(filename, false);
        }
        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="forceReload">if set to <c>true</c> [force reload].</param>
        /// <returns>Stream.</returns>
        public Stream OpenFile(string filename,bool forceReload)
        {
            if (forceReload && _files.ContainsKey(filename))
            {
                long length = _files[filename].Length;
                _files.RemoveByKey(filename);
                if (_freeFiles.Contains(filename)) _freeFiles.Remove(filename);
                _currentBufferSize -= length;
            }

            this.CacheFile(filename);

            return _files[filename];
        }
        /// <summary>
        /// Caches the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void CacheFile(string filename)
        {
            if (!_files.ContainsKey(filename))
            {
                StreamReader sr = new StreamReader(filename);
                _currentBufferSize += sr.BaseStream.Length;
                EnsureCapacity();
                _files.Add(filename, CloneStream(sr.BaseStream));
                sr.Close();
            }
        }
        /// <summary>
        /// Closes the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void CloseFile(string filename)
        {
            if (_files.ContainsKey(filename))
            {
                //_currentBufferSize -= _files[filename].Length;
                //_files.Remove(filename);
                //EnsureCapacity();
                if (!_freeFiles.Contains(filename))
                {
                    _freeFiles.Add(filename);
                }
            }
        }
        /// <summary>
        /// Gets the size of the used buffer.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long GetUsedBufferSize()
        {
            return _currentBufferSize;
        }
        /// <summary>
        /// Gets the size of the free buffer.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long GetFreeBufferSize()
        {
            if (_isOnQuotaOverride)
            {
                return (_maxBufferSize + _maxOverrideSize) - _currentBufferSize;
            }
            return _maxBufferSize - _currentBufferSize;
        }
        /// <summary>
        /// Frees the cache.
        /// </summary>
        public void FreeCache()
        {
            _files.Clear();
            _freeFiles.Clear();
            _isOnQuotaOverride = false;
            _currentBufferSize = 0;
        }
        /// <summary>
        /// Frees the cached file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool FreeCachedFile(string filename)
        {
            if (_files.ContainsKey(filename))
            {
                _currentBufferSize -= _files[filename].Length;
                _files.RemoveByKey(filename);
                EnsureCapacity();
                _freeFiles.Remove(filename);
                return true;
            }
            _freeFiles.Remove(filename);
            return false;
        }
        /// <summary>
        /// Determines whether [is cached file] [the specified filename].
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns><c>true</c> if [is cached file] [the specified filename]; otherwise, <c>false</c>.</returns>
        public bool IsCachedFile(string filename)
        {
            return _files.ContainsKey(filename);
        }
        /// <summary>
        /// Determines whether [is on quota override].
        /// </summary>
        /// <returns><c>true</c> if [is on quota override]; otherwise, <c>false</c>.</returns>
        public bool IsOnQuotaOverride()
        {
            return _isOnQuotaOverride;
        }
        /// <summary>
        /// Gets the cached files.
        /// </summary>
        /// <value>The cached files.</value>
        public string[] CachedFiles
        {
            get
            {
                return _files.Keys;
            }
        }

        /// <summary>
        /// Ensures the capacity.
        /// </summary>
        /// <exception cref="Exception">Cache quota exceded</exception>
        private void EnsureCapacity()
        {
            if (_currentBufferSize > _maxBufferSize)
            {
                if (_currentBufferSize > _maxBufferSize + _maxOverrideSize)
                {
                    if (_freeFiles.Count == 0)
                    {
                        throw new Exception("Cache quota exceded");
                    }
                    else
                    {
                        _files.RemoveByKey(_freeFiles[0]);
                        EnsureCapacity();
                    }
                }
                else
                {
                    _isOnQuotaOverride = true;
                }
            }
            else
            {
                _isOnQuotaOverride = false;
            }
        }
        /// <summary>
        /// Clones the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>Stream.</returns>
        private Stream CloneStream(Stream stream)
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            return new MemoryStream(buffer);
        }

    }
}
