// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="RGB.cs" company="Zeroit Dev Technologies">
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
    /// Structure to define RGB.
    /// </summary>
    public struct RGB
	{
        /// <summary>
        /// Gets an empty RGB structure;
        /// </summary>
        public static readonly RGB Empty = new RGB();

        #region Fields
        /// <summary>
        /// The red
        /// </summary>
        private int red;
        /// <summary>
        /// The green
        /// </summary>
        private int green;
        /// <summary>
        /// The blue
        /// </summary>
        private int blue;

        #endregion

        #region Operators
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(RGB item1, RGB item2)
		{
			return (
				item1.Red == item2.Red 
				&& item1.Green == item2.Green 
				&& item1.Blue == item2.Blue
				);
		}

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(RGB item1, RGB item2)
		{
			return (
				item1.Red != item2.Red 
				|| item1.Green != item2.Green 
				|| item1.Blue != item2.Blue
				);
		}

        #endregion

        #region Accessors
        /// <summary>
        /// Gets or sets the red.
        /// </summary>
        /// <value>The red.</value>
        [Description("Red component."),]
		public int Red
		{
			get
			{
				return red;
			}
			set
			{
				red = (value>255)? 255 : ((value<0)?0 : value);
			}
		}

        /// <summary>
        /// Gets or sets the green.
        /// </summary>
        /// <value>The green.</value>
        [Description("Green component."),]
		public int Green
		{
			get
			{
				return green;
			}
			set
			{
				green = (value>255)? 255 : ((value<0)?0 : value);
			}
		}

        /// <summary>
        /// Gets or sets the blue.
        /// </summary>
        /// <value>The blue.</value>
        [Description("Blue component."),]
		public int Blue
		{
			get
			{
				return blue;
			}
			set
			{
				blue = (value>255)? 255 : ((value<0)?0 : value);
			}
		}
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RGB"/> struct.
        /// </summary>
        /// <param name="R">The r.</param>
        /// <param name="G">The g.</param>
        /// <param name="B">The b.</param>
        public RGB(int R, int G, int B) 
		{
			red = (R>255)? 255 : ((R<0)?0 : R);
			green = (G>255)? 255 : ((G<0)?0 : G);
			blue = (B>255)? 255 : ((B<0)?0 : B);
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

			return (this == (RGB)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() 
		{
			return Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode();
		}

		#endregion
	} 
}
