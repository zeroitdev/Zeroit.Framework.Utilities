// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="RGB_TO_HSL_Converter.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// A class collection for RGB Manipulation
    /// </summary>
    public class ColorRGB
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        /// <summary>
        /// Creates an instance of RGB color
        /// </summary>
        public ColorRGB()
        {
            R = 255;
            G = 255;
            B = 255;
            A = 255;
        }

        /// <summary>
        /// Creates an instance of RGB color
        /// </summary>
        /// <param name="value">Set RGB color</param>
        public ColorRGB(Color value)
        {
            this.R = value.R;
            this.G = value.G;
            this.B = value.B;
            this.A = value.A;
        }
        public static implicit operator Color(ColorRGB rgb)
        {
            Color c = Color.FromArgb(rgb.A, rgb.R, rgb.G, rgb.B);
            return c;
        }
        public static explicit operator ColorRGB(Color c)
        {
            return new ColorRGB(c);
        }

        /// <summary>
        /// Convert from HSL to RGB
        /// </summary>
        /// <param name="H">Set Hue in a range of 0-1</param>
        /// <param name="S">Set Saturation in a range of 0-1</param>
        /// <param name="L">Set Luminosity in a range of 0-1</param>
        /// <returns>Returns a Color (RGB struct) in range of 0-255</returns>
        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static ColorRGB FromHSL(double H, double S, double L)
        {
            return FromHSLA(H, S, L, 1.0);
        }

        /// <summary>
        /// Convert from HSLA to RGB
        /// </summary>
        /// <param name="H">Set Hue in a range of 0-1</param>
        /// <param name="S">Set Saturation in a range of 0-1</param>
        /// <param name="L">Set Luminosity in a range of 0-1</param>
        /// <param name="A">Set Alpha in a range of 0-1</param>
        /// <returns></returns>
        // Given H,S,L,A in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static ColorRGB FromHSLA(double H, double S, double L, double A)
        {
            double v;
            double r, g, b;
            if (A > 1.0)
                A = 1.0;

            r = L;   // default to gray
            g = L;
            b = L;
            v = (L <= 0.5) ? (L * (1.0 + S)) : (L + S - L * S);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = L + L - v;
                sv = (v - m) / v;
                H *= 6.0;
                sextant = (int)H;
                fract = H - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            ColorRGB rgb = new ColorRGB();
            rgb.R = Convert.ToByte(r * 255.0f);
            rgb.G = Convert.ToByte(g * 255.0f);
            rgb.B = Convert.ToByte(b * 255.0f);
            rgb.A = Convert.ToByte(A * 255.0f);
            return rgb;
        }

        /// <summary>
        /// Hue in range from 0.0 to 1.0
        /// </summary>
        // Hue in range from 0.0 to 1.0
        public float H
        {
            get
            {
                // Use System.Drawing.Color.GetHue, but divide by 360.0F 
                // because System.Drawing.Color returns hue in degrees (0 - 360)
                // rather than a number between 0 and 1.
                return ((Color)this).GetHue() / 360.0F;
            }
        }

        /// <summary>
        /// Saturation in range from 0.0 to 1.0
        /// </summary>
        // Saturation in range 0.0 - 1.0
        public float S
        {
            get
            {
                return ((Color)this).GetSaturation();
            }
        }

        /// <summary>
        /// Luminosity in range from 0.0 to 1.0
        /// </summary>
        // Lightness in range 0.0 - 1.0
        public float L
        {
            get
            {
                return ((Color)this).GetBrightness();
                
            }
        }
    }
}
