﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="Resources.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation
{
    /// <summary>
    /// Provides access to the resources of Humanizer
    /// </summary>
    public static class Resources
    {
        /// <summary>
        /// The resource manager
        /// </summary>
        static readonly ResourceManager ResourceManager = new ResourceManager("Zeroit.Framework.Utilities.StringProcessing.HumanizerProperties.Resources", typeof(Resources).GetTypeInfo().Assembly);

        /// <summary>
        /// Returns the value of the specified string resource
        /// </summary>
        /// <param name="resourceKey">The name of the resource to retrieve.</param>
        /// <param name="culture">The culture of the resource to retrieve. If not specified, current thread's UI culture is used.</param>
        /// <returns>The value of the resource localized for the specified culture.</returns>
        public static string GetResource(string resourceKey, CultureInfo culture = null)
        {
            return ResourceManager.GetString(resourceKey, culture);
        }
    }
}