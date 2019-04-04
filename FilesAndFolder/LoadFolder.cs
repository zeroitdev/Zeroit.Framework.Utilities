// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="LoadFolder.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
