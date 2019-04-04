// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FrameRegion.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// Class DrawRenderer.
    /// </summary>
    public static partial class DrawRenderer
    {
        // **************************************** WIN32 ENTRY POINTS

        // ************************************************** FrameRgn

        /// <summary>
        /// Frames the RGN.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hrgn">The HRGN.</param>
        /// <param name="hbr">The HBR.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32")]
        static extern bool FrameRgn(IntPtr hdc,
                                      IntPtr hrgn,
                                      IntPtr hbr,
                                      int nWidth,
                                      int nHeight);

        // ******************************************** GetStockObject

        /// <summary>
        /// Gets the stock object.
        /// </summary>
        /// <param name="stock_object">The stock object.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32")]
        static extern IntPtr GetStockObject(StockObjects stock_object);

        // ******************************** WIN32 ENUMS AND STRUCTURES

        // ********************************************** StockObjects

        /// <summary>
        /// Stock Objects Enum
        /// </summary>
        public enum StockObjects : int
        {
            /// <summary>
            /// The white brush
            /// </summary>
            WHITE_BRUSH = 0,
            /// <summary>
            /// The ltgray brush
            /// </summary>
            LTGRAY_BRUSH = 1,
            /// <summary>
            /// The gray brush
            /// </summary>
            GRAY_BRUSH = 2,
            /// <summary>
            /// The dkgray brush
            /// </summary>
            DKGRAY_BRUSH = 3,
            /// <summary>
            /// The black brush
            /// </summary>
            BLACK_BRUSH = 4,
            /// <summary>
            /// The null brush
            /// </summary>
            NULL_BRUSH = 5,
            /// <summary>
            /// The hollow brush
            /// </summary>
            HOLLOW_BRUSH = NULL_BRUSH,
            /// <summary>
            /// The white pen
            /// </summary>
            WHITE_PEN = 6,
            /// <summary>
            /// The black pen
            /// </summary>
            BLACK_PEN = 7,
            /// <summary>
            /// The null pen
            /// </summary>
            NULL_PEN = 8,
            /// <summary>
            /// The oem fixed font
            /// </summary>
            OEM_FIXED_FONT = 10,
            /// <summary>
            /// The ANSI fixed font
            /// </summary>
            ANSI_FIXED_FONT = 11,
            /// <summary>
            /// The ANSI variable font
            /// </summary>
            ANSI_VAR_FONT = 12,
            /// <summary>
            /// The system font
            /// </summary>
            SYSTEM_FONT = 13,
            /// <summary>
            /// The device default font
            /// </summary>
            DEVICE_DEFAULT_FONT = 14,
            /// <summary>
            /// The default palette
            /// </summary>
            DEFAULT_PALETTE = 15,
            /// <summary>
            /// The system fixed font
            /// </summary>
            SYSTEM_FIXED_FONT = 16,
            /// <summary>
            /// The default GUI font
            /// </summary>
            DEFAULT_GUI_FONT = 17,
            /// <summary>
            /// The dc brush
            /// </summary>
            DC_BRUSH = 18,
            /// <summary>
            /// The dc pen
            /// </summary>
            DC_PEN = 19,
        }

        // ******************************************* C# ENTRY POINTS

        // ********************************************** frame_region

        /// <summary>
        /// Draws a black border around the specified region
        /// </summary>
        /// <param name="graphics">the Graphics object on which to draw the frame</param>
        /// <param name="region">region around which to draw the frame</param>
        /// <param name="stockObjects">The stock objects.</param>
        public static void DrawBorderAroundRegion(this System.Drawing.Graphics graphics, Region region, StockObjects stockObjects)
        {
            var hregn = region.GetHrgn(graphics);
            var hdc = graphics.GetHdc();

            FrameRgn(hdc,
                       hregn,
                       GetStockObject(stockObjects),
                       1,
                       1);
            graphics.ReleaseHdc(hdc);
        }

    }
}
