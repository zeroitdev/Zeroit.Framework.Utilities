// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipHelperDir.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.IO
{
    /// <summary>
    /// Class ZipHelperDir.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.ZipHelperEntry" />
    public class ZipHelperDir : ZipHelperEntry
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipHelperDir"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="path">The path.</param>
        internal ZipHelperDir(ZipHelper owner,string path)
            :base(owner,path)
        {
        }

        /// <summary>
        /// Gets the dirs.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetDirs()
        {
            return OwnerZip.GetDirs(this.Path);
        }
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetFiles()
        {
            return OwnerZip.GetFiles(this.Path);
        }
    }
}
