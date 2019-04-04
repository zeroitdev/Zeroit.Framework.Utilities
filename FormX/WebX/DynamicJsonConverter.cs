// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="DynamicJsonConverter.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Collections;

namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Credit here goes to Drew Noakes;
    /// </summary>
    /// <seealso cref="System.Web.Script.Serialization.JavaScriptConverter" />
    sealed class DynamicJsonConverter : JavaScriptConverter
    {
        /// <summary>
        /// The instance
        /// </summary>
        static JavaScriptSerializer instance;

        /// <summary>
        /// Gets the instance of a JavaScriptSerializer using the DynamicJsonConverter.
        /// </summary>
        /// <value>The instance.</value>
        public static JavaScriptSerializer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaScriptSerializer();
                    instance.RegisterConverters(new[] { new DynamicJsonConverter() });
                }

                return instance;
            }
        }

        /// <summary>
        /// Deserializes the given dictionary.
        /// </summary>
        /// <param name="dictionary">The string object dictionary to use.</param>
        /// <param name="type">The type that is used as the target pattern.</param>
        /// <param name="serializer">The serializer instance.</param>
        /// <returns>The produced object.</returns>
        /// <exception cref="ArgumentNullException">dictionary</exception>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            return type == typeof(object) ? new DynamicJsonObject(dictionary) : null;
        }

        /// <summary>
        /// Serializes the given object to a list of key - value pairs.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="serializer">The serializer instance.</param>
        /// <returns>The produced key - value list.</returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var dic = new Dictionary<string, object>();
            var props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                dic.Add(prop.Name, prop.GetValue(obj, null));
            }

            return dic;
        }

        /// <summary>
        /// Gets the list of supported types. This list does only contain the object Object.
        /// </summary>
        /// <value>The supported types.</value>
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
        }

        #region Nested type: DynamicJsonObject

        /// <summary>
        /// Class DynamicJsonObject. This class cannot be inherited.
        /// </summary>
        /// <seealso cref="System.Dynamic.DynamicObject" />
        private sealed class DynamicJsonObject : DynamicObject
        {
            /// <summary>
            /// The dictionary
            /// </summary>
            readonly IDictionary<string, object> _dictionary;

            /// <summary>
            /// Initializes a new instance of the <see cref="DynamicJsonObject"/> class.
            /// </summary>
            /// <param name="dictionary">The dictionary.</param>
            /// <exception cref="ArgumentNullException">dictionary</exception>
            public DynamicJsonObject(IDictionary<string, object> dictionary)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");

                _dictionary = dictionary;
            }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
            {
                var sb = new StringBuilder("{");
                ToString(sb);
                return sb.ToString();
            }

            /// <summary>
            /// To the string.
            /// </summary>
            /// <param name="sb">The sb.</param>
            void ToString(StringBuilder sb)
            {
                var firstInDictionary = true;

                foreach (var pair in _dictionary)
                {
                    if (!firstInDictionary)
                        sb.Append(",");

                    firstInDictionary = false;
                    var value = pair.Value;
                    var name = pair.Key;

                    if (value is string)
                        sb.AppendFormat("{0}:\"{1}\"", name, value);
                    else if (value is IDictionary<string, object>)
                        new DynamicJsonObject((IDictionary<string, object>)value).ToString(sb);
                    else if (value is ArrayList)
                    {
                        sb.Append(name + ":[");
                        var firstInArray = true;

                        foreach (var arrayValue in value as ArrayList)
                        {
                            if (!firstInArray)
                                sb.Append(",");
                            firstInArray = false;

                            if (arrayValue is IDictionary<string, object>)
                                new DynamicJsonObject(arrayValue as IDictionary<string, object>).ToString(sb);
                            else if (arrayValue is string)
                                sb.AppendFormat("\"{0}\"", arrayValue);
                            else
                                sb.AppendFormat("{0}", arrayValue);

                        }

                        sb.Append("]");
                    }
                    else
                        sb.AppendFormat("{0}:{1}", name, value);
                }

                sb.Append("}");
            }

            /// <summary>
            /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as getting a value for a property.
            /// </summary>
            /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
            /// <param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result" />.</param>
            /// <returns>true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a run-time exception is thrown.)</returns>
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (!_dictionary.TryGetValue(binder.Name, out result))
                {
                    result = null;
                    return true;
                }

                var dictionary = result as IDictionary<string, object>;

                if (dictionary != null)
                {
                    result = new DynamicJsonObject(dictionary);
                    return true;
                }

                var arrayList = result as ArrayList;

                if (arrayList != null && arrayList.Count > 0)
                {
                    if (arrayList[0] is IDictionary<string, object>)
                        result = new List<object>(arrayList.Cast<IDictionary<string, object>>().Select(x => new DynamicJsonObject(x)));
                    else
                        result = new List<object>(arrayList.Cast<object>());
                }

                return true;
            }
        }

        #endregion
    }
}
