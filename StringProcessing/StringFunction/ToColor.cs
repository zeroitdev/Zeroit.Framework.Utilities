// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToColor.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //Color c = "ff00bb".ToColor();
        //LayoutRoot.Background = new SolidColorBrush(c);

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Convert a (A)RGB string to a Silverlight Color object
        /// </summary>
        /// <param name="argb">An RGB or an ARGB string</param>
        /// <returns>a Color object</returns>
        public static Color ToColor(this string argb)
        {
            argb = argb.Replace("#", "");
            byte a = System.Convert.ToByte("ff", 16);
            byte pos = 0;
            if (argb.Length == 8)
            {
                a = System.Convert.ToByte(argb.Substring(pos, 2), 16);
                pos = 2;
            }
            byte r = System.Convert.ToByte(argb.Substring(pos, 2), 16);
            pos += 2;
            byte g = System.Convert.ToByte(argb.Substring(pos, 2), 16);
            pos += 2;
            byte b = System.Convert.ToByte(argb.Substring(pos, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }

    }
}
