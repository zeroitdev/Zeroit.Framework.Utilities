// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EnumHumanizeExtensions.cs" company="Zeroit Dev Technologies">
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
using System.Linq;
using System.Reflection;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerConfiguration;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Contains extension methods for humanizing Enums
    /// </summary>
    public static class EnumHumanizeExtensions
    {
        /// <summary>
        /// The display attribute type name
        /// </summary>
        private const string DisplayAttributeTypeName = "System.ComponentModel.DataAnnotations.DisplayAttribute";
        /// <summary>
        /// The display attribute get description method name
        /// </summary>
        private const string DisplayAttributeGetDescriptionMethodName = "GetDescription";
        /// <summary>
        /// The display attribute get name method name
        /// </summary>
        private const string DisplayAttributeGetNameMethodName = "GetName";

        /// <summary>
        /// The string typed property
        /// </summary>
        private static readonly Func<PropertyInfo, bool> StringTypedProperty = p => p.PropertyType == typeof(string);

        /// <summary>
        /// Turns an enum member into a human readable string; e.g. AnonymousUser -&gt; Anonymous user. It also honors DescriptionAttribute data annotation
        /// </summary>
        /// <param name="input">The enum member to be humanized</param>
        /// <returns>System.String.</returns>
        public static string Humanize(this Enum input)
        {
            var enumType = input.GetType();
            var enumTypeInfo = enumType.GetTypeInfo();

            if (IsBitFieldEnum(enumTypeInfo) && !Enum.IsDefined(enumType, input))
            {
                return Enum.GetValues(enumType)
                           .Cast<Enum>()
                           .Where(e => e.CompareTo(Convert.ChangeType(Enum.ToObject(enumType, 0), enumType)) != 0)
                           .Where(input.HasFlag)
                           .Select(e => e.Humanize())
                           .Humanize();
            }

            var caseName = input.ToString();
            var memInfo = enumTypeInfo.GetDeclaredField(caseName);

            if (memInfo != null)
            {
                var customDescription = GetCustomDescription(memInfo);

                if (customDescription != null)
                    return customDescription;
            }

            return caseName.Humanize();
        }

        /// <summary>
        /// Checks whether the given enum is to be used as a bit field type.
        /// </summary>
        /// <param name="typeInfo">The type information.</param>
        /// <returns>True if the given enum is a bit field enum, false otherwise.</returns>
        private static bool IsBitFieldEnum(TypeInfo typeInfo)
        {
            return typeInfo.GetCustomAttribute(typeof(FlagsAttribute)) != null;
        }

        // I had to add this method because PCL doesn't have DescriptionAttribute & I didn't want two versions of the code & thus the reflection
        /// <summary>
        /// Gets the custom description.
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        /// <returns>System.String.</returns>
        private static string GetCustomDescription(MemberInfo memberInfo)
        {
            var attrs = memberInfo.GetCustomAttributes(true);

            foreach (var attr in attrs)
            {
                var attrType = attr.GetType();
                if (attrType.FullName == DisplayAttributeTypeName)
                {
                    var methodGetDescription = attrType.GetRuntimeMethod(DisplayAttributeGetDescriptionMethodName, new Type[0]);
                    if (methodGetDescription != null)
                    {
                        var executedMethod = methodGetDescription.Invoke(attr, new object[0]);
                        if (executedMethod != null) return executedMethod.ToString();
                    }
                    var methodGetName = attrType.GetRuntimeMethod(DisplayAttributeGetNameMethodName, new Type[0]);
                    if (methodGetName != null)
                    {
                        var executedMethod = methodGetName.Invoke(attr, new object[0]);
                        if (executedMethod != null) return executedMethod.ToString();
                    }
                    return null;
                }

                var descriptionProperty =
                    attrType.GetRuntimeProperties()
                        .Where(StringTypedProperty)
                        .FirstOrDefault(Configurator.EnumDescriptionPropertyLocator);
                if (descriptionProperty != null)
                    return descriptionProperty.GetValue(attr, null).ToString();
            }

            return null;
        }

        /// <summary>
        /// Turns an enum member into a human readable string with the provided casing; e.g. AnonymousUser with Title casing -&gt; Anonymous User. It also honors DescriptionAttribute data annotation
        /// </summary>
        /// <param name="input">The enum member to be humanized</param>
        /// <param name="casing">The casing to use for humanizing the enum member</param>
        /// <returns>System.String.</returns>
        public static string Humanize(this Enum input, LetterCasing casing)
        {
            var humanizedEnum = Humanize(input);

            return humanizedEnum.ApplyCase(casing);
        }
    }
}
