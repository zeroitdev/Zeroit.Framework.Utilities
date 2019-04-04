// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CIELab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Structure to define CIE L*a*b*.
    /// </summary>
    public struct CIELab
	{
        /// <summary>
        /// Gets an empty CIELab structure.
        /// </summary>
        public static readonly CIELab Empty = new CIELab();

        #region Fields
        /// <summary>
        /// The l
        /// </summary>
        private double l;
        /// <summary>
        /// a
        /// </summary>
        private double a;
        /// <summary>
        /// The b
        /// </summary>
        private double b;

        #endregion

        #region Operators
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CIELab item1, CIELab item2)
		{
			return (
				item1.L == item2.L 
				&& item1.A == item2.A 
				&& item1.B == item2.B
				);
		}

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CIELab item1, CIELab item2)
		{
			return (
				item1.L != item2.L 
				|| item1.A != item2.A 
				|| item1.B != item2.B
				);
		}

        #endregion

        #region Accessors
        /// <summary>
        /// Gets or sets L component.
        /// </summary>
        /// <value>The l.</value>
        public double L
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

        /// <summary>
        /// Gets or sets a component.
        /// </summary>
        /// <value>a.</value>
        public double A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

        /// <summary>
        /// Gets or sets a component.
        /// </summary>
        /// <value>The b.</value>
        public double B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CIELab"/> struct.
        /// </summary>
        /// <param name="l">The l.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        public CIELab(double l, double a, double b) 
		{
			this.l = l;
			this.a = a;
			this.b = b;
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

			return (this == (CIELab)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() 
		{
			return L.GetHashCode() ^ a.GetHashCode() ^ b.GetHashCode();
		}

		#endregion
	} 
}
