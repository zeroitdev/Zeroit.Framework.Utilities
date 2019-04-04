// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Hsv.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors.Converters
{

    /**
	 * Hue (0,360), Saturation (0,1), Value (0,1)
	 */

    /// <summary>
    /// A class for HSV Manipulation
    /// </summary>
    public class HsvColor
    {
        public float h, s, v;


        public HsvColor(float h, float s, float v)
        {
            this.h = h;
            this.s = s;
            this.v = v;
        }

        /**
		 * Wikipedia colors are from 0-100 %, so this constructor includes and S, V normalizes the values.
		 * modifier value that affects saturation and value, making it useful for any SV value range.
		 */
        public HsvColor(float h, float s, float v, float sv_modifier)
        {
            this.h = h;
            this.s = s * sv_modifier;
            this.v = v * sv_modifier;
        }

        /// <summary>
        /// Convert to HSV from RGB
        /// </summary>
        /// <param name="col">Set color</param>
        /// <returns></returns>
        public static HsvColor FromRGB(Color col)
        {
            return ColorConverter.RGBtoHSV(col);
        }

        /// <summary>
        /// Override To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("( {0}, {1}, {2} )", h, s, v);
        }

        /// <summary>
        /// Find Square Distance from HSV Color
        /// </summary>
        /// <param name="InColor">Set HSV color</param>
        /// <returns></returns>
        public float SqrDistance(HsvColor InColor)
        {
            return (InColor.h / 360f - this.h / 360f) + (InColor.s - this.s) + (InColor.v - this.v);
        }
    }

}
