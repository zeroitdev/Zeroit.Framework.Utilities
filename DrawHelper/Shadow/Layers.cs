// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Layers.cs" company="Zeroit Dev Technologies">
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
// This object mimics the functionality of Photoshop layers. 
// It provides a single method: ```merge()```. This method takes
// a top and a bottom layer to merge together. *The top layer is 
// merged ontop of the bottom layer*.
//
// There are 7 pre-defined blending modes with which you can
// blend layers.
*/
namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class Layers.
    /// </summary>
    class Layers
    {
        /// <summary>
        /// Applies the specified bottom.
        /// </summary>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <param name="fn">The function.</param>
        /// <returns>BitmapWorker.</returns>
        BitmapWorker apply(BitmapWorker bottom, BitmapWorker top, string fn)
        {
            int i = 0, j = 0,
            h = Math.Min(bottom.Height(), top.Height()),
            w = Math.Min(bottom.Width(), top.Width());

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    // Execute blend on each pixel.
                    bottom.SetPixel(i, j, func(fn, bottom.GetPixel(i, j), top.GetPixel(i, j)));
                }
            }
            return bottom;
        }

        /// <summary>
        /// Opacities the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <returns>BitmapWorker.</returns>
        public BitmapWorker opacity(int value, BitmapWorker bottom, BitmapWorker top) // in Form1.cs for example: "layer3 = layers.opacity(50,layer2, layer1);" *"50" = 50% the value from 0-100
        {
            if (value >= 0 && value <= 100)
            {
                float percentge = (float)value / 100;
                int i = 0, j = 0,
             h = Math.Min(bottom.Height(), top.Height()),
             w = Math.Min(bottom.Width(), top.Width());

                for (i = 0; i < w; i++)
                {
                    for (j = 0; j < h; j++)
                    {
                        Color b = bottom.GetPixel(i, j);
                        Color t = top.GetPixel(i, j);
                        float cr = 0, cg = 0, cb = 0, ca = 0;
                        ca = b.A * (1 - percentge) + t.A * percentge;
                        cr = b.R * (1 - percentge) + t.R * percentge;
                        cg = b.G * (1 - percentge) + t.G * percentge;
                        cb = b.B * (1 - percentge) + t.B * percentge;

                        bottom.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255), (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                    }
                }
            }
            return bottom;
        }

        /// <summary>
        /// Functions the specified function.
        /// </summary>
        /// <param name="fn">The function.</param>
        /// <param name="b">The b.</param>
        /// <param name="t">The t.</param>
        /// <returns>Color.</returns>
        Color func(string fn, Color b, Color t)
        {
            int cr = 0, cg = 0, cb = 0, ca = 0;
            //check which function to apply and apply it
            if (fn == "multiply")
            {
                cr = (t.R * b.R) / 255;
                cg = (t.G * b.G) / 255;
                cb = (t.B * b.B) / 255;
                ca = (t.A  * b.A) / 255;
            }
            if (fn == "screen")
            {
                cr = 255 - (((255 - t.R) * (255 - b.R)) / 255);
                cg = 255 - (((255 - t.G) * (255 - b.G)) / 255);
                cb = 255 - (((255 - t.B) * (255 - b.B)) / 255);
                ca = 255 - (((255 - t.A) * (255 - b.A)) / 255);
            }

            if (fn == "overlay")
            {
                cr = coverlay(b.R, t.R);
                cg = coverlay(b.G, t.G);
                cb = coverlay(b.B, t.B);
                ca = coverlay(b.A, t.A);
            }

            // Thanks to @olivierlesnicki for suggesting a better algoritm.
            if (fn == "softLight")
            {
                cr = csoftLight(b.R, t.R);
                cg = csoftLight(b.G, t.G);
                cb = csoftLight(b.B, t.B);
                ca = csoftLight(b.A, t.A);
            }
            if (fn == "addition")
            {
                cr = b.R + t.R;
                cg = b.G + t.G;
                cb = b.B + t.B;
                ca = b.A + t.A;
            }
            if (fn == "exclusion")
            {
                cr = 128 - 2 * (b.R - 128) * (t.R - 128) / 255;
                cg = 128 - 2 * (b.G - 128) * (t.G - 128) / 255;
                cb = 128 - 2 * (b.B - 128) * (t.B - 128) / 255;
                ca = 128 - 2 * (b.A - 128) * (t.A - 128) / 255;
            }
            if (fn == "difference")
            {
                cr = Math.Abs(b.R - t.R);
                cg = Math.Abs(b.G - t.G);
                cb = Math.Abs(b.B - t.B);
                ca = Math.Abs(b.A - t.A);
            }
           if (fn == "colordodge")
            {
               
                double cr_d, cg_d, cb_d, ca_d;
                if ((t.R) != 255)
                    cr_d = ((double)b.R /(255 - t.R))*255 ;
                else cr_d = 0;

                if ((t.G) != 255)
                    cg_d = ((double)b.G/(255 - t.G))*255;
                else cg_d = 0;

                if ((t.B) != 255)
                    cb_d = ((double)b.B/(255 - t.B))*255;
                else cb_d = 0;

                if ((t.A) != 255)
                    ca_d = ((double)b.A/(255 - t.A))*255;
                else ca_d = 0;

                cr = (int)cr_d;
                cg = (int)cg_d;
                cb = (int)cb_d;
                ca = (int)ca_d;

            }
            return Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255), (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255));

        }

        /// <summary>
        /// Coverlays the specified b.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="t">The t.</param>
        /// <returns>System.Int32.</returns>
        int coverlay(int b, int t) { return (b > 128) ? 255 - 2 * (255 - t) * (255 - b) / 255 : (b * t * 2) / 255; }

        /// <summary>
        /// Csofts the light.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="t">The t.</param>
        /// <returns>System.Int32.</returns>
        int csoftLight(float b, float t)
        {
            b /= 255;
            t /= 255;
            return (int)((t < 0.5) ? 255 * ((1 - 2 * t) * b * b + 2 * t * b) : 255 * ((1 - (2 * t - 1)) * b + (2 * t - 1) * (Math.Pow(b, 0.5))));
        }

        /// <summary>
        /// Merges two layers. Takes a 'type' parameter and
        /// a bottom and top layer. The 'type' parameter specifies
        /// the blending mode. type options are:
        /// - multiply
        /// - screen
        /// - overlay
        /// - softLight
        /// - addition
        /// - exclusion
        /// - difference
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <returns>BitmapWorker.</returns>
        public BitmapWorker merge(string type, BitmapWorker bottom, BitmapWorker top)
        {

            return apply(bottom, top, type);
        }

    }
}
