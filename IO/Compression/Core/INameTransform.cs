// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="INameTransform.cs" company="Zeroit Dev Technologies">
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
