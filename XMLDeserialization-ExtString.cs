// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="XMLDeserialization-ExtString.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/

using System.Xml.Serialization;
using System.IO;

namespace Zeroit.Framework.Utilities.XML
{
    /// <summary>
    /// A class collection for XML String Deserialization
    /// </summary>
    public static class XMLStringDeserialization
    {
        /// <summary>
        /// Deserialize XML
        /// </summary>
        /// <typeparam name="T">Set Type</typeparam>
        /// <param name="xmlString">Set XML string</param>
        /// <returns>T.</returns>
        public static T DeserializeXML<T>(this string xmlString)
        {
            T returnValue = default(T);

            XmlSerializer serial = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xmlString);
            object result = serial.Deserialize(reader);

            if (result != null && result is T)
            {
                returnValue = ((T)result);
            }

            reader.Close();

            return returnValue;
        }
    }
}
