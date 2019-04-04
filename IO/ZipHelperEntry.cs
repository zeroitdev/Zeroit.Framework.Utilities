// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipHelperEntry.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.IO.Compression.Zip;

namespace Zeroit.Framework.Utilities.IO
{
    /// <summary>
    /// Class ZipHelperEntry.
    /// </summary>
    public abstract class ZipHelperEntry
    {
        /// <summary>
        /// The owner
        /// </summary>
        ZipHelper _owner;
        /// <summary>
        /// The zip entry
        /// </summary>
        ZipEntry _zipEntry;
        /// <summary>
        /// The name
        /// </summary>
        string _name;
        /// <summary>
        /// The path
        /// </summary>
        string _path;
        //bool _isRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipHelperEntry"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="path">The path.</param>
        protected internal ZipHelperEntry(ZipHelper owner, string path)
        {
            _owner = owner;
            _path = path;

            if (path == "/" || path == "")
            {
                _zipEntry = null;
                //_isRoot = true;
                _name = "<root>";
            }
            else
            {
                _zipEntry = _owner.GetZipEntry(_path);
                _name = _owner.ExtractName(_path);
            }
        }

        /// <summary>
        /// Gets or sets the internal zip entry.
        /// </summary>
        /// <value>The internal zip entry.</value>
        internal ZipEntry InternalZipEntry
        {
            get
            {
                return _zipEntry;
            }
            set
            {
                _zipEntry = value;
            }
        }
        /// <summary>
        /// Gets the owner zip.
        /// </summary>
        /// <value>The owner zip.</value>
        internal ZipHelper OwnerZip
        {
            get
            {
                return _owner;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
        }
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get
            {
                return _path;
            }
        }
    }
}
