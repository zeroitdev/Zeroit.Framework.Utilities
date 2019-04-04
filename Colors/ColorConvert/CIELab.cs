// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CIELab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors.Converters
{

    /**
	 * CIE_Lab* color
	 */

    /// <summary>
    /// A class collection for CIE Lab color manipulation
    /// </summary>
    public class CIELabColor
    {
        public float L, a, b;

        public CIELabColor(float L, float a, float b)
        {
            this.L = L;
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Convert  From XYZ to CIE
        /// </summary>
        /// <param name="xyz">XYZ</param>
        /// <returns></returns>
        public static CIELabColor FromXYZ(XYZColor xyz)
        {
            return ColorConverter.XYZToCIE_Lab(xyz);
        }

        /// <summary>
        /// Convert from RGB to CIE
        /// </summary>
        /// <param name="col">Set Color</param>
        /// <returns></returns>
        public static CIELabColor FromRGB(Color col)
        {
            XYZColor xyz = XYZColor.FromRGB(col);

            return ColorConverter.XYZToCIE_Lab(xyz);
        }

        /// <summary>
        /// To String Override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("( {0}, {1}, {2} )", L, a, b);
        }
    }

}
