// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="InjectObjectProperties.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //var sourceObject = new { simpleString = "string", integer = 3, Date = new DateTime(2013, 08, 19) };

        //Debug.WriteLine("Gettings property by name : '{0:simpleString}' event cast insensitive : {0:date}".Inject(sourceObject));

        //Debug.WriteLine("The property can be formatted by appending standard String.Format syntax after the property name like this {0:date:yyyy-MM-dd}".Inject(sourceObject));

        //Debug.WriteLine("Use culture info to format the value to a specific culture '{0:date:dddd}'".Inject(CultureInfo.GetCultureInfo("da-DK"), sourceObject));

        //Debug.WriteLine("Inject more values and event build in types {0:integer} {1} with build in properties {1:length}".Inject(sourceObject, "simple string"));

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Supplements String.Format by letting you get properties from objects.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>System.String.</returns>
        public static string Inject(this string source, IFormatProvider formatProvider, params object[] args)
        {
            var objectWrappers = new object[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                objectWrappers[i] = new ObjectWrapper(args[i]);
            }

            return string.Format(formatProvider, source, objectWrappers);
        }

        /// <summary>
        /// Supplements String.Format by letting you get properties from objects .
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>System.String.</returns>
        public static string Inject(this string source, params object[] args)
        {
            return Inject(source, CultureInfo.CurrentUICulture, args);
        }

        /// <summary>
        /// Class ObjectWrapper.
        /// </summary>
        /// <seealso cref="System.IFormattable" />
        private class ObjectWrapper : IFormattable
        {
            /// <summary>
            /// The wrapped
            /// </summary>
            private readonly object wrapped;
            /// <summary>
            /// The cache
            /// </summary>
            private static readonly Dictionary<string, FormatInfo> Cache = new Dictionary<string, FormatInfo>();

            /// <summary>
            /// Initializes a new instance of the <see cref="ObjectWrapper"/> class.
            /// </summary>
            /// <param name="wrapped">The wrapped.</param>
            public ObjectWrapper(object wrapped)
            {
                this.wrapped = wrapped;
            }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <param name="format">The format to use.-or- A null reference (Nothing in Visual Basic) to use the default format defined for the type of the <see cref="T:System.IFormattable" /> implementation.</param>
            /// <param name="formatProvider">The provider to use to format the value.-or- A null reference (Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system.</param>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public string ToString(string format, IFormatProvider formatProvider)
            {
                if (string.IsNullOrEmpty(format))
                {
                    return this.wrapped.ToString();
                }

                var type = this.wrapped.GetType();
                var key = type.FullName + ":" + format;

                FormatInfo wrapperCache;
                lock (Cache)
                {
                    if (!Cache.TryGetValue(key, out wrapperCache))
                    {
                        wrapperCache = CreateFormatInfo(format, type);
                        Cache.Add(key, wrapperCache);
                    }
                }

                var propertyInfo = wrapperCache.PropertyInfo;
                var outputFormat = wrapperCache.OutputFormat;

                var value = propertyInfo != null ? propertyInfo.GetValue(this.wrapped) : this.wrapped;

                return string.Format(formatProvider, outputFormat, value);
            }

            /// <summary>
            /// Creates the format information.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <param name="type">The type.</param>
            /// <returns>FormatInfo.</returns>
            private static FormatInfo CreateFormatInfo(string format, IReflect type)
            {
                var spilt = format.Split(new[] { ':' }, 2);
                var param = spilt[0];
                var hasSubFormat = spilt.Length == 2;
                var subFormat = hasSubFormat ? spilt[1] : string.Empty;

                var propertyInfo = type.GetProperty(param, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                var outputFormat = propertyInfo != null ? (hasSubFormat ? "{0:" + subFormat + "}" : "{0}") : "{0:" + format + "}";

                return new FormatInfo(propertyInfo, outputFormat);
            }

            /// <summary>
            /// Class FormatInfo.
            /// </summary>
            private class FormatInfo
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="FormatInfo"/> class.
                /// </summary>
                /// <param name="propertyInfo">The property information.</param>
                /// <param name="form">The form.</param>
                public FormatInfo(PropertyInfo propertyInfo, string form)
                {
                    this.PropertyInfo = propertyInfo;
                    this.OutputFormat = form;
                }

                /// <summary>
                /// Gets or sets the property information.
                /// </summary>
                /// <value>The property information.</value>
                public PropertyInfo PropertyInfo { get; private set; }

                /// <summary>
                /// Gets or sets the output format.
                /// </summary>
                /// <value>The output format.</value>
                public string OutputFormat { get; private set; }
            }
        }

    }
}
