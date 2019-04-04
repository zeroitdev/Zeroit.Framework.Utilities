// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="_ColorFunctionalities.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    /// <summary>
    /// Class WebColor.
    /// </summary>
    public static partial class WebColor
    {

        #region Private Fields


        /// <summary>
        /// The colors a
        /// </summary>
        private static readonly Dictionary<string, Color> colorsA = new Dictionary<string, Color>()
        {
            { "AbsoluteZero", AbsoluteZero},
            { "Acajou", Acajou},
            { "AcidGreen", AcidGreen},
            { "Aero", Aero},
            { "AeroBlue", AeroBlue},
            { "AfricanViolet", AfricanViolet},
            { "AirForceBlueUSAF", AirForceBlueUSAF},
            { "AirSuperiorityBlue", AirSuperiorityBlue},
            { "AlabamaCrimson", AlabamaCrimson},
            { "Alabaster", Alabaster},
            { "AliceBlue", AliceBlue},
            { "AlienArmpit", AlienArmpit},
            { "AlizarinCrimson", AlizarinCrimson},
            { "AlloyOrange", AlloyOrange},
            { "Almond", Almond},
            { "Amaranth", Amaranth},
            { "AmaranthDeepPurple", AmaranthDeepPurple},
            { "AmaranthPink", AmaranthPink},
            { "AmaranthPurple", AmaranthPurple},
            { "AmaranthRed", AmaranthRed},
            { "Amazon", Amazon},
            { "Amazonite", Amazonite},
            { "Amber", Amber},
            { "AmberSAEECE", AmberSAEECE},
            { "AmericanBlue", AmericanBlue},
            { "AmericanBronze", AmericanBronze},
            { "AmericanBrown", AmericanBrown},
            { "AmericanGold", AmericanGold},
            { "AmericanGreen", AmericanGreen},
            { "AmericanOrange", AmericanOrange},
            { "AmericanPink", AmericanPink},
            { "AmericanPurple", AmericanPurple},
            { "AmericanRed", AmericanRed},
            { "AmericanRose", AmericanRose},
            { "AmericanSilver", AmericanSilver},
            { "AmericanViolet", AmericanViolet},
            { "AmericanYellow", AmericanYellow},
            { "Amethyst", Amethyst},
            { "AndroidGreen", AndroidGreen},
            { "AntiFlashWhite", AntiFlashWhite},
            { "AntiqueBrass", AntiqueBrass},
            { "AntiqueBronze", AntiqueBronze},
            { "AntiqueFuchsia", AntiqueFuchsia},
            { "AntiqueRuby", AntiqueRuby},
            { "AntiqueWhite", AntiqueWhite},
            { "AoEnglish", AoEnglish},
            { "Apple", Apple},
            { "AppleGreen", AppleGreen},
            { "Apricot", Apricot},
            { "Aqua", Aqua},
            { "Aquamarine", Aquamarine},
            { "ArcticLime", ArcticLime},
            { "ArmyGreen", ArmyGreen},
            { "Arsenic", Arsenic},
            { "Artichoke", Artichoke},
            { "ArylideYellow", ArylideYellow},
            { "AshGray", AshGray},
            { "Asparagus", Asparagus},
            { "AteneoBlue", AteneoBlue},
            { "AtomicTangerine", AtomicTangerine},
            { "Auburn", Auburn},
            { "Aureolin", Aureolin},
            { "AuroMetalSaurus", AuroMetalSaurus},
            { "Avocado", Avocado},
            { "Awesome", Awesome},
            { "Axolotl", Axolotl},
            { "AztecGold", AztecGold},
            { "Azure", Azure},
            { "AzureWeb", AzureWeb},
            { "AzureMist", AzureMist},
            { "AzureishWhite", AzureishWhite}

        };


        #endregion

        #region Public Properties


        /// <summary>
        /// Gets the color a.
        /// </summary>
        /// <value>The color a.</value>
        public static Dictionary<string, Color> ColorA
        {
            get { return colorsA; }
        }

        #endregion

        #region Private Methods
        /**
		 * Get human readable name from a Color.
		 */

        /// <summary>
        /// Get Color Name
        /// </summary>
        /// <param name="InColor">Set in-color</param>
        /// <returns>System.String.</returns>
        public static string GetColorName(Color InColor)
        {
            Color lab = Color.FromArgb(InColor.R, InColor.G, InColor.B);

            string name = "Unknown";
            float diff = (float)double.PositiveInfinity;

            foreach (KeyValuePair<string, Color> kvp in colorsA)
            {
                name = kvp.Key;
            }

            return name;
        }


        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="InColor">Color of the in.</param>
        /// <returns>Color.</returns>
        public static Color GetColor(Color InColor)
        {
            Color lab = Color.FromArgb(InColor.R, InColor.G, InColor.B);


            float diff = (float)double.PositiveInfinity;

            foreach (KeyValuePair<string, Color> kvp in colorsA)
            {
                lab = kvp.Value;
            }

            return lab;
        }


        #endregion

    }
}
