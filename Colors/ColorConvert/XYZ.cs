// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="XYZ.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors.Converters
{
    /**
	 * XYZ color
	 */
    // http://www.easyrgb.com/index.php?X=MATH&H=07#text7


    /// <summary>
    /// A class collection XYZ manipulation
    /// </summary>
    public class XYZColor
    {
        public float x, y, z;

        
        public XYZColor(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Convert from RGB to XYZ
        /// </summary>
        /// <param name="col">Set RGB color</param>
        /// <returns></returns>
        public static XYZColor FromRGB(Color col)
        {
            return ColorConverter.RGBToXYZ(col);
        }

        /// <summary>
        /// Convert from RGB to XYZ
        /// </summary>
        /// <param name="R">Set Red value</param>
        /// <param name="G">Set Green value</param>
        /// <param name="B">Set Blue value</param>
        /// <returns></returns>
        public static XYZColor FromRGB(float R, float G, float B)
        {
            return ColorConverter.RGBToXYZ(R, G, B);
        }

        /// <summary>
        /// Override To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("( {0}, {1}, {2} )", x, y, z);
        }
    }

}
