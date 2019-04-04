// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipHelperFile.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.IO
{
    /// <summary>
    /// Class ZipHelperFile.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.ZipHelperEntry" />
    public class ZipHelperFile : ZipHelperEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZipHelperFile"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="path">The path.</param>
        internal ZipHelperFile(ZipHelper owner, string path)
            : base(owner, path)
        {
        }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension
        {
            get
            {
                return System.IO.Path.GetExtension(InternalZipEntry.Name);
            }
        }
    }
}
