// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Parse.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;

namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        // regular parsing
        //int i = "123".Parse<int>();
        //int? inull = "123".Parse<int?>();
        //DateTime d = "01/12/2008".Parse<DateTime>();
        //DateTime? dn = "01/12/2008".Parse<DateTime?>();

        //// null values
        //string sample = null;
        //int? k = sample.Parse<int?>(); // returns null
        //int l = sample.Parse<int>();   // returns 0
        //DateTime dd = sample.Parse<DateTime>(); // returns 01/01/0001
        //DateTime? ddn = sample.Parse<DateTime?>(); // returns null

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Parse a string to any other type including nullable types.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        public static T Parse<T>(this string value)
        {
            // Get default value for type so if string
            // is empty then we can return default value.
            T result = default(T);
            if (!string.IsNullOrEmpty(value))
            {
                // we are not going to handle exception here
                // if you need SafeParse then you should create
                // another method specially for that.
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                result = (T)tc.ConvertFrom(value);
            }
            return result;
        }

    }
}
