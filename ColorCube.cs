// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ColorCube.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{

    /// <summary>
    /// Describes the RGB color space as a 3D cube with the origin at Black.
    /// </summary>
    public sealed class ColorCube
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorCube"/> class.
        /// </summary>
        protected ColorCube()
        {
        }

        /// <summary>
        /// Compares two colors according to their distance from the origin of the cube (black).
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>System.Int32.</returns>
        public static int Compare(Color source, Color target)
        {
            double delta1 = GetDistance(Color.Black, source);
            double delta2 = GetDistance(Color.Black, target);
            return delta1.CompareTo(delta2);
        }

        /// <summary>
        /// Returns an integer between 0 and 255 indicating the perceived brightness of the color.
        /// </summary>
        /// <param name="target">A System.Drawing.Color instance.</param>
        /// <returns>An integer indicating the brightness with 0 being dark and 255 being bright.</returns>
        /// <remarks>Formula found using web search at:
        /// http://www.nbdtech.com/Blog/archive/2008/04/27/Calculating-the-Perceived-Brightness-of-a-Color.aspx Jump
        /// with reference to : http://alienryderflex.com/hsp.html Jump
        /// Effectively the same as measuring a color's distance from black, but constrained to a 0-255 range.</remarks>
        public static int GetBrightness(Color target)
        {
            return Convert.ToInt32(Math.Sqrt(System.Math.Pow(0.241 * target.R, System.Math.Pow(2 + 0.691 * target.G, System.Math.Pow(2 + 0.068 * target.B, 2)))));
        }

        /// <summary>
        /// Gets a color from within the cube starting at the origin and moving a given distance in the specified direction.
        /// </summary>
        /// <param name="azimuth">The side-to-side angle in degrees; 0 points toward red and 90 points toward blue.</param>
        /// <param name="elevation">The top-to-bottom angle in degrees; 0 is no green and 90 points toward full green.</param>
        /// <param name="distance">The distance to travel within the cube; 500 is max.</param>
        /// <returns>The color within the cube at the given distance in the specified direction.</returns>
        public static Color GetColorFrom(int azimuth, int elevation, int distance)
        {
            return GetColorFrom(Color.Black, azimuth, elevation, distance);
        }

        /// <summary>
        /// Gets a color from within the cube starting at the specified location and moving a given distance in the specified direction.
        /// </summary>
        /// <param name="source">The source location within the cube from which to start moving.</param>
        /// <param name="azimuth">The side-to-side angle in degrees; 0 points toward red and 90 points toward blue.</param>
        /// <param name="elevation">The top-to-bottom angle in degrees; 0 is no green and 90 points toward full green.</param>
        /// <param name="distance">The distance to travel within the cube; the approximate distance from black to white is 500.</param>
        /// <param name="isRadians">if set to <c>true</c> [is radians].</param>
        /// <returns>The color within the cube at the given distance in the specified direction.</returns>
        /// <exception cref="System.ArgumentException">
        /// azimuth - Value must be between 0 and 90.
        /// or
        /// elevation - Value must be between 0 and 90.
        /// </exception>
        public static Color GetColorFrom(Color source, double azimuth, double elevation, double distance, bool isRadians = false)
        {
            if (azimuth < 0 || azimuth > 90)
            {
                throw new ArgumentException("azimuth", "Value must be between 0 and 90.");
            }
            if (elevation < 0 || elevation > 90)
            {
                throw new ArgumentException("elevation", "Value must be between 0 and 90.");
            }
            double a = 0;
            double e = 0;
            double r = 0;
            double g = 0;
            double b = 0;
            if (isRadians)
            {
                a = azimuth;
                e = elevation;
            }
            else
            {
                a = DegreesToRadians(azimuth);
                e = DegreesToRadians(elevation);
            }
            r = distance * Math.Cos(a) * Math.Cos(e);
            b = distance * Math.Sin(a) * Math.Cos(e);
            g = distance * Math.Sin(e);
            if (double.IsNaN(r))
            {
                r = 0;
            }
            if (double.IsNaN(g))
            {
                g = 0;
            }
            if (double.IsNaN(b))
            {
                b = 0;
            }
            return Color.FromArgb((int)Math.Max(Math.Min(source.R + r, 255), 0), (int)Math.Max(Math.Min(source.G + g, 255), 0), (int)Math.Max(Math.Min(source.B + b, 255), 0));
        }

        /// <summary>
        /// Creates an array of colors from a selection within a sphere around the specified color.
        /// </summary>
        /// <param name="target">The color to select around.</param>
        /// <param name="distance">The radius of the selection sphere.</param>
        /// <param name="increment">The increment within the sphere at which a selection is taken; larger numbers result in smaller selection sets.</param>
        /// <returns>An array of colors located around the specified color within the cube.</returns>
        public static Color[] GetColorsAround(Color target, int distance, int increment)
        {
            List<Color> result = new List<Color>();
            //INSTANT C# TODO TASK: The step increment was not confirmed to be positive - confirm that the stopping condition is appropriate:
            //ORIGINAL LINE: For a As Integer = 0 To 359 Step increment
            for (int a = 0; a <= 359; a += increment)
            {
                //INSTANT C# TODO TASK: The step increment was not confirmed to be positive - confirm that the stopping condition is appropriate:
                //ORIGINAL LINE: For e As Integer = 0 To 359 Step increment
                for (int e = 0; e <= 359; e += increment)
                {
                    Color c = GetColorFrom(target, a, e, distance);
                    if (!(result.Contains(c)))
                    {
                        result.Add(c);
                    }
                }
            }
            result.Sort(Compare);
            return result.ToArray();
        }

        /// <summary>
        /// Creates an array of colors in a gradient sequence between two specified colors.
        /// </summary>
        /// <param name="source">The starting color in the sequence.</param>
        /// <param name="target">The end color in the sequence.</param>
        /// <param name="increment">The increment between colors.</param>
        /// <returns>A gradient array of colors.</returns>
        public static Color[] GetColorSequence(Color source, Color target, int increment)
        {
            List<Color> result = new List<Color>();
            double a = GetAzimuthTo(source, target);
            double e = GetElevationTo(source, target);
            double d = GetDistance(source, target);
            //INSTANT C# TODO TASK: The step increment was not confirmed to be positive - confirm that the stopping condition is appropriate:
            //ORIGINAL LINE: For i As Integer = 0 To d Step increment
            for (int i = 0; i <= d; i += increment)
            {
                result.Add(GetColorFrom(source, a, e, i, true));
            }
            return result.ToArray();
        }

        /// <summary>
        /// Creates a rainbow array of colors by selecting from the edges of the cube in ROYGBIV order at the specified increment.
        /// </summary>
        /// <param name="increment">The increment along the edges at which a selection is taken; larger numbers result in smaller selection sets.</param>
        /// <returns>An array of colors in ROYGBIV order at the given increment.</returns>
        public static Color[] GetColorSpectrum(int increment)
        {
            List<Color> result = new List<Color>();
            int[] rgb = new int[3];
            int idx = 1;
            int inc = increment;
            Func<int, int, bool> cmp = null;

            rgb[0] = 255;
            cmp = CompareLess;
            do
            {
                result.Add(Color.FromArgb(rgb[0], rgb[1], rgb[2]));
                if (cmp(rgb[idx], inc))
                {
                    rgb[idx] += inc;
                }
                else
                {
                    switch (idx)
                    {
                        case 1:
                            if (rgb[2] < 255)
                            {
                                rgb[idx] = 255;
                                idx = 0;
                                cmp = CompareGreater;
                            }
                            else
                            {
                                rgb[idx] = 0;
                                idx = 0;
                                cmp = CompareLess;
                            }
                            break;
                        case 2:
                            rgb[idx] = 255;
                            idx = 1;
                            cmp = CompareGreater;
                            break;
                        case 0:
                            if (rgb[2] < 255)
                            {
                                rgb[idx] = 0;
                                idx = 2;
                                cmp = CompareLess;
                            }
                            else
                            {
                                rgb[idx] = 255;
                                //INSTANT C# WARNING: Exit statements not matching the immediately enclosing block are converted using a 'goto' statement:
                                //ORIGINAL LINE: Exit Do
                                goto ExitLabel1;
                            }
                            break;
                    }
                    inc *= -1;
                }
            } while (true);
            ExitLabel1:
            result.Add(Color.FromArgb(rgb[0], rgb[1], rgb[2]));
            return result.ToArray();
        }

        /// <summary>
        /// Gets the distance between two colors within the cube.
        /// </summary>
        /// <param name="source">The source color in the cube.</param>
        /// <param name="target">The target color in the cube.</param>
        /// <returns>The distance between the source and target colors.</returns>
        public static double GetDistance(Color source, Color target)
        {
            double squareR = Convert.ToDouble(target.R) - Convert.ToDouble(source.R);
            squareR *= squareR;
            double squareG = Convert.ToDouble(target.G) - Convert.ToDouble(source.G);
            squareG *= squareG;
            double squareB = Convert.ToDouble(target.B) - Convert.ToDouble(source.B);
            squareB *= squareB;
            return System.Math.Sqrt(squareR + squareG + squareB);
        }

        /// <summary>
        /// Converts a RGB color into its Hue, Saturation, and Luminance (HSL) values.
        /// </summary>
        /// <param name="rgb">The color to convert.</param>
        /// <returns>The HSL representation of the color.</returns>
        /// <remarks>Source algorithm found using web search at:
        /// http://geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm Jump
        /// (Adapted to VB)</remarks>
        public static HSLColor GetHSL(Color rgb)
        {
            double h = 0;
            double s = 0;
            double l = 0;
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;
            double v = 0;
            double m = 0;
            double vm = 0;
            double r2 = 0;
            double g2 = 0;
            double b2 = 0;

            h = 0;
            s = 0;
            l = 0;
            v = Math.Max(r, g);
            v = Math.Max(v, b);
            m = Math.Min(r, g);
            m = Math.Min(m, b);
            l = (m + v) / 2.0;
            if (l <= 0.0)
            {
                return new HSLColor();
            }

            vm = v - m;
            s = vm;
            if (s > 0.0)
            {
                s /= (l <= 0.5) ? (v + m) : (2.0 - v - m);
            }
            else
            {
                return new HSLColor();
            }

            r2 = (v - r) / vm;
            g2 = (v - g) / vm;
            b2 = (v - b) / vm;

            if (r == v)
            {
                h = (g == m) ? 5.0 + b2 : 1.0 - g2;
            }
            else if (g == v)
            {
                h = (b == m) ? 1.0 + r2 : 3.0 - b2;
            }
            else
            {
                h = (r == m) ? 3.0 + g2 : 5.0 - r2;
            }

            h /= 6.0;
            return new HSLColor(h, s, l);
        }

        /// <summary>
        /// Compares the less.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="inc">The inc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected static bool CompareLess(int value, int inc)
        {
            return value < 255 - Math.Abs(inc);
        }

        /// <summary>
        /// Compares the greater.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="inc">The inc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected static bool CompareGreater(int value, int inc)
        {
            return value > 0 + Math.Abs(inc);
        }

        /// <summary>
        /// Degreeses to radians.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>System.Double.</returns>
        protected static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        /// <summary>
        /// Radianses to degrees.
        /// </summary>
        /// <param name="radians">The radians.</param>
        /// <returns>System.Double.</returns>
        protected static double RadiansToDegrees(double radians)
        {
            return Convert.ToSingle(radians * (180.0 / Math.PI));
        }

        /// <summary>
        /// Gets the azimuth to.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>System.Double.</returns>
        protected static double GetAzimuthTo(Color source, Color target)
        {
            return WrapAngle(Math.Atan2(Convert.ToDouble(target.B) - Convert.ToDouble(source.B), Convert.ToDouble(target.R) - Convert.ToDouble(source.R)));
        }

        /// <summary>
        /// Gets the elevation to.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>System.Double.</returns>
        protected static double GetElevationTo(Color source, Color target)
        {
            return WrapAngle(Math.Atan2(Convert.ToDouble(target.G) - Convert.ToDouble(source.G), 255));
        }

        /// <summary>
        /// Wraps the angle.
        /// </summary>
        /// <param name="radians">The radians.</param>
        /// <returns>System.Double.</returns>
        protected static double WrapAngle(double radians)
        {
            while (radians < -Math.PI)
            {
                radians += Math.PI * 2;
            }
            while (radians > Math.PI)
            {
                radians -= Math.PI * 2;
            }
            return radians;
        }

        /// <summary>
        /// Describes a RGB color in Hue, Saturation, and Luminance values.
        /// </summary>
        public struct HSLColor
        {
            /// <summary>
            /// The color hue.
            /// </summary>
            public double H;
            /// <summary>
            /// The color saturation.
            /// </summary>
            public double S;
            /// <summary>
            /// The color luminance.
            /// </summary>
            public double L;

            /// <summary>
            /// Initializes a new instance of the <see cref="HSLColor"/> struct.
            /// </summary>
            /// <param name="hValue">The h value.</param>
            /// <param name="sValue">The s value.</param>
            /// <param name="lValue">The l value.</param>
            public HSLColor(double hValue, double sValue, double lValue) : this()
            {
                H = hValue;
                S = sValue;
                L = lValue;
            }
        }
    }
}
