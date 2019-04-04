// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PolygonInputConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{

    #region Converter

    /// <summary>
    /// Class Converter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public class Converter : TypeConverter
    {

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        // This code allows the designer to generate the Shape constructor

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
                if (destinationType == typeof(string))
                {
                    // Display string in designer
                    return "(PolygonInput)";
                }

                else if (destinationType == typeof(InstanceDescriptor) && value is PolygonInput)
                {
                    PolygonInput polygonInput = (PolygonInput)value;

                    ConstructorInfo ctor = typeof(PolygonInput).GetConstructor(new Type[]
                    {


                        typeof(List<List<Point>>),
                        typeof(PolygonInput.FillModes),
                        typeof(PolygonInput.ShapeTypes)
                    });

                    if (ctor != null)
                    {
                        return new InstanceDescriptor(ctor, new object[] {


                            polygonInput.Points,
                            polygonInput.FillMode,
                            polygonInput.ShapeType 
                        });
                    }

                }
            
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }


    #endregion

}
