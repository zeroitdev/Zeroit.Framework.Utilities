// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="UpdateData.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal struct UpdateData
  {
    public uint FilesCount;
    public InternalCompressionMode Mode;

    public Dictionary<int, string> FileNamesToModify { get; set; }

    public List<ArchiveFileInfo> ArchiveFileData { get; set; }
  }
}
