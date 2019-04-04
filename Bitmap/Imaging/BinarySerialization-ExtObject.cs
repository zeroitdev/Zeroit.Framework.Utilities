// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BinarySerialization-ExtObject.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
