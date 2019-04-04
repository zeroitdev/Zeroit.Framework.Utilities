// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ColorConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors.Converters
{

    public static partial class ColorConverter
    {
        /**
		 * Convert RGBA color to XYZ
		 */

        /// <summary>
        /// Convert from RGB to XYZ
        /// </summary>
        /// <param name="col">Set Color</param>
        public static XYZColor RGBToXYZ(Color col)
        {
            return RGBToXYZ(col.R, col.G, col.B);

        }

        /// <summary>
        /// Convert from RGB to XYZ
        /// </summary>
        /// <param name="r">Set Red value</param>
        /// <param name="g">Set Green value</param>
        /// <param name="b">Set Blue value</param>
        /// <returns></returns>
        public static XYZColor RGBToXYZ(float r, float g, float b)
        {
            if (r > 0.04045f)
                r = (float)(float)Math.Pow(((r + 0.055f) / 1.055f), 2.4f);
            else
                r = r / 12.92f;

            if (g > 0.04045f)
                g = (float)Math.Pow(((g + 0.055f) / 1.055f), 2.4f);
            else
                g = g / 12.92f;

            if (b > 0.04045f)
                b = (float)Math.Pow(((b + 0.055f) / 1.055f), 2.4f);
            else
                b = b / 12.92f;

            r = r * 100f;
            g = g * 100f;
            b = b * 100f;

            // Observer. = 2°, Illuminant = D65
            float x = r * 0.4124f + g * 0.3576f + b * 0.1805f;
            float y = r * 0.2126f + g * 0.7152f + b * 0.0722f;
            float z = r * 0.0193f + g * 0.1192f + b * 0.9505f;

            return new XYZColor(x, y, z);
        }

        
        /// <summary>
        /// Convert from XYZ to CIE
        /// </summary>
        /// <param name="xyz">XYZ Color</param>
        /// <returns></returns>
        public static CIELabColor XYZToCIE_Lab(XYZColor xyz)
        {
            float var_X = xyz.x / 95.047f;           // ref_X =  95.047   Observer= 2°, Illuminant= D65
            float var_Y = xyz.y / 100.000f;          // ref_Y = 100.000
            float var_Z = xyz.z / 108.883f;          // ref_Z = 108.883

            if (var_X > 0.008856f)
                var_X = (float)Math.Pow(var_X, (1 / 3f));
            else
                var_X = (7.787f * var_X) + (16f / 116f);

            if (var_Y > 0.008856f)
                var_Y = (float)Math.Pow(var_Y, (1 / 3f));
            else
                var_Y = (7.787f * var_Y) + (16f / 116f);

            if (var_Z > 0.008856f)
                var_Z = (float)Math.Pow(var_Z, (1 / 3f));
            else
                var_Z = (7.787f * var_Z) + (16f / 116f);

            float L = (116f * var_Y) - 16f;
            float a = 500f * (var_X - var_Y);
            float b = 200f * (var_Y - var_Z);

            return new CIELabColor(L, a, b);
        }


        /**
		 * Calculate the euclidean distance between two Cie-Lab colors (DeltaE).
 		 * http://www.easyrgb.com/index.php?X=DELT&H=03#text3
		 */

        /// <summary>
        /// Calculate the euclidean distance between two Cie-Lab colors (DeltaE).
        /// </summary>
        /// <param name="lhs">Left Hand Side</param>
        /// <param name="rhs">Right Hand Side</param>
        /// <returns></returns>
        public static float DeltaE(CIELabColor lhs, CIELabColor rhs)
        {
            return (float)Math.Sqrt(
                (float)Math.Pow((lhs.L - rhs.L), 2) +
                (float)Math.Pow((lhs.a - rhs.a), 2) +
                (float)Math.Pow((lhs.b - rhs.b), 2));
        }

        /**
		 * Convert HSV to RGB.
		 *  http://www.cs.rit.edu/~ncs/color/t_convert.html
		 *	r,g,b values are from 0 to 1
		 *	h = [0,360], s = [0,1], v = [0,1]
		 *	if s == 0, then h = -1 (undefined)
		 */

        /// <summary>
        /// Convert from HSV to RGB
        /// </summary>
        /// <param name="hsv">HSV color</param>
        /// <returns></returns>
        public static Color HSVtoRGB(HsvColor hsv)
        {
            return HSVtoRGB(hsv.h, hsv.s, hsv.v);
        }


        /**
		 * Convert HSV color to RGB.
		 */


        /// <summary>
        /// Convert from HSV to RGB
        /// </summary>
        /// <param name="h">Hue</param>
        /// <param name="s">Saturation</param>
        /// <param name="v">Value</param>
        /// <returns></returns>
        public static Color HSVtoRGB(float h, float s, float v)
        {
            int H = (int)h;
            int S = (int)s;
            int V = (int)v;
            int r, g, b;
            int i;
            int f, p, q, t;
            short StateARGBValueValid = 2;
            if (s == 0)
            {
                // achromatic (grey)

                //return new Color(Color.MakeArgb((byte)v, (byte)v, (byte)v, (int)1), StateARGBValueValid, (string)null, (KnownColor)0);

                return Color.FromArgb((int)v, (int)v, (int)v, (int)1f);
            }
            h /= 60;            // sector 0 to 5
            i = (int)(float)Math.Floor(h);
            f = H - i;          // factorial part of h
            p = V * (1 - S);
            q = V * (1 - S * f);
            t = V * (1 - S * (1 - f));

            switch (i)
            {
                case 0:
                    r = V;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = V;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = V;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = V;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = V;
                    break;
                default:        // case 5:
                    r = V;
                    g = p;
                    b = q;
                    break;
            }

            return Color.FromArgb((int)r, (int)g, (int)b, (int)1f);
        }


        /**
		 * http://www.cs.rit.edu/~ncs/color/t_convert.html
		 * r,g,b values are from 0 to 1
		 * h = [0,360], s = [0,1], v = [0,1]
		 * 	if s == 0, then h = -1 (undefined)
		 */

        /// <summary>
        /// Convert from RGB to HSV
        /// </summary>
        /// <param name="color">Set color</param>
        /// <returns></returns>
        public static HsvColor RGBtoHSV(Color color)
        {
            int h, s, v;
            int r = color.R, b = color.B, g = color.G;

            int min, max, delta;
            min = (int)Math.Min((float)Math.Min(r, g), b);
            max = (int)Math.Max((float)Math.Max(r, g), b);

            v = max;                // v

            delta = max - min;

            if (max != 0f)
            {
                s = delta / max;        // s
            }
            else
            {
                // r = g = b = 0		// s = 0, v is undefined
                s = 0;
                h = 0;
                return new HsvColor(h, s, v);
            }

            if ((float)Math.Abs(r - max) < (float)Double.Epsilon)
            {
                h = (g - b) / delta;        // between yellow & magenta
                if (float.IsNaN(h))
                    h = 0;
            }
            else if ((float)Math.Abs(g - max) < (float)Double.Epsilon)
            {
                h = 2 + (b - r) / delta;    // between cyan & yellow
            }
            else
            {
                h = 4 + (r - g) / delta;    // between magenta & cyan
            }

            h *= 60;                    // degrees

            if (h < 0)
                h += 360;

            return new HsvColor(h, s, v);
        }


        /**
		 * Get human readable name from a Color.
		 */

        /// <summary>
        /// Get Color Name
        /// </summary>
        /// <param name="InColor">Set in-color</param>
        /// <returns></returns>
        public static string GetColorName(Color InColor)
        {
            CIELabColor lab = CIELabColor.FromRGB(InColor);

            string name = "Unknown";
            float diff = (float)double.PositiveInfinity;

            foreach (KeyValuePair<string, CIELabColor> kvp in ColorNameLookup)
            {
                float dist = (float)Math.Abs(DeltaE(lab, kvp.Value));

                if (dist < diff)
                {
                    diff = dist;
                    name = kvp.Key;
                }
            }

            return name;
        }

        /// <summary>
        /// Convert to CIE from RGB
        /// </summary>
        /// <param name="R">Set Red</param>
        /// <param name="G">Set Green</param>
        /// <param name="B">Set Blue</param>
        /// <param name="Scale">Set scale</param>
        /// <returns></returns>
        public static CIELabColor CIELabFromRGB(float R, float G, float B, float Scale)
        {
            float inv_scale = 1f / Scale;
            XYZColor xyz = XYZColor.FromRGB(R * inv_scale, G * inv_scale, B * inv_scale);

            return CIELabColor.FromXYZ(xyz);
        }

        /**
		 * http://en.wikipedia.org/wiki/List_of_colors:_A%E2%80%93F
		 */

    }
}
