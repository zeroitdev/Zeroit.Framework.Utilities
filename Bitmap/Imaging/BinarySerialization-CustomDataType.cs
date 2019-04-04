// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BinarySerialization-CustomDataType.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.BinarySerializationDeepCopy
{
    /// <summary>
    /// A class of Custom Data Types
    /// </summary>
    [Serializable]
    public class CustomDataType
    {
        private int intMember = 0;

        /// <summary>
        /// Integer Member
        /// </summary>
        public int IntMember
        {
            get { return intMember; }
            set { intMember = value; }
        }

        private string stringMember = String.Empty;

        /// <summary>
        /// String Member
        /// </summary>
        public string StringMember
        {
            get { return stringMember; }
            set { stringMember = value; }
        }

        private DateTime dateTimeMember = DateTime.MinValue;

        /// <summary>
        /// DateTime Member
        /// </summary>
        public DateTime DateTimeMember
        {
            get { return dateTimeMember; }
            set { dateTimeMember = value; }
        }

        /// <summary>
        /// To String
        /// </summary>
        public override string ToString()
        {
            return "IntMember: " + IntMember + ", DateTimeMember: " + DateTimeMember.ToString() + ", StringMember: " + stringMember;
        }
    }
}