// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CIEXYZ.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Structure to define CIE XYZ.
    /// </summary>
    public struct CIEXYZ
	{
        /// <summary>
        /// Gets an empty CIEXYZ structure.
        /// </summary>
        public static readonly CIEXYZ Empty = new CIEXYZ();
        /// <summary>
        /// Gets the CIE D65 (white) structure.
        /// </summary>
        public static readonly CIEXYZ D65 = new CIEXYZ(0.9505, 1.0, 1.0890);

        #region Fields
        /// <summary>
        /// The x
        /// </summary>
        private double x;
        /// <summary>
        /// The y
        /// </summary>
        private double y;
        /// <summary>
        /// The z
        /// </summary>
        private double z;

        #endregion

        #region Operators
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CIEXYZ item1, CIEXYZ item2)
		{
			return (
				item1.X == item2.X 
				&& item1.Y == item2.Y 
				&& item1.Z == item2.Z
				);
		}

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CIEXYZ item1, CIEXYZ item2)
		{
			return (
				item1.X != item2.X 
				|| item1.Y != item2.Y 
				|| item1.Z != item2.Z
				);
		}

        #endregion

        #region Accessors
        /// <summary>
        /// Gets or sets X component.
        /// </summary>
        /// <value>The x.</value>
        public double X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = (value>0.9505)? 0.9505 : ((value<0)? 0 : value);
			}
		}

        /// <summary>
        /// Gets or sets Y component.
        /// </summary>
        /// <value>The y.</value>
        public double Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = (value>1.0)? 1.0 : ((value<0)?0 : value);
			}
		}

        /// <summary>
        /// Gets or sets Z component.
        /// </summary>
        /// <value>The z.</value>
        public double Z
		{
			get
			{
				return this.z;
			}
			set
			{
				this.z = (value>1.089)? 1.089 : ((value<0)? 0 : value);
			}
		}

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CIEXYZ"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public CIEXYZ(double x, double y, double z) 
		{
			this.x = (x>0.9505)? 0.9505 : ((x<0)? 0 : x);
			this.y = (y>1.0)? 1.0 : ((y<0)? 0 : y);
			this.z = (z>1.089)? 1.089 : ((z<0)? 0 : z);
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

			return (this == (CIEXYZ)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() 
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
		}

		#endregion
	} 
}
