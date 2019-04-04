// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="INameTransform.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.Utilities.IO.Compression.Core
{
    /// <summary>
    /// INameTransform defines how file system names are transformed for use with archives.
    /// </summary>
    public interface INameTransform
	{
        /// <summary>
        /// Given a file name determine the transformed equivalent.
        /// </summary>
        /// <param name="name">The name to transform.</param>
        /// <returns>The transformed name.</returns>
        string TransformFile(string name);

        /// <summary>
        /// Given a directory name determine the transformed equivalent.
        /// </summary>
        /// <param name="name">The name to transform.</param>
        /// <returns>The transformed directory name</returns>
        string TransformDirectory(string name);
	}
}
