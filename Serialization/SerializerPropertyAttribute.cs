// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SerializerPropertyAttribute.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.Serialization
{
    /// <summary>
    /// Class SerializerPropertyAttribute.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class SerializerPropertyAttribute :  Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializerPropertyAttribute"/> class.
        /// </summary>
        public SerializerPropertyAttribute()
        {
            
        }
    }
}
