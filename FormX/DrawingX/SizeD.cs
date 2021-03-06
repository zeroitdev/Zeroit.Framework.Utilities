﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SizeD.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.ComponentModel;

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// Struct SizeD
    /// </summary>
    public struct SizeD
    {
        /// <summary>
        /// The width
        /// </summary>
        double _width;
        /// <summary>
        /// The height
        /// </summary>
        double _height;

        /// <summary>
        /// Gets a Zeroit.Framework.Utilities.DrawHelper.SizeD structure that has a Zeroit.Framework.Utilities.DrawHelper.SizeD.Height and Zeroit.Framework.Utilities.DrawHelper.SizeD.Width value of 0.
        /// </summary>
        public static readonly SizeD Empty = new SizeD();

        /// <summary>
        /// Initializes a new instance of the Zeroit.Framework.Utilities.DrawHelper.SizeD structure from the specified Zeroit.Framework.Utilities.DrawHelper.PointD structure.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD structure from which to initialize this Zeroit.Framework.Utilities.DrawHelper.SizeD structure.</param>
        public SizeD(PointD pt)
        {
            _width = pt.X;
            _height = pt.Y;
        }

        /// <summary>
        /// Initializes a new instance of the Zeroit.Framework.Utilities.DrawHelper.SizeD structure from the specified dimensions.
        /// </summary>
        /// <param name="width">The width component of the new Zeroit.Framework.Utilities.DrawHelper.SizeD.</param>
        /// <param name="height">The height component of the new Zeroit.Framework.Utilities.DrawHelper.SizeD.</param>
        public SizeD(double width, double height)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Subtracts the width and height of one Zeroit.Framework.Utilities.DrawHelper.SizeD structure from
        /// the width and height of another Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <param name="sz1">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure on the left side of the subtraction operator.</param>
        /// <param name="sz2">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure on the right side of the subtraction operator.</param>
        /// <returns>A Zeroit.Framework.Utilities.DrawHelper.SizeD structure that is the result of the subtraction operation.</returns>
        public static SizeD operator -(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        /// <summary>
        /// Tests whether two Zeroit.Framework.Utilities.DrawHelper.SizeD structures are different.
        /// </summary>
        /// <param name="sz1">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure on the left of the inequality operator.</param>
        /// <param name="sz2">The Zeroit.Framework.Utilities.DrawHelper.SizDe structure on the right of the inequality operator.</param>
        /// <returns>true if sz1 and sz2 differ either in width or height; false if sz1 and sz2 are equal.</returns>
        public static bool operator !=(SizeD sz1, SizeD sz2)
        {
            if (sz1.Width == sz2.Width)
                return false;
            else if (sz1.Height == sz2.Height)
                return false;

            return true;
        }

        /// <summary>
        /// Adds the width and height of one Zeroit.Framework.Utilities.DrawHelper.SizeD structure to the width
        /// and height of another Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <param name="sz1">The first Zeroit.Framework.Utilities.DrawHelper.SizeD to add.</param>
        /// <param name="sz2">The second Zeroit.Framework.Utilities.DrawHelper.SizeD to add.</param>
        /// <returns>A Zeroit.Framework.Utilities.DrawHelper.SizeD structure that is the result of the addition operation.</returns>
        public static SizeD operator +(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        /// <summary>
        /// Tests whether two Zeroit.Framework.Utilities.DrawHelper.SizeD structures are equal.
        /// </summary>
        /// <param name="sz1">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure on the left side of the equality operator.</param>
        /// <param name="sz2">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure on the right of the equality operator.</param>
        /// <returns>true if sz1 and sz2 have equal width and height; otherwise, false.</returns>
        public static bool operator ==(SizeD sz1, SizeD sz2)
        {
            return !(sz1 != sz2);
        }

        /// <summary>
        /// Converts the specified Zeroit.Framework.Utilities.DrawHelper.SizeD structure to a System.Drawing.Point
        /// structure.
        /// </summary>
        /// <param name="size">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure to convert.</param>
        /// <returns>The Zeroit.Framework.Utilities.DrawHelper.PointD structure to which this operator converts.</returns>
        public static explicit operator PointD(SizeD size)
        {
            return new PointD(size.Width, size.Height);
        }

        /// <summary>
        /// Converts the specified Zeroit.Framework.Utilities.DrawHelper.SizeD structure to a System.Drawing.SizeF
        /// structure.
        /// </summary>
        /// <param name="p">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure to convert.</param>
        /// <returns>The System.Drawing.SizeF structure to which this operator converts.</returns>
        public static explicit operator SizeF(SizeD p)
        {
            return new SizeF((float)p.Width, (float)p.Height);
        }

        /// <summary>
        /// Gets or sets the vertical component of this Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <value>The height.</value>
        public double Height { get { return _height; } set { _height = value; } }

        /// <summary>
        /// Tests whether this Zeroit.Framework.Utilities.DrawHelper.SizeD structure has width and height of 0.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        /// <summary>
        /// Gets or sets the horizontal component of this Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <value>The width.</value>
        public double Width { get { return _width; } set { _width = value; } }

        /// <summary>
        /// Adds the width and height of one Zeroit.Framework.Utilities.DrawHelper.SizeD structure to the width and height of another Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <param name="sz1">The first Zeroit.Framework.Utilities.DrawHelper.SizeD structure to add.</param>
        /// <param name="sz2">The second Zeroit.Framework.Utilities.DrawHelper.SizeD structure to add.</param>
        /// <returns>A Zeroit.Framework.Utilities.DrawHelper.SizeD structure that is the result of the addition operation.</returns>
        public static SizeD Add(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        /// <summary>
        /// Converts the specified Zeroit.Framework.Utilities.DrawHelper.SizeD structure to a System.Drawing.Size
        /// structure by rounding the values of the Zeroit.Framework.Utilities.DrawHelper.SizeD structure to
        /// the next higher integer values.
        /// </summary>
        /// <param name="value">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure to convert.</param>
        /// <returns>The System.Drawing.Size structure this method converts to.</returns>
        public static Size Ceiling(SizeD value)
        {
            return new Size((int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height));
        }

        /// <summary>
        /// Tests to see whether the specified object is a Zeroit.Framework.Utilities.DrawHelper.SizeD structure
        /// with the same dimensions as this Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <param name="obj">The System.Object to test.</param>
        /// <returns>true if obj is a System.Drawing.Size and has the same width and height as this System.Drawing.Size; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SizeD)
            {
                return (SizeD)obj == this;
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this Zeroit.Framework.Utilities.DrawHelper.SizeD structure.</returns>
        public override int GetHashCode()
        {
            return (int)Width + (int)Height;
        }

        /// <summary>
        /// Converts the specified Zeroit.Framework.Utilities.DrawHelper.SizeD structure to a System.Drawing.Size
        /// structure by rounding the values of the Zeroit.Framework.Utilities.DrawHelper.SizeD structure to
        /// the nearest integer values.
        /// </summary>
        /// <param name="value">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure to convert.</param>
        /// <returns>The System.Drawing.Size structure this method converts to.</returns>
        public static Size Round(SizeD value)
        {
            return new Size((int)Math.Round(value.Width), (int)Math.Round(value.Height));
        }

        /// <summary>
        /// Subtracts the width and height of one Zeroit.Framework.Utilities.DrawHelper.SizeD structure from the width and height
        /// of another Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <param name="sz1">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure on the left side of the subtraction operator.</param>
        /// <param name="sz2">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure on the right side of the subtraction operator.</param>
        /// <returns>A Zeroit.Framework.Utilities.DrawHelper.SizeD structure that is a result of the subtraction operation.</returns>
        public static SizeD Subtract(SizeD sz1, SizeD sz2)
        {
            return new SizeD(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        /// <summary>
        /// Creates a human-readable string that represents this Zeroit.Framework.Utilities.DrawHelper.SizeD structure.
        /// </summary>
        /// <returns>A string that represents this Zeroit.Framework.Utilities.DrawHelper.SizeD.</returns>
        public override string ToString()
        {
            return ((SizeF)this).ToString();
        }

        /// <summary>
        /// Converts the specified Zeroit.Framework.Utilities.DrawHelper.SizeD structure to a System.Drawing.Size structure by
        /// truncating the values of the System.Drawing.SizeF structure to the next lower integer values.
        /// </summary>
        /// <param name="value">The Zeroit.Framework.Utilities.DrawHelper.SizeD structure to convert.</param>
        /// <returns>The System.Drawing.Size structure this method converts to.</returns>
        public static Size Truncate(SizeD value)
        {
            return new Size((int)Math.Truncate(value.Width), (int)Math.Truncate(value.Height));
        }
    }
}
