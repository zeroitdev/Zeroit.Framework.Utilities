// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="In.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Class In.
    /// </summary>
    public partial class In
    {
        /// <summary>
        /// Returns the first of January of the provided year
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>DateTime.</returns>
        public static DateTime TheYear(int year)
        {
            return new DateTime(year, 1, 1);
        }
    }
}
