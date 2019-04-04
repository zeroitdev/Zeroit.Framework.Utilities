// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LoadFile.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for Selecting Files
    /// </summary>
    public static class LoadFile
    {
        /// <summary>
        /// Select File
        /// </summary>
        /// <param name="dialog">Set Open File Dialog</param>
        /// <param name="sourceControl">Set Source Control</param>
        /// <param name="outputControl">Set Output Control</param>
        /// <param name="filter">Set string Filter</param>
        /// <param name="title">Set</param>
        public static void SelectFile(
            OpenFileDialog dialog, 
            Control sourceControl, 
            Control outputControl,
            string filter,
            string title = "Select File")
        {

            dialog.Title = title;

            if (filter == string.Empty)
            {
                filter = @"All Files (*.*)|*.*";
            }

            dialog.Filter = filter;
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK && dialog.SafeFileName != null)
            {
                outputControl.Text = dialog.FileName;
            }

            sourceControl.Focus();
        }

    }
}
