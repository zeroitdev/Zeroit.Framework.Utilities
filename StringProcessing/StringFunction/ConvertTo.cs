// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ConvertTo.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.Utilities.StringProcessing
{
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //var texto = "123123";
        //var res = texto.ConvertTo<int>();
        //res++;

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts to a specific data type.
        /// </summary>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="text">The text.</param>
        /// <returns>TValue.</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static TValue ConvertTo<TValue>(this string text)
        {
            TValue res = default(TValue);
            System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(TValue));
            if (tc.CanConvertFrom(text.GetType()))
                res = (TValue)tc.ConvertFrom(text);
            else
            {
                tc = System.ComponentModel.TypeDescriptor.GetConverter(text.GetType());
                if (tc.CanConvertTo(typeof(TValue)))
                    res = (TValue)tc.ConvertTo(text, typeof(TValue));
                else
                    throw new NotSupportedException();
            }
            return res;
        }

    }
}
