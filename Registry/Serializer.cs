// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
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
using System.Xml.Serialization;
using System.IO;


namespace Zeroit.Framework.Utilities.Registry
{
    /// <summary>
    /// Description of MyClass.
    /// </summary>
    public static class Serializer
	{

        /// <summary>
        /// Loads from registry.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="ValueName">Name of the value.</param>
        /// <param name="xData">The x data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool LoadFromRegistry(string Key,string ValueName,ref object xData)
		{
			try
			{
				string Reg=(string)Microsoft.Win32.Registry.CurrentUser.OpenSubKey(Key).GetValue(ValueName);
				return StringToObject(Reg,ref xData);
			}
			catch(Exception EX)
			{
			}
			return false;
			
		}

        /// <summary>
        /// Saves to registry.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="ValueName">Name of the value.</param>
        /// <param name="xData">The x data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SaveToRegistry(string Key,string ValueName,object xData)
		{
			try
			{
				string Value=ObjectToString(xData);
				return KeyValue.SaveObject(Key,ValueName,Value);
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
