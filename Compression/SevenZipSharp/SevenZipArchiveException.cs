// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipArchiveException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class SevenZipArchiveException : SevenZipException
  {
    public const string DefaultMessage = "Invalid archive: open/read error! Is it encrypted and a wrong password was provided?";

    public SevenZipArchiveException()
      : base("Invalid archive: open/read error! Is it encrypted and a wrong password was provided?")
    {
    }

    public SevenZipArchiveException(string message)
      : base("Invalid archive: open/read error! Is it encrypted and a wrong password was provided?", message)
    {
    }

    public SevenZipArchiveException(string message, Exception inner)
      : base("Invalid archive: open/read error! Is it encrypted and a wrong password was provided?", message, inner)
    {
    }

    protected SevenZipArchiveException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
