﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BinarySerialization-CustomDataType.cs" company="Zeroit Dev Technologies">
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