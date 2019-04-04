// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="FileOverwriteEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class FileOverwriteEventArgs : EventArgs
  {
    public FileOverwriteEventArgs(string fileName)
    {
      this.FileName = fileName;
    }

    public bool Cancel { get; set; }

    public string FileName { get; set; }
  }
}
