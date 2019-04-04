// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Serializer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Xml;

namespace Zeroit.Framework.Utilities.Serialization
{
    /// <summary>
    /// Class Serializer.
    /// </summary>
    public class Serializer
    {

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">The obj is not marked with SerializerAttribute</exception>
        /// <exception cref="Exception">The property " + current.Name + " don't have a set method!</exception>
        public static string Serialize(object obj)
        {
           object[] attrs = obj.GetType().GetCustomAttributes(typeof(SerializerAttribute), false);

           if (attrs.Length == 0)
           {
               throw new InvalidOperationException("The obj is not marked with SerializerAttribute");
           }


           PropertyInfo[] infos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic);

           StringBuilder sbXml = new StringBuilder();

           XmlTextWriter xwr = new XmlTextWriter(new StringWriter(sbXml).ToString(), Encoding.UTF8);

           xwr.Formatting = Formatting.Indented;

           xwr.WriteStartElement("Object");
           xwr.WriteAttributeString("Assembly", obj.GetType().Assembly.FullName);
           xwr.WriteAttributeString("Type", obj.GetType().FullName);

           foreach (PropertyInfo current in infos)
           {
               if (!current.CanWrite)
                   throw new Exception("The property " + current.Name + " don't have a set method!");
               xwr.WriteStartElement("Property");
               xwr.WriteAttributeString("Name", current.Name);
               xwr.WriteAttributeString("Type", current.PropertyType.ToString());

               xwr.WriteEndElement();
           }

           xwr.WriteEndElement();

           xwr.Flush();

           xwr.Close();

           return sbXml.ToString();
        }
    }
}
