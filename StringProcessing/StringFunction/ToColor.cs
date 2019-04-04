// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToColor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
