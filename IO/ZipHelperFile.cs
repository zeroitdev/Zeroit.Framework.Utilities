// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipHelperFile.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
