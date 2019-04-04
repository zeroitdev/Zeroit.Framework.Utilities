// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="CollectionFormatterRegistry.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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