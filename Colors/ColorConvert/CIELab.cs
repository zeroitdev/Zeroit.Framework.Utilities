// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CIELab.cs" company="Zeroit Dev Technologies">
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
