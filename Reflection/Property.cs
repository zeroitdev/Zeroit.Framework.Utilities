// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Property.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;

namespace Zeroit.Framework.Utilities.Reflection
{
    /// <summary>
    /// Description of Property.
    /// </summary>
    public static partial class Property
	{

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="TargetObject">The target object.</param>
        /// <param name="Property">The property.</param>
        /// <param name="Value">The value.</param>
        private static void SetValue(object TargetObject,PropertyInfo Property,object Value)
		{
			Property.SetValue(TargetObject,Value,null);
		}

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="TargetObject">The target object.</param>
        /// <param name="Property">The property.</param>
        /// <returns>System.Object.</returns>
        private static object GetValue(object TargetObject,PropertyInfo Property)
		{
			return Property.GetValue(TargetObject,null);
		}

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        /// <param name="PropertyName">Name of the property.</param>
        /// <returns>PropertyInfo.</returns>
        private static PropertyInfo GetProperty(PropertyInfo[] Properties, string PropertyName)
        {
            for (int i = 0; i < Properties.Length; i++)
            {
                if (Properties[i].Name == PropertyName)
                    return Properties[i];
            }
            return null;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="TargetObject">The target object.</param>
        /// <param name="PropertyName">Name of the property.</param>
        /// <param name="Value">The value.</param>
        public static void SetValue(object TargetObject,string PropertyName,object Value)
		{
			if(PropertyName=="")
				return;
			PropertyInfo xInfo=GetProperty(TargetObject.GetType().GetProperties(),PropertyName);
			if(xInfo==null)
				return;
			SetValue(TargetObject,xInfo,Value);
		}

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="TargetObject">The target object.</param>
        /// <param name="PropertyName">Name of the property.</param>
        /// <returns>System.Object.</returns>
        public static object GetValue(object TargetObject,string PropertyName)
		{
			if(PropertyName=="")
				return null;
			PropertyInfo xInfo=GetProperty(TargetObject.GetType().GetProperties(),PropertyName);
			if(xInfo==null)
				return null;
			return GetValue(TargetObject,xInfo);
		}

		

    }
}
