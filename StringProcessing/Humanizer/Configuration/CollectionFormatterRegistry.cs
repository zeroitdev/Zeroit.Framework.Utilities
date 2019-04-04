// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="CollectionFormatterRegistry.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.CollectionFormatters;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration
{
    /// <summary>
    /// Class CollectionFormatterRegistry.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration.LocaliserRegistry{Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation.CollectionFormatters.ICollectionFormatter}" />
    internal class CollectionFormatterRegistry : LocaliserRegistry<ICollectionFormatter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionFormatterRegistry"/> class.
        /// </summary>
        public CollectionFormatterRegistry()
            : base(new DefaultCollectionFormatter("&"))
        {
            Register("en", new OxfordStyleCollectionFormatter("and"));
            Register("it", new DefaultCollectionFormatter("e"));
            Register("de", new DefaultCollectionFormatter("und"));
            Register("dk", new DefaultCollectionFormatter("og"));
            Register("nl", new DefaultCollectionFormatter("en"));
            Register("pt", new DefaultCollectionFormatter("e"));
            Register("ro", new DefaultCollectionFormatter("și"));
            Register("nn", new DefaultCollectionFormatter("og"));
            Register("nb", new DefaultCollectionFormatter("og"));
            Register("sv", new DefaultCollectionFormatter("och"));
        }
    }
}