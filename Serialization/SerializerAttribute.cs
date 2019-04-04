// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SerializerAttribute.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.Serialization
{
    /// <summary>
    /// Class SerializerAttribute.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage( AttributeTargets.Class)]
    public class SerializerAttribute :   Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializerAttribute"/> class.
        /// </summary>
        public SerializerAttribute()
        {
            
        }
    }
}
