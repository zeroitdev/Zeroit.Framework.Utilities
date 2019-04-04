// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LoadFile.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
