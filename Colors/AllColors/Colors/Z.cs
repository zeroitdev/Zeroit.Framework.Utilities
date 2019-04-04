// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="Z.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Class WebColor.
    /// </summary>
    public static partial class WebColor
    {

        /// <summary>
        /// Gets the zaffre.
        /// </summary>
        /// <value>The zaffre.</value>
        public static Color Zaffre
        {
            get { return zaffre; }
        }

        /// <summary>
        /// Gets the zinnwaldite brown.
        /// </summary>
        /// <value>The zinnwaldite brown.</value>
        public static Color ZinnwalditeBrown
        {
            get { return zinnwalditeBrown; }
            
        }

        /// <summary>
        /// Gets the zomp.
        /// </summary>
        /// <value>The zomp.</value>
        public static Color Zomp
        {
            get { return zomp; }
        }



        /// <summary>
        /// The zaffre
        /// </summary>
        private static Color zaffre = Color.FromArgb(0, 20, 168);
        /// <summary>
        /// The zinnwaldite brown
        /// </summary>
        private static Color zinnwalditeBrown = Color.FromArgb(44, 22, 8);
        /// <summary>
        /// The zomp
        /// </summary>
        private static Color zomp = Color.FromArgb(57, 167, 142);
    }
}