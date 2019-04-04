// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="CMYK.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Structure to define CMYK.
    /// </summary>
    public struct CMYK 
	{
        /// <summary>
        /// Gets an empty CMYK structure;
        /// </summary>
        public readonly static CMYK Empty = new CMYK();

        #region Fields
        /// <summary>
        /// The c
        /// </summary>
        private double c;
        /// <summary>
        /// The m
        /// </summary>
        private double m;
        /// <summary>
        /// The y
        /// </summary>
        private double y;
        /// <summary>
        /// The k
        /// </summary>
        private double k;
        #endregion

        #region Operators
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CMYK item1, CMYK item2)
		{
			return (
				item1.Cyan == item2.Cyan 
				&& item1.Magenta == item2.Magenta 
				&& item1.Yellow == item2.Yellow
				&& item1.Black == item2.Black
				);
		}

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CMYK item1, CMYK item2)
		{
			return (
				item1.Cyan != item2.Cyan 
				|| item1.Magenta != item2.Magenta 
				|| item1.Yellow != item2.Yellow
				|| item1.Black != item2.Black
				);
		}


        #endregion

        #region Accessors
        /// <summary>
        /// Gets or sets the cyan.
        /// </summary>
        /// <value>The cyan.</value>
        public double Cyan
		{ 
			get
			{
				return c;
			} 
			set
			{ 
				c = value; 
				c = (c>1)? 1 : ((c<0)? 0 : c); 
			} 
		}

        /// <summary>
        /// Gets or sets the magenta.
        /// </summary>
        /// <value>The magenta.</value>
        public double Magenta
		{ 
			get
			{
				return m;
			} 
			set
			{ 
				m = value; 
				m = (m>1)? 1 : ((m<0)? 0 : m); 
			} 
		}

        /// <summary>
        /// Gets or sets the yellow.
        /// </summary>
        /// <value>The yellow.</value>
        public double Yellow
		{ 
			get
			{
				return y;
			} 
			set
			{ 
				y = value; 
				y = (y>1)? 1 : ((y<0)? 0 : y); 
			} 
		}

        /// <summary>
        /// Gets or sets the black.
        /// </summary>
        /// <value>The black.</value>
        public double Black 
		{ 
			get
			{
				return k;
			} 
			set
			{ 
				k = value; 
				k = (k>1)? 1 : ((k<0)? 0 : k); 
			} 
		}
        #endregion

        /// <summary>
        /// Creates an instance of a CMYK structure.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="m">The m.</param>
        /// <param name="y">The y.</param>
        /// <param name="k">The k.</param>
        public CMYK(double c, double m, double y, double k) 
		{
			this.c = c;
			this.m = m;
			this.y = y;
			this.k = k;
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

			return (this == (CMYK)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() 
		{
			return Cyan.GetHashCode() ^ Magenta.GetHashCode() ^ Yellow.GetHashCode() ^ Black.GetHashCode();
		}

		#endregion
	} 
}
