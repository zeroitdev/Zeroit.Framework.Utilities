// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BinarySerialization-ExtObject.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zeroit.Framework.Utilities.BinarySerializationDeepCopy
{
    /// <summary>
    /// A class for Deep copy
    /// </summary>
    public static class ExtObject
    {
        /// <summary>
        /// Deep Copy
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <param name="objectToCopy">Object to Copy</param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T objectToCopy)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, objectToCopy);

            memoryStream.Position = 0;
            T returnValue = (T)binaryFormatter.Deserialize(memoryStream);

            memoryStream.Close();
            memoryStream.Dispose();

            return returnValue;
        }
    }
}
