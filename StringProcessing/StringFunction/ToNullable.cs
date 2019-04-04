// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToNullable.cs" company="Zeroit Dev Technologies">
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
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {

        //---------------------------------Implementation-----------------------------//

        //int? numVotes = "123".ToNullable<int>();
        //decimal price = tbxPrice.Text.ToNullable<decimal>() ?? 0.0M;
        //PetTypeEnum petType = "Cat".ToNullable<PetTypeEnum>() ?? PetTypeEnum.DefaultPetType;
        //PetTypeEnum petTypeByIntValue = "2".ToNullable<PetTypeEnum>() ?? PetTypeEnum.DefaultPetType;

        //string thisWillNotThrowException = null;
        //int? nullsAreSafe = thisWillNotThrowException.ToNullable<int>();
        //// More examples here: https://github.com/Pangamma/PangammaUtilities-CSharp/blob/master/TestExamples/ToNullableStringExtensionTests.cs

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// <para>More convenient than using T.TryParse(string, out T).
        /// Works with primitive types, structs, and enums.
        /// Tries to parse the string to an instance of the type specified.
        /// If the input cannot be parsed, null will be returned.
        /// </para>
        /// <para>
        /// If the value of the caller is null, null will be returned.
        /// So if you have "string s = null;" and then you try "s.ToNullable...",
        /// null will be returned. No null exception will be thrown.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p_self">The p self.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        public static T? ToNullable<T>(this string p_self) where T : struct
        {
            if (!string.IsNullOrEmpty(p_self))
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                if (converter.IsValid(p_self)) return (T)converter.ConvertFromString(p_self);
                if (typeof(T).IsEnum) { T t; if (Enum.TryParse<T>(p_self, out t)) return t; }
            }

            return null;
        }

    }
}
