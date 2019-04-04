// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="HSB.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Structure to define HSB.
    /// </summary>
    public struct HSB
	{
        /// <summary>
        /// Gets an empty HSB structure;
        /// </summary>
        public static readonly HSB Empty = new HSB();

        #region Fields
        /// <summary>
        /// The hue
        /// </summary>
        private double hue;
        /// <summary>
        /// The saturation
        /// </summary>
        private double saturation;
        /// <summary>
        /// The brightness
        /// </summary>
        private double brightness;
        #endregion

        #region Operators
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(HSB item1, HSB item2)
		{
			return (
				item1.Hue == item2.Hue 
				&& item1.Saturation == item2.Saturation 
				&& item1.Brightness == item2.Brightness
				);
		}

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(HSB item1, HSB item2)
		{
			return (
				item1.Hue != item2.Hue 
				|| item1.Saturation != item2.Saturation 
				|| item1.Brightness != item2.Brightness
				);
		}

        #endregion

        #region Accessors
        /// <summary>
        /// Gets or sets the hue component.
        /// </summary>
        /// <value>The hue.</value>
        [Description("Hue component"),]
		public double Hue 
		{ 
			get
			{
				return hue;
			} 
			set
			{ 
				hue = (value>360)? 360 : ((value<0)?0:value); 
			} 
		}

        /// <summary>
        /// Gets or sets saturation component.
        /// </summary>
        /// <value>The saturation.</value>
        [Description("Saturation component"),]
		public double Saturation 
		{ 
			get
			{
				return saturation;
			} 
			set
			{ 
				saturation = (value>1)? 1 : ((value<0)?0:value); 
			} 
		}

        /// <summary>
        /// Gets or sets the brightness component.
        /// </summary>
        /// <value>The brightness.</value>
        [Description("Brightness component"),]
		public double Brightness 
		{ 
			get
			{
				return brightness;
			} 
			set
			{ 
				brightness = (value>1)? 1 : ((value<0)? 0 : value); 
			} 
		}
        #endregion

        /// <summary>
        /// Creates an instance of a HSB structure.
        /// </summary>
        /// <param name="h">Hue value.</param>
        /// <param name="s">Saturation value.</param>
        /// <param name="b">Brightness value.</param>
        public HSB(double h, double s, double b) 
		{
			hue = (h>360)? 360 : ((h<0)?0:h); 
			saturation = (s>1)? 1 : ((s<0)?0:s);
			brightness = (b>1)? 1 : ((b<0)?0:b);
		}

        #region Methods
        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(Object obj) 
		{
			if(obj==null || GetType()!=obj.GetType()) return false;

			return (this == (HSB)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() 
		{
			return Hue.GetHashCode() ^ Saturation.GetHashCode() ^ Brightness.GetHashCode();
		}

		#endregion
	}
}
