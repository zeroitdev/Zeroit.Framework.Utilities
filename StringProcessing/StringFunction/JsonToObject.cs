// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="JsonToObject.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Script.Serialization;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //Person per = jsonString.ConvertJsonStringToObject<Person>();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Converts the json string to object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringToDeserialize">The string to deserialize.</param>
        /// <returns>T.</returns>
        public static T ConvertJsonStringToObject<T>(this string stringToDeserialize)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(stringToDeserialize);
        }

    }
}
