// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="HSL.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Structure to define HSL.
    /// </summary>
    public struct HSL
	{
        /// <summary>
        /// Gets an empty HSL structure;
        /// </summary>
        public static readonly HSL Empty = new HSL();

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
        /// The luminance
        /// </summary>
        private double luminance;
        #endregion

        #region Operators
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(HSL item1, HSL item2)
		{
			return (
				item1.Hue == item2.Hue 
				&& item1.Saturation == item2.Saturation 
				&& item1.Luminance == item2.Luminance
				);
		}

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(HSL item1, HSL item2)
		{
			return (
				item1.Hue != item2.Hue 
				|| item1.Saturation != item2.Saturation 
				|| item1.Luminance != item2.Luminance
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
        /// Gets or sets the luminance component.
        /// </summary>
        /// <value>The luminance.</value>
        [Description("Luminance component"),]
		public double Luminance 
		{ 
			get
			{
				return luminance;
			} 
			set
			{ 
				luminance = (value>1)? 1 : ((value<0)? 0 : value); 
			} 
		}

        #endregion

        /// <summary>
        /// Creates an instance of a HSL structure.
        /// </summary>
        /// <param name="h">Hue value.</param>
        /// <param name="s">Saturation value.</param>
        /// <param name="l">Lightness value.</param>
        public HSL(double h, double s, double l) 
		{
			hue = (h>360)? 360 : ((h<0)?0:h); 
			saturation = (s>1)? 1 : ((s<0)?0:s);
			luminance = (l>1)? 1 : ((l<0)?0:l);
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

			return (this == (HSL)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() 
		{
			return Hue.GetHashCode() ^ Saturation.GetHashCode() ^ Luminance.GetHashCode();
		}

		#endregion
	}
}
