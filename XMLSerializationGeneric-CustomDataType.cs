// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="XMLSerializationGeneric-CustomDataType.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;

namespace Zeroit.Framework.Utilities.XML
{
    /// <summary>
    /// A class collection for XML Serialization
    /// </summary>
    public class XMLSerializationGenericCustomDataType
    {
        /// <summary>
        /// The int member
        /// </summary>
        private int intMember = 0;

        /// <summary>
        /// Property for Integer member
        /// </summary>
        /// <value>The int member.</value>
        public int IntMember
        {
            get { return intMember; }
            set { intMember = value; }
        }

        /// <summary>
        /// The string member
        /// </summary>
        private string stringMember = String.Empty;

        /// <summary>
        /// Property for String member
        /// </summary>
        /// <value>The string member.</value>
        public string StringMember
        {
            get { return stringMember; }
            set { stringMember = value; }
        }

        /// <summary>
        /// The date time member
        /// </summary>
        private DateTime dateTimeMember = DateTime.MinValue;

        /// <summary>
        /// Property for DateTime member
        /// </summary>
        /// <value>The date time member.</value>
        public DateTime DateTimeMember
        {
            get { return dateTimeMember; }
            set { dateTimeMember = value; }
        }
    }
}
