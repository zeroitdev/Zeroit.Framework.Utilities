// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Serializer.cs" company="Zeroit Dev Technologies">
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
