// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
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
using System.Xml.Serialization;

namespace Zeroit.Framework.Utilities.Files
{
    /// <summary>
    /// Description of Serializer.
    /// </summary>
    public static class Serializer
	{
        /// <summary>
        /// Objects to file.
        /// </summary>
        /// <param name="xObject">The x object.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ObjectToFile(object xObject,string FileName)
		{
			try
			{
				string Serialized= ObjectToString(xObject);
				TextIO.StringToFile(FileName,Serialized);
				return true;
			}
			catch(Exception EX)
			{
			}
			return false;
		}

        /// <summary>
        /// Files to object.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="xObject">The x object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool FileToObject(string FileName,ref object xObject)
		{
			try
			{
				string Serialized= TextIO.FileToString(FileName);
				return StringToObject(Serialized,ref xObject);
			}
			catch(Exception EX)
			{
			}
			return false;
		}

        /// <summary>
        /// Objects to string.
        /// </summary>
        /// <param name="xObject">The x object.</param>
        /// <returns>System.String.</returns>
        private static string ObjectToString(object xObject)
        {
            try
            {
                XmlSerializer xSerializer = new XmlSerializer(xObject.GetType(), "");
                StringWriter xString = new StringWriter();
                xSerializer.Serialize(xString, xObject, null);
                return xString.ToString();
            }
            catch (Exception EX)
            {
            }
            return null;
        }

        /// <summary>
        /// Strings to object.
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <param name="xObject">The x object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool StringToObject(string Data, ref object xObject)
        {
            try
            {
                XmlSerializer xSerializer = new XmlSerializer(xObject.GetType(), "");
                StringReader xString = new StringReader(Data);
                xObject = xSerializer.Deserialize(xString);
                return true;
            }
            catch (Exception EX)
            {
            }
            return false;
        }


    }
}
