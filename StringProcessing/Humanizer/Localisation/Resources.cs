// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="Resources.cs" company="Zeroit Dev Technologies">
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
