// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="KeyValue.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.Registry
{
    /// <summary>
    /// Description of Key.
    /// </summary>
    public static class KeyValue
	{
        /// <summary>
        /// Loads the object.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="ValueName">Name of the value.</param>
        /// <returns>System.Object.</returns>
        private static object LoadObject(string Key,string ValueName)
		{
			try
			{
				return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(Key).GetValue(ValueName);
			}
			catch(Exception EX)
			{
				
			}
			return null;
		}

        /// <summary>
        /// Loads the string.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="ValueName">Name of the value.</param>
        /// <returns>System.String.</returns>
        public static string LoadString(string Key,string ValueName)
		{
			object xTemp=KeyValue.LoadObject(Key,ValueName);
			if(xTemp==null)
				return "";
			return (string)xTemp;
		}

        /// <summary>
        /// Loads the int.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="ValueName">Name of the value.</param>
        /// <returns>System.Int32.</returns>
        public static int LoadInt(string Key,string ValueName)
		{
			object xTemp=KeyValue.LoadObject(Key,ValueName);
			if(xTemp==null)
				return 0;
			return (int)xTemp;
		}

        /// <summary>
        /// Saves the object.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="ValueName">Name of the value.</param>
        /// <param name="xValue">The x value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SaveObject(string Key,string ValueName,object xValue)
		{
			try
			{
				Microsoft.Win32.Registry.CurrentUser.CreateSubKey(Key).SetValue(ValueName,xValue.ToString());
				return true;
			}
			catch(Exception EX)
			{
			}
			return false;
		}

	}
}
