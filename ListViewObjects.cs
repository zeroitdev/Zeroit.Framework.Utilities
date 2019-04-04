// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ListViewObjects.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// A class collection for list view objects
    /// </summary>
    public class ListViewObjects
    {
        /// <summary>
        /// The type
        /// </summary>
        public string type = "Not Set";
        /// <summary>
        /// The datetime value
        /// </summary>
        public DateTime datetimeValue = DateTime.Now;
        /// <summary>
        /// The distance
        /// </summary>
        public int distance = 0;

        /// <summary>
        /// Override To String
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            string returnValue = type.PadRight(7) + "\t\t";
            returnValue += datetimeValue.ToString("yyyy/MM/dd HH:mm:ss") + "\t";
            returnValue += distance.ToString();

            return returnValue;
        }
    }
}
