// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DWMWINDOWATTRIBUTE.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Enum DWMWINDOWATTRIBUTE
    /// </summary>
    public enum DWMWINDOWATTRIBUTE
    {
        /// <summary>
        /// The dwmwa allow ncpaint
        /// </summary>
        DWMWA_ALLOW_NCPAINT = 4,
        /// <summary>
        /// The dwmwa caption button bounds
        /// </summary>
        DWMWA_CAPTION_BUTTON_BOUNDS = 5,
        /// <summary>
        /// The dwmwa fli p3 d policy
        /// </summary>
        DWMWA_FLIP3D_POLICY = 8,
        /// <summary>
        /// The dwmwa force iconic representation
        /// </summary>
        DWMWA_FORCE_ICONIC_REPRESENTATION = 7,
        /// <summary>
        /// The dwmwa last
        /// </summary>
        DWMWA_LAST = 9,
        /// <summary>
        /// The dwmwa ncrendering enabled
        /// </summary>
        DWMWA_NCRENDERING_ENABLED = 1,
        /// <summary>
        /// The dwmwa ncrendering policy
        /// </summary>
        DWMWA_NCRENDERING_POLICY = 2,
        /// <summary>
        /// The dwmwa nonclient RTL layout
        /// </summary>
        DWMWA_NONCLIENT_RTL_LAYOUT = 6,
        /// <summary>
        /// The dwmwa transitions forcedisabled
        /// </summary>
        DWMWA_TRANSITIONS_FORCEDISABLED = 3
    }
}
