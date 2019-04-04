// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EnumHelper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Zeroit.Framework.Utilities.EnumHelper
{
    /// <summary>
    /// Class EnumExtender.
    /// </summary>
    public static class EnumExtender
    {
        //------------------------Enum should be decorated with FlagsAttribute as below---------------------//
        //
        //[Flags]
        //public enum EnumExample
        //{
        //    ValueA = 1,
        //    ValueB = 2,
        //    ValueC = 4,
        //    ValueD = 8,
        //    Combi = ValueA | ValueB
        //}
        //
        //------------------------Enum should be decorated with FlagsAttribute as below---------------------//


        /// <summary>
        /// Gets all items for an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }

        /// <summary>
        /// Gets all items for an enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> GetAllItems<T>() where T : struct
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }

        /// <summary>
        /// Gets all selected items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value)
        {
            int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);

            foreach (object item in Enum.GetValues(typeof(T)))
            {
                int itemAsInt = Convert.ToInt32(item, CultureInfo.InvariantCulture);

                if (itemAsInt == (valueAsInt & itemAsInt))
                {
                    yield return (T)item;
                }
            }
        }

        /// <summary>
        /// Determines whether [contains] [the specified request].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if [contains] [the specified request]; otherwise, <c>false</c>.</returns>
        public static bool Contains<T>(this Enum value, T request)
        {
            int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);
            int requestAsInt = Convert.ToInt32(request, CultureInfo.InvariantCulture);

            if (requestAsInt == (valueAsInt & requestAsInt))
            {
                return true;
            }

            return false;
        }

        //---------------------------------If GetValues does not work in your dotnet framework use the code below ---------------------------//
        //public List<Enum> GetValues(Enum enumeration)
        //{
        //    List<Enum> enumerations = new List<Enum>();
        //    foreach (FieldInfo fieldInfo in enumeration.GetType().GetFields(
        //        BindingFlags.Static | BindingFlags.Public))
        //    {
        //        enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
        //    }
        //    return enumerations;
        //}
        //---------------------------------If GetValues does not work in your dotnet framework use the code below ---------------------------//


        /// <summary>
        /// Determines whether [has] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [has] [the specified value]; otherwise, <c>false</c>.</returns>
        public static bool Has<T>(this System.Enum type, T value)
        {
            try
            {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            }
            catch
            {
                return false;
            }
        }

        //checks if the value is only the provided type
        /// <summary>
        /// Determines whether [is] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is] [the specified value]; otherwise, <c>false</c>.</returns>
        public static bool Is<T>(this System.Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        //appends a value
        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static T Add<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type | (int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                    ), ex);
            }
        }

        //completely removes the value
        /// <summary>
        /// Removes the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static T Remove<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type & ~(int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name
                    ), ex);
            }
        }

    }

    /// <summary>
    /// Where GetValues does not work.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T[].</returns>
        /// <exception cref="ArgumentException">Type '" + enumType.Name + "' is not an enum</exception>
        public static T[] GetValues<T>()
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type '" + enumType.Name + "' is not an enum");
            }

            List<T> values = new List<T>();

            var fields = from field in enumType.GetFields()
                         where field.IsLiteral
                         select field;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(enumType);
                values.Add((T)value);
            }

            return values.ToArray();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>System.Object[].</returns>
        /// <exception cref="ArgumentException">Type '" + enumType.Name + "' is not an enum</exception>
        public static object[] GetValues(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type '" + enumType.Name + "' is not an enum");
            }

            List<object> values = new List<object>();

            var fields = from field in enumType.GetFields()
                         where field.IsLiteral
                         select field;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(enumType);
                values.Add(value);
            }

            return values.ToArray();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>List&lt;Enum&gt;.</returns>
        public static List<Enum> GetValues(Enum enumeration)
        {
            List<Enum> enumerations = new List<Enum>();
            foreach (FieldInfo fieldInfo in enumeration.GetType().GetFields(
                BindingFlags.Static | BindingFlags.Public))
            {
                enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
            }
            return enumerations;
        }

        /// <summary>
        /// Gets all items for an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
