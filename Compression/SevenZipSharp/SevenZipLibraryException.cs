// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipLibraryException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class SevenZipLibraryException : SevenZipException
  {
    public static readonly string DefaultMessage = "Can not load 7-zip library or internal COM error!";

    public SevenZipLibraryException()
      : base(SevenZipLibraryException.DefaultMessage)
    {
    }

    public SevenZipLibraryException(string message)
      : base(SevenZipLibraryException.DefaultMessage, message)
    {
    }

    public SevenZipLibraryException(string message, Exception inner)
      : base(SevenZipLibraryException.DefaultMessage, message, inner)
    {
    }

    protected SevenZipLibraryException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
