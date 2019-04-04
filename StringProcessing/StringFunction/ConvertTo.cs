// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ConvertTo.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
