// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ZipNameTransform.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

using Zeroit.Framework.Utilities.IO.Compression.Core;

namespace Zeroit.Framework.Utilities.IO.Compression.Zip
{
    /// <summary>
    /// ZipNameTransform transforms name as per the Zip file convention.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Core.INameTransform" />
    public class ZipNameTransform : INameTransform
	{
        /// <summary>
        /// Initialize a new instance of <see cref="ZipNameTransform"></see>
        /// </summary>
        /// <remarks>Relative paths default to true with this constructor.</remarks>
        public ZipNameTransform()
		{
			relativePath = true;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="ZipNameTransform"></see>
        /// </summary>
        /// <param name="useRelativePaths">If true relative paths are created,
        /// if false absolute paths are created.</param>
        public ZipNameTransform(bool useRelativePaths)
		{
			relativePath = useRelativePaths;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="ZipNameTransform"></see>
        /// </summary>
        /// <param name="useRelativePaths">If true relative paths are created,
        /// if false absolute paths are created.</param>
        /// <param name="trimPrefix">The string to trim from front of paths if found.</param>
        public ZipNameTransform(bool useRelativePaths, string trimPrefix)
		{
			this.trimPrefix = trimPrefix;
			relativePath = useRelativePaths;
		}

        /// <summary>
        /// Transform a directory name according to the Zip file naming conventions.
        /// </summary>
        /// <param name="name">The directory name to transform.</param>
        /// <returns>The transformed name.</returns>
        public string TransformDirectory(string name)
		{
			name = TransformFile(name);
			if (name.Length > 0) {
				if ( !name.EndsWith("/") ) {
					name += "/";
				}
			}
			else {
				name = "/";
			}
			return name;
		}

        /// <summary>
        /// Transform a file name according to the Zip file naming conventions.
        /// </summary>
        /// <param name="name">The file name to transform.</param>
        /// <returns>The transformed name.</returns>
        public string TransformFile(string name)
		{
			if (name != null) {
				if ( trimPrefix != null && name.IndexOf(trimPrefix) == 0 ) {
					name = name.Substring(trimPrefix.Length);
				}
				
				if (Path.IsPathRooted(name) == true) {
					// NOTE:
					// for UNC names...  \\machine\share\zoom\beet.txt gives \zoom\beet.txt
					name = name.Substring(Path.GetPathRoot(name).Length);
				}
				
				if (relativePath == true) {
					if (name.Length > 0 && (name[0] == Path.AltDirectorySeparatorChar || name[0] == Path.DirectorySeparatorChar)) {
						name = name.Remove(0, 1);
					}
				} else {
					if (name.Length > 0 && name[0] != Path.AltDirectorySeparatorChar && name[0] != Path.DirectorySeparatorChar) {
						name = name.Insert(0, "/");
					}
				}
				name = name.Replace(@"\", "/");
			}
			else {
				name = "";
			}
			return name;
		}

        /// <summary>
        /// The trim prefix
        /// </summary>
        string trimPrefix;

        /// <summary>
        /// Get/set the path prefix to be trimmed from paths if present.
        /// </summary>
        /// <value>The trim prefix.</value>
        public string TrimPrefix
		{
			get { return trimPrefix; }
			set { trimPrefix = value; }
		}

        /// <summary>
        /// The relative path
        /// </summary>
        bool relativePath;
	}
}
