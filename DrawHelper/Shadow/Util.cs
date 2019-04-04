// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Util.cs" company="Zeroit Dev Technologies">
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

/*
 * This class provides common toolkit amongst modules. Exports 3 methods and 1 class. 
// ``` clamp(val, min, max) ```
// 
// Ensures a value is between min and max.
// 
// ``` dist(x1, x2) ```
//
// Calculates the absolute distance between two values.
//
// ``` normalize(val, dmin, dmax, smin, smax) ```
//
// Projects a value in the source range into the corresponding
// value in the destination range.
//
// ``` Bezier(C1, C2, C3, C4) ```
//
// A Bezier curve implementation.
 */

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class Util.
    /// </summary>
    class Util
    {
        /// <summary>
        /// Clamps the specified value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>System.Single.</returns>
        public static float clamp(float val, float min, float max)
        {
            return Math.Min(max, Math.Max(min, val));
        }

        /// <summary>
        /// Dists the specified x1.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="x2">The x2.</param>
        /// <returns>System.Single.</returns>
        public static float dist(float x1, float x2)
        {
            return (float)Math.Sqrt(Math.Pow(x2 - x1, 2));
        }

        /// <summary>
        /// Normalizes the specified value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="dmin">The dmin.</param>
        /// <param name="dmax">The dmax.</param>
        /// <param name="smin">The smin.</param>
        /// <param name="smax">The smax.</param>
        /// <returns>System.Single.</returns>
        public static float normalize(float val, float dmin, float dmax, float smin, float smax)
        {
            float sdist = dist(smin, smax);
            float ddist = dist(dmin, dmax);
            float ratio = ddist / sdist;
            val = clamp(val, smin, smax);
            return dmin + (val-smin) * ratio;
        }
        
    }

    // **Adapted from (with special thanks)** <br>
    // 13thParallel.org Beziér Curve Code <br>
    // *by Dan Pupius (www.pupius.net)*
    /// <summary>
    /// Class Bezier.
    /// </summary>
    public class Bezier
    {
        /// <summary>
        /// The c1
        /// </summary>
        Point C1, C2, C3, C4;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bezier"/> class.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="c3">The c3.</param>
        /// <param name="c4">The c4.</param>
        public Bezier(Point c1, Point c2, Point c3, Point c4)
        {
            C1 = c1; C2 = c2; C3 = c3; C4 = c4;

        }

        /// <summary>
        /// B1s the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>System.Single.</returns>
        float B1(float t) { return t * t * t; }
        /// <summary>
        /// B2s the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>System.Single.</returns>
        float B2(float t) { return 3 * t * t * (1 - t); }
        /// <summary>
        /// B3s the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>System.Single.</returns>
        float B3(float t) { return 3 * t * (1 - t) * (1 - t); }
        /// <summary>
        /// B4s the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>System.Single.</returns>
        float B4(float t) { return (1 - t) * (1 - t) * (1 - t); }

        /// <summary>
        /// Gets the point.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>Point.</returns>
        Point getPoint(float t)
        {
            return new Point(
                (int)(C1.X * B1(t) + C2.X * B2(t) + C3.X * B3(t) + C4.X * B4(t)),
                (int)(C1.Y * B1(t) + C2.Y * B2(t) + C3.Y * B3(t) + C4.Y * B4(t))
            );
        }

        // Creates a color table for 1024 points. To create the table
        // 1024 bezier points are calculated with t = i/1024 in every
        // loop iteration and map is created for [x] = y. This is then
        // used to project a color RGB value (x) to another color RGB
        // value (y).

        /// <summary>
        /// Gens the color table.
        /// </summary>
        /// <returns>System.Int32[].</returns>
        public int[] genColorTable()
        {
            int[] points = new int[1024];

            for (int i = 0; i < 1024; i++)
            {
                Point point = getPoint(i / 1024.0f);
                points[point.X] = point.Y;
            }

            return points;
        }
    }


}
