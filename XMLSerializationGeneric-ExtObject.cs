// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="XMLSerializationGeneric-ExtObject.cs" company="Zeroit Dev Technologies">
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
using System.Xml;

namespace Zeroit.Framework.Utilities.XML
{
    /// <summary>
    /// A class collection for XML Serialization
    /// </summary>
    public static class XMLSerializationGenericExtObject
    {
        /// <summary>
        /// XML Serialize
        /// </summary>
        /// <typeparam name="T">Set type</typeparam>
        /// <param name="objectToSerialize">Set object type to serialize</param>
        /// <returns>System.String.</returns>
        public static string XmlSerialize<T>(this T objectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.Formatting = Formatting.Indented;
            xmlSerializer.Serialize(xmlWriter, objectToSerialize);

            return stringWriter.ToString();
        }
    }
}
