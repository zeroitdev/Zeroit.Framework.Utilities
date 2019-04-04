// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PointD.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.ComponentModel;

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// Struct PointD
    /// </summary>
    public struct PointD
    {
        /// <summary>
        /// The x
        /// </summary>
        double _x;
        /// <summary>
        /// The y
        /// </summary>
        double _y;

        /// <summary>
        /// Represents a new instance of the Zeroit.Framework.Utilities.DrawHelper.PointD class with member data left uninitialized.
        /// </summary>
        public static readonly PointD Empty = new PointD();

        /// <summary>
        /// Initializes a new instance of the System.Drawing.PointF class with the specified coordinates.
        /// </summary>
        /// <param name="x">The horizontal position of the point.</param>
        /// <param name="y">The vertical position of the point.</param>
        public PointD(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Translates a Zeroit.Framework.Utilities.DrawHelper.PointD by the negative of a given System.Drawing.Size.
        /// </summary>
        /// <param name="pt">A Zeroit.Framework.Utilities.DrawHelper.PointD to compare.</param>
        /// <param name="sz">A Zeroit.Framework.Utilities.DrawHelper.PointD to compare.</param>
        /// <returns>The translated Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public static PointD operator -(PointD pt, Size sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Translates a Zeroit.Framework.Utilities.DrawHelper.PointD by the negative of a specified Zeroit.Framework.Utilities.DrawHelper.SizeD.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD to translate.</param>
        /// <param name="sz">The Zeroit.Framework.Utilities.DrawHelper.SizeD that specifies the numbers to subtract from the coordinates of pt.</param>
        /// <returns>The translated Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public static PointD operator -(PointD pt, SizeD sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Determines whether the coordinates of the specified points are not equal.
        /// </summary>
        /// <param name="left">A Zeroit.Framework.Utilities.DrawHelper.PointD to compare.</param>
        /// <param name="right">A Zeroit.Framework.Utilities.DrawHelper.PointD to compare.</param>
        /// <returns>true to indicate the Zeroit.Framework.Utilities.DrawHelper.PointD.X and Zeroit.Framework.Utilities.DrawHelper.PointD.Y
        /// values of left and right are not equal; otherwise, false.</returns>
        public static bool operator !=(PointD left, PointD right)
        {
            if (left.Y == right.Y)
                return false;
            else if (left.X == right.X)
                return false;

            return true;
        }

        /// <summary>
        /// Translates a Zeroit.Framework.Utilities.DrawHelper.PointD by a given System.Drawing.Size.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD to translate.</param>
        /// <param name="sz">A System.Drawing.Size that specifies the pair of numbers to add
        /// to the coordinates of pt</param>
        /// <returns>Returns the translated Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public static PointD operator +(PointD pt, Size sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Translates the Zeroit.Framework.Utilities.DrawHelper.PointD by the specified Zeroit.Framework.Utilities.DrawHelper.SizeD.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD to translate.</param>
        /// <param name="sz">The Zeroit.Framework.Utilities.DrawHelper.SizeD that specifies the numbers to add to the x- and
        /// y-coordinates of the Zeroit.Framework.Utilities.DrawHelper.PointD.</param>
        /// <returns>The translated Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public static PointD operator +(PointD pt, SizeD sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Compares two Zeroit.Framework.Utilities.DrawHelper.PointD structures. The result specifies whether
        /// the values of the Zeroit.Framework.Utilities.DrawHelper.PointD.X and Zeroit.Framework.Utilities.DrawHelper.PointD.Y properties
        /// of the two Zeroit.Framework.Utilities.DrawHelper.PointD structures are equal.
        /// </summary>
        /// <param name="left">A Zeroit.Framework.Utilities.DrawHelper.PointD to compare.</param>
        /// <param name="right">A Zeroit.Framework.Utilities.DrawHelper.PointD to compare.</param>
        /// <returns>true if the Zeroit.Framework.Utilities.DrawHelper.PointD.X and Zeroit.Framework.Utilities.DrawHelper.PointD.Y values of
        /// the left and right System.DrawingD.PointD structures are equal; otherwise,
        /// false.</returns>
        public static bool operator ==(PointD left, PointD right)
        {
            return !(left != right);
        }

        /// <summary>
        /// Converts an instance of a Zeroit.Framework.Utilities.DrawHelper.PointD structure to a System.Drawing.PointF structure.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD structure instance to convert.</param>
        /// <returns>The System.Drawing.PointF structure from the original.</returns>
        public static explicit operator PointF(PointD pt)
        {
            return new PointF((float)pt.X, (float)pt.Y);
        }

        /// <summary>
        /// Gets a value indicating whether this System.Drawing.PointF is empty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsEmpty { get { return this == Empty; } }

        /// <summary>
        /// Gets or sets the x-coordinate of this Zeroit.Framework.Utilities.DrawHelper.PointD.
        /// </summary>
        /// <value>The x.</value>
        public double X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Gets or sets the y-coordinate of this Zeroit.Framework.Utilities.DrawHelper.PointD.
        /// </summary>
        /// <value>The y.</value>
        public double Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Translates a given Zeroit.Framework.Utilities.DrawHelper.PointD by the specified System.Drawing.Size.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD to translate.</param>
        /// <param name="sz">The System.Drawing.Size that specifies the numbers to add to the coordinates of pt.</param>
        /// <returns>The translated Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public static PointD Add(PointD pt, Size sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Translates a given Zeroit.Framework.Utilities.DrawHelper.PointD by a specified Zeroit.Framework.Utilities.DrawHelper.SizeD.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD to translate.</param>
        /// <param name="sz">The Zeroit.Framework.Utilities.DrawHelper.SizeD that specifies the numbers to add to the coordinates of pt.</param>
        /// <returns>The translated System.DrawingD.PointF.</returns>
        public static PointD Add(PointD pt, SizeD sz)
        {
            return new PointD(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// Specifies whether this Zeroit.Framework.Utilities.DrawHelper.PointD contains the same coordinates as the specified System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to test.</param>
        /// <returns>This method returns true if obj is a Zeroit.Framework.Utilities.DrawHelper.PointD and has the same
        /// coordinates as this System.Drawing.Point.</returns>
        public override bool Equals(object obj)
        {
            if (obj is PointD)
            {
                return (PointD)obj == this;
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this Zeroit.Framework.Utilities.DrawHelper.PointD structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this Zeroit.Framework.Utilities.DrawHelper.PointD
        /// structure.</returns>
        public override int GetHashCode()
        {
            return (int)X + (int)Y;
        }

        /// <summary>
        /// Translates a Zeroit.Framework.Utilities.DrawHelper.PointD by the negative of a specified size.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD to translate.</param>
        /// <param name="sz">The Zeroit.Framework.Utilities.DrawHelper.Size that specifies the numbers to subtract from the coordinates of pt.</param>
        /// <returns>The translated Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public static PointD Subtract(PointD pt, Size sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Translates a Zeroit.Framework.Utilities.DrawHelper.PointD by the negative of a specified size.
        /// </summary>
        /// <param name="pt">The Zeroit.Framework.Utilities.DrawHelper.PointD to translate.</param>
        /// <param name="sz">The Zeroit.Framework.Utilities.DrawHelper.SizeD that specifies the numbers to subtract from the coordinates of pt.</param>
        /// <returns>The translated Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public static PointD Subtract(PointD pt, SizeF sz)
        {
            return new PointD(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// Converts this Zeroit.Framework.Utilities.DrawHelper.PointD to a human readable string.
        /// </summary>
        /// <returns>A string that represents this Zeroit.Framework.Utilities.DrawHelper.PointD.</returns>
        public override string ToString()
        {
            return ((PointF)this).ToString();
        }
    }
}
