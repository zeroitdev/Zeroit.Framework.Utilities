// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="V.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Class WebColor.
    /// </summary>
    public static partial class WebColor
    {
        /// <summary>
        /// The vampire black
        /// </summary>
        private static Color VampireBlack = Color.FromArgb(8, 8, 8);
        /// <summary>
        /// The van dyke brown
        /// </summary>
        private static Color VanDykeBrown = Color.FromArgb(102, 66, 40);
        /// <summary>
        /// The vanilla
        /// </summary>
        private static Color Vanilla = Color.FromArgb(243, 229, 171);
        /// <summary>
        /// The vanilla ice
        /// </summary>
        private static Color VanillaIce = Color.FromArgb(243, 143, 169);
        /// <summary>
        /// The vegas gold
        /// </summary>
        private static Color VegasGold = Color.FromArgb(197, 179, 88);
        /// <summary>
        /// The venetian red
        /// </summary>
        private static Color VenetianRed = Color.FromArgb(200, 8, 21);
        /// <summary>
        /// The verdigris
        /// </summary>
        private static Color Verdigris = Color.FromArgb(67, 179, 174);
        /// <summary>
        /// The vermilion
        /// </summary>
        private static Color Vermilion = Color.FromArgb(227, 66, 52);
        /// <summary>
        /// The vermilion variant
        /// </summary>
        private static Color VermilionVariant = Color.FromArgb(217, 56, 30);
        /// <summary>
        /// The veronica
        /// </summary>
        private static Color Veronica = Color.FromArgb(160, 32, 240);
        /// <summary>
        /// The verse green
        /// </summary>
        private static Color VerseGreen = Color.FromArgb(24, 136, 13);
        /// <summary>
        /// The very light azure
        /// </summary>
        private static Color VeryLightAzure = Color.FromArgb(116, 187, 251);
        /// <summary>
        /// The very light blue
        /// </summary>
        private static Color VeryLightBlue = Color.FromArgb(102, 102, 255);
        /// <summary>
        /// The very light malachite green
        /// </summary>
        private static Color VeryLightMalachiteGreen = Color.FromArgb(100, 233, 134);
        /// <summary>
        /// The very light tangelo
        /// </summary>
        private static Color VeryLightTangelo = Color.FromArgb(255, 176, 119);
        /// <summary>
        /// The very pale orange
        /// </summary>
        private static Color VeryPaleOrange = Color.FromArgb(255, 223, 191);
        /// <summary>
        /// The very pale yellow
        /// </summary>
        private static Color VeryPaleYellow = Color.FromArgb(255, 255, 191);
        /// <summary>
        /// The violet
        /// </summary>
        private static Color Violet = Color.FromArgb(143, 0, 255);
        /// <summary>
        /// The violet col wheel
        /// </summary>
        private static Color VioletColWheel = Color.FromArgb(127, 0, 255);
        /// <summary>
        /// The violet crayola
        /// </summary>
        private static Color VioletCrayola = Color.FromArgb(150, 61, 127);
        /// <summary>
        /// The violet ryb
        /// </summary>
        private static Color VioletRYB = Color.FromArgb(134, 1, 175);
        /// <summary>
        /// The violet web
        /// </summary>
        private static Color VioletWeb = Color.FromArgb(238, 130, 238);
        /// <summary>
        /// The violet blue
        /// </summary>
        private static Color VioletBlue = Color.FromArgb(50, 74, 178);
        /// <summary>
        /// The violet blue crayola
        /// </summary>
        private static Color VioletBlueCrayola = Color.FromArgb(118, 110, 200);
        /// <summary>
        /// The violet red
        /// </summary>
        private static Color VioletRed = Color.FromArgb(247, 83, 148);
        /// <summary>
        /// The violet red variant
        /// </summary>
        private static Color VioletRedVariant = Color.FromArgb(137, 20, 70);
        /// <summary>
        /// The violin brown
        /// </summary>
        private static Color ViolinBrown = Color.FromArgb(103, 68, 3);
        /// <summary>
        /// The viridian
        /// </summary>
        private static Color Viridian = Color.FromArgb(64, 130, 109);
        /// <summary>
        /// The viridian green
        /// </summary>
        private static Color ViridianGreen = Color.FromArgb(0, 150, 152);
        /// <summary>
        /// The vista blue
        /// </summary>
        private static Color VistaBlue = Color.FromArgb(124, 158, 217);
        /// <summary>
        /// The vivid amber
        /// </summary>
        private static Color VividAmber = Color.FromArgb(204, 153, 0);
        /// <summary>
        /// The vivid auburn
        /// </summary>
        private static Color VividAuburn = Color.FromArgb(146, 39, 36);
        /// <summary>
        /// The vivid burgundy
        /// </summary>
        private static Color VividBurgundy = Color.FromArgb(159, 29, 53);
        /// <summary>
        /// The vivid cerise
        /// </summary>
        private static Color VividCerise = Color.FromArgb(218, 29, 129);
        /// <summary>
        /// The vivid cerulean
        /// </summary>
        private static Color VividCerulean = Color.FromArgb(0, 170, 238);
        /// <summary>
        /// The vivid crimson
        /// </summary>
        private static Color VividCrimson = Color.FromArgb(204, 0, 51);
        /// <summary>
        /// The vivid gamboge
        /// </summary>
        private static Color VividGamboge = Color.FromArgb(255, 153, 0);
        /// <summary>
        /// The vivid lime green
        /// </summary>
        private static Color VividLimeGreen = Color.FromArgb(166, 214, 8);
        /// <summary>
        /// The vivid malachite
        /// </summary>
        private static Color VividMalachite = Color.FromArgb(0, 204, 51);
        /// <summary>
        /// The vivid mulberry
        /// </summary>
        private static Color VividMulberry = Color.FromArgb(184, 12, 227);
        /// <summary>
        /// The vivid orange
        /// </summary>
        private static Color VividOrange = Color.FromArgb(255, 95, 0);
        /// <summary>
        /// The vivid orange peel
        /// </summary>
        private static Color VividOrangePeel = Color.FromArgb(255, 160, 0);
        /// <summary>
        /// The vivid orchid
        /// </summary>
        private static Color VividOrchid = Color.FromArgb(204, 0, 255);
        /// <summary>
        /// The vivid raspberry
        /// </summary>
        private static Color VividRaspberry = Color.FromArgb(255, 0, 108);
        /// <summary>
        /// The vivid red
        /// </summary>
        private static Color VividRed = Color.FromArgb(247, 13, 26);
        /// <summary>
        /// The vivid red tangelo
        /// </summary>
        private static Color VividRedTangelo = Color.FromArgb(223, 97, 36);
        /// <summary>
        /// The vivid sky blue
        /// </summary>
        private static Color VividSkyBlue = Color.FromArgb(0, 204, 255);
        /// <summary>
        /// The vivid tangelo
        /// </summary>
        private static Color VividTangelo = Color.FromArgb(240, 116, 39);
        /// <summary>
        /// The vivid tangerine
        /// </summary>
        private static Color VividTangerine = Color.FromArgb(255, 160, 137);
        /// <summary>
        /// The vivid vermilion
        /// </summary>
        private static Color VividVermilion = Color.FromArgb(229, 96, 36);
        /// <summary>
        /// The vivid violet
        /// </summary>
        private static Color VividViolet = Color.FromArgb(159, 0, 255);
        /// <summary>
        /// The vivid yellow
        /// </summary>
        private static Color VividYellow = Color.FromArgb(255, 227, 2);
        /// <summary>
        /// The vodka
        /// </summary>
        private static Color Vodka = Color.FromArgb(191, 192, 238);
        /// <summary>
        /// The volt
        /// </summary>
        private static Color Volt = Color.FromArgb(205, 255, 0);
    }
}