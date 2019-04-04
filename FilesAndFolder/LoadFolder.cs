// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LoadFolder.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Files
{
    /// <summary>
    /// A class collection for Selecting a Folder
    /// </summary>
    public static class LoadFolder
    {
        /// <summary>
        /// Select Folder
        /// </summary>
        /// <param name="Dialog">Set Folder Browser Dialog</param>
        /// <param name="sourceControl">Set Source Control</param>
        /// <param name="outputControl">Set Output Control</param>
        public static void SelectFolder(FolderBrowserDialog Dialog, Control sourceControl, Control outputControl)
        {

            Dialog.ShowDialog();
            outputControl.Text = Dialog.SelectedPath;
            sourceControl.Focus();
        }
    }
}
