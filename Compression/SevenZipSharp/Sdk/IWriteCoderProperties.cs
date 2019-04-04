// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="IWriteCoderProperties.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip.Sdk
{
  internal interface IWriteCoderProperties
  {
    void WriteCoderProperties(Stream outStream);
  }
}
