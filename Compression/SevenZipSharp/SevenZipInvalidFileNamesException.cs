// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipInvalidFileNamesException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class SevenZipInvalidFileNamesException : SevenZipException
  {
    public const string DefaultMessage = "Invalid file names have been specified: ";

    public SevenZipInvalidFileNamesException()
      : base("Invalid file names have been specified: ")
    {
    }

    public SevenZipInvalidFileNamesException(string message)
      : base("Invalid file names have been specified: ", message)
    {
    }

    public SevenZipInvalidFileNamesException(string message, Exception inner)
      : base("Invalid file names have been specified: ", message, inner)
    {
    }

    protected SevenZipInvalidFileNamesException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
