// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="XYZ.cs" company="Zeroit Dev Technologies">
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
