// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="YUV.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Structure to define YUV.
    /// </summary>
    public struct YUV 
	{
        /// <summary>
        /// Gets an empty YUV structure.
        /// </summary>
        public static readonly YUV Empty = new YUV();

        #region Fields
        /// <summary>
        /// The y
        /// </summary>
        private double y;
        /// <summary>
        /// The u
        /// </summary>
        private double u;
        /// <summary>
        /// The v
        /// </summary>
        private double v;
        #endregion

        #region Operators
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(YUV item1, YUV item2)
		{
			return (
				item1.Y == item2.Y 
				&& item1.U == item2.U 
				&& item1.V == item2.V
				);
		}

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(YUV item1, YUV item2)
		{
			return (
				item1.Y != item2.Y 
				|| item1.U != item2.U 
				|| item1.V != item2.V
				);
		}

        #endregion

        #region Accessors
        /// <summary>
        /// Get and set Y
        /// </summary>
        /// <value>The y.</value>
        public double Y
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
        /// Get and set U
        /// </summary>
        /// <value>The u.</value>
        public double U
		{ 
			get
			{
				return u;
			} 
			set
			{ 
				u = value; 
				u = (u>0.436)? 0.436 : ((u<-0.436)? -0.436 : u); 
			} 
		}

        /// <summary>
        /// Get and set V
        /// </summary>
        /// <value>The v.</value>
        public double V
		{ 
			get
			{
				return v;
			} 
			set
			{ 
				v = value; 
				v = (v>0.615)? 0.615 : ((v<-0.615)? -0.615 : v); 
			} 
		}

        #endregion

        /// <summary>
        /// Creates an instance of a YUV structure.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        public YUV(double y, double u, double v) 
		{
			this.y = y;
			this.u = u;
			this.v = v;
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

			return (this == (YUV)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() 
		{
			return Y.GetHashCode() ^ U.GetHashCode() ^ V.GetHashCode();
		}

		#endregion
	} 
}
